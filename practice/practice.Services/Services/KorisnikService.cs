using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice.Model;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Helpers;
using practice.Services;
using practice.Services.Requests;
using practice.Services.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace practice.Services
{
    public class KorisnikService : BaseService<MKorisnici, Korisnici,KorisniciSearchObject,KorisniciPostReq,KorisniciUpdateReq>,IKorisnikService
    {
        public KorisnikService(PracticeContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Korisnici> AddFilter(IQueryable<Korisnici> query, KorisniciSearchObject search = null)
        {
            if (!string.IsNullOrEmpty(search.Naziv))
            {
                query = query.Where(x => search.Naziv.Contains(x.FirstName) || search.Naziv.Contains(x.LastName));
            }
            return query;
        }
        public override async Task<MKorisnici> Insert(KorisniciPostReq req)
        {
            var korisnik = new Korisnici();
            _mapper.Map(req, korisnik);
            korisnik.LozinkaSalt = Generator.GenerateSalt();
            korisnik.LozinkaHash = Generator.GenerateHash(korisnik.LozinkaSalt, req.Lozinka);
            GenerisiToken(korisnik);
            await _context.AddAsync(korisnik);
            await _context.SaveChangesAsync();
            await dodajUlogu(korisnik);
            return _mapper.Map<MKorisnici>(korisnik);
        }

        private string GenerisiToken(Korisnici korisnik)
        {
            var token = Generator.GenerateToken(10);
            var tokenSalt = Generator.GenerateSalt();
            korisnik.VerifikacijskiTokenSalt = tokenSalt;
            korisnik.VerifikacijskiToken = Generator.GenerateHash(tokenSalt, token);
            EmailSender.SendEmail(token, korisnik.Email, korisnik.FirstName);
            return token.ToString();
        }

        public IActionResult Verify(int korisnikID, string token)
        {
            var mail = new EmailToken()
            {
                mail = "adis.sipkovic@edu.fit.ba",
                token = Generator.GenerateToken(15)
            };


            var factory = new ConnectionFactory
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitmq",
                UserName = Environment.GetEnvironmentVariable("RABBITMQ_USER") ?? "guest",
                Password = Environment.GetEnvironmentVariable("RABBITMQ_PASS") ?? "guest",
                Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var message = "Hello, this is a test message";
            Console.WriteLine(message);
            Console.WriteLine("Factory - hostname, username, password, port -> " + factory.HostName + " " + factory.UserName + " " + factory.Password);
            Console.WriteLine("-----------------------");
            var json = JsonConvert.SerializeObject(mail);
            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);


            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);


            return new OkResult();

        }

        private async Task<bool> dodajUlogu(Korisnici korisnik)
        {
            var korisnikUloga = new KorisniciUloge()
            {
                KorisnikId = korisnik.KorisnikId,
                UlogaId = 2
            };
            await _context.KorisniciUloges.AddAsync(korisnikUloga);
            await _context.SaveChangesAsync();
            return true;
        }

        public override  IQueryable<Korisnici> AddInclude(IQueryable<Korisnici> query)
        {
            //EmailSender.SendEmail("p332jlkafs", "sipkovic.adis1@outlook.com", "Adis");
            return query.Include("KorisniciUloges.Uloga");
        }

        public async Task<MKorisnici> Login(string username, string password)
        {
            var korisnik = await _context.Korisnicis.Include("KorisniciUloges.Uloga").FirstOrDefaultAsync(x=>x.KorisnickoIme==username);

            if (korisnik == null)
                return null;

            var hash = Generator.GenerateHash(korisnik.LozinkaSalt, password);

            if (korisnik.LozinkaHash != hash)
            {
                return null;
            }
           return _mapper.Map<MKorisnici>(korisnik);
        }

        public override async Task<bool> Delete(int id)
        {
            var korisnik = await _context.Korisnicis.FindAsync(id);
            _context.Remove(korisnik);
            var korisnikUloga = await _context.KorisniciUloges.Where(x=>x.KorisnikId==id).FirstOrDefaultAsync();
            _context.Remove(korisnikUloga);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task ChangePass(int id, PassChange req)
        {
            var entity = await _context.Korisnicis.FindAsync(id);
            if (entity == null)
            {
                throw new UserException("No object with that id");
            }
            var stari_password_hash = Generator.GenerateHash(entity.LozinkaSalt, req.stari);
            if(stari_password_hash != entity.LozinkaHash)
            {
                throw new UserException("You haven't entered a valid old password");
            }

            entity.LozinkaHash = Generator.GenerateHash(entity.LozinkaSalt, req.novi);

            await _context.SaveChangesAsync(); 
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using practice.Model;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Helpers;
using practice.Services.Requests;
using practice.Services.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _context.AddAsync(korisnik);
            await _context.SaveChangesAsync();
            var korisnikUloga = new KorisniciUloge()
            {
                KorisnikId=korisnik.KorisnikId,
                UlogaId=2
            };
            await _context.KorisniciUloges.AddAsync(korisnikUloga);
            await _context.SaveChangesAsync();
            return _mapper.Map<MKorisnici>(korisnik);
        }
        public override  IQueryable<Korisnici> AddInclude(IQueryable<Korisnici> query)
        {
            EmailSender.SendEmail("p332jlkafs", "sipkovic.adis1@outlook.com", "Adis");
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
    }
}

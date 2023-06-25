using AutoMapper;
using Microsoft.EntityFrameworkCore;
using practice.Model;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Helpers;
using practice.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly PracticeContext _context;
        public IMapper _mapper { get; set; }
        public KorisnikService(PracticeContext practice, IMapper mapper)
        {
            _context=practice; 
            _mapper=mapper;
        }
        public List<MKorisnici> Get()
        {
            var list = _context.Korisnicis.ToList();

            return _mapper.Map<List<MKorisnici>>(list);
        }

        public MKorisnici Insert(KorisniciPostReq request)
        {
            var korisnik = new Korisnici();
            _mapper.Map(request, korisnik);
            korisnik.LozinkaSalt = Generator.GenerateSalt();
            korisnik.LozinkaHash = Generator.GenerateHash(korisnik.LozinkaSalt, request.Lozinka);
            _context.Korisnicis.Add(korisnik);
            _context.SaveChanges();
            return _mapper.Map<MKorisnici>(korisnik);
        }

        public MKorisnici Update(int id, KorisniciUpdateReq request)
        {
            var korisnik = _context.Korisnicis.Find(id);

            _mapper.Map(request, korisnik);

            _context.SaveChanges();

            return _mapper.Map<MKorisnici>(korisnik);

        }

        public void Delete(int id)
        {
            var korisnik = _context.Korisnicis.Find(id);
            _context.Remove(korisnik);
            _context.SaveChanges();
        }

        //public MKorisnici GetById(int id)
        //{
        //    var find = _context.Korisnicis.Where(x=>x.KorisnikId==id).FirstOrDefault();

        //    return find;
        //}
    }
}

using practice.Model;
using practice.Services.Database;
using practice.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public interface IKorisnikService
    {
        public List<MKorisnici> Get();
        public MKorisnici Insert(KorisniciPostReq request);
        public MKorisnici Update(int id, KorisniciUpdateReq request);
        public void Delete(int id);
        //public MKorisnici GetById(int id);
    }
}

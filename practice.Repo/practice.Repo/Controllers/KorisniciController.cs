using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using practice.Model;
using practice.Services;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Requests;
using practice.Services.SearchObjects;

namespace practice.Repo.Controllers
{
    [ApiController]
    public class KorisniciController : BaseController<MKorisnici, KorisniciSearchObject,KorisniciPostReq,KorisniciUpdateReq>
    {


        //[HttpGet("id")]
        //public Korisnici GetById(int id)
        //{
        //    return _korisnikService.GetById(id);
        //}
        public KorisniciController(IKorisnikService service) : base(service)
        {
        }
    }
}
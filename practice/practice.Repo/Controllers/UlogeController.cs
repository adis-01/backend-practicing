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
    [Route("[controller]")]
    public class UlogeController : BaseController<MUloge,KorisniciSearchObject,UlogePostRequest,object>
    {

        
        //[HttpGet("id")]
        //public Korisnici GetById(int id)
        //{
        //    return _korisnikService.GetById(id);
        //}
        public UlogeController(IUlogeService service) : base(service)
        {
            
        }
        
    }
}
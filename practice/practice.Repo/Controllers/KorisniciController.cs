using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using practice.Model;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services;
using practice.Services.Requests;
using practice.Services.SearchObjects;
using Microsoft.AspNetCore.Identity;

namespace practice.Repo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles ="Korisnik")]
    public class KorisniciController : BaseController<MKorisnici, KorisniciSearchObject,KorisniciPostReq,KorisniciUpdateReq>
    {

        protected IKorisnikService _service;
        //[HttpGet("id")]
        //public Korisnici GetById(int id)
        //{
        //    return _korisnikService.GetById(id);
        //}
        public KorisniciController(IKorisnikService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("verify/{id}")]
        [AllowAnonymous]
        public IActionResult Verify(int id, string token)
        {
            return  _service.Verify(id, token);
        }

        [HttpPost("PassChange/{id}")]
        [Authorize(Roles ="Korisnik,Administrator")]
        public async Task ChangePass(int id, [FromBody] PassChange req)
        {
            await _service.ChangePass(id, req);
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<MKorisnici> Login([FromBody] LoginRequest req)
        {
            var username = req.username;
            var password = req.password;
            return await _service.Login(username, password);
        }
    }
}
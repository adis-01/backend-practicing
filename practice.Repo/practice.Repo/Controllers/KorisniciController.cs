using Microsoft.AspNetCore.Mvc;
using practice.Model;
using practice.Services;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Requests;

namespace practice.Repo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;
        private readonly PracticeContext _practice;
        private readonly ILogger<WeatherForecastController> _logger;

        public KorisniciController(ILogger<WeatherForecastController> logger, IKorisnikService korisnikService)
        {
            _logger = logger;
            _korisnikService = korisnikService;
        }

        [HttpGet]
        public IEnumerable<MKorisnici> Get() {
            return _korisnikService.Get();
        }

        [HttpPost]
        public MKorisnici Insert(KorisniciPostReq req)
        {
            return _korisnikService.Insert(req);
        }

        [HttpPut("{id}")]
        public MKorisnici Update(int id,KorisniciUpdateReq req)
        {
            return _korisnikService.Update(id,req);
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            _korisnikService.Delete(id);
        }


        //[HttpGet("id")]
        //public Korisnici GetById(int id)
        //{
        //    return _korisnikService.GetById(id);
        //}
    }
}
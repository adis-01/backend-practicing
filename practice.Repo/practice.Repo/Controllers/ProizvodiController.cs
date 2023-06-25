using Microsoft.AspNetCore.Mvc;
using practice.Model;
using practice.Services;
using practice.Services.Data;
using practice.Services.Database;

namespace practice.Repo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : ControllerBase
    {
        private readonly IPriceService _proizvodiService;
        private readonly PracticeContext _practice;
        private readonly ILogger<WeatherForecastController> _logger;

        public ProizvodiController(ILogger<WeatherForecastController> logger,IPriceService proizvodiService,PracticeContext practice)
        {
            _logger = logger;
            _proizvodiService=proizvodiService; 
            _practice=practice;
        }

        [HttpGet]
        public IEnumerable<Price> Get() {
            return _proizvodiService.Get();
        }

        [HttpGet("id")]
        public Price GetById(int id)
        {
            return _proizvodiService.GetById(id);
        }
    }
}
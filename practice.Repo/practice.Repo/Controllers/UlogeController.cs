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
    public class UlogeController : ControllerBase
    {
        private readonly IUlogeService _ulogeService;
        private readonly ILogger<WeatherForecastController> _logger;

        public UlogeController(ILogger<WeatherForecastController> logger, IUlogeService ulogeService)
        {
            _logger = logger;
            _ulogeService = ulogeService;
        }

        [HttpGet()]
        public IList<MUloge> GetAll()
        {
            return _ulogeService.GetUloge();
        }

        [HttpGet("{id}")]
        public MUloge GetByID(int id)
        {
            return _ulogeService.GetUlogaById(id);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using practice.Model;
using practice.Services;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Requests;

namespace practice.Repo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;
        private readonly PracticeContext _practice;
        private readonly ILogger<WeatherForecastController> _logger;

        public PriceController(ILogger<WeatherForecastController> logger,IPriceService proizvodiService,PracticeContext practice)
        {
            _logger = logger;
            _priceService=proizvodiService; 
            _practice=practice;
        }

        [HttpGet]
        public async Task<IList<MPrice>> Get() {
            return await _priceService.Get();
        }

        [HttpGet("id")]
        public async Task<MPrice> GetById(int? id)
        {
            return await _priceService.GetByIdOptional(id);
        }

        [HttpPost()]
        public async Task<MPrice> Insert(PricePostReq req)
        {
            return await _priceService.Insert(req);
        }

        [HttpPut("id")]
        public async Task<MPrice> Update(int id, PriceUpdateReq req) {
            return await _priceService.Update(id, req);
        }

        [HttpDelete("id")]
        public void Delete (int id)
        {
            var find = _practice.Prices.Find(id);
            _practice.Remove(find);
            _practice.SaveChanges();
        }
    }
}
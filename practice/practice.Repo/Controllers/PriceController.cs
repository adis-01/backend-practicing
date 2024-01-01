using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practice.Model;
using practice.Services;
using practice.Services.Requests;
using practice.Services.SearchObjects;

namespace practice.Repo.Controllers
{
    [ApiController]
    public class PriceController : BaseController<MPrice, PriceSearchObject, PricePostReq, PriceUpdateReq>
    {
        public IPriceService _price;
        public PriceController(IPriceService price) : base(price)
        {
            _price = price;
        }

       
        [HttpGet("image/{pricaID}")]
        public async Task<IActionResult> GetImage (int pricaID)
        {
            return await _price.GetImage(pricaID);
        }

       
    }
}

using Microsoft.AspNetCore.Mvc;
using practice.Model;
using practice.Services;
using practice.Services.Requests;
using practice.Services.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public interface IPriceService : IBService<MPrice,PriceSearchObject,PricePostReq,PriceUpdateReq>
    {
        Task<IActionResult> GetImage(int id);
    }
}

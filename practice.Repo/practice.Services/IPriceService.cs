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
    public interface IPriceService
    {
        Task<IList<MPrice>> Get();
        public Task<MPrice> GetByIdOptional (int? id);
        public Task<MPrice> Insert(PricePostReq req);
        public Task<MPrice> GetByIdPrice(int id);
        public Task<MPrice> Update(int id, PriceUpdateReq req);
    }
}

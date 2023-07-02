using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice.Model;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Requests;
using practice.Services.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public class PriceService : BaseService<MPrice, Price, PriceSearchObject, PricePostReq, PriceUpdateReq>, IPriceService
    {
        public PriceService(PracticeContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Price> AddFilter(IQueryable<Price> query, PriceSearchObject search = null)
        {
            if(!string.IsNullOrEmpty(search.NazivPrice))
                query = query.Where(x => search.NazivPrice.Contains(x.Naslov));
            return query;
        }
        public override IQueryable<Price> AddInclude(IQueryable<Price> query)
        {
            return query.Include("Korisnik");
        }

        public async Task<IActionResult> GetImage(int id)
        {
            var prica = await _context.Prices.FirstOrDefaultAsync(x=>x.PricaId==id);

            if (prica == null || prica.Slika == null)
                return new NotFoundResult();

            var slikaByte = prica.Slika;

            return new FileContentResult(slikaByte, "image/*");
        }

        public override async Task<MPrice> Insert(PricePostReq req)
        {
            var novaPrica = new Price();
            _mapper.Map(req, novaPrica);
            string slika = req.slikaPrice;
            byte[] slikaByte = Convert.FromBase64String(slika);
            novaPrica.Slika=slikaByte;
            await _context.Prices.AddAsync(novaPrica);
            await _context.SaveChangesAsync();
            return _mapper.Map<MPrice>(novaPrica);
        }

    }
}

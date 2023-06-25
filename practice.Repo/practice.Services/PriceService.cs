using AutoMapper;
using Microsoft.EntityFrameworkCore;
using practice.Model;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Requests;

namespace practice.Services
{
    public class PriceService : IPriceService
    {
        private readonly PracticeContext _practice;
        public IMapper _mapper { get; set; }
        public PriceService(PracticeContext practice, IMapper mapper)
        {
            _practice = practice;
            _mapper = mapper;
        }
        public List<Proizvodi> proizvodis = new List<Proizvodi>()
        {
            new Proizvodi()
            {
                id=1,
                ime="milka",
                vrsta="cokolada"
            },
            new Proizvodi()
            {
                id=2,
                ime="coca-cola",
                vrsta="sok"
            }
        };

        public async Task<IList<MPrice>> Get()
        {
            var list = await _practice.Prices.ToListAsync();
            return _mapper.Map<List<MPrice>>(list);
        }

        public async Task<MPrice> Insert(PricePostReq req)
        {
            var prica = new Price();
            _mapper.Map(req, prica);
            await _practice.Prices.AddAsync(prica);
            await _practice.SaveChangesAsync();
            return _mapper.Map<MPrice>(prica);
        }

        public async Task<MPrice> GetByIdPrice(int id)
        {
            var prica = await _practice.Prices.FindAsync(id);
            return _mapper.Map<MPrice>(prica);
        }

        public async Task<MPrice> GetByIdOptional(int? id)
        {
            if (id.HasValue)
            {
                var find = await _practice.Prices.FindAsync(id);
                return _mapper.Map<MPrice>(find);
            }
            var firstObject =       _practice.Prices.FirstOrDefaultAsync();
            return _mapper.Map<MPrice>(firstObject);
        }

        public async Task<MPrice> Update(int id, PriceUpdateReq req)
        {
            var prica = await _practice.Prices.FindAsync(id);
            _mapper.Map(req, prica);
            await _practice.SaveChangesAsync();
            return _mapper.Map<MPrice>(prica);
        }
    }
}
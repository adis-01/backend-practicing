using practice.Model;
using practice.Services.Data;
using practice.Services.Database;

namespace practice.Services
{
    public class PriceService : IPriceService
    {
        private readonly PracticeContext _practice;
        public PriceService(PracticeContext practice)
        {
            _practice = practice;
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

        public IList<Database.Price> Get()
        {
            var list = _practice.Prices.ToList();
            return list;
        }

        public Price GetById (int id)
        {
            var prica = _practice.Prices.Where(x => x.PricaId == id).FirstOrDefault();

            return prica;
        }
    }
}
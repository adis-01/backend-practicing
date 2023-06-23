using practice.Model;

namespace practice.Services
{
    public class ProizvodiService : IProizvodiService
    {
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

        public IList<Proizvodi> Get()
        {
            return proizvodis;
        }
    }
}
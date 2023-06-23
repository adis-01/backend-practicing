using practice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public interface IProizvodiService
    {
        IList<Proizvodi> Get();
    }
}

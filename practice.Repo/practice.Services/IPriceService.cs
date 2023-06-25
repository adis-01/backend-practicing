using practice.Model;
using practice.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public interface IPriceService
    {
        IList<Price> Get();
        Price GetById (int id);
    }
}

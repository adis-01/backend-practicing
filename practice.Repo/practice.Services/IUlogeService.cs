using practice.Model;
using practice.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public interface IUlogeService
    {
        public IList<MUloge> GetUloge();
        public MUloge GetUlogaById(int id);
    }
}

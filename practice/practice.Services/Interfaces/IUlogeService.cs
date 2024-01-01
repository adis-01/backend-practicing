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
    public interface IUlogeService : IBService<MUloge,KorisniciSearchObject,UlogePostRequest,object>
    {
    }
}

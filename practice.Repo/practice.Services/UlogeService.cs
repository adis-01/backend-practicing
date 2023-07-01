using AutoMapper;
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
    public class UlogeService : BaseService<MUloge, Uloge,KorisniciSearchObject,UlogePostRequest,object>,IUlogeService
    {
        public UlogeService(PracticeContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

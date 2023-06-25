using AutoMapper;
using practice.Model;
using practice.Services.Data;
using practice.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public class UlogeService : IUlogeService
    {
        private readonly PracticeContext _context;
        public IMapper _mapper;

        public UlogeService(PracticeContext context,IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
        }
        public MUloge GetUlogaById(int id)
        {
            var find = _context.Uloges.Find(id);
            return _mapper.Map<MUloge>(find);
        }

        public IList<MUloge> GetUloge()
        {
            var uloge = _context.Uloges.ToList();
            return _mapper.Map<List<MUloge>>(uloge);
        }
    }
}

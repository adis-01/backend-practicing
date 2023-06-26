using AutoMapper;
using Microsoft.EntityFrameworkCore;
using practice.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public class BaseService<T,TDb> : IBService<T> where TDb : class
    {
        protected readonly PracticeContext _context;
        protected IMapper _mapper;
        public BaseService(PracticeContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<T>> GetAll()
        {
            var list = await _context.Set<TDb>().ToListAsync();
            return _mapper.Map<IList<T>>(list);
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _context.Set<TDb>().FindAsync(id);
            return _mapper.Map<T>(entity);
        }

       
    }
}

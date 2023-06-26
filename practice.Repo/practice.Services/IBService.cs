using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public interface IBService<T>
    {
        public Task<IList<T>> GetAll();
        public Task<T> GetById(int id);
    }
}

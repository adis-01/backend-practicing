using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public interface IBService<T,TS,TInsert,TUpdate> where TS : class where TInsert : class where TUpdate : class
    {
        Task<IList<T>> GetAll(TS search = null);
        Task<T> GetById(int id);
        Task<T> Insert(TInsert req);
        Task<T> Update(int id,TUpdate req);
        Task<bool> Delete(int id);
    }
}

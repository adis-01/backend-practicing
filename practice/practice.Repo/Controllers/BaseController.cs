using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using practice.Services;

namespace practice.Repo.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles ="Korisnik")]
    public class BaseController<T,TS,TInsert,TUpdate> : ControllerBase where TS : class where TInsert : class where TUpdate : class
    {
        private readonly IBService<T,TS,TInsert,TUpdate> _service;
        public BaseController(IBService<T,TS,TInsert,TUpdate> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IList<T>> GetAll([FromQuery]TS search = null)
        {
            return await _service.GetAll(search);
        }
        [HttpGet("{id}")]
        public async Task<T> GetById(int id)
        {
            return await _service.GetById(id);
        }
        [HttpPost]
        public async Task<T> Insert([FromBody] TInsert req)
        {
            return await _service.Insert(req);
        }
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }
        [HttpPut("{id}")]
        public async Task<T> Update(int id, TUpdate req)
        {
            return await _service.Update(id,req);
        }
    }
}

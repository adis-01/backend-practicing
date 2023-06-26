using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practice.Services;

namespace practice.Repo.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase
    {
        protected readonly IBService<T> _service;
        public BaseController(IBService<T> service)
        {
            _service=service;
        }

        [HttpGet()]
        public async Task<IList<T>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<T> GetById(int id)
        {
            return await _service.GetById(id);
        }
       
    }
}

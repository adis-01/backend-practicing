using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practice.Model;
using practice.Services;
using practice.Services.Data;
using practice.Services.Database;
using practice.Services.Helpers;
using practice.Services.Requests;

namespace practice.Repo.Controllers
{
    [ApiController]
    public class TKorisniciController2 : BaseController<MKorisnici>
    {
        
        public TKorisniciController2(IBService<MKorisnici> service) : base(service) { }

    }
}

﻿using Microsoft.AspNetCore.Mvc;
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
    public interface IKorisnikService : IBService<MKorisnici, KorisniciSearchObject, KorisniciPostReq, KorisniciUpdateReq> 
    {
        public Task<MKorisnici> Login(string username, string password);
        public IActionResult Verify(int id, string token);
        public Task ChangePass(int id,PassChange req);
    }
}

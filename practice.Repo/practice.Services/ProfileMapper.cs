using AutoMapper;
using practice.Model;
using practice.Services.Database;
using practice.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Korisnici, MKorisnici>();
            CreateMap<KorisniciPostReq, Korisnici>();
            CreateMap<KorisniciUpdateReq,Korisnici>();
            CreateMap<Price, MPrice>();
            CreateMap<PricePostReq, Price>();
            CreateMap<Uloge,MUloge>();
            CreateMap<PriceUpdateReq, Price>();
            CreateMap<UlogePostRequest,Uloge>();
        }
    }
}

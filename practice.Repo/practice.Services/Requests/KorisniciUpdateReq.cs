﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services.Requests
{
    public class KorisniciUpdateReq
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string KorisnickoIme { get; set; } = null!;

        public bool Status { get; set; }

    }
}

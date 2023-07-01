using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services.Requests
{
    public class KorisniciPostReq
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string KorisnickoIme { get; set; } = null!;
        [Compare("LozinkaPonovo",ErrorMessage ="Lozinke se ne podudaraju")]
        public string Lozinka { get; set; } = null!;
        [Compare("Lozinka",ErrorMessage ="Lozinke se ne podudaraju")]
        public string LozinkaPonovo { get; set; } = null!;
        public bool Status { get; set; }
    }
}

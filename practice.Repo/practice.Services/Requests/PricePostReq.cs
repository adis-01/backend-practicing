using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services.Requests
{
    public class PricePostReq
    {
        public string Naslov { get; set; } = null!;

        public string? Opis { get; set; }

        public int? NovcaniCilj { get; set; }

        public bool Aktivna { get; set; }

        public int KorisnikId { get; set; }
    }
}

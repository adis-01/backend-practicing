using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services.Requests
{
    public class PriceUpdateReq
    {
        public string Naslov { get; set; } = null!;

        public string? Opis { get; set; }
        public bool Aktivna { get; set; }
    }
}

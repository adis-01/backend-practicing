using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services.Requests
{
    public class PricePostReq
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Naslov { get; set; } = null!;

        public string? Opis { get; set; }

        public int? NovcaniCilj { get; set; }

        public bool Aktivna { get; set; }

        public int KorisnikId { get; set; }
        [Required]
        public string? slikaPrice { get; set; }
    }
}

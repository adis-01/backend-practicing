using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Model
{
    public class MKorisniciUloge
    {
        public int KorisnikUlogaId { get; set; }


        public virtual MUloge? Uloga { get; set; }
    }
}

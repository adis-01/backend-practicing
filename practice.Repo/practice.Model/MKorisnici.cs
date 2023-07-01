using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Model
{
    public class MKorisnici
    {
        public int KorisnikId { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string KorisnickoIme { get; set; } = null!;
        public virtual ICollection<MKorisniciUloge> KorisniciUloges { get; set; } = new List<MKorisniciUloge>();
    }
}

using System;
using System.Collections.Generic;

namespace practice.Services.Database;

public partial class Korisnici
{
    public int KorisnikId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string KorisnickoIme { get; set; } = null!;

    public string LozinkaHash { get; set; } = null!;

    public string LozinkaSalt { get; set; } = null!;

    public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; } = new List<KorisniciUloge>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
    public bool isActive { get; set; } = false;
    public string VerifikacijskiToken { get; set; } = null!;
    public string VerifikacijskiTokenSalt { get; set; } = null!;
    public string Email { get; set; } = null!;
}

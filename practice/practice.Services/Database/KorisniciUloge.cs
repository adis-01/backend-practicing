﻿using System;
using System.Collections.Generic;

namespace practice.Services.Database;

public partial class KorisniciUloge
{
    public int KorisnikUlogaId { get; set; }

    public int? KorisnikId { get; set; }

    public int? UlogaId { get; set; }

    public virtual Korisnici? Korisnik { get; set; }

    public virtual Uloge? Uloga { get; set; }
}

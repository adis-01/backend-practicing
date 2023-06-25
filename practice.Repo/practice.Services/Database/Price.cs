using System;
using System.Collections.Generic;

namespace practice.Services.Database;

public partial class Price
{
    public int PricaId { get; set; }

    public string Naslov { get; set; } = null!;

    public string? Opis { get; set; }

    public int? NovcaniCilj { get; set; }

    public bool Aktivna { get; set; }

    public int KorisnikId { get; set; }

    public byte[]? Slika { get; set; }

    public virtual Korisnici Korisnik { get; set; } = null!;
}

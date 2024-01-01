using System;
using System.Collections.Generic;

namespace practice.Services.Database;

public partial class Uloge
{
    public int UlogaId { get; set; }

    public string NazivUloge { get; set; } = null!;

    public string? OpisUloge { get; set; }

    public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; } = new List<KorisniciUloge>();
}

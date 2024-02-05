using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class KolcsonzesTortenet
{
    public uint Id { get; set; }

    public uint KonyvId { get; set; }

    public uint? TagId { get; set; }

    public DateTime? Datum { get; set; }

    public virtual Konyv Konyv { get; set; } = null!;

    public virtual Felhasznalo? Tag { get; set; }
}

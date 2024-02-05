using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class Konyv
{
    public uint Id { get; set; }

    public uint RaktariSzam { get; set; }

    public DateOnly? BeszerzesDatuma { get; set; }

    public uint SzerzoId { get; set; }

    public string Cim { get; set; } = null!;

    public uint? SorozatId { get; set; }

    public decimal? IsbnSzam { get; set; }

    public decimal? Szakjelzet { get; set; }

    public string? CutterJelzet { get; set; }

    public uint? KiadoId { get; set; }

    public ushort? KiadasEve { get; set; }

    public decimal? Ar { get; set; }

    public string? Megjegyzes { get; set; }

    public uint? TagId { get; set; }

    public virtual Kiado? Kiado { get; set; }

    public virtual ICollection<KolcsonzesTortenet> KolcsonzesTortenets { get; set; } = new List<KolcsonzesTortenet>();

    public virtual Sorozat? Sorozat { get; set; }

    public virtual Szerzo Szerzo { get; set; } = null!;

    public virtual Felhasznalo? Tag { get; set; }
}

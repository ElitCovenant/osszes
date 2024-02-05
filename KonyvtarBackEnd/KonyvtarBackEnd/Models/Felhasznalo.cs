using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class Felhasznalo
{
    public uint Id { get; set; }

    public string Nev { get; set; } = null!;

    public DateTime? TagsagKezdete { get; set; }

    public DateTime? TagsagVege { get; set; }

    public sbyte? Kolcsonozhet { get; set; }

    public sbyte? TagFelvehet { get; set; }

    public string? FelhasznaloiNev { get; set; }

    public string? Jelszo { get; set; }

    public virtual ICollection<KolcsonzesTortenet> KolcsonzesTortenets { get; set; } = new List<KolcsonzesTortenet>();

    public virtual ICollection<Konyv> Konyvs { get; set; } = new List<Konyv>();
}

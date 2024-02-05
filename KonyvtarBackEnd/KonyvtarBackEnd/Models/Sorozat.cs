using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class Sorozat
{
    public uint Id { get; set; }

    public string Nev { get; set; } = null!;

    public virtual ICollection<Konyv> Konyvs { get; set; } = new List<Konyv>();
}

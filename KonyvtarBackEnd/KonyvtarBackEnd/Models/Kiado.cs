using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class Kiado
{
    public uint Id { get; set; }

    public string? Nev { get; set; }

    public virtual ICollection<Konyv> Konyvs { get; set; } = new List<Konyv>();
}

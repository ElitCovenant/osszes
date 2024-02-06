using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class Series
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

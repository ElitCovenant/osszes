using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class Rule
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

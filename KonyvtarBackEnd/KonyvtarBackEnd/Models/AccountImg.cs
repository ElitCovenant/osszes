using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class AccountImg
{
    public int Id { get; set; }

    public string ImgName { get; set; } = null!;

    public string ImgPath { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

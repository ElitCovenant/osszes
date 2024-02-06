using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class LoanHistory
{
    public uint Id { get; set; }

    public uint BookId { get; set; }

    public uint? UserId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User? User { get; set; }
}

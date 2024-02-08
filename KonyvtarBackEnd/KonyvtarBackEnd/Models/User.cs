using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class User
{
    public uint Id { get; set; }

    public DateTime? MembershipStart { get; set; }

    public DateTime? MembershipEnd { get; set; }

    public string? Usarname { get; set; }

    public string? Hash { get; set; }

    public string? Token { get; set; }

    public int IdRule { get; set; }

    public int IdAccountImg { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual AccountImg IdAccountImgNavigation { get; set; } = null!;

    public virtual Rule IdRuleNavigation { get; set; } = null!;

    public virtual ICollection<LoanHistory> LoanHistories { get; set; } = new List<LoanHistory>();
}

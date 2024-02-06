using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models;

public partial class Book
{
    public uint Id { get; set; }

    public uint WarehouseNum { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public uint AuthorId { get; set; }

    public string Title { get; set; } = null!;

    public uint? SeriesId { get; set; }

    public decimal? IsbnNum { get; set; }

    public decimal? Szakkjelzet { get; set; }

    public string? CutterJelzet { get; set; }

    public uint? PublisherId { get; set; }

    public ushort? ReleaseDate { get; set; }

    public decimal? Price { get; set; }

    public string? Comment { get; set; }

    public uint? UserId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<LoanHistory> LoanHistories { get; set; } = new List<LoanHistory>();

    public virtual Publisher? Publisher { get; set; }

    public virtual Series? Series { get; set; }

    public virtual User? User { get; set; }
}

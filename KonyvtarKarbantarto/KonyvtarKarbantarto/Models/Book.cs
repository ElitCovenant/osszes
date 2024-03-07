using System;
using System.Collections.Generic;

namespace KonyvtarBackEnd.Models
{

    public partial class Book
    {
        public uint Id { get; set; }

        public uint WarehouseNum { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public uint AuthorId { get; set; }

        public string Title { get; set; }

        public uint? SeriesId { get; set; }

        public decimal? IsbnNum { get; set; }

        public decimal? Szakkjelzet { get; set; }

        public string CutterJelzet { get; set; }

        public uint? PublisherId { get; set; }

        public ushort? ReleaseDate { get; set; }

        public decimal? Price { get; set; }

        public string Comment { get; set; }

        public string BookImg { get; set; }

        public uint? UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarKarbantarto.Dto
{
    public class BookDtoUpload
    {
        public int warehouse_Num { get; set; }
        public string purchase_Date { get; set; }
        public uint author_Id { get; set; }
        public string title { get; set; }
        public uint series_Id { get; set; }
        public decimal isbn_Num { get; set; }
        public decimal szakjelzet { get;set; }
        public string cutter_Jelzet { get; set; }
        public uint publisher_Id { get; set; }
        public ushort release_Date { get; set; }
        public int price { get; set; }
        public string comment { get; set; }
        public string bookImg { get; set; }
        public uint user_Id { get; set; }
    }
}

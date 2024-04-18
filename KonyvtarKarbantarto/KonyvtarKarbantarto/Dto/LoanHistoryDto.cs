using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarKarbantarto.Dto
{
    public class LoanHistoryDto
    {
        public uint id {  get; set; }
        public uint book_Id { get; set; }
        public uint user_Id { get; set; }
        public string startDate { get; set; }
        public string deadline { get; set; }
        public bool returned { get; set; }
        public string comment { get; set; }
    }
}

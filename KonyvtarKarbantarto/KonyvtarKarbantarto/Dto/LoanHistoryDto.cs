using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarKarbantarto.Dto
{
    public class LoanHistoryDto
    {
        public int id {  get; set; }
        public int book_Id { get; set; }
        public int user_Id { get; set; }
        public string startDate { get; set; }
        public string deadline { get; set; }
        public bool returned { get; set; }
        public string comment { get; set; }
    }
}

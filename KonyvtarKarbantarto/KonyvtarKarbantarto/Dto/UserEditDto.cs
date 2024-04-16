using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarKarbantarto.Dto
{
    public class UserEditDto
    {
        public uint id {  get; set; }
        public string membershipStart { get; set; }
        public string membershipEnd { get; set;}
        public string userName { get; set; }
        public int id_Rule { get; set; }
        public int id_Account_Image { get; set; }

    }
}

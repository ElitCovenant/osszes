using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarKarbantarto.Models
{
    internal class User
    {
        public uint Id { get; set; }

        public DateTime? MembershipStart { get; set; }

        public DateTime? MembershipEnd { get; set; }

        public string Usarname { get; set; }

        public string Hash { get; set; }

        public string Token { get; set; }

        public int IdRule { get; set; }

        public int IdAccountImg { get; set; }
    }
}

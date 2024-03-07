﻿using System;
using System.Collections.Generic;

namespace KonyvtarKarbantarto.Models
{

    public partial class LoanHistory
    {
        public uint Id { get; set; }

        public uint BookId { get; set; }

        public uint? UserId { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? DateEnd { get; set; }

        public bool Returned { get; set; }

        public string Comment { get; set; }
    }
}

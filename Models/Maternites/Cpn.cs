using System;
using System.Collections.Generic;

namespace LYRA.Models.Maternites
{
    public partial class Cpn
    {
        public long CpnId { get; set; }
        public long MaterniteId { get; set; }
        public int NumeroCpn { get; set; }
        public DateTime Date { get; set; }
    }
}

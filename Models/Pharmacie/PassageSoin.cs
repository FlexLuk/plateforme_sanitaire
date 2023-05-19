using System;
using System.Collections.Generic;

namespace LYRA.Models.Pharmacie
{
    public partial class PassageSoin
    {
        public long PassageSoinsId { get; set; }
        public long SoinsId { get; set; }
        public DateTime Date { get; set; }

        public long? AvoirSoinsId { get; set; }
    }
}

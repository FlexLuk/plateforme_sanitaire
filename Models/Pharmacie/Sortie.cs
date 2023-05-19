using System;
using System.Collections.Generic;

namespace LYRA.Models.Pharmacie
{
    public partial class Sortie
    {
        public long Sortieid { get; set; }
        public long Medicamentid { get; set; }
        public decimal Stockinitial { get; set; }
        public decimal Quantitesortie { get; set; }
        public decimal Stockfinal { get; set; }
        public DateTime Date { get; set; }
        public long? Ordonnanceid { get; set; }
        public long? Fichisteid { get; set; }
        
    }
}

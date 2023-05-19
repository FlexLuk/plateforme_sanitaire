using System;
using System.Collections.Generic;

namespace LYRA.Models.Pharmacie
{
    public partial class OrdonnanceAvoir
    {
        public long Ordonnanceavoirid { get; set; }
        public long Ordonnanceid { get; set; }
        public long Medicamentid { get; set; }
        public decimal Quantite { get; set; }
        public string? Prescription { get; set; }
        public string? Matin { get; set; }
        public string? Midi { get; set; }
        public string? Soir { get; set; }
        public int? Sortie{ get; set; }
        public int? Soins{ get; set; }
    }
}

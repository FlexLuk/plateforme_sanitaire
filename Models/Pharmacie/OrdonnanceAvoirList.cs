using System;
using System.Collections.Generic;

namespace LYRA.Models.Pharmacie
{
    public partial class OrdonnanceAvoirList
    {
        public long Ordonnanceavoirid { get; set; }
        public long Ordonnanceid { get; set; }
        public int? num { get; set; }
        public long Medicamentid { get; set; }
        public decimal Quantite { get; set; }
        public string? Prescription { get; set; }
        public string? Article { get; set; }
        public bool? Sortie{ get; set; }
        public bool? Soins{ get; set; }
        public bool? Edit{ get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace LYRA.Models.Pharmacie
{
    public partial class Soins
    {
        public long Soinsid { get; set; }
        public long? Fichisteid { get; set; }
        public long? Ordonnanceid { get; set; }
        public long? Affiliationid { get; set; }
        public string? Categorie { get; set; }
        public string? Urgence { get; set; }
        public DateTime Date { get; set; }
        public string? Fin { get; set; }
    }
}

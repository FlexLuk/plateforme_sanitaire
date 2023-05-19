using System;
using System.Collections.Generic;

namespace LYRA.Models.Pharmacie
{
    public partial class Ordonnance
    {
        public long Ordonnanceid { get; set; }
        public long Fichistteid { get; set; }
        public string? Numordonnance { get; set; }
        public DateTime? Date { get; set; }
        public string? Etat { get; set; }
    }
}

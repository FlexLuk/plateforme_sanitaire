using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class HistoPassageEmployer
    {
        public long Histopassageemployerid { get; set; }
        public long? Fichisteid { get; set; }
        public long Affiliationid { get; set; }
        public string Categorie { get; set; } = null!;
        public long? Patiantid { get; set; }
    }
}

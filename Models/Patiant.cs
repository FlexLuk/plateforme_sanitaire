using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class Patiant
    {
        public long Patiantid { get; set; }
        public string Categorie { get; set; } = null!;
        public string Affiliationid { get; set; } = null!;
        public DateTime Datepassage { get; set; }
        public long Fichisteid { get; set; }
        public int Numjour { get; set; }
        public string Nomparametre { get; set; } = null!;
        public int Numeroparametre { get; set; }
        public string? Statut { get; set; }
    }
}

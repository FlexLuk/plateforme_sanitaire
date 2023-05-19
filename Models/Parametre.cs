using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class Parametre
    {
        public long Parametreid { get; set; }
        public long Fichisteid { get; set; }
        public string? Tag { get; set; }
        public string? Tad { get; set; }
        public string? Temperature { get; set; }
        public string? Poids { get; set; }
        public string? FrequenceCardiaque { get; set; }
        public string? Observation { get; set; }
        public long? Medecinid { get; set; }
        public string? Status { get; set; }
        public DateTime Datecreation { get; set; }
        public long Patiantid { get; set; }
        public int? Passage{ get; set; }
    }
}

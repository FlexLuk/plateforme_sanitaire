using System;
using System.Collections.Generic;

namespace LYRA.Models.Maternites
{
    public partial class Maternite
    {
        public long MaterniteId { get; set; }
        public long FichisteId { get; set; }
        public DateTime Date { get; set; }
        public long? AvoirMaterniteId { get; set; }
        public int? NombreAccouchement { get; set; }
        public int? AgeMere { get; set; }
        public string? Grossesse { get; set; }
        public DateTime? DateDernierRegle { get; set; }
        public DateTime? DateProbableAccouchement { get; set; }
        public int? NumeroBebe { get; set; }
        public string? TypeAccouchement { get; set; }
        public string? Categorie { get; set; }
        public long? Affiliationid { get; set; }
        
    }
}

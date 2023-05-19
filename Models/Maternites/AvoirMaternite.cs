using System;
using System.Collections.Generic;

namespace LYRA.Models.Maternites
{
    public partial class AvoirMaternite
    {
        public long AvoirMaterniteId { get; set; }
        public DateTime Date { get; set; }
        public long FichisteId { get; set; }
        public int? Validation { get; set; }
        public string? Commentaire { get; set; }
        public string? Etat { get; set; }
    }
}

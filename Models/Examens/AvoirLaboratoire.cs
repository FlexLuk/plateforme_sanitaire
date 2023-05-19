using System;
using System.Collections.Generic;

namespace LYRA.Models.Examens
{
    public partial class AvoirLaboratoire
    {
        public long AvoirLaboratoireId { get; set; }
        public long FichisteId { get; set; }
        public string? Statut { get; set; }
        public DateTime Date { get; set; }
    }
}

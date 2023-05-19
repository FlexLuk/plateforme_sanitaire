using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class DiagnosticAvoir
    {
        public long DiagnosticAvoirId { get; set; }
        public int DiagnosticId { get; set; }
        public long ConsultationId { get; set; }
        public long? FichisteId { get; set; }
        public string? DesignationDiag { get; set; }
        public DateTime Date { get; set; }
    }
}

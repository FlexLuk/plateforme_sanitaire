using System;
using System.Collections.Generic;

namespace LYRA.Models.Maternites
{
    public partial class EchoMaternite
    {
        public long EhoMaterniteId { get; set; }
        public long? FichisteId { get; set; }
        public DateTime? Date { get; set; }
        public string? PerimetreCranienne { get; set; }
        public string? PerimetreBrachiale { get; set; }
        public string? PerimetreThoracique { get; set; }
        public string? TypeLiquideAmniotique { get; set; }
        public string? QuantiteLiquideAmniotique { get; set; }
        public long? AvoirEchoId { get; set; }
        public long? CpnId { get; set; }
        public long? MaterniteId { get; set; }
        public string? Statut { get; set; }
        public string? BatementCoeur { get; set; }
        public string? EtatBebe { get; set; }
        public string? MouvementActif { get; set; }
    }
}

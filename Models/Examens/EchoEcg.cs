using System;
using System.Collections.Generic;

namespace LYRA.Models.Examens
{
    public partial class EchoEcg
    {
        public long EchoEcgId { get; set; }
        public long? Fichisteid { get; set; }
        public string? Prescripteur { get; set; }
        public string? Echo { get; set; }
        public string? Ecg { get; set; }
        public string? Resultat { get; set; }
        public string? Demande { get; set; }
        public string? Statut { get; set; }
        public DateTime? Date { get; set; }
    }
}

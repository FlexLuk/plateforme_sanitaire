using System;
using System.Collections.Generic;

namespace LYRA.Models.Complementaire
{
    public partial class Tdr
    {
        public long TdrId { get; set; }
        public long? AvoirSoinsId { get; set; }
        public string? Demande { get; set; }
        public string? Resultat { get; set; }
        public byte[] Date { get; set; } = null!;
        public string? Commentaire { get; set; }
        public string? Urgence { get; set; }
        public string? Etat { get; set; }
    }
}

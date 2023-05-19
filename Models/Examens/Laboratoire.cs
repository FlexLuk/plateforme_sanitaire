using System;
using System.Collections.Generic;

namespace LYRA.Models.Examens
{
    public partial class Laboratoire
    {
        public long LaboratoireId { get; set; }
        public DateTime Date { get; set; }
        public long FichisteId { get; set; }
        public int? MedecinId { get; set; }
        public long? CpnId { get; set; }
        public string? Statut { get; set; }
        public string? Prescripteur { get; set; }
        public string? TypeTest { get; set; } = null!;
        public string? Test { get; set; } = null!;
        public string? Resultat { get; set; }
        public string? Commentaire { get; set; }
    }
}

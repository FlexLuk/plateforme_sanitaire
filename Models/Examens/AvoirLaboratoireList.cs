using System;
using System.Collections.Generic;

namespace LYRA.Models.Examens
{
    public partial class AvoirLaboratoireList
    {
        public DateTime Date { get; set; }
        
        public string? Name { get; set; }
        public string? TypeTest { get; set; }
        public string? Test { get; set; }
        public string? Resultat { get; set; }
        public string? Statut { get; set; }
        public long FichisteId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class HistoEmploi
    {
        public int Emploiid { get; set; }
        public string? Numemployeur { get; set; }
        public int? Employerid { get; set; }
        public string? Emploi { get; set; }
        public string? Numosiet { get; set; }
        public DateTime? Dateembauche { get; set; }
        public DateTime? Datedebauche { get; set; }
        public string? Commentaire { get; set; }
    }
}

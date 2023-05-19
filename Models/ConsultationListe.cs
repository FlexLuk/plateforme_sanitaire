using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class ConsultationListe
    {
        public long Consultationid { get; set; }
        public long Fichisteid { get; set; }
        public int? Medecinid { get; set; }
        public DateTime? Dateconsultation { get; set; }
        public string? Nom { get; set; }
        public string? Programmer { get; set; }
        public DateTime? DateRdv { get; set; }
        public int? Passage { get; set; }
    }
}

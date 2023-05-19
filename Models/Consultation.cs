using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class Consultation
    {
        public long Consultationid { get; set; }
        public long Fichisteid { get; set; }
        public long? Soinsid { get; set; }
        public int Medecinid { get; set; }
        public int? Numjour { get; set; }
        public DateTime? Dateconsultation { get; set; }
        public string? Plainte { get; set; }
        //public string? Diagnostique { get; set; }
        public string? Symptomes { get; set; }
        public string? Observations { get; set; }
        public string? Statut { get; set; }
        public string? ListeAttente { get; set; }
        public string? Programmer { get; set; }
        public DateTime? DateRdv { get; set; }
        public int? repos { get; set; }
        public decimal? reposJours { get; set; }
        public int? Passage { get; set; }
    }
}

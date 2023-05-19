using System;
using System.Collections.Generic;

namespace LYRA.Models.Examens
{
    public partial class Dentiste
    {
        public long Dentisteid { get; set; }
        public string? Demande { get; set; }
        public long? Fichisteid { get; set; }
        public string? Type { get; set; }
        public long? Ordonnanceid { get; set; }
        public DateTime Date { get; set; }
        public int Age { get; set; }
        public int? Repetition { get; set; }
        public string? Plaintes { get; set; }
        public string? Symptomes { get; set; }
        public string? Diagnostiques { get; set; }
        public string? Prescripteur { get; set; }
        public int? Cas { get; set; }
        //public string? Commentaires { get; set; }
        public string? Terminer { get; set; }
        public string? Resultat { get; set; }
        public int? numDent { get; set; }
        public DateTime? Rendez_vous { get; set; }
    }
}

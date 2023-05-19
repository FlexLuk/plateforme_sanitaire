using System;
using System.Collections.Generic;

namespace LYRA.Models.Rendez_vous
{
    public partial class MedecinRdv
    {
        public long Rdvid { get; set; }
        public string? Titre { get; set; }
        public DateTime Date { get; set; }
        public long Fichisteid { get; set; }
        public string? Statut { get; set; }
        public string? Categorie { get; set; }
        public long? Affiliationid { get; set; }
        public long? Consultationid { get; set; }
        public int? Medecinid { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class Medecin
    {
        public int Medecinid { get; set; }
        public Int16 Utilisateurid { get; set; }
        public string? NomMedecin { get; set; }
        public string PrenomMedecin { get; set; } = null!;
        public string? Fonction { get; set; }
        public string? Specialite { get; set; }
        public string? Telephone { get; set; }
        public string? Adresse { get; set; }
        public string? Statut { get; set; }

        

    }
}

using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class Famille
    {
        public int Familleid { get; set; }
        public string? Nom { get; set; }
        public string Prenom { get; set; } = null!;
        public string Sexe { get; set; } = null!;
        public string? Cin { get; set; }
        public string? Adresse { get; set; }
        public string? Contact { get; set; }
        public DateTime? Datenaissance { get; set; }
        public string? Lieunaissance { get; set; }
        public string Categorie { get; set; } = null!;
        public int Employerid { get; set; }
        public string? Numeroosiet { get; set; }
        public string? NomDossier { get; set; }
    }
}

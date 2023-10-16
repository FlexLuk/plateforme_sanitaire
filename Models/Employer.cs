using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LYRA.Models
{
    public partial class Employer
    {
        public int Employerid { get; set; }
        public string? Numemployeur { get; set; }
        public string? Nom { get; set; }
        [Required(ErrorMessage = "Ce champs est obligatoire.")]
        public string? Prenom { get; set; } = null!;
        [Required(ErrorMessage = "Ce champs est obligatoire.")]
        public string? Sexe { get; set; } = null!;
        public string? Cin { get; set; } = null!;
        public string? Adresse { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Date de naissance obligatoire.")]
        public DateTime? Datenaissance { get; set; }
        public string? Lieunaissance { get; set; }
        public string? Situationmatrimoniale { get; set; }
        public string? Categorie { get; set; } = null!;

        [Required(ErrorMessage = "Il faut assigner un numero OSIET.")]
        public string? Numeroosiet { get; set; } = null!;
        public string? Statut { get; set; }
        public string? Fonction { get; set; }
        public string? NomDossier { get; set; }
    }
}

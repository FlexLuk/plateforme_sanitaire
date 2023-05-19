using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LYRA.Models
{
    public partial class Employeur
    {
        public int Employeurid { get; set; }
        [Required(ErrorMessage = "Numero OSIET obligatoire.")]
        public string Numemployeur { get; set; } = null!;
        [Required(ErrorMessage = "Veuillez entrer le nom de l'employeur.")]
        public string Raisonsociale { get; set; } = null!;
        public string? Formejurdique { get; set; }
        public string? Nif { get; set; }
        public string? Stat { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? Nomcontact { get; set; }
        [Required(ErrorMessage = "Ce champs est obligatoire aussi.")]
        public string Statut { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LYRA.Models.Pharmacie
{
    public partial class Medicament
    {
        public long Medicamentid { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire")]
        public string Designation { get; set; } = null!;

        [Required(ErrorMessage = "Ce champs est obligatoire")]
        public string Presentation { get; set; } = null!;
        public decimal Quantite { get; set; }
        public decimal Stockmin { get; set; }
    }
}

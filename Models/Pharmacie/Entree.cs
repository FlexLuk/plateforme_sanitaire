using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LYRA.Models.Pharmacie
{
    public partial class Entree
    {
        public long Entreeid { get; set; }
        [Required(ErrorMessage = "Ce champs est obligatoire")]
        public long Medicamentid { get; set; }
        public decimal Stockinitial { get; set; }
        [Required(ErrorMessage = "Ce champs est obligatoire")]
        public decimal Quantiteentree { get; set; }
        public decimal Stockfinal { get; set; }
        public DateTime Date { get; set; }
        public int? Utilisateurid { get; set; }
    }
}

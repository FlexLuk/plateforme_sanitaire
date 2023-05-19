using System;
using System.Collections.Generic;

namespace LYRA.Models.Pharmacie
{
    public partial class AvoirSoins
    {
        public long Avoirsoinsid { get; set; }
        public long? Soinsid { get; set; } = null!;
        public long? Ordonnanceavoirid { get; set; } = null!;
        public int? Frequence { get; set; } = null!;
        public string? Unitefrequence { get; set; } = null!;
        public string? Presence { get; set; } = null!;
        public int? NombrePresence { get; set; } = null!;
        public DateTime? Date { get; set; } = null!;
        public string? Commentaire { get; set; } = null!;
        public string? Demande { get; set; } = null!;
        public string? DemandeSup { get; set; } = null!;
        public string? Resultat { get; set; } = null!;
        public string? TypeSoins { get; set; } = null!;
        public string? Etat { get; set; } = null!;
        public string? Consommables { get; set; } = null!;
    }
}

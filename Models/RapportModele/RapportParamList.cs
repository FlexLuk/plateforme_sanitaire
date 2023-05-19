namespace LYRA.Models.RapportModele
{
    public class RapportParamList
    {
        public long? Fichisteid { get; set; }
        public DateTime? Date { get; set; }
        public int? NumJour { get; set; }
        public string? NomComplet { get; set; }
        public string? Etablissement { get; set; }
        public string? Categorie { get; set; }
        public string? NumOSIET { get; set; }
        public decimal? Temperature { get; set; }
        public string? TD { get; set; }
        public string? TG { get; set; }
        public decimal? Poids{ get; set; }
        public string? Medecin { get; set; }
        public string? Observation { get; set; }
    }
}

namespace LYRA.Models.Pharmacie
{
    public class ListOrdonnance
    {
        public long Ordonnanceid { get; set; }
        public long Fichistteid { get; set; }
        public string? Numordonnance { get; set; }
        public DateTime? Date { get; set; }
        public string? nomComplet { get; set; }
        public string? etablissement { get; set; }
        public string? NomMedecin { get; set; }
        public int? idMedecin { get; set; }
    }
}

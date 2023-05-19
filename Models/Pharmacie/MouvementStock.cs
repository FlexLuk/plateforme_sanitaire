namespace LYRA.Models.Pharmacie
{
    public class MouvementStock
    {
        public long idDocument { get; set; }
        public long? idOrdonnance { get; set; }
        public string designationArticle { get; set; } = null!;
        public string? presentation { get; set; }
        public decimal quantite { get; set; }
        public decimal quantiteEnStock { get; set; }
        public string? type { get; set; }
        public DateTime? date { get; set; }
        public string? nomUtilisateur { get; set; }

    }
}

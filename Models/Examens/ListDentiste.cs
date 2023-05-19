namespace LYRA.Models.Examens
{
    public class ListDentiste
    {
        public DateTime date { get; set; }
        public long? FichisteId { get; set; }
        public string? nom { get; set; } = null!;
        public string? etablissement { get; set; } = null!;
        public string? NumOsiet { get; set; } = null!;
        public int? age { get; set; }
        public int? dent { get; set; }
        public string? Cas { get; set; } = null!;
        public string? type { get; set; } = null!;
        public string? prescripteur { get; set; } = null!;
        public string? terminer { get; set; } = null!;
        public DateTime? rdv { get; set; }
    }
}

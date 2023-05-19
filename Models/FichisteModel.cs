namespace LYRA.Models
{
    public class FichisteModel
    {
        public long FId { get; set; }
        public string FName { get; set; } = null!;
        public DateTime? FDateCreate { get; set; }
        public int? FNumero { get; set; }
        public int? FFrequenceM { get; set; }
        public int? FFrequenceY { get; set; }
        public string? FCategorie { get; set; }
        public int? FParametre { get; set; }
        public string? FEtablissement { get; set; }
        public DateTime? FDateNaissance { get; set; }
        public string? FLieuNaissance { get; set; }
        public string? FNumeroosiet { get; set; }
        public string? FNomfichiste { get; set; }
    }
}

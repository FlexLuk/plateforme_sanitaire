namespace LYRA.Models
{
    public class PrescriptionDoc
    {
        public long ArticleId { get; set; }
        public long AvoirId { get; set; }
        public string Article { get; set; } = null!;
        public decimal Nombre { get; set; }
        public string? Prescription { get; set; } 
        public int? Sortie { get; set; } 
    }
}

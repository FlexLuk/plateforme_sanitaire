namespace LYRA.Models.Pharmacie
{
    public class SoinsModel
    {
        public long Soinid { get; set; }
        public long Fichisteid { get; set; }
        public string NomPatient { get; set; } = null!;
        public string NomEntreprise { get; set; } = null!;
        public string? NumOSIET { get; set; }
        public DateTime Daty { get; set; }
        public long NumOrdonnance { get; set; }
    }
}

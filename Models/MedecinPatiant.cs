namespace LYRA.Models
{
    public class MedecinPatiant
    {
        public long idFichiste { get; set; }
        public DateTime? date{ get; set; }
        public long idConsultation { get; set; }
        public int? Numjour { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
    }
}

namespace LYRA.Models.Pharmacie
{
    public class RapportSoinList
    {
        public DateTime Date { get; set; }
        public int NumJour { get; set; }
        public string NomComplet { get; set; } = null!;
        public string NumOSIET { get; set; } = null!;
        public string Etablissement { get; set; } = null!;
        public int? Age { get; set; }
        public string Sexe { get; set; } = null!;
        public string? Actes { get; set; }
        public string Medicament { get; set; } = null!;
        public string? Consommables { get; set; }
        public string? VoieAdmin { get; set; }
        public string? EffectueSurTotal { get; set; }
        public string? Observation { get; set; }
        public string? Prescripteur { get; set; }
        public string? Responsable { get; set; }

    }
}

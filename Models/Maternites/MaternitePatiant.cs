namespace LYRA.Models.Maternites
{
    public class MaternitePatiant
    {
        public DateTime Date { get; set; }
        public long Fichisteid { get; set; }
        public long Materniteid { get; set; }
        public long AvoirMaterniteId { get; set; }
        public string Name { get; set; } = null!;
        public string? Etat { get; set; }

    }
}

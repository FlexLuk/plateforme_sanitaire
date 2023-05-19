using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LYRA.Models
{
    public partial class Fichiste
    {
        public long Fichisteid { get; set; }
        public DateTime Date { get; set; }
        public int Numjour { get; set; }
        public int? Frequencemois { get; set; }
        public int? Frequenceannee { get; set; }
        public string Affiliationid { get; set; } = null!;
        public int? Parametreid { get; set; }
        public string Categorie { get; set; } = null!;
        public string? Username { get; set; }
    }
}

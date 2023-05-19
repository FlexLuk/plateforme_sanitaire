using System.ComponentModel.DataAnnotations;

namespace LYRA.Models
{
    public partial class Affiliation
    {

        public int ID { get; set; }
        public string AFFILIATION { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace LYRA.Models.Maternites
{
    public partial class Bebe
    {
        public long BebeId { get; set; }
        public long CpnId { get; set; }
        public string? BatementCoeur { get; set; }
        public string? MouvementActif { get; set; }
        public string? Etat { get; set; }
        public string? Commentaire { get; set; }
    }
}

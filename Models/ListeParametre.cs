using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class ListeParametre
    {
        public int Listeparametreid { get; set; }
        public int Numero { get; set; }
        public Int16? Utilisateurid { get; set; }
        public string? Statut { get; set; }
    }
}

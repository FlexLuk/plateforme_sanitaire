using System;
using System.Collections.Generic;

namespace LYRA.Models.Maternites
{
    public partial class VaccinMere
    {
        public long VaccinMereId { get; set; }
        public long? FichisteId { get; set; }
        public DateTime Date { get; set; }
        public long? MaterniteId { get; set; }
        public string? NomVaccin { get; set; }
        public string? Etat { get; set; }
    }
}

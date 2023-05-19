using System;
using System.Collections.Generic;

namespace LYRA.Models.Maternites
{
    public partial class VaccinEnfant
    {
        public long VaccinEnfantId { get; set; }
        public long? CpnId { get; set; }
        public long? FichisteId { get; set; }
        public DateTime Date { get; set; }
        public string? NomVaccin { get; set; }
        public string? Etat { get; set; }
    }
}

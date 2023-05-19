using System;
using System.Collections.Generic;

namespace LYRA.Models.Maternites
{
    public partial class AvoirEcho
    {
        public long AvoirEchoId { get; set; }
        public DateTime Date { get; set; }
        public long CpnId { get; set; }
        public long? MaterniteId{ get; set; }
        public long? EchoId { get; set; }
        public long? LaboratoireId { get; set; }
        public long? VaccinMereId { get; set; }
        public long? VaccinBebeId { get; set; }
    }
}

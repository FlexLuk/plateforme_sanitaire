using System;
using System.Collections.Generic;

namespace LYRA.Models
{
    public partial class Diagnostic
    {
        public int DiagnosticId { get; set; }
        public string Designation { get; set; } = null!;
    }
}

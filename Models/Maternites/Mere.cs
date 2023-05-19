using System;
using System.Collections.Generic;

namespace LYRA.Models.Maternites
{
    public partial class Mere
    {
        public long MereId { get; set; }
        public long CpnId { get; set; }
        public string? Ictere { get; set; }
        public string? Taille { get; set; }
        public string? Mamelon { get; set; }
        public string? HauteurUterine { get; set; }
        public string? BassinPelvienne { get; set; }
        public string? Oeoedeme { get; set; }
        public string? Varice { get; set; }
        public string? Leucorrhee { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackDetection.Models
{
    internal class ScanningResult
    {
        internal string ShortDescr { get; set; }
        internal string Descr { get; set; }
        internal int SecurityLevel { get; set; }
        internal string Link { get; set; }
        internal string RawData { get; set; }
        internal DateTime Date { get; set; }
        internal int StatusCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackDetection.Models
{
    internal abstract class IScanningAttack : List<ScanningResult>
    {
        internal protected List<ScanningResult> scanningResult = new List<ScanningResult>();
        internal protected void Add(ScanningResult res)
        {
            scanningResult.Add(res);
        }

        internal protected List<ScanningResult> GetCollectedData()
        {
            return scanningResult;
        }
    }
}

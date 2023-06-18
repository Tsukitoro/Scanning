using System.Collections.Generic;

namespace AttackDetection.Models
{
    internal abstract class IScanningAttack : List<ScanningResult>
    {
        internal protected List<ScanningResult> scanningResult = new List<ScanningResult>();
        internal protected new void Add(ScanningResult res)
        {
            scanningResult.Add(res);
        }

        internal protected List<ScanningResult> GetCollectedData()
        {
            return scanningResult;
        }
    }
}

using System.Collections.Generic;

namespace EdFi.LoadTools.BulkLoadClient
{
    public interface IBulkLoadClientResult
    {
        int ExitCode { get; set; }
    }

    public class BulkLoadClientResult: IBulkLoadClientResult
    {
        public int ExitCode { get; set; } = 0;
    }
}

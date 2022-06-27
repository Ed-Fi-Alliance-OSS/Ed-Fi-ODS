using System.Collections.Generic;

namespace EdFi.Ods.Generator.Common.Options
{
    public interface IModelOptions
    {
        IEnumerable<string> ModelPaths { get; set; }
        string CapabilityStatementPath { get; set; }
    }
}
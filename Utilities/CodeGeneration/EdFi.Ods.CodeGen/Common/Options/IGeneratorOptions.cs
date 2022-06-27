using System.Collections.Generic;

namespace EdFi.Ods.Generator.Common.Options
{
    public interface IGeneratorOptions
    {
        string OutputPath { get; set; }
        IEnumerable<string> Properties { get; set; }
        IEnumerable<string> Plugins { get; set; }
        IDictionary<string, string> PropertyByName { get; }
        string TemplatePath { get; set; }
        string LogLevel { get; set; }
    }
}
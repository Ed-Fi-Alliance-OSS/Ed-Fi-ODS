using System.Collections.Generic;
using EdFi.Ods.Common.Models.Dynamic;

namespace EdFi.Ods.Generator.Common.Database.TemplateModelProviders
{
    public class DatabaseTemplateModel : DynamicModel
    {
        public IEnumerable<SchemaInfo> Schemas { get; set; }

        public IEnumerable<Table> Tables { get; set; }
    }
}
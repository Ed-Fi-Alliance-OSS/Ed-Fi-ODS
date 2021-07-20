using System.Collections.Generic;
using EdFi.Ods.Generator.Templating;

namespace EdFi.Ods.ChangeQueries.SqlGeneration.TemplateModelProviders
{
    public class CreateChangesSchema : ITemplateModelProvider
    {
        public object GetTemplateModel(IDictionary<string, string> properties)
        {
            return new Model {ChangesSchema = ChangeQueriesDatabaseConstants.SchemaName};
        }

        private class Model
        {
            public string ChangesSchema { get; set; }
        }
    }
}
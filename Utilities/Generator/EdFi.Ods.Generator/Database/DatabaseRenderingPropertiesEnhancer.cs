using System.Collections.Generic;
using EdFi.Ods.Generator.Database.NamingConventions;

namespace EdFi.Ods.Generator.Database
{
    public class DatabaseRenderingPropertiesEnhancer : IRenderingPropertiesEnhancer
    {
        private readonly IDatabaseOptions _databaseOptions;
        private readonly IDatabaseNamingConvention _namingConvention;

        public DatabaseRenderingPropertiesEnhancer(IDatabaseOptions databaseOptions, IDatabaseNamingConventionFactory databaseNamingConventionFactory)
        {
            _databaseOptions = databaseOptions;
            _namingConvention = databaseNamingConventionFactory.CreateNamingConvention(databaseOptions.DatabaseEngine);
        }
        
        public void EnhanceProperties(IDictionary<string, string> properties)
        {
            properties["DatabaseEngine"] = _databaseOptions.DatabaseEngine;
            properties["SchemaFilter"] = _databaseOptions.SchemaFilter;
            properties["DatabaseEngineCode"] = _namingConvention.DatabaseEngineCode;
        }
    }
}
using System.Data;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Common.Database.DataTypes;
using EdFi.Ods.Generator.Common.Database.NamingConventions;
using EdFi.Ods.Generator.Common.Database.TemplateModelProviders;

namespace EdFi.Ods.Generator.Common.Database
{
    public static class ColumnHelper
    {
        public static Column CreateDiscriminatorColumn(IDatabaseNamingConvention databaseNamingConvention, IDatabaseTypeTranslator databaseTypeTranslator) => new Column
        {
            ColumnName = databaseNamingConvention.ColumnName("Discriminator"),
            DataType = databaseTypeTranslator.GetSqlType(new PropertyType(DbType.String, 128)),
            IsNullable = true,
        };
    }
}
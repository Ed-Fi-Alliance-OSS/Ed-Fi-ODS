using System.Data;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.DataTypes;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Database.TemplateModelProviders;

namespace EdFi.Ods.Generator.Database
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
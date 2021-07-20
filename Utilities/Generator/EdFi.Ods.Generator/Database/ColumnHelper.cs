using EdFi.Ods.Generator.Database.TemplateModelProviders;

namespace EdFi.Ods.Generator.Database
{
    public class ColumnHelper
    {
        public static Column CreateDiscriminatorColumn() => new Column
        {
            ColumnName = "Discriminator",
            DataType = "nvarchar(128)",
            IsNullable = true,
        };
    }
}
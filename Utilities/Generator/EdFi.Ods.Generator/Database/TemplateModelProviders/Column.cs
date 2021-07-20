using EdFi.Ods.Common.Models.Dynamic;

namespace EdFi.Ods.Generator.Database.TemplateModelProviders
{
    public class Column : DynamicModelBase
    {
        public string ColumnName { get; set; }

        public string DataType { get; set; }

        public bool IsNullable { get; set; }

        public bool? IsFirst { get; set; }

        public string DefaultConstraintName { get; set; }
        public string DefaultValue { get; set; }

        public bool IsString
        {
            get => DataType.StartsWith("nvarchar"); // TODO: Need to add support for Postgres.
        }

        public bool IsGuid
        {
            get => DataType == "uniqueidentifier";
        }

        public bool IsNumber
        {
            get =>
                DataType == "bit" || DataType == "decimal" || DataType == "int" || DataType == "money" || DataType == "smallint";
        }

        public bool IsDate
        {
            get => DataType == "datetime" || DataType == "datetime2" || DataType == "date";
        }

        public bool IsTime
        {
            get => DataType == "time";
        }

        public bool IsUnsupportedType => !IsString && !IsGuid && !IsNumber && !IsDate && !IsTime;

        public bool? IsLast { get; set; }

        public bool IsServerAssigned { get; set; }

        public int Index { get; set; }

        public bool IsConcreteDescriptorId { get; set; }

        /// <summary>
        /// Indicates whether the column represents an identifier (i.e the USI) for a specific type of person (e.g. Student/Staff/Parent).
        /// </summary>
        public bool IsPersonUSIUsage { get; set; }

        public string PersonType { get; set; }
        
        /// <summary>
        /// For primary key columns on derived entities/tables, gets or sets the name of the corresponding column in the base table.
        /// </summary>
        public string BaseColumnName { get; set; }
    }
}
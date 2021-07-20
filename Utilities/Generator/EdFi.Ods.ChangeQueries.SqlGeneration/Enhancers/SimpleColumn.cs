using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.ChangeQueries.SqlGeneration.Enhancers
{
    /// <summary>
    /// Represents a column with just a name.
    /// </summary>
    public class SimpleColumn
    {
        public SimpleColumn() { }
        
        public SimpleColumn(string columnName, string dataType, string selectExpression = null, bool? isFirst = null)
        {
            ColumnName = columnName;
            DataType = dataType;
            SelectExpression = selectExpression;
            IsFirst = isFirst;
        }
        
        // public SimpleColumn(EntityProperty property)
        // {
        //     ColumnName = property.PropertyName;
        //     ColumnDataType = ColumnDataType;
        // }
        
        public string ColumnName { get; set; }
        
        /// <summary>
        /// Contains the fully defined SQL data type definition for the target database (when used in SQL DDL generation).
        /// </summary>
        public string DataType { get; set; }
        
        /// <summary>
        /// Contains the SELECT expression for the column (when used in SQL DML generation).
        /// </summary>
        public string SelectExpression { get; set; }
        
        /// <summary>
        /// Indicates whether the column is the first columns in a set, or <b>null</b> if this is not known or relevant.
        /// </summary>
        public bool? IsFirst { get; set; }
    }
}
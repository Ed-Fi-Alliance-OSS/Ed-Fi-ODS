namespace EdFi.Ods.ChangeQueries.SqlGeneration.Enhancers
{
    public class SingleColumnJoin
    {
        public SingleColumnJoin(
            string schema,
            string tableName,
            string joinAlias,
            bool isLeftJoin,
            string thisJoinColumnName,
            string otherJoinColumnName)
        {
            Schema = schema;
            TableName = tableName;
            JoinAlias = joinAlias;
            IsLeftJoin = isLeftJoin;
            ThisJoinColumnName = thisJoinColumnName;
            OtherJoinColumnName = otherJoinColumnName;
        }

        public string Schema { get; }
        public string TableName { get; }
        public string JoinAlias { get; }
        public bool IsLeftJoin { get; }
        public string ThisJoinColumnName { get; set; }
        public string OtherJoinColumnName { get; set; }
    }
}
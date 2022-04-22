namespace EdFi.Ods.Common.Database.Querying.Dialects
{
    public class PostgreSqlDialect : Dialect
    {
        public override string GetOffsetLimitString(int? offset, int? limit)
        {
            if (offset == null && limit == null)
                return null;
            
            if (offset != null && limit != null)
            {
                return $"LIMIT {limit} OFFSET {offset}";
            }

            if (offset != null)
            {
                return $"OFFSET {offset}";
            }

            return $"LIMIT {limit}";
        }
    }
}
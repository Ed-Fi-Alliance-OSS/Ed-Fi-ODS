namespace EdFi.Ods.Common.Database.Querying.Dialects
{
    public class SqlServerDialect : Dialect
    {
        public override string GetOffsetLimitString(int? offset, int? limit)
        {
            if (offset == null && limit == null)
                return null;
            
            if (offset != null && limit != null)
            {
                return $"OFFSET {offset} ROWS FETCH NEXT {limit} ROWS ONLY";
            }

            if (offset != null)
            {
                return $"OFFSET {offset} ROWS";
            }

            return $"OFFSET 0 ROWS FETCH NEXT {limit} ROWS ONLY";
        }
    }
}
namespace EdFi.Ods.Common.Database.Querying.Dialects
{
    public abstract class Dialect
    {
        public abstract string GetOffsetLimitString(int? offset, int? limit);
    }
}
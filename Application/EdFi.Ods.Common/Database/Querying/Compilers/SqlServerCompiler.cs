using EdFi.Ods.Common.Database.Querying.Dialects;

namespace EdFi.Ods.Common.Database.Querying.Compilers
{
    public class SqlServerCompiler : Compiler
    {
        private readonly SqlServerDialect _dialect = new SqlServerDialect();

        protected override string GetTemplate(Query query)
        {
            return $"/**with**/ SELECT /**select**/ FROM {query._tableName}/**innerjoin**/ /**leftjoin**/ /**rightjoin**/ /**where**/ /**groupby**/ /**orderby**/ /**paging**/";
        }

        protected override Dialect Dialect
        {
            get => _dialect;
        }
    }
}
using EdFi.Common.Configuration;

namespace EdFi.Ods.Generator.Database.NamingConventions
{
    public interface IDatabaseNamingConventionFactory
    {
        IDatabaseNamingConvention CreateNamingConvention(string databaseEngine);
    }
}
namespace EdFi.Ods.Generator.Common.Database.NamingConventions
{
    public interface IDatabaseNamingConventionFactory
    {
        IDatabaseNamingConvention CreateNamingConvention(string databaseEngine);
    }
}
namespace EdFi.Ods.Generator.Common.Options
{
    public interface IDatabaseOptions
    {
        string DatabaseEngine { get; set; }
        
        string Schema { get; set; }
    }
}
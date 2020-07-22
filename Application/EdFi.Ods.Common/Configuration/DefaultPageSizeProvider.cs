
namespace EdFi.Ods.Common.Configuration
{
    public class DefaultPageSizeProvider : IDefaultPageSizeProvider
    {
        public int GetDefaultPageSize()
        {
            return int.TryParse(System.Configuration.ConfigurationManager.AppSettings["defaultPageSize"], out int defaultPageSize)
                ? defaultPageSize
                : 500;
        }
    }
}

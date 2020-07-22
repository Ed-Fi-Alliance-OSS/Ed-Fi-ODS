
namespace EdFi.Ods.Common.Configuration
{
    public class DefaultPageSizeProvider : IDefaultPageSizeProvider
    {
        public int GetDefaultPageSizeLimit()
        {
            return int.TryParse(System.Configuration.ConfigurationManager.AppSettings["defaultPageSizeLimit"], out int defaultPageSize)
                ? defaultPageSize
                : 500;
        }
    }
}

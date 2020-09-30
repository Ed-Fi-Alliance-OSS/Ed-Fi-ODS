using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Common.Extensions
{
    public static class ApiKeyContextExtensions
    {
        /// <summary>
        /// Indicates whether the ApiKeyContext is <b>null</b>, or is assigned to the
        /// empty instance (<see cref="ApiKeyContext.Empty" />).
        /// </summary>
        /// <param name="apiKeyContext">The API key context to be evaluated.</param>
        /// <returns><b>true</b> if the API key context has not been set; otherwise <b>false</b>.</returns>
        public static bool IsNullOrEmpty(this ApiKeyContext apiKeyContext)
        {
            return apiKeyContext == null || apiKeyContext == ApiKeyContext.Empty;
        }
    }
}

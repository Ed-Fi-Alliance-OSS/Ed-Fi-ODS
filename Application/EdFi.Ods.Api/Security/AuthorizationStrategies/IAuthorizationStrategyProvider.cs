using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies;

public interface IAuthorizationStrategyProvider
{
    /// <summary>
    /// Gets the IAuthorizationStrategy implementation for the authorization strategy, by name.
    /// </summary>
    /// <param name="authorizationStrategyName"></param>
    /// <returns>The IAuthorizationStrategy implementation for the authorization strategy if found; otherwise <b>null</b>.</returns>
    IAuthorizationStrategy GetByName(string authorizationStrategyName);
}

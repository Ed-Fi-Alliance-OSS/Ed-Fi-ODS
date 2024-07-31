using Autofac.Features.Indexed;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies;

/// <summary>
/// Implements an authorization strategy provider that resolves the providers from the container based on keyed registrations
/// where the key is the authorization strategy name.
/// </summary>
public class NamedAuthorizationStrategyProvider : IAuthorizationStrategyProvider
{
    private readonly IIndex<string, IAuthorizationStrategy> _authorizationStrategyByName;

    public NamedAuthorizationStrategyProvider(IIndex<string, IAuthorizationStrategy> authorizationStrategyByName)
    {
        _authorizationStrategyByName = authorizationStrategyByName;
    }

    public IAuthorizationStrategy GetByName(string authorizationStrategyName)
    {
        return _authorizationStrategyByName.TryGetValue(authorizationStrategyName, out var authorizationStrategy)
            ? authorizationStrategy
            : null;
    }
}

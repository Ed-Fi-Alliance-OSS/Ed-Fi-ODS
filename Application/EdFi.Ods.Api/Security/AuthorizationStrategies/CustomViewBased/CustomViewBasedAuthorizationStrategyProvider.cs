using System;
using Autofac.Extras.DynamicProxy;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Authorization;
using log4net;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.CustomViewBased;

[Intercept(InterceptorCacheKeys.Security)]
public class CustomViewBasedAuthorizationStrategyProvider : IAuthorizationStrategyProvider
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(CustomViewBasedAuthorizationStrategyProvider));

    private readonly ICustomViewBasisEntityProvider _customViewBasisEntityProvider;
    private readonly Func<string, Entity, CustomViewBasedAuthorizationStrategy> _customViewBasedAuthorizationFactory;

    public CustomViewBasedAuthorizationStrategyProvider(
        ICustomViewBasisEntityProvider customViewBasisEntityProvider,
        Func<string, Entity, CustomViewBasedAuthorizationStrategy> customViewBasedAuthorizationFactory)
    {
        _customViewBasisEntityProvider = customViewBasisEntityProvider;
        _customViewBasedAuthorizationFactory = customViewBasedAuthorizationFactory;
    }

    /// <inheritdoc cref="IAuthorizationStrategyProvider.GetByName" />
    public IAuthorizationStrategy GetByName(string authorizationStrategyName)
    {
        var result = _customViewBasisEntityProvider.GetBasisEntity(authorizationStrategyName);
        
        if (result.entity != null)
        {
            return _customViewBasedAuthorizationFactory(authorizationStrategyName, result.entity);
        }
        
        _logger.Debug($"Authorization strategy name '{authorizationStrategyName}' failed to match any entities named '{result.attemptedEntityName}' in any schemas in the model...");

        return null;
    }
}

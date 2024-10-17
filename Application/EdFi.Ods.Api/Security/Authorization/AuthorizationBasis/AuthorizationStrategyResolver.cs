// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.DynamicProxy;
using EdFi.Ods.Api.Security.AuthorizationStrategies;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

[Intercept(InterceptorCacheKeys.Security)]
public interface IAuthorizationStrategyResolver
{
    IReadOnlyList<IAuthorizationStrategy> GetAuthorizationStrategies(IReadOnlyList<string> strategyNames);
}

public class AuthorizationStrategyResolver : IAuthorizationStrategyResolver
{
    private readonly IAuthorizationStrategyProvider[] _authorizationStrategyProviders;

    public AuthorizationStrategyResolver(IAuthorizationStrategyProvider[] authorizationStrategyProviders)
    {
        _authorizationStrategyProviders = authorizationStrategyProviders;
    }

    public IReadOnlyList<IAuthorizationStrategy> GetAuthorizationStrategies(IReadOnlyList<string> strategyNames)
    {
        List<string> strategiesMissingImplementations = null;

        var authorizationStrategies = strategyNames.Select(
                strategyName =>
                {
                    foreach (var authorizationStrategyProvider in _authorizationStrategyProviders)
                    {
                        var authorizationStrategy = authorizationStrategyProvider.GetByName(strategyName);

                        if (authorizationStrategy != null)
                        {
                            return authorizationStrategy;
                        }
                    }

                    // Initialize list if necessary and add the missing strategy name
                    strategiesMissingImplementations ??= new List<string>();
                    strategiesMissingImplementations.Add(strategyName);

                    return null;
                })
            .ToArray();

        if (strategiesMissingImplementations != null)
        {
            throw new SecurityConfigurationException(
                SecurityConfigurationException.DefaultDetail,
                $"Could not find authorization strategy implementations for the following strategy names: '{string.Join("', '", strategiesMissingImplementations)}'.");
        }

        return authorizationStrategies;
    }
}

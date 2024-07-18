// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Infrastructure.Filtering
{
    /// <inheritdoc cref="IAuthorizationFilterDefinitionProvider" />
    public class AuthorizationFilterDefinitionProvider : IAuthorizationFilterDefinitionProvider
    {
        private readonly IAuthorizationFilterDefinitionsFactory[] _authorizationFilterDefinitionsFactories;
        private readonly Lazy<IDictionary<string, AuthorizationFilterDefinition>> _predefinedFilterDefinitionByName;
        private readonly ConcurrentDictionary<string, AuthorizationFilterDefinition> _runtimeFilterDefinitionByName = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilterDefinitionProvider"/> class using the supplied filter configurators.
        /// </summary>
        /// <param name="authorizationFilterDefinitionsFactories"></param>
        public AuthorizationFilterDefinitionProvider(IAuthorizationFilterDefinitionsFactory[] authorizationFilterDefinitionsFactories)
        {
            _authorizationFilterDefinitionsFactories = authorizationFilterDefinitionsFactories;

            _predefinedFilterDefinitionByName = new Lazy<IDictionary<string, AuthorizationFilterDefinition>>(
                () => authorizationFilterDefinitionsFactories
                    // Sort the definitions providers to ensure a determinate alias generation during filter definition
                    .OrderBy(p => p.GetType().FullName)
                    .SelectMany(c => c.CreatePredefinedAuthorizationFilterDefinitions())
                    .Distinct()
                    .ToDictionary(f => f.FilterName, f => f));
        }

        /// <inheritdoc cref="IAuthorizationFilterDefinitionProvider.GetAuthorizationFilterDefinition" />
        public AuthorizationFilterDefinition GetAuthorizationFilterDefinition(string filterName)
        {
            if (TryGetAuthorizationFilterDefinition(filterName, out var filterDefinition))
            {
                return filterDefinition;
            }
            
            throw new Exception($"Unable to find filter application details for filter '{filterName}'.");
        }

        /// <inheritdoc cref="IAuthorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition" />
        public bool TryGetAuthorizationFilterDefinition(string filterName, out AuthorizationFilterDefinition authorizationFilterDefinition)
        {
            if (!_predefinedFilterDefinitionByName.Value.TryGetValue(filterName, out authorizationFilterDefinition))
            {
                authorizationFilterDefinition = _runtimeFilterDefinitionByName.GetOrAdd(
                    filterName,
                    static (fn, factories) => factories
                        .Select(f => f.CreateAuthorizationFilterDefinition(fn))
                        .FirstOrDefault(fad => fad != null),
                    _authorizationFilterDefinitionsFactories);
            }

            return authorizationFilterDefinition != null;
        }
    }
}

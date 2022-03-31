// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Infrastructure.Filtering
{
    /// <inheritdoc cref="IAuthorizationFilterDefinitionProvider" />
    public class AuthorizationFilterDefinitionProvider : IAuthorizationFilterDefinitionProvider
    {
        private readonly Lazy<IDictionary<string, AuthorizationFilterDefinition>> _filterDefinitionByName;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilterDefinitionProvider"/> class using the supplied filter configurators.
        /// </summary>
        /// <param name="authorizationFilterDefinitionsProviders"></param>
        public AuthorizationFilterDefinitionProvider(IAuthorizationFilterDefinitionsFactory[] authorizationFilterDefinitionsProviders)
        {
            _filterDefinitionByName = new Lazy<IDictionary<string, AuthorizationFilterDefinition>>(
                () => authorizationFilterDefinitionsProviders
                    // Sort the definitions providers to ensure a determinate alias generation during filter definition
                    .OrderBy(p => p.GetType().FullName)
                    .SelectMany(c => c.CreateAuthorizationFilterDefinitions())
                    .Distinct()
                    .ToDictionary(f => f.FilterName, f => f));
        }

        /// <inheritdoc cref="IAuthorizationFilterDefinitionProvider.GetFilterDefinition" />
        public AuthorizationFilterDefinition GetFilterDefinition(string filterName)
        {
            if (!_filterDefinitionByName.Value.TryGetValue(filterName, out var filterApplicationDetails))
            {
                throw new Exception($"Unable to find filter application details for filter '{filterName}'.");
            }

            return filterApplicationDetails;
        }

        /// <inheritdoc cref="IAuthorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition" />
        public bool TryGetAuthorizationFilterDefinition(string filterName, out AuthorizationFilterDefinition authorizationFilterDefinition)
        {
            return _filterDefinitionByName.Value.TryGetValue(filterName, out authorizationFilterDefinition);
        }
    }
}

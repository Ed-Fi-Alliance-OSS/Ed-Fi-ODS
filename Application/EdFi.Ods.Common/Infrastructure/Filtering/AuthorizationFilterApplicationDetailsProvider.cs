// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Infrastructure.Filtering
{
    /// <inheritdoc cref="IAuthorizationFilterApplicationDetailsProvider" />
    public class AuthorizationFilterApplicationDetailsProvider : IAuthorizationFilterApplicationDetailsProvider
    {
        private readonly Lazy<IDictionary<string, FilterApplicationDetails>> _filterDefinitionByName;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilterApplicationDetailsProvider"/> class using the supplied filter configurators.
        /// </summary>
        /// <param name="authorizationFilterDefinitionsProviders"></param>
        public AuthorizationFilterApplicationDetailsProvider(INHibernateFilterConfigurator[] authorizationFilterDefinitionsProviders)
        {
            _filterDefinitionByName = new Lazy<IDictionary<string, FilterApplicationDetails>>(
                () => authorizationFilterDefinitionsProviders
                    // Sort the definitions providers to ensure a determinate alias generation during filter definition
                    .OrderBy(p => p.GetType().FullName)
                    .SelectMany(c => c.GetFilters())
                    .Distinct()
                    .ToDictionary(f => f.FilterDefinition.FilterName, f => f));
        }

        /// <inheritdoc cref="IAuthorizationFilterApplicationDetailsProvider.GetFilterDefinition" />
        public FilterApplicationDetails GetFilterDefinition(string filterName)
        {
            if (!_filterDefinitionByName.Value.TryGetValue(filterName, out var filterApplicationDetails))
            {
                throw new Exception($"Unable to find filter application details for filter '{filterName}'.");
            }

            return filterApplicationDetails;
        }

        /// <inheritdoc cref="IAuthorizationFilterApplicationDetailsProvider.TryGetAuthorizationFilterDefinition" />
        public bool TryGetAuthorizationFilterDefinition(string filterName, out FilterApplicationDetails authorizationFilterDefinition)
        {
            return _filterDefinitionByName.Value.TryGetValue(filterName, out authorizationFilterDefinition);
        }
    }
}

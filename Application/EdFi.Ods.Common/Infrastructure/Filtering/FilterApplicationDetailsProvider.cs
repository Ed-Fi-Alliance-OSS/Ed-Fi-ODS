// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Infrastructure.Filtering
{
    /// <inheritdoc cref="EdFi.Ods.Common.Infrastructure.Filtering.IFilterApplicationDetailsProvider" />
    public class FilterApplicationDetailsProvider : IFilterApplicationDetailsProvider
    {
        private readonly Lazy<IDictionary<string, FilterApplicationDetails>> _filterApplicationDetailsByFilterName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterApplicationDetailsProvider"/> class using the supplied filter configurators.
        /// </summary>
        /// <param name="nhibernateFilterConfigurators"></param>
        public FilterApplicationDetailsProvider(INHibernateFilterConfigurator[] nhibernateFilterConfigurators)
        {
            _filterApplicationDetailsByFilterName = new Lazy<IDictionary<string, FilterApplicationDetails>>(
                () => nhibernateFilterConfigurators
                    .SelectMany(c => c.GetFilters())
                    .Distinct()
                    .ToDictionary(f => f.FilterDefinition.FilterName, f => f));
        }

        /// <inheritdoc cref="IFilterApplicationDetailsProvider.GetFilterApplicationDetails" />
        public FilterApplicationDetails GetFilterApplicationDetails(string filterName)
        {
            if (!_filterApplicationDetailsByFilterName.Value.TryGetValue(filterName, out var filterApplicationDetails))
            {
                throw new Exception($"Unable to find filter application details for filter '{filterName}'.");
            }

            return filterApplicationDetails;
        }

        /// <inheritdoc cref="IFilterApplicationDetailsProvider.TryGetFilterApplicationDetails" />
        public bool TryGetFilterApplicationDetails(string filterName, out FilterApplicationDetails filterApplicationDetails)
        {
            return _filterApplicationDetailsByFilterName.Value.TryGetValue(filterName, out filterApplicationDetails);
        }
    }
}

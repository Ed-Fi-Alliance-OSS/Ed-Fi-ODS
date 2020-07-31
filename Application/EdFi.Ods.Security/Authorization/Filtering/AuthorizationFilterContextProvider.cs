// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using EdFi.Ods.Api.NHibernate.Filtering;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Security.Authorization.Filtering
{
    /// <summary>
    /// Stores and retrieves parameterized filters to and from context storage.
    /// </summary>
    public class AuthorizationFilterContextProvider : IAuthorizationFilterContextProvider
    {
        private const string FilterContextKeyName = "FilterContextProvider.FilterContext";

        private readonly IContextStorage _contextStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilterContextProvider" /> class using the specified context storage.
        /// </summary>
        /// <param name="contextStorage">The component to be used to store the contextual data.</param>
        public AuthorizationFilterContextProvider(IContextStorage contextStorage)
        {
            _contextStorage = contextStorage;
        }

        /// <summary>
        /// Sets parameterized filters to the current context.
        /// </summary>
        /// <param name="filters">A dictionary keyed by filter name, whose values are dictionaries keyed by parameter name.</param>
        public void SetFilterContext(IReadOnlyList<AuthorizationFilterDetails> filters)
        {
            // Store the filters into context
            _contextStorage.SetValue(FilterContextKeyName, filters);
        }

        /// <summary>
        /// Gets parameterized filters from the current context, or an empty dictionary if none have been set.
        /// </summary>
        /// <returns>A dictionary keyed by filter name, whose values are dictionaries keyed by parameter name.</returns>
        public IReadOnlyList<AuthorizationFilterDetails> GetFilterContext()
        {
            return _contextStorage.GetValue<IReadOnlyList<AuthorizationFilterDetails>>(FilterContextKeyName)
                ?? new AuthorizationFilterDetails[0];
        }
    }
}

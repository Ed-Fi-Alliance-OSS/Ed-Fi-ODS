// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.Authorization.Filtering
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

        /// <inheritdoc cref="IAuthorizationFilterContextProvider.SetFilterContext" />
        public void SetFilterContext(IReadOnlyList<AuthorizationStrategyFiltering> filters)
        {
            // Store the filters into context
            _contextStorage.SetValue(FilterContextKeyName, filters);
        }

        /// <inheritdoc cref="IAuthorizationFilterContextProvider.GetFilterContext" />
        public IReadOnlyList<AuthorizationStrategyFiltering> GetFilterContext()
        {
            return _contextStorage.GetValue<IReadOnlyList<AuthorizationStrategyFiltering>>(FilterContextKeyName)
                ?? Array.Empty<AuthorizationStrategyFiltering>();
        }
    }
}

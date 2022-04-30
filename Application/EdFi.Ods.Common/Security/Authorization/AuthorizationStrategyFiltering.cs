// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Security.Authorization
{
    public class AuthorizationStrategyFiltering
    {
        /// <summary>
        /// Gets or sets the name of the authorization strategy that created this filter.
        /// </summary>
        public string AuthorizationStrategyName { get; set; }

        /// <summary>
        /// Gets or sets the filters to be applied.
        /// </summary>
        public IReadOnlyList<AuthorizationFilterContext> Filters { get; set; }

        /// <summary>
        /// Indicates which logical operator ('AND' or 'OR') should be used when combining this authorization strategy with others. 
        /// </summary>
        public FilterOperator Operator { get; set; } = FilterOperator.Or;
    }
}

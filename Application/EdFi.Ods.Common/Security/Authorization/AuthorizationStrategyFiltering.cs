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
        public string AuthorizationStrategyName { get; init; }

        /// <summary>
        /// Gets or sets the filters to be applied.
        /// </summary>
        public IReadOnlyList<AuthorizationFilterContext> Filters { get; init; }

        /// <summary>
        /// Indicates which logical operator ('AND' or 'OR') should be used when combining this authorization strategy with others. 
        /// </summary>
        public FilterOperator Operator { get; init; } = FilterOperator.Or;

        /// <summary>
        /// Indicates whether the authorization strategy filtering that is performed relies on system-assigned values, indicating
        /// that it should be processed after other strategies to avoid exposing the existence or presence of items in the database
        /// to unauthorized callers.
        /// </summary>
        public bool UsesSystemAssignedValues { get; set; }
    }
}

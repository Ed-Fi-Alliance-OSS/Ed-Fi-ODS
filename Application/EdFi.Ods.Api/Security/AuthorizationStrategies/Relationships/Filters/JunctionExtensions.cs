// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public static class JunctionExtensions
    {
        /// <summary>
        /// Applies property-level filter expressions to the criteria as either Equal or In expressions based on the supplied parameters.
        /// </summary>
        /// <param name="whereJunction">The <see cref="ICriterion" /> container for adding WHERE clause criterion.</param>
        /// <param name="parameters">The named parameters to be processed into the criteria query.</param>
        /// <param name="availableFilterProperties">The array of property names that can be used for filtering.</param>
        public static void ApplyPropertyFilters(this Junction whereJunction, IDictionary<string, object> parameters, params string[] availableFilterProperties)
        {
            foreach (var nameAndValue in parameters.Where(x => availableFilterProperties.Contains(x.Key, StringComparer.OrdinalIgnoreCase)))
            {
                if (nameAndValue.Value is object[] arrayOfValues)
                {
                    whereJunction.Add(Restrictions.In($"{nameAndValue.Key}", arrayOfValues));
                }
                else
                {
                    whereJunction.Add(Restrictions.Eq($"{nameAndValue.Key}", nameAndValue.Value));
                }
            }
        }
    }
}

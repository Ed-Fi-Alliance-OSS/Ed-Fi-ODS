// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Security.AuthorizationStrategies.NHibernateConfiguration
{
    /// <summary>
    /// Provides methods for evaluating an array of <see cref="PropertyInfo"/> objects.
    /// </summary>
    public static class PropertyInfoArrayExtensions
    {
        /// <summary>
        /// Indicates whether any of the properties has the specified name (case-insensitive matching).
        /// </summary>
        /// <param name="properties">The array of properties to search.</param>
        /// <param name="caseInsensitivePropertyName">The case-insensitive name of the property for which to search.</param>
        /// <returns><b>true</b> if the property exists; otherwise <b>false</b>.</returns>
        public static bool HasPropertyNamed(
            this PropertyInfo[] properties,
            string caseInsensitivePropertyName)
        {
            return properties.Any(x => x.Name.EqualsIgnoreCase(caseInsensitivePropertyName));
        }
    }
}

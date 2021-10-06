// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Security.Authorization
{
    /// <summary>
    /// Defines a method for constructing the convention-based authorization view name.
    /// </summary>
    public static class ViewNameHelper
    {
        /// <summary>
        /// Gets the convention-based authorization view name (without the schema), constructed by sorting the specified
        /// endpoint names alphabetically and adding the specified modifier as a suffix (if present).
        /// </summary>
        /// <param name="endpoint1">The name of one endpoint represented in the view.</param>
        /// <param name="endpoint2">The name of the other endpoint represented in the view.</param>
        /// <param name="authorizationPathModifier">The path modifier for authorization, if applicable, indicating an alternative mechanism for
        /// establishing a relationship between the two supplied endpoints.</param>
        /// <returns>The authorization view name (without the schema).</returns>
        public static string GetAuthorizationViewName(string endpoint1, string endpoint2, string authorizationPathModifier)
        {
            if (PersonEntitySpecification.IsPersonIdentifier(endpoint1) && endpoint2.EqualsIgnoreCase("EducationOrganizationId"))
            {
                return $"{endpoint1}To{endpoint2}{authorizationPathModifier}";
            }

            if (string.Compare(endpoint1, endpoint2, StringComparison.InvariantCultureIgnoreCase) < 0)
            {
                return $"{endpoint1}To{endpoint2}{authorizationPathModifier}";
            }

            return $"{endpoint2}To{endpoint1}{authorizationPathModifier}";
        }

        /// <summary>
        /// Gets the fully qualified convention-based authorization view name (including the schema), constructed by sorting the specified
        /// endpoint names alphabetically and adding the specified modifier as a suffix (if present).
        /// </summary>
        /// <param name="endpoint1">The name of one endpoint represented in the view.</param>
        /// <param name="endpoint2">The name of the other endpoint represented in the view.</param>
        /// <param name="authorizationPathModifier">The path modifier for authorization, if applicable, indicating an alternative mechanism for
        /// establishing a relationship between the two supplied endpoints.</param>
        /// <returns>The authorization view name (without the schema).</returns>
        public static string GetFullyQualifiedAuthorizationViewName(string endpoint1, string endpoint2, string authorizationPathModifier)
        {
            return $"{SystemConventions.AuthSchema}.{GetAuthorizationViewName(endpoint1, endpoint2, authorizationPathModifier)}";
        }
    }
}

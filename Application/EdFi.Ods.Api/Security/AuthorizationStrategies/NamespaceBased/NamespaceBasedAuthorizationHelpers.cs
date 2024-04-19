// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased;

public static class NamespaceBasedAuthorizationHelpers
{
    public static IList<string> GetClaimNamespacePrefixes(EdFiAuthorizationContext authorizationContext, string authorizationStrategyName)
    {
        var namespacePrefixes = authorizationContext.ApiClientContext.NamespacePrefixes;

        if (!namespacePrefixes.Any() || namespacePrefixes.All(string.IsNullOrEmpty))
        {
            throw new SecurityAuthorizationException(
                "scenario92.",
                $"The API client has been given permissions on a resource that uses the '{authorizationStrategyName}' authorization strategy but the client doesn't have any namespace prefixes assigned.")
            {
                InstanceTypeParts = ["namespace", "invalid-client", "no-namespaces"]
            };
        }

        return namespacePrefixes;
    }
}

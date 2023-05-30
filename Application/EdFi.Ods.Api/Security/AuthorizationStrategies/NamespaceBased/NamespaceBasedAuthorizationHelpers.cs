// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased;

public static class NamespaceBasedAuthorizationHelpers
{
    public static IList<string> GetClaimNamespacePrefixes(EdFiAuthorizationContext authorizationContext)
    {
        var namespacePrefixes = authorizationContext.ApiClientContext.NamespacePrefixes;

        if (!namespacePrefixes.Any() || namespacePrefixes.All(string.IsNullOrEmpty))
        {
            throw new EdFiSecurityException($"Access to the resource could not be authorized because the caller did not have any NamespacePrefix claims ('{EdFiOdsApiClaimTypes.NamespacePrefix}') or the claim values were all empty.");
        }

        return namespacePrefixes;
    }
}

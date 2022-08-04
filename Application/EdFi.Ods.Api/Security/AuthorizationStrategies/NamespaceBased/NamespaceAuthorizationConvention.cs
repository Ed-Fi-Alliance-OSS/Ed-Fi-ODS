// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased;

/// <summary>
/// Provides a shared method implementing the Namespace-based authorization conventions for matching a Namespace-based
/// property to use for authorization. Either a "Namespace" property must exist, or a <i>single</i> prefixed Namespace
/// property must exist, or an exception will occur.
/// </summary>
public static class NamespaceAuthorizationConvention
{
    /// <summary>
    /// Get the name of the property to use for Namespace-based authorization.
    /// </summary>
    /// <param name="resourceFullName">The name of the resource in context (for exception messaging).</param>
    /// <param name="availableProperties">The names of the available properties on the resource/entity.</param>
    /// <returns>The name of the Namespace-based property to use for authorization; otherwise an <see cref="Exception" />.</returns>
    /// <exception cref="Exception">Occurs when there is no property named "Namespace" available, and either no Namespace-suffixed property or more than one present.</exception>
    public static string GetNamespacePropertyName(string resourceFullName, IEnumerable<string> availableProperties)
    {
        string prefixedNamespacePropertyName = null;

        var candidatePropertyNames = availableProperties.Where(pn => pn.EndsWith("Namespace"));

        foreach (string candidatePropertyName in candidatePropertyNames)
        {
            if (candidatePropertyName == "Namespace")
            {
                return "Namespace";
            }

            if (prefixedNamespacePropertyName == null)
            {
                prefixedNamespacePropertyName = candidatePropertyName;
            }
            else
            {
                throw new Exception(
                    $"Unable to definitively identify a Namespace-based property in the '{resourceFullName}' resource to use for Namespace-based authorization.");
            }
        }

        return prefixedNamespacePropertyName
            ?? throw new Exception(
                $"There is no Namespace-based property in the '{resourceFullName}' resource to use for Namespace-based authorization.");
    }
}

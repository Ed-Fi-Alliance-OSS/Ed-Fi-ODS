// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Extensions;

namespace EdFi.Ods.Common.Specifications;

public static class UniqueIdConventions
{
    public const string UsiSuffix = "USI";
    public const string UniqueIdSuffix = "UniqueId";

    /// <summary>
    /// Indicates whether the supplied property name matches the USI naming convention.
    /// </summary>
    /// <param name="propertyName">The property name to be evaluated.</param>
    /// <param name="personEntityName">If supplied, ensures the property name also matches the person entity name as the prefix.</param>
    /// <returns><b>true</b> if the property matches the convention; otherwise <b>false</b>.</returns>
    public static bool IsUSI(string propertyName, string personEntityName = null)
    {
        if (personEntityName == null)
        {
            return propertyName.EndsWith(UsiSuffix);
        }
        
        return propertyName.StartsWithIgnoreCase(personEntityName)
            && propertyName.EndsWith(UsiSuffix)
            && propertyName.Length == (personEntityName.Length + UsiSuffix.Length);
    }

    public static string RemoveUsiSuffix(string propertyName)
    {
        return propertyName.ReplaceSuffix(UsiSuffix, string.Empty);
    }

    public static string GetUsiPropertyName(string uniqueIdColumnName)
    {
        return uniqueIdColumnName.ReplaceSuffix(UniqueIdSuffix, UsiSuffix);
    }

    /// <summary>
    /// Indicates whether the supplied property name matches the UniqueId naming convention.
    /// </summary>
    /// <param name="propertyName">The property name to be evaluated.</param>
    /// <param name="personEntityName">If supplied, ensures the property name also matches the person entity name as the prefix.</param>
    /// <returns><b>true</b> if the property matches the convention; otherwise <b>false</b>.</returns>
    public static bool IsUniqueId(string propertyName, string personEntityName = null)
    {
        if (personEntityName == null)
        {
            return propertyName.EndsWith(UniqueIdSuffix);
        }

        return propertyName.StartsWithIgnoreCase(personEntityName)
            && propertyName.EndsWith(UniqueIdSuffix)
            && propertyName.Length == (personEntityName.Length + UniqueIdSuffix.Length);
    }

    public static string RemoveUniqueIdSuffix(string propertyName)
    {
        return propertyName.ReplaceSuffix(UniqueIdSuffix, string.Empty);
    }

    public static string GetUniqueIdPropertyName(string usiPropertyName)
    {
        return usiPropertyName.ReplaceSuffix(UsiSuffix, UniqueIdSuffix);
    }
}

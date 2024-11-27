// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Extensions;

public static class EntityReferenceDataExtensions
{
    /// <summary>
    /// Indicates whether the supplied object instance's type name matches the pattern used by NHibernate when building
    /// proxied objects for lazy loading purposes.
    /// </summary>
    /// <param name="instance">The entity instance to be evaluated.</param>
    /// <returns><b>true</b> if the instance appears to be proxied; otherwise <b>false</b>.</returns>
    public static bool IsProxied(this IEntityReferenceData instance)
    {
        if (instance == null)
        {
            return false;
        }

        return instance.GetType().Name.EndsWith("Proxy");
    }
}

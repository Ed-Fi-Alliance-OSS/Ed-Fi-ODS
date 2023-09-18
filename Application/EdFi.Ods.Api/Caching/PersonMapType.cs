// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Caching;

/// <summary>
/// Identifies the type of person map for a cache key to delineate entries for the same ODS instance and person type.
/// </summary>
public enum PersonMapType
{
    /// <summary>
    /// The mapping contains UniqueId values accessible by USI.
    /// </summary>
    UniqueIdByUsi,
    /// <summary>
    /// The mapping contains USI values accessible by UniqueId.
    /// </summary>
    UsiByUniqueId
}

public static class PersonMapTypeExtensions
{
    /// <summary>
    /// Returns the <see cref="PersonMapType" /> value that is the inverse of the one provided.
    /// </summary>
    /// <param name="personMapType">The map type to be inverted.</param>
    /// <returns>The inverse map type.</returns>
    /// <exception cref="NotSupportedException"></exception>
    public static PersonMapType Inverse(this PersonMapType personMapType)
    {
        switch (personMapType)
        {
            case PersonMapType.UniqueIdByUsi:
                return PersonMapType.UsiByUniqueId;
            case PersonMapType.UsiByUniqueId:
                return PersonMapType.UniqueIdByUsi;
            default:
                // Should never happen (defensive programming)
                throw new NotSupportedException($"Inverse of person identifier map type '{personMapType}' is not supported.");
        }
    }
}
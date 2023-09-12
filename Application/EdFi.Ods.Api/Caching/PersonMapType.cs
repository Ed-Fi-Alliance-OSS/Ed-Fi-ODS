// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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

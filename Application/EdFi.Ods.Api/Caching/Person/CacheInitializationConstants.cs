// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Caching.Person;

/// <summary>
/// Defines constants for cache keys for entries added to track the initiation of background cache initialization.
/// </summary>
public static class CacheInitializationConstants
{
    /// <summary>
    /// The UniqueId cache entry key to be used for denoting that background cache initialization has been initiated. 
    /// </summary>
    public const string InitializationMarkerKeyForUniqueId = "__initialized__";

    /// <summary>
    /// The USI cache entry key to be used for denoting that background cache initialization has been initiated. 
    /// </summary>
    public const int InitializationMarkerKeyForUsi = int.MinValue;
}

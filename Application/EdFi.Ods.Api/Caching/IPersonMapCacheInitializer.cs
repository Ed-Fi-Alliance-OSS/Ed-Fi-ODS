// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;

namespace EdFi.Ods.Api.Caching;

/// <summary>
/// Defines a method for ensuring that the person UniqueId/USI map cache has been initiated for the specified ODS.
/// </summary>
public interface IPersonMapCacheInitializer
{
    /// <summary>
    /// Initiates the background initialization of the person UniqueId/USI map cache for the specified ODS.
    /// </summary>
    /// <param name="odsInstanceHashId">The unique hashId of the ODS instance.</param>
    /// <param name="personType">The person type for the cache initialization.</param>
    /// <returns>A <see cref="Task" /> that is suitable for background execution (i.e. created using the <see cref="Task.Run" /> method).</returns>
    Task InitializePersonMapAsync(ulong odsInstanceHashId, string personType);
}
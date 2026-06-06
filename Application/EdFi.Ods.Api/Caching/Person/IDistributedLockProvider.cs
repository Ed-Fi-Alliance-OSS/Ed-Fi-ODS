// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.Caching.Person;

/// <summary>
/// Defines methods for coordinating distributed access to background cache initialization.
/// </summary>
public interface IDistributedLockProvider
{
    /// <summary>
    /// Attempts to acquire a distributed lock with the specified key.
    /// </summary>
    /// <param name="lockKey">The lock key.</param>
    /// <param name="expiration">The lock expiration period.</param>
    /// <returns><see langword="true"/> if the lock was acquired; otherwise, <see langword="false"/>.</returns>
    Task<bool> TryAcquireLockAsync(string lockKey, TimeSpan expiration);

    /// <summary>
    /// Releases a distributed lock.
    /// </summary>
    /// <param name="lockKey">The lock key.</param>
    Task ReleaseLockAsync(string lockKey);
}

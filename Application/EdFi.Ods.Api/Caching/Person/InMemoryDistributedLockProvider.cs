// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.Caching.Person;

/// <summary>
/// Provides an in-memory distributed lock provider for single-process cache initialization coordination.
/// </summary>
public class InMemoryDistributedLockProvider : IDistributedLockProvider
{
    private readonly ConcurrentDictionary<string, DateTimeOffset> _lockExpirations = new();

    /// <inheritdoc />
    public Task<bool> TryAcquireLockAsync(string lockKey, TimeSpan expiration)
    {
        ArgumentNullException.ThrowIfNull(lockKey);

        DateTimeOffset now = DateTimeOffset.UtcNow;
        DateTimeOffset newExpiration = now.Add(expiration);

        while (true)
        {
            if (_lockExpirations.TryAdd(lockKey, newExpiration))
            {
                return Task.FromResult(true);
            }

            if (!_lockExpirations.TryGetValue(lockKey, out DateTimeOffset existingExpiration))
            {
                continue;
            }

            if (existingExpiration > now)
            {
                return Task.FromResult(false);
            }

            if (_lockExpirations.TryUpdate(lockKey, newExpiration, existingExpiration))
            {
                return Task.FromResult(true);
            }
        }
    }

    /// <inheritdoc />
    public Task ReleaseLockAsync(string lockKey)
    {
        ArgumentNullException.ThrowIfNull(lockKey);
        _lockExpirations.TryRemove(lockKey, out _);
        return Task.CompletedTask;
    }
}

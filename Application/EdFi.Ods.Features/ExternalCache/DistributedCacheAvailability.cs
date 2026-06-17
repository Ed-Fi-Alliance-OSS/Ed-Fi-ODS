// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Polly.CircuitBreaker;
using StackExchange.Redis;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Classifies exceptions raised by distributed-cache operations, distinguishing transient
/// infrastructure unavailability (an open circuit breaker or Redis connectivity/timeout failures)
/// from genuine application errors. When the cache is merely unavailable, callers should degrade
/// gracefully — treating reads as a miss and writes as a no-op — rather than failing the request.
/// </summary>
public static class DistributedCacheAvailability
{
    /// <summary>
    /// Returns <c>true</c> when the exception indicates the distributed cache is temporarily
    /// unavailable (the resilience circuit breaker is open, or Redis is unreachable/timing out)
    /// and the operation should be treated as a cache miss/no-op instead of a hard failure.
    /// </summary>
    /// <param name="ex">The exception thrown by a distributed-cache operation.</param>
    public static bool IsUnavailable(Exception ex)
    {
        if (ex is BrokenCircuitException)
        {
            return true;
        }

        if (ex is TimeoutException or OperationCanceledException
            or RedisConnectionException or RedisTimeoutException)
        {
            return true;
        }

        string message = ex.Message.ToLowerInvariant();

        return message.Contains("timeout")
            || message.Contains("connection")
            || message.Contains("unavailable");
    }
}

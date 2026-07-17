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
    /// <remarks>
    /// Classification is by known exception type only — deliberately not by message text. Callers
    /// wrap serialization/deserialization in the same try block, so matching on message content
    /// (e.g. "timeout"/"connection") risks misclassifying a genuine application bug as a transient
    /// cache failure and silently swallowing it as a miss/no-op.
    /// </remarks>
    /// <param name="ex">The exception thrown by a distributed-cache operation.</param>
    public static bool IsUnavailable(Exception ex)
    {
        return ex is BrokenCircuitException
            or TimeoutException
            or OperationCanceledException
            or RedisConnectionException
            or RedisTimeoutException;
    }
}

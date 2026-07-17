// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Features.ExternalCache;
using EdFi.Ods.Features.ExternalCache.Redis;
using FakeItEasy;
using Microsoft.Extensions.Caching.Distributed;
using NUnit.Framework;
using Shouldly;
using StackExchange.Redis;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Exercises the providers against a live (non-faked) <see cref="RedisCacheResilience" /> pipeline: repeated
/// Redis failures must trip the circuit breaker, after which calls degrade gracefully (miss/no-op) and fail
/// fast without reaching Redis. Asserting the underlying call count proves the pipeline is actually in the
/// execution path — these tests fail if the circuit breaker is removed or bypassed.
/// </summary>
[TestFixture]
public class ExternalCacheProviderCircuitBreakerTests
{
    // MinimumThroughput of 2 (Polly's minimum) so two consecutive failures open the circuit.
    private const int FailureThreshold = 2;
    private const int TotalCalls = 5;

    private static RedisConnectionException CreateConnectionFailure()
    {
        return new RedisConnectionException(ConnectionFailureType.SocketClosed, "connection lost");
    }

    [Test]
    public void TryGetCachedObject_Should_degrade_to_a_miss_and_stop_calling_redis_once_the_circuit_opens()
    {
        var distributedCache = A.Fake<IDistributedCache>();

        A.CallTo(() => distributedCache.Get(A<string>._))
            .Throws(CreateConnectionFailure());

        var provider = new ExternalCacheProvider<string>(
            distributedCache,
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(5),
            new RedisCacheResilience(failureThreshold: FailureThreshold, breakDurationSeconds: 30));

        for (int i = 0; i < TotalCalls; i++)
        {
            bool found = provider.TryGetCachedObject("test-key", out object value);

            found.ShouldBeFalse();
            value.ShouldBeNull();
        }

        // The first two failures trip the breaker; the remaining calls fail fast with
        // BrokenCircuitException (degraded to a miss) without reaching Redis.
        A.CallTo(() => distributedCache.Get(A<string>._))
            .MustHaveHappened(FailureThreshold, Times.Exactly);
    }

    [Test]
    public void SetCachedObject_Should_skip_the_write_and_stop_calling_redis_once_the_circuit_opens()
    {
        var distributedCache = A.Fake<IDistributedCache>();

        A.CallTo(() => distributedCache.Set(A<string>._, A<byte[]>._, A<DistributedCacheEntryOptions>._))
            .Throws(CreateConnectionFailure());

        var provider = new ExternalCacheProvider<string>(
            distributedCache,
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(5),
            new RedisCacheResilience(failureThreshold: FailureThreshold, breakDurationSeconds: 30));

        for (int i = 0; i < TotalCalls; i++)
        {
            Should.NotThrow(() => provider.SetCachedObject("test-key", "value"));
        }

        A.CallTo(() => distributedCache.Set(A<string>._, A<byte[]>._, A<DistributedCacheEntryOptions>._))
            .MustHaveHappened(FailureThreshold, Times.Exactly);
    }

    [Test]
    public async Task TryGetCachedObjectAsync_Should_degrade_to_a_miss_and_stop_calling_redis_once_the_circuit_opens()
    {
        var distributedCache = A.Fake<IDistributedCache>();

        A.CallTo(() => distributedCache.GetAsync(A<string>._, A<CancellationToken>._))
            .ThrowsAsync(CreateConnectionFailure());

        var provider = new AsyncExternalCacheProvider<string>(
            distributedCache,
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(5),
            new RedisCacheResilience(failureThreshold: FailureThreshold, breakDurationSeconds: 30));

        for (int i = 0; i < TotalCalls; i++)
        {
            var (found, value) = await provider.TryGetCachedObjectAsync("test-key");

            found.ShouldBeFalse();
            value.ShouldBeNull();
        }

        A.CallTo(() => distributedCache.GetAsync(A<string>._, A<CancellationToken>._))
            .MustHaveHappened(FailureThreshold, Times.Exactly);
    }

    [Test]
    public async Task SetCachedObjectAsync_Should_skip_the_write_and_stop_calling_redis_once_the_circuit_opens()
    {
        var distributedCache = A.Fake<IDistributedCache>();

        A.CallTo(() => distributedCache.SetAsync(A<string>._, A<byte[]>._, A<DistributedCacheEntryOptions>._, A<CancellationToken>._))
            .ThrowsAsync(CreateConnectionFailure());

        var provider = new AsyncExternalCacheProvider<string>(
            distributedCache,
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(5),
            new RedisCacheResilience(failureThreshold: FailureThreshold, breakDurationSeconds: 30));

        for (int i = 0; i < TotalCalls; i++)
        {
            await Should.NotThrowAsync(() => provider.SetCachedObjectAsync("test-key", "value"));
        }

        A.CallTo(() => distributedCache.SetAsync(A<string>._, A<byte[]>._, A<DistributedCacheEntryOptions>._, A<CancellationToken>._))
            .MustHaveHappened(FailureThreshold, Times.Exactly);
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Features.ExternalCache;
using EdFi.Ods.Features.ExternalCache.Redis;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.Extensions.Caching.Distributed;
using NUnit.Framework;
using Polly.CircuitBreaker;
using Shouldly;
using StackExchange.Redis;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ExternalCache
{
    [TestFixture]
    public class ExternalCacheProviderTests
    {
        public abstract class When_the_underlying_distributed_cache_fails : TestFixtureBase
        {
            ExternalCacheProvider<string> _externalCacheProvider;

            protected override void Arrange()
            {
                var distributedCache = A.Fake<IDistributedCache>();

                A.CallTo(() => distributedCache.Get(A<string>.Ignored))
                    .Throws(new Exception());

                A.CallTo(() => distributedCache.Set(A<string>.Ignored, A<byte[]>.Ignored, A<DistributedCacheEntryOptions>.Ignored))
                    .Throws(new Exception());

                _externalCacheProvider = new ExternalCacheProvider<string>(distributedCache, A.Dummy<TimeSpan>(), A.Dummy<TimeSpan>(), new RedisCacheResilience());
            }

            public class A_call_to_TryGetCachedObject : When_the_underlying_distributed_cache_fails
            {
                protected override void Act()
                {
                    _externalCacheProvider.TryGetCachedObject(A.Dummy<string>(), out _);
                }
            }

            public class A_call_to_SetCachedObject : When_the_underlying_distributed_cache_fails
            {
                protected override void Act()
                {
                    _externalCacheProvider.SetCachedObject(A.Dummy<string>(), A.Dummy<object>());
                }
            }

            public class A_call_to_Insert : When_the_underlying_distributed_cache_fails
            {
                protected override void Act()
                {
                    _externalCacheProvider.Insert(A.Dummy<string>(), A.Dummy<object>(), A.Dummy<DateTime>(), A.Dummy<TimeSpan>());
                }
            }

            [Test]
            public void Should_throw_an_exception()
            {
                var problemDetails = ActualException.ShouldBeOfType<DistributedCacheException>();

                AssertHelper.All(
                    () => problemDetails.Status.ShouldBe(500),
                    () => problemDetails.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "system:distributed-cache-error")),
                    () => problemDetails.Detail.ShouldBe("An unexpected problem has occurred.")
                );
            }
        }

        public abstract class When_the_distributed_cache_is_unavailable : TestFixtureBase
        {
            protected ExternalCacheProvider<string> ExternalCacheProvider;

            protected override void Arrange()
            {
                var distributedCache = A.Fake<IDistributedCache>();

                // A Redis connectivity failure surfaces as a timeout/connection exception, which should be
                // treated as the cache being temporarily unavailable rather than a hard failure.
                A.CallTo(() => distributedCache.Get(A<string>.Ignored))
                    .Throws(new TimeoutException());

                A.CallTo(() => distributedCache.Set(A<string>.Ignored, A<byte[]>.Ignored, A<DistributedCacheEntryOptions>.Ignored))
                    .Throws(new TimeoutException());

                ExternalCacheProvider = new ExternalCacheProvider<string>(distributedCache, A.Dummy<TimeSpan>(), A.Dummy<TimeSpan>(), new RedisCacheResilience());
            }

            public class A_call_to_TryGetCachedObject : When_the_distributed_cache_is_unavailable
            {
                private bool _result;

                protected override void Act()
                {
                    _result = ExternalCacheProvider.TryGetCachedObject("key", out _);
                }

                [Test]
                public void Should_degrade_to_a_cache_miss_without_throwing()
                {
                    AssertHelper.All(
                        () => ActualException.ShouldBeNull(),
                        () => _result.ShouldBeFalse());
                }
            }

            public class A_call_to_SetCachedObject : When_the_distributed_cache_is_unavailable
            {
                protected override void Act()
                {
                    ExternalCacheProvider.SetCachedObject("key", "value");
                }

                [Test]
                public void Should_not_throw()
                {
                    ActualException.ShouldBeNull();
                }
            }

            public class A_call_to_Insert : When_the_distributed_cache_is_unavailable
            {
                protected override void Act()
                {
                    ExternalCacheProvider.Insert("key", "value", DateTime.MaxValue, TimeSpan.Zero);
                }

                [Test]
                public void Should_not_throw()
                {
                    ActualException.ShouldBeNull();
                }
            }
        }

        [TestFixture]
        public class DistributedCacheAvailability_classification
        {
            [Test]
            public void Should_treat_an_open_circuit_breaker_as_unavailable()
            {
                DistributedCacheAvailability.IsUnavailable(new BrokenCircuitException()).ShouldBeTrue();
            }

            [Test]
            public void Should_treat_redis_connectivity_failures_as_unavailable()
            {
                AssertHelper.All(
                    () => DistributedCacheAvailability.IsUnavailable(new TimeoutException()).ShouldBeTrue(),
                    () => DistributedCacheAvailability.IsUnavailable(new OperationCanceledException()).ShouldBeTrue(),
                    () => DistributedCacheAvailability.IsUnavailable(new RedisTimeoutException("timed out", CommandStatus.Unknown)).ShouldBeTrue(),
                    () => DistributedCacheAvailability.IsUnavailable(new RedisConnectionException(ConnectionFailureType.UnableToConnect, "no connection")).ShouldBeTrue());
            }

            [Test]
            public void Should_treat_a_generic_error_as_a_genuine_failure()
            {
                // Classification is by type, not message text: a non-cache exception whose message merely
                // contains words like "connection" must NOT be swallowed as a transient cache failure.
                AssertHelper.All(
                    () => DistributedCacheAvailability.IsUnavailable(new InvalidOperationException("boom")).ShouldBeFalse(),
                    () => DistributedCacheAvailability.IsUnavailable(new InvalidOperationException("connection reset by a bug")).ShouldBeFalse());
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Features.ExternalCache;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.Extensions.Caching.Distributed;
using NUnit.Framework;
using Shouldly;
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

                _externalCacheProvider = new ExternalCacheProvider<string>(distributedCache, A.Dummy<TimeSpan>(), A.Dummy<TimeSpan>());
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
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Features.ExternalCache;
using FakeItEasy;
using Microsoft.Extensions.Caching.Distributed;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ExternalCache;

[TestFixture]
public class AsyncExternalCacheProviderTests
{
    [Test]
    public async Task TryGetCachedObjectAsync_ShouldReturnNotFound_WhenDistributedCacheThrows()
    {
        // Arrange
        var distributedCache = A.Fake<IDistributedCache>();

        A.CallTo(() => distributedCache.GetAsync("test-key", A<CancellationToken>._))
            .ThrowsAsync(new Exception("redis unavailable"));

        var provider = new AsyncExternalCacheProvider<string>(
            distributedCache,
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(5));

        // Act
        var (found, value) = await provider.TryGetCachedObjectAsync("test-key");

        // Assert
        found.ShouldBeFalse();
        value.ShouldBeNull();
    }

    [Test]
    public async Task TryGetCachedObjectAsync_ShouldReturnFound_WhenDistributedCacheReturnsValue()
    {
        // Arrange
        var distributedCache = A.Fake<IDistributedCache>();

        A.CallTo(() => distributedCache.GetAsync("test-key", A<CancellationToken>._))
            .Returns(Task.FromResult(Encoding.UTF8.GetBytes("(int)42")));

        var provider = new AsyncExternalCacheProvider<string>(
            distributedCache,
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(5));

        // Act
        var (found, value) = await provider.TryGetCachedObjectAsync("test-key");

        // Assert
        found.ShouldBeTrue();
        value.ShouldBe(42);
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching
{
    [TestFixture]
    public class ExpiringConcurrentDictionaryCacheProviderTests
    {
        private static readonly TimeSpan _expirationPeriod = TimeSpan.FromMilliseconds(250);

        [Test]
        public void TryGetCachedObject_ShouldReturnFalse_WhenCacheDisabled()
        {
            // Arrange
            var provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", TimeSpan.FromSeconds(-1));

            // Act
            var result = provider.TryGetCachedObject("TestKey", out var value);

            // Assert
            result.ShouldBeFalse();
            value.ShouldBeNull();
        }

        [Test]
        public void SetCachedObject_ShouldNotAddValue_WhenCacheDisabled()
        {
            // Arrange
            var provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", TimeSpan.FromSeconds(-1));

            // Act
            provider.SetCachedObject("TestKey", "TestValue");

            // Assert
            var result = provider.TryGetCachedObject("TestKey", out var value);
            result.ShouldBeFalse();
            value.ShouldBeNull();
        }

        [Test]
        public void Insert_ShouldNotAddValue_WhenCacheDisabled()
        {
            // Arrange
            var provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", TimeSpan.FromSeconds(-1));

            // Act
            provider.Insert("TestKey", "TestValue", DateTime.UtcNow, TimeSpan.Zero);

            // Assert
            var result = provider.TryGetCachedObject("TestKey", out var value);
            result.ShouldBeFalse();
            value.ShouldBeNull();
        }

        [Test]
        public async Task CacheExpired_ShouldClearDictionary_WhenTimerExpires()
        {
            // Arrange
            var expirationCallback = A.Fake<Action>();
            var provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", _expirationPeriod, expirationCallback);

            // Act
            provider.SetCachedObject("TestKey1", "TestValue1");
            provider.SetCachedObject("TestKey2", "TestValue2");
            await Task.Delay(_expirationPeriod * 1.25); // Wait for expiration period to elapse

            // Assert
            A.CallTo(() => expirationCallback.Invoke()).MustHaveHappenedOnceExactly();
            provider.TryGetCachedObject("TestKey1", out var value1).ShouldBeFalse();
            provider.TryGetCachedObject("TestKey2", out var value2).ShouldBeFalse();
        }
        
        [Test]
        public async Task CacheExpired_ShouldNotClearDictionary_WhenExpirationIsDisabled()
        {
            // Arrange
            var expirationCallback = A.Fake<Action>();
            var provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", TimeSpan.Zero, expirationCallback);

            // Act
            provider.SetCachedObject("TestKey1", "TestValue1");
            provider.SetCachedObject("TestKey2", "TestValue2");
            await Task.Delay(_expirationPeriod * 1.25); // Wait for expiration period to elapse

            // Assert
            A.CallTo(() => expirationCallback.Invoke()).MustNotHaveHappened();
            
            provider.TryGetCachedObject("TestKey1", out var value1).ShouldBeTrue();
            provider.TryGetCachedObject("TestKey2", out var value2).ShouldBeTrue();
            value1.ShouldBe("TestValue1");
            value2.ShouldBe("TestValue2");
        }

        [Test]
        public async Task Insert_ShouldAddValue_WhenCacheEnabled()
        {
            // Arrange
            var provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", _expirationPeriod);

            // Act
            provider.Insert("TestKey", "TestValue", DateTime.UtcNow, TimeSpan.Zero);

            // Assert
            var result = provider.TryGetCachedObject("TestKey", out var value);
            result.ShouldBeTrue();
            value.ShouldBe("TestValue");
            await Task.Delay(_expirationPeriod * 1.25); // Wait for cache to expire
            result = provider.TryGetCachedObject("TestKey", out value);
            result.ShouldBeFalse();
            value.ShouldBeNull();
        }
        
        [Test]
        public async Task SetCacheObject_ShouldAddValue_WhenCacheEnabled()
        {
            // Arrange
            var provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", _expirationPeriod);

            // Act
            provider.SetCachedObject("TestKey", "TestValue");

            // Assert
            var result = provider.TryGetCachedObject("TestKey", out var value);
            result.ShouldBeTrue();
            value.ShouldBe("TestValue");
            await Task.Delay(_expirationPeriod * 1.25); // Wait for cache to expire
            result = provider.TryGetCachedObject("TestKey", out value);
            result.ShouldBeFalse();
            value.ShouldBeNull();
        }
    }
}

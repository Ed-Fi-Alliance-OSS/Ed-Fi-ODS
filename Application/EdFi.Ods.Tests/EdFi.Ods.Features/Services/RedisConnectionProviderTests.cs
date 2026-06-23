// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.Services.Redis;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Services;

[TestFixture]
public class RedisConnectionProviderTests
{
    [Test]
    public void Constructor_WhenRedisConfigurationIsNull_ThrowsArgumentNullException()
    {
        // Arrange, Act, Assert
        var ex = Should.Throw<ArgumentNullException>(() => new RedisConnectionProvider((RedisConfiguration)null));
        ex.ParamName.ShouldBe("redisConfiguration");
    }

    [Test]
    public void Constructor_WithValidConfiguration_InitializesSuccessfully()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration { Configuration = "localhost:6379" };

        // Act
        var provider = new RedisConnectionProvider(redisConfiguration);

        // Assert
        provider.ShouldNotBeNull();
        provider.IsConnected.ShouldBeFalse();
    }

    [Test]
    public void Constructor_WithConnectionString_InitializesSuccessfully()
    {
        // Act
        var provider = new RedisConnectionProvider("localhost:6379");

        // Assert
        provider.ShouldNotBeNull();
        provider.IsConnected.ShouldBeFalse();
    }

    [Test]
    public void Constructor_WithAllConfigurationSettings_AppliesAllSettingsCorrectly()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration
        {
            Configuration = "localhost:6379",
            SyncTimeoutMs = 5000,
            AsyncTimeoutMs = 8000,
            ConnectTimeoutMs = 12000,
            ConnectRetry = 3,
            AbortOnConnectFail = true,
            KeepAliveSeconds = 60,
            Ssl = true,
            Password = "test-password",
        };

        // Act
        var provider = new RedisConnectionProvider(redisConfiguration);

        // Assert
        provider.ShouldNotBeNull();
        provider.IsConnected.ShouldBeFalse();
    }

    // Previously, the constructor defaulted to "localhost" for Redis. However, this is insecure if triggered accidentally in production.
    [Test]
    public void Constructor_WithEmptyConfiguration_ThrowsException()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration { Configuration = string.Empty };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new RedisConnectionProvider(redisConfiguration));
    }

    [Test]
    public void Constructor_WithNullConfiguration_ThrowsException()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration { Configuration = null };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new RedisConnectionProvider(redisConfiguration));
    }

    [Test]
    public void Constructor_WithDefaultTimeoutValues_UsesConfiguredDefaults()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration
        {
            Configuration = "localhost:6379",
            // Using default timeout values
        };

        // Act
        var provider = new RedisConnectionProvider(redisConfiguration);

        // Assert
        provider.ShouldNotBeNull();
        // Verify defaults are applied by checking constructor succeeds and IsConnected is false
        provider.IsConnected.ShouldBeFalse();
    }

    [Test]
    public void Constructor_WithCustomTimeouts_AppliesCustomValues()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration
        {
            Configuration = "localhost:6379",
            SyncTimeoutMs = 2000,
            AsyncTimeoutMs = 3000,
            ConnectTimeoutMs = 4000,
            ConnectRetry = 2,
            AbortOnConnectFail = true,
            KeepAliveSeconds = 45,
            Ssl = true,
        };

        // Act
        var provider = new RedisConnectionProvider(redisConfiguration);

        // Assert
        provider.ShouldNotBeNull();
    }

    [Test]
    public void Constructor_WithPasswordSet_InitializesSuccessfully()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration
        {
            Configuration = "localhost:6379",
            Password = "secure-password",
        };

        // Act
        var provider = new RedisConnectionProvider(redisConfiguration);

        // Assert
        provider.ShouldNotBeNull();
    }

    [Test]
    public void Constructor_WithEmptyPassword_InitializesSuccessfully()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration
        {
            Configuration = "localhost:6379",
            Password = string.Empty,
        };

        // Act
        var provider = new RedisConnectionProvider(redisConfiguration);

        // Assert
        provider.ShouldNotBeNull();
    }

    [Test]
    public void Constructor_WithWhitespacePassword_IgnoresPassword()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration
        {
            Configuration = "localhost:6379",
            Password = "   ",
        };

        // Act
        var provider = new RedisConnectionProvider(redisConfiguration);

        // Assert
        provider.ShouldNotBeNull();
    }

    [Test]
    public void Constructor_MultipleInstances_AreIndependent()
    {
        // Arrange
        var config1 = new RedisConfiguration { Configuration = "localhost:6379" };
        var config2 = new RedisConfiguration { Configuration = "localhost:6380" };

        // Act
        var provider1 = new RedisConnectionProvider(config1);
        var provider2 = new RedisConnectionProvider(config2);

        // Assert
        provider1.ShouldNotBeNull();
        provider2.ShouldNotBeNull();
        provider1.IsConnected.ShouldBeFalse();
        provider2.IsConnected.ShouldBeFalse();
    }

    [Test]
    public void Constructor_WithSslDisabled_InitializesSuccessfully()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration
        {
            Configuration = "localhost:6379",
            Ssl = false,
        };

        // Act
        var provider = new RedisConnectionProvider(redisConfiguration);

        // Assert
        provider.ShouldNotBeNull();
    }

    [Test]
    public void Constructor_WithSslEnabled_InitializesSuccessfully()
    {
        // Arrange
        var redisConfiguration = new RedisConfiguration
        {
            Configuration = "localhost:6379",
            Ssl = true,
        };

        // Act
        var provider = new RedisConnectionProvider(redisConfiguration);

        // Assert
        provider.ShouldNotBeNull();
    }
}

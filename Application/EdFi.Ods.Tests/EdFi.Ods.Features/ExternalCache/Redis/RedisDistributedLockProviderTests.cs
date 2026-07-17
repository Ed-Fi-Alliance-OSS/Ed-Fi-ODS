// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Features.ExternalCache.Redis;
using EdFi.Ods.Features.Services.Redis;
using FakeItEasy;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Polly;
using Polly.CircuitBreaker;
using Shouldly;
using StackExchange.Redis;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ExternalCache.Redis;

[TestFixture]
public class RedisDistributedLockProviderTests
{
    private IRedisConnectionProvider _redisConnectionProvider;
    private IDatabase _database;
    private RedisCacheResilience _resilience;
    private RedisDistributedLockProvider _provider;

    [SetUp]
    public void SetUp()
    {
        _redisConnectionProvider = A.Fake<IRedisConnectionProvider>();
        _database = A.Fake<IDatabase>();
        _resilience = new RedisCacheResilience();

        // Mock the Multiplexer and server for script loading in the constructor
        var multiplexer = A.Fake<IConnectionMultiplexer>();
        var server = A.Fake<IServer>();
        var endpoint = new DnsEndPoint("localhost", 6379);

        A.CallTo(() => _database.Multiplexer).Returns(multiplexer);
        A.CallTo(() => multiplexer.GetEndPoints(false)).Returns(new EndPoint[] { endpoint });
        A.CallTo(() => multiplexer.GetServer(endpoint, null)).Returns(server);
        A.CallTo(() => server.ScriptLoad(A<string>._, CommandFlags.None))
            .Returns(new byte[] { 1, 2, 3 });
        A.CallTo(() => _redisConnectionProvider.Get()).Returns(_database);

        _provider = new RedisDistributedLockProvider(_redisConnectionProvider, _resilience);
    }

    [Test]
    public async Task TryAcquireLockAsync_ShouldUseSetNxWithProvidedExpiration()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Returns(true);

        var result = await _provider.TryAcquireLockAsync(lockKey, expiration);

        result.ShouldBeTrue();

        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task TryAcquireLockAsync_ShouldReturnFalse_WhenLockAlreadyExists()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Returns(false);

        var result = await _provider.TryAcquireLockAsync(lockKey, expiration);

        result.ShouldBeFalse();
    }

    [Test]
    public async Task ReleaseLockAsync_ShouldUseLuaScriptToSafelyDeleteLock()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        // First, acquire a lock
        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Returns(true);

        await _provider.TryAcquireLockAsync(lockKey, expiration);

        // Then release the lock
        A.CallTo(() =>
                _database.ScriptEvaluateAsync(
                    A<byte[]>._,
                    A<RedisKey[]>.That.Matches(k => k[0].ToString() == lockKey),
                    A<RedisValue[]>.That.IsNotNull(),
                    CommandFlags.None
                )
            )
            .Returns(RedisResult.Create((long)1));

        await _provider.ReleaseLockAsync(lockKey);

        A.CallTo(() =>
                _database.ScriptEvaluateAsync(
                    A<byte[]>._,
                    A<RedisKey[]>.That.Matches(k => k[0].ToString() == lockKey),
                    A<RedisValue[]>.That.IsNotNull(),
                    CommandFlags.None
                )
            )
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task ReleaseLockAsync_ShouldNotExecuteScriptIfTokenNotFound()
    {
        const string lockKey = "cache-init-lock";

        // Try to release without acquiring first
        await _provider.ReleaseLockAsync(lockKey);

        // Verify ScriptEvaluateAsync was never called
        A.CallTo(() =>
                _database.ScriptEvaluateAsync(
                    A<byte[]>._,
                    A<RedisKey[]>._,
                    A<RedisValue[]>._,
                    CommandFlags.None
                )
            )
            .MustNotHaveHappened();
    }

    [Test]
    public void TryAcquireLockAsync_ShouldThrow_WhenLockKeyIsNull()
    {
        var exception = Should.Throw<ArgumentNullException>(() =>
            _provider.TryAcquireLockAsync(null!, TimeSpan.FromSeconds(10))
        );

        exception.ParamName.ShouldBe("lockKey");
    }

    [Test]
    public void ReleaseLockAsync_ShouldThrow_WhenLockKeyIsNull()
    {
        var exception = Should.Throw<ArgumentNullException>(() =>
            _provider.ReleaseLockAsync(null!)
        );

        exception.ParamName.ShouldBe("lockKey");
    }

    [Test]
    public async Task TryAcquireLockAsync_ShouldReturnFalse_WhenRedisThrowsConnectionException()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Throws(new RedisConnectionException(ConnectionFailureType.SocketClosed, "Connection failed"));

        var result = await _provider.TryAcquireLockAsync(lockKey, expiration);

        result.ShouldBeFalse();
    }

    [Test]
    public async Task TryAcquireLockAsync_ShouldReturnFalse_WhenRedisThrowsTimeoutException()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Throws(new TimeoutException());

        var result = await _provider.TryAcquireLockAsync(lockKey, expiration);

        result.ShouldBeFalse();
    }

    [Test]
    public async Task TryAcquireLockAsync_ShouldReturnFalse_WhenRedisThrowsOperationCanceledException()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Throws(new OperationCanceledException());

        var result = await _provider.TryAcquireLockAsync(lockKey, expiration);

        result.ShouldBeFalse();
    }

    [Test]
    public async Task TryAcquireLockAsync_ShouldReturnFalse_WhenRedisUnavailable()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Throws(new Exception("Connection to Redis unavailable"));

        var result = await _provider.TryAcquireLockAsync(lockKey, expiration);

        result.ShouldBeFalse();
    }

    [Test]
    public async Task ReleaseLockAsync_ShouldNotThrow_WhenRedisThrowsConnectionException()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        // First acquire lock
        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Returns(true);

        await _provider.TryAcquireLockAsync(lockKey, expiration);

        // Then configure release to throw
        A.CallTo(() =>
                _database.ScriptEvaluateAsync(
                    A<byte[]>._,
                    A<RedisKey[]>._,
                    A<RedisValue[]>._,
                    CommandFlags.None
                )
            )
            .Throws(new RedisConnectionException(ConnectionFailureType.SocketClosed, "Connection failed"));

        // Should not throw
        var threwException = false;
        try
        {
            await _provider.ReleaseLockAsync(lockKey);
        }
        catch
        {
            threwException = true;
        }

        threwException.ShouldBeFalse();
    }

    [Test]
    public async Task ReleaseLockAsync_ShouldNotThrow_WhenRedisThrowsTimeoutException()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        // First acquire lock
        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Returns(true);

        await _provider.TryAcquireLockAsync(lockKey, expiration);

        // Then configure release to throw
        A.CallTo(() =>
                _database.ScriptEvaluateAsync(
                    A<byte[]>._,
                    A<RedisKey[]>._,
                    A<RedisValue[]>._,
                    CommandFlags.None
                )
            )
            .Throws(new TimeoutException());

        // Should not throw
        var threwException = false;
        try
        {
            await _provider.ReleaseLockAsync(lockKey);
        }
        catch
        {
            threwException = true;
        }

        threwException.ShouldBeFalse();
    }

    [Test]
    public async Task ReleaseLockAsync_ShouldNotThrow_WhenRedisUnavailable()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        // First acquire lock
        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Returns(true);

        await _provider.TryAcquireLockAsync(lockKey, expiration);

        // Then configure release to throw
        A.CallTo(() =>
                _database.ScriptEvaluateAsync(
                    A<byte[]>._,
                    A<RedisKey[]>._,
                    A<RedisValue[]>._,
                    CommandFlags.None
                )
            )
            .Throws(new Exception("Redis unavailable"));

        // Should not throw
        var threwException = false;
        try
        {
            await _provider.ReleaseLockAsync(lockKey);
        }
        catch
        {
            threwException = true;
        }

        threwException.ShouldBeFalse();
    }

    [Test]
    public async Task TryAcquireLockAsync_ShouldReturnFalse_WhenCircuitBreakerIsOpen()
    {
        const string lockKey = "cache-init-lock";
        var expiration = TimeSpan.FromSeconds(30);

        // Create a resilience policy with a low failure threshold (requires at least 2 minimum throughput for Polly)
        var brokenCircuitResilience = new RedisCacheResilience(failureThreshold: 2, breakDurationSeconds: 30);
        var testProvider = new RedisDistributedLockProvider(_redisConnectionProvider, brokenCircuitResilience);

        // Configure database to always fail
        A.CallTo(() =>
                _database.StringSetAsync(
                    lockKey,
                    A<RedisValue>.That.Matches(v => !string.IsNullOrEmpty(v)),
                    expiration,
                    When.NotExists
                )
            )
            .Throws(new RedisConnectionException(ConnectionFailureType.SocketClosed, "Connection failed"));

        // Trigger multiple failures to open the circuit
        for (int i = 0; i < 5; i++)
        {
            await testProvider.TryAcquireLockAsync(lockKey, expiration);
        }

        // Wait a moment for the circuit to process
        await Task.Delay(100);

        // Now the circuit should be open; attempt to acquire should return false
        var result = await testProvider.TryAcquireLockAsync(lockKey, expiration);

        result.ShouldBeFalse();
    }
}

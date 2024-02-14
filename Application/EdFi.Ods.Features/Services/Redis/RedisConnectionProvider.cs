// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;

namespace EdFi.Ods.Features.Services.Redis;

public class RedisConnectionProvider : IRedisConnectionProvider
{
    private readonly RedisCacheOptions _options;
    private readonly SemaphoreSlim _connectionLock = new(initialCount: 1, maxCount: 1);

    private volatile IConnectionMultiplexer _connection;
    private IDatabase _cache;

    public RedisConnectionProvider(string configuration)
    {
        _options = new RedisCacheOptions() { Configuration = configuration };
    }
    
    public IDatabase Get()
    {
        EnsureConnected();

        return _cache;
    }
    
    private void EnsureConnected()
    {
        if (_cache != null)
        {
            return;
        }

        _connectionLock.Wait();

        try
        {
            if (_cache == null)
            {
                if(_options.ConnectionMultiplexerFactory is null)
                {
                    if (_options.ConfigurationOptions is not null)
                    {
                        _connection = ConnectionMultiplexer.Connect(_options.ConfigurationOptions);
                    }
                    else if (!string.IsNullOrWhiteSpace(_options.Configuration))
                    {
                        _connection = ConnectionMultiplexer.Connect(_options.Configuration);
                    }
                    else
                    {
                        throw new InvalidOperationException("External cache is enabled and configured for Redis, but neither a configuration string nor Redis configuration options have been provided in appsettings");
                    }
                }
                else
                {
                    _connection = _options.ConnectionMultiplexerFactory().ConfigureAwait(false).GetAwaiter().GetResult();;
                }

                TryRegisterProfiler();
                _cache = _connection.GetDatabase();
            }
        }
        finally
        {
            _connectionLock.Release();
        }
    }

    private void TryRegisterProfiler()
    {
        if (_connection == null)
        {
            throw new InvalidOperationException($"{nameof(_connection)} cannot be null.");
        }

        if (_options.ProfilingSession != null)
        {
            _connection.RegisterProfiler(_options.ProfilingSession);
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration;

public class ServiceSettings
{
    public RedisConfiguration Redis { get; set; } = new();
}

/// <summary>
/// Provides settings for Redis-backed services.
/// </summary>
public class RedisConfiguration
{
    /// <summary>
    /// Gets or sets the base Redis connection string.
    /// </summary>
    public string Configuration { get; set; }

    /// <summary>
    /// Time (in milliseconds) to wait for a synchronous operation to complete. Default: 10000.
    /// </summary>
    public int SyncTimeoutMs { get; set; } = 10000;

    /// <summary>
    /// Time (in milliseconds) to wait for an asynchronous operation to complete. Default: 10000.
    /// </summary>
    public int AsyncTimeoutMs { get; set; } = 10000;

    /// <summary>
    /// Time (in milliseconds) to wait for a connection to be established. Default: 10000.
    /// </summary>
    public int ConnectTimeoutMs { get; set; } = 10000;

    /// <summary>
    /// Number of times to retry connecting on failure. Default: 5.
    /// </summary>
    public int ConnectRetry { get; set; } = 5;

    /// <summary>
    /// Whether to abort if the initial connection attempt fails. Default: false.
    /// </summary>
    public bool AbortOnConnectFail { get; set; }

    /// <summary>
    /// Interval (in seconds) at which to send keepalive pings. Default: 30.
    /// </summary>
    public int KeepAliveSeconds { get; set; } = 30;

    /// <summary>
    /// Whether to use SSL/TLS for the Redis connection. Default: false.
    /// </summary>
    public bool Ssl { get; set; }

    /// <summary>
    /// Optional password for Redis AUTH.
    /// </summary>
    public string Password { get; set; }
}

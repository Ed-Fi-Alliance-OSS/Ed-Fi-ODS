// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using StackExchange.Redis;

namespace EdFi.Ods.Features.Services.Redis;

/// <summary>
/// Provides access to a Redis database connection.
/// </summary>
public interface IRedisConnectionProvider
{
    /// <summary>
    /// Gets a value indicating whether the underlying Redis connection is currently available.
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// Gets the Redis database.
    /// </summary>
    /// <returns>The Redis database.</returns>
    IDatabase Get();
}

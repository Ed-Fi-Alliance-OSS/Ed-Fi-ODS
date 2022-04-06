// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Authentication;

/// <summary>
/// Implements a cache key provider that supports the default cache key format as well for <see cref="ApiMode.InstanceYearSpecific"/>.
/// </summary>
public class ApiClientDetailsCacheKeyProvider : IApiClientDetailsCacheKeyProvider
{
    public const string CacheKeyFormat = "ApiClientDetails.{0}";

    private readonly ApiSettings _apiSettings;
    private readonly IInstanceIdContextProvider _instanceIdContextProvider;

    public ApiClientDetailsCacheKeyProvider(
        ApiSettings apiSettings,
        IInstanceIdContextProvider instanceIdContextProvider = null)
    {
        _apiSettings = apiSettings;
        _instanceIdContextProvider = instanceIdContextProvider;
    }

    /// <inheritdoc cref="IApiClientDetailsCacheKeyProvider.GetCacheKey" />
    public string GetCacheKey(string token)
    {
        string cacheKey;

        // NOTE: This abstraction could be further decomposed into separate implementations for the different ApiModes
        if (_apiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
        {
            const string InstanceCacheKeyFormat = "ApiClientDetails.{0}.{1}";
            var instanceId = _instanceIdContextProvider.GetInstanceId();

            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException("Expected instanceId is null or empty.");
            }

            cacheKey = string.Format(InstanceCacheKeyFormat, instanceId, token);
        }
        else
        {
            cacheKey = string.Format(CacheKeyFormat, token);
        }

        return cacheKey;
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using System.Threading.RateLimiting;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Security.Authentication;

/// <summary>
/// Applies <see cref="ApiSettings.TokenRateLimit"/> with in-memory fixed windows. When the setting is disabled, every
/// request is allowed.
/// </summary>
public sealed class TokenRequestRateLimiter : ITokenRequestRateLimiter, IDisposable
{
    private const string UnknownIpAddress = "unknown";

    private readonly bool _enabled;
    private readonly TimeSpan _window;
    private readonly PartitionedRateLimiter<string> _ipAddressLimiter;
    private readonly PartitionedRateLimiter<string> _clientIdLimiter;

    public TokenRequestRateLimiter(ApiSettings apiSettings)
    {
        var settings = apiSettings.TokenRateLimit ?? new TokenRateLimitSettings();

        _enabled = settings.Enabled;

        if (!_enabled)
        {
            return;
        }

        _window = TimeSpan.FromSeconds(settings.WindowSeconds);
        _ipAddressLimiter = CreateLimiter(settings.PermitsPerIpAddress, _window);
        _clientIdLimiter = CreateLimiter(settings.FailedAttemptsPerClientId, _window);
    }

    public bool TryAcquireForIpAddress(IPAddress ipAddress, out TimeSpan retryAfter)
    {
        retryAfter = TimeSpan.Zero;

        if (!_enabled)
        {
            return true;
        }

        return TryAcquire(_ipAddressLimiter, ipAddress?.ToString() ?? UnknownIpAddress, 1, out retryAfter);
    }

    public bool IsClientIdAllowed(string clientId, out TimeSpan retryAfter)
    {
        retryAfter = TimeSpan.Zero;

        if (!_enabled || clientId == null)
        {
            return true;
        }

        // Acquiring zero permits checks whether any are left without using one
        return TryAcquire(_clientIdLimiter, clientId, 0, out retryAfter);
    }

    public void RecordFailedAuthentication(string clientId)
    {
        if (!_enabled || clientId == null)
        {
            return;
        }

        using var lease = _clientIdLimiter.AttemptAcquire(clientId);
    }

    public void Dispose()
    {
        _ipAddressLimiter?.Dispose();
        _clientIdLimiter?.Dispose();
    }

    private bool TryAcquire(PartitionedRateLimiter<string> limiter, string key, int permits, out TimeSpan retryAfter)
    {
        using var lease = limiter.AttemptAcquire(key, permits);

        if (lease.IsAcquired)
        {
            retryAfter = TimeSpan.Zero;
            return true;
        }

        retryAfter = lease.TryGetMetadata(MetadataName.RetryAfter, out var leaseRetryAfter)
            ? leaseRetryAfter
            : _window;

        return false;
    }

    private static PartitionedRateLimiter<string> CreateLimiter(int permitLimit, TimeSpan window)
        => PartitionedRateLimiter.Create<string, string>(
            key => RateLimitPartition.GetFixedWindowLimiter(
                key,
                _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = permitLimit,
                    Window = window,
                    QueueLimit = 0,
                    AutoReplenishment = true
                }),
            StringComparer.Ordinal);
}

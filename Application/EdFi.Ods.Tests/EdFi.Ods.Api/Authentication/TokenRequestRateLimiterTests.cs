// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Authentication;

[TestFixture]
public class TokenRequestRateLimiterTests
{
    private static readonly IPAddress _ipAddress = IPAddress.Parse("192.0.2.10");
    private static readonly IPAddress _otherIpAddress = IPAddress.Parse("192.0.2.20");

    [Test]
    public void When_disabled_every_request_is_allowed()
    {
        using var limiter = new TokenRequestRateLimiter(new ApiSettings());

        for (int i = 0; i < 100; i++)
        {
            limiter.TryAcquireForIpAddress(_ipAddress, out _).ShouldBeTrue();
            limiter.RecordFailedAuthentication("clientId");
        }

        limiter.IsClientIdAllowed("clientId", out _).ShouldBeTrue();
    }

    [Test]
    public void Requests_from_an_IP_address_are_rejected_once_its_limit_is_reached()
    {
        using var limiter = CreateLimiter(permitsPerIpAddress: 3);

        for (int i = 0; i < 3; i++)
        {
            limiter.TryAcquireForIpAddress(_ipAddress, out _).ShouldBeTrue();
        }

        limiter.TryAcquireForIpAddress(_ipAddress, out var retryAfter).ShouldBeFalse();

        retryAfter.ShouldBeGreaterThan(TimeSpan.Zero);
        retryAfter.ShouldBeLessThanOrEqualTo(TimeSpan.FromSeconds(60));
    }

    [Test]
    public void Each_IP_address_has_its_own_limit()
    {
        using var limiter = CreateLimiter(permitsPerIpAddress: 1);

        limiter.TryAcquireForIpAddress(_ipAddress, out _).ShouldBeTrue();
        limiter.TryAcquireForIpAddress(_ipAddress, out _).ShouldBeFalse();

        limiter.TryAcquireForIpAddress(_otherIpAddress, out _).ShouldBeTrue();
    }

    [Test]
    public void Requests_without_a_known_IP_address_share_one_limit()
    {
        using var limiter = CreateLimiter(permitsPerIpAddress: 1);

        limiter.TryAcquireForIpAddress(null, out _).ShouldBeTrue();
        limiter.TryAcquireForIpAddress(null, out _).ShouldBeFalse();
    }

    [Test]
    public void Checking_a_client_id_does_not_count_as_an_attempt()
    {
        using var limiter = CreateLimiter(failedAttemptsPerClientId: 1);

        for (int i = 0; i < 10; i++)
        {
            limiter.IsClientIdAllowed("clientId", out _).ShouldBeTrue();
        }
    }

    [Test]
    public void A_client_id_is_rejected_once_its_failed_authentications_reach_the_limit()
    {
        using var limiter = CreateLimiter(failedAttemptsPerClientId: 2);

        limiter.RecordFailedAuthentication("clientId");
        limiter.IsClientIdAllowed("clientId", out _).ShouldBeTrue();

        limiter.RecordFailedAuthentication("clientId");
        limiter.IsClientIdAllowed("clientId", out var retryAfter).ShouldBeFalse();

        retryAfter.ShouldBeGreaterThan(TimeSpan.Zero);
    }

    [Test]
    public void Each_client_id_has_its_own_limit()
    {
        using var limiter = CreateLimiter(failedAttemptsPerClientId: 1);

        limiter.RecordFailedAuthentication("clientId");

        limiter.IsClientIdAllowed("clientId", out _).ShouldBeFalse();
        limiter.IsClientIdAllowed("otherClientId", out _).ShouldBeTrue();
        limiter.IsClientIdAllowed("CLIENTID", out _).ShouldBeTrue();
    }

    [Test]
    public void Requests_are_allowed_again_when_the_window_ends()
    {
        using var limiter = CreateLimiter(permitsPerIpAddress: 1, failedAttemptsPerClientId: 1, windowSeconds: 1);

        limiter.TryAcquireForIpAddress(_ipAddress, out _).ShouldBeTrue();
        limiter.TryAcquireForIpAddress(_ipAddress, out _).ShouldBeFalse();
        limiter.RecordFailedAuthentication("clientId");
        limiter.IsClientIdAllowed("clientId", out _).ShouldBeFalse();

        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2.5));

        limiter.TryAcquireForIpAddress(_ipAddress, out _).ShouldBeTrue();
        limiter.IsClientIdAllowed("clientId", out _).ShouldBeTrue();
    }

    private static TokenRequestRateLimiter CreateLimiter(
        int permitsPerIpAddress = 30,
        int failedAttemptsPerClientId = 10,
        int windowSeconds = 60)
        => new(
            new ApiSettings
            {
                TokenRateLimit = new TokenRateLimitSettings
                {
                    Enabled = true,
                    PermitsPerIpAddress = permitsPerIpAddress,
                    FailedAttemptsPerClientId = failedAttemptsPerClientId,
                    WindowSeconds = windowSeconds
                }
            });
}

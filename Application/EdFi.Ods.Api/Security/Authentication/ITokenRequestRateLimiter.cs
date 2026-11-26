// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;

namespace EdFi.Ods.Api.Security.Authentication;

/// <summary>
/// Limits the requests to the token endpoint per client IP address and the failed client authentications per client_id.
/// </summary>
public interface ITokenRequestRateLimiter
{
    /// <summary>
    /// Counts a token request from the IP address, and reports whether it is within the limit.
    /// </summary>
    /// <param name="ipAddress">The client's IP address, or <b>null</b> when it isn't known.</param>
    /// <param name="retryAfter">When the limit is exceeded, how long the client should wait.</param>
    bool TryAcquireForIpAddress(IPAddress ipAddress, out TimeSpan retryAfter);

    /// <summary>
    /// Reports whether the client_id may still attempt to authenticate, without counting the attempt.
    /// </summary>
    /// <param name="clientId">The client_id presented in the token request.</param>
    /// <param name="retryAfter">When the limit is exceeded, how long the client should wait.</param>
    bool IsClientIdAllowed(string clientId, out TimeSpan retryAfter);

    /// <summary>
    /// Counts a failed client authentication for the client_id.
    /// </summary>
    void RecordFailedAuthentication(string clientId);
}

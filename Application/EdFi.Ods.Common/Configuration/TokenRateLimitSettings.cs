// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration;

/// <summary>
/// Limits the requests to the token endpoint (oauth/token), so that client secrets can't be guessed at the rate the
/// server sustains and the cost of hashing each presented secret can't be used to exhaust the server's CPU.
/// Disabled by default.
/// </summary>
/// <remarks>
/// The limits use fixed time windows and are kept in memory, so each API instance counts its own requests. A client
/// that exceeds a limit gets a 429 Too Many Requests response with a Retry-After header until the window ends; there
/// is no lockout. The client IP address is the connection's remote address, or the forwarded one when
/// <see cref="ApiSettings.UseReverseProxyHeaders"/> is enabled; configure <see cref="ApiSettings.KnownProxies"/> or
/// <see cref="ApiSettings.KnownNetworks"/> so that clients can't choose their own address.
/// </remarks>
public class TokenRateLimitSettings
{
    public bool Enabled { get; set; }

    /// <summary>
    /// The number of token requests accepted from one client IP address in each window.
    /// </summary>
    public int PermitsPerIpAddress { get; set; } = 30;

    /// <summary>
    /// The number of failed client authentications accepted for one client_id in each window. Once reached, further
    /// requests for that client_id are rejected until the window ends, even with the right secret. Successful requests
    /// don't count.
    /// </summary>
    public int FailedAttemptsPerClientId { get; set; } = 10;

    /// <summary>
    /// The length of each window, in seconds.
    /// </summary>
    public int WindowSeconds { get; set; } = 60;
}

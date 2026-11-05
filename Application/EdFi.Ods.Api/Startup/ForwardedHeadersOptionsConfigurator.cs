// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Startup;

/// <summary>
/// Configures the ASP.NET Core forwarded headers middleware used when <see cref="ApiSettings.UseReverseProxyHeaders"/>
/// is enabled.
/// </summary>
public class ForwardedHeadersOptionsConfigurator : IConfigureOptions<ForwardedHeadersOptions>
{
    private readonly ApiSettings _apiSettings;

    public ForwardedHeadersOptionsConfigurator(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings;
    }

    public void Configure(ForwardedHeadersOptions options)
    {
        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor
                                   | ForwardedHeaders.XForwardedHost
                                   | ForwardedHeaders.XForwardedProto;

        // Walk the whole chain of forwarded values so the first (client-facing) value is used when a request passes
        // through several proxies (see ODS-5481). When known proxies/networks are configured, processing still stops
        // at the first hop that is not trusted.
        options.ForwardLimit = null;

        // The middleware trusts only loopback proxies by default, which would ignore the headers in containerized
        // deployments. Unless known proxies/networks are configured, accept the headers from any proxy.
        options.KnownProxies.Clear();
        options.KnownIPNetworks.Clear();

        foreach (string knownProxy in _apiSettings.KnownProxies)
        {
            if (!IPAddress.TryParse(knownProxy, out var address))
            {
                throw new InvalidOperationException(
                    $"Invalid IP address '{knownProxy}' in ApiSettings:{nameof(ApiSettings.KnownProxies)}.");
            }

            options.KnownProxies.Add(address);
        }

        foreach (string knownNetwork in _apiSettings.KnownNetworks)
        {
            if (!System.Net.IPNetwork.TryParse(knownNetwork, out var network))
            {
                throw new InvalidOperationException(
                    $"Invalid network '{knownNetwork}' in ApiSettings:{nameof(ApiSettings.KnownNetworks)}. Use CIDR notation, for example '10.0.0.0/8'.");
            }

            options.KnownIPNetworks.Add(network);
        }
    }
}

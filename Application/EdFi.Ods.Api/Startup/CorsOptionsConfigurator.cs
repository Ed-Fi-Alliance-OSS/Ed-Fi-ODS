// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Startup;

/// <summary>
/// Configures the CORS policy applied to the API.
/// </summary>
/// <remarks>
/// When <see cref="ApiSettings.CorsAllowedOrigins"/> is empty, any origin may call the API. This keeps the
/// behavior of earlier releases (e.g. Swagger UI hosted on a different origin than the API). When origins are
/// configured, only those origins are allowed.
/// </remarks>
public class CorsOptionsConfigurator : IConfigureOptions<CorsOptions>
{
    public const string PolicyName = "EdFiOdsApiCorsPolicy";

    private readonly ApiSettings _apiSettings;

    public CorsOptionsConfigurator(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings;
    }

    /// <summary>
    /// Indicates whether the API accepts cross-origin requests from any origin (no allowed origins configured).
    /// </summary>
    public bool AllowsAnyOrigin => GetAllowedOrigins().Length == 0;

    public void Configure(CorsOptions options)
    {
        string[] allowedOrigins = GetAllowedOrigins();

        options.AddPolicy(
            PolicyName,
            builder =>
            {
                if (allowedOrigins.Length == 0)
                {
                    builder.AllowAnyOrigin();
                }
                else
                {
                    builder.WithOrigins(allowedOrigins);
                }

                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("*");
            });
    }

    private string[] GetAllowedOrigins()
    {
        return (_apiSettings.CorsAllowedOrigins ?? new())
            .Where(origin => !string.IsNullOrWhiteSpace(origin))
            .Select(NormalizeOrigin)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }

    private static string NormalizeOrigin(string origin)
    {
        string trimmedOrigin = origin.Trim().TrimEnd('/');

        // A browser sends the Origin header as scheme://host[:port], and the CORS middleware compares it with the
        // configured origins as a string, so anything else would never match.
        if (!Uri.TryCreate(trimmedOrigin, UriKind.Absolute, out var uri)
            || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
            || uri.AbsolutePath != "/"
            || !string.IsNullOrEmpty(uri.Query)
            || !string.IsNullOrEmpty(uri.Fragment)
            || !string.IsNullOrEmpty(uri.UserInfo))
        {
            throw new InvalidOperationException(
                $"Invalid origin '{origin}' in ApiSettings:{nameof(ApiSettings.CorsAllowedOrigins)}. Use the form 'https://host[:port]' with no path, or leave the setting empty to allow any origin.");
        }

        // Return the canonical form a browser sends, e.g. "https://host:443" becomes "https://host"
        return uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped);
    }
}

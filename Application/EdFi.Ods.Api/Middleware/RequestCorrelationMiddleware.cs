// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Globalization;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Implements middleware that inspects the request and captures a correlation identifier supplied in an HTTP header or query
/// string parameter (in that order of precedence). A supplied value that is empty, longer than
/// <see cref="MaxCorrelationIdLength" /> characters or contains control or line separator characters is replaced with a new
/// GUID, because the value is written to the logs and returned to the caller.
/// </summary>
public class RequestCorrelationMiddleware(ILogContextAccessor logContextAccessor, ApiSettings apiSettings) : IMiddleware
{
    public const int MaxCorrelationIdLength = 64;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string correlationId = null;

        // Capture correlation from the header, if present
        if (context.Request.Headers.TryGetValue(string.IsNullOrEmpty(apiSettings.OdsCorrelationIdHttpHeaderName) ? CorrelationConstants.HttpHeader : apiSettings.OdsCorrelationIdHttpHeaderName, out var headerValues))
        {
            correlationId = headerValues[0];
        }
        // Capture correlation from the query string, if present
        else if (context.Request.Query.TryGetValue(CorrelationConstants.QueryString, out var queryStringValues))
        {
            correlationId = queryStringValues[0];
        }

        logContextAccessor.SetCorrelationId(IsValidCorrelationId(correlationId) ? correlationId : Guid.NewGuid().ToString());

        await next(context);
    }

    private static bool IsValidCorrelationId(string correlationId)
    {
        if (string.IsNullOrWhiteSpace(correlationId) || correlationId.Length > MaxCorrelationIdLength)
        {
            return false;
        }

        foreach (char c in correlationId)
        {
            if (char.IsControl(c)
                || char.GetUnicodeCategory(c) is UnicodeCategory.LineSeparator or UnicodeCategory.ParagraphSeparator)
            {
                return false;
            }
        }

        return true;
    }
}
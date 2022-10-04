// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Utils.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace EdFi.Ods.Api.Middleware;

// SPIKE NOTE: Needs unit tests!

/// <summary>
/// Implements middleware that inspects the content type of a request (Accept for GET request, Content-Type for PUT/POST requests),
/// and initializes the <see cref="ProfileContentTypeContext" /> for the current request.
/// </summary>
public class ProfileContentTypeContextMiddleware
{
    private readonly RequestDelegate _next;

    private const string ProfileContentTypePrefix = "application/vnd.ed-fi.";

    private const int ResourceNameFacet = 0;
    private const int ProfileNameFacet = 1;
    private const int UsageFacet = 2;
        
    public ProfileContentTypeContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
    {
        if (context.Request.Method == HttpMethods.Get)
        {
            // Only process profile content types in the Accept header
            var profileContentType =
                context.Request.Headers.Accept.FirstOrDefault(ct => ct.StartsWith(ProfileContentTypePrefix));
                
            if (profileContentType != null)
            {
                ProcessProfileContentType("Accept", profileContentType);
            }
        }
        else if (context.Request.Method == HttpMethods.Post || context.Request.Method == HttpMethods.Put)
        {
            // Only process profile content types
            string profileContentType = context.Request.ContentType;

            if (profileContentType?.StartsWith(ProfileContentTypePrefix) ?? false)
            {
                ProcessProfileContentType("Content-Type", profileContentType);
            }
        }

        await _next(context);

        void ProcessProfileContentType(string headerName, string contentType)
        {
            // e.g. application/vnd.ed-fi.student.test-profile.readable+json
            if (MediaTypeHeaderValue.TryParse(contentType, out var mt))
            {
                // Skip known existing segments for "vnd.ed-fi", and retrieve just the resource name, profile name and usage
                var profileContentTypeFacets = mt.Facets.Skip(2).ToArray();

                if (profileContentTypeFacets.Length != 3)
                {
                    throw new BadRequestException($"The format of the profile-based '{headerName}' header was invalid.");
                }

                profileContentTypeContextProvider.Set(
                    new ProfileContentTypeContext(
                        profileContentTypeFacets[ProfileNameFacet].Value,
                        profileContentTypeFacets[ResourceNameFacet].Value,
                        GetContentTypeUsage(headerName, profileContentTypeFacets[UsageFacet])));
            }
        }

        ContentTypeUsage GetContentTypeUsage(string headerName, StringSegment profileContentTypeFacet)
        {
            var usageSegment = profileContentTypeFacet;

            if (usageSegment.Equals("readable", StringComparison.OrdinalIgnoreCase))
            {
                return ContentTypeUsage.Readable;
            }
            else if (usageSegment.Equals("writable", StringComparison.OrdinalIgnoreCase))
            {
                return ContentTypeUsage.Writable;
            }
   
            throw new BadRequestException($"The profile usage segment in the profile-based '{headerName}' header was not recognized.");
        }
    }
}

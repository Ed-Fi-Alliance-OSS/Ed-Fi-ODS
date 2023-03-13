// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Utils.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace EdFi.Ods.Api.Middleware
{
    /// <summary>
    /// Implements middleware that inspects the content type of a request (Accept for GET request, Content-Type for PUT/POST requests),
    /// and initializes the <see cref="ProfileContentTypeContext" /> for the current request.
    /// </summary>
    public class ProfileContentTypeContextMiddleware
    {
        private const string ProfileContentTypePrefix = "application/vnd.ed-fi.";

        private const string InvalidContentTypeHeaderFormat = "The format of the profile-based '{0}' header was invalid.";
        private const string InvalidUsageTypeFormat =
            "The profile usage segment in the profile-based '{0}' header was not recognized.";
        private const string NonExistingProfileFormat =
            "The profile specified by the content type in the '{0}' header is not supported by this host.";

        private const int ResourceNameFacet = 0;
        private const int ProfileNameFacet = 1;
        private const int UsageFacet = 2;
        private readonly RequestDelegate _next;
        private readonly IProfileMetadataProvider _profileMetadataProvider;

        public ProfileContentTypeContextMiddleware(RequestDelegate next, IProfileMetadataProvider profileMetadataProvider)
        {
            _next = next;
            _profileMetadataProvider = profileMetadataProvider;
        }

        public async Task InvokeAsync(
            HttpContext context,
            IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
        {
            if (context.Request.Method == HttpMethods.Get)
            {
                // Only process profile content types in the Accept header
                var profileContentType = context.Request.Headers[HeaderNames.Accept]
                    .FirstOrDefault(ct => ct.StartsWith(ProfileContentTypePrefix));
                    
                if (profileContentType != null)
                {
                    var (continueInvocation, profileContentTypeContext) = await TryProcessProfileContentTypeAsync(
                        "Accept",
                        profileContentType,
                        context.Response,
                        context.Request);

                    if (!continueInvocation)
                    {
                        return;
                    }

                    profileContentTypeContextProvider.Set(profileContentTypeContext);
                }
            }
            else if (context.Request.Method == HttpMethods.Post || context.Request.Method == HttpMethods.Put)
            {
                // Only process profile content types
                string profileContentType = context.Request.ContentType;

                if (profileContentType?.StartsWith(ProfileContentTypePrefix) ?? false)
                {
                    var (continueInvocation, profileContentTypeContext) = await TryProcessProfileContentTypeAsync(
                        "Content-Type",
                        profileContentType,
                        context.Response,
                        context.Request);

                    if (!continueInvocation)
                    {
                        return;
                    }

                    profileContentTypeContextProvider.Set(profileContentTypeContext);
                }
            }

            await _next(context);

            async Task<(bool ignored, ProfileContentTypeContext profileContentTypeContext)> TryProcessProfileContentTypeAsync(
                string headerName,
                string contentType,
                HttpResponse response,
                HttpRequest request)
            {
                // e.g. application/vnd.ed-fi.student.test-profile.readable+json
                if (MediaTypeHeaderValue.TryParse(contentType, out var mt))
                {
                    // Skip known existing segments for "vnd.ed-fi", and retrieve just the resource name, profile name and usage
                    var profileContentTypeFacets = mt.Facets.Skip(2).ToArray();

                    if (profileContentTypeFacets.Length != 3)
                    {
                        await WriteResponse(
                            response,
                            StatusCodes.Status400BadRequest,
                            headerName,
                            InvalidContentTypeHeaderFormat);

                        return (false, null);
                    }

                    if (!TryGetContentTypeUsage(profileContentTypeFacets[UsageFacet], out var contentTypeUsage))
                    {
                        await WriteResponse(response, StatusCodes.Status400BadRequest, headerName, InvalidUsageTypeFormat);

                        return (false, null);
                    }

                    // Validate that the usage type matches the request method
                    if (contentTypeUsage == ContentTypeUsage.Writable && request.Method == HttpMethods.Get)
                    {
                        await WriteResponse(
                            response,
                            StatusCodes.Status400BadRequest,
                            headerName,
                            $"A profile-based content type that is writable cannot be used with GET requests.");

                        return (false, null);
                    }

                    if (contentTypeUsage == ContentTypeUsage.Readable
                        && (request.Method == HttpMethods.Post || request.Method == HttpMethods.Put))
                    {
                        await WriteResponse(
                            response,
                            StatusCodes.Status400BadRequest,
                            headerName,
                            $"A profile-based content type that is readable cannot be used with PUT or POST requests.");

                        return (false, null);
                    }

                    // Validate that the Profile exists
                    string profileName = profileContentTypeFacets[ProfileNameFacet].Value;

                    if (!_profileMetadataProvider.ProfileDefinitionsByName.ContainsKey(profileName))
                    {
                        await WriteResponse(
                            response,
                            request.Method == HttpMethods.Get
                                ? StatusCodes.Status406NotAcceptable
                                : StatusCodes.Status415UnsupportedMediaType,
                            headerName,
                            NonExistingProfileFormat);

                        return (false, null);
                    }

                    var profileContentTypeContext = new ProfileContentTypeContext(
                        profileName,
                        profileContentTypeFacets[ResourceNameFacet].Value,
                        contentTypeUsage);

                    return (true, profileContentTypeContext);
                }

                return (true, null);
            }

            async Task WriteResponse(HttpResponse httpResponse, int statusCode, string headerName, string messageFormat)
            {
                httpResponse.StatusCode = statusCode;
                httpResponse.ContentType = "application/json";

                await using (var sw = new StreamWriter(httpResponse.Body))
                {
                    string json = JsonConvert.SerializeObject(new { message = string.Format(messageFormat, headerName) });
                    httpResponse.Headers.ContentLength = json.Length;
                    await sw.WriteAsync(json);
                }
            }

            bool TryGetContentTypeUsage(StringSegment profileContentTypeFacet, out ContentTypeUsage contentTypeUsage)
            {
                var usageSegment = profileContentTypeFacet;

                if (usageSegment.Equals("readable", StringComparison.OrdinalIgnoreCase))
                {
                    contentTypeUsage = ContentTypeUsage.Readable;

                    return true;
                }

                if (usageSegment.Equals("writable", StringComparison.OrdinalIgnoreCase))
                {
                    contentTypeUsage = ContentTypeUsage.Writable;

                    return true;
                }

                contentTypeUsage = default;

                return false;
            }
        }
    }
}

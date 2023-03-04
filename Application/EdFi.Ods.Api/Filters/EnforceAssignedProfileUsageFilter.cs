// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Utils.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace EdFi.Ods.Api.Filters
{
    public class EnforceAssignedProfileUsageFilter : IAsyncActionFilter
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
        private readonly IContextProvider<ProfileContentTypeContext> _profileContentTypeContextProvider;
        private readonly IProfileResourceModelProvider _profileResourceModelProvider;
        private readonly IProfileMetadataProvider _profileMetadataProvider;

        private readonly bool _isEnabled;

        public EnforceAssignedProfileUsageFilter(
            IApiKeyContextProvider apiKeyContextProvider,
            IProfileResourceModelProvider profileResourceModelProvider,
            IProfileMetadataProvider profileMetadataProvider,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider,
            ApiSettings apiSettings)
        {
            _apiKeyContextProvider = apiKeyContextProvider;
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
            _profileContentTypeContextProvider = profileContentTypeContextProvider;
            _profileResourceModelProvider = profileResourceModelProvider;
            _profileMetadataProvider = profileMetadataProvider;

            _isEnabled = apiSettings.IsFeatureEnabled("Profiles");
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // If Profiles feature is not enabled, don't do any processing.
            if (!_isEnabled)
            {
                await next();

                return;
            }

            var apiKeyContext = _apiKeyContextProvider.GetApiKeyContext();

            // No authorized client? Skip additional processing here now.
            if (apiKeyContext == null)
            {
                await next();

                return;
            }

            // // No profiles assigned? Skip additional processing here now.
            // if (!apiKeyContext.Profiles.Any())
            // {
            //     await next();
            //
            //     return;
            // }

            // Determine the relevant content type usage for the current request (readable or writable)
            var relevantContentTypeUsage = context.HttpContext.Request.Method == HttpMethods.Get
                ? ContentTypeUsage.Readable
                : ContentTypeUsage.Writable;

            var dataManagementResourceContext = _dataManagementResourceContextProvider.Get();

            if (dataManagementResourceContext == null)
            {
                await next();

                return;
            }
            
            var resourceFullName = dataManagementResourceContext.Resource.FullName;

            // var assignedProfilesForRequest = apiKeyContext.Profiles.Where(
            //         p => _profileResourceModelProvider.GetProfileResourceModel(p)
            //                 .ResourceByName.TryGetValue(resourceFullName, out var contentTypes)
            //             && (relevantContentTypeUsage == ContentTypeUsage.Readable
            //                 ? contentTypes.Readable
            //                 : contentTypes.Writable)
            //             != null)
            //     .ToArray();
            //
            // // If there are no assigned profiles relevant for this request, skip additional processing here now.
            // if (assignedProfilesForRequest.Length == 0)
            // {
            //     await next();
            //
            //     return;
            // }

            var profileContentTypeContext = _profileContentTypeContextProvider.Get();

            if (profileContentTypeContext != null)
            {
                // Validate that the resource in the request matches the resource in the associated content type
                if (!dataManagementResourceContext.Resource.Name.EqualsIgnoreCase(profileContentTypeContext.ResourceName))
                {
                    await WriteErrorResponse(
                        StatusCodes.Status400BadRequest,
                        "The resource in the profile-based content type does not match the resource targeted by the request.");

                    return;
                }

                // Validate that the resource in the request is covered by the Profile from the content type 
                if (_profileMetadataProvider.ProfileDefinitionsByName.ContainsKey(profileContentTypeContext.ProfileName))
                {
                    var profileResourceModel = _profileResourceModelProvider.GetProfileResourceModel(profileContentTypeContext.ProfileName);

                    if (!profileResourceModel.ResourceByName.TryGetValue(resourceFullName, out var contentTypes)
                        || (relevantContentTypeUsage == ContentTypeUsage.Readable ? contentTypes.Readable : contentTypes.Writable) == null)
                    {
                        string errorMessage = $"The '{dataManagementResourceContext.Resource.Name}' resource is not accessible through the '{profileContentTypeContext.ProfileName}' profile specified by the content type.";
                        await WriteErrorResponse(StatusCodes.Status400BadRequest, errorMessage);

                        return;
                    }
                }
            }

            var assignedProfilesForRequest = apiKeyContext.Profiles.Where(
                    p => _profileResourceModelProvider.GetProfileResourceModel(p)
                            .ResourceByName.TryGetValue(resourceFullName, out var contentTypes)
                        && (relevantContentTypeUsage == ContentTypeUsage.Readable
                            ? contentTypes.Readable
                            : contentTypes.Writable)
                        != null)
                .ToArray();

            // If there are no assigned profiles relevant for this request, skip additional processing here now.
            if (assignedProfilesForRequest.Length == 0)
            {
                await next();

                return;
            }

            // No profile content type specified in the request header?
            if (profileContentTypeContext == null)
            {
                // -------------------------------------------------------------------------------------------------------------------
                // NOTE: Auto-assign the content type usage if none specified by client, and exactly one relevant profile is assigned
                // -------------------------------------------------------------------------------------------------------------------
                // // If there's only one Profile that can be applied, automatically apply it and continue processing
                // if (assignedProfilesForRequest.Length == 1)
                // {
                //     // Auto-assign the appropriate profile usage
                //     _profileContentTypeContextProvider.Set(
                //         new ProfileContentTypeContext(
                //             assignedProfilesForRequest.Single(),
                //             resourceFullName.Name,
                //             relevantContentTypeUsage));
                //
                //     await next();
                //     return;
                // }
                // -------------------------------------------------------------------------------------------------------------------

                // If there's more than one possible Profile, the client is required to specify which one is in use.
                await WriteForbiddenResponse();

                return;
            }

            // Ensure that the specified profile content type is using one of the assigned Profiles
            if (!assignedProfilesForRequest.Contains(profileContentTypeContext.ProfileName, StringComparer.OrdinalIgnoreCase))
            {
                await WriteForbiddenResponse();

                return;
            }

            await next();

            async Task WriteForbiddenResponse()
            {
                string errorMessage = relevantContentTypeUsage == ContentTypeUsage.Readable
                    ? $"Based on profile assignments, one of the following profile-specific content types is required when requesting this resource: '{string.Join("', '", assignedProfilesForRequest.OrderBy(a => a).Select(p => ProfilesContentTypeHelper.CreateContentType(resourceFullName.Name, p, relevantContentTypeUsage)))}'"
                    : $"Based on profile assignments, one of the following profile-specific content types is required when updating this resource: '{string.Join("', '", assignedProfilesForRequest.OrderBy(a => a).Select(p => ProfilesContentTypeHelper.CreateContentType(resourceFullName.Name, p, relevantContentTypeUsage)))}'";

                await WriteErrorResponse(StatusCodes.Status403Forbidden, errorMessage);
            }

            async Task WriteErrorResponse(int statusCode, string errorMessage)
            {
                var response = context.HttpContext.Response;

                response.StatusCode = statusCode;
                response.Headers[HeaderNames.ContentType] = new StringValues(MediaTypeNames.Application.Json);

                await using (var sw = new StreamWriter(response.Body))
                {
                    string json = JsonConvert.SerializeObject(new { message = errorMessage });
                    response.Headers.ContentLength = json.Length;
                    await sw.WriteAsync(json);
                }
            }
        }
    }
}


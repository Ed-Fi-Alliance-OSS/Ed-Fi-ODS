// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Utils.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace EdFi.Ods.Api.Filters;

public class EnforceAssignedProfileUsageAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // ------------------------------------------------------------------------------------------------------------------------
        // NOTE: If we want to determine whether Profiles feature is enabled, we'll need access to the ApiSettings statically
        // or we'll need to convert the attribute to be instance-based rather than type-based (on a high-throughput part of the system)
        // ------------------------------------------------------------------------------------------------------------------------
        // var apiSettings = GeneratedArtifactStaticDependencies.ApiSettings().Get();
        //
        // if (!apiSettings.IsFeatureEnabled("Profiles")) // ProfilesConstants.FeatureName
        // {
        //     await next();
        //     return;
        // }
        // ------------------------------------------------------------------------------------------------------------------------

        var apiKeyContext = GeneratedArtifactStaticDependencies.ApiKeyContextProvider.GetApiKeyContext();

        // No authorized client? Skip additional processing here now.
        if (apiKeyContext == null)
        {
            await next();

            return;
        }

        // No profiles assigned? Skip additional processing here now.
        if (apiKeyContext.Profiles.Count == 0)
        {
            await next();

            return;
        }

        // Determine the relevant content type usage for the current request (readable or writable)
        var relevantContentTypeUsage = context.HttpContext.Request.Method == HttpMethods.Get
            ? ContentTypeUsage.Readable
            : ContentTypeUsage.Writable;

        var resourceFullName = GeneratedArtifactStaticDependencies.DataManagementResourceContextProvider.Get().Resource.FullName;

        var assignedProfilesForRequest = apiKeyContext.Profiles.Where(
                p => GeneratedArtifactStaticDependencies.ProfileResourceModelProvider.GetProfileResourceModel(p)
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

        var profileContentTypeContext = GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get();

        // No profile content type specified in the request header?
        if (profileContentTypeContext == null)
        {
            // -------------------------------------------------------------------------------------------------------------------
            // NOTE: Auto-assign the content type usage if none specified by client, and exactly one relevant profile is assigned
            // -------------------------------------------------------------------------------------------------------------------
            // // If there's only one Profile that can be applied, automatically apply it and continue processing
            // if (allowedProfilesForRequest.Length == 1)
            // {
            //     // Auto-assign the appropriate profile usage
            //     _profileContentTypeContextProvider.Set(
            //         new ProfileContentTypeContext(
            //             allowedProfilesForRequest.Single(),
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
                ? $"Based on profile assignments, one of the following profile-specific content types is required when requesting this resource: '{string.Join("', '", assignedProfilesForRequest.Select(p => ProfilesContentTypeHelper.CreateContentType(resourceFullName.Name, p, relevantContentTypeUsage)))}'"
                : $"Based on profile assignments, one of the following profile-specific content types is required when updating this resource: '{string.Join("', '", assignedProfilesForRequest.Select(p => ProfilesContentTypeHelper.CreateContentType(resourceFullName.Name, p, relevantContentTypeUsage)))}'";

            var response = context.HttpContext.Response;

            response.StatusCode = StatusCodes.Status403Forbidden;
            response.Headers.ContentType = new StringValues(MediaTypeNames.Application.Json);

            await using (var sw = new StreamWriter(response.Body))
            {
                string json = JsonConvert.SerializeObject(new { message = errorMessage });
                response.Headers.ContentLength = json.Length;
                await sw.WriteAsync(json);
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Utils.Profiles;

namespace EdFi.Ods.Api.Services.Filters
{
    public class ProfilesAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IProfileResourceNamesProvider _profileResourceNamesProvider;

        public ProfilesAuthorizationFilter(IApiKeyContextProvider apiKeyContextProvider, IProfileResourceNamesProvider profileResourceNamesProvider)
        {
            _apiKeyContextProvider = apiKeyContextProvider;
            _profileResourceNamesProvider = profileResourceNamesProvider;
        }

        public bool AllowMultiple
        {
            get { return false; }
        }

        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            // check if the http method sent needs to be checked by this filter
            if (!(actionContext.Request.Method == HttpMethod.Put ||
                  actionContext.Request.Method == HttpMethod.Post ||
                  actionContext.Request.Method == HttpMethod.Get))
            {
                return continuation();
            }

            // Try to get the current API key context
            var assignedProfiles = new List<string>();
            var apiKeyContext = _apiKeyContextProvider.GetApiKeyContext();

            // check that the ApiKeyContext is available so that we can get the assigned profiles
            if (apiKeyContext != null && apiKeyContext != ApiKeyContext.Empty)
            {
                assignedProfiles = _apiKeyContextProvider.GetApiKeyContext()
                                                         .Profiles.ToList();
            }

            // declare profile content type variable because it can be retrieved from the 
            // accept header or the content-type header
            string profileContentType = null;
            ProfileContentTypeDetails profileContentTypeDetails = null;

            // get singluar spelling of the controller name for comparison to the resource in the profiles
            string resourceCollectionName =
                actionContext.ControllerContext.ControllerDescriptor.ControllerName.TrimSuffix("Controller");

            string resourceItemName = CompositeTermInflector.MakeSingular(resourceCollectionName);

            // try to get the Profile Content type and parse if successful
            if (TryGetProfileContentType(actionContext, out profileContentType))
            {
                profileContentTypeDetails = profileContentType.GetContentTypeDetails();
            }

            // If the caller has not specified a profile specific content type and there are no assigned 
            // profiles then allow the request to be processed (there is nothing left to check)
            if (string.IsNullOrEmpty(profileContentType) && !assignedProfiles.Any())
            {
                return continuation();
            }

            // If the caller has not specified a profile specific content type but the targeted 
            // resource is covered by an assigned profile then we must refuse the request
            if (string.IsNullOrEmpty(profileContentType)
                && IsResourceCoveredByAssignedProfile(assignedProfiles, resourceItemName))
            {
                if (actionContext.Request.Method == HttpMethod.Get)
                {
                    return
                        Task.FromResult(
                            ForbiddenHttpResponseMessage(
                                actionContext,
                                string.Format(
                                    "One of the following profile-specific content types is required when requesting this resource: '{0}'.",
                                    string.Join(
                                        "', '",
                                        assignedProfiles.Select(
                                            p => ProfilesContentTypeHelper.CreateContentType(
                                                resourceCollectionName,
                                                p,
                                                ContentTypeUsage.Readable))))));
                }

                // PUT or POST
                return
                    Task.FromResult(
                        ForbiddenHttpResponseMessage(
                            actionContext,
                            string.Format(
                                "Based on the assigned profiles, one of the following profile-specific content types is required when updating this resource: '{0}'.",
                                string.Join(
                                    "', '",
                                    assignedProfiles.Select(
                                        p => ProfilesContentTypeHelper.CreateContentType(resourceCollectionName, p, ContentTypeUsage.Writable))))));
            }

            // if there is no profile specific content at this point there are no more checks to make so proceed with request processing
            if (string.IsNullOrEmpty(profileContentType))
            {
                return continuation();
            }

            // If the caller is "opting in" to a profile, and the targeted resource exists in the specified profile, proceed with request processing
            if (!assignedProfiles.Any()
                && IsTheResourceInTheProfile(resourceItemName, profileContentTypeDetails.Profile))
            {
                return continuation();
            }

            // If the caller is not assigned any profiles that cover the targeted resource, then proceed with request processing.
            if (!AnyAssignedProfilesCoverTheResource(assignedProfiles, resourceItemName))
            {
                return continuation();
            }

            // Check if the resource is covered under an assigned profile that is not the profile content type sent
            if (!IsResourceCoveredByAnotherAssignedProfile(assignedProfiles, resourceItemName, profileContentTypeDetails.Profile))
            {
                // create the response based on the method
                if (actionContext.Request.Method == HttpMethod.Get)
                {
                    return Task.FromResult(
                        ForbiddenHttpResponseMessage(
                            actionContext,
                            string.Format(
                                "One of the following profile-specific content types is required when requesting this resource: '{0}'.",
                                string.Join(
                                    "', '",
                                    GetApplicableContentTypes(
                                        assignedProfiles,
                                        resourceCollectionName,
                                        resourceItemName,
                                        actionContext.Request.Method)))));
                }

                if (actionContext.Request.Method == HttpMethod.Put || actionContext.Request.Method == HttpMethod.Post)
                {
                    return Task.FromResult(
                        ForbiddenHttpResponseMessage(
                            actionContext,
                            string.Format(
                                "Based on the assigned profiles, one of the following profile-specific content types is required when updating this resource: '{0}'.",
                                string.Join(
                                    "', '",
                                    GetApplicableContentTypes(
                                        assignedProfiles,
                                        resourceCollectionName,
                                        resourceItemName,
                                        actionContext.Request.Method)))));
                }
            }

            return continuation();
        }

        //Returns true if there are any assigned profiles that cover the resource and profile sent as paramenters
        private bool IsResourceCoveredByAnotherAssignedProfile(
            List<string> assignedProfiles,
            string resourceItemName,
            string profileContentTypeProfileName)
        {
            return
                assignedProfiles.Intersect(
                                     _profileResourceNamesProvider.GetProfileResourceNames()
                                                                  .Where(
                                                                       x => x.ResourceName.EqualsIgnoreCase(resourceItemName)
                                                                            && x.ProfileName.EqualsIgnoreCase(profileContentTypeProfileName))
                                                                  .Select(x => x.ProfileName))
                                .Any();
        }

        private bool IsResourceCoveredByAssignedProfile(IList<string> assignedProfiles, string resourceItemName)
        {
            // is the resource items name sent in covered by an assigned profile?
            return assignedProfiles.Intersect(
                                        _profileResourceNamesProvider.GetProfileResourceNames()
                                                                     .Where(x => x.ResourceName.EqualsIgnoreCase(resourceItemName))
                                                                     .Select(z => z.ProfileName))
                                   .Any();
        }

        private bool AnyAssignedProfilesCoverTheResource(List<string> assignedProfiles, string resourceItemName)
        {
            // Determines if there is an assigned profile that covers the sent in resourceItemName
            return assignedProfiles
                  .Intersect(
                       _profileResourceNamesProvider
                          .GetProfileResourceNames()
                          .Where(x => x.ResourceName.EqualsIgnoreCase(resourceItemName))
                          .Select(x => x.ProfileName))
                  .Any();
        }

        private bool IsTheResourceInTheProfile(string resourceItemName, string profileContentTypeProfile)
        {
            // Determines if the sent in resource is in the profile.
            return _profileResourceNamesProvider.GetProfileResourceNames()
                                                .Any(
                                                     x => x.ProfileName.EqualsIgnoreCase(profileContentTypeProfile)
                                                          && x.ResourceName.EqualsIgnoreCase(resourceItemName));
        }

        // Generates a list of assigned profiles that can be used by the client for the sent resource 
        private IEnumerable<string> GetApplicableContentTypes(
            IEnumerable<string> assignedProfiles,
            string resourceCollectionName,
            string resourceItemName,
            HttpMethod httpMethod)
        {
            ContentTypeUsage contentTypeUsage = httpMethod == HttpMethod.Get
                ? ContentTypeUsage.Readable
                : ContentTypeUsage.Writable;

            var assignedContentTypes = assignedProfiles
               .Select(x => ProfilesContentTypeHelper.CreateContentType(resourceCollectionName, x, contentTypeUsage));

            return assignedContentTypes
                  .Intersect(
                       _profileResourceNamesProvider.GetProfileResourceNames()
                                                    .Where(x => x.ResourceName.EqualsIgnoreCase(resourceItemName))
                                                    .Select(
                                                         x => ProfilesContentTypeHelper.CreateContentType(
                                                             CompositeTermInflector.MakePlural(x.ResourceName),
                                                             x.ProfileName,
                                                             contentTypeUsage)))
                  .ToList();
        }

        private bool TryGetProfileContentType(HttpActionContext actionContext, out string profileContentType)
        {
            profileContentType = null;

            //if the method is get then retrieve the contenttype from the accept header if it is a profile content type
            if (actionContext.Request.Method == HttpMethod.Get)
            {
                if (actionContext.Request.Headers.Accept.Any(x => x.MediaType.StartsWith("application/vnd.ed-fi")))
                {
                    profileContentType = actionContext.Request.Headers.Accept.First(x => x.MediaType.StartsWith("application/vnd.ed-fi"))
                                                      .ToString();
                }
            }

            //if the method is put or post then retrieve the contenttype from the contenttype header if it is a profile type
            if (actionContext.Request.Method == HttpMethod.Put || actionContext.Request.Method == HttpMethod.Post)
            {
                if (actionContext.Request.Content.Headers.ContentType != null && actionContext.Request.Content.Headers.ContentType.ToString()
                                                                                              .StartsWith("application/vnd.ed-fi"))
                {
                    profileContentType = actionContext.Request.Content.Headers.ContentType.MediaType;
                }
            }

            return !string.IsNullOrEmpty(profileContentType);
        }

        private HttpResponseMessage ForbiddenHttpResponseMessage(HttpActionContext actionContext, string message)
        {
            return actionContext.Request.CreateResponse(
                HttpStatusCode.Forbidden,
                new RESTError
                {
                    Code = (int) HttpStatusCode.Forbidden, Type = "Forbidden", Message = message
                });
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Configuration;
using EdFi.Common.Inflection;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Utils.Profiles;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EdFi.Ods.Api.Middleware
{
    public class ExplicitProfilesMiddleware : IMiddleware
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly ApiSettings _apiSettings;
        private readonly ILog _logger = LogManager.GetLogger(typeof(ExplicitProfilesMiddleware));
        private readonly IProfileResourceModelProvider _profileResourceModelProvider;
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;

        public ExplicitProfilesMiddleware(
            IApiKeyContextProvider apiKeyContextProvider,
            ISchemaNameMapProvider schemaNameMapProvider,
            IProfileResourceModelProvider profileResourceModelProvider,
            ApiSettings apiSettings)
        {
            _apiKeyContextProvider = apiKeyContextProvider;
            _apiSettings = apiSettings;
            _schemaNameMapProvider = schemaNameMapProvider;
            _profileResourceModelProvider = profileResourceModelProvider;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // we only care about requests that are put, post, or get
            if (context.Request.Method == HttpMethods.Delete || context.Request.Method == HttpMethods.Patch)
            {
                await next(context);
                return;
            }

            // we only care about data management requests.
            var routeMatcher = new RouteMatcher();

            if (!routeMatcher.TryMatch(
                    CreateRouteTemplate(),
                    context.Request.Path.Value.Split('?')[0],
                    out RouteValueDictionary routeValues))
            {
                await next(context);
                return;
            }

            var apiKeyContext = _apiKeyContextProvider.GetApiKeyContext();

            if (apiKeyContext.ApiKey == null)
            {
                _logger.Debug($"User not authenticated skipping.");
                await next(context);
                return;
            }

            var profiles = apiKeyContext.Profiles?.ToList();

            // vendor does not have a profile so we just continue.
            if (!profiles.Any())
            {
                _logger.Debug($"No profiles defined for ApiKey = '{apiKeyContext.ApiKey}'");
                await next(context);
                return;
            }

            // we cannot determine the correct profile to use so we need to abort and send a bad request
            if (profiles.Count > 1)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsync(
                    "Multiple Profiles are found. Please apply the profile manually");

                return;
            }

            // we should only have one profile at this point of time.
            string profileName = profiles.Single();

            string resourceCollectionName = routeValues["resource"]
                .ToString();

            string schema = routeValues["schema"]
                .ToString();

            var fullName = new FullName(
                _schemaNameMapProvider.GetSchemaMapByUriSegment(schema)
                    .PhysicalName,
                CompositeTermInflector.MakeSingular(resourceCollectionName));

            _profileResourceModelProvider.GetProfileResourceModel(profileName)
                .ResourceByName
                .TryGetValue(fullName, out ProfileResourceContentTypes profileResourceContentTypes);

            // the resource we are requesting is not constrained by a profile
            if (profileResourceContentTypes == null)
            {
                await next(context);
                return;
            }

            string contentType = ProfilesContentTypeHelper.CreateContentType(
                resourceCollectionName,
                profileName,
                context.Request.Method == HttpMethods.Get
                    ? ContentTypeUsage.Readable
                    : ContentTypeUsage.Writable);

            // set the content type for the request
            context.Request.ContentType = contentType;
            await next(context);

            string CreateRouteTemplate()
            {
                string template = "data/v3/";

                if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
                {
                    template += RouteConstants.SchoolYearFromRoute;
                }

                if (_apiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
                {
                    template += RouteConstants.InstanceIdFromRoute;
                    template += RouteConstants.SchoolYearFromRoute;
                }

                return template + "{schema}/{resource}/{id?}";
            }
        }
    }
}

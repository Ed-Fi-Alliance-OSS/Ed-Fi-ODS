// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Dtos;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Features.Publishing.OpenApiMetadata
{
    public class PublishingOpenApiMetadataRouteInformation : IOpenApiMetadataRouteInformation
    {
        private readonly ApiSettings _apiSettings;

        public PublishingOpenApiMetadataRouteInformation(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public RouteInformation GetRouteInformation()
            => new RouteInformation
            {
                Name = PublishingConstants.PublishingMetadataRouteName,
                Template = CreateRoute() + "/swagger.json"
            };

        private string CreateRoute()
        {
            string prefix = $"metadata/{{other:regex(publishing)}}/v{PublishingConstants.FeatureVersion}/";

            if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
            {
                prefix += RouteConstants.SchoolYearFromRoute;
            }

            if (_apiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
            {
                prefix += RouteConstants.InstanceIdFromRoute;
                prefix += RouteConstants.SchoolYearFromRoute;
            }

            return prefix.TrimSuffix("/");
        }
    }
}

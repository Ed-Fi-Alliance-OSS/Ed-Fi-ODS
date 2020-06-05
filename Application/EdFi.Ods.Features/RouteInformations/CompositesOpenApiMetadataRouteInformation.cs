// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.NetCore.Routing;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Features.RouteInformations
{
    public class CompositesOpenApiMetadataRouteInformation : IOpenApiMetadataRouteInformation
    {
        private readonly ApiSettings _apiSettings;

        public CompositesOpenApiMetadataRouteInformation(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public RouteInformation GetRouteInformation()
            => new RouteInformation
            {
                Name = MetadataRouteConstants.Composites,
                Template = $"{CreateRoute()}/swagger.json"
            };

        private string CreateRoute()
        {
            string prefix = $"metadata/composites/v{ApiVersionConstants.Composite}/";

            if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
            {
                prefix += RouteConstants.SchoolYearFromRoute;
            }

            prefix += "{organizationCode}/{compositeCategoryName}";

            return prefix.TrimSuffix("/");
        }
    }
}
#endif

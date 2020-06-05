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

namespace EdFi.Ods.Features.RouteInformations {
    public abstract class OpenApiMetadataRouteInformationBase : IOpenApiMetadataRouteInformation
    {
        private readonly ApiSettings _apiSettings;
        private readonly string _routeName;
        private readonly string _template;

        public OpenApiMetadataRouteInformationBase(ApiSettings apiSettings, string routeName, string template)
        {
            _apiSettings = apiSettings;
            _routeName = routeName;
            _template = template;
        }

        public RouteInformation GetRouteInformation()
            => new RouteInformation
            {
                Name = _routeName,
                Template = $"{CreateRoute()}/swagger.json"
            };

        string CreateRoute()
        {
            string prefix = $"metadata/{RouteConstants.DataManagementRoutePrefix}/";

            if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
            {
                prefix += RouteConstants.SchoolYearFromRoute;
            }

            if (!string.IsNullOrEmpty(_template))
            {
                prefix += _template;
            }

            return prefix.TrimSuffix("/");
        }
    }
}
#endif
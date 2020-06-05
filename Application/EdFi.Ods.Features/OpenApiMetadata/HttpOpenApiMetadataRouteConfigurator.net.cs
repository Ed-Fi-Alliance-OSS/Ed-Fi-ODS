#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common;

namespace EdFi.Ods.Features.OpenApiMetadata
{
    public class HttpOpenApiMetadataRouteConfigurator : IHttpConfigurator
    {
        private readonly IOpenApiMetadataRouteConfiguration[] _openApiMetadataRouteConfigurations;
        private readonly bool _useSchoolYear;

        public HttpOpenApiMetadataRouteConfigurator(IOpenApiMetadataRouteConfiguration[] openApiMetadataRouteConfigurations,
            bool useSchoolYear = false)
        {
            _openApiMetadataRouteConfigurations = Preconditions.ThrowIfNull(openApiMetadataRouteConfigurations, nameof(openApiMetadataRouteConfigurations));
            _useSchoolYear = useSchoolYear;
        }

        public void Configure(HttpConfiguration config)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            foreach (var openApiMetadataRouteConfiguration in _openApiMetadataRouteConfigurations)
            {
                openApiMetadataRouteConfiguration.ConfigureOpenApiMetadataRoutes(config, _useSchoolYear);
            }
        }
    }
}
#endif
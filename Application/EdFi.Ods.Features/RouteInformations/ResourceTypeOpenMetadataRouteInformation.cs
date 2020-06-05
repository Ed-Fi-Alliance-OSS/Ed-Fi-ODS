// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;

namespace EdFi.Ods.Features.RouteInformations {
    public class ResourceTypeOpenMetadataRouteInformation : OpenApiMetadataRouteInformationBase
    {
        public ResourceTypeOpenMetadataRouteInformation(ApiSettings apiSettings)
            : base(apiSettings, MetadataRouteConstants.ResourceTypes, "{document}") { }
    }
}
#endif
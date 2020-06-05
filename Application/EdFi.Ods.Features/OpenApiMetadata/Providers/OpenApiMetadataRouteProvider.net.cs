// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;
using EdFi.Ods.Api.Extensions;

namespace EdFi.Ods.Features.OpenApiMetadata.Providers
{
    public class OpenApiMetadataRouteProvider : IOpenApiMetadataRouteProvider
    {
        private readonly HttpRouteCollection _httpRouteCollection;

        public OpenApiMetadataRouteProvider(HttpRouteCollection httpRouteCollection)
        {
            _httpRouteCollection = httpRouteCollection;
        }

        public IEnumerable<IHttpRoute> GetAllRoutes() => _httpRouteCollection.Where(r => r.IsOpenApiMetadataRoute());
    }
}
#endif

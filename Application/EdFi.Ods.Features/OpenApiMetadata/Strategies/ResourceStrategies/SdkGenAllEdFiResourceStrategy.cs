// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies
{
    public class SdkGenAllEdFiResourceStrategy : IOpenApiMetadataResourceStrategy
    {
        public IEnumerable<SwaggerResource> GetFilteredResources(SwaggerDocumentContext swaggerDocumentContext)
        {
            return swaggerDocumentContext.ResourceModel
                                         .GetAllResources()
                                         .Where(r => r.IsEdFiStandardResource && !r.Entity.IsAbstract)
                                         .Select(r => new SwaggerResource(r));
        }
    }
}

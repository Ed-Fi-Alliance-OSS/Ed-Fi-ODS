// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Utils.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class DefaultSwaggerPathsFactoryStrategy
        : ISwaggerPathsFactorySelectorStrategy,
          ISwaggerPathsFactoryContentTypeStrategy
    {
        public string GetOperationContentType(SwaggerResource swaggerResource, ContentTypeUsage contentTypeUsage)
        {
            return SwaggerDocumentHelper.ContentType;
        }

        public IEnumerable<SwaggerPathsResource> ApplyStrategy(IEnumerable<SwaggerResource> swaggerResources)
        {
            return swaggerResources.Select(
                r => new SwaggerPathsResource(r.Resource)
                     {
                         Readable = true, Writable = true
                     });
        }

        public bool HasTotalCount => true;
    }
}

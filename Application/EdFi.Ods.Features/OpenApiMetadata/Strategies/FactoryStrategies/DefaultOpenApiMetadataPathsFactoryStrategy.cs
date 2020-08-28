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
    public class DefaultOpenApiMetadataPathsFactoryStrategy
        : IOpenApiMetadataPathsFactorySelectorStrategy,
          IOpenApiMetadataPathsFactoryContentTypeStrategy
    {
        public string GetOperationContentType(OpenApiMetadataResource openApiMetadataResource, ContentTypeUsage contentTypeUsage)
        {
            return OpenApiMetadataDocumentHelper.ContentType;
        }

        public IEnumerable<OpenApiMetadataPathsResource> ApplyStrategy(IEnumerable<OpenApiMetadataResource> openApiMetadataResources)
        {
            return openApiMetadataResources.Select(
                r => new OpenApiMetadataPathsResource(r.Resource)
                {
                    Readable = true,
                    Writable = true
                });
        }

        public bool HasTotalCount => true;
    }
}

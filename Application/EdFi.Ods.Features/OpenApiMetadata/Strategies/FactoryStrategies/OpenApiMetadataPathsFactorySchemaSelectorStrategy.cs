// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class OpenApiMetadataPathsFactorySchemaSelectorStrategy : IOpenApiMetadataPathsFactorySelectorStrategy
    {
        private readonly OpenApiMetadataDocumentContext _documentContext;

        public OpenApiMetadataPathsFactorySchemaSelectorStrategy(OpenApiMetadataDocumentContext documentContext)
        {
            _documentContext = documentContext;
        }

        public IEnumerable<OpenApiMetadataPathsResource> ApplyStrategy(IEnumerable<OpenApiMetadataResource> swaggerResources)
        {
            return swaggerResources.Where(x => _documentContext.IsIncludedExtension(x.Resource))
                                   .Select(
                                        x => new OpenApiMetadataPathsResource(x)
                                        {
                                            Readable = true,
                                            Writable = true
                                        });
        }

        public bool HasTotalCount => true;
    }
}

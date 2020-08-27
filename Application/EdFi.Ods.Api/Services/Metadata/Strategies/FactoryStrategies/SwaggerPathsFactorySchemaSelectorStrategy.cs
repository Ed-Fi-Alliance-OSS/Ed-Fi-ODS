// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Services.Metadata.Models;

namespace EdFi.Ods.Api.Services.Metadata.Strategies.FactoryStrategies
{
    public class SwaggerPathsFactorySchemaSelectorStrategy : ISwaggerPathsFactorySelectorStrategy
    {
        private readonly SwaggerDocumentContext _documentContext;

        public SwaggerPathsFactorySchemaSelectorStrategy(SwaggerDocumentContext documentContext)
        {
            _documentContext = documentContext;
        }

        public IEnumerable<SwaggerPathsResource> ApplyStrategy(IEnumerable<SwaggerResource> swaggerResources)
        {
            return swaggerResources.Where(x => _documentContext.IsIncludedExtension(x.Resource))
                                   .Select(
                                        x => new SwaggerPathsResource(x)
                                             {
                                                 Readable = true, Writable = true
                                             });
        }

        public bool HasTotalCount => true;
    }
}

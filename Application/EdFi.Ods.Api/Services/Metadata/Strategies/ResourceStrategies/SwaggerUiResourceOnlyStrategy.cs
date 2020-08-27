﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Services.Metadata.Models;

namespace EdFi.Ods.Api.Services.Metadata.Strategies.ResourceStrategies
{
    public class SwaggerUiResourceOnlyStrategy : IOpenApiMetadataResourceStrategy
    {
        public IEnumerable<SwaggerResource> GetFilteredResources(SwaggerDocumentContext swaggerDocumentContext) => swaggerDocumentContext
                                                                                                                  .ResourceModel
                                                                                                                  .GetAllResources()
                                                                                                                  .Where(
                                                                                                                       x => !x.Entity.IsLookup
                                                                                                                            && !x.Entity.IsAbstract)
                                                                                                                  .Select(
                                                                                                                       r => new SwaggerResource(r));
    }
}

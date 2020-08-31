﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies
{
    public class SdkGenExtensionResourceStrategy : IOpenApiMetadataResourceStrategy
    {
        public IEnumerable<OpenApiMetadataResource> GetFilteredResources(OpenApiMetadataDocumentContext openApiMetadataDocumentContext) =>

            // Only included extensions or EdFi resources that have one of the included extensions
            openApiMetadataDocumentContext.ResourceModel
                                  .GetAllResources()
                                  .Where(
                                       r =>
                                           openApiMetadataDocumentContext.IsIncludedExtension(r)
                                           || r.IsEdFiStandardResource
                                           && (r.AllContainedItemTypes.Any(
                                                   i =>
                                                       i.Extensions.Any(
                                                           x => openApiMetadataDocumentContext.IsIncludedExtension(
                                                               x.ObjectType)))
                                               || r.Extensions.Any(
                                                   x => openApiMetadataDocumentContext.IsIncludedExtension(x.ObjectType))))
                                  .Select(r => new OpenApiMetadataResource(r));
    }
}

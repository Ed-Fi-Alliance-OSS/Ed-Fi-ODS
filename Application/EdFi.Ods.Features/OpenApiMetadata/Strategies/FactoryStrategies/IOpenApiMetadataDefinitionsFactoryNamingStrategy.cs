﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public interface IOpenApiMetadataDefinitionsFactoryNamingStrategy : IOpenApiMetadataFactoryResourceDefinitionNamingStrategy
    {
        string GetContainedItemTypeName(OpenApiMetadataResource openApiMetadataResource, ResourceChildItem resourceChildItem);

        string GetReferenceName(ResourceClassBase resource, Reference reference);

        string GetEmbeddedObjectReferenceName(OpenApiMetadataResource openApiMetadataResource, EmbeddedObject embeddedObject);

        string GetCollectionReferenceName(OpenApiMetadataResource openApiMetadataResource, Collection collection);
    }
}

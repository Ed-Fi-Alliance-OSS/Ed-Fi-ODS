// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class OpenApiMetadataDefinitionsFactoryDefaultEdFiExtensionBridgeStrategy : IOpenApiMetadataDefinitionsFactoryEdFiExtensionBridgeStrategy
    {
        private readonly OpenApiMetadataDocumentContext _documentContext;

        public OpenApiMetadataDefinitionsFactoryDefaultEdFiExtensionBridgeStrategy(OpenApiMetadataDocumentContext documentContext)
        {
            _documentContext = documentContext;
        }

        public Schema GetEdFiEntityExtensionBridgeSchema(ResourceClassBase resource, IOpenApiMetadataResourceContext resourceContext)
        {
            return resource.Extensions.Any(extension => _documentContext.IsIncludedExtension(extension.ObjectType))
                ? new Schema
                {
                    @ref = OpenApiMetadataDocumentHelper.GetDefinitionReference(OpenApiMetadataDocumentHelper.GetEdFiExtensionBridgeName(resource, resourceContext))
                }
                : null;
        }

        public Schema GetEdFiExtensionBridgeSchema(ResourceClassBase resourceClassBase, IOpenApiMetadataResourceContext resourceContext)
        {
            return new Schema
            {
                type = "object",
                properties = resourceClassBase.ExtensionByName
                                                                      .Where(kvp => _documentContext.IsIncludedExtension(kvp.Value.ObjectType))
                                                                      .ToDictionary(
                                                                           pair => pair.Key,
                                                                           pair =>
                                                                               new Schema
                                                                               {
                                                                                   @ref =
                                                                                       OpenApiMetadataDocumentHelper.GetDefinitionReference(
                                                                                           OpenApiMetadataDocumentHelper
                                                                                              .GetResourceExtensionDefinitionName(
                                                                                                   pair.Value,
                                                                                                   resourceContext))
                                                                               })
            };
        }
    }
}

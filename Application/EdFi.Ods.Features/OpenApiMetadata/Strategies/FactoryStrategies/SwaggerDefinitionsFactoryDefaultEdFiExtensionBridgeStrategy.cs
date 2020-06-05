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
    public class SwaggerDefinitionsFactoryDefaultEdFiExtensionBridgeStrategy : ISwaggerDefinitionsFactoryEdFiExtensionBridgeStrategy
    {
        private readonly SwaggerDocumentContext _documentContext;

        public SwaggerDefinitionsFactoryDefaultEdFiExtensionBridgeStrategy(SwaggerDocumentContext documentContext)
        {
            _documentContext = documentContext;
        }

        public Schema GetEdFiEntityExtensionBridgeSchema(ResourceClassBase resource, ISwaggerResourceContext resourceContext)
        {
            return resource.Extensions.Any(extension => _documentContext.IsIncludedExtension(extension.ObjectType))
                ? new Schema
                  {
                      @ref = SwaggerDocumentHelper.GetDefinitionReference(SwaggerDocumentHelper.GetEdFiExtensionBridgeName(resource, resourceContext))
                  }
                : null;
        }

        public Schema GetEdFiExtensionBridgeSchema(ResourceClassBase resourceClassBase, ISwaggerResourceContext resourceContext)
        {
            return new Schema
                   {
                       type = "object", properties = resourceClassBase.ExtensionByName
                                                                      .Where(kvp => _documentContext.IsIncludedExtension(kvp.Value.ObjectType))
                                                                      .ToDictionary(
                                                                           pair => pair.Key,
                                                                           pair =>
                                                                               new Schema
                                                                               {
                                                                                   @ref =
                                                                                       SwaggerDocumentHelper.GetDefinitionReference(
                                                                                           SwaggerDocumentHelper
                                                                                              .GetResourceExtensionDefinitionName(
                                                                                                   pair.Value,
                                                                                                   resourceContext))
                                                                               })
                   };
        }
    }
}

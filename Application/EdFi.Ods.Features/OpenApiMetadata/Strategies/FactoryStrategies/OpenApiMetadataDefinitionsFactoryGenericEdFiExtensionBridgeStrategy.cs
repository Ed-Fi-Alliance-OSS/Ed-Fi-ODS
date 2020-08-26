// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Models;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class OpenApiMetadataDefinitionsFactoryGenericEdFiExtensionBridgeStrategy : IOpenApiMetadataDefinitionsFactoryEdFiExtensionBridgeStrategy
    {
        private readonly OpenApiMetadataDocumentContext _documentContext;

        public OpenApiMetadataDefinitionsFactoryGenericEdFiExtensionBridgeStrategy(OpenApiMetadataDocumentContext documentContext)
        {
            _documentContext = documentContext;
        }

        public Schema GetEdFiEntityExtensionBridgeSchema(ResourceClassBase resource, IOpenApiMetadataResourceContext resourceContext)
        {
            if (_documentContext.RenderType == RenderType.GeneralizedExtensions)
            {
                return new Schema
                {
                    type = "object",
                    description = $"Extensions to the {resource.Name} entity.",
                    properties = new SortedDictionary<string, Schema>()
                };
            }

            return null;
        }

        public Schema GetEdFiExtensionBridgeSchema(ResourceClassBase resource, IOpenApiMetadataResourceContext resourceContext)
        {
            //No Extension bridge schema
            return null;
        }
    }
}

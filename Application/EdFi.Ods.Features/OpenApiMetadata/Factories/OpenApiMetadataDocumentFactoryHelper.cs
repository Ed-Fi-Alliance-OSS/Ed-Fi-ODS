// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public static class OpenApiMetadataDocumentFactoryHelper
    {
        // Consider reviewing the conditionals in this file for similarities, that could be used 
        // to create methods for construction of the underlying strategies for that conditional function segment.
        // This would allow for methods like "GetCompositeSwaggerDefinitionsFactory" or "GetExtensionOnlySwaggerDocumentFactory"
        // that would create the entire SwaggerDocumentFactory with the correct strategies for that use case rather 
        // than using conditional checks on the context.

        public static OpenApiMetadataDefinitionsFactory CreateSwaggerDefinitionsFactory(OpenApiMetadataDocumentContext swaggerDocumentContext)
        {
            switch (swaggerDocumentContext.RenderType)
            {
                case RenderType.GeneralizedExtensions:

                    var genericStrategy =
                        new OpenApiMetadataDefinitionsFactoryGenericEdFiExtensionBridgeStrategy(swaggerDocumentContext);

                    return new OpenApiMetadataDefinitionsFactory(
                        new OpenApiMetadataDefinitionsFactoryEmptyEntityExtensionStrategy(),
                        genericStrategy,
                        new OpenApiMetadataDefinitionsFactoryDefaultNamingStrategy(),
                        new OpenApiMetadataFactoryResourceFilterSchemaStrategy(swaggerDocumentContext));

                case RenderType.ExtensionArtifactsOnly:

                    var genericBridgeStrategy =
                        new OpenApiMetadataDefinitionsFactoryGenericEdFiExtensionBridgeStrategy(swaggerDocumentContext);

                    return new OpenApiMetadataDefinitionsFactory(
                        new OpenApiMetadataDefinitionsFactoryDefaultEntityExtensionStrategy(
                            swaggerDocumentContext,
                            genericBridgeStrategy,
                            new OpenApiMetadataDefinitionsFactoryDefaultNamingStrategy()),
                        genericBridgeStrategy,
                        new OpenApiMetadataDefinitionsFactoryDefaultNamingStrategy(),
                        new OpenApiMetadataFactoryResourceFilterSchemaStrategy(swaggerDocumentContext));
                default:
                    var bridgeStrategy = new OpenApiMetadataDefinitionsFactoryDefaultEdFiExtensionBridgeStrategy(swaggerDocumentContext);
                    var filterStrategy = new OpenApiMetadataFactoryResourceFilterDefaultStrategy();

                    var namingStrategy = GetSwaggerDefinitionsFactoryNamingStrategy(swaggerDocumentContext);

                    var extensionStrategy = new OpenApiMetadataDefinitionsFactoryDefaultEntityExtensionStrategy(
                        swaggerDocumentContext,
                        bridgeStrategy,
                        namingStrategy);

                    return new OpenApiMetadataDefinitionsFactory(
                        extensionStrategy,
                        bridgeStrategy,
                        namingStrategy,
                        filterStrategy);
            }
        }

        public static OpenApiMetadataPathsFactory CreateSwaggerPathsFactory(OpenApiMetadataDocumentContext swaggerDocumentContext)
        {
            if (swaggerDocumentContext.IsProfileContext)
            {
                var profileStrategy = new OpenApiMetadataPathsFactoryProfileStrategy(swaggerDocumentContext);

                //Profile strategy implements each of the interfaces in the signature of the paths factory constructor
                //Hence the odd parameter repetition.
                return new OpenApiMetadataPathsFactory(profileStrategy, profileStrategy, profileStrategy);
            }

            IOpenApiMetadataPathsFactorySelectorStrategy selectorStrategy = null;
            IOpenApiMetadataPathsFactoryNamingStrategy resourceNamingStrategy = null;

            if (swaggerDocumentContext.RenderType == RenderType.ExtensionArtifactsOnly)
            {
                selectorStrategy = new OpenApiMetadataPathsFactorySchemaSelectorStrategy(swaggerDocumentContext);
            }

            if (swaggerDocumentContext.IsCompositeContext)
            {
                selectorStrategy = new OpenApiMetadataCompositePathsFactoryStrategy(swaggerDocumentContext);
                resourceNamingStrategy = new OpenApiMetadataPathsFactoryCompositeStrategy();
            }

            var defaultStrategy = new DefaultOpenApiMetadataPathsFactoryStrategy();
            var defaultResourceDefinitionNamingStrategy = new OpenApiMetadataPathsFactoryDefaultStrategy();

            IOpenApiMetadataPathsFactoryContentTypeStrategy contentTypeStrategy = defaultStrategy;
            selectorStrategy = selectorStrategy ?? defaultStrategy;
            resourceNamingStrategy = resourceNamingStrategy ?? defaultResourceDefinitionNamingStrategy;

            return new OpenApiMetadataPathsFactory(selectorStrategy, contentTypeStrategy, resourceNamingStrategy);
        }

        public static OpenApiMetadataTagsFactory CreateSwaggerTagsFactory(OpenApiMetadataDocumentContext documentContext)
        {
            var filter = documentContext.RenderType == RenderType.ExtensionArtifactsOnly
                ? new OpenApiMetadataFactoryResourceFilterSchemaStrategy(documentContext) as IOpenApiMetadataFactoryResourceFilterStrategy
                : new OpenApiMetadataFactoryResourceFilterDefaultStrategy();

            return new OpenApiMetadataTagsFactory(filter);
        }

        private static IOpenApiMetadataDefinitionsFactoryNamingStrategy GetSwaggerDefinitionsFactoryNamingStrategy(
            OpenApiMetadataDocumentContext swaggerDocumentContext)
        {
            if (swaggerDocumentContext.IsCompositeContext)
            {
                return new OpenApiMetadataDefinitionsFactoryCompositeNamingStrategy();
            }

            return swaggerDocumentContext.IsProfileContext
                ? (IOpenApiMetadataDefinitionsFactoryNamingStrategy)new OpenApiMetadataDefinitionsFactoryProfileNamingStrategy()
                : new OpenApiMetadataDefinitionsFactoryDefaultNamingStrategy();
        }

        public static OpenApiMetadataDocumentFactory GetExtensionOnlySwaggerDocumentFactory(IResourceModel resourceModel, Schema schema)
        {
            var documentContext = new OpenApiMetadataDocumentContext(resourceModel)
            {
                RenderType = RenderType.ExtensionArtifactsOnly,
                IsIncludedExtension = r => r.FullName.Schema.Equals(schema.PhysicalName)
            };

            return new OpenApiMetadataDocumentFactory(
                new OpenApiMetadataParametersFactory(),
                CreateSwaggerDefinitionsFactory(documentContext),
                new OpenApiMetadataResponsesFactory(),
                CreateSwaggerPathsFactory(documentContext),
                CreateSwaggerTagsFactory(documentContext),
                documentContext
            );
        }
    }
}

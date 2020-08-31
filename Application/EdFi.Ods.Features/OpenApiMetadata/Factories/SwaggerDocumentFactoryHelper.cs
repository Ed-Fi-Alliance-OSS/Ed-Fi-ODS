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
    public static class SwaggerDocumentFactoryHelper
    {
        // Consider reviewing the conditionals in this file for similarities, that could be used 
        // to create methods for construction of the underlying strategies for that conditional function segment.
        // This would allow for methods like "GetCompositeSwaggerDefinitionsFactory" or "GetExtensionOnlySwaggerDocumentFactory"
        // that would create the entire SwaggerDocumentFactory with the correct strategies for that use case rather 
        // than using conditional checks on the context.

        public static SwaggerDefinitionsFactory CreateSwaggerDefinitionsFactory(SwaggerDocumentContext swaggerDocumentContext)
        {
            switch (swaggerDocumentContext.RenderType)
            {
                case RenderType.GeneralizedExtensions:

                    var genericStrategy =
                        new SwaggerDefinitionsFactoryGenericEdFiExtensionBridgeStrategy(swaggerDocumentContext);

                    return new SwaggerDefinitionsFactory(
                        new SwaggerDefinitionsFactoryEmptyEntityExtensionStrategy(),
                        genericStrategy,
                        new SwaggerDefinitionsFactoryDefaultNamingStrategy(),
                        new SwaggerFactoryResourceFilterSchemaStrategy(swaggerDocumentContext));

                case RenderType.ExtensionArtifactsOnly:

                    var genericBridgeStrategy =
                        new SwaggerDefinitionsFactoryGenericEdFiExtensionBridgeStrategy(swaggerDocumentContext);

                    return new SwaggerDefinitionsFactory(
                        new SwaggerDefinitionsFactoryDefaultEntityExtensionStrategy(
                            swaggerDocumentContext,
                            genericBridgeStrategy,
                            new SwaggerDefinitionsFactoryDefaultNamingStrategy()),
                        genericBridgeStrategy,
                        new SwaggerDefinitionsFactoryDefaultNamingStrategy(),
                        new SwaggerFactoryResourceFilterSchemaStrategy(swaggerDocumentContext));
                default:
                    var bridgeStrategy = new SwaggerDefinitionsFactoryDefaultEdFiExtensionBridgeStrategy(swaggerDocumentContext);
                    var filterStrategy = new SwaggerFactoryResourceFilterDefaultStrategy();

                    var namingStrategy = GetSwaggerDefinitionsFactoryNamingStrategy(swaggerDocumentContext);

                    var extensionStrategy = new SwaggerDefinitionsFactoryDefaultEntityExtensionStrategy(
                        swaggerDocumentContext,
                        bridgeStrategy,
                        namingStrategy);

                    return new SwaggerDefinitionsFactory(
                        extensionStrategy,
                        bridgeStrategy,
                        namingStrategy,
                        filterStrategy);
            }
        }

        public static SwaggerPathsFactory CreateSwaggerPathsFactory(SwaggerDocumentContext swaggerDocumentContext)
        {
            if (swaggerDocumentContext.IsProfileContext)
            {
                var profileStrategy = new SwaggerPathsFactoryProfileStrategy(swaggerDocumentContext);

                //Profile strategy implements each of the interfaces in the signature of the paths factory constructor
                //Hence the odd parameter repetition.
                return new SwaggerPathsFactory(profileStrategy, profileStrategy, profileStrategy);
            }

            ISwaggerPathsFactorySelectorStrategy selectorStrategy = null;
            ISwaggerPathsFactoryNamingStrategy resourceNamingStrategy = null;

            if (swaggerDocumentContext.RenderType == RenderType.ExtensionArtifactsOnly)
            {
                selectorStrategy = new SwaggerPathsFactorySchemaSelectorStrategy(swaggerDocumentContext);
            }

            if (swaggerDocumentContext.IsCompositeContext)
            {
                selectorStrategy = new SwaggerCompositePathsFactoryStrategy(swaggerDocumentContext);
                resourceNamingStrategy = new SwaggerPathsFactoryCompositeStrategy();
            }

            var defaultStrategy = new DefaultSwaggerPathsFactoryStrategy();
            var defaultResourceDefinitionNamingStrategy = new SwaggerPathsFactoryDefaultStrategy();

            ISwaggerPathsFactoryContentTypeStrategy contentTypeStrategy = defaultStrategy;
            selectorStrategy = selectorStrategy ?? defaultStrategy;
            resourceNamingStrategy = resourceNamingStrategy ?? defaultResourceDefinitionNamingStrategy;

            return new SwaggerPathsFactory(selectorStrategy, contentTypeStrategy, resourceNamingStrategy);
        }

        public static SwaggerTagsFactory CreateSwaggerTagsFactory(SwaggerDocumentContext documentContext)
        {
            var filter = documentContext.RenderType == RenderType.ExtensionArtifactsOnly
                ? new SwaggerFactoryResourceFilterSchemaStrategy(documentContext) as ISwaggerFactoryResourceFilterStrategy
                : new SwaggerFactoryResourceFilterDefaultStrategy();

            return new SwaggerTagsFactory(filter);
        }

        private static ISwaggerDefinitionsFactoryNamingStrategy GetSwaggerDefinitionsFactoryNamingStrategy(
            SwaggerDocumentContext swaggerDocumentContext)
        {
            if (swaggerDocumentContext.IsCompositeContext)
            {
                return new SwaggerDefinitionsFactoryCompositeNamingStrategy();
            }

            return swaggerDocumentContext.IsProfileContext
                ? (ISwaggerDefinitionsFactoryNamingStrategy) new SwaggerDefinitionsFactoryProfileNamingStrategy()
                : new SwaggerDefinitionsFactoryDefaultNamingStrategy();
        }

        public static SwaggerDocumentFactory GetExtensionOnlySwaggerDocumentFactory(IResourceModel resourceModel, Schema schema)
        {
            var documentContext = new SwaggerDocumentContext(resourceModel)
                                  {
                                      RenderType = RenderType.ExtensionArtifactsOnly,
                                      IsIncludedExtension = r => r.FullName.Schema.Equals(schema.PhysicalName)
                                  };

            return new SwaggerDocumentFactory(
                new SwaggerParametersFactory(),
                CreateSwaggerDefinitionsFactory(documentContext),
                new SwaggerResponsesFactory(),
                CreateSwaggerPathsFactory(documentContext),
                CreateSwaggerTagsFactory(documentContext),
                documentContext
            );
        }
    }
}

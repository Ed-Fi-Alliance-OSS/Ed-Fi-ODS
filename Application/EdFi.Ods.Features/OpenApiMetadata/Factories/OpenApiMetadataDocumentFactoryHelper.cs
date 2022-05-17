// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.ChangeQueries.Repositories;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public static class OpenApiMetadataDocumentFactoryHelper
    {
        // Consider reviewing the conditionals in this file for similarities, that could be used 
        // to create methods for construction of the underlying strategies for that conditional function segment.
        // This would allow for methods like "GetCompositeOpenApiMetadataDefinitionsFactory" or "GetExtensionOnlyOpenApiMetadataDocumentFactory"
        // that would create the entire OpenApiMetadataDocumentFactory with the correct strategies for that use case rather 
        // than using conditional checks on the context.

        public static OpenApiMetadataDefinitionsFactory CreateOpenApiMetadataDefinitionsFactory(
            OpenApiMetadataDocumentContext openApiMetadataDocumentContext,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider,
            ApiSettings apiSettings)
        {
            switch (openApiMetadataDocumentContext.RenderType)
            {
                case RenderType.GeneralizedExtensions:

                    var genericStrategy =
                        new OpenApiMetadataDefinitionsFactoryGenericEdFiExtensionBridgeStrategy(openApiMetadataDocumentContext);

                    return new OpenApiMetadataDefinitionsFactory(
                        new OpenApiMetadataDefinitionsFactoryEmptyEntityExtensionStrategy(),
                        genericStrategy,
                        new OpenApiMetadataDefinitionsFactoryDefaultNamingStrategy(),
                        new OpenApiMetadataFactoryResourceFilterSchemaStrategy(openApiMetadataDocumentContext),
                        trackedChangesIdentifierProjectionsProvider,
                        apiSettings);

                case RenderType.ExtensionArtifactsOnly:

                    var genericBridgeStrategy =
                        new OpenApiMetadataDefinitionsFactoryGenericEdFiExtensionBridgeStrategy(openApiMetadataDocumentContext);

                    return new OpenApiMetadataDefinitionsFactory(
                        new OpenApiMetadataDefinitionsFactoryDefaultEntityExtensionStrategy(
                            openApiMetadataDocumentContext,
                            genericBridgeStrategy,
                            new OpenApiMetadataDefinitionsFactoryDefaultNamingStrategy()),
                        genericBridgeStrategy,
                        new OpenApiMetadataDefinitionsFactoryDefaultNamingStrategy(),
                        new OpenApiMetadataFactoryResourceFilterSchemaStrategy(openApiMetadataDocumentContext),
                        trackedChangesIdentifierProjectionsProvider,
                        apiSettings);
                default:
                    var bridgeStrategy =
                        new OpenApiMetadataDefinitionsFactoryDefaultEdFiExtensionBridgeStrategy(openApiMetadataDocumentContext);

                    var filterStrategy = new OpenApiMetadataFactoryResourceFilterDefaultStrategy();

                    var namingStrategy = GetOpenApiMetadataDefinitionsFactoryNamingStrategy(openApiMetadataDocumentContext);

                    var extensionStrategy = new OpenApiMetadataDefinitionsFactoryDefaultEntityExtensionStrategy(
                        openApiMetadataDocumentContext,
                        bridgeStrategy,
                        namingStrategy);

                    return new OpenApiMetadataDefinitionsFactory(
                        extensionStrategy,
                        bridgeStrategy,
                        namingStrategy,
                        filterStrategy,
                        trackedChangesIdentifierProjectionsProvider,
                        apiSettings);
            }
        }

        public static OpenApiMetadataPathsFactory CreateOpenApiMetadataPathsFactory(
            OpenApiMetadataDocumentContext openApiMetadataDocumentContext, ApiSettings apiSettings)
        {
            if (openApiMetadataDocumentContext.IsProfileContext)
            {
                var profileStrategy = new OpenApiMetadataPathsFactoryProfileStrategy(openApiMetadataDocumentContext);

                //Profile strategy implements each of the interfaces in the signature of the paths factory constructor
                //Hence the odd parameter repetition.
                return new OpenApiMetadataPathsFactory(profileStrategy, profileStrategy, profileStrategy, apiSettings);
            }

            IOpenApiMetadataPathsFactorySelectorStrategy selectorStrategy = null;
            IOpenApiMetadataPathsFactoryNamingStrategy resourceNamingStrategy = null;

            if (openApiMetadataDocumentContext.RenderType == RenderType.ExtensionArtifactsOnly)
            {
                selectorStrategy = new OpenApiMetadataPathsFactorySchemaSelectorStrategy(openApiMetadataDocumentContext);
            }

            if (openApiMetadataDocumentContext.IsCompositeContext)
            {
                selectorStrategy = new OpenApiMetadataCompositePathsFactoryStrategy(openApiMetadataDocumentContext);
                resourceNamingStrategy = new OpenApiMetadataPathsFactoryCompositeStrategy();
            }

            var defaultStrategy = new DefaultOpenApiMetadataPathsFactoryStrategy();
            var defaultResourceDefinitionNamingStrategy = new OpenApiMetadataPathsFactoryDefaultStrategy();

            IOpenApiMetadataPathsFactoryContentTypeStrategy contentTypeStrategy = defaultStrategy;
            selectorStrategy ??= defaultStrategy;
            resourceNamingStrategy ??= defaultResourceDefinitionNamingStrategy;

            return new OpenApiMetadataPathsFactory(selectorStrategy, contentTypeStrategy, resourceNamingStrategy, apiSettings);
        }

        public static OpenApiMetadataTagsFactory CreateOpenApiMetadataTagsFactory(OpenApiMetadataDocumentContext documentContext)
        {
            var filter = documentContext.RenderType == RenderType.ExtensionArtifactsOnly
                ? new OpenApiMetadataFactoryResourceFilterSchemaStrategy(documentContext) as
                    IOpenApiMetadataFactoryResourceFilterStrategy
                : new OpenApiMetadataFactoryResourceFilterDefaultStrategy();

            return new OpenApiMetadataTagsFactory(filter);
        }

        private static IOpenApiMetadataDefinitionsFactoryNamingStrategy GetOpenApiMetadataDefinitionsFactoryNamingStrategy(
            OpenApiMetadataDocumentContext openApiMetadataDocumentContext)
        {
            if (openApiMetadataDocumentContext.IsCompositeContext)
            {
                return new OpenApiMetadataDefinitionsFactoryCompositeNamingStrategy();
            }

            return openApiMetadataDocumentContext.IsProfileContext
                ? (IOpenApiMetadataDefinitionsFactoryNamingStrategy) new OpenApiMetadataDefinitionsFactoryProfileNamingStrategy()
                : new OpenApiMetadataDefinitionsFactoryDefaultNamingStrategy();
        }
    }
}

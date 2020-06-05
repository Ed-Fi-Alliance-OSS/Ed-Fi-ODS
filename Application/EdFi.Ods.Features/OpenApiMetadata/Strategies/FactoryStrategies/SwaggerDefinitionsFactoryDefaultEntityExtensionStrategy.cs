// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class SwaggerDefinitionsFactoryDefaultEntityExtensionStrategy : ISwaggerDefinitionsFactoryEntityExtensionStrategy
    {
        private readonly ISwaggerDefinitionsFactoryEdFiExtensionBridgeStrategy _bridgeStrategy;
        private readonly SwaggerDocumentContext _documentContext;
        private readonly ISwaggerDefinitionsFactoryNamingStrategy _namingStrategy;

        public SwaggerDefinitionsFactoryDefaultEntityExtensionStrategy(
            SwaggerDocumentContext documentContext,
            ISwaggerDefinitionsFactoryEdFiExtensionBridgeStrategy bridgeStrategy,
            ISwaggerDefinitionsFactoryNamingStrategy namingStrategy)
        {
            _documentContext = documentContext;
            _bridgeStrategy = bridgeStrategy;
            _namingStrategy = namingStrategy;
        }

        public IDictionary<string, Schema> GetEdFiExtensionBridgeDefinitions(IEnumerable<SwaggerResource> swaggerResources)
        {
            return swaggerResources.Where(r => r.Resource.Entity != null && r.Resource.IsEdFiStandardResource && !r.Resource.Entity.IsLookup)
                                   .Select(
                                        r =>
                                        {
                                            var extendedItems =
                                                r.Resource.AllContainedItemTypes.Where(
                                                      i => i.Extensions.Any(e => _documentContext.IsIncludedExtension(e.ObjectType)))
                                                 .ToList<ResourceClassBase>();

                                            if (r.Resource.Extensions.Any(e => _documentContext.IsIncludedExtension(e.ObjectType)))
                                            {
                                                extendedItems.Add(r.Resource);
                                            }

                                            return
                                                new
                                                {
                                                    SwaggerResourceContext = r as ISwaggerResourceContext, ExtendedItems = extendedItems
                                                };
                                        })
                                   .SelectMany(
                                        ar =>
                                            ar.ExtendedItems.SelectMany(x => CreateEdFiExtensionSchemas(x, ar.SwaggerResourceContext)))
                                   .GroupBy(x => x.Key)
                                   .Select(g => g.First())
                                   .ToDictionary(x => x.Key, x => x.Value);
        }

        private IDictionary<string, Schema> CreateEdFiExtensionSchemas(ResourceClassBase resourceClassBase, ISwaggerResourceContext resourceContext)
        {
            var extensions = new Dictionary<string, Schema>();

            //Add the bridge extension object with all extension references.
            var bridgeSchema = _bridgeStrategy.GetEdFiExtensionBridgeSchema(resourceClassBase, resourceContext);

            if (bridgeSchema != null)
            {
                extensions.Add(
                    SwaggerDocumentHelper.GetEdFiExtensionBridgeName(resourceClassBase, resourceContext),
                    bridgeSchema);
            }

            return extensions;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Composites;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies
{
    public class OpenApiCompositeStrategy : IOpenApiMetadataResourceStrategy
    {
        private readonly ICompositesMetadataProvider _compositesMetadataProvider;

        public OpenApiCompositeStrategy(ICompositesMetadataProvider compositesMetadataProvider)
        {
            _compositesMetadataProvider = compositesMetadataProvider;
        }

        public IEnumerable<SwaggerResource> GetFilteredResources(SwaggerDocumentContext swaggerDocumentContext)
        {
            var compositeContext = swaggerDocumentContext.CompositeContext;

            var definitionProcessor =
                new CompositeDefinitionProcessor<CompositeResourceModelBuilderContext, Resource>(
                    new CompositeResourceModelBuilder());

            IReadOnlyList<XElement> compositeDefinitions;

            if (!_compositesMetadataProvider.TryGetCompositeDefinitions(
                compositeContext.OrganizationCode,
                compositeContext.CategoryName,
                out compositeDefinitions))
            {
                return null;
            }

            var compositeResources = new List<SwaggerResource>();

            foreach (var compositeDefinition in compositeDefinitions)
            {
                // Enable this for composite xml validation.
                definitionProcessor.UseCompositeValidation();

                var compositeResource = definitionProcessor.Process(
                    compositeDefinition,
                    swaggerDocumentContext.ResourceModel,
                    new CompositeResourceModelBuilderContext());

                compositeResources.Add(
                    new SwaggerResource(compositeResource)
                    {
                        Readable = true, CompositeResourceContext = new CompositeResourceContext
                                                                    {
                                                                        OrganizationCode = swaggerDocumentContext.CompositeContext.OrganizationCode,
                                                                        Specification = compositeDefinition.Element("Specification"), BaseResource =
                                                                            compositeDefinition.Element("BaseResource")
                                                                                               .AttributeValue("name")
                                                                    }
                    });
            }

            var defaultCompositeRoutes = new List<XElement>
                                         {
                                             XElement.Parse(
                                                 "<Route relativeRouteTemplate='/{compositeName}' />"),
                                             XElement.Parse(
                                                 "<Route relativeRouteTemplate='/{compositeName}/{id}' />")
                                         };

            // Get all route definitions for the category
            IReadOnlyList<XElement> routes;

            if (!_compositesMetadataProvider.TryGetRoutes(compositeContext.OrganizationCode, compositeContext.CategoryName, out routes))
            {
                throw new Exception($"Composite category '{compositeContext.CategoryName}' does not have any routes defined.");
            }

            compositeContext.RouteElements = defaultCompositeRoutes.Concat(routes)
                                                                   .ToList();

            return compositeResources.ToList();
        }
    }
}

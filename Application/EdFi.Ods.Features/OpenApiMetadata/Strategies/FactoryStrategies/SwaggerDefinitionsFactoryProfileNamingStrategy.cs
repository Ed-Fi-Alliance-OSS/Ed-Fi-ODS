// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class SwaggerDefinitionsFactoryProfileNamingStrategy
        : ISwaggerDefinitionsFactoryNamingStrategy
    {
        public string GetCollectionReferenceName(SwaggerResource swaggerResource, Collection collection)
        {
            var name = collection.IsDerivedFrom(swaggerResource.Resource)
                ? CreateChildModelTypeName(
                    swaggerResource.Resource,
                    collection.ItemType.Name,
                    collection.Parent)
                : collection.ItemType.Name;

            return
                SwaggerDocumentHelper.CamelCaseSegments(
                    $"{collection.ItemType.SchemaProperCaseName}_{name}_{swaggerResource.OperationNamingContext}");
        }

        public string GetContainedItemTypeName(SwaggerResource swaggerResource, ResourceChildItem resourceChildItem)
        {
            var name = resourceChildItem.IsDerivedFrom(swaggerResource.Resource)
                ? CreateChildModelTypeName(
                    swaggerResource.Resource,
                    resourceChildItem.Name,
                    resourceChildItem.Parent)
                : resourceChildItem.Name;

            return
                SwaggerDocumentHelper.CamelCaseSegments(
                    $"{resourceChildItem.SchemaProperCaseName}_{name}_{swaggerResource.OperationNamingContext}");
        }

        public string GetEmbeddedObjectReferenceName(SwaggerResource swaggerResource, EmbeddedObject embeddedObject)
        {
            return
                SwaggerDocumentHelper.CamelCaseSegments(
                    $@"{embeddedObject.ObjectType.SchemaProperCaseName}_{embeddedObject.ObjectType.Name}_{swaggerResource.OperationNamingContext}");
        }

        public string GetReferenceName(ResourceClassBase swaggerResource, Reference reference)
        {
            var schemaPrefix = swaggerResource.Entity.DomainModel.SchemaNameMapProvider
                                              .GetSchemaMapByPhysicalName(swaggerResource.Entity.Schema)
                                              .ProperCaseName;

            return SwaggerDocumentHelper.CamelCaseSegments($"{schemaPrefix}_{reference.ReferenceTypeName}");
        }

        public string GetResourceName(Resource resource, ISwaggerResourceContext resourceContext)
        {
            var name = resourceContext.ContextualResource == null
                ? string.Format(
                             @"{0}_{1}_{2}",
                             resource.SchemaProperCaseName,
                             CompositeTermInflector.MakeSingular(resource.Name),
                             resourceContext.OperationNamingContext)
                        .ToCamelCase()
                : string.Format(
                    @"{0}_{1}_{2}_{3}",
                    resource.SchemaProperCaseName,
                    CompositeTermInflector.MakeSingular(resource.Name),
                    resourceContext.ContextualResource.Name,
                    resourceContext.OperationNamingContext);

            return SwaggerDocumentHelper.CamelCaseSegments(name);
        }

        private static string CreateChildModelTypeName(
            ResourceClassBase resourceClassBase,
            string childTypeName,
            ResourceClassBase containingResource)
        {
            if (containingResource is IHasParent)
            {
                return string.Join(
                    "_",
                    new[]
                    {
                        childTypeName
                    }.Concat(
                        (containingResource as IHasParent)
                       .GetLineage()
                       .Select(x => x.Name.ToCamelCase())));
            }

            return $"{childTypeName}_{resourceClassBase.Name}";
        }
    }
}

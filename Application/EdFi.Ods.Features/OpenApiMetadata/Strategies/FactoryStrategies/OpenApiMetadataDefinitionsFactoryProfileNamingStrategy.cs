// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class OpenApiMetadataDefinitionsFactoryProfileNamingStrategy
        : IOpenApiMetadataDefinitionsFactoryNamingStrategy
    {
        public string GetCollectionReferenceName(OpenApiMetadataResource openApiMetadataResource, Collection collection)
        {
            var name = CreateChildModelTypeName(openApiMetadataResource, collection.ItemType);

            return
                OpenApiMetadataDocumentHelper.CamelCaseSegments(
                    $"{collection.ItemType.SchemaProperCaseName}_{name}_{openApiMetadataResource.OperationNamingContext}");
        }

        public string GetContainedItemTypeName(OpenApiMetadataResource openApiMetadataResource, ResourceChildItem resourceChildItem)
        {
            var name = CreateChildModelTypeName(openApiMetadataResource, resourceChildItem);

            return
                OpenApiMetadataDocumentHelper.CamelCaseSegments(
                    $"{resourceChildItem.SchemaProperCaseName}_{name}_{openApiMetadataResource.OperationNamingContext}");
        }

        public string GetEmbeddedObjectReferenceName(OpenApiMetadataResource openApiMetadataResource, EmbeddedObject embeddedObject)
        {
            var name = CreateChildModelTypeName(openApiMetadataResource, embeddedObject.ObjectType);

            return
                OpenApiMetadataDocumentHelper.CamelCaseSegments(
                    $@"{embeddedObject.ObjectType.SchemaProperCaseName}_{name}_{openApiMetadataResource.OperationNamingContext}");
        }

        public string GetReferenceName(ResourceClassBase openApiMetadataResource, Reference reference)
        {
            var schemaPrefix = openApiMetadataResource.Entity.DomainModel.SchemaNameMapProvider
                                              .GetSchemaMapByPhysicalName(openApiMetadataResource.Entity.Schema)
                                              .ProperCaseName;

            return OpenApiMetadataDocumentHelper.CamelCaseSegments($"{schemaPrefix}_{reference.ReferenceTypeName}");
        }

        public string GetResourceName(Resource resource, IOpenApiMetadataResourceContext resourceContext)
        {
            var name = resourceContext.ContextualResource == null
                ? string.Format(
                             @"{0}_{1}_{2}",
                             resource.SchemaProperCaseName,
                             CompositeTermInflector.MakeSingular(resource.Name),
                             resourceContext.OperationNamingContext)
                : string.Format(
                    @"{0}_{1}_{2}_{3}",
                    resource.SchemaProperCaseName,
                    CompositeTermInflector.MakeSingular(resource.Name),
                    resourceContext.ContextualResource.Name,
                    resourceContext.OperationNamingContext);

            return OpenApiMetadataDocumentHelper.CamelCaseSegments(name);
        }

        private static string CreateChildModelTypeName(OpenApiMetadataResource openApiMetadataResource, ResourceChildItem resourceChildItem)
        {
            if (resourceChildItem.IsDerivedFrom(openApiMetadataResource.Resource) != true)
                return resourceChildItem.Name;

            if (resourceChildItem.Parent is IHasParent parent)
            {
                return string.Join(
                    "_",
                    new[]
                    {
                        resourceChildItem.Name
                    }.Concat(
                         parent
                        .GetLineage()
                        .Select(x => x.Name.ToCamelCase())));
            }

            return $"{resourceChildItem.Name}_{openApiMetadataResource.Resource.Name}";
        }
    }
}

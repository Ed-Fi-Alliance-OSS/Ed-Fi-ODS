// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class SwaggerDefinitionsFactoryDefaultNamingStrategy : ISwaggerDefinitionsFactoryNamingStrategy
    {
        public string GetContainedItemTypeName(
            SwaggerResource swaggerResource,
            ResourceChildItem resourceChildItem)
        {
            var schemaPrefix = resourceChildItem.SchemaProperCaseName;
            return SwaggerDocumentHelper.CamelCaseSegments($"{schemaPrefix}_{resourceChildItem.Name}");
        }

        public string GetReferenceName(ResourceClassBase resource, Reference reference)
        {
            var schemaProperCaseName = reference.ReferencedResource.SchemaProperCaseName;

            return SwaggerDocumentHelper.CamelCaseSegments($"{schemaProperCaseName}_{reference.ReferenceTypeName}");
        }

        public string GetEmbeddedObjectReferenceName(
            SwaggerResource swaggerResource,
            EmbeddedObject embeddedObject)
        {
            var schemaPrefix = embeddedObject
                              .ObjectType
                              .Entity
                              .DomainModel
                              .SchemaNameMapProvider
                              .GetSchemaMapByPhysicalName(embeddedObject.ObjectType.Entity.Schema)
                              .ProperCaseName;

            return SwaggerDocumentHelper.CamelCaseSegments($"{schemaPrefix}_{embeddedObject.ObjectType.Name}");
        }

        public string GetCollectionReferenceName(
            SwaggerResource swaggerResource,
            Collection collection)
        {
            var schemaPrefix = collection
                              .ItemType
                              .Entity
                              .DomainModel
                              .SchemaNameMapProvider
                              .GetSchemaMapByPhysicalName(collection.ItemType.Entity.Schema)
                              .ProperCaseName;

            return SwaggerDocumentHelper.CamelCaseSegments($"{schemaPrefix}_{collection.ItemType.Name}");
        }

        public string GetResourceName(Resource resource, ISwaggerResourceContext resourceContext)
        {
            var schemaPrefix = resource
                              .Entity
                              .DomainModel
                              .SchemaNameMapProvider
                              .GetSchemaMapByPhysicalName(resource.Entity.Schema)
                              .ProperCaseName;

            return SwaggerDocumentHelper.CamelCaseSegments($"{schemaPrefix}_{resource.Name}");
        }
    }
}

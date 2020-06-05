// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class SwaggerDefinitionsFactoryCompositeNamingStrategy : ISwaggerDefinitionsFactoryNamingStrategy
    {
        public string GetContainedItemTypeName(
            SwaggerResource swaggerResource,
            ResourceChildItem resourceChildItem)
        {
            return CreateCompositeChildModelTypeName(
                swaggerResource.Resource.Name,
                resourceChildItem.Name,
                resourceChildItem.Parent);
        }

        public string GetReferenceName(ResourceClassBase resource, Reference reference)
        {
            return CreateCompositeChildModelTypeName(
                resource.Name,
                reference.ReferenceTypeName,
                reference.ReferencedResource);
        }

        public string GetEmbeddedObjectReferenceName(
            SwaggerResource swaggerResource,
            EmbeddedObject embeddedObject)
        {
            return CreateCompositeChildModelTypeName(
                swaggerResource.Resource.Name,
                embeddedObject.ObjectType.Name,
                embeddedObject.Parent);
        }

        public string GetCollectionReferenceName(SwaggerResource swaggerResource, Collection collection)
        {
            return CreateCompositeChildModelTypeName(
                swaggerResource.Resource.Name,
                collection.ItemType.Name,
                collection.Parent);
        }

        public string GetResourceName(Resource resource, ISwaggerResourceContext resourceContext)
        {
            return resource.Name.ToCamelCase();
        }

        private static string CreateCompositeChildModelTypeName(string resourceName, string childTypeName, ResourceClassBase containingResource)
        {
            if (containingResource is IHasParent)
            {
                return SwaggerDocumentHelper.CamelCaseSegments(
                    string.Join(
                        "_",
                        ((IHasParent) containingResource)
                       .GetLineage()
                       .Select(x => x.Name.ToCamelCase())
                       .Concat(
                            new[]
                            {
                                childTypeName.ToCamelCase()
                            })));
            }

            return SwaggerDocumentHelper.CamelCaseSegments($"{resourceName.ToCamelCase()}_{childTypeName.ToCamelCase()}");
        }
    }
}

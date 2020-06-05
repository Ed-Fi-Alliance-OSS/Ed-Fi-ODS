// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Common.Utils.Extensions;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public class SwaggerDefinitionsFactory
    {
        private const string ExtensionCollectionKey = "_ext";
        private readonly ISwaggerDefinitionsFactoryEdFiExtensionBridgeStrategy _definitionsFactoryEdFiExtensionBridgeStrategy;
        private readonly ISwaggerDefinitionsFactoryEntityExtensionStrategy _definitionsFactoryEntityExtensionStrategy;
        private readonly ISwaggerDefinitionsFactoryNamingStrategy _swaggerDefinitionsFactoryNamingStrategy;
        private readonly ISwaggerFactoryResourceFilterStrategy _swaggerFactoryResourceFilterStrategy;

        public SwaggerDefinitionsFactory(ISwaggerDefinitionsFactoryEntityExtensionStrategy entityExtensionStrategy,
            ISwaggerDefinitionsFactoryEdFiExtensionBridgeStrategy edFiExtensionBridgeStrategy,
            ISwaggerDefinitionsFactoryNamingStrategy swaggerDefinitionsFactoryNamingStrategy,
            ISwaggerFactoryResourceFilterStrategy swaggerFactoryResourceFilterStrategy)
        {
            _definitionsFactoryEntityExtensionStrategy = entityExtensionStrategy;
            _definitionsFactoryEdFiExtensionBridgeStrategy = edFiExtensionBridgeStrategy;
            _swaggerDefinitionsFactoryNamingStrategy = swaggerDefinitionsFactoryNamingStrategy;
            _swaggerFactoryResourceFilterStrategy = swaggerFactoryResourceFilterStrategy;
        }

        private static Schema EtagSchema
            => new Schema
            {
                type = "string",
                description = "A unique system-generated value that identifies the version of the resource."
            };

        public IDictionary<string, Schema> Create(IList<SwaggerResource> swaggerResources)
        {
            var definitions = BoilerPlateDefinitions();

            swaggerResources.Where(x => _swaggerFactoryResourceFilterStrategy.ShouldInclude(x.Resource)).Select(
                r => new
                {
                    key = _swaggerDefinitionsFactoryNamingStrategy.GetResourceName(r.Resource, r),
                    schema = CreateResourceSchema(r)
                }).GroupBy(d => d?.key).Select(g => g.First()).ForEach(
                d =>
                {
                    if (d != null)
                    {
                        definitions.Add(d.key, d.schema);
                    }
                });

            swaggerResources.SelectMany(
                r => r.Resource.AllContainedItemTypes.Where(x => _swaggerFactoryResourceFilterStrategy.ShouldInclude(x))
                    .Select(
                        i => new
                        {
                            key = _swaggerDefinitionsFactoryNamingStrategy.GetContainedItemTypeName(r, i),
                            schema = CreateResourceChildSchema(i, r)
                        }).Concat(
                        swaggerResources.SelectMany(s => s.Resource.AllContainedReferences).Select(
                            reference => new
                            {
                                key = _swaggerDefinitionsFactoryNamingStrategy.GetReferenceName(r.Resource, reference),
                                schema = SwaggerDocumentHelper.CreateReferenceSchema(reference)
                            }))).GroupBy(d => d?.key).Select(g => g.First()).ForEach(
                d =>
                {
                    if (d != null)
                    {
                        definitions.Add(d.key, d.schema);
                    }
                });

            _definitionsFactoryEntityExtensionStrategy.GetEdFiExtensionBridgeDefinitions(swaggerResources)
                .ForEach(pair => definitions.Add(pair.Key, pair.Value));

            return new SortedDictionary<string, Schema>(definitions);
        }

        private static Schema RefSchema(string referenceName)
            => new Schema {@ref = SwaggerDocumentHelper.GetDefinitionReference(referenceName)};

        private static string CollectionDescription(string pluralName, string description)
            => $"An unordered collection of {pluralName}. {description}";

        private static string ReferenceDescription(string referencedResourceName, string roleName, string otherEntityName)
            => $@"A reference to the related {referencedResourceName} resource for {roleName?.ToLower()}{otherEntityName}.";

        private Schema CreateResourceChildSchema(ResourceChildItem resourceChildItem, SwaggerResource swaggerResource)
        {
            var properties = resourceChildItem.Properties
                .Select(
                    p => new
                    {
                        IsRequired = p.IsIdentifying || !p.PropertyType.IsNullable,
                        Key = UniqueIdSpecification.GetUniqueIdPropertyName(p.JsonPropertyName).ToCamelCase(),
                        Schema = SwaggerDocumentHelper.CreatePropertySchema(p)
                    }).Concat(
                    resourceChildItem.References.Select(
                        r => new
                        {
                            r.IsRequired,
                            Key = r.PropertyName.ToCamelCase(),
                            Schema = new Schema
                            {
                                @ref = SwaggerDocumentHelper.GetDefinitionReference(
                                    _swaggerDefinitionsFactoryNamingStrategy.GetReferenceName(swaggerResource.Resource, r))
                            }
                        })).Concat(
                    resourceChildItem.Collections.Select(
                        c => new
                        {
                            IsRequired = c.Association.IsRequiredCollection,
                            Key = c.JsonPropertyName,
                            Schema = CreateCollectionSchema(c, swaggerResource)
                        })).Concat(
                    resourceChildItem.EmbeddedObjects.Select(
                        e => new
                        {
                            IsRequired = false,
                            Key = e.JsonPropertyName,
                            Schema = CreateEmbeddedObjectSchema(e, swaggerResource)
                        })).ToList();

            var bridgeSchema = GetEdFiExtensionBridgeReferenceSchema(resourceChildItem, swaggerResource);

            if (bridgeSchema != null)
            {
                properties.Add(
                    new
                    {
                        IsRequired = false,
                        Key = ExtensionCollectionKey,
                        Schema = bridgeSchema
                    });
            }

            var requiredProperties = properties.Where(x => x.IsRequired).Select(x => x.Key).ToList();

            return new Schema
            {
                type = "object",
                required = requiredProperties.Any()
                    ? requiredProperties
                    : null,
                properties = properties.ToDictionary(k => k.Key, v => v.Schema)
            };
        }

        private Schema CreateCollectionSchema(Collection collection, SwaggerResource swaggerResource)
        {
            return new Schema
            {
                type = "array",
                description = CollectionDescription(
                    collection.ItemType.PluralName.ToCamelCase(), collection.ItemType.Description.ScrubForOpenApi()),
                items = RefSchema(
                    _swaggerDefinitionsFactoryNamingStrategy.GetCollectionReferenceName(swaggerResource, collection))
            };
        }

        private Schema CreateEmbeddedObjectSchema(EmbeddedObject embeddedObject, SwaggerResource swaggerResource)
        {
            return new Schema
            {
                @ref = SwaggerDocumentHelper.GetDefinitionReference(
                    _swaggerDefinitionsFactoryNamingStrategy.GetEmbeddedObjectReferenceName(swaggerResource, embeddedObject))
            };
        }

        private Schema CreateResourceSchema(SwaggerResource swaggerResource)
        {
            var resource = swaggerResource.Resource;

            var properties = resource.UnifiedKeyAllProperties()
                .Select(
                    x => new PropertySchemaInfo
                    {
                        PropertyName = x.JsonPropertyName,
                        IsRequired = !x.PropertyType.IsNullable && !x.IsServerAssigned,
                        Sort = SortOrder(x.PropertyName, x.IsIdentifying),
                        Schema = SwaggerDocumentHelper.CreatePropertySchema(x)
                    }).Concat(
                    resource.Collections.Select(
                        x => new PropertySchemaInfo
                        {
                            PropertyName = CreateCollectionKey(x),
                            IsRequired = x.Association.IsRequiredCollection,
                            Sort = SortOrder(x.PropertyName, x.Association.IsRequiredCollection),
                            Schema = CreateCollectionSchema(x, swaggerResource)
                        })).Concat(
                    resource.EmbeddedObjects.Select(
                        x => new PropertySchemaInfo
                        {
                            PropertyName = x.JsonPropertyName,
                            Sort = SortOrder(x.PropertyName, false),
                            Schema = CreateEmbeddedObjectSchema(x, swaggerResource)
                        })).Concat(
                    resource.References.Select(
                        x => new PropertySchemaInfo
                        {
                            PropertyName = x.PropertyName,
                            IsRequired = x.IsRequired,
                            IsReference = true,
                            Sort = 3,
                            Schema = new Schema
                            {
                                @ref = SwaggerDocumentHelper.GetDefinitionReference(
                                    _swaggerDefinitionsFactoryNamingStrategy.GetReferenceName(swaggerResource.Resource, x))
                            }

                            // NOTE: currently there is an open issue with swagger-ui to address 
                            // objects showing up in the ui that have a reference and 
                            // other properties within the schema. The standard at this time does
                            // not support this use case. (The error we get is:
                            // Sibling values are not allowed along side $refs.
                            // As of swagger-ui 3.11.0 this has not been resolved.
                            // https://github.com/OAI/OpenAPI-Specification/issues/556
                            // TODO: JSM - Once the standard is updated to accept sibling values along
                            // side with $refs, uncomment the line below
                            // isIdentity = x.Association.IsIdentifying ? true : (bool?) null
                        })).Distinct(new PropertySchemaInfoComparer()).ToList();

            var propertyDict = properties.OrderBy(x => x.Sort).ThenBy(x => x.PropertyName)
                .ToDictionary(x => x.PropertyName.ToCamelCase(), x => x.Schema);

            propertyDict.Add("_etag", EtagSchema);
            var bridgeSchema = GetEdFiExtensionBridgeReferenceSchema(resource, swaggerResource);

            if (bridgeSchema != null)
            {
                propertyDict.Add(ExtensionCollectionKey, bridgeSchema);
            }

            var requiredProperties = properties
                .Where(x => x.IsRequired && !x.PropertyName.EqualsIgnoreCase("id"))
                .Select(x => x.PropertyName.ToCamelCase()).ToList();

            return new Schema
            {
                type = "object",
                required = requiredProperties.Any()
                    ? requiredProperties
                    : null,
                properties = propertyDict
            };
        }

        private Schema GetEdFiExtensionBridgeReferenceSchema(ResourceClassBase resource, ISwaggerResourceContext resourceContext)
        {
            //Handle entity extension bridge.
            if (resource.IsEdFiStandardResource && resource.Entity?.IsLookup != true)
            {
                return _definitionsFactoryEdFiExtensionBridgeStrategy.GetEdFiEntityExtensionBridgeSchema(
                    resource, resourceContext);
            }

            return null;
        }

        private int SortOrder(string propertyName, bool isIdentifying)
        {
            if (propertyName.Equals("Id"))
            {
                return 1;
            }

            return isIdentifying
                ? 2
                : 9;
        }

        private static string CreateCollectionKey(Collection collection)
        {
            return collection.IsDerivedEntityATypeEntity() && collection.Parent.Entity != null && collection.IsInherited
                ? collection.Association.OtherEntity.PluralName.ToCamelCase()
                : collection.JsonPropertyName;
        }

        private static Dictionary<string, Schema> BoilerPlateDefinitions()
        {
            return new Dictionary<string, Schema>
            {
                {
                    "link", new Schema
                    {
                        type = "object",
                        properties = new Dictionary<string, Schema>
                        {
                            {
                                "rel", new Schema
                                {
                                    type = "string",
                                    description = "Describes the nature of the relationship to the referenced resource."
                                }
                            },
                            {
                                "href", new Schema
                                {
                                    type = "string",
                                    description = "The URL to the related resource."
                                }
                            }
                        }
                    }
                }
            };
        }

        private class PropertySchemaInfo
        {
            public string PropertyName { get; set; }

            public Schema Schema { get; set; }

            public bool IsRequired { get; set; }

            public bool IsReference { get; set; }

            public int Sort { get; set; }
        }

        private class PropertySchemaInfoComparer : IEqualityComparer<PropertySchemaInfo>
        {
            public bool Equals(PropertySchemaInfo x, PropertySchemaInfo y)
            {
                return x.PropertyName == y.PropertyName;
            }

            public int GetHashCode(PropertySchemaInfo obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}

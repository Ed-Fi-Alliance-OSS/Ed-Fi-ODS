// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Features.ChangeQueries.Repositories;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public class OpenApiMetadataDefinitionsFactory
    {
        private const string ExtensionCollectionKey = "_ext";
        private readonly IOpenApiMetadataDefinitionsFactoryEdFiExtensionBridgeStrategy _definitionsFactoryEdFiExtensionBridgeStrategy;
        private readonly IOpenApiMetadataDefinitionsFactoryEntityExtensionStrategy _definitionsFactoryEntityExtensionStrategy;
        private readonly IOpenApiMetadataDefinitionsFactoryNamingStrategy _openApiMetadataDefinitionsFactoryNamingStrategy;
        private readonly IOpenApiMetadataFactoryResourceFilterStrategy _openApiMetadataFactoryResourceFilterStrategy;
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;
        private readonly ApiSettings _apiSettings;

        public OpenApiMetadataDefinitionsFactory(IOpenApiMetadataDefinitionsFactoryEntityExtensionStrategy entityExtensionStrategy,
            IOpenApiMetadataDefinitionsFactoryEdFiExtensionBridgeStrategy edFiExtensionBridgeStrategy,
            IOpenApiMetadataDefinitionsFactoryNamingStrategy openApiMetadataDefinitionsFactoryNamingStrategy,
            IOpenApiMetadataFactoryResourceFilterStrategy openApiMetadataFactoryResourceFilterStrategy,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider,
            ApiSettings apiSettings)
        {
            _definitionsFactoryEntityExtensionStrategy = entityExtensionStrategy;
            _definitionsFactoryEdFiExtensionBridgeStrategy = edFiExtensionBridgeStrategy;
            _openApiMetadataDefinitionsFactoryNamingStrategy = openApiMetadataDefinitionsFactoryNamingStrategy;
            _openApiMetadataFactoryResourceFilterStrategy = openApiMetadataFactoryResourceFilterStrategy;
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
            _apiSettings = apiSettings;
        }

        private static Schema EtagSchema
            => new Schema
            {
                type = "string",
                description = "A unique system-generated value that identifies the version of the resource."
            };

        public IDictionary<string, Schema> Create(IList<OpenApiMetadataResource> openApiMetadataResources)
        {
            var definitions = BoilerPlateDefinitions();
            var isChangeQueriesEnabled = _apiSettings.IsFeatureEnabled("ChangeQueries");

            openApiMetadataResources
                .Where(x => _openApiMetadataFactoryResourceFilterStrategy.ShouldInclude(x.Resource))
                .SelectMany(
                    r => new[]
                    {
                        new
                        {
                            key = _openApiMetadataDefinitionsFactoryNamingStrategy.GetResourceName(r.Resource, r),
                            schema = CreateResourceSchema(r)
                        },
                        isChangeQueriesEnabled
                            ? new
                            {
                                key = GetTrackedChangesResourceKeyName(r.Resource, r),
                                schema = CreateTrackedChangesKeySchema(r)
                            }
                            : null,
                        isChangeQueriesEnabled
                            ? new
                            {
                                key = GetTrackedChangesResourceDeleteName(r.Resource, r),
                                schema = CreateTrackedChangesDeletesSchema(r)
                            }
                            : null,
                        isChangeQueriesEnabled
                            ? new
                            {
                                key = GetTrackedChangesResourceKeyChangeName(r.Resource, r),
                                schema = CreateTrackedChangesKeyChangesSchema(r)
                            }
                            : null
                    })
                .Where(d => d != null)
                .GroupBy(d => d.key).Select(g => g.First())
                .ForEach(d => definitions.Add(d.key, d.schema));

            openApiMetadataResources.SelectMany(
                r => r.Resource.AllContainedItemTypes.Where(x => _openApiMetadataFactoryResourceFilterStrategy.ShouldInclude(x))
                    .Select(
                        i => new
                        {
                            key = _openApiMetadataDefinitionsFactoryNamingStrategy.GetContainedItemTypeName(r, i),
                            schema = CreateResourceChildSchema(i, r)
                        }).Concat(
                        openApiMetadataResources.SelectMany(s => s.Resource.AllContainedReferences).Select(
                            reference => new
                            {
                                key = _openApiMetadataDefinitionsFactoryNamingStrategy.GetReferenceName(r.Resource, reference),
                                schema = OpenApiMetadataDocumentHelper.CreateReferenceSchema(reference)
                            }))).GroupBy(d => d?.key).Select(g => g.First()).ForEach(
                d =>
                {
                    if (d != null)
                    {
                        definitions.Add(d.key, d.schema);
                    }
                });

            _definitionsFactoryEntityExtensionStrategy.GetEdFiExtensionBridgeDefinitions(openApiMetadataResources)
                .ForEach(pair => definitions.Add(pair.Key, pair.Value));

            return new SortedDictionary<string, Schema>(definitions);
        }

        private static Schema RefSchema(string referenceName)
            => new Schema { @ref = OpenApiMetadataDocumentHelper.GetDefinitionReference(referenceName) };

        private static string CollectionDescription(string pluralName, string description)
            => $"An unordered collection of {pluralName}. {description}";

        private static string ReferenceDescription(string referencedResourceName, string roleName, string otherEntityName)
            => $@"A reference to the related {referencedResourceName} resource for {roleName?.ToLower()}{otherEntityName}.";

        private Schema CreateResourceChildSchema(ResourceChildItem resourceChildItem, OpenApiMetadataResource openApiMetadataResource)
        {
            var properties = resourceChildItem.Properties
                .Select(
                    p => new
                    {
                        IsRequired = p.IsIdentifying || !p.PropertyType.IsNullable,
                        Key = UniqueIdSpecification.GetUniqueIdPropertyName(p.JsonPropertyName).ToCamelCase(),
                        Schema = OpenApiMetadataDocumentHelper.CreatePropertySchema(p)
                    }).Concat(
                    resourceChildItem.References.Select(
                        r => new
                        {
                            r.IsRequired,
                            Key = r.PropertyName.ToCamelCase(),
                            Schema = new Schema
                            {
                                @ref = OpenApiMetadataDocumentHelper.GetDefinitionReference(
                                    _openApiMetadataDefinitionsFactoryNamingStrategy.GetReferenceName(openApiMetadataResource.Resource, r))
                            }
                        })).Concat(
                    resourceChildItem.Collections.Select(
                        c => new
                        {
                            IsRequired = c.Association.IsRequiredCollection,
                            Key = c.JsonPropertyName,
                            Schema = CreateCollectionSchema(c, openApiMetadataResource)
                        })).Concat(
                    resourceChildItem.EmbeddedObjects.Select(
                        e => new
                        {
                            IsRequired = false,
                            Key = e.JsonPropertyName,
                            Schema = CreateEmbeddedObjectSchema(e, openApiMetadataResource)
                        })).ToList();

            var bridgeSchema = GetEdFiExtensionBridgeReferenceSchema(resourceChildItem, openApiMetadataResource);

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

        private Schema CreateCollectionSchema(Collection collection, OpenApiMetadataResource openApiMetadataResource)
        {
            return new Schema
            {
                type = "array",
                description = CollectionDescription(
                    collection.ItemType.PluralName.ToCamelCase(), collection.ItemType.Description.ScrubForOpenApi()),
                items = RefSchema(
                    _openApiMetadataDefinitionsFactoryNamingStrategy.GetCollectionReferenceName(openApiMetadataResource, collection))
            };
        }

        private Schema CreateEmbeddedObjectSchema(EmbeddedObject embeddedObject, OpenApiMetadataResource openApiMetadataResource)
        {
            return new Schema
            {
                @ref = OpenApiMetadataDocumentHelper.GetDefinitionReference(
                    _openApiMetadataDefinitionsFactoryNamingStrategy.GetEmbeddedObjectReferenceName(openApiMetadataResource, embeddedObject))
            };
        }

        /// <summary>
        /// Creates a schema that only contains the natural keys of a resource.
        /// </summary>
        private Schema CreateTrackedChangesKeySchema(OpenApiMetadataResource openApiMetadataResource)
        {
            var resource = openApiMetadataResource.Resource;

            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            var identifierProperties = identifierProjections
                .SelectMany(
                    p => p.IsDescriptorUsage
                        ? new[] {p.JsonPropertyName}
                        : p.SelectColumns.Select(i => i.JsonPropertyName))
                .Distinct()
                .Select(
                    p => new PropertySchemaInfo
                    {
                        PropertyName = p,
                        Schema = OpenApiMetadataDocumentHelper.CreatePropertySchema(
                            resource.AllProperties.FirstOrDefault(rp => p == rp.JsonPropertyName) ??
                            throw new Exception(
                                $"The natural key '{p}' of the resource '{resource.FullName}' wasn't found in its model.")
                        )
                    });

            return new Schema
            {
                type = "object",
                properties = identifierProperties.ToDictionary(x => x.PropertyName.ToCamelCase(), x => x.Schema)
            };
        }

        private Schema CreateTrackedChangesDeletesSchema(OpenApiMetadataResource openApiMetadataResource)
        {
            return new Schema
            {
                type = "object",
                properties = new Dictionary<string, Schema>
                {
                    {
                        "id", new Schema
                        {
                            type = "string",
                            description = "Resource identifier"
                        }
                    },
                    {
                        "changeVersion", new Schema
                        {
                            type = "number",
                            description = "Change version"
                        }
                    },
                    {
                        "keyValues", RefSchema(GetTrackedChangesResourceKeyName(openApiMetadataResource.Resource, openApiMetadataResource))
                    }
                }
            };
        }

        private Schema CreateTrackedChangesKeyChangesSchema(OpenApiMetadataResource openApiMetadataResource)
        {
            return new Schema
            {
                type = "object",
                properties = new Dictionary<string, Schema>
                {
                    {
                        "id", new Schema
                        {
                            type = "string",
                            description = "Resource identifier"
                        }
                    },
                    {
                        "changeVersion", new Schema
                        {
                            type = "number",
                            description = "Change version"
                        }
                    },
                    {
                        "oldKeyValues", RefSchema(GetTrackedChangesResourceKeyName(openApiMetadataResource.Resource, openApiMetadataResource))
                    },
                    {
                        "newKeyValues", RefSchema(GetTrackedChangesResourceKeyName(openApiMetadataResource.Resource, openApiMetadataResource))
                    }
                }
            };
        }

        private Schema CreateResourceSchema(OpenApiMetadataResource openApiMetadataResource)
        {
            var resource = openApiMetadataResource.Resource;

            var properties = resource.UnifiedKeyAllProperties()
                .Select(
                    x => new PropertySchemaInfo
                    {
                        PropertyName = x.JsonPropertyName,
                        IsRequired = !x.PropertyType.IsNullable && !x.IsServerAssigned,
                        Sort = SortOrder(x.PropertyName, x.IsIdentifying),
                        Schema = OpenApiMetadataDocumentHelper.CreatePropertySchema(x)
                    }).Concat(
                    resource.Collections.Select(
                        x => new PropertySchemaInfo
                        {
                            PropertyName = CreateCollectionKey(x),
                            IsRequired = x.Association.IsRequiredCollection,
                            Sort = SortOrder(x.PropertyName, x.Association.IsRequiredCollection),
                            Schema = CreateCollectionSchema(x, openApiMetadataResource)
                        })).Concat(
                    resource.EmbeddedObjects.Select(
                        x => new PropertySchemaInfo
                        {
                            PropertyName = x.JsonPropertyName,
                            Sort = SortOrder(x.PropertyName, false),
                            Schema = CreateEmbeddedObjectSchema(x, openApiMetadataResource)
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
                                @ref = OpenApiMetadataDocumentHelper.GetDefinitionReference(
                                    _openApiMetadataDefinitionsFactoryNamingStrategy.GetReferenceName(openApiMetadataResource.Resource, x))
                            }

                            // NOTE: currently there is an open issue with openApiMetadata-ui to address
                            // objects showing up in the ui that have a reference and
                            // other properties within the schema. The standard at this time does
                            // not support this use case. (The error we get is:
                            // Sibling values are not allowed along side $refs.
                            // As of openApiMetadata-ui 3.11.0 this has not been resolved.
                            // https://github.com/OAI/OpenAPI-Specification/issues/556
                            // TODO: JSM - Once the standard is updated to accept sibling values along
                            // side with $refs, uncomment the line below
                            // isIdentity = x.Association.IsIdentifying ? true : (bool?) null
                        })).Distinct(new PropertySchemaInfoComparer()).ToList();

            var propertyDict = properties.OrderBy(x => x.Sort).ThenBy(x => x.PropertyName)
                .ToDictionary(x => x.PropertyName.ToCamelCase(), x => x.Schema);

            propertyDict.Add("_etag", EtagSchema);
            var bridgeSchema = GetEdFiExtensionBridgeReferenceSchema(resource, openApiMetadataResource);

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

        private Schema GetEdFiExtensionBridgeReferenceSchema(ResourceClassBase resource, IOpenApiMetadataResourceContext resourceContext)
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

        private string GetTrackedChangesResourceKeyName(Resource resource, IOpenApiMetadataResourceContext resourceContext)
            => $"trackedChanges_{_openApiMetadataDefinitionsFactoryNamingStrategy.GetResourceName(resource, resourceContext)}Key";

        private string GetTrackedChangesResourceDeleteName(Resource resource, IOpenApiMetadataResourceContext resourceContext)
            => $"trackedChanges_{_openApiMetadataDefinitionsFactoryNamingStrategy.GetResourceName(resource, resourceContext)}Delete";

        private string GetTrackedChangesResourceKeyChangeName(Resource resource, IOpenApiMetadataResourceContext resourceContext)
            => $"trackedChanges_{_openApiMetadataDefinitionsFactoryNamingStrategy.GetResourceName(resource, resourceContext)}KeyChange";

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

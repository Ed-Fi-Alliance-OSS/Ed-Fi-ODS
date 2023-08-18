// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Generators.Resources
{
    public class ResourceCollectionRenderer
    {
        public object InheritedCollections(ResourceClassBase resource)
        {
            if (resource.IsDescriptorEntity())
            {
                return ResourceRenderer.DoRenderProperty;
            }

            return resource.IsDerived && resource.Collections.Any()
                ? new
                {
                    Inherited =
                        resource.Collections
                            .Where(x => x.IsInherited)
                            .OrderBy(x => x.PropertyName)
                            .Select(
                                x => new
                                {
                                    BaseEntity =
                                        $"{resource.Entity.BaseEntity.Name}.{resource.Entity.BaseEntity.SchemaProperCaseName()}",
                                    BaseEntityInterfaceName = $"I{resource.Entity.BaseEntity.Name}",
                                    ItemTypeNamespacePrefix = GetContextualNamespacePrefix(x.ItemType),
                                    ItemType = x.ItemType.Name,
                                    Collection = x.ItemType.PluralName,
                                    PropertyName = x.PropertyName,
                                    JsonPropertyName =
                                        x.IsDerivedEntityATypeEntity()
                                            ? x.Association.OtherEntity.PluralName.ToCamelCase()
                                            : x.JsonPropertyName,
                                    PropertyFieldName = x.ItemType.PluralName.ToCamelCase(),
                                    ParentName = x.ParentFullName.Name,
                                    ResourceName = resource.Name,
                                })
                            .ToList()
                }
                : ResourceRenderer.DoNotRenderProperty;
        }

        public object Collections(ResourceClassBase resourceClass)
        {
            var collectionPairs = Resources.GetMemberItemPairs(resourceClass, r => r?.Collections);

            return collectionPairs
                .Where( c => !c.IsInherited)
                .OrderBy(c => c.PropertyName)
                .Select(
                    c => new
                    {
                        ItemTypeNamespacePrefix = GetContextualNamespacePrefix(c.ItemType),
                        ItemType = c.ItemType.Name,
                        Collection = c.ItemType.PluralName,
                        PropertyName = c.PropertyName,
                        JsonPropertyName = c.JsonPropertyName,
                        PropertyFieldName = c.ItemType.PluralName.ToCamelCase(),
                        ParentName = c.ParentFullName.Name,
                        BaseEntity = resourceClass.Name
                    })
                .ToList();
        }

        private static string GetContextualNamespacePrefix(ResourceChildItem resourceChildItem)
        {
            var schemaNameMapProvider = resourceChildItem.Entity.DomainModel.SchemaNameMapProvider;

            // TODO: Embedded Convention - relative namespace prefix for extension interfaces
            return "Entities.Common."
                + schemaNameMapProvider.GetSchemaMapByPhysicalName(resourceChildItem.FullName.Schema)
                    .ProperCaseName
                + ".";
        }

        public object FilteredDelegates(ResourceClassBase resourceClass)
        {
            var collections = Resources.GetMemberItemPairs(resourceClass, r => r?.Collections);

            if (!collections.Any())
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            var toRender = new List<object>();

            //unfiltered objects
            toRender.AddRange(
                collections
                    .Select(
                        c => new
                        {
                            ItemTypeNamespacePrefix = c.ItemType.GetNamespacePrefix(),
                            ItemType = c.ItemType.Name,
                            PropertyName = c.ItemType.Name,
                            ParentName =
                                resourceClass.IsDerived && !resourceClass.IsDescriptorEntity()
                                    ? resourceClass.Entity.Aggregate.Name
                                    : c.ParentFullName.Name,
                        }));

            return toRender.Any()
                ? toRender
                : ResourceRenderer.DoNotRenderProperty;
        }

        public class PutPostRequestValidatorCollectionProperty {
            public string PropertyName { get; set; }

            public string PropertyFieldNamePrefix { get; set; }

            public string ItemTypeName { get; set; }

            public object Namespace { get; set; }
        }

        public class UnifiedReferenceProperty {
            public string ReferenceName { get; set; }

            public string ReferenceJsonName { get; set; }

            public string ReferencePropertyName { get; set; }

            public string ReferenceJsonPropertyName { get; set; }
        }

        public class UnifiedProperty
        {
            public string UnifiedPropertyName { get; set; }

            public string UnifiedJsonPropertyName { get; set; }

            public string UnifiedCSharpPropertyType { get; set; }

            public bool UnifiedPropertyIsFromParent { get; set; }

            public bool UnifiedPropertyIsLocallyDefined { get; set; }

            public string UnifiedPropertyParentPath { get; set; }

            public IEnumerable<UnifiedReferenceProperty> References { get; set; }
        }

        public class KeyUnificationValidation
        {
            public string ResourceClassName { get; set; }

            public string ParentResourceClassName { get; set; }

            public IEnumerable<UnifiedProperty> UnifiedProperties { get; set; }
        }

        public class PutPostRequestValidator
        {
            public string Schema { get; set; }

            public string EntityName { get; set; }

            public bool HasCollections { get; set; }
            
            public IEnumerable<PutPostRequestValidatorCollectionProperty> Collections { get; set; }

            public KeyUnificationValidation KeyUnificationValidations { get; set; }

            /// <summary>
            /// The fully qualified namespace prefix that can be used for extension artifacts to ensure they can be delineated
            /// from Ed-Fi Standard artifacts by the compiler (e.g. global::EdFi...).
            /// </summary>
            public string ExtensionNamespacePrefix { get; set; }
        }

        public object CreatePutPostRequestValidator(
            ResourceData data,
            ResourceClassBase resource,
            TemplateContext templateContext)
        {
            var resourceChildItem = resource as ResourceChildItem;
            return new PutPostRequestValidator
            {
                Schema = resource.FullName.Schema,
                EntityName = resource.Name,
                ExtensionNamespacePrefix = templateContext.IsExtension
                    ? $"global::EdFi.Ods.Entities.Common.{resource.SchemaProperCaseName}."
                    : null,
                HasCollections = resource.Collections.Any(), 
                Collections = resource.Collections
                    .Select(
                        collection => new PutPostRequestValidatorCollectionProperty
                        {
                            PropertyName = collection.PropertyName,
                            PropertyFieldNamePrefix = collection.PropertyName.ToCamelCase(),
                            ItemTypeName = collection.ItemType.Name,
                            Namespace = collection.ParentFullName.Name != resource.Name
                                ? string.Format(
                                    "{0}.{1}.",
                                    collection.ParentFullName.Name,
                                    resource.Entity.BaseEntity.SchemaProperCaseName())
                                : ResourceRenderer.DoNotRenderProperty
                        }),
                KeyUnificationValidations = new KeyUnificationValidation
                {
                    ResourceClassName = resource.Name,
                    ParentResourceClassName = resourceChildItem?.Parent.Name,
                    UnifiedProperties = resource.AllProperties
                        .Where(rp => rp.IsUnified())
                        .Select(rp => new UnifiedProperty
                        {
                            UnifiedPropertyName = rp.PropertyName,
                            UnifiedJsonPropertyName = rp.JsonPropertyName,
                            UnifiedCSharpPropertyType = rp.PropertyType.ToCSharp(),
                            UnifiedPropertyIsFromParent = rp.EntityProperty.IncomingAssociations
                                .Any(a => a.IsNavigable),
                            UnifiedPropertyIsLocallyDefined = rp.IsLocallyDefined,
                            UnifiedPropertyParentPath = resourceChildItem is
                                {
                                    IsResourceExtension: true,
                                    IsResourceExtensionClass: false, 
                                }
                                ? string.Join(
                                    string.Empty,
                                    resourceChildItem.GetLineage().TakeWhile(l => !l.IsResourceExtension)
                                        .Select(l => "." + l.Name))
                                : null,
                            References = rp.EntityProperty.IncomingAssociations
                                .Where(a => !a.IsNavigable && rp.Parent.ReferenceByName.ContainsKey(a.Name + "Reference"))
                                .Select(a => new
                                {
                                    Reference = rp.Parent.ReferenceByName[a.Name + "Reference"],
                                    OtherEntityPropertyName = a.PropertyMappings.Where(pm => pm.ThisProperty.Equals(rp.EntityProperty)).Select(pm => pm.OtherProperty.PropertyName).Single(),
                                })
                                .Select(x => new
                                {
                                    Reference = x.Reference,
                                    ReferenceProperty =
                                        (x.Reference.ReferenceTypeProperties
                                                .SingleOrDefault(rtp => rtp.EntityProperty.PropertyName == x.OtherEntityPropertyName)
                                            // Deal with the special case of the re-pointing of the identifying property from USI to UniqueId in Person entities
                                            ?? x.Reference.ReferenceTypeProperties
                                                .Single(rtp => rtp.EntityProperty.PropertyName ==
                                                    UniqueIdConventions.GetUniqueIdPropertyName(x.OtherEntityPropertyName)))
                                })
                                .Select(x => new UnifiedReferenceProperty
                                {
                                    ReferenceName = x.Reference.PropertyName,
                                    ReferenceJsonName = x.Reference.JsonPropertyName,
                                    ReferencePropertyName = x.ReferenceProperty.PropertyName,
                                    ReferenceJsonPropertyName = x.ReferenceProperty.JsonPropertyName
                                })
                        })
                }
            };
        }

        public object References(ResourceData data, ResourceClassBase resource)
        {
            var references = resource.References.ToList();

            if (!references.Any())
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            if (resource.IsAggregateRoot() || !resource.HasBackReferences())
            {
                return new
                {
                    Collections = references
                        .OrderBy(x => x.PropertyName)
                        .Select(
                            x =>
                            {
                                bool renderNamespace =
                                    !(x.Association.IsSelfReferencing
                                        || x.Association.IsSelfReferencingManyToMany)
                                    || x.Association.OtherEntity.IsAbstract
                                    || !x.Association.OtherEntity.IsSameAggregate(
                                        resource.Entity);

                                string referenceName = !renderNamespace
                                    ? x.ReferenceTypeName
                                    : $"{x.ReferencedResourceName}.{x.ReferencedResource.Entity.SchemaProperCaseName()}.{x.ReferenceTypeName}";

                                return new
                                {
                                    Reference = new
                                    {
                                        ReferencedResourceName = x.ReferencedResourceName,
                                        ReferenceTypeName =
                                            !x.ReferencedResource.Entity
                                                .IsExtensionEntity
                                            && !x.ReferenceTypeName.Replace("Reference", string.Empty)
                                                .Equals(resource.Name)
                                            && !x.ReferenceTypeName.Replace("Reference", string.Empty)
                                                .Equals((resource as ResourceChildItem)?.Parent.Name)
                                                ? $"{x.ReferencedResourceName}.{EdFiConventions.ProperCaseName}.{x.ReferenceTypeName}"
                                                : referenceName,
                                        Name = x.ParentFullName.Name,

                                        // using the property name so we do not break the data member contract
                                        // from the original template.
                                        JsonPropertyName = x.PropertyName.ToCamelCase(),
                                        PropertyName = x.PropertyName,
                                        PropertyFieldName = x.PropertyName.ToCamelCase(),
                                        IsRequired = x.IsRequired,
                                        IsIdentifying = x.Association.IsIdentifying,
                                    },
                                    Standard = ResourceRenderer.DoRenderProperty
                                };
                            }
                        )
                        .ToList()
                };
            }

            return new
            {
                Collections = resource.References
                    .OrderBy(x => x.PropertyName)
                    .Select(
                        x => new
                        {
                            Reference = new
                            {
                                ReferencedResourceName = x.ReferencedResourceName,
                                ReferenceTypeName = x.ReferenceTypeName,
                                Name = x.ParentFullName.Name,
                                JsonPropertyName = x.JsonPropertyName,
                                PropertyName = x.PropertyName,
                                PropertyFieldName = x.PropertyName.ToCamelCase(),
                                IsRequired = x.IsRequired,
                                IsIdentifying = x.Association.IsIdentifying,
                                BackReferenceType =
                                    string.Format(
                                        "{0}To{1}Reference",
                                        x.Association.ThisEntity.Name,
                                        x.Association.OtherEntity.Name)
                            },
                            Backref = ResourceRenderer.DoRenderProperty
                        }
                    )
                    .ToList()
            };
        }
        public object OnDeserialize(ResourceData data, ResourceClassBase resource, TemplateContext TemplateContext)
        {
            bool shouldRender = !(!data.HasNavigableChildren(resource));

            if (!(resource.Collections.Any() || !resource.IsAggregateRoot() && resource.HasBackReferences()))
            {
                shouldRender = false;
            }

            if (!shouldRender)
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            if (resource.IsDerived && !resource.IsDescriptorEntity())
            {
                return new
                {
                    Inherited = resource.Collections.Any(x => x.IsInherited)
                        ? ResourceRenderer.DoRenderProperty
                        : ResourceRenderer.DoNotRenderProperty,
                    InheritedCollections = resource.Collections.Where(x => x.IsInherited)
                        .OrderBy(x => x.PropertyName)
                        .Select(
                            x => new
                            {
                                PropertyFieldName =
                                    x.ItemType.PluralName.ToCamelCase()
                            })
                        .ToList(),
                    Standard = resource.Collections.Any(x => !x.IsInherited)
                        ? ResourceRenderer.DoRenderProperty
                        : ResourceRenderer.DoNotRenderProperty,
                    Collections = resource.Collections
                        .Where(x => !x.IsInherited && TemplateContext.ShouldRenderEntity(x.ItemType.Entity))
                        .OrderBy(x => x.PropertyName)
                        .Select(
                            x => new
                            {
                                ItemType = x.ItemType.Name,
                                Collection = x.ItemType.PluralName,
                                PropertyName = x.PropertyName,

                                // using the property name so we do not break the data member contract
                                // from the original template.
                                JsonPropertyName = x.PropertyName
                                    .TrimPrefix(x.ParentFullName.Name)
                                    .ToCamelCase(),
                                PropertyFieldName = x.ItemType.PluralName.ToCamelCase(),
                                ParentName = x.ParentFullName.Name
                            })
                        .ToList()
                };
            }

            if (resource.Collections.Any() || !resource.IsAggregateRoot() && resource.References.Any())
            {
                return new
                {
                    BackRef = !resource.IsAggregateRoot() && resource.HasBackReferences()
                        ? ResourceRenderer.DoRenderProperty
                        : ResourceRenderer.DoNotRenderProperty,
                    BackRefCollections = resource.References
                        .OrderBy(x => x.PropertyName)
                        .Select(
                            x => new
                            {
                                ReferenceTypeName = x.ReferenceTypeName,
                                PropertyFieldName = x.PropertyName.ToCamelCase()
                            })
                        .ToList(),
                    Standard = resource.Collections.Any(x => !x.IsInherited)
                        ? ResourceRenderer.DoRenderProperty
                        : ResourceRenderer.DoNotRenderProperty,
                    Collections = resource.Collections
                        .OrderBy(x => x.PropertyName)
                        .Select(
                            x => new
                            {
                                ItemType = x.ItemType.Name,
                                Collection = x.ItemType.PluralName,
                                PropertyName = x.PropertyName,

                                // using the property name so we do not break the data member contract
                                // from the original template.
                                JsonPropertyName = x.PropertyName
                                    .TrimPrefix(x.ParentFullName.Name)
                                    .ToCamelCase(),
                                PropertyFieldName = x.ItemType.PluralName.ToCamelCase(),
                                ParentName = x.ParentFullName.Name
                            })
                        .ToList(),
                    Inherited = resource.Collections.Any(x => x.IsInherited)
                        ? ResourceRenderer.DoRenderProperty
                        : ResourceRenderer.DoNotRenderProperty,
                    InheritedCollections = resource.Collections.Where(x => x.IsInherited)
                        .OrderBy(x => x.PropertyName)
                        .Select(x => new {PropertyFieldName = x.ItemType.PluralName.ToCamelCase()})
                        .ToList()
                };
            }

            return ResourceRenderer.DoNotRenderProperty;
        }

        public object NavigableOneToOnes(ResourceClassBase resourceClass)
        {
            var embeddedObjects = Resources.GetMemberItemPairs(resourceClass, r => r?.EmbeddedObjects);

            return embeddedObjects
                .Where(eo => !eo.IsInherited)
                .OrderBy(eo => eo.PropertyName)
                .Select(
                    eo => new
                    {
                        JsonPropertyName = eo.JsonPropertyName,
                        EmbeddedObjectNamespacePrefix = GetContextualNamespacePrefix(eo.ObjectType),
                        EmbeddedObjectType = eo.PropertyName,
                        PropertyName = eo.PropertyName,
                        ParentName = resourceClass.Name,
                    })
                .ToList();
        }

        public object InheritedNavigableOneToOnes(ResourceClassBase resourceClass)
        {
            var embeddedObjects = Resources.GetMemberItemPairs(resourceClass, r => r?.EmbeddedObjects);

            return embeddedObjects
                .Where(eo => eo.IsInherited)
                .OrderBy(eo => eo.PropertyName)
                .Select(
                    eo => new
                    {
                        JsonPropertyName = eo.JsonPropertyName,
                        EmbeddedObjectInterfaceNamespacePrefix = GetContextualNamespacePrefix(eo.ObjectType),
                        EmbeddedObjectInterfaceType = "I" + eo.PropertyName,
                        EmbeddedObjectTypeNamespace =
                            $"{Namespaces.Resources.RelativeNamespace}.{resourceClass.Entity.BaseEntity.Name}.{resourceClass.Entity.BaseEntity.SchemaProperCaseName()}.",
                        EmbeddedObjectType = eo.PropertyName,
                        PropertyName = eo.PropertyName,
                        BaseEntityNamespacePrefix =
                            $"{Namespaces.Entities.Common.RelativeNamespace}.{resourceClass.Entity.BaseEntity.SchemaProperCaseName()}.",
                        BaseEntityName = resourceClass.Entity.BaseEntity.Name,
                    })
                .ToList();
        }
    }
}

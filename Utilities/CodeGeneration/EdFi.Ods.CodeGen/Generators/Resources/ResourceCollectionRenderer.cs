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

namespace EdFi.Ods.CodeGen.Generators.Resources
{
    public class ResourceCollectionRenderer
    {
        public object InheritedCollections(
            ResourceProfileData profileData,
            ResourceClassBase resource,
            TemplateContext templateContext)
        {
            if (resource.IsDescriptorEntity())
            {
                return ResourceRenderer.DoRenderProperty;
            }

            string ns = profileData.GetProfileNamespace(resource);

            var activeResource = profileData.GetProfileActiveResource(resource);

            return activeResource.IsDerived && activeResource.Collections.Any()
                ? new
                {
                    Inherited =
                        activeResource.Collections
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
                                    PropertyNamespace = ns,
                                    ResourceName = resource.Name,
                                    Standard =
                                        profileData.IsIncluded(resource, x)
                                        && !profileData.IsFilteredCollection(resource, x),
                                    Null = !profileData.IsIncluded(resource, x),
                                    Filtered = profileData.IsIncluded(resource, x)
                                        && profileData.IsFilteredCollection(
                                            resource,
                                            x)
                                })
                            .ToList()
                }
                : ResourceRenderer.DoNotRenderProperty;
        }

        public object Collections(
            ResourceProfileData profileData,
            ResourceClassBase resourceClass,
            TemplateContext TemplateContext)
        {
            var collectionPairs = Resources.GetMemberItemPairs(resourceClass, r => r?.Collections);

            string ns = profileData.GetProfileNamespace(resourceClass);

            return collectionPairs
                .Where(
                    itemPair =>
                        !itemPair.Underlying.IsInherited)
                .OrderBy(x => x.Underlying.PropertyName)
                .Select(
                    itemPair => new
                    {
                        ItemTypeNamespacePrefix = GetContextualNamespacePrefix(itemPair.Underlying.ItemType),
                        ItemType = itemPair.Underlying.ItemType.Name,
                        Collection = itemPair.Underlying.ItemType.PluralName,
                        PropertyName = itemPair.Underlying.PropertyName,
                        JsonPropertyName = itemPair.Underlying.JsonPropertyName,
                        PropertyFieldName = itemPair.Underlying.ItemType.PluralName.ToCamelCase(),
                        ParentName = itemPair.Underlying.ParentFullName.Name,
                        PropertyNamespace = ns,
                        Standard =

                            // It's included
                            itemPair.Current != null

                            // It's not filtered
                            && !itemPair.Current.ValueFilters.Any(),
                        Null = itemPair.Current == null,
                        Filtered =

                            // It's included
                            itemPair.Current != null

                            // It's filtered
                            && itemPair.Current.ValueFilters.Any(),
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

        public object SynchronizationSourceSupport(
            ResourceProfileData profileData,
            ResourceClassBase resourceClass,
            TemplateContext TemplateContext)
        {
            var collectionPairs = Resources.GetMemberItemPairs(resourceClass, r => r?.Collections);

            var synchSupportCollections =
                collectionPairs.Select(
                    itemPair =>
                    {
                        bool isExcluded = itemPair.Current == null;

                        return new
                        {
                            ParentName =
                                resourceClass.IsDerived
                                    ? resourceClass.Name
                                    : itemPair.Underlying.Parent.Name,
                            PropertyName = itemPair.Underlying.ItemType.PluralName,
                            IsExcluded = isExcluded
                        };
                    });

            // Properties
            var allPossibleProperties = resourceClass.FilterContext.UnfilteredResourceClass?.AllProperties ??
                resourceClass.AllProperties;

            var currentProperties = resourceClass.AllProperties;

            var propertyPairs =
                (from p in allPossibleProperties
                    join c in currentProperties on p.PropertyName equals c.PropertyName into leftJoin
                    from _c in leftJoin.DefaultIfEmpty()
                    where p.IsSynchronizable()
                    orderby p.PropertyName
                    select new
                    {
                        UnderlyingProperty = p,
                        CurrentProperty = _c
                    })
                .ToList();

            var synchSupportProperties =
                propertyPairs.Select(
                        x =>
                        {
                            bool isExcluded = x.CurrentProperty == null;

                            return new
                            {
                                ParentName = x.UnderlyingProperty.Parent != null
                                    ? x.UnderlyingProperty.Parent.Name
                                    : resourceClass.Name,
                                PropertyName = x.UnderlyingProperty.PropertyName,
                                IsExcluded = isExcluded
                            };
                        })
                    .ToList();

            // Embedded Objects
            var allPossibleEmbeddedObjects = resourceClass.FilterContext.UnfilteredResourceClass?.EmbeddedObjects ??
                resourceClass.EmbeddedObjects;

            var currentEmbeddedObjects = resourceClass.EmbeddedObjects;

            var embeddedObjectPairs =
                (from p in allPossibleEmbeddedObjects
                    join c in currentEmbeddedObjects on p.PropertyName equals c.PropertyName into leftJoin
                    from _c in leftJoin.DefaultIfEmpty()
                    orderby p.PropertyName
                    select new
                    {
                        UnderlyingEmbeddedObject = p,
                        CurrentEmbeddedObject = _c
                    })
                .ToList();

            var synchSupportEmbeddedObjects =
                embeddedObjectPairs.Select(
                    x => new
                    {
                        ParentName = x.UnderlyingEmbeddedObject.Parent.Name,
                        PropertyName = x.UnderlyingEmbeddedObject.PropertyName,
                        IsExcluded = x.CurrentEmbeddedObject == null
                    });

            var synchSupportMembers =
                synchSupportCollections
                    .Concat(synchSupportProperties)
                    .Concat(synchSupportEmbeddedObjects)
                    .ToList();

            if (!synchSupportMembers.Any())
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            int horizontalSpaceAllocation = synchSupportMembers.Max(x => x.PropertyName.Length)
                + "IsSupported".Length + 1;

            return
                synchSupportMembers
                    .OrderBy(x => x.PropertyName)
                    .Distinct()
                    .Select(
                        x =>
                            new
                            {
                                ParentName = x.ParentName,
                                PropertyName = x.PropertyName,
                                SourceSupport = string.Format("Is{0}Supported", x.PropertyName)
                                    .PadRight(horizontalSpaceAllocation),
                                IsExcluded = x.IsExcluded
                            })
                    .ToList();
        }

        public object FilteredDelegates(ResourceProfileData profileData, ResourceClassBase resourceClass)
        {
            var collectionPairs = Resources.GetMemberItemPairs(resourceClass, r => r?.Collections);

            if (!collectionPairs.Any())
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            var toRender = new List<object>();

            //unfiltered objects
            toRender.AddRange(
                collectionPairs.Where(x => x.Current == null || !x.Current.ValueFilters.Any())
                    .Select(
                        x => new
                        {
                            ItemTypeNamespacePrefix = x.Underlying.ItemType.GetNamespacePrefix(),
                            ItemType = x.Underlying.ItemType.Name,
                            PropertyName = x.Underlying.ItemType.Name,
                            ParentName =
                                resourceClass.IsDerived && !resourceClass.IsDescriptorEntity()
                                    ? resourceClass.Entity.Aggregate.Name
                                    : x.Underlying.ParentFullName.Name,
                            Standard = ResourceRenderer.DoRenderProperty
                        }));

            // filtered objects
            toRender.AddRange(
                collectionPairs
                    .Where(x => x.Current != null && x.Current.ValueFilters.Any())
                    .OrderBy(x => x.Underlying.PropertyName)
                    .Select(
                        x =>
                            new
                            {
                                ItemTypeNamespacePrefix = x.Underlying.ItemType.GetNamespacePrefix(),
                                ItemType = x.Underlying.ItemType.Name,
                                PropertyName = x.Underlying.ItemType.Name,
                                ParentName =
                                    resourceClass.IsDerived && !resourceClass.IsDescriptorEntity()
                                        ? resourceClass.Entity.Aggregate.Name
                                        : x.Underlying.ParentFullName.Name,
                                FilteredValues = x.Current.ValueFilters
                                    .SelectMany(
                                        y => y.Values.Select(
                                            z => new
                                            {
                                                FilteredPropertyName = y.PropertyName,
                                                FilteredValue = z,
                                                NotFirst = z != y.Values.First(),
                                                IsIncluded = y.FilterMode == ItemFilterMode.IncludeOnly,
                                                IsLast = z == y.Values.Last()
                                            })),
                                Filtered = ResourceRenderer.DoRenderProperty
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
            public string EntityName { get; set; }

            public IEnumerable<PutPostRequestValidatorCollectionProperty> Collections { get; set; }

            public bool HasProfileItemFilterValidations { get; set; }

            public IEnumerable<ItemFilterValidation> ProfileItemFilterValidations { get; set; }

            public KeyUnificationValidation KeyUnificationValidations { get; set; }
        }

        public class ItemFilterValidation {
            public string PropertyName { get; set; }

            public string ValidatorName { get; set; }

            public string ValidatorPropertyName { get; set; }

            public string PropertyFieldName { get; set; }

            public string Filters { get; set; }

            public string ProfileName { get; set; }
        }

        public object CreatePutPostRequestValidator(
            ResourceProfileData profileData,
            ResourceClassBase resource,
            TemplateContext templateContext)
        {
            var resourceChildItem = resource as ResourceChildItem;
            return new PutPostRequestValidator
            {
                EntityName = resource.Name,
                Collections = resource.Collections
                    // TODO: Remove this filter with dynamic profiles
                    .Where(collection => !profileData.HasProfile || profileData.IsIncluded(resource, collection))
                    .Select(
                        collection => new PutPostRequestValidatorCollectionProperty
                        {
                            PropertyName = collection.PropertyName,
                            PropertyFieldNamePrefix = collection.PropertyName.ToCamelCase(),
                            ItemTypeName = collection.ItemType.Name,
                            Namespace = collection.ParentFullName.Name != resource.Name
                                ? string.Format(
                                    "{0}.{1}.{2}",
                                    collection.ParentFullName.Name,
                                    profileData.HasProfile ? resource.SchemaProperCaseName : resource.Entity.BaseEntity.SchemaProperCaseName(),
                                    profileData.ProfilePropertyNamespaceSection)
                                : ResourceRenderer.DoNotRenderProperty
                        }),
                HasProfileItemFilterValidations = profileData.HasProfile
                    && profileData.IsWritable
                    && profileData.HasFilteredCollection()
                    && GetItemFilterValidations().Any(),
                ProfileItemFilterValidations = GetItemFilterValidations(),
                KeyUnificationValidations = new KeyUnificationValidation
                {
                    ResourceClassName = resource.Name,
                    ParentResourceClassName = resourceChildItem?.Parent.Name,
                    UnifiedProperties = resource.AllProperties
                        // TODO: Remove this filter with dynamic profiles
                        .Where(rp => !profileData.HasProfile || profileData.IsIncluded(resource, rp))
                        .Where(rp => rp.IsUnified())
                        .Select(rp => new UnifiedProperty
                        {
                            UnifiedPropertyName = rp.PropertyName,
                            UnifiedJsonPropertyName = rp.JsonPropertyName,
                            UnifiedCSharpPropertyType = rp.PropertyType.ToCSharp(),
                            UnifiedPropertyIsFromParent = rp.EntityProperty.IncomingAssociations
                                .Any(a => a.IsNavigable),
                            UnifiedPropertyParentPath = resourceChildItem != null && resourceChildItem.IsResourceExtension
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
                                // TODO: Remove this filter with dynamic profiles
                                .Where(x => !profileData.HasProfile || profileData.IsIncluded(resource, x.Reference))
                                .Select(x => new
                                {
                                    Reference = x.Reference,
                                    ReferenceProperty =
                                        (x.Reference.ReferenceTypeProperties
                                                .SingleOrDefault(rtp => rtp.EntityProperty.PropertyName == x.OtherEntityPropertyName)
                                            // Deal with the special case of the re-pointing of the identifying property from USI to UniqueId in Person entities
                                            ?? x.Reference.ReferenceTypeProperties
                                                .Single(rtp => rtp.EntityProperty.PropertyName ==
                                                    EdFi.Ods.Common.Specifications.UniqueIdSpecification.GetUniqueIdPropertyName(x.OtherEntityPropertyName)))
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

            IEnumerable<ItemFilterValidation> GetItemFilterValidations()
            {
                return resource.Collections
                    .Where(x => profileData.IsFilteredCollection(resource, x))
                    .OrderBy(x => x.PropertyName)
                    .SelectMany(
                        x => profileData.GetFilteredCollection(resource, x)
                            .ValueFilters
                            .Select(
                                y => new ItemFilterValidation
                                {
                                    PropertyName = x.PropertyName,
                                    ValidatorName = x.ItemType.Name,
                                    ValidatorPropertyName = y.PropertyName,
                                    PropertyFieldName = x.ItemType.Name.ToCamelCase(),
                                    Filters = string.Join(", ", y.Values.Select(s => string.Format("'{0}'", s))),
                                    ProfileName = profileData.ProfileName
                                }));
            }
        }

        public object References(ResourceProfileData profileData, ResourceClassBase resource, TemplateContext TemplateContext)
        {
            var activeResource = profileData.GetProfileActiveResource(resource);

            var references = activeResource.References
                .ToList();

            if (!references.Any(x => profileData.IsIncluded(resource, x)))
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            if (activeResource.IsAggregateRoot() || !activeResource.HasBackReferences())
            {
                return new
                {
                    Collections = references
                        .Where(x => profileData.IsIncluded(resource, x))
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
                                        IsIdentifying = x.Association.IsIdentifying
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
                Collections = activeResource.References
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
        public object OnDeserialize(ResourceProfileData profileData, ResourceClassBase resource, TemplateContext TemplateContext)
        {
            bool shouldRender = !(profileData.HasProfile && !profileData.HasNavigableChildren(resource));

            if (!profileData.HasProfile
                && !(resource.Collections.Any() || !resource.IsAggregateRoot() && resource.HasBackReferences()))
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

            if (resource.Collections.Any(c => profileData.IsIncluded(resource, c))
                || !resource.IsAggregateRoot() && resource.References.Any(x => profileData.IsIncluded(resource, x)))
            {
                return new
                {
                    BackRef = !resource.IsAggregateRoot() && resource.HasBackReferences()
                        ? ResourceRenderer.DoRenderProperty
                        : ResourceRenderer.DoNotRenderProperty,
                    BackRefCollections = resource.References
                        .Where(x => profileData.IsIncluded(resource, x))
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

        public object NavigableOneToOnes(ResourceProfileData profileData, ResourceClassBase resourceClass)
        {
            var embeddedObjectPairs = Resources.GetMemberItemPairs(resourceClass, r => r?.EmbeddedObjects);

            return embeddedObjectPairs
                .Where(x => !x.Underlying.IsInherited)
                .OrderBy(x => x.Underlying.PropertyName)
                .Select(
                    x => new
                    {
                        JsonPropertyName = x.Underlying.JsonPropertyName,
                        EmbeddedObjectNamespacePrefix = GetContextualNamespacePrefix(x.Underlying.ObjectType),
                        EmbeddedObjectType = x.Underlying.PropertyName,
                        PropertyName = x.Underlying.PropertyName,
                        ParentName = resourceClass.Name,
                        Standard = x.Current != null,
                        Null = x.Current == null
                    })
                .ToList();
        }

        public object InheritedNavigableOneToOnes(ResourceProfileData profileData, ResourceClassBase resourceClass)
        {
            var embeddedObjectPairs = Resources.GetMemberItemPairs(resourceClass, r => r?.EmbeddedObjects);

            return embeddedObjectPairs
                .Where(x => x.Underlying.IsInherited)
                .OrderBy(x => x.Underlying.PropertyName)
                .Select(
                    x => new
                    {
                        JsonPropertyName = x.Underlying.JsonPropertyName,
                        EmbeddedObjectInterfaceNamespacePrefix = GetContextualNamespacePrefix(x.Underlying.ObjectType),
                        EmbeddedObjectInterfaceType = "I" + x.Underlying.PropertyName,
                        EmbeddedObjectTypeNamespace =
                            $"{Namespaces.Resources.RelativeNamespace}.{resourceClass.Entity.BaseEntity.Name}.{resourceClass.Entity.BaseEntity.SchemaProperCaseName()}.",
                        EmbeddedObjectType = x.Underlying.PropertyName,
                        PropertyName = x.Underlying.PropertyName,
                        BaseEntityNamespacePrefix =
                            $"{Namespaces.Entities.Common.RelativeNamespace}.{resourceClass.Entity.BaseEntity.SchemaProperCaseName()}.",
                        BaseEntityName = resourceClass.Entity.BaseEntity.Name,
                        Standard = x.Current != null,
                        Null = x.Current == null
                    })
                .ToList();
        }
    }
}

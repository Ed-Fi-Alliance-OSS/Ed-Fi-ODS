// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Generators.Resources
{
    public class Resources : GeneratorBase
    {
        private readonly ResourceCollectionRenderer _resourceCollectionRenderer = new();
        private readonly ResourcePropertyRenderer _resourcePropertyRenderer = new();

        public static IPersonEntitySpecification PersonEntitySpecification { get; private set; }

        protected override void Configure() { }

        protected override object Build()
        {
            var domainModel = TemplateContext.DomainModelProvider.GetDomainModel();
            
            PersonEntitySpecification = 
                new PersonEntitySpecification(
                    new PersonTypesProvider(
                        new SuppliedDomainModelProvider(domainModel)));

            _resourcePropertyRenderer.PersonEntitySpecification = PersonEntitySpecification;
            
            var schemaNameMapProvider = TemplateContext.DomainModelProvider.GetDomainModel()
                .SchemaNameMapProvider;

            // NOTE: for model matching only we need to include abstract models
            var resources = new ResourceModelProvider(TemplateContext.DomainModelProvider).GetResourceModel().GetAllResources();

            var resourceDatas = resources
                .Select(r => new ResourceData(r))
                .OrderBy(r => r.ResourceName)
                .ToList();

            return new
            {
                ResourceContexts = resourceDatas
                    .SelectMany(CreateResourceContextModels)
                    .Where(rc => rc != null)
                    .ToList(),
                SchemaNamespaces = GetSchemaProperCaseNames(resourceDatas, schemaNameMapProvider)
                    .Select(
                        x => new {Namespace = EdFiConventions.BuildNamespace(Namespaces.Entities.Common.BaseNamespace, x)}),
                ProperCaseName = TemplateContext.SchemaProperCaseName,
                SchemaName = TemplateContext.SchemaPhysicalName,
                IsExtensionContext = TemplateContext.IsExtension
            };
        }

        private IEnumerable<string> GetSchemaProperCaseNames(
            List<ResourceData> resourceDatas,
            ISchemaNameMapProvider schemaNameMapProvider)
        {
            return new[] {EdFiConventions.ProperCaseName}
                .Concat(
                    TemplateContext.IsExtension
                        ? resourceDatas
                            .SelectMany(pd => pd.Resource.AllContainedItemTypes)
                            .Select(x => x.FullName.Schema)
                            .Except(EdFiConventions.PhysicalSchemaName)
                            .Distinct()
                        : Array.Empty<string>())
                .Select(
                    sch => schemaNameMapProvider.GetSchemaMapByPhysicalName(sch)
                        .ProperCaseName);
        }

        public static IList<HrefData> GetIdentifyingPropertiesWithAttributes(
            ResourceClassBase resource,
            AssociationView association)
        {
            return resource.IdentifyingProperties
                .Where(x => !x.IsLocallyDefined)
                .Select(
                    x =>
                    {
                        string propertyName = x.IsDescriptorUsage
                            ? x.PropertyName + "Id"
                            : x.PropertyName;

                        if (association.PropertyMappingByThisName.ContainsKey(propertyName))
                        {
                            // in the case where we have unified key and roles, we need to use the
                            // context of the call along with the destination

                            var otherResourceProperty = association.PropertyMappingByThisName[propertyName]
                                .OtherProperty
                                .ToResourceProperty(resource);

                            if (!x.HasAssociations())
                            {
                                return
                                    new HrefData
                                    {
                                        Source = otherResourceProperty,
                                        Target = otherResourceProperty,
                                        IsUnified = x.IsUnified()
                                    };
                            }

                            var context = resource.Context(x);

                            if (context != null)
                            {
                                return new HrefData
                                {
                                    Source =
                                        context.PropertyMappingByThisName[propertyName]
                                            .OtherProperty
                                            .ToResourceProperty(resource),
                                    Target = otherResourceProperty,
                                    IsUnified = x.IsUnified()
                                };
                            }

                            return
                                new HrefData
                                {
                                    Source = otherResourceProperty,
                                    Target = otherResourceProperty,
                                    IsUnified = x.IsUnified()
                                };
                        }

                        return new HrefData
                        {
                            Source = x,
                            Target = x,
                            IsUnified = x.IsUnified()
                        };
                    })
                .ToList();
        }

        private IEnumerable<object> CreateResourceContextModels(ResourceData resourceData)
        {
            // Create the context for the main resource
            var resourceContext = new
            {
                ResourceName = resourceData.ResourceName,
                ResourceClassesNamespace = EdFiConventions.CreateResourceNamespace(resourceData.Resource),
                ResourceClasses = CreateContextualResourceClasses(resourceData, resourceData.Resource.FullName.Schema),
                IsAbstract = resourceData.IsAbstract
            };

            if (resourceContext.ResourceClasses != ResourceRenderer.DoNotRenderProperty)
            {
                yield return resourceContext;
            }

            // Process resources based on Ed-Fi standard resources for possible resource extensions
            if (resourceData.Resource.IsEdFiStandardResource)
            {
                // Get all the extension physical schema names present on the current resource model
                string[] extensionSchemaPhysicalNames =
                    !resourceData.Resource.IsEdFiStandardResource
                        ? Array.Empty<string>()
                        : resourceData.Resource.AllContainedItemTypes
                            .Select(rci => rci.FullName.Schema)
                            .Except(new[] {EdFiConventions.PhysicalSchemaName})
                            .ToArray();

                // Process each extension schema with an individual namespace
                foreach (string extensionSchemaPhysicalName in extensionSchemaPhysicalNames.OrderBy(a=>a))
                {
                    string extensionSchemaProperCaseName = TemplateContext.DomainModelProvider.GetDomainModel()
                        .SchemaNameMapProvider
                        .GetSchemaMapByPhysicalName(extensionSchemaPhysicalName)
                        .ProperCaseName;

                    var extensionContext = new
                    {
                        ResourceName = resourceData.ResourceName,
                        ResourceClassesNamespace = EdFiConventions.CreateResourceNamespace(
                            resourceData.Resource,
                            extensionSchemaProperCaseName),
                        ResourceClasses = CreateContextualResourceClasses(resourceData, extensionSchemaPhysicalName),
                        IsAbstract = resourceData.IsAbstract
                    };

                    if (extensionContext.ResourceClasses != ResourceRenderer.DoNotRenderProperty)
                    {
                        yield return extensionContext;
                    }
                }
            }
        }

        private object CreateContextualResourceClasses(ResourceData resourceData, string contextualSchemaPhysicalName)
        {
            var contextualItemFullNames =
                new HashSet<FullName>(resourceData.Resource.AllContainedItemTypes.Select(x => x.FullName));

            var resourceClasses =

                // Create the model for the root class of the resource (if it should be rendered in the current context)
                (TemplateContext.ShouldRenderResourceClass(resourceData.Resource)
                    && resourceData.Resource.FullName.Schema == contextualSchemaPhysicalName
                        ? new[] { CreateResourceClass(resourceData, resourceData.Resource) }
                        : Array.Empty<object>())

                // Add in all the Contained Item Types for the resource
                .Concat(
                    resourceData.Resource.AllContainedItemTypes

                        // Where the item should be generated for the current resource namespace context
                        .Where(x => contextualItemFullNames.Contains(x.FullName))

                        // Only render items for resource classes that are in the same schema for the code generation context
                        .Where(x => TemplateContext.ShouldRenderResourceClass(x))
                        .Where(x => x.FullName.Schema == contextualSchemaPhysicalName)

                        // When generating non-Ed-Fi schema for an Ed-Fi resource, only include resource extension classes, otherwise only include non-resource-extension classes.
                        .Where(
                            x => x.IsResourceExtension
                                == (resourceData.Resource.IsEdFiStandardResource
                                    && contextualSchemaPhysicalName != EdFiConventions.PhysicalSchemaName))
                        .Where(
                            x =>
                            {
                                // For contexts where the root resource class is derived, don't render inherited children
                                if (resourceData.IsDerived)
                                {
                                    return !x.IsInheritedChildItem;
                                }

                                return true;
                            })
                        .OrderBy(x => x.Name)
                        .Select(x => CreateResourceClass(resourceData, x)))
                .ToList();

            return resourceClasses.Any()
                ? resourceClasses.Select(rc => new { ResourceClass = rc }).ToList()
                : ResourceRenderer.DoNotRenderProperty;
        }

        private ResourceClassBase GetContextualParent(ResourceChildItem resourceChildItem)
        {
            if (resourceChildItem == null)
            {
                return null;
            }

            return resourceChildItem.Parent;
        }

        private object CreateResourceClass(ResourceData resourceData, ResourceClassBase resourceClass)
        {
            // NOTE model matching
            if (resourceClass.IsAbstract())
            {
                return new
                {
                    ResourceReference = new
                    {
                        MessagePackIndexer = new MessagePackIndexer(),
                        ReferenceName = resourceClass.Name,
                        ReferenceIdentifiers =
                            _resourcePropertyRenderer.AssembleIdentifiers(resourceClass),
                        Href = AssembleHref(resourceClass),
                        HasDiscriminator = resourceClass.Entity.HasDiscriminator(),
                    },
                    ShouldRenderClass = false,
                    HasDiscriminator = resourceClass.Entity.HasDiscriminator()
                };
            }

            var parentResource = (resourceClass as ResourceChildItem)?.Parent;

            // NOTE model matching
            if (parentResource != null && parentResource.IsAbstract() &&
                parentResource.Entity?.IsSameAggregate(resourceClass.Entity) != true)
            {
                return new {ShouldRenderClass = false};
            }

            object putPostRequestValidator = _resourceCollectionRenderer.CreatePutPostRequestValidator(resourceData, resourceClass, TemplateContext);

            // Contextual parent handling
            var resourceAsChildItem = resourceClass as ResourceChildItem;
            var contextualParent = GetContextualParent(resourceAsChildItem);

            var parentProperCaseSchemaName =
                contextualParent?.ResourceModel.SchemaNameMapProvider
                    .GetSchemaMapByPhysicalName(contextualParent.FullName.Schema)
                    .ProperCaseName;

            // Lists
            var collections = _resourceCollectionRenderer.Collections(resourceClass);
            var inheritedNavigableOneToOnes = _resourceCollectionRenderer.InheritedNavigableOneToOnes(resourceClass);
            var navigableOneToOnes = _resourceCollectionRenderer.NavigableOneToOnes(resourceClass);

            // InheritedCollections instance, or null
            var inheritedCollections = _resourceCollectionRenderer.InheritedCollections(resourceClass);

            bool isExtendable = resourceClass.IsExtendable();

            // Determine if we should generate an IValidatableObject
            bool hasValidatableChildren = (collections as IList).Count > 0
                || (inheritedNavigableOneToOnes as IList).Count > 0
                || (navigableOneToOnes as IList).Count > 0
                || inheritedCollections != null
                || isExtendable;

            return new
            {
                MessagePackIndexer = new MessagePackIndexer(),
                ShouldRenderClass = true,
                ResourceReference = resourceClass.IsAggregateReference()
                    ? new
                    {
                        MessagePackIndexer = new MessagePackIndexer(),
                        ReferenceName = resourceClass.Name,
                        ReferenceIdentifiers = _resourcePropertyRenderer
                            .AssembleIdentifiers(resourceClass),
                        Href = AssembleHref(resourceClass)
                    }
                    : ResourceRenderer.DoNotRenderProperty,
                ClassName = resourceClass.Name,
                EntityName = resourceClass.Name,
                Constructor = AssembleConstructor(resourceClass),
                HasCollections = ((IList) collections).Count > 0,
                Collections = collections,
                Identifiers = _resourcePropertyRenderer.AssemblePrimaryKeys(resourceData, resourceClass, TemplateContext),
                NonIdentifiers = _resourcePropertyRenderer.AssembleProperties(resourceClass),
                InheritedProperties = _resourcePropertyRenderer.AssembleInheritedProperties(resourceClass),
                InheritedCollections = inheritedCollections,
                OnDeserialize = _resourceCollectionRenderer.OnDeserialize(resourceData, resourceClass, TemplateContext),
                Guid =
                    resourceClass.IsAggregateRoot()
                        ? new
                        {
                            ResourceName = resourceClass.Name,
                            GuidConverterTypeName = "GuidConverter"
                        }
                        : ResourceRenderer.DoNotRenderProperty,
                NavigableOneToOnes = navigableOneToOnes,
                InheritedNavigableOneToOnes = inheritedNavigableOneToOnes,
                Versioning = resourceClass.IsAggregateRoot()
                    ? ResourceRenderer.DoRenderProperty
                    : ResourceRenderer.DoNotRenderProperty,
                References = _resourceCollectionRenderer.References(resourceData, resourceClass),
                FQName = resourceClass.FullName,
                SchemaProperCaseName = resourceClass.SchemaProperCaseName,
                SchemaName = resourceClass.Entity?.Schema,
                IsAbstract = resourceClass.IsAbstract(),
                IsAggregateRoot = resourceClass.IsAggregateRoot(),
                DerivedName = resourceClass.IsDerived
                    ? $@", {EdFiConventions.BuildNamespace(
                            Namespaces.Entities.Common.RelativeNamespace,
                            resourceClass.Entity.BaseEntity.SchemaProperCaseName())
                        }.I{resourceClass.Entity.BaseEntity.Name}"
                    : ResourceRenderer.DoNotRenderProperty,
                ParentName = contextualParent?.Name,
                ParentFieldName = contextualParent?.Name.ToCamelCase(),
                InterfaceParentFieldName = contextualParent?.Name,
                ParentNamespacePrefix = parentProperCaseSchemaName == null
                    ? null
                    : $"{Namespaces.Entities.Common.RelativeNamespace}.{parentProperCaseSchemaName}.",
                IsBaseClassConcrete = resourceClass.Entity != null
                                      && resourceClass.Entity.IsDerived
                                      && resourceClass.Entity.BaseEntity != null
                                      && !resourceClass.Entity.BaseEntity.IsAbstractRequiringNoCompositeId(),
                DerivedBaseTypeName = resourceClass.IsDerived && resourceClass.Entity != null
                    ? resourceClass.Entity.BaseEntity?.Name
                    : ResourceRenderer.DoNotRenderProperty,
                FilteredDelegates = _resourceCollectionRenderer.FilteredDelegates(resourceClass),
                KeyUnificationValidations = GetKeyUnificationValidations(resourceClass),
                ShouldRenderValidator = putPostRequestValidator != ResourceRenderer.DoNotRenderProperty,
                Validator = putPostRequestValidator,
                HasValidatableChildren = hasValidatableChildren,
                IsExtendable = isExtendable,
                IsResourceExtensionClass = resourceClass.IsResourceExtensionClass,
                HasSupportedExtensions = resourceData.Resource.Extensions.Any(),
                SupportedExtensions = resourceData.Resource.Extensions.OrderBy(f => f.PropertyName)
                    .Select(e => new {ExtensionName = TemplateContext.GetSchemaProperCaseNameForExtension(e)}),
                IsEdFiResource = resourceClass.IsEdFiResource(),
                NamespacePrefix = resourceClass.GetNamespacePrefix(),
                HasDiscriminator = resourceClass.Entity.HasDiscriminator(),

                // Foreign Key Discriminators should not have any profile applied to this, as this data is required for links
                ResourceReferences = CreateResourceReferences(resourceClass),
                HasRequiredMembersWithMeaningfulDefaultValues = _resourcePropertyRenderer.HasRequiredMembersWithMeaningfulDefaultValues(resourceClass),
                RequiredMembersWithMeaningfulDefaultValues = _resourcePropertyRenderer.RequiredMembersWithMeaningfulDefaultValues(resourceClass)
            };
        }

        private static ResourceCollectionRenderer.KeyUnificationValidation GetKeyUnificationValidations(ResourceClassBase resourceClass)
        {
            var resourceChildItem = resourceClass as ResourceChildItem;
            
            return new ResourceCollectionRenderer.KeyUnificationValidation
            {
                ResourceClassName = resourceClass.Name,
                ParentResourceClassName = resourceChildItem?.Parent.Name,
                HasUnifiedProperties = resourceClass.AllProperties.Any(rp => rp.IsUnified()),
                UnifiedProperties = resourceClass.AllProperties.Where(rp => rp.IsUnified())
                    .Select(
                        rp => new ResourceCollectionRenderer.UnifiedProperty
                        {
                            UnifiedPropertyName = rp.PropertyName,
                            UnifiedJsonPropertyName = rp.JsonPropertyName,
                            UnifiedCSharpPropertyType = rp.PropertyType.ToCSharp(),
                            UnifiedPropertyIsFromParent = rp.EntityProperty.IncomingAssociations.Any(a => a.IsNavigable),
                            UnifiedPropertyIsString = rp.PropertyType.IsString(),
                            UnifiedPropertyIsLocallyDefined = rp.IsLocallyDefined,
                            UnifiedPropertyParentPath = resourceChildItem is
                            {
                                IsResourceExtension: true,
                                IsResourceExtensionClass: false,
                            }
                                ? string.Join(
                                    string.Empty,
                                    resourceChildItem.GetLineage()
                                        .TakeWhile(l => !l.IsResourceExtension)
                                        .Select(l => "." + l.Name))
                                : null,
                            References = rp.EntityProperty.IncomingAssociations
                                .Where(a => !a.IsNavigable && rp.Parent.ReferenceByName.ContainsKey(a.Name + "Reference"))
                                .Select(
                                    a => new
                                    {
                                        Reference = rp.Parent.ReferenceByName[a.Name + "Reference"],
                                        OtherEntityPropertyName = a.PropertyMappings
                                            .Where(pm => pm.ThisProperty.Equals(rp.EntityProperty))
                                            .Select(pm => pm.OtherProperty.PropertyName)
                                            .Single(),
                                    })
                                .Select(
                                    x => new
                                    {
                                        Reference = x.Reference,
                                        ReferenceProperty = (x.Reference.ReferenceTypeProperties.SingleOrDefault(
                                                rtp => rtp.EntityProperty.PropertyName == x.OtherEntityPropertyName)

                                            // Deal with the special case of the re-pointing of the identifying property from USI to UniqueId in Person entities
                                            ?? x.Reference.ReferenceTypeProperties.Single(
                                                rtp => rtp.EntityProperty.PropertyName
                                                    == UniqueIdConventions.GetUniqueIdPropertyName(x.OtherEntityPropertyName)))
                                    })
                                .Select(
                                    x => new ResourceCollectionRenderer.UnifiedReferenceProperty
                                    {
                                        ReferenceName = x.Reference.PropertyName,
                                        ReferenceJsonName = x.Reference.JsonPropertyName,
                                        ReferencePropertyName = x.ReferenceProperty.PropertyName,
                                        ReferenceJsonPropertyName = x.ReferenceProperty.JsonPropertyName
                                    })
                        })
            };
        }
        
        private static IEnumerable<object> CreateResourceReferences(ResourceClassBase resourceClass)
        {
            if (resourceClass.Entity == null)
            {
                if (resourceClass.IsResourceExtensionClass)
                {
                    return Enumerable.Empty<object>();
                }

                throw new Exception($"Resource class '{resourceClass.FullName}' does not have an associated entity.");
            }

            return resourceClass.Entity
                .GetAssociationsToReferenceableAggregateRoots(includeInherited: true)
                .OrderBy(a => a.Name)
                .Select(
                    a => new
                    {
                        Association = a,
                        InheritanceRootEntity = a.OtherEntity.TypeHierarchyRootEntity,
                    })
                .Select(
                    x =>
                        new
                        {
                            ClassName = x.Association.ThisEntity.Name,
                            ReferenceName = x.Association.Name,
                            MappedReferenceDataHasDiscriminator = x.Association.OtherEntity.HasDiscriminator(),

                            // References to core entities for extension entities are on the interface of the extension entity
                            Namespace = resourceClass.Entity.IsEdFiStandardEntity
                                ? $"{Namespaces.Entities.Common.RelativeNamespace}.{x.InheritanceRootEntity.SchemaProperCaseName()}"
                                : $"{Namespaces.Entities.Common.RelativeNamespace}.{x.Association.ThisEntity.SchemaProperCaseName()}"
                        });
        }

        private object AssembleConstructor(ResourceClassBase resource)
        {
            return resource.Collections.Any()
                ? new
                {
                    Inherited = resource.IsDerived && resource.Collections.Any(x => x.IsInherited)
                        ? ResourceRenderer.DoRenderProperty
                        : ResourceRenderer.DoNotRenderProperty,
                    InheritedCollections = resource.Collections
                        .Where(x => x.IsInherited)
                        .Select(
                            x =>
                                new
                                {
                                    BaseEntity =
                                        $"{resource.Entity.BaseEntity.Name}.{resource.Entity.BaseEntity.SchemaProperCaseName()}",
                                    PropertyName = x.ItemType.PluralName,
                                    CollectionName = x.ItemType.Name
                                })
                        .ToList(),
                    Standard = resource.Collections.Any(x => !x.IsInherited)
                        ? ResourceRenderer.DoRenderProperty
                        : ResourceRenderer.DoNotRenderProperty,
                    Collections = resource.Collections
                        .Where(
                            x =>
                                !x.IsInherited
                                && TemplateContext.ShouldRenderResourceClass(
                                    x.ItemType))
                        .Select(
                            x => new
                            {
                                PropertyName = x.ItemType.PluralName,
                                CollectionName = x.ItemType.Name
                            })
                        .ToList()
                }
                : ResourceRenderer.DoNotRenderProperty;
        }

        private object AssembleHref(ResourceClassBase resourceClass, AssociationView association = null)
        {
            if (resourceClass.IsAggregateRoot())
            {
                return new
                {
                    StandardLink = new
                    {
                        ResourceName = resourceClass.Name,
                        ResourceBaseRoute = GetResourceCollectionRelativeRoute(resourceClass as Resource),
                    }
                };
            }

            if (association == null)
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            return new
            {
                StandardLink = new
                {
                    Rel = association.OtherEntity.Name,
                    ResourceBaseRoute =
                        $"/{association.OtherEntity.SchemaUriSegment()}/{association.OtherEntity.PluralName.ToCamelCase()}",
                }
            };
        }

        private static string GetResourceCollectionRelativeRoute(Resource resource)
        {
            return $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}";
        }

        internal static List<TItem> GetMemberItemPairs<TItem>(
            ResourceClassBase resourceClass,
            Func<ResourceClassBase, IReadOnlyList<TItem>> memberAccessor)
            where TItem : ResourceMemberBase
        {
            var allItems = memberAccessor(resourceClass)
                .OrderBy(i => i.PropertyName)
                .ToList();

            return allItems;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators.Resources
{
    public class Resources : GeneratorBase
    {
        private readonly ResourceCollectionRenderer _resourceCollectionRenderer;
        private readonly ResourcePropertyRenderer _resourcePropertyRenderer;

        public Resources()
        {
            _resourcePropertyRenderer = new ResourcePropertyRenderer();
            _resourceCollectionRenderer = new ResourceCollectionRenderer();
        }

        protected override void Configure()
        {
        }

        protected override object Build()
        {
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

        private object CreateContextSpecificResourceReferences(ResourceClassBase resource)
        {
            if (resource.IsAggregateRoot() || !resource.HasBackReferences())
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            var externalAssociations = resource.ExternalReferenceAssociations()
                .ToList();

            var refs = externalAssociations.Select(
                    av => new
                    {
                        ContextSpecificResourceReference = new
                        {
                            NamespacePrefix = resource.GetNamespacePrefix(),
                            ReferenceName = string.Format(
                                "{0}To{1}",
                                av.ThisEntity.Name,
                                av.OtherEntity.Name),
                            // Leaving this member definition inline as this entire method
                            // is to be deprecated in the future.
                            ContextualReferenceIdentifier =
                                av.ThisProperties
                                    .Where(p => (p.IsUnified && p.IsIdentifying))
                                    .Select(
                                        p =>
                                            av.PropertyMappingByThisName[p.PropertyName]
                                                .OtherProperty
                                                .ToResourceProperty(resource))
                                    .OrderBy(p => p.PropertyName)
                                    .Select(p => new
                                    {
                                        PropertyName = p.PropertyName,
                                        JsonPropertyName = p.JsonPropertyName,
                                        PropertyType = p.PropertyType.ToCSharp(),
                                        // Use GetLineage to build the property path, in reverse order, skipping the first since that's the BackReference itself
                                        PropertyPathToRoot = "BackReference." +
                                            string.Join(".", ((ResourceChildItem)resource).GetLineage().Reverse().Skip(1).Select(l => l.Name))
                                    }),
                            ReferenceIdentifiers =
                                _resourcePropertyRenderer.AssembleIdentifiers(
                                    resource,
                                    av),
                            Href = AssembleHref(resource, av),
                            HasDiscriminator = av.OtherEntity.HasDiscriminator(),
                            ThisEntityName = av.ThisEntity.Name,
                            OtherEntityName = av.OtherEntity.Name,
                            BackReference =
                                string.Format(
                                    "backreference.{0}.",
                                    (resource as ResourceChildItem)?.Parent.Name),
                            ReferenceFullyDefined =
                                _resourcePropertyRenderer
                                    .AssembleReferenceFullyDefined(
                                        resource,
                                        av)
                        }
                    }
                )
                .ToList();

            return refs;
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
                        ReferenceName = resourceClass.Name,
                        ReferenceIdentifiers =
                            _resourcePropertyRenderer.AssembleIdentifiers(resourceClass),
                        Href = AssembleHref(resourceClass),
                        HasDiscriminator = resourceClass.Entity.HasDiscriminator()
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

            var collections = _resourceCollectionRenderer.Collections(resourceClass);

            return new
            {
                ShouldRenderClass = true,
                ResourceReference = resourceClass.IsAggregateReference()
                    ? new
                    {
                        ReferenceName = resourceClass.Name,
                        ReferenceIdentifiers = _resourcePropertyRenderer
                            .AssembleIdentifiers(resourceClass),
                        Href = AssembleHref(resourceClass)
                    }
                    : ResourceRenderer.DoNotRenderProperty,
                ContextSpecificResourceReferences = CreateContextSpecificResourceReferences(resourceClass),
                ClassName = resourceClass.Name,
                EntityName = resourceClass.Name,
                Constructor = AssembleConstructor(resourceClass),
                HasCollections = ((IList) collections).Count > 0,
                Collections = collections,
                Identifiers = _resourcePropertyRenderer.AssemblePrimaryKeys(resourceData, resourceClass, TemplateContext),
                NonIdentifiers = _resourcePropertyRenderer.AssembleProperties(resourceClass),
                InheritedProperties = _resourcePropertyRenderer.AssembleInheritedProperties(resourceClass),
                InheritedCollections =
                    _resourceCollectionRenderer.InheritedCollections(resourceClass),
                OnDeserialize = _resourceCollectionRenderer.OnDeserialize(resourceData, resourceClass, TemplateContext),
                Guid =
                    resourceClass.IsAggregateRoot()
                        ? new
                        {
                            ResourceName = resourceClass.Name,
                            GuidConverterTypeName = "GuidConverter"
                        }
                        : ResourceRenderer.DoNotRenderProperty,
                NavigableOneToOnes = _resourceCollectionRenderer.NavigableOneToOnes(resourceClass),
                InheritedNavigableOneToOnes = _resourceCollectionRenderer.InheritedNavigableOneToOnes(resourceClass),
                Versioning = resourceClass.IsAggregateRoot()
                    ? ResourceRenderer.DoRenderProperty
                    : ResourceRenderer.DoNotRenderProperty,
                References = _resourceCollectionRenderer.References(resourceData, resourceClass),
                FQName = resourceClass.FullName,
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
                ShouldRenderValidator = putPostRequestValidator != ResourceRenderer.DoNotRenderProperty,
                Validator = putPostRequestValidator,
                IsExtendable = resourceClass.IsExtendable(),
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

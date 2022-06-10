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
        private IResourceProfileProvider _resourceProfileProvider;

        public Resources()
        {
            _resourcePropertyRenderer = new ResourcePropertyRenderer();
            _resourceCollectionRenderer = new ResourceCollectionRenderer();
        }

        protected override void Configure()
        {
            _resourceProfileProvider = new ResourceProfileProvider(
                new ResourceModelProvider(TemplateContext.DomainModelProvider),
                TemplateContext);
        }

        protected override object Build()
        {
            var profileDatas = _resourceProfileProvider
                .GetResourceProfileData()
                .ToList();

            var schemaNameMapProvider = TemplateContext.DomainModelProvider.GetDomainModel()
                .SchemaNameMapProvider;

            // NOTE: for model matching only we need to include abstract models
            return new
            {
                ResourceContexts = profileDatas
                    .SelectMany(CreateResourceContextModels)
                    .Where(rc => rc != null)
                    .ToList(),
                SchemaNamespaces = GetSchemaProperCaseNames(profileDatas, schemaNameMapProvider)
                    .Select(
                        x => new {Namespace = EdFiConventions.BuildNamespace(Namespaces.Entities.Common.BaseNamespace, x)}),
                ProperCaseName = TemplateContext.SchemaProperCaseName,
                IsExtensionContext = TemplateContext.IsExtension
            };
        }

        private IEnumerable<string> GetSchemaProperCaseNames(
            List<ResourceProfileData> profileDatas,
            ISchemaNameMapProvider schemaNameMapProvider)
        {
            return new[] {EdFiConventions.ProperCaseName}
                .Concat(
                    TemplateContext.IsExtension
                        ? profileDatas
                            .SelectMany(pd => pd.SuppliedResource.AllContainedItemTypes)
                            .Select(x => x.FullName.Schema)
                            .Except(EdFiConventions.PhysicalSchemaName)
                            .Distinct()
                        : new string[0])
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

        private IEnumerable<object> CreateResourceContextModels(ResourceProfileData profileData)
        {
            // Create the context for the main resource
            var resourceContext = new
            {
                ResourceName = profileData.ResourceName,
                ResourceClassesNamespace = EdFiConventions.CreateResourceNamespace(
                    profileData.ContextualRootResource,
                    profileData.ProfileNamespaceName,
                    profileData.ReadableWritableContext,
                    profileData.ConcreteResourceContext),
                ResourceClasses = CreateContextualResourceClasses(
                    profileData,
                    profileData.ContextualRootResource.FullName.Schema),
                IsAbstract = profileData.IsAbstract
            };

            if (resourceContext.ResourceClasses != ResourceRenderer.DoNotRenderProperty)
            {
                yield return resourceContext;
            }

            // Process resources based on Ed-Fi standard resources for possible resource extensions
            if (profileData.ContextualRootResource.IsEdFiStandardResource)
            {
                // Get all the extension physical schema names present on the current resource model
                string[] extensionSchemaPhysicalNames =
                    !profileData.ContextualRootResource.IsEdFiStandardResource
                        ? new string[0]
                        : profileData.ContextualRootResource.AllContainedItemTypes
                            .Select(i => i.FullName.Schema)
                            .Except(
                                new[] {EdFiConventions.PhysicalSchemaName})
                            .ToArray();

                // Process each extension schema with an individual namespace
                foreach (string extensionSchemaPhysicalName in extensionSchemaPhysicalNames)
                {
                    string extensionSchemaProperCaseName = TemplateContext.DomainModelProvider.GetDomainModel()
                        .SchemaNameMapProvider
                        .GetSchemaMapByPhysicalName(extensionSchemaPhysicalName)
                        .ProperCaseName;

                    var extensionContext = new
                    {
                        ResourceName = profileData.ResourceName,
                        ResourceClassesNamespace =
                            EdFiConventions.CreateResourceNamespace(
                                profileData.ContextualRootResource,
                                profileData.ProfileNamespaceName,
                                profileData.ReadableWritableContext,
                                profileData.ConcreteResourceContext,
                                extensionSchemaProperCaseName),
                        ResourceClasses = CreateContextualResourceClasses(
                            profileData,
                            extensionSchemaPhysicalName),
                        IsAbstract = profileData.IsAbstract
                    };

                    if (extensionContext.ResourceClasses != ResourceRenderer.DoNotRenderProperty)
                    {
                        yield return extensionContext;
                    }
                }
            }
        }

        private object CreateContextualResourceClasses(
            ResourceProfileData profileData,
            string contextualSchemaPhysicalName)
        {
            var contextualItemFullNames =
                new HashSet<FullName>(profileData.ContextualRootResource.AllContainedItemTypes.Select(x => x.FullName));

            var resourceClasses =

                // Create the model for the root class of the resource (if it should be rendered in the current context)
                (TemplateContext.ShouldRenderResourceClass(profileData.ContextualRootResource)
                 && profileData.ContextualRootResource.FullName.Schema == contextualSchemaPhysicalName
                    ? new[] {CreateResourceClass(profileData, profileData.ContextualRootResource)}
                    : new object[0])

                // Add in all the Contained Item Types for the resource
                .Concat(
                    profileData.SuppliedResource
                        .AllContainedItemTypes

                        // Where the item should be generated for the current resource namespace context
                        .Where(x => contextualItemFullNames.Contains(x.FullName))

                        // Only render items for resource classes that are in the same schema for the code generation context
                        .Where(x => TemplateContext.ShouldRenderResourceClass(x))
                        .Where(x => x.FullName.Schema == contextualSchemaPhysicalName)

                        // When generating non-Ed-Fi schema for an Ed-Fi resource, only include resource extension classes, otherwise only include non-resource-extension classes.
                        .Where(
                            x => x.IsResourceExtension == (profileData.ContextualRootResource.IsEdFiStandardResource
                                                           && contextualSchemaPhysicalName != EdFiConventions.PhysicalSchemaName))
                        .Where(
                            x =>
                            {
                                // For contexts where the root resource class is derived, don't render inherited children
                                if (profileData.IsDerived)
                                {
                                    return !x.IsInheritedChildItem;
                                }

                                // For contexts where the root resource class is a base class, only render its children
                                // if the concrete version of the resource needs it.
                                if (profileData.IsBaseResource)
                                {
                                    return profileData.SuppliedResource
                                        .AllContainedItemTypes.Any(
                                            i => x.FullName == i.FullName);
                                }

                                return true;
                            })
                        .OrderBy(x => x.Name)
                        .Select(x => CreateResourceClass(profileData, x)))
                .ToList();

            return resourceClasses.Any()
                ? resourceClasses
                    .Select(
                        rc => new {ResourceClass = rc})
                    .ToList()
                : ResourceRenderer.DoNotRenderProperty;
        }

        private object CreateContextSpecificResourceReferences(ResourceProfileData profileData, ResourceClassBase resource)
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
                                    profileData,
                                    resource,
                                    av),
                            Href = AssembleHref(profileData, resource, av),
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

        private ResourceClassBase GetContextualParent(
            ResourceChildItem resourceChildItem,
            ResourceProfileData profileData)
        {
            if (resourceChildItem == null)
            {
                return null;
            }

            if (profileData.IsBaseResource && resourceChildItem.IsInheritedChildItem)
            {
                return profileData.ContextualRootResource.AllContainedItemTypes.Single(
                        x => x.FullName == resourceChildItem.FullName)
                    .Parent;
            }

            return resourceChildItem.Parent;
        }

        private object CreateResourceClass(ResourceProfileData profileData, ResourceClassBase resourceClass)
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
                            _resourcePropertyRenderer.AssembleIdentifiers(profileData, resourceClass),
                        Href = AssembleHref(profileData, resourceClass),
                        HasDiscriminator = resourceClass.HasDiscriminator()
                    },
                    ShouldRenderClass = false,
                    HasDiscriminator = resourceClass.HasDiscriminator()
                };
            }

            var parentResource = (resourceClass as ResourceChildItem)?.Parent;

            // NOTE model matching
            if (parentResource != null && parentResource.IsAbstract() &&
                parentResource.Entity?.IsSameAggregate(resourceClass.Entity) != true)
            {
                return new {ShouldRenderClass = false};
            }

            object putPostRequestValidator = _resourceCollectionRenderer.CreatePutPostRequestValidator(profileData, resourceClass, TemplateContext);

            // Contextual parent handling
            var resourceAsChildItem = resourceClass as ResourceChildItem;
            var contextualParent = GetContextualParent(resourceAsChildItem, profileData);

            var parentProperCaseSchemaName =
                contextualParent?.ResourceModel.SchemaNameMapProvider
                    .GetSchemaMapByPhysicalName(contextualParent.FullName.Schema)
                    .ProperCaseName;

            var collections = _resourceCollectionRenderer.Collections(profileData, resourceClass, TemplateContext);

            return new
            {
                ShouldRenderClass = true,
                ResourceReference = resourceClass.IsAggregateReference()
                    ? new
                    {
                        ReferenceName = resourceClass.Name,
                        ReferenceIdentifiers = _resourcePropertyRenderer
                            .AssembleIdentifiers(profileData, resourceClass),
                        Href = AssembleHref(profileData, resourceClass)
                    }
                    : ResourceRenderer.DoNotRenderProperty,
                ContextSpecificResourceReferences = CreateContextSpecificResourceReferences(profileData, resourceClass),
                ClassName = resourceClass.Name,
                EntityName = resourceClass.Name,
                Constructor = AssembleConstructor(profileData, resourceClass),
                HasCollections = ((IList) collections).Count > 0,
                Collections = collections,
                Identifiers = _resourcePropertyRenderer.AssemblePrimaryKeys(profileData, resourceClass, TemplateContext),
                NonIdentifiers = _resourcePropertyRenderer.AssembleProperties(resourceClass),
                InheritedProperties = _resourcePropertyRenderer.AssembleInheritedProperties(profileData, resourceClass),
                InheritedCollections =
                    _resourceCollectionRenderer.InheritedCollections(profileData, resourceClass, TemplateContext),
                OnDeserialize = _resourceCollectionRenderer.OnDeserialize(profileData, resourceClass, TemplateContext),
                Guid =
                    resourceClass.IsAggregateRoot()
                        ? new
                        {
                            ResourceName = resourceClass.Name,
                            GuidConverterTypeName = "GuidConverter"
                        }
                        : ResourceRenderer.DoNotRenderProperty,
                NavigableOneToOnes = _resourceCollectionRenderer.NavigableOneToOnes(profileData, resourceClass),
                InheritedNavigableOneToOnes = _resourceCollectionRenderer.InheritedNavigableOneToOnes(profileData, resourceClass),
                SynchronizationSourceSupport =
                    _resourceCollectionRenderer
                        .SynchronizationSourceSupport(profileData, resourceClass, TemplateContext),
                Versioning = resourceClass.IsAggregateRoot()
                    ? ResourceRenderer.DoRenderProperty
                    : ResourceRenderer.DoNotRenderProperty,
                References = _resourceCollectionRenderer.References(profileData, resourceClass, TemplateContext),
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
                FilteredDelegates = _resourceCollectionRenderer.FilteredDelegates(profileData, resourceClass),
                ShouldRenderValidator = putPostRequestValidator != ResourceRenderer.DoNotRenderProperty,
                Validator = putPostRequestValidator,
                IsExtendable = resourceClass.IsExtendable(),
                IsProfileProject = TemplateContext.IsProfiles,
                HasSupportedExtensions = profileData.SuppliedResource.Extensions.Any(),
                SupportedExtensions = profileData.SuppliedResource.Extensions
                    .Select(e => new {ExtensionName = TemplateContext.GetSchemaProperCaseNameForExtension(e)}),
                IsEdFiResource = resourceClass.IsEdFiResource(),
                NamespacePrefix = resourceClass.GetNamespacePrefix(),
                HasDiscriminator = resourceClass.HasDiscriminator(),

                // Foreign Key Discriminators should not have any profile applied to this, as this data is required for links
                ResourceReferences = CreateResourceReferences(resourceClass)
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
                            ReferenceIncluded = resourceClass.References.Select(r => r.Association.Association)
                                .Contains(x.Association.Association),

                            // References to core entities for extension entities are on the interface of the extension entity
                            Namespace = resourceClass.Entity.IsEdFiStandardEntity
                                ? $"{Namespaces.Entities.Common.RelativeNamespace}.{x.InheritanceRootEntity.SchemaProperCaseName()}"
                                : $"{Namespaces.Entities.Common.RelativeNamespace}.{x.Association.ThisEntity.SchemaProperCaseName()}"
                        });
        }

        private object AssembleConstructor(ResourceProfileData profileData, ResourceClassBase resource)
        {
            string ns = profileData.GetProfileNamespace(resource);

            var activeResource = profileData.GetProfileActiveResource(resource);

            return activeResource.Collections.Any()
                ? new
                {
                    Inherited = resource.IsDerived && activeResource.Collections.Any(x => x.IsInherited)
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
                                    PropertyNamespace = ns,
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
                                && profileData.IsIncluded(resource, x)
                                && TemplateContext.ShouldRenderResourceClass(
                                    x.ItemType))
                        .Select(
                            x => new
                            {
                                PropertyName = x.ItemType.PluralName,
                                PropertyNamespace = ns,
                                CollectionName = x.ItemType.Name
                            })
                        .ToList()
                }
                : ResourceRenderer.DoNotRenderProperty;
        }

        private object AssembleHref(
            ResourceProfileData profileData,
            ResourceClassBase resource,
            AssociationView association = null)
        {
            if (resource.IsAggregateRoot())
            {
                return new
                {
                    StandardLink = new
                    {
                        ResourceName = resource.Name,
                        ResourceBaseRoute = GetResourceCollectionRelativeRoute(resource as Resource),
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

        internal static List<SemanticItemPair<TItem>> GetMemberItemPairs<TItem>(
            ResourceClassBase resourceClass,
            Func<ResourceClassBase, IReadOnlyList<TItem>> memberAccessor)
            where TItem : ResourceMemberBase
        {
            // Collections
            var allItems = memberAccessor(resourceClass.FilterContext.UnfilteredResourceClass)
                           ?? memberAccessor(resourceClass);

            var availableItems = memberAccessor(resourceClass);

            var pairs =
                (from all in allItems
                    join avail in availableItems on all.PropertyName equals avail.PropertyName into leftJoin
                    from _avail in leftJoin.DefaultIfEmpty()
                    orderby all.PropertyName
                    select new SemanticItemPair<TItem>
                    {
                        Underlying = all,
                        Current = _avail
                    })
                .ToList();

            return pairs;
        }
    }
}

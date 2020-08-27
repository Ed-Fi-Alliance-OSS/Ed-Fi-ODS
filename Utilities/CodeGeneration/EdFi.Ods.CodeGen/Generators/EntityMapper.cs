// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntityMapper : GeneratorBase
    {
        protected override object Build()
        {
            var resources = ResourceModelProvider.GetResourceModel()
                                                 .GetAllResources();

            var aggregates = resources
                            .Select(
                                 r => new
                                      {
                                          ResourceName = r.Name, ResourceClasses =

                                              // Add the root resource class (if it's not abstract or it has a composite id)
                                              (r.Entity?.IsAbstractRequiringNoCompositeId() != true && TemplateContext.ShouldRenderResourceClass(r)
                                                  ? new ResourceClassBase[]
                                                    {
                                                        r
                                                    }
                                                  : new ResourceClassBase[0])

                                              // Add in non-inherited child items
                                             .Concat(
                                                  r.AllContainedItemTypes
                                                   .Where(
                                                        t => TemplateContext.ShouldRenderResourceClass(t)
                                                             && !t.IsInheritedChildItem))
                                             .ToList()
                                      })
                            .Where(x => x.ResourceClasses.Any())
                            .OrderBy(x => x.ResourceName)
                            .Select(
                                 x => new
                                      {
                                          AggregateName = x.ResourceName, Mappers = x.ResourceClasses
                                                                                     .OrderBy(y => y.Name)
                                                                                     .Select(BuildMapper)
                                      });

            var hasDerivedResources = resources.Any(r => r.IsDerived);

            return new
                   {
                       HasDerivedResources = hasDerivedResources, NamespaceName =
                           EdFiConventions.BuildNamespace(
                               Namespaces.Entities.Common.BaseNamespace,
                               TemplateContext.SchemaProperCaseName),
                       Aggregates = aggregates
                   };
        }

        private object BuildMapper(ResourceClassBase resourceClass)
        {
            return new
                   {
                       ModelName = resourceClass.Name,
                       ModelParentName = resourceClass.Entity?.Parent?.Name ?? resourceClass.Name.TrimSuffix("Extension"),
                       ExtensionName = TemplateContext.SchemaProperCaseName, IsEntityExtension = resourceClass.IsResourceExtensionClass,
                       BaseClassName = resourceClass.Entity?.BaseEntity?.Name, AllowPrimaryKeyUpdates = resourceClass.Entity?.Identifier.IsUpdatable,
                       AnnotatedLocalPrimaryKeyList = AnnotateLocalIdentifyingPropertyKeys(resourceClass.Entity), BackSynchedPrimaryKeyList =
                           resourceClass.IdentifyingProperties
                                        .Where(p => !IsDefiningUniqueId(resourceClass, p))
                                        .OrderBy(x => x.PropertyName)
                                        .Select(
                                             x => new
                                                  {
                                                      CSharpSafePrimaryKeyName = x.PropertyName.MakeSafeForCSharpClass(resourceClass.Name)
                                                  }),
                       IsDerivedEntity = resourceClass.Entity?.IsDerived, BaseClassNonPkPropertyList = resourceClass.NonIdentifyingProperties
                                                                                                                    .Where(
                                                                                                                         p => p.IsInherited &&
                                                                                                                              p.IsSynchronizedProperty())
                                                                                                                    .OrderBy(p => p.PropertyName)
                                                                                                                    .Select(
                                                                                                                         p => new
                                                                                                                              {
                                                                                                                                  BasePropertyName =
                                                                                                                                      p.PropertyName
                                                                                                                              }),
                       NonPrimaryKeyList = resourceClass.NonIdentifyingProperties
                                                        .Where(p => !p.IsInherited && p.IsSynchronizedProperty())

                                                         // Add mappings for UniqueId values defined on Person resources
                                                        .Concat(resourceClass.IdentifyingProperties.Where(p => IsDefiningUniqueId(resourceClass, p)))
                                                        .OrderBy(p => p.PropertyName)
                                                        .Select(
                                                             p => new
                                                                  {
                                                                      p.PropertyName, CSharpSafePropertyName =
                                                                          p.PropertyName.MakeSafeForCSharpClass(resourceClass.Name)
                                                                  }),
                       HasOneToOneRelationships = resourceClass.EmbeddedObjects.Any(), OneToOneClassList = resourceClass.EmbeddedObjects
                                                                                                                        .Select(
                                                                                                                             x => new
                                                                                                                                  {
                                                                                                                                      OtherClassName =
                                                                                                                                          x.PropertyName
                                                                                                                                  }),
                       BaseNavigableChildrenList = resourceClass.Collections
                                                                .Where(c => c.IsInherited)
                                                                .Select(
                                                                     c => new
                                                                          {
                                                                              OtherClassPlural = c.PropertyName, OtherClassSingular = c.ItemType.Name
                                                                          }),
                       NavigableChildrenList = resourceClass.Collections
                                                            .Where(c => !c.IsInherited)
                                                            .Select(
                                                                 c => new
                                                                      {
                                                                          IsExtensionClass = resourceClass.IsResourceExtensionClass,
                                                                          IsCollectionAggregateExtension = c.ItemType.Entity.IsAggregateExtensionTopLevelEntity,
                                                                          ParentName = (resourceClass as ResourceChildItem)?.Parent.Name,
                                                                          ChildClassPlural = c.PropertyName, ChildClassSingular = c.ItemType.Name
                                                                      }),

                       // Only Ed-Fi Standard entities that are non-lookups can have extensions
                       IsExtendable = resourceClass.IsEdFiStandardResource
                                      && !resourceClass.IsLookup()
                                      && !resourceClass.IsDescriptorEntity()
                                      && !resourceClass.IsAbstract(),
                       IsBaseClassConcrete = IsBaseClassConcrete(resourceClass), IsBaseEntity = resourceClass.Entity?.IsBase,
                       DerivedEntitiesList = BuildDerivedEntities(resourceClass), IsRootEntity = resourceClass is Resource, ContextualKeysList =
                           resourceClass.IdentifyingProperties
                                        .OrderBy(p => p.PropertyName)
                                        .Select(
                                             p => new
                                                  {
                                                      CSharpSafePropertyName = p.PropertyName.MakeSafeForCSharpClass(resourceClass.Name)
                                                  }),
                       SourceSupportPropertyList = BuildSourceSupportProperties(resourceClass), FilterDelegatePropertyList = resourceClass.Collections
                                                                                                                                          .OrderBy(
                                                                                                                                               c => c
                                                                                                                                                   .ItemType
                                                                                                                                                   .Name)
                                                                                                                                          .Select(
                                                                                                                                               c => new
                                                                                                                                                    {
                                                                                                                                                        PropertyName
                                                                                                                                                            = c
                                                                                                                                                             .ItemType
                                                                                                                                                             .Name
                                                                                                                                                    }),
                       HasAggregateReferences =
                           resourceClass.Entity?.GetAssociationsToReferenceableAggregateRoots(includeInherited: true).Any(),
                       AggregateReferences =
                           resourceClass.Entity?.GetAssociationsToReferenceableAggregateRoots(includeInherited: true)
                                        .OrderBy(a => a.Name)
                                        .Select(
                                             a => new
                                                  {
                                                      AggregateReferenceName = a.Name,
                                                      MappedReferenceDataHasDiscriminator = a.OtherEntity.HasDiscriminator()
                                                  })
                   };
        }

        private static bool IsDefiningUniqueId(ResourceClassBase resourceClass, ResourceProperty property)
        {
            return UniqueIdSpecification.IsUniqueId(property.PropertyName)
                   && PersonEntitySpecification.IsPersonEntity(resourceClass.Name);
        }

        private bool IsBaseClassConcrete(ResourceClassBase resourceClass)
        {
            if (resourceClass.Entity == null)
            {
                return false;
            }

            return resourceClass.Entity.IsDerived
                   && resourceClass.Entity.BaseEntity != null
                   && !resourceClass.Entity.BaseEntity.IsAbstractRequiringNoCompositeId();
        }

        private IEnumerable<object> BuildDerivedEntities(ResourceClassBase resourceClass)
        {
            if (resourceClass.Entity == null)
            {
                return new object[0];
            }

            return resourceClass.Entity.DerivedEntities
                                .Select(
                                     x => new
                                          {
                                              DerivedEntityName = x.Name
                                          })
                                .OrderBy(x => x.DerivedEntityName);
        }

        /// <summary>
        /// This method will build a list of contextually-identifying keys,
        /// but will add leading and trailing annotations to be used during the rendering
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private IEnumerable<object> AnnotateLocalIdentifyingPropertyKeys(Entity entity)
        {
            if (entity == null)
            {
                return new List<object>();
            }

            var contextualIdList = entity.ContextualIdentifyingProperties
                                         .Select(x => x.GetModelsInterfacePropertyName())
                                         .OrderBy(s => s)
                                         .ToList();

            if (!contextualIdList.Any())
            {
                return new List<object>();
            }

            string first = contextualIdList.First();
            string last = contextualIdList.Last();

            return contextualIdList.Select(
                x => new
                     {
                         PrimaryKeyName = x, NotFirst = x != first, IsLast = x == last
                     });
        }

        private IEnumerable<object> BuildSourceSupportProperties(ResourceClassBase resourceClass)
        {
            return resourceClass.AllProperties

                                 // Don't include properties that are not sychronizable
                                .Where(p => p.IsSynchronizedProperty())

                                 // Don't include identifying properties, with the exception of where UniqueIds are defined
                                .Where(p => !p.IsIdentifying || IsDefiningUniqueId(resourceClass, p))
                                .Select(p => p.PropertyName)

                                 // Add embedded object properties
                                .Concat(
                                     resourceClass.EmbeddedObjects.Cast<ResourceMemberBase>()
                                                  .Concat(resourceClass.Extensions)
                                                  .Concat(resourceClass.Collections)
                                                  .Select(rc => rc.PropertyName))
                                .Distinct()
                                .OrderBy(pn => pn)
                                .Select(
                                     pn => new
                                           {
                                               PropertyName = pn
                                           });
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntitiesForQueries : GeneratorBase
    {
        private const string QueryModelSuffix = "Q";
        private static readonly object NotRendered = null;
        private readonly IViewsProvider _viewsProvider;
        private readonly IDatabaseTypeTranslator _databaseTypeTranslator;
        private Func<Entity, bool> _shouldRenderEntityForSchema;

        public EntitiesForQueries(IViewsProvider viewsProvider, IDatabaseTypeTranslator databaseTypeTranslator)
        {
            Preconditions.ThrowIfNull(viewsProvider, nameof(viewsProvider));
            Preconditions.ThrowIfNull(databaseTypeTranslator, nameof(databaseTypeTranslator));

            _viewsProvider = viewsProvider;
            _databaseTypeTranslator = databaseTypeTranslator;
        }

        protected override void Configure()
        {
            _shouldRenderEntityForSchema = TemplateContext.ShouldRenderEntity;
        }

        protected override object Build()
        {
            var domainModel = TemplateContext.DomainModelProvider.GetDomainModel();

            var orderedAggregates = domainModel.Aggregates
                                               .Where(
                                                    a =>
                                                        a.Members.Any(
                                                            e => _shouldRenderEntityForSchema(e)
                                                                 || e.Extensions.Any(
                                                                     ex =>
                                                                         _shouldRenderEntityForSchema
                                                                             (ex))))
                                               .OrderBy(x => x.FullName.Name);

            var result = new
                         {
                             Aggregates = orderedAggregates
                                .Select(
                                     aggregate => new
                                                  {
                                                      AggregateName = aggregate.Name, AggregateNamespace =
                                                          aggregate.AggregateRoot.AggregateQueryNamespace(
                                                              TemplateContext.SchemaProperCaseName,
                                                              TemplateContext.IsExtension),
                                                      Classes = aggregate.Members.Where(
                                                                              e =>
                                                                                  _shouldRenderEntityForSchema(e))
                                                                         .Concat(
                                                                              aggregate.Members.SelectMany(m => m.Extensions)
                                                                                       .Where(ex => _shouldRenderEntityForSchema(ex)))
                                                                         .SelectMany(entity => GetClasses(aggregate, entity)),
                                                      HasDiscriminator = aggregate.AggregateRoot.HasDiscriminator()
                                                  })
                         };

            return result;
        }

        private IEnumerable<object> GetClasses(Aggregate aggregate, Entity entity)
        {
            var classContexts = GetClassGenerationContexts(entity);

            foreach (var classContext in classContexts)
            {
                var contextualSuffixes = GetContextualClassAndPropertyNameSuffixes(entity);

                foreach (var contextualSuffix in contextualSuffixes)
                {
                    yield return
                        new
                        {
                            AggregateName = aggregate.Name, ClassName = entity.Name, TableName = entity.Name, SchemaName = entity.Schema,
                            ClassNameSuffix = QueryModelSuffix, ContextualClassNameSuffix = contextualSuffix.ClassNameSuffix, entity.IsAggregateRoot,
                            entity.IsAbstract, entity.IsDerived, classContext.IsConcreteEntityBaseClass,
                            classContext.IsConcreteEntityChildClassForBase, BaseAggregateRootRelativeNamespace =
                                entity.IsDerived
                                    ? entity.BaseEntity.GetRelativeEntityNamespace(
                                          entity.BaseEntity.SchemaProperCaseName(),
                                          true,
                                          !entity.BaseEntity.IsEdFiStandardEntity)
                                      + (!entity.BaseEntity.IsAbstract
                                          ? "Base"
                                          : string.Empty)
                                      + QueryModelSuffix
                                    : NotRendered,
                            PrimaryKey = new
                                         {
                                             ParentReference = entity.ParentAssociation != null
                                                 ? new
                                                   {
                                                       ParentClassName = entity.Parent.Name, FullyQualifiedParentClassName =
                                                           $"{entity.GetRelativeAggregateNamespace(entity.Parent.IsEdFiStandardEntity ? EdFiConventions.ProperCaseName : TemplateContext.SchemaProperCaseName, isQueryModel: true)}.{entity.Parent.Name}",
                                                       ContextualSuffix = (classContext.IsConcreteEntityChildClassForBase
                                                                              ? "Base"
                                                                              : string.Empty)
                                                                          + QueryModelSuffix
                                                   }
                                                 : NotRendered,
                                             NonParentProperties = entity
                                                                  .Identifier
                                                                  .Properties
                                                                  .Where(p => !p.IsFromParent)
                                                                  .Select(
                                                                       p => new
                                                                            {
                                                                                entity.IsAbstract,
                                                                                NeedsOverride = entity.IsDerived && !p.IsInheritedIdentifyingRenamed,
                                                                                CSharpDeclaredType =
                                                                                    p.PropertyType.ToCSharp(includeNullability: true),
                                                                                CSharpSafePropertyName =
                                                                                    p.PropertyName.MakeSafeForCSharpClass(entity.Name)
                                                                            })
                                         },
                            Properties = GetMappedProperties(entity, contextualSuffix)
                                        .OrderBy(p => p.PropertyName)
                                        .Select(
                                             p => new
                                                  {
                                                      CSharpDeclaredType = p.PropertyType.ToCSharp(includeNullability: true), PropertyName = p.PropertyName.ToMixedCase()
                                                  }),
                            HasOneToOnes = GetMappedNavigableOneToOnes(entity).Any(), OneToOnes = GetMappedNavigableOneToOnes(entity)
                               .Select(
                                    a => new
                                         {
                                             OtherClassName = a.OtherEntity.Name, ClassNameSuffix = QueryModelSuffix
                                         }),
                            NavigableChildren = GetMappedCollectionAssociations(entity)
                                               .Where(a => _shouldRenderEntityForSchema(a.OtherEntity))
                                               .OrderBy(a => a.Name)
                                               .SelectMany(a => GetContextualNavigableChildren(a, classContext)),
                            HasNonNavigableChildren = GetMappedExternalCollectionAssociations(entity)
                               .Any(a => _shouldRenderEntityForSchema(a.OtherEntity)),
                            NonNavigableChildren = GetMappedExternalCollectionAssociations(entity)
                                                  .Where(a => _shouldRenderEntityForSchema(a.OtherEntity))
                                                  .OrderBy(a => a.Name)
                                                  .SelectMany(GetContextualNonNavigableChildren),
                            HasNonNavigableParents = GetMappedExternalParentAssociations(entity)
                               .Any(a => _shouldRenderEntityForSchema(a.OtherEntity)),
                            NonNavigableParents = GetMappedExternalParentAssociations(entity)
                                                 .Where(a => _shouldRenderEntityForSchema(a.OtherEntity))
                                                 .OrderBy(a => a.Name)
                                                 .Select(
                                                      a => new
                                                           {
                                                               AggregateRelativeNamespace = a.OtherEntity.GetRelativeAggregateNamespace(
                                                                   TemplateContext.SchemaProperCaseName,
                                                                   isQueryModel: true,
                                                                   isExtensionContext: TemplateContext.IsExtension),
                                                               ClassName = a.OtherEntity.Name, ClassNameSuffix = QueryModelSuffix,
                                                               AssociationName = a.Name
                                                           })
                        };
                }
            }
        }

        private static IEnumerable<AssociationView> GetMappedNavigableOneToOnes(Entity entity)
        {
            return entity.NavigableOneToOnes;
        }

        private static IEnumerable<AssociationView> GetMappedExternalCollectionAssociations(Entity entity)
        {
            return entity.NonNavigableChildren

                          // NOTE: This filter prevents collections related to hierarchical structures from being rendered. It may make sense to include these.
                         .Where(a => !a.IsSelfReferencing && !(a.IsSelfReferencingManyToMany && a.AssociatesEntitiesOfTheSameAggregate));
        }

        private static IEnumerable<AssociationView> GetMappedCollectionAssociations(Entity entity)
        {
            return entity.NavigableChildren

                          // NOTE: This concatenation adds in self-many-to-many collections under "Collections", while removing the filter on 
                          // GetMappedExternalCollectionAssociations will allow it to come in there, which is more appropriate, and then the following
                          // statement could be removed.
                         .Concat(entity.NonNavigableChildren.Where(a => a.AssociatesEntitiesOfTheSameAggregate && a.IsSelfReferencingManyToMany));
        }

        private static IEnumerable<EntityProperty> GetMappedProperties(Entity entity, SuffixesContext contextualSuffix)
        {
            var properties = contextualSuffix.ViewProperties.Any()
                ? contextualSuffix.ViewProperties
                : entity.NonIdentifyingProperties;

            return properties.Where(p => !p.IsAlreadyDefinedInCSharpEntityBaseClasses());
        }

        private static IEnumerable<AssociationView> GetMappedExternalParentAssociations(Entity entity)
        {
            return entity.NonNavigableParents;
        }

        private IEnumerable<object> GetContextualNavigableChildren(AssociationView a, ClassContext classContext)
        {
            var childContexts = GetContextualClassAndPropertyNameSuffixes(a.OtherEntity);

            foreach (var childContext in childContexts)
            {
                yield return new
                             {
                                 ClassNameSuffix = QueryModelSuffix + childContext.ClassNameSuffix, ChildClassName = a.OtherEntity.Name,
                                 AssociationName = a.Name + childContext.PropertyNameSuffix,
                                 IsChildForConcreteBase = classContext.IsConcreteEntityBaseClass
                             };
            }
        }

        private IEnumerable<object> GetContextualNonNavigableChildren(AssociationView a)
        {
            var childContexts = GetContextualClassAndPropertyNameSuffixes(a.OtherEntity);

            foreach (var childContext in childContexts)
            {
                yield return new
                             {
                                 AggregateRelativeNamespace =
                                     a.OtherEntity.GetRelativeAggregateNamespace(
                                         a.OtherEntity.ResolvedEdFiEntity()
                                          .SchemaProperCaseName(),
                                         isQueryModel: true,
                                         isExtensionContext: !a.OtherEntity.ResolvedEdFiEntity()
                                                               .IsEdFiStandardEntity),
                                 ChildClassName = a.OtherEntity.ResolvedEdFiEntityName() + QueryModelSuffix,
                                 ChildClassNameSuffix = childContext.ClassNameSuffix, AssociationName = a.Name, childContext.PropertyNameSuffix
                             };
            }
        }

        private static IEnumerable<ClassContext> GetClassGenerationContexts(Entity entity)
        {
            yield return new ClassContext();

            if (!entity.IsAbstract && entity.IsBase)
            {
                // For concrete base classes, we also need to generate a separate class to act as the base for the derived classes (an NHibernate mapping requirement)
                yield return
                    new ClassContext
                    {
                        IsConcreteEntityBaseClass = true, IsConcreteEntityChildClassForBase = false
                    };
            }
            else if (!entity.IsAggregateRoot // For child classes
                     && !entity.Aggregate.AggregateRoot.IsAbstract // Where the aggregate root is not abstract
                     && entity.Aggregate.AggregateRoot.IsBase) // ... and the aggregate root is a base class
            {
                // For children of concrete base classes, we need to generate a separate class for when the parent is having the special base class generated
                yield return
                    new ClassContext
                    {
                        IsConcreteEntityBaseClass = false, IsConcreteEntityChildClassForBase = true
                    };
            }
        }

        private IEnumerable<SuffixesContext> GetContextualClassAndPropertyNameSuffixes(Entity entity)
        {
            yield return new SuffixesContext();

            // Build the expected name for a hierarchical view (by convention)
            // TODO: Embedded convention - Building hierarchical view name
            var hierarchicalViewFqn = new FullName(entity.Schema, entity.Name + "H");

            // Find the hierarchical view, by convention
            var view = _viewsProvider.LoadViews()
                                              .SingleOrDefault(v => new FullName(v.SchemaOwner, v.Name) == hierarchicalViewFqn);

            if (entity.HasSelfReferencingAssociations || view != null)
            {
                // Query the hierarchy recursively
                var context = new SuffixesContext
                              {
                                  ClassNameSuffix = "H", PropertyNameSuffix = "Hierarchy"
                              };

                var columns = view.Columns.Where(c => !c.IsPrimaryKey)

                                   // Filter out boilerplate properties
                                  .Where(x => !IsAlreadyExplicitlyGeneratedInTemplate(x.Name))

                                   // Filter out properties that are part of the entity's identifier
                                  .Where(x => entity.Identifier.Properties.All(pkc => !pkc.PropertyName.EqualsIgnoreCase(x.Name)));

                // Convert the IDatabaseSchemaProvider properties to entity properties
                context.ViewProperties = columns
                   .Select(
                        c =>
                            new EntityProperty(
                                new EntityPropertyDefinition(
                                    c.Name.ToMixedCase(),
                                    new PropertyType(_databaseTypeTranslator.GetDbType(c.DbDataType), c.Length ?? 0, c.Precision ?? 0, c.Scale ?? 0, c.Nullable))));

                yield return context;
            }
        }

        private static bool IsAlreadyExplicitlyGeneratedInTemplate(string propertyName)
        {
            return new[]
                   {
                       "Id", "CreateDate", "LastModifiedDate"
                   }
               .Contains(propertyName);
        }

        /// <summary>
        /// Holds contextual information for the generation of the current NHibernate entity.
        /// </summary>
        /// <remarks>Due to how the mappings need to be generated to handle certain special scenarios 
        /// (e.g. concrete base classes and their children), multiple entities are sometimes generated for
        /// the same tables.  This context class captures the details pertinent to the variations
        /// required for the specific mappings being generated so that a single template and template driver 
        /// class can be used.</remarks>
        private class ClassContext
        {
            /// <summary>
            /// Indicates whether the current class mapping being generated is the "base class" version for
            /// an entity that is a concrete base entity (a base type that is not also abstract).
            /// </summary>
            public bool IsConcreteEntityBaseClass { get; set; }

            /// <summary>
            /// Indicates whether the current class mapping being generated is for one of the child collection
            /// classes for the specialized "base class" mapping.
            /// </summary>
            public bool IsConcreteEntityChildClassForBase { get; set; }
        }

        private class SuffixesContext
        {
            public SuffixesContext()
            {
                // Initialize array of view properties to an empty list
                ViewProperties = new EntityProperty[0];
            }

            public string ClassNameSuffix { get; set; }

            public string PropertyNameSuffix { get; set; }

            /// <summary>
            /// Contains additional properties extracted from the hierarchical database view found for the specified entity.
            /// </summary>
            public IEnumerable<EntityProperty> ViewProperties { get; set; }
        }
    }
}

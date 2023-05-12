// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.CodeGen.Models.Templates;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntityOrmMappings : GeneratorBase
    {
        private readonly IAuthorizationDatabaseTableViewsProvider _authorizationDatabaseTableViewsProvider;
        private readonly IDatabaseTypeTranslator _databaseTypeTranslator;
        private Dictionary<Entity, List<ClassMappingContext>> _classMappingsForEntities;
        private Func<Entity, bool> _shouldRenderEntityForSchema;
        private readonly string _propertyAccessor = $"EdFi.Ods.Common.Infrastructure.Accessors.EmbeddedObjectPropertyAccessor, EdFi.Ods.Common";

        public EntityOrmMappings(IAuthorizationDatabaseTableViewsProvider authorizationDatabaseTableViewsProvider, IDatabaseTypeTranslator databaseTypeTranslator)
        {
            Preconditions.ThrowIfNull(authorizationDatabaseTableViewsProvider, nameof(authorizationDatabaseTableViewsProvider));
            Preconditions.ThrowIfNull(databaseTypeTranslator, nameof(databaseTypeTranslator));

            _authorizationDatabaseTableViewsProvider = authorizationDatabaseTableViewsProvider;
            _databaseTypeTranslator = databaseTypeTranslator;
        }

        public bool GenerateQueryModel { get; set; }

        protected override void Configure()
        {
            _shouldRenderEntityForSchema = TemplateContext.ShouldRenderEntity;
        }

        protected override object Build()
        {
            var domainModel = TemplateContext.DomainModelProvider.GetDomainModel();

            var orderedAggregates = domainModel
                .Aggregates.Where(
                    a => a.Members.Any(
                        e => _shouldRenderEntityForSchema(e)
                             || e.Extensions.Any(ex => _shouldRenderEntityForSchema(ex))))
                .OrderBy(x => x.FullName.Name)
                .ToList();

            //Initialize.
            _classMappingsForEntities = new Dictionary<Entity, List<ClassMappingContext>>();

            var distinctOrderedAggregates = orderedAggregates
                .SelectMany(
                    x => x.Members.Where(e => _shouldRenderEntityForSchema(e))
                        .Concat(
                            x.Members.SelectMany(m => m.Extensions)
                                .Where(ex => _shouldRenderEntityForSchema(ex))))
                .Distinct();

            foreach (Entity entity in distinctOrderedAggregates)
            {
                _classMappingsForEntities[entity] = CreateContextsForGeneratingMultipleClassMappings(entity, GenerateQueryModel);
            }

            return
                new OrmMapping
                {
                    Assembly = TemplateContext.IsExtension
                        ? PathHelper.GetProjectNameFromProjectPath(TemplateContext.ProjectPath)
                        : Namespaces.Standard.BaseNamespace,
                    Namespace = GenerateQueryModel
                        ? Namespaces.Entities.NHibernate.QueryModels.BaseNamespace
                        : Namespaces.Entities.NHibernate.BaseNamespace,
                    Aggregates =
                        orderedAggregates
                            .Select(
                                aggregate => new OrmAggregate
                                {
                                    Classes = aggregate
                                        .Members

                                        // Derived classes are mapped within their base entity mapping, so exclude top level mappings for these classes
                                        .Where(c => !c.IsDerived && _shouldRenderEntityForSchema(c))
                                        .Concat(
                                            aggregate.Members.SelectMany(m => m.Extensions)
                                                .Where(ex => _shouldRenderEntityForSchema(ex)))
                                        .SelectMany(GetClassMappings)
                                        .ToList()
                                })
                            .ToList()
                };

            List<ClassMappingContext> CreateContextsForGeneratingMultipleClassMappings(Entity entity, bool isQueryModel)
            {
                var contexts = new List<ClassMappingContext>
                {
                    // Add the default context
                    new ClassMappingContext {IsQueryModel = isQueryModel}
                };

                if (entity.IsBase && !entity.IsAbstract)
                {
                    // Concrete base classes need an additional specialized mapping created
                    contexts.Add(
                        new ClassMappingContext
                        {
                            IsConcreteEntityBaseMapping = true,
                            IsQueryModel = isQueryModel
                        });
                }

                if (entity.Parent != null && entity.Parent.IsBase && !entity.Parent.IsAbstract && !entity.IsEntityExtension)
                {
                    // Children of concrete base classes need an additional specialized mapping created
                    contexts.Add(
                        new ClassMappingContext
                        {
                            IsConcreteEntityChildMappingForBase = true,
                            IsQueryModel = isQueryModel
                        });
                }

                return contexts;
            }

            IEnumerable<OrmClass> GetClassMappings(Entity entity)
            {
                var contexts = _classMappingsForEntities[entity];

                bool hasDiscriminator = entity.HasDiscriminator();

                foreach (var classMappingContext in contexts)
                {
                    string fullyQualifiedClassName = GetEntityFullNameForContext(entity, classMappingContext);

                    yield return new OrmClass
                    {
                        ClassName = fullyQualifiedClassName,
                        ReferenceClassName = fullyQualifiedClassName + "ReferenceData",
                        TableName = entity.TableName(TemplateContext.TemplateSet.DatabaseEngine, entity.Name),
                        SchemaName =
                            EdFiConventions.IsEdFiPhysicalSchemaName(entity.Schema)
                                ? null
                                : entity.Schema,
                        IsAggregateRoot = entity.IsAggregateRoot,
                        IsAbstract = entity.IsAbstract,
                        Id = !HasKeyRequiringUseOfCompositeId(entity)
                            ? CreateId()
                            : null,
                        CompositeId = HasKeyRequiringUseOfCompositeId(entity)
                            ? CreateCompositeId(classMappingContext)
                            : null,
                        Properties = GetOrderedNonIdentifyingProperties(entity, classMappingContext)
                            .ToList(),
                        HasOneToOneChildMappings = entity.NavigableOneToOnes.Any(),
                        OneToOneChildMappings = entity.NavigableOneToOnes
                            .Where(a => _shouldRenderEntityForSchema(a.OtherEntity))
                            .Select(ch => CreateOrmOneToOne(ch, classMappingContext))
                            .ToList(),
                        HasBackReferences = classMappingContext.IsQueryModel && entity.NonNavigableParents.Any(),
                        BackReferences =
                            classMappingContext.IsQueryModel
                                ? entity.NonNavigableParents.OrderBy(p => p.Name)
                                    .Where(p => _shouldRenderEntityForSchema(p.OtherEntity))
                                    .Select(CreateOrmBackReference)
                                    .ToList()
                                : null,
                        Collections = entity.NavigableChildren
                            .Concat(
                                classMappingContext.IsQueryModel
                                    ? entity.NonNavigableChildren
                                    : new AssociationView[0])
                            .Where(
                                ch => !(classMappingContext.IsQueryModel && ch.IsSelfReferencing) &&
                                      _shouldRenderEntityForSchema(ch.OtherEntity))
                            .OrderBy(ch => ch.Name)
                            .Select(ch => CreateNHibernateCollectionMapping(ch, classMappingContext))
                            .ToList(),
                        IsConcreteEntityBaseMapping = classMappingContext.IsConcreteEntityBaseMapping,
                        HasDiscriminator = hasDiscriminator,
                        IsReferenceable = entity.IsReferenceable(),
                        HasDerivedEntities = entity.IsBase,
                        HasDiscriminatorWhereClause = hasDiscriminator && entity.IsBase,
                        DerivedEntities = CreateDerivedEntities()
                            .ToList(),
                        IsQueryModelContext = classMappingContext.IsQueryModel,
                        AggregateReferences = !classMappingContext.IsQueryModel
                            ? entity.GetAssociationsToReferenceableAggregateRoots()
                                .OrderBy(a => a.Name)
                                .Select(CreateOrmAggregateReference)
                                .ToList()
                            : null
                    };
                }

                OrmCompositeIdentity CreateCompositeId(ClassMappingContext classMappingContext)
                {
                    return new OrmCompositeIdentity
                    {
                        KeyProperties = entity.Identifier.Properties
                            .Where(p => !p.IsFromParent)
                            .OrderBy(p => p.PropertyName)
                            .Select(
                                p => new OrmProperty
                                {
                                    PropertyName = p.PropertyName.MakeSafeForCSharpClass(entity.Name),
                                    ColumnName = p.ColumnName(TemplateContext.TemplateSet.DatabaseEngine, p.PropertyName),
                                    NHibernateTypeName = p.PropertyType.ToNHibernateType(),
                                    MaxLength = GetMaxLength(p),
                                    MinLength = GetMinLength(p)
                                })
                            .ToList(),
                        KeyManyToOne = entity.ParentAssociation == null
                            ? null
                            : new OrmManyToOne
                            {
                                Name = entity.ParentAssociation.Name,
                                HasClassName = classMappingContext.IsConcreteEntityChildMappingForBase,
                                ClassName =
                                    classMappingContext.IsConcreteEntityChildMappingForBase
                                        ? GetEntityFullNameForContext(
                                            entity.Parent,
                                            _classMappingsForEntities[entity.Parent]
                                                .FirstOrDefault(x => x.IsConcreteEntityBaseMapping)
                                            ?? _classMappingsForEntities[entity.Parent]
                                                .First())
                                        : null,
                                OrderedParentColumns = entity.ParentAssociation.Inverse.GetOrderedAssociationTargetColumns()
                                    .Select(
                                        p => new OrmColumn
                                        {
                                            Name = p.ColumnName(TemplateContext.TemplateSet.DatabaseEngine, p.PropertyName)
                                        })
                                    .ToList()
                            }
                    };
                }

                OrmProperty CreateId()
                {
                    return new OrmProperty
                    {
                        PropertyName = entity.Identifier.Properties.Single()
                            .PropertyName,
                        ColumnName = entity.Identifier.Properties.Single()
                            .ColumnName(
                                TemplateContext.TemplateSet.DatabaseEngine,
                                entity.Identifier.Properties.Single()
                                    .PropertyName),
                        NHibernateTypeName = entity.Identifier.Properties.Single()
                            .PropertyType.ToNHibernateType(),
                        MaxLength = GetMaxLength(entity.Identifier.Properties.Single()),
                        MinLength = GetMinLength(entity.Identifier.Properties.Single()),
                        GeneratorClass =
                            entity.Identifier.Properties.Single()
                                .IsServerAssigned
                                ? "identity"
                                : "assigned"
                    };
                }

                OrmOneToOne CreateOrmOneToOne(AssociationView ch, ClassMappingContext classMappingContext)
                {
                    return new OrmOneToOne
                    {
                        Name = ch.OtherEntity.Name,
                        Access =
                            _propertyAccessor,
                        IsQueryModelMapping = classMappingContext.IsQueryModel,
                        ClassName = GetEntityFullNameForContext(
                            ch.OtherEntity,
                            _classMappingsForEntities[ch.OtherEntity]
                                .First()),
                        Columns = ch.GetOrderedAssociationTargetColumns()
                            .Select(
                                ep => new OrmColumn
                                {
                                    Name = ep.ColumnName(TemplateContext.TemplateSet.DatabaseEngine, ep.PropertyName)
                                })
                            .ToList()
                    };
                }

                OrmBackReference CreateOrmBackReference(AssociationView p)
                {
                    return new OrmBackReference
                    {
                        BagName = p.Name,
                        ParentClassName = GetEntityFullNameForContext(
                            p.OtherEntity,
                            _classMappingsForEntities[p.OtherEntity]
                                .First()),
                        Columns = p.Inverse.GetOrderedAssociationTargetColumns()
                            .Select(
                                ep => new OrmColumn
                                {
                                    Name = ep.ColumnName(TemplateContext.TemplateSet.DatabaseEngine, ep.PropertyName)
                                })
                            .ToList()
                    };
                }

                OrmAggregateReference CreateOrmAggregateReference(AssociationView a)
                {
                    return new OrmAggregateReference
                    {
                        BagName = a.Name + "ReferenceData",
                        AggregateReferenceClassName =
                            GetEntityFullNameForContext(
                                a.OtherEntity.TypeHierarchyRootEntity,
                                new ClassMappingContext {IsReference = true}),
                        Columns = a.Inverse.GetOrderedAssociationTargetColumns()
                            .Select(
                                p => new OrmColumn
                                {
                                    Name = p.ColumnName(TemplateContext.TemplateSet.DatabaseEngine, p.PropertyName)
                                })
                            .ToList()
                    };
                }

                IEnumerable<OrmDerivedEntity> CreateDerivedEntities()
                {
                    return entity
                        .DerivedEntities
                        .Where(
                            e => _shouldRenderEntityForSchema(e))
                        .Select(
                            e => new EntityAndContext
                            {
                                Entity = e,
                                Contexts = _classMappingsForEntities[e]
                            })
                        .SelectMany(
                            entityAndContexts => entityAndContexts
                                .Contexts
                                .Select(context => CreateOrmDerivedEntity(entityAndContexts, context)));

                    OrmDerivedEntity CreateOrmDerivedEntity(EntityAndContext entityAndContexts, ClassMappingContext context)
                    {
                        var e = entityAndContexts.Entity;

                        var derivedEntityClassMappingContext = context;

                        string className = GetEntityFullNameForContext(e, derivedEntityClassMappingContext);

                        return
                            new OrmDerivedEntity
                            {
                                IsJoinedSubclass = e.IsDescriptorEntity,
                                ClassName = className,
                                ReferenceClassName = className + "ReferenceData",
                                TableName = e.Name,
                                SchemaName = EdFiConventions.IsEdFiPhysicalSchemaName(e.Schema)
                                    ? null
                                    : e.Schema,
                                DiscriminatorValue = $"{e.Schema}.{e.Name}",
                                BaseTableName = e.BaseEntity.Name,
                                BaseTableSchemaName =
                                    EdFiConventions.IsEdFiPhysicalSchemaName(e.BaseEntity.Schema)
                                        ? null
                                        : e.BaseEntity.Schema,
                                KeyColumns = e.Identifier.Properties
                                    .OrderBy(p => p.PropertyName)
                                    .Select(p => new OrmColumn {Name = p.PropertyName})
                                    .ToList(),
                                KeyProperties = e.Identifier.Properties
                                    .OrderBy(p => p.PropertyName)
                                    .Select(
                                        p => new OrmProperty
                                        {
                                            PropertyName =
                                                p.PropertyName.MakeSafeForCSharpClass(entity.Name),
                                            ColumnName = p.ColumnName(TemplateContext.TemplateSet.DatabaseEngine, p.PropertyName),
                                            NHibernateTypeName = p.PropertyType.ToNHibernateType(),
                                            MaxLength = GetMaxLength(p),
                                            MinLength = GetMinLength(p)
                                        })
                                    .ToList(),
                                Properties = GetOrderedNonIdentifyingProperties(e, derivedEntityClassMappingContext)
                                    .ToList(),
                                AggregateReferences = !derivedEntityClassMappingContext.IsQueryModel
                                    ? e.GetAssociationsToReferenceableAggregateRoots()
                                        .OrderBy(a => a.Name)
                                        .Select(
                                            a => new OrmAggregateReference
                                            {
                                                BagName = a.Name + "ReferenceData",
                                                AggregateReferenceClassName =
                                                    GetEntityFullNameForContext(
                                                        a.OtherEntity.TypeHierarchyRootEntity,
                                                        new ClassMappingContext {IsReference = true}),
                                                Columns = a.Inverse
                                                    .GetOrderedAssociationTargetColumns()
                                                    .Select(
                                                        ep => new OrmColumn
                                                        {
                                                            Name = ep.ColumnName(
                                                                TemplateContext.TemplateSet.DatabaseEngine,
                                                                ep.PropertyName)
                                                        })
                                                    .ToList()
                                            })
                                        .ToList()
                                    : null,
                                HasBackReferences = derivedEntityClassMappingContext.IsQueryModel
                                                    && e.NonNavigableParents.Any(
                                                        r => _shouldRenderEntityForSchema(r.OtherEntity)),
                                BackReferences = derivedEntityClassMappingContext.IsQueryModel
                                    ? e.NonNavigableParents.OrderBy(p => p.Name)
                                        .Where(p => _shouldRenderEntityForSchema(p.OtherEntity))
                                        .Select(
                                            p => new OrmBackReference
                                            {
                                                BagName = p.Name,
                                                ParentClassName = GetEntityFullNameForContext(
                                                    p.OtherEntity,
                                                    _classMappingsForEntities[p.OtherEntity]
                                                        .First()),
                                                Columns = p.Inverse.GetOrderedAssociationTargetColumns()
                                                    .Select(
                                                        ep => new OrmColumn
                                                        {
                                                            Name = ep.ColumnName(
                                                                TemplateContext.TemplateSet.DatabaseEngine,
                                                                ep.PropertyName)
                                                        })
                                                    .ToList()
                                            })
                                        .ToList()
                                    : null,
                                Collections = e.NavigableChildren.Concat(
                                        derivedEntityClassMappingContext.IsQueryModel
                                            ? e.NonNavigableChildren
                                            : new AssociationView[0])
                                    .Where(
                                        ch => !(derivedEntityClassMappingContext.IsQueryModel &&
                                                ch.IsSelfReferencing) &&
                                              _shouldRenderEntityForSchema(ch.OtherEntity))
                                    .Select(
                                        ch
                                            => new OrmCollection
                                            {
                                                BagName = ch.Name,
                                                IsEmbeddedCollection =
                                                    !derivedEntityClassMappingContext.IsQueryModel,
                                                Columns = ch.GetOrderedAssociationTargetColumns()
                                                    .Select(
                                                        ep => new OrmColumn
                                                        {
                                                            Name = ep.ColumnName(
                                                                TemplateContext.TemplateSet.DatabaseEngine,
                                                                ep.PropertyName)
                                                        })
                                                    .ToList(),
                                                ClassName = GetEntityFullNameForContext(
                                                    ch.OtherEntity,
                                                    _classMappingsForEntities[ch.OtherEntity]
                                                        .First())
                                            })
                                    .ToList()
                            };
                    }
                }
            }

            OrmCollection CreateNHibernateCollectionMapping(
                AssociationView childAssociation,
                ClassMappingContext classMappingContext)
            {
                return new OrmCollection
                {
                    //Can't use classMappingContext.IsHierarchical here because this method is called 2x in that case.
                    BagName = childAssociation.Name,
                    IsEmbeddedCollection =
                        !classMappingContext.IsQueryModel && childAssociation.IsNavigable,
                    Columns = childAssociation.GetOrderedAssociationTargetColumns()
                        .Select(
                            ep => new OrmColumn
                            {
                                Name = ep.ColumnName(TemplateContext.TemplateSet.DatabaseEngine, ep.PropertyName)
                            })
                        .ToList(),
                    ClassName = GetEntityFullNameForContext(
                            childAssociation.OtherEntity,
                            classMappingContext.IsConcreteEntityBaseMapping
                                ? _classMappingsForEntities[childAssociation.OtherEntity]
                                      .FirstOrDefault(x => x.IsConcreteEntityChildMappingForBase) ??
                                  _classMappingsForEntities[childAssociation.OtherEntity]
                                      .First()
                                : _classMappingsForEntities[childAssociation.OtherEntity]
                                    .First())
                };
            }

            IEnumerable<NHibernatePropertyDefinition> GetOrderedNonIdentifyingProperties(
                Entity entity,
                ClassMappingContext classMappingContext)
            {
                return entity.NonIdentifyingProperties
                    .Where(p => !p.IsPredefinedProperty())
                    .Concat(classMappingContext.ViewProperties) // Add in properties found in the view in context, if any
                    .OrderBy(p => p.PropertyName)
                    .Select(
                        p => new NHibernatePropertyDefinition
                        {
                            PropertyName = p.PropertyName,
                            ColumnName = p.ColumnName(TemplateContext.TemplateSet.DatabaseEngine, p.PropertyName),
                            NHibernateTypeName = p.PropertyType.ToNHibernateType(),
                            MaxLength = GetMaxLength(p),
                            MinLength = GetMinLength(p),
                            IsNullable = p.PropertyType.IsNullable
                        });
            }

            string GetMaxLength(EntityProperty p)
            {
                return p.PropertyType.ToNHibernateType() == "string"
                    ? p.PropertyType.MaxLength.ToString()
                    : null;
            }

            string GetMinLength(EntityProperty p)
            {
                return p.PropertyType.ToNHibernateType() == "string"
                    ? p.PropertyType.MinLength.ToString()
                    : null;
            }
            bool HasKeyRequiringUseOfCompositeId(Entity m)
            {
                return

                    // It has a composite key structure
                    m.Identifier.Properties.Count > 1

                    // ... or it happens to have a single PK column in a one-to-one relationship
                    || m.Identifier.Properties.Single()
                        .IsFromParent;
            }
        }

        private string GetEntityFullNameForContext(Entity entity, ClassMappingContext classMappingContext)
        {
            return classMappingContext.IsQueryModel
                ? entity.EntityForQueryFullName(
                    entity.SchemaProperCaseName(),
                    GetClassNameSuffixForContext(),
                    TemplateContext.IsExtension)
                : entity.EntityTypeFullName(
                    entity.SchemaProperCaseName(),
                    GetClassNameSuffixForContext());

            string GetClassNameSuffixForContext()
            {
                StringBuilder suffixBuilder = new StringBuilder();

                if (classMappingContext.IsConcreteEntityChildMappingForBase)
                {
                    suffixBuilder.Append("ForBase");
                }

                if (classMappingContext.IsConcreteEntityBaseMapping)
                {
                    suffixBuilder.Append("Base");
                }

                if (classMappingContext.IsReference)
                {
                    suffixBuilder.Append("ReferenceData");
                }

                if (classMappingContext.IsQueryModel)
                {
                    suffixBuilder.Append("Q");
                }

                return suffixBuilder.ToString();
            }
        }

        /// <summary>
        /// Holds contextual information for the generation of the current NHibernate class mapping.
        /// </summary>
        /// <remarks>Due to how the mappings need to be generated to handle certain special scenarios
        /// (e.g. concrete base classes and their children), multiple mappings are sometimes generated for
        /// the same tables (entities).  This context class captures the details pertinent to the variations
        /// required for the specific mapping being generated so that a single template and template driver
        /// class can be used.</remarks>
        private class ClassMappingContext
        {
            public ClassMappingContext()
            {
                // Initialize array of view properties to an empty list
                ViewProperties = new EntityProperty[0];
            }

            /// <summary>
            /// Indicates whether the current class mapping being generated is the "base class" version for
            /// an entity that is a concrete base entity (a base type that is not also abstract).
            /// </summary>
            public bool IsConcreteEntityBaseMapping { get; set; }

            /// <summary>
            /// Indicates whether the current class mapping being generated is for one of the child collection
            /// classes for the specialized "base class" mapping.
            /// </summary>
            public bool IsConcreteEntityChildMappingForBase { get; set; }

            /// <summary>
            /// Indicates whether the class mapping is part of the query model mappings
            /// (rather than the persistent model mappings with aggregate boundaries).
            /// </summary>
            public bool IsQueryModel { get; set; }

            /// <summary>
            /// Contains additional properties extracted from the hierarchical database view found for the specified entity.
            /// </summary>
            public IEnumerable<EntityProperty> ViewProperties { get; set; }

            /// <summary>
            /// Indicates whether the class mapping is being generated for a class containing aggregate reference data.
            /// </summary>
            public bool IsReference { get; set; }
        }

        private class EntityAndContext
        {
            public Entity Entity { get; set; }

            public List<ClassMappingContext> Contexts { get; set; }
        }
    }
}

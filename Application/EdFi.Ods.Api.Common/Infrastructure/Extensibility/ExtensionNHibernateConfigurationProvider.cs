// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using NHibernate.Cfg.MappingSchema;

namespace EdFi.Ods.Api.Common.Infrastructure.Extensibility
{
    public class ExtensionNHibernateConfigurationProvider : IExtensionNHibernateConfigurationProvider
    {
        private readonly IAssembliesProvider _assembliesProvider;
        private readonly string _assemblyName;
        private readonly DatabaseEngine _databaseEngine;
        private readonly DomainModel _domainModel;

        public ExtensionNHibernateConfigurationProvider(IDomainModelProvider domainModelProvider,
            IAssembliesProvider assembliesProvider, DatabaseEngine databaseEngine, string assemblyName)
        {
            _assembliesProvider = Preconditions.ThrowIfNull(assembliesProvider, nameof(assembliesProvider));
            _databaseEngine = Preconditions.ThrowIfNull(databaseEngine, nameof(databaseEngine));
            _domainModel = Preconditions.ThrowIfNull(domainModelProvider, nameof(domainModelProvider)).GetDomainModel();
            _assemblyName = Preconditions.ThrowIfNull(assemblyName, nameof(assemblyName));
        }

        private string ProperCaseName
        {
            get => ExtensionsConventions.GetProperCaseNameFromAssemblyName(_assemblyName);
        }

        private string PhysicalName
        {
            get => _domainModel.SchemaNameMapProvider.GetSchemaMapByProperCaseName(ProperCaseName).PhysicalName;
        }

        public OrmMappingFileData OrmMappingFileData
        {
            get
            {
                var assembly = _assembliesProvider.Get(_assemblyName);

                return new OrmMappingFileData
                {
                    Assembly = assembly,
                    MappingFileFullNames = new[]
                        {
                            $"{assembly.GetName().Name}.{OrmMappingFileConventions.EntityOrmMappings}.{_databaseEngine.ScriptsFolderName}.{OrmMappingFileConventions.EntityOrmMappingsGeneratedHbm}"
                        }
                };
            }
        }

        /// <summary>
        /// Returns a dictionary with entity name as the key and the associated extension hbm bag (which wraps the extension object in a collection for mapping purposes)
        /// </summary>
        public IDictionary<string, HbmBag> EntityExtensionHbmBagByEntityName
        {
            get => CreateExtensionEntityExtensionHbmBagByEntityName();
        }

        /// <summary>
        /// Returns a dictionary keyed by Ed-Fi standard entity name, containing the aggregate extension collections as an hbm bag
        /// </summary>
        public IDictionary<string, HbmBag[]> AggregateExtensionHbmBagsByEntityName
        {
            get => CreateAggregateExtensionHbmBagsByEntityName();
        }

        /// <summary>
        /// Returns a dictionary keyed by Ed-Fi standard base entity name, containing the derived entity discriminators as HbmJoinedSubclasses.
        /// </summary>
        public IDictionary<string, HbmJoinedSubclass[]> NonDiscriminatorBasedHbmJoinedSubclassesByEntityName
        {
            get => CreateNonDiscriminatorBasedHbmJoinedSubclassesByEntityName();
        }

        /// <summary>
        /// Returns a dictionary keyed by Ed-Fi standard base entity name, containing the derived entity as HbmSubclass. (Discriminator is required)
        /// </summary>
        public IDictionary<string, HbmSubclass[]> DiscriminatorBasedHbmSubclassesByEntityName
        {
            get => CreateDiscriminatorBasedHbmSubclassesByEntityName();
        }

        private Dictionary<string, HbmBag> CreateExtensionEntityExtensionHbmBagByEntityName()
        {
            return Enumerable.Select(
                    _domainModel.Entities.Where(e => e.IsEntityExtension && e.Schema.Equals(PhysicalName)), e => new
                    {
                        EntityName = e.EdFiStandardEntityAssociation.OtherEntity.Name,
                        Bag = new HbmBag
                        {
                            name = ProperCaseName,
                            cascade = "all-delete-orphan",
                            inverse = true,
                            lazy = HbmCollectionLazy.False,
                            key = new HbmKey
                            {
                                column = e.EdFiStandardEntityAssociation.Inverse.GetOrderedAssociationTargetColumns()
                                    .Select(
                                        p => new HbmColumn
                                        {
                                            name = p.ColumnName(_databaseEngine, p.PropertyName)
                                        }).ToArray()
                            },
                            Item = new HbmOneToMany {@class = GetExtensionEntityAssemblyQualifiedName(e)}
                        }
                    })
                .ToDictionary(k => k.EntityName, v => v.Bag);
        }

        private Dictionary<string, HbmBag[]> CreateAggregateExtensionHbmBagsByEntityName()
        {
            return _domainModel.Entities.Where(e => e.IsAggregateExtensionTopLevelEntity && e.Schema.Equals(PhysicalName))
                .Select(
                    e => new
                    {
                        EntityName = e.Parent.Name,
                        Bag = new HbmBag
                        {
                            name = e.ParentAssociation.Inverse.GetAggregateExtensionBagName(),
                            cascade = "all-delete-orphan",
                            inverse = true,
                            lazy = HbmCollectionLazy.False,
                            key = new HbmKey
                            {
                                column = e.ParentAssociation.Inverse.GetOrderedAssociationTargetColumns()
                                    .Select(
                                        p => new HbmColumn
                                        {
                                            name = p.ColumnName(_databaseEngine, p.PropertyName)
                                        }).ToArray()
                            },
                            Item = new HbmOneToMany {@class = GetExtensionEntityAssemblyQualifiedName(e)}
                        }
                    })
                .GroupBy(x => x.EntityName, x => x.Bag)
                .ToDictionary(x => x.Key, x => x.ToArray());
        }

        private Dictionary<string, HbmJoinedSubclass[]> CreateNonDiscriminatorBasedHbmJoinedSubclassesByEntityName()
        {
            return Enumerable.Select(
                    _domainModel.Entities
                        .Where(e => e.IsDerived && e.IsExtensionEntity && e.Schema.Equals(PhysicalName) && e.IsDescriptorEntity), e => new
                    {
                        EntityName = !e.BaseEntity.IsAbstract
                            ? $"{e.BaseEntity.Name}Base"
                            : e.BaseEntity.Name,
                        HbmJoinedSubclass = CreateHbmJoinSubclass(e)
                    })
                .GroupBy(x => x.EntityName, x => x.HbmJoinedSubclass)
                .ToDictionary(x => x.Key, x => x.ToArray());

            HbmJoinedSubclass CreateHbmJoinSubclass(Entity entity)
            {
                var properties = Enumerable.ToArray<object>(
                        entity.Properties
                            .OrderBy(p => p.PropertyName)
                            .Select(p => CreateHbmProperty(p, entity)));

                var references = Enumerable.ToArray<object>(entity.NavigableOneToOnes.Select(CreateHbmBag));

                return new HbmJoinedSubclass
                {
                    table = entity.TableName(_databaseEngine),
                    schema = PhysicalName,
                    name = GetExtensionEntityAssemblyQualifiedName(entity),
                    key = CreateHbmKey(entity.Properties.Where(p => p.IsIdentifying).OrderBy(p => p.PropertyName)),
                    Items = properties.Concat(references).ToArray(),
                    lazy = false
                };

                HbmBag CreateHbmBag(AssociationView association)
                {
                    return new
                        HbmBag
                        {
                            name = $"{association.Name}",
                            cascade = "all-delete-orphan",
                            inverse = true,
                            lazy = HbmCollectionLazy.False,
                            key = CreateHbmKey(
                                association.OtherEntity.Properties.Where(p => p.IsIdentifying).OrderBy(p => p.PropertyName)),
                            Item = new HbmOneToMany {@class = GetExtensionEntityAssemblyQualifiedName(association.OtherEntity)}
                        };
                }
            }
        }

        private Dictionary<string, HbmSubclass[]> CreateDiscriminatorBasedHbmSubclassesByEntityName()
        {
            return Enumerable.Select(
                    _domainModel.Entities
                        .Where(
                            e => e.IsDerived && e.IsExtensionEntity && e.Schema.Equals(PhysicalName) &&
                                 !e.BaseEntity.Schema.Equals(PhysicalName) && !e.IsDescriptorEntity), e => new
                    {
                        EntityName = !e.BaseEntity.IsAbstract
                            ? $"{e.BaseEntity.Name}Base"
                            : e.BaseEntity.Name,
                        HbmSubclass = CreateHbmSubclass(e)
                    })
                .GroupBy(x => x.EntityName, x => x.HbmSubclass)
                .ToDictionary(x => x.Key, x => x.ToArray());

            HbmSubclass CreateHbmSubclass(Entity entity)
            {
                var properties = Enumerable.ToArray<object>(
                        GetRenamedIdentifyingProperties()
                            .Concat(entity.NonIdentifyingProperties)
                            .Where(p => !p.IsPredefinedProperty())
                            .OrderBy(p => p.PropertyName)
                            .Select(p => CreateHbmProperty(p, entity)));

                var collections = Enumerable.ToArray<object>(
                        entity.NavigableChildren
                            .Where(c => !c.IsSelfReferencing)
                            .Select(CreateHbmSet));

                var aggregateReferences = entity.GetAssociationsToReferenceableAggregateRoots()
                    .OrderBy(a => a.Name)
                    .Select(CreateHbmManyToOne)
                    .ToArray<object>();

                var hbmJoin = new HbmJoin
                {
                    table = entity.TableName(_databaseEngine),
                    schema = entity.Schema,
                    key = CreateHbmKey(
                        entity.Properties.Where(p => p.IsIdentifying)
                            .OrderBy(p => p.PropertyName)),
                    Items = collections
                        .Concat(aggregateReferences)
                        .Concat(properties)
                        .ToArray()
                };

                return new HbmSubclass
                {
                    name = GetExtensionEntityAssemblyQualifiedName(entity),
                    lazy = false,
                    discriminatorvalue = $"{entity.Schema}.{entity.Name}",
                    @join = new[] {hbmJoin}
                };

                IEnumerable<EntityProperty> GetRenamedIdentifyingProperties()
                {
                    return entity.BaseAssociation
                        .PropertyMappings
                        .Where(pm => pm.OtherProperty.PropertyName != pm.ThisProperty.PropertyName)
                        .Select(pm => pm.ThisProperty);
                }

                HbmSet CreateHbmSet(AssociationView association)
                {
                    return new HbmSet
                    {
                        key = CreateHbmKey(
                            association.PropertyMappings
                                .Where(pm => !pm.ThisProperty.IsFromParent)
                                .OrderBy(pm => pm.ThisProperty.PropertyName)
                                .Select(pm => pm.OtherProperty)),
                        name = association.Name,
                        cascade = "all-delete-orphan",
                        inverse = true,
                        lazy = HbmCollectionLazy.False,
                        Item = new HbmOneToMany {@class = GetExtensionEntityAssemblyQualifiedName(association.OtherEntity)}
                    };
                }

                HbmManyToOne CreateHbmManyToOne(AssociationView association)
                {
                    var otherEntity = association.OtherEntity.TypeHierarchyRootEntity;

                    return new HbmManyToOne
                    {
                        name = association.Name + "ReferenceData",
                        @class = otherEntity
                            .EntityTypeFullName(otherEntity.SchemaProperCaseName(), "ReferenceData"),
                        fetch = HbmFetchMode.Join,
                        insert = false,
                        update = false,
                        cascade = "none",
                        lazy = HbmLaziness.Proxy,
                        Items = association.Inverse
                            .GetOrderedAssociationTargetColumns()
                            .Select(p =>
                                new HbmColumn
                                {
                                    name = p.PropertyName
                                })
                            .ToArray<object>()
                    };
                }
            }
        }

        private string GetExtensionEntityAssemblyQualifiedName(Entity extensionEntity)
        {
            string entityTypeName = extensionEntity.EntityTypeFullName(ProperCaseName);

            return $"{entityTypeName}, {_assemblyName}";
        }

        private HbmProperty CreateHbmProperty(EntityProperty p, Entity entity)
        {
            return new HbmProperty
            {
                name = p.PropertyName,
                column = p.ColumnName(_databaseEngine, p.PropertyName),
                notnull = !p.PropertyType.IsNullable,
                insert = !entity.Identifier.Properties
                    .Where(i => !i.IsFromParent)
                    .Contains(p),
                insertSpecified = entity.Identifier.Properties
                    .Where(i => !i.IsFromParent)
                    .Contains(p),
                type = new HbmType {name = p.PropertyType.ToNHibernateType()},
                lazy = false
            };
        }

        private HbmKey CreateHbmKey(IEnumerable<EntityProperty> properties)
        {
            return new HbmKey
            {
                column = properties
                    .Select(p => new HbmColumn {name = p.ColumnName(_databaseEngine, p.PropertyName)})
                    .ToArray()
            };
        }
    }
}

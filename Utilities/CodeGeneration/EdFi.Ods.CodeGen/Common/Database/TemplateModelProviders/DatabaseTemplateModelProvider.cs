// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EdFi.Common;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Dynamic;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Generator.Common.Database.Conventions;
using EdFi.Ods.Generator.Common.Database.DataTypes;
using EdFi.Ods.Generator.Common.Database.Domain;
using EdFi.Ods.Generator.Common.Database.NamingConventions;
using EdFi.Ods.Generator.Common.Options;
// using EdFi.Ods.Generator.Common.Rendering;
using EdFi.Ods.Generator.Common.Templating;
using log4net;

namespace EdFi.Ods.Generator.Common.Database.TemplateModelProviders
{
    public class DatabaseTemplateModelProvider : ITemplateModelProvider
    {
        private readonly IList<ITableEnhancer> _tableEnhancers;
        private readonly IList<IColumnEnhancer> _columnEnhancers;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DatabaseTemplateModelProvider));

        private readonly IDatabaseTypeTranslatorFactory _databaseTypeTranslatorFactory;
        private readonly IDatabaseNamingConventionFactory _databaseNamingConventionFactory;
        private readonly Lazy<DomainModel> _domainModel;

        private readonly string _databaseEngine;
        private readonly string _schema;

        private bool ShouldRenderEntityForSchema(Entity entity) => string.IsNullOrEmpty(_schema) || _schema.Equals(entity.Schema, StringComparison.OrdinalIgnoreCase);

        public DatabaseTemplateModelProvider(
            IDatabaseTypeTranslatorFactory databaseTypeTranslatorFactory,
            IDatabaseNamingConventionFactory databaseNamingConventionFactory,
            IDomainModelDefinitionsProviderSource domainModelDefinitionsProviderSource,
            IList<IDomainModelDefinitionsTransformer> domainModelDefinitionsTransformers,
            IList<ITableEnhancer> tableEnhancers,
            IList<IColumnEnhancer> columnEnhancers,
            IDatabaseOptions databaseOptions,
            IGeneratorOptions generatorOptions)
        {
            _tableEnhancers = tableEnhancers;
            _columnEnhancers = columnEnhancers;
            _databaseTypeTranslatorFactory = Preconditions.ThrowIfNull(databaseTypeTranslatorFactory, nameof(databaseTypeTranslatorFactory));
            _databaseNamingConventionFactory = Preconditions.ThrowIfNull(databaseNamingConventionFactory, nameof(databaseNamingConventionFactory));

            _renderingContext = generatorOptions.PropertyByName;
            
            var domainModelDefinitionProviders = new Lazy<List<IDomainModelDefinitionsProvider>>(
                () => domainModelDefinitionsProviderSource.GetDomainModelDefinitionProviders()
                    .ToList());

            var domainModelProvider = new Lazy<IDomainModelProvider>(
                () => new DomainModelProvider(domainModelDefinitionProviders.Value, domainModelDefinitionsTransformers.ToArray()));
            
            _domainModel = new Lazy<DomainModel>(() =>
            {
                var domainModel = domainModelProvider.Value.GetDomainModel();

                _logger.Info($"Domain model contains the following {domainModel.Schemas.Count} schema(s): {string.Join(", ", domainModel.Schemas.Select(s => $"{s.PhysicalName} ({domainModel.Entities.Count(e => e.Schema == s.PhysicalName)} entities)"))}");

                return domainModel;
            });
            
            _databaseEngine = databaseOptions.DatabaseEngine;
            _schema = databaseOptions.Schema;
        }

        private readonly IDictionary<FullName, IList<FullName>> _updatableAncestorsByEntity 
            = new Dictionary<FullName, IList<FullName>>();

        private IDictionary<string, string> _renderingContext;

        public object GetTemplateModel(IDictionary<string, string> properties)
        {
            var databaseEngine = _databaseEngine;

            var databaseNamingConvention = _databaseNamingConventionFactory.CreateNamingConvention(databaseEngine);
            var databaseTypeTranslator = _databaseTypeTranslatorFactory.CreateTranslator(databaseEngine);
            
            var domainModel = _domainModel.Value;

            var entitiesAndTables = domainModel.Entities
                .Where(ShouldRenderEntityForSchema)
                .OrderBy(e => e.FullName.Name)
                .Select(e => new { Entity = e, Table = CreateTable(e) })
                .ToArray();

            
            // Provide each table with access to aggregate root table to support common child table operations
            var entityAndTableByName = entitiesAndTables.ToDictionary(x => x.Entity.FullName, x => x);

            foreach (var entry in entityAndTableByName)
            {
                if (!entry.Value.Entity.IsAggregateRoot)
                {
                    if (entityAndTableByName.TryGetValue(entry.Value.Entity.Aggregate.FullName, out var aggregateRootEntry))
                    {
                        entry.Value.Table.AggregateRootTable = aggregateRootEntry.Table;
                    }
                }
            }

            // Create the database template model for code generation
            var model = new DatabaseTemplateModel
            {
                Schemas = domainModel.Entities
                    .Where(ShouldRenderEntityForSchema)
                    .Select(e => databaseNamingConvention.Schema(e))
                    .Distinct()
                    .Select(s => new SchemaInfo { Schema = s})
                    .ToArray(),
                Tables = entitiesAndTables
                    .Select(e => e.Table)
                    .ToArray(),
            };

            var dynamicModel = model as IDynamicModel; 
                
            // Add the properties supplied via the command-line to the template
            foreach (var kvp in properties)
            {
                dynamicModel.DynamicProperties.Add(kvp.Key, kvp.Value);
            }

            return model;
            
            Table CreateTable(Entity entity)
            {
                dynamic entityAsDynamic = entity;
                
                var table = new Table
                {
                    IsAggregateRoot = entity.IsAggregateRoot,
                    IsDerived = entity.IsDerived,
                    IsBase = entity.IsBase,
                    BaseTableSchema = entity.IsDerived ? databaseNamingConvention.Schema(entity.BaseEntity) : null,
                    BaseTableName = entity.IsDerived ? databaseNamingConvention.TableName(entity.BaseEntity) : null,
                    BaseAlternateKeyConstraintName = entity.IsDerived ? databaseNamingConvention.GetAlternateKeyConstraintName(entity.BaseEntity) : null,
                    BaseAlternateKeyColumns = entity.IsDerived ? entity.BaseEntity?.AlternateIdentifiers.FirstOrDefault()?.Properties.Select(
                        (p, i) => CreateColumn(p, i, entity.BaseEntity.AlternateIdentifiers.First().Properties))
                            .ToArray()
                        : null,
                    IsDescriptorTable = entity.IsDescriptorEntity,
                    IsDescriptorBaseTable = entity.IsDescriptorBaseEntity(),
                    IsEducationOrganizationDerivedTable = entity.IsEducationOrganizationDerivedEntity(),
                    IsEducationOrganizationBaseTable = entity.IsEducationOrganizationBaseEntity(),
                    IsPersonTypeTable = entity.IsPersonEntity(),
                    Schema = databaseNamingConvention.Schema(entity),
                    TableName = databaseNamingConvention.TableName(entity),
                    FullName = entity.FullName,

                    // TODO: ODS-5296 - Move LDS plugin
                    // HashKey = new HashKey
                    // {
                    //     ColumnName = databaseNamingConvention.ColumnName(entity.Name, "HashKey"),
                    //     IndexName = databaseNamingConvention.GetUniqueIndexName(entity, "HashKey")
                    // },
                    
                    PrimaryKeyConstraintName = databaseNamingConvention.PrimaryKeyConstraintName(entity),
                    PrimaryKeyColumns = entity.Identifier.Properties.Select(
                        (p, i) => CreateColumn(p, i, entity.Identifier.Properties)).ToArray(),
                    ContextualPrimaryKeyColumns = entity.Identifier.Properties
                        .Where(p => !entity.IsAggregateRoot)
                        .Where(p => !p.IsFromParent)
                        .Where(p => !entity.Aggregate.AggregateRoot.Identifier.Properties.Any(p2 => p2.PropertyName == p.PropertyName))
                        .Where(p => !p.IncomingAssociations.Any())
                        .Select((p, i) => CreateColumn(p, i))
                        .ToArray(), 
                    HasServerAssignedSurrogateId = entity.HasServerAssignedSurrogateId(),
                    SurrogateIdColumn = entity.Identifier.Properties
                        .Where(p => p.IsServerAssigned)
                        .Select((p, i) => CreateColumn(p, i))
                        .SingleOrDefault(),
                    HasAlternateKey = entity.AlternateIdentifiers.Any(),
                    AlternateKeyConstraintName = databaseNamingConvention.GetAlternateKeyConstraintName(entity),
                    AlternateKeyColumns = entity.AlternateIdentifiers.FirstOrDefault()?.Properties.Select(
                        (p, i) => CreateColumn(p, i, entity.AlternateIdentifiers.First().Properties))
                        .ToArray(),
                    
                    // ForeignKeyColumns = entity.IncomingAssociations
                    //     .Where(a => !a.IsNavigable)
                    //     .SelectMany(a => a.ThisProperties.Select(p => new Column
                    //     {
                    //         ColumnName = _databaseNamingConvention.CreateArtifactName(p.PropertyName),
                    //         DataType = p.PropertyType.ToSql().ToMetaEdPluginDataType(),
                    //         IsNullable = p.PropertyType.IsNullable,
                    //     })),
                    // Non-PK and Non-FK columns
                    NonPrimaryOrForeignKeyColumns = entity.Properties
                        .Where(p => !p.IsIdentifying && !p.IncomingAssociations.Any())
                        .Where(p => !p.IsBoilerplate())
                        .Select( (p, i) => CreateColumn(p, i))
                        .ToArray(),
                    // Non-PK columns
                    NonPrimaryKeyColumns = entity.Properties
                        .Where(p => !p.IsIdentifying && !p.IsBoilerplate())
                        .Select( (p, i) => CreateColumn(p, i))
                        .ToArray(),
                    // TODO: Think about whether and where this should be applied to the model through a transform. 
                    DiscriminatorColumn = entity.HasDiscriminator() ? ColumnHelper.CreateDiscriminatorColumn(databaseNamingConvention, databaseTypeTranslator) : null,
                    BoilerplateColumns = GetBoilerplateColumns(ordered: true).ToArray(),
                    // TODO: Review usage of this property and consider removal
                    BoilerplateColumnsUnsorted = GetBoilerplateColumns().ToArray(),
                    ForeignKeys = entity.IncomingAssociations
                        .GroupBy(association => databaseNamingConvention.ForeignKeyConstraintName(association), a => a)
                        .OrderBy(g => g.Key)
                        .SelectMany(g => g
                        .Select((a, associationIndex) => new ForeignKey
                        {
                            ConstraintName = databaseNamingConvention.ForeignKeyConstraintName(a, (associationIndex == 0 ? string.Empty : associationIndex.ToString())),
                            ThisSchema = databaseNamingConvention.Schema(a.ThisEntity),
                            ThisTableName = databaseNamingConvention.TableName(a.ThisEntity),
                            ThisColumns = a.ThisProperties.Select((p, i) => new Column
                            {
                                EntityProperty = p,
                                ColumnName = databaseNamingConvention.ColumnName(p),
                                DataType = databaseTypeTranslator.GetSqlType(p.PropertyType),
                                IsNullable = p.PropertyType.IsNullable,
                                IsDescriptorUsage = p.IsDescriptorUsage || (p.IsIdentifying && p.Entity.IsDescriptorEntity()),
                                IsFirst = i == 0,
                                Index = i,
                            }).ToArray(),
                            OtherSchema = databaseNamingConvention.Schema(a.OtherEntity),
                            OtherTableName = databaseNamingConvention.TableName(a.OtherEntity),
                            OtherColumns = a.OtherProperties.Select((p, i) => 
                                CreateColumn(p, i, a.OtherProperties))
                                .ToArray(),
                            IsFromBase = a.AssociationType == AssociationViewType.FromBase,
                            IsOneToOne = a.AssociationType == AssociationViewType.OneToOneIncoming,
                            // IsIdentifying = a.IsIdentifying,
                            IsNavigable = a.IsNavigable,
                            IsUpdatable = IsAssociationUpdatable(a),
                        }))
                        .ToArray(),
                    IdIndexName = databaseNamingConvention.GetUniqueIndexName(entity, "Id"),
                    // TODO: Move to ChangeQueries plugin as dynamic enhancement?
                    KeyValuesCanChange = entity.Identifier.IsUpdatable || (entity.IncomingAssociations.Any(a => a.IsIdentifying && IsAssociationUpdatable(a))),
                    // TODO: Move to LDS plugin as dynamic enhancement
                    IsTemporalTable = (entityAsDynamic.ReadHistory == true),
                };

                // Enhance the table
                var enhancedTable = table;
                
                foreach (var tableEnhancer in _tableEnhancers) // TODO: For future implementation - attribute-based filtering --> .Where(e => RenderingHelper.ShouldRunEnhancer(e, _renderingContext)))
                {
                    enhancedTable = tableEnhancer.EnhanceTable(entity, enhancedTable, enhancedTable);
                }

                return enhancedTable;
                
                bool IsAssociationUpdatable(AssociationView association)
                {
                    var sb = new StringBuilder();
                    
                    var updatableAncestors = GetAncestorsWithUpdatableIdentifier(association.OtherEntity, sb).ToArray();

                    if (updatableAncestors.Any())
                    {
                        // _logger.Debug($"Starting probe for updatable identifier on association '{association.Association.FullName}'.");
                        // _logger.Debug(sb.ToString());

                        var sb2 = new StringBuilder();
                        
                        // Get other incoming associations
                        var otherIncomingAssociationsWithSameUpdatableAncestor = association.ThisEntity.IncomingAssociations
                            .Where(a => a != association)
                            .Select(
                                a => new
                                {
                                    Association = a,
                                    UpdatableAncestors = GetAncestorsWithUpdatableIdentifier(a.OtherEntity, sb2)
                                })
                            .Where(x => x.UpdatableAncestors.Intersect(updatableAncestors).Any())
                            .Select(x => x.Association)
                            .ToArray();

                        if (!otherIncomingAssociationsWithSameUpdatableAncestor.Any())
                        {
                            return true;
                        }

                        var chosenAssociation = otherIncomingAssociationsWithSameUpdatableAncestor
                            .Concat(new[] {association})
                            .OrderBy(a => a.Association.FullName.ToString(), StringComparer.OrdinalIgnoreCase)
                            .First();

                        return (chosenAssociation == association);
                    }

                    return false;
                }

                IEnumerable<FullName> GetAncestorsWithUpdatableIdentifier(Entity subjectEntity, StringBuilder sb)
                {
                    if (_updatableAncestorsByEntity.TryGetValue(subjectEntity.FullName, out var entityUpdatableAncestors))
                    {
                        return entityUpdatableAncestors;
                    }

                    var updatableAncestors = new List<FullName>();
                    
                    sb.AppendLine($"Probing entity '{subjectEntity.Name}' for updatable identifier.");

                    if (subjectEntity.Identifier.IsUpdatable)
                    {
                        sb.AppendLine($"Identifier for '{subjectEntity.Name}' is updatable.");

                        updatableAncestors.Add(subjectEntity.FullName);
                    }

                    foreach (var association in subjectEntity.IncomingAssociations.Where(a => a.IsIdentifying && !a.IsSelfReferencing))
                    {
                        sb.AppendLine($"Probing association '{association.Name}' for updatable identifier.");

                        var ancestorsWithUpdatableIdentifier = GetAncestorsWithUpdatableIdentifier(association.OtherEntity, sb);

                        updatableAncestors.AddRange(ancestorsWithUpdatableIdentifier);
                    }
                    
                    _updatableAncestorsByEntity[subjectEntity.FullName] = updatableAncestors;

                    return updatableAncestors;
                }

                IEnumerable<Column> GetBoilerplateColumns(bool ordered = false)
                {
                    var boilerplateProperties = entity.Properties
                        .Where(p => !p.IsIdentifying)
                        .Where(p => p.IsBoilerplate());

                    if (ordered)
                    {
                        boilerplateProperties = boilerplateProperties.OrderBy(p => Enum.Parse<ColumnConventions.BoilerplateColumn>(p.PropertyName));
                    }
                    
                    return boilerplateProperties
                        .Select((p, i) => new Column
                        {
                            EntityProperty = p,
                            ColumnName = databaseNamingConvention.ColumnName(p.PropertyName),
                            DataType = databaseTypeTranslator.GetSqlType(p.PropertyType),
                            IsNullable = p.PropertyType.IsNullable,
                            DefaultValue = p.PropertyType.DbType == DbType.DateTime2 
                                ? databaseNamingConvention.DefaultDateConstraintValue()
                                : (p.PropertyType.DbType == DbType.Guid 
                                    ? databaseNamingConvention.DefaultGuidConstraintValue()
                                    : null),
                            DefaultConstraintName = databaseNamingConvention.DefaultConstraintName(p),
                            IsFirst = i == 0,
                            IsBoilerplateId = p.PropertyName == ColumnConventions.BoilerplateColumn.Id.ToString()
                                && p.PropertyType.DbType == DbType.Guid
                        });
                }
            }

            Column CreateColumn(EntityProperty property, int index, IReadOnlyList<EntityProperty> contextualPropertySet = null)
            {
                var column = new Column
                {
                    EntityProperty = property, 
                    ColumnName = databaseNamingConvention.ColumnName(property),
                    DataType = databaseTypeTranslator.GetSqlType(property.PropertyType),
                    IsNullable = property.PropertyType.IsNullable,
                    IsServerAssigned = property.IsServerAssigned,
                    BaseColumnName = property.BaseProperty != null ? databaseNamingConvention.ColumnName(property.BaseProperty) : null,
                    IsFirst = index == 0,
                    IsLast = contextualPropertySet == null ? (bool?) null : (index == contextualPropertySet.Count - 1),
                    Index = index,
                    
                    // Ed-Fi-specific properties
                    IsDescriptorUsage = property.IsDescriptorUsage || (property.IsIdentifying && property.Entity.IsDescriptorEntity()),
                    IsPersonUSIUsage = property.DefiningProperty.Entity != property.Entity
                        && property.DefiningProperty.IsIdentifying 
                        && property.DefiningProperty.Entity.IsPersonEntity(),
                    PersonType = UniqueIdSpecification.GetUSIPersonType(property.DefiningProperty.PropertyName),
                };

                // Enhance the table
                var enhancedColumn = column;

                foreach (var columnEnhancer in _columnEnhancers) // TODO: For future implementation - attribute-based filtering --> .Where(e => RenderingHelper.ShouldRunEnhancer(e, _renderingContext)))
                {
                    enhancedColumn = columnEnhancer.EnhanceColumn(property, enhancedColumn, enhancedColumn);
                }

                return enhancedColumn;
            }
        }
    }
}

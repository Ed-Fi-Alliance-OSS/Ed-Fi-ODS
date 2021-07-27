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
using EdFi.Ods.Generator.Database.Conventions;
using EdFi.Ods.Generator.Database.DataTypes;
using EdFi.Ods.Generator.Database.Domain;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Database.TemplateModelProviders;
using EdFi.Ods.Generator.Templating;
using log4net;

namespace EdFi.Ods.Generator.Database.TemplateModelProviders
{
    public class DatabaseTemplateModelProvider : ITemplateModelProvider
    {
        private readonly IList<ITableEnhancer> _tableEnhancers;
        private readonly IList<IColumnEnhancer> _columnEnhancers;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DatabaseTemplateModelProvider));

        private readonly IDatabaseTypeTranslatorFactory _databaseTypeTranslatorFactory;
        private readonly IDatabaseNamingConventionFactory _databaseNamingConventionFactory;
        private readonly string _databaseEngine;
        private readonly Lazy<DomainModel> _domainModel;

        // TODO: Eliminate or refactor
        private readonly Func<Entity, bool> _shouldRenderEntityForSchema = e => true;

        public DatabaseTemplateModelProvider(
            IDatabaseTypeTranslatorFactory databaseTypeTranslatorFactory,
            IDatabaseNamingConventionFactory databaseNamingConventionFactory,
            IDomainModelDefinitionsProviderSource domainModelDefinitionsProviderSource,
            IList<IDomainModelDefinitionsTransformer> domainModelDefinitionsTransformers,
            IList<ITableEnhancer> tableEnhancers,
            IList<IColumnEnhancer> columnEnhancers,
            IDatabaseOptions databaseOptions)
        {
            _tableEnhancers = tableEnhancers;
            _columnEnhancers = columnEnhancers;
            _databaseTypeTranslatorFactory = Preconditions.ThrowIfNull(databaseTypeTranslatorFactory, nameof(databaseTypeTranslatorFactory));
            _databaseNamingConventionFactory = Preconditions.ThrowIfNull(databaseNamingConventionFactory, nameof(databaseNamingConventionFactory));

            var domainModelDefinitionProviders = new Lazy<List<IDomainModelDefinitionsProvider>>(
                () => domainModelDefinitionsProviderSource.GetDomainModelDefinitionProviders()
                    .ToList());

            var domainModelProvider = new Lazy<IDomainModelProvider>(
                () => new DomainModelProvider(domainModelDefinitionProviders.Value, domainModelDefinitionsTransformers.ToArray()));
            
            _domainModel = new Lazy<DomainModel>(() =>
            {
                var domainModel = domainModelProvider.Value.GetDomainModel();

                _logger.Debug($"Domain model contains the following {domainModel.Schemas.Count} schema(s): {string.Join(", ", domainModel.Schemas.Select(s => s.PhysicalName))}");

                return domainModel;
            });
            
            _databaseEngine = databaseOptions.DatabaseEngine;
        }

            // TODO: Move to LDS plugin

            // TODO: Move to ChangeQueries plugin
            public bool KeyValuesCanChange { get; set; }

        private readonly IDictionary<FullName, IList<FullName>> _updatableAncestorsByEntity 
            = new Dictionary<FullName, IList<FullName>>();

        public object GetTemplateModel(IDictionary<string, string> properties)
        {
            var databaseEngine = _databaseEngine;

            var databaseNamingConvention = _databaseNamingConventionFactory.CreateNamingConvention(databaseEngine);
            var databaseTypeTranslator = _databaseTypeTranslatorFactory.CreateTranslator(databaseEngine);
            
            var domainModel = _domainModel.Value;
            
            var model = new DatabaseTemplateModel
            {
                Schemas = domainModel.Entities
                    .Where(e => _shouldRenderEntityForSchema(e))
                    .Select(e => e.Schema)
                    .Distinct()
                    .Select(s => new SchemaInfo { Schema = s}),
                Tables = domainModel.Entities
                    .Where(e => _shouldRenderEntityForSchema(e))
                    .OrderBy(e => e.FullName.Name)
                    .Select(CreateTable)
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
                    BaseTableSchema = entity.BaseEntity?.Schema,
                    BaseTableName = entity.IsDerived ? databaseNamingConvention.TableName(entity.BaseEntity) : null,
                    BaseAlternateKeyConstraintName = entity.IsDerived ? databaseNamingConvention.GetAlternateKeyConstraintName(entity.BaseEntity) : null,
                    BaseAlternateKeyColumns = entity.IsDerived ? entity.BaseEntity?.AlternateIdentifiers.FirstOrDefault()?.Properties.Select(
                        (p, i) => CreateColumn(p, i, databaseNamingConvention, databaseTypeTranslator, entity.BaseEntity.AlternateIdentifiers.First().Properties))
                        : null,
                    IsDescriptorTable = entity.IsDescriptorEntity,
                    IsDescriptorBaseTable = entity.IsDescriptorBaseEntity(),
                    IsPersonTypeTable = entity.IsPersonEntity(),
                    Schema = entity.Schema,
                    TableName = databaseNamingConvention.TableName(entity), // entity.TableNameByDatabaseEngine[databaseEngine],
                    FullName = entity.FullName,
                    // TODO: Need to introduce naming strategy
                    HashKey = new HashKey
                    {
                        ColumnName = databaseNamingConvention.ColumnName($"{entity.Name}", "HashKey"),
                        IndexName = databaseNamingConvention.GetUniqueIndexName(entity, "HashKey")
                    },
                    PrimaryKeyConstraintName = databaseNamingConvention.PrimaryKeyConstraintName(entity),
                    PrimaryKeyColumns = entity.Identifier.Properties.Select(
                        (p, i) => CreateColumn(p, i, databaseNamingConvention, databaseTypeTranslator, entity.Identifier.Properties)),
                    ContextualPrimaryKeyColumns = entity.Identifier.Properties
                        .Where(p => !entity.IsAggregateRoot)
                        .Where(p => !p.IsFromParent)
                        .Where(p => !entity.Aggregate.AggregateRoot.Identifier.Properties.Any(p2 => p2.PropertyName == p.PropertyName))
                        .Where(p => !p.IncomingAssociations.Any())
                        .Select((p, i) => CreateColumn(p, i, databaseNamingConvention, databaseTypeTranslator)), 
                    HasServerAssignedSurrogateId = entity.Identifier.IsSurrogateIdentifierDefinition(),
                    SurrogateIdColumn = entity.Identifier.Properties
                        .Where(p => p.IsServerAssigned)
                        .Select((p, i) => CreateColumn(p, i, databaseNamingConvention, databaseTypeTranslator))
                        .SingleOrDefault(),
                    HasAlternateKey = entity.AlternateIdentifiers.Any(),
                    AlternateKeyConstraintName = databaseNamingConvention.GetAlternateKeyConstraintName(entity), // TODO: Needs Postgres support
                    AlternateKeyColumns = entity.AlternateIdentifiers.FirstOrDefault()?.Properties.Select(
                        (p, i) => CreateColumn(p, i, databaseNamingConvention, databaseTypeTranslator, entity.AlternateIdentifiers.First().Properties)),
                    IdentifyingReferences = entity.IncomingAssociations
                        .Where(a => a.IsIdentifying && a.OtherEntity != entity.Parent)
                        .Select(CreateHashReference),
                    References = entity.IncomingAssociations
                        .Where(a => !a.IsIdentifying)
                        .Select(CreateHashReference),
                    AllReferences = entity.IncomingAssociations
                        .Select(CreateHashReference),
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
                        .Select( (p, i) => CreateColumn(p, i, databaseNamingConvention, databaseTypeTranslator)),
                    // Non-PK columns
                    NonPrimaryKeyColumns = entity.Properties
                        .Where(p => !p.IsIdentifying && !p.IsBoilerplate())
                        .Select( (p, i) => CreateColumn(p, i, databaseNamingConvention, databaseTypeTranslator)),
                    // TODO: Think about whether and where this should be applied to the model through a transform. 
                    DiscriminatorColumn = entity.HasDiscriminator() ? ColumnHelper.CreateDiscriminatorColumn() : null,
                    BoilerplateColumns = GetBoilerplateColumns().OrderBy(c => Enum.Parse<ColumnConventions.BoilerplateColumn>(c.ColumnName)),
                    BoilerplateColumnsUnsorted = GetBoilerplateColumns(),
                    ForeignKeys = entity.IncomingAssociations
                        .GroupBy(association => databaseNamingConvention.ForeignKeyConstraintName(association), a => a)
                        .OrderBy(g => g.Key)
                        .SelectMany(g => g
                        .Select((a, associationIndex) => new ForeignKey
                        {
                            // TODO: Need multi-database targeting
                            ConstraintName = databaseNamingConvention.ForeignKeyConstraintName(a, (associationIndex == 0 ? string.Empty : associationIndex.ToString())),
                            ThisSchema = a.ThisEntity.Schema,
                            ThisTableName = databaseNamingConvention.TableName(a.ThisEntity),
                            ThisColumns = a.ThisProperties.Select((p, i) => new Column
                            {
                                ColumnName = databaseNamingConvention.ColumnName(p),
                                DataType = databaseTypeTranslator.GetSqlType(p.PropertyType),
                                IsNullable = p.PropertyType.IsNullable,
                                IsConcreteDescriptorId = p.IsLookup || (p.IsIdentifying && p.Entity.IsDescriptorEntity()),
                                IsFirst = i == 0,
                                Index = i,
                            }),
                            OtherSchema = a.OtherEntity.Schema,
                            OtherTableName = databaseNamingConvention.TableName(a.OtherEntity),
                            OtherColumns = a.OtherProperties.Select((p, i) => 
                                CreateColumn(p, i, databaseNamingConvention, databaseTypeTranslator, a.OtherProperties)),
                            IsFromBase = a.AssociationType == AssociationViewType.FromBase,
                            IsOneToOne = a.AssociationType == AssociationViewType.OneToOneIncoming,
                            // IsIdentifying = a.IsIdentifying,
                            IsNavigable = a.IsNavigable,
                            IsUpdatable = IsAssociationUpdatable(a),
                        })),
                    IdIndexName = databaseNamingConvention.GetUniqueIndexName(entity, "Id"),
                    // TODO: Move to ChangeQueries plugin as dynamic component?
                    KeyValuesCanChange = entity.Identifier.IsUpdatable || (entity.IncomingAssociations.Any(a => a.IsIdentifying && IsAssociationUpdatable(a))),
                    // TODO: Move to LDS plugin as dynamic enhancement
                    IsTemporal = (entityAsDynamic.ReadHistory == true),
                };

                // Enhance the table
                var enhancedTable = table;
                
                foreach (var tableEnhancer in _tableEnhancers)
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

                // string GetHashKeyIndexName(string thisTableName, string otherTableName = null, string roleName = null)
                // {
                //     string indexName;
                //
                //     if (otherTableName == null)
                //     {
                //         indexName = $"UX_{thisTableName}_HashKey";
                //     }
                //     else
                //     {
                //         indexName = $"IX_{roleName}{thisTableName}_{otherTableName}_HashKey";
                //     }
                //
                //     if (indexName.Length > 128)
                //         return indexName.Substring(0, 128);
                //
                //     return indexName;
                // }

                HashReference CreateHashReference(AssociationView association, int index = 0)
                {
                    if (association == null)
                    {
                        return null;
                    }
                    
                    return new HashReference
                    {
                        ReferencedTableSchema = databaseNamingConvention.Schema(association.OtherEntity),
                        ReferencedTableName = databaseNamingConvention.TableName(association.OtherEntity),
                        ReferenceMemberName = association.Name,
                        // TODO: REMOVE -- ConstraintName = databaseNamingConvention.ConstraintName(entity, association.OtherEntity, association.RoleName),
                        ConstraintName = databaseNamingConvention.ForeignKeyConstraintName(association),
                        IndexName = databaseNamingConvention.ForeignKeyIndexName(association, "HashKey"), 
                        Column = new Column
                        {
                            ColumnName = databaseNamingConvention.ColumnName($"{association.Name}HashKey"),
                            DataType = databaseTypeTranslator.GetSqlType(new PropertyType(DbType.Guid)),
                            IsNullable = !association.IsRequired,
                        },
                        ReferenceColumns = association.ThisProperties
                            .Select((p, i) => CreateColumn(p, i, databaseNamingConvention, databaseTypeTranslator, association.ThisProperties)), 
                        IsFirst = index == 0
                    };
                }

                IEnumerable<Column> GetBoilerplateColumns()
                {
                    return entity.Properties
                        .Where(p => !p.IsIdentifying)
                        .Where(p => p.IsBoilerplate())
                        .Select((p, i) => new Column
                        {
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
                        });
                }
            }
        }

        private Column CreateColumn(
            EntityProperty property,
            int index,
            IDatabaseNamingConvention databaseNamingConvention,
            IDatabaseTypeTranslator databaseTypeTranslator,
            IReadOnlyList<EntityProperty> contextualPropertySet = null)
        {
            var column = new Column
            {
                ColumnName = databaseNamingConvention.ColumnName(property),
                DataType = databaseTypeTranslator.GetSqlType(property.PropertyType),
                IsNullable = property.PropertyType.IsNullable,
                IsServerAssigned = property.IsServerAssigned,
                IsConcreteDescriptorId = property.IsLookup || (property.IsIdentifying && property.Entity.IsDescriptorEntity()),
                IsPersonUSIUsage = property.DefiningProperty.Entity != property.Entity
                    && property.DefiningProperty.IsIdentifying 
                    && property.DefiningProperty.Entity.IsPersonEntity(),
                PersonType = UniqueIdSpecification.GetUSIPersonType(property.DefiningProperty.PropertyName),
                BaseColumnName = property.BaseProperty != null ? databaseNamingConvention.ColumnName(property.BaseProperty) : null,
                IsFirst = index == 0,
                IsLast = contextualPropertySet == null ? (bool?) null : (index == contextualPropertySet.Count - 1),
                Index = index,
            };

            // Enhance the table
            var enhancedColumn = column;
                
            foreach (var columnEnhancer in _columnEnhancers)
            {
                enhancedColumn = columnEnhancer.EnhanceColumn(property, enhancedColumn, enhancedColumn);
            }

            return enhancedColumn;
        }
    }
}

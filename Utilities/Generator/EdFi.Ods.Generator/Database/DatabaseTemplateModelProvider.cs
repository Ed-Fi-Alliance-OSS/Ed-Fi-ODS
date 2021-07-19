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
using EdFi.Ods.Generator.Models;
using EdFi.Ods.Generator.Templating;
using log4net;

namespace EdFi.Ods.Generator.Database
{
    public class DatabaseTemplateModelProvider : ITemplateModelProvider
    {
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
            IDomainModelDefinitionsProviderProvider domainModelDefinitionsProviderProvider,
            IList<IDomainModelDefinitionsTransformer> domainModelDefinitionsTransformers,
            Options options)
        {
            _databaseTypeTranslatorFactory = Preconditions.ThrowIfNull(databaseTypeTranslatorFactory, nameof(databaseTypeTranslatorFactory));
            _databaseNamingConventionFactory = Preconditions.ThrowIfNull(databaseNamingConventionFactory, nameof(databaseNamingConventionFactory));

            var domainModelDefinitionProviders = new Lazy<List<IDomainModelDefinitionsProvider>>(
                () => domainModelDefinitionsProviderProvider.DomainModelDefinitionProviders()
                    .ToList());

            var domainModelProvider = new Lazy<IDomainModelProvider>(
                () => new DomainModelProvider(domainModelDefinitionProviders.Value, domainModelDefinitionsTransformers.ToArray()));
            
            _domainModel = new Lazy<DomainModel>(() => domainModelProvider.Value.GetDomainModel());
            
            _databaseEngine = options.DatabaseEngine;
        }

        private class Table : DynamicModelBase
        {
            public string Schema { get; set; }

            public string TableName { get; set; }

            public bool HasPrimaryKeyColumns
            {
                get => PrimaryKeyColumns.Any();
            }

            public IEnumerable<Column> PrimaryKeyColumns { get; set; }

            public bool HasContextualPrimaryKeyColumns
            {
                get => ContextualPrimaryKeyColumns.Any();
            }

            public IEnumerable<Column> ContextualPrimaryKeyColumns { get; set; }

            public IEnumerable<Column> ParentPrimaryKeyColumns
            {
                get => PrimaryKeyColumns
                    .Where(pkc => !ContextualPrimaryKeyColumns.Any(c => c.ColumnName == pkc.ColumnName))
                    .Select((pkc, i) => new Column
                    {
                        ColumnName = pkc.ColumnName,
                        DataType = pkc.DataType,
                        IsNullable = pkc.IsNullable,
                        IsFirst = i == 0,
                    });
            }
            
            public bool IsAggregateRoot { get; set; }

            public bool HasNonPrimaryOrForeignKeyColumns
            {
                get => NonPrimaryOrForeignKeyColumns.Any();
            }

            public bool HasNonPrimaryOrForeignKeyColumnsOrReferences
            {
                get => NonPrimaryOrForeignKeyColumns.Any() || References.Any();
            }

            /// <summary>
            /// Gets the columns that are not part of any primary or foreign key.
            /// </summary>
            public IEnumerable<Column> NonPrimaryOrForeignKeyColumns { get; set; }

            public bool HasBoilerplateColumns
            {
                get => BoilerplateColumns.Any();
            }

            public Column DiscriminatorColumn { get; set; }

            public IEnumerable<Column> BoilerplateColumns { get; set; }
            public IEnumerable<Column> BoilerplateColumnsUnsorted { get; set; }

            public bool HasReferences
            {
                get => References.Any();
            }

            /// <summary>
            /// Gets non-identifying references.
            /// </summary>
            public IEnumerable<HashReference> References { get; set; }

            public IEnumerable<HashReference> IdentifyingReferences { get; set; }

            public string PrimaryKeyConstraintName { get; set; }

            public bool HasNonPrimaryKeyColumns => NonPrimaryKeyColumns.Any();
            
            /// <summary>
            /// Gets all columns that are not part of the primary key, but are also not the boilerplate columns.
            /// </summary>
            public IEnumerable<Column> NonPrimaryKeyColumns { get; set; }

            public IEnumerable<ForeignKey> ForeignKeys { get; set; }

            public string IdIndexName { get; set; }

            public bool IsDerived { get; set; }


            public bool HasAllReferences => AllReferences.Any();

            /// <summary>
            /// Gets all references, identifying and non-identifying.
            /// </summary>
            public IEnumerable<HashReference> AllReferences { get; set; }

            public HashKey HashKey { get; set; }

            public bool HasAlternateKey { get; set; }

            public string AlternateKeyConstraintName { get; set; }

            public bool HasServerAssignedSurrogateId { get; set; }

            public Column SurrogateIdColumn { get; set; }
            
            public IEnumerable<Column> AlternateKeyColumns { get; set; }

            public bool IsDescriptorBaseTable { get; set; }

            public FullName FullName { get; set; }

            public bool IsPersonTypeTable { get; set; }

            public bool IsTemporal { get; set; }
            // /// <summary>
            // /// Gets the reference back to the parent.
            // /// </summary>
            // public HashReference ParentReference { get; set; }
        }

        private class Column : DynamicModelBase
        {
            public string ColumnName { get; set; }

            public string DataType { get; set; }

            public bool IsNullable { get; set; }

            public bool? IsFirst { get; set; }

            public string DefaultConstraintName { get; set; }
            public string DefaultValue { get; set; }
            
            public bool IsString
            {
                get => DataType.StartsWith("nvarchar"); // TODO: Need to add support for Postgres.
            }
            
            public bool IsGuid
            {
                get => DataType == "uniqueidentifier";
            }

            public bool IsNumber
            {
                get => DataType == "bit"
                    || DataType == "decimal"
                    || DataType == "int"
                    || DataType == "money"
                    || DataType == "smallint";
            }

            public bool IsDate
            {
                get => DataType == "datetime" || DataType == "datetime2" || DataType == "date";
            }
            
            public bool IsTime
            {
                get => DataType == "time";
            }

            public bool IsUnsupportedType => !IsString && !IsGuid && !IsNumber && !IsDate && !IsTime;
            
            public bool? IsLast { get; set; }

            public bool IsServerAssigned { get; set; }

            public int Index { get; set; }

            public bool IsConcreteDescriptorId { get; set; }

            /// <summary>
            /// Indicates whether the column represents an identifier (i.e the USI) for a specific type of person (e.g. Student/Staff/Parent).
            /// </summary>
            public bool IsPersonUSIUsage { get; set; }

            public string PersonType { get; set; }
        }

        private class ForeignKey
        {
            public string ConstraintName { get; set; }

            public string ThisSchema { get; set; }
            public string ThisTableName { get; set; }
            public IEnumerable<Column> ThisColumns { get; set; }
            public string OtherSchema { get; set; }
            public string OtherTableName { get; set; }
            public IEnumerable<Column> OtherColumns { get; set; }

            public bool IsFromBase { get; set; }

            // public bool IsIdentifying { get; set; }

            public bool IsNavigable { get; set; }

            public bool IsUpdatable { get; set; }

            public bool IsOneToOne { get; set; }
        }

        // TODO: Move to NDE plugin, add as dynamic
        private class HashKey
        {
            public string ColumnName { get; set; }
            
            public string IndexName { get; set; }
        }
        
        // TODO: Move to NDE plugin, add as dynamic
        private class HashReference
        {
            public string ReferencedTableSchema { get; set; }

            public string ReferencedTableName { get; set; }

            public Column Column { get; set; }

            public string ConstraintName { get; set; }

            public string ReferenceMemberName { get; set; } // TODO: This needs to be processed for Postgres naming limitations

            /// <summary>
            /// The physical columns whose values are composed into the hash key.
            /// </summary>
            public IEnumerable<Column> ReferenceColumns { get; set; }

            public bool IsFirst { get; set; }

            public string IndexName { get; set; }
        }

        private readonly IDictionary<FullName, IList<FullName>> _updatableAncestorsByEntity 
            = new Dictionary<FullName, IList<FullName>>();

        public class SchemaInfo
        {
            public string Schema { get; set; }
        }

        private class DatabaseArtifactsTemplateModel : DynamicModelBase
        {
            public IEnumerable<SchemaInfo> Schemas { get; set; }

            public IEnumerable<Table> Tables { get; set; }
        }

        public object GetTemplateModel(IDictionary<string, string> properties)
        {
            var databaseEngine = _databaseEngine;

            var databaseNamingConvention = _databaseNamingConventionFactory.CreateNamingConvention(databaseEngine);
            var databaseTypeTranslator = _databaseTypeTranslatorFactory.CreateTranslator(databaseEngine);
            
            var domainModel = _domainModel.Value;
            
            var model = new DatabaseArtifactsTemplateModel
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
                    HasServerAssignedSurrogateId = entity.HasServerAssignedSurrogateId(),
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
                    DiscriminatorColumn = entity.HasDiscriminator() ? CreateDiscriminatorColumn() : null,
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
                    IsTemporal = (entityAsDynamic.ReadHistory == true),
                };

                // TODO: Add seam for enhancements 
                return EnhanceTable(entity, table, table);
                
                bool IsAssociationUpdatable(AssociationView association)
                {
                    var sb = new StringBuilder();
                    
                    var updatableAncestors = GetAncestorsWithUpdatableIdentifier(association.OtherEntity, sb).ToArray();

                    if (updatableAncestors.Any())
                    {
                        _logger.Debug($"Starting probe for updatable identifier on association '{association.Association.FullName}'.");
                        _logger.Debug(sb.ToString());

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

        private static Column CreateDiscriminatorColumn() => new Column
        {
            ColumnName = "Discriminator",
            DataType = "nvarchar(128)",
            IsNullable = true,
        };

        private Table EnhanceTable(Entity entity, Table table, dynamic tableProps)
        {
            if (entity.Properties.Any(p => p.PropertyName == "ContextSchoolYear"))
            {
                tableProps.HasSchoolYearContext = true;
            }
            else
            {
                tableProps.HasSchoolYearContext = false;
            }

            // Add a column for the descriptor base - in contrast to existing model logic
            tableProps.DiscriminatorColumnForLds = entity.HasDiscriminator() || entity.IsDescriptorBaseEntity()
                ? CreateDiscriminatorColumn()
                : null;
            
                // if (entity.IsAggregateRoot 
                //     && entity.Identifier.Properties.Count() == 1
                //     && entity.Identifier.Properties.First().PropertyType.DbType == DbType.Int32
                //     && entity.AlternateIdentifiers.Any())
                // {
                //     table.PrimaryKeyColumns.First()
                // }
            return table;
        }

        private Column EnhanceColumn(EntityProperty property, Column column, dynamic columnProps)
        {
            if (property.PropertyName == "ContextSchoolYear")
            {
                columnProps.IsSchoolYearContext = true;
            }

            return column;
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
                IsFirst = index == 0,
                IsLast = contextualPropertySet == null ? (bool?) null : (index == contextualPropertySet.Count - 1),
                Index = index,
            };

            return EnhanceColumn(property, column, column);
        }
    }
}

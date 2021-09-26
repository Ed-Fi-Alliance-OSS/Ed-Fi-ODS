// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Generator.Database.NamingConventions;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesQueryMetadataProvider : IKeyChangesQueryMetadataProvider
    {
        private readonly IDatabaseNamingConvention _namingConvention;

        private readonly ConcurrentDictionary<FullName, KeyChangesQueryMetadata> _queryMetadataByResourceName =
            new ConcurrentDictionary<FullName, KeyChangesQueryMetadata>();

        private const string SourceTableAlias = "src";
        
        public KeyChangesQueryMetadataProvider(IDatabaseNamingConvention namingConvention)
        {
            _namingConvention = namingConvention;
        }
        
        public Query GetTemplateQuery(Resource resource)
        {
            // Optimize by caching the constructed query
            var keyChangesQueryMetadata = _queryMetadataByResourceName.GetOrAdd(
                resource.FullName,
                (fn) => CreateKeyChangesTemplateQuery(resource));

            return keyChangesQueryMetadata.TemplateQuery;
        }
        
        public QueryProjection[] GetIdentifierProjections(Resource resource)
        {
            // Optimize by caching the constructed query
            var keyChangesQueryMetadata = _queryMetadataByResourceName.GetOrAdd(
                resource.FullName,
                (fn) => CreateKeyChangesTemplateQuery(resource));

            return keyChangesQueryMetadata.Projections;
        }
        
        private KeyChangesQueryMetadata CreateKeyChangesTemplateQuery(Resource resource)
        {
            var entity = resource.Entity;
            
            var identifierProjections = CreateIdentifierProjections();

            var (changeTableSchema, changeTableName) = entity.IsDerived
                ? (ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix + _namingConvention.Schema(entity.BaseEntity), _namingConvention.TableName(entity.BaseEntity)) 
                : (ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix + _namingConvention.Schema(entity), _namingConvention.TableName(entity));

            var keyChangesQuery = new Query($"{changeTableSchema}.{changeTableName} AS {ChangeQueriesDatabaseConstants.TrackedChangesAlias}");

            keyChangesQuery.Select($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName("Id")}", $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}");
            
            SelectIdentifyingColumns();

            keyChangesQuery.OrderBy($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}");

            // ApplySourceTableExclusionForUndeletedItems();

            ApplyDiscriminatorCriteriaForDerivedEntities();

            ApplyKeyChangesOnlyCriteria();

            return new KeyChangesQueryMetadata
            {
                TemplateQuery = keyChangesQuery,
                Projections = identifierProjections
            };

            void SelectIdentifyingColumns()
            {
                string[] selectColumns = identifierProjections.SelectMany(x => x.SelectColumns)
                    .Select(
                        sc => sc.ColumnAlias == null
                            ? $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{sc.ColumnName}"
                            : $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{sc.ColumnName} AS {sc.ColumnAlias}")
                    .ToArray();

                keyChangesQuery.Select(selectColumns);
            }

            // void ApplySourceTableExclusionForUndeletedItems()
            // {
            //     // Source table exclusion to prevent items that have been re-added during the same change window from showing up as deletes
            //     keyChangesQuery.LeftJoin(
            //         $"{_namingConvention.Schema(entity)}.{_namingConvention.TableName(entity)} AS {SourceTableAlias}",
            //         join =>
            //         {
            //             foreach (var projection in identifierProjections)
            //             {
            //                 @join.On(
            //                     $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{projection.ChangeTableJoinColumnName}",
            //                     $"{SourceTableAlias}.{projection.SourceTableJoinColumnName}");
            //             }
            //
            //             return @join;
            //         });
            //
            //     keyChangesQuery.WhereNull(string.Concat(SourceTableAlias, ".", identifierProjections.First().SourceTableJoinColumnName));
            // }

            void ApplyDiscriminatorCriteriaForDerivedEntities()
            {
                // Add discriminator criteria, for derived types with a Discriminator on the base type only
                if (entity.IsDerived)
                {
                    keyChangesQuery.Where($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName("Discriminator")}", entity.FullName.ToString());
                }
            }

            // NEW
            void ApplyKeyChangesOnlyCriteria()
            {
                // Only return deletes
                var firstIdentifierProperty = // (IsDerivedFromEntityWithDiscriminator(entity) 
                    (entity.IsDerived ? entity.BaseEntity : entity)
                    .Identifier.Properties.First();

                string columnName = _namingConvention.ColumnName(
                    $"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{firstIdentifierProperty.PropertyName}");
                
                keyChangesQuery.WhereNotNull($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{columnName}");
            }
            
            QueryProjection[] CreateIdentifierProjections()
            {
                var projections = resource
                    .IdentifyingProperties
                    .Select(
                        rp =>
                        {
                            var changeTableJoinProperty = (entity.IsDerived ? rp.EntityProperty.BaseProperty : rp.EntityProperty);

                            return new QueryProjection
                            {
                                JsonPropertyName = rp.JsonPropertyName,
                                SelectColumns = GetSelectColumns(rp).ToArray(),

                                // TODO: Remove if really not used
                                //ChangeTableJoinColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeTableJoinProperty}"),
                                //SourceTableJoinColumnName = _namingConvention.ColumnName(rp.EntityProperty),
                                IsDescriptorUsage = rp.IsDescriptorUsage,
                            };
                        })
                    .ToArray();

                return projections;
            }
            
            IEnumerable<SelectColumn> GetSelectColumns(ResourceProperty resourceProperty)
            {
                var entityProperty = resourceProperty.EntityProperty;

                // This handles usages of DescriptorIds and USIs
                if (entityProperty.IsSurrogateIdentifierUsage())
                {
                    string[] SplitTerms(string text) => Regex.Matches(text, "([A-Z][^A-Z]+|[A-Z]+(?![^A-Z]))").SelectMany(m => m.Captures.Select(c => c.Value)).ToArray();
                    string[] TrimFinalTerm(string[] terms) => terms.Take(terms.Length - 1).ToArray(); 
                        
                    var allTerms = SplitTerms(entityProperty.PropertyName);
                    var baseTerms = TrimFinalTerm(allTerms);
                    
                    // For Descriptors, this returns Namespace/CodeValue, for Student/Staff/Parent is returns the UniqueId
                    var naturalIdentifyingProperties = entityProperty.DefiningProperty.Entity.NaturalIdentifyingProperties();

                    foreach (var naturalIdentifyingProperty in naturalIdentifyingProperties)
                    {
                        var naturalTerms = SplitTerms(naturalIdentifyingProperty.PropertyName);

                        var changeQueryColumnName = 
                            string.Join(string.Empty, baseTerms.TakeWhile(t => t != naturalTerms[0]).Concat(naturalTerms));
                        
                        yield return new SelectColumn
                        {
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeQueryColumnName}"),
                            ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeQueryColumnName}"),
                            JsonPropertyName = changeQueryColumnName.ToCamelCase(),
                            Qualifier = ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix,
                        };
                        
                        // NEW value
                        yield return new SelectColumn
                        {
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{changeQueryColumnName}"),
                            ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{changeQueryColumnName}"),
                            JsonPropertyName = changeQueryColumnName.ToCamelCase(),
                            Qualifier = ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix,
                        };
                    }

                    yield break;
                }

                // Handle identifying properties that are surrogate ids by performing column expansion to use the alternate identifier
                // (e.g. Student/Staff/Parent USI -> UniqueId, concrete Descriptors -> Namespace, CodeValue)
                if (entityProperty.IsSurrogateIdentifier())
                {
                    var naturalIdentifyingProperties = entityProperty.Entity.NaturalIdentifyingProperties();

                    foreach (var naturalIdentifyingProperty in naturalIdentifyingProperties)
                    {
                        yield return new SelectColumn
                        {
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),
                            ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),
                            JsonPropertyName = naturalIdentifyingProperty.PropertyName.ToCamelCase(),
                            Qualifier = ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix,
                        };
                        
                        // NEW value
                        yield return new SelectColumn
                        {
                            ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),
                            ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}"),
                            JsonPropertyName = naturalIdentifyingProperty.PropertyName.ToCamelCase(),
                            Qualifier = ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix,
                        };
                    }
                    
                    yield break;
                }
             
                if (IsDerivedFromEntityWithDiscriminator(entityProperty.Entity))
                {
                    yield return new SelectColumn
                    {
                        ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),
                        ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),
                        JsonPropertyName = resourceProperty.JsonPropertyName,
                        Qualifier = ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix,
                    };
                    
                    // NEW value
                    yield return new SelectColumn
                    {
                        ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),
                        ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}"),
                        JsonPropertyName = resourceProperty.JsonPropertyName,
                        Qualifier = ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix,
                    };
                    
                    yield break;
                }

                // Just return the column
                yield return new SelectColumn
                {
                    ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.PropertyName}"),
                    ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.PropertyName}"),
                    JsonPropertyName = resourceProperty.JsonPropertyName,
                    Qualifier = ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix,
                };

                // NEW value
                yield return new SelectColumn
                {
                    ColumnName = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.PropertyName}"),
                    ColumnAlias = _namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{entityProperty.PropertyName}"),
                    JsonPropertyName = resourceProperty.JsonPropertyName,
                    Qualifier = ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix,
                };
            }
            
            bool IsDerivedFromEntityWithDiscriminator(Entity entity) => entity.BaseEntity?.HasDiscriminator() == true;
        }
    }
}

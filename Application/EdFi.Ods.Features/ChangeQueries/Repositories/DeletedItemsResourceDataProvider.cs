// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Resources;
using Microsoft.AspNetCore.Http;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public class DeletedItemsResourceDataProvider : IDeletedItemsResourceDataProvider
    {
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;
        private readonly Compiler _sqlCompiler;

        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IDefaultPageSizeLimitProvider _defaultPageSizeLimitProvider;

        private const string TrackedChangesAlias = "c";
        private const string SourceTableAlias = "src";

        private readonly ConcurrentDictionary<FullName, DeletedItemsQueryMetadata> _queryMetadataByResourceName =
            new ConcurrentDictionary<FullName, DeletedItemsQueryMetadata>();
        
        public DeletedItemsResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IDomainModelProvider domainModelProvider,
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            Compiler sqlCompiler)
        {
            _dbProviderFactory = dbProviderFactory;
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
            _domainModelProvider = domainModelProvider;
            _defaultPageSizeLimitProvider = defaultPageSizeLimitProvider;
            _sqlCompiler = sqlCompiler;
        }

        public async Task<DeletedItemsResourceData> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters, IQueryCollection query)
        {
            // Optimize by caching the constructed query
            var deletesQueryMetadata = _queryMetadataByResourceName.GetOrAdd(
                resource.FullName,
                (fn) => CreateDeletesTemplateQuery(resource));

            var responseData = new DeletedItemsResourceData();

            using (var conn = _dbProviderFactory.CreateConnection())
            {
                conn.ConnectionString = _odsDatabaseConnectionStringProvider.GetConnectionString();
                await conn.OpenAsync();

                var db = new QueryFactory(conn, _sqlCompiler);
                var deletesQuery = db.FromQuery(deletesQueryMetadata.Query);

                deletesQuery.Offset(queryParameters.Offset ?? 0);
                deletesQuery.Limit(Math.Min(queryParameters.Limit ?? 25, _defaultPageSizeLimitProvider.GetDefaultPageSizeLimit()));
                
                ApplyChangeVersionCriteria(deletesQuery);

                // Execute query, casting to strong type to avoid use of dynamic
                var deletedItems = (List<object>) await deletesQuery.GetAsync();

                var deletedResources = deletedItems
                    .Cast<IDictionary<string, object>>()
                    .Select(
                        deletedItem => new DeletedResourceItem
                        {
                            Id = (Guid) deletedItem["Id"],
                            ChangeVersion = (long) deletedItem[ChangeQueriesDatabaseConstants.ChangeVersionColumnName],
                            KeyValues = GetIdentifierKeyValues(deletesQueryMetadata.Projections, deletedItem),
                        })
                    .ToList();

                responseData.DeletedResources = deletedResources;

                // TODO: GKM - Re-add support for counting Deletes
                if (queryParameters.TotalCount)
                {
                    var countQuery = db.FromQuery(deletesQueryMetadata.Query);
                    ApplyChangeVersionCriteria(countQuery);

                    var count = await countQuery.CountAsync<long>();
                    
                    responseData.Count = Convert.ToInt64(count);
                }
            }

            return responseData;

            void ApplyChangeVersionCriteria(Query deletesQuery)
            {
                if (queryParameters.MinChangeVersion.HasValue)
                {
                    deletesQuery.Where(
                        $"{TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}",
                        ">=",
                        new Variable("@MinChangeVersion"));
                }

                if (queryParameters.MaxChangeVersion.HasValue)
                {
                    deletesQuery.Where(
                        $"{TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}",
                        "<=",
                        new Variable("@MaxChangeVersion"));
                }

                if (queryParameters.MinChangeVersion.HasValue || queryParameters.MaxChangeVersion.HasValue)
                {
                    deletesQuery.Where(
                        q => q.Where(
                                q2 =>
                                {
                                    if (queryParameters.MinChangeVersion.HasValue)
                                    {
                                        q2.Where(
                                            $"{SourceTableAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}",
                                            ">=",
                                            new Variable("@MinChangeVersion"));
                                    }

                                    if (queryParameters.MaxChangeVersion.HasValue)
                                    {
                                        q2.Where(
                                            $"{SourceTableAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}",
                                            "<=",
                                            new Variable("@MaxChangeVersion"));
                                    }

                                    return q2;
                                })
                            .OrWhereNull($"{SourceTableAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}"));
                }

                if (queryParameters.MinChangeVersion.HasValue)
                {
                    deletesQuery.Variables["@MinChangeVersion"] = queryParameters.MinChangeVersion;
                }

                if (queryParameters.MinChangeVersion.HasValue)
                {
                    deletesQuery.Variables["@MaxChangeVersion"] = queryParameters.MaxChangeVersion;
                }
            }
        }

        private static Dictionary<string, object> GetIdentifierKeyValues(
            QueryProjection[] identifierProjections, 
            IDictionary<string, object> deletedItem)
        {
            var keyValues = new Dictionary<string, object>();

            foreach (var identifierMetadata in identifierProjections)
            {
                if (identifierMetadata.IsDescriptorUsage)
                {
                    string namespaceColumn = identifierMetadata.SelectColumns.FirstOrDefault(c => c.ColumnAlias.EndsWithIgnoreCase("Namespace"))?.ColumnAlias;
                    string codeValueColumn = identifierMetadata.SelectColumns.FirstOrDefault(c => c.ColumnAlias.EndsWith("CodeValue"))?.ColumnAlias;

                    if (namespaceColumn == null)
                    {
                        throw new Exception("Unable to find Namespace column in deleted item query results for building a descriptor URI.");
                    }
                    
                    if (codeValueColumn == null)
                    {
                        throw new Exception("Unable to find CodeValue column in deleted item query results for building a descriptor URI.");
                    }
                    
                    keyValues[identifierMetadata.JsonPropertyName] =
                        $"{deletedItem[namespaceColumn]}#{deletedItem[codeValueColumn]}";
                }
                else
                {
                    foreach (var selectColumn in identifierMetadata.SelectColumns)
                    {
                        keyValues[selectColumn.ColumnAlias] = deletedItem[selectColumn.ColumnAlias];
                    }
                }
            }

            return keyValues;
        }

        private DeletedItemsQueryMetadata CreateDeletesTemplateQuery(Resource resource)
        {
            var entity = resource.Entity;

            var identifierProjections = GetIdentifierProjections(resource);

            var (changeTableSchema, changeTableName) = entity.IsDerived //IsDerivedFromEntityWithDiscriminator(entity)
                ? (ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix + entity.BaseEntity.Schema, entity.BaseEntity.Name) 
                : (ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix + entity.Schema, entity.Name);

            var deletesQuery = new Query($"{changeTableSchema}.{changeTableName} AS {TrackedChangesAlias}");

            deletesQuery.Select($"{TrackedChangesAlias}.Id", $"{TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}");
            
            SelectIdentifyingColumns();

            deletesQuery.OrderBy($"{TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}");

            ApplySourceTableExclusionForUndeletedItems();

            ApplyDiscriminatorCriteriaForDerivedEntities();

            ApplyDeletesOnlyCriteria();

            return new DeletedItemsQueryMetadata
            {
                Query = deletesQuery,
                Projections = identifierProjections
            };

            void SelectIdentifyingColumns()
            {
                string[] selectColumns = identifierProjections.SelectMany(x => x.SelectColumns)
                    .Select(
                        x => x.ColumnAlias == null
                            ? $"{TrackedChangesAlias}.{x.ColumnName}"
                            : $"{TrackedChangesAlias}.{x.ColumnName} AS {x.ColumnAlias}")
                    .ToArray();

                deletesQuery.Select(selectColumns);
            }

            void ApplySourceTableExclusionForUndeletedItems()
            {
                // Source table exclusion to prevent items that have been re-added during the same change window from showing up as deletes
                deletesQuery.LeftJoin(
                    $"{entity.Schema}.{entity.Name} AS {SourceTableAlias}",
                    join =>
                    {
                        foreach (var projection in identifierProjections)
                        {
                            @join.On(
                                $"{TrackedChangesAlias}.{projection.ChangeTableJoinColumnName}",
                                $"{SourceTableAlias}.{projection.SourceTableJoinColumnName}");
                        }

                        return @join;
                    });

                deletesQuery.WhereNull(identifierProjections.First().SourceTableJoinColumnName);
            }

            void ApplyDiscriminatorCriteriaForDerivedEntities()
            {
                // Add discriminator criteria, for derived types with a Discriminator on the base type only
                if (IsDerivedFromEntityWithDiscriminator(entity))
                {
                    deletesQuery.Where($"{TrackedChangesAlias}.Discriminator", entity.FullName.ToString());

                    // TODO: GKM - Need to figure out if deletes of Discriminators can be supported through joins
                }
            }

            void ApplyDeletesOnlyCriteria()
            {
                // Only return deletes
                string firstIdentifierPropertyName = (entity.IsDerived // (IsDerivedFromEntityWithDiscriminator(entity)
                        ? entity.BaseEntity
                        : entity).Identifier.Properties.First()
                    .PropertyName;

                deletesQuery.WhereNull(
                    $"{TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{firstIdentifierPropertyName}");
            }
        }

        private QueryProjection[] GetIdentifierProjections(Resource resource)
        {
            var entity = resource.Entity;
            
            var identifierProjections = resource
                .IdentifyingProperties
                .Select(
                    rp =>
                    {
                        string changeTableJoinColumnName = (entity.IsDerived //(IsDerivedFromEntityWithDiscriminator(entity) 
                                ? rp.EntityProperty.BaseProperty 
                                : rp.EntityProperty)
                            .PropertyName;

                        return new QueryProjection
                        {
                            JsonPropertyName = rp.JsonPropertyName,
                            SelectColumns = GetSelectColumns(rp).ToArray(),

                            ChangeTableJoinColumnName = $"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeTableJoinColumnName}",
                            SourceTableJoinColumnName = rp.EntityProperty.PropertyName,
                            IsDescriptorUsage = rp.IsDescriptorUsage,
                        };
                    })
                .ToArray();

            return identifierProjections;
        }
 
        private bool IsDerivedFromEntityWithDiscriminator(Entity entity) => entity.BaseEntity?.HasDiscriminator() == true;

        private IEnumerable<SelectColumn> GetSelectColumns(ResourceProperty resourceProperty)
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

                    var changeQueryColumnName = string.Join(string.Empty,baseTerms.TakeWhile(t => t != naturalTerms[0]).Concat(naturalTerms));
                    
                    yield return new SelectColumn
                    {
                        ColumnName = $"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeQueryColumnName}",
                        ColumnAlias = changeQueryColumnName.ToCamelCase(),
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
                        ColumnName = $"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{naturalIdentifyingProperty.PropertyName}",
                        ColumnAlias = naturalIdentifyingProperty.PropertyName.ToCamelCase(),
                    };
                }
                
                yield break;
            }
         
            if (IsDerivedFromEntityWithDiscriminator(entityProperty.Entity))
            {
                yield return new SelectColumn
                {
                    ColumnName = $"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{entityProperty.BaseProperty.PropertyName}",
                    ColumnAlias = resourceProperty.JsonPropertyName,
                };
                
                yield break;
            }

            // Just return the column
            yield return new SelectColumn
            {
                ColumnName = $"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{resourceProperty.PropertyName}",
                ColumnAlias = resourceProperty.JsonPropertyName,
            };
        }
    }
}

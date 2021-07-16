// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Resources;
using NHibernate;
using NHibernate.Transform;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public interface IGetDeletedResourceItems
    {
        DeletedResourceItems Execute(string schema, string resource, IQueryParameters queryParameters);
    }
    
    public class DeletedResourceItems
    {
        public IReadOnlyList<DeletedResourceItem> DeletedResources { get; set; }
            
        public long? Count { get; set; }
    }
    
    public class GetDeletedResourceItems : NHibernateRepositoryOperationBase, IGetDeletedResourceItems
    {
        private const string TrackedChangesAlias = "c";
        private const string SourceTableAlias = "src";
        private const string SourceBaseTableAlias = "src_base";
        
        private readonly ISessionFactory _sessionFactory;
        private readonly IDomainModelProvider _domainModelProvider;
        
        private readonly ConcurrentDictionary<FullName, TrackedDeletesQueryMetadata> _deletesQueryMetadataByResourceName =
            new ConcurrentDictionary<FullName, TrackedDeletesQueryMetadata>();

        public GetDeletedResourceItems(ISessionFactory sessionFactory, IDomainModelProvider domainModelProvider)
            : base(sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _domainModelProvider = domainModelProvider;
        }

        public DeletedResourceItems Execute(string schemaUriSegment, string urlResourcePluralName, IQueryParameters queryParameters)
        {
            var resource = _domainModelProvider
                .GetDomainModel()
                .ResourceModel
                .GetResourceByApiCollectionName(schemaUriSegment, urlResourcePluralName);

            if (resource == null)
            {
                throw new Exception($"Unable to find resource for provided schema uri segment '{schemaUriSegment}' and url resource '{urlResourcePluralName}'.");
            }

            if ((queryParameters.MinChangeVersion ?? 0) > (queryParameters.MaxChangeVersion ?? long.MaxValue))
            {
                throw new ArgumentException("Minimum change version cannot be greater than maximum change version.");
            }

            var queryMetadata = _deletesQueryMetadataByResourceName.GetOrAdd(resource.FullName, 
                fn => CreateTrackedDeletesQueryMetadata(resource));

            return GetDeletedItemsResponse(queryMetadata, queryParameters);
        }

        private DeletedResourceItems GetDeletedItemsResponse(
            TrackedDeletesQueryMetadata queryMetadata,
            IQueryParameters queryParameters)
        {
            string deletesSql = GetDeletesSql(queryMetadata, queryParameters);

            var deletesResponse = new DeletedResourceItems();

            using (var sessionScope = new SessionScope(_sessionFactory))
            {
                var query = sessionScope.Session.CreateSQLQuery(deletesSql)
                    .SetFirstResult(queryParameters.Offset ?? 0)
                    .SetMaxResults(queryParameters.Limit ?? 25)
                    .SetResultTransformer(Transformers.AliasToEntityMap);

                var deletedItems = query.List();

                var deletedResources = deletedItems
                    .Cast<Hashtable>()
                    .Select(
                        deletedItem => new DeletedResourceItem
                        {
                            Id = (Guid) deletedItem["Id"],
                            ChangeVersion = (long) deletedItem[ChangeQueriesDatabaseConstants.ChangeVersionColumnName],
                            KeyValues = GetIdentifierKeyValues(queryMetadata.IdentifierProjections, deletedItem),
                        })
                    .ToList();

                deletesResponse.DeletedResources = deletedResources;

                if (queryParameters.TotalCount)
                {
                    string cmdCountSql = GetDeletesCountSql(queryMetadata, queryParameters);

                    var count = sessionScope.Session.CreateSQLQuery(cmdCountSql).UniqueResult();
                    deletesResponse.Count = Convert.ToInt64(count);
                }
            }

            return deletesResponse;
        }

        private TrackedDeletesQueryMetadata CreateTrackedDeletesQueryMetadata(Resource resource)
        {
            string discriminatorCriteria = null;
            string sourceBaseTableJoin = null;
            string sourceChangeVersionTableAlias = SourceTableAlias;
            
            if (resource.IsDerived)
            {
                sourceChangeVersionTableAlias = SourceBaseTableAlias;
                
                discriminatorCriteria = resource.IsDerived
                    ? $" AND {TrackedChangesAlias}.Discriminator = '{resource.Entity.FullName}'"
                    : null;

                var baseTableJoinSegments = resource.Entity.BaseAssociation.PropertyMappings.Select(pm => $"{SourceTableAlias}.{pm.ThisProperty.PropertyName} = {SourceBaseTableAlias}.{pm.OtherProperty.PropertyName}");

                string baseTableJoinSegmentsSql = string.Join(" AND ", baseTableJoinSegments);

                sourceBaseTableJoin = resource.IsDerived
                    ? $" LEFT JOIN {resource.Entity.BaseEntity.Schema}.{resource.Entity.BaseEntity.Name} {SourceBaseTableAlias} "
                    + $" ON {baseTableJoinSegmentsSql}"
                    : null;
            }
            
            var identifierProjections = resource
                .IdentifyingProperties
                .Select(
                    rp => new ProjectionMetadata
                    {
                        JsonPropertyName = rp.JsonPropertyName,
                        SelectColumns = GetSelectColumns(rp).ToArray(),
                        ChangeTableJoinColumnName = $"Old{(rp.EntityProperty.BaseProperty ?? rp.EntityProperty).PropertyName}",
                        SourceTableJoinColumnName = rp.EntityProperty.PropertyName,
                        IsDescriptorProperty = rp.IsLookup,
                    })
                .ToArray();

            string selectColumnsSql = string.Join(
                ", ",
                identifierProjections
                    .SelectMany(x => x.SelectColumns)
                    .Select(
                        x =>
                            x.ColumnAlias == null
                                ? $"{TrackedChangesAlias}.{x.ColumnName}"
                                : $"{TrackedChangesAlias}.{x.ColumnName} AS {x.ColumnAlias}"));

            string deletesOnlyCriteria = $" AND {TrackedChangesAlias}.New{(resource.Entity.BaseEntity ?? resource.Entity).Identifier.Properties.First().PropertyName} IS NULL";

            string sourceTableJoinCriteria = string.Join(
                " AND ",
                identifierProjections.Select(x => $"{TrackedChangesAlias}.{x.ChangeTableJoinColumnName} = {SourceTableAlias}.{x.SourceTableJoinColumnName}"));

            string sourceTableExclusionCriteria = $"{SourceTableAlias}.{identifierProjections.Select(x => x.SourceTableJoinColumnName).First()} IS NULL";

            var queryMetadata = new TrackedDeletesQueryMetadata(
                (resource.Entity.BaseEntity ?? resource.Entity).Schema,
                (resource.Entity.BaseEntity ?? resource.Entity).Name,
                resource.Entity.Schema,
                resource.Entity.Name,
                selectColumnsSql,
                deletesOnlyCriteria,
                discriminatorCriteria,
                sourceTableJoinCriteria,
                sourceBaseTableJoin,
                sourceChangeVersionTableAlias,
                sourceTableExclusionCriteria,
                identifierProjections);

            return queryMetadata;
        }

        private IEnumerable<SelectColumn> GetSelectColumns(ResourceProperty resourceProperty)
        {
            if (resourceProperty.IsLookup)
            {
                yield return new SelectColumn
                {
                    ColumnName = $"Old{resourceProperty.EntityProperty.PropertyName.ReplaceSuffix("Id", "Namespace")}",
                    ColumnAlias = null,
                };

                yield return new SelectColumn
                {
                    ColumnName = $"Old{resourceProperty.EntityProperty.PropertyName.ReplaceSuffix("Id", "CodeValue")}",
                    ColumnAlias = null,
                };
            }
            else
            {
                if (resourceProperty.EntityProperty.IsInheritedIdentifyingRenamed)
                {
                    yield return new SelectColumn
                    {
                        ColumnName = $"Old{resourceProperty.EntityProperty.BaseProperty.PropertyName}",
                        ColumnAlias = resourceProperty.JsonPropertyName
                    };
                }
                else
                {
                    yield return new SelectColumn
                    {
                        ColumnName = $"Old{resourceProperty.PropertyName}",
                        ColumnAlias = resourceProperty.JsonPropertyName
                    };
                }
            }
        }

        private string GetDeletesSql(TrackedDeletesQueryMetadata queryMetadata, IQueryParameters queryParameters)
        {
            string selectClauseFormat = $"SELECT {TrackedChangesAlias}.Id, {TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}, {{0}}";
            string orderByClause = $"ORDER BY {TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}";
            
            return BuildCompleteDeletesSql(queryMetadata, queryParameters, selectClauseFormat, orderByClause);
        }

        private string GetDeletesCountSql(TrackedDeletesQueryMetadata queryMetadata, IQueryParameters queryParameters)
        {
            string selectClauseFormat = $"SELECT Count(1)";

            return BuildCompleteDeletesSql(queryMetadata, queryParameters, selectClauseFormat);
        }

        private string BuildCompleteDeletesSql(
            TrackedDeletesQueryMetadata queryMetadata,
            IQueryParameters queryParameters,
            string selectClauseFormat,
            string orderByClause = null)
        {
            string sourceTableChangeVersionCriteria = null;
            string deletedChangeVersionCriteria = null;

            if (queryParameters.MinChangeVersion.HasValue)
            {
                deletedChangeVersionCriteria +=
                    $" {TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName} >= {queryParameters.MinChangeVersion.Value}";

                sourceTableChangeVersionCriteria +=
                    $" {queryMetadata.SourceChangeVersionTableAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName} >= {queryParameters.MinChangeVersion.Value}";
            }

            if (queryParameters.MaxChangeVersion.HasValue)
            {
                deletedChangeVersionCriteria +=
                    $" {AndIfNeeded(deletedChangeVersionCriteria)}{TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName} <= {queryParameters.MaxChangeVersion.Value}";

                sourceTableChangeVersionCriteria +=
                    $" {AndIfNeeded(sourceTableChangeVersionCriteria)}{queryMetadata.SourceChangeVersionTableAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName} <= {queryParameters.MaxChangeVersion.Value}";
            }

            if (!string.IsNullOrEmpty(deletedChangeVersionCriteria))
            {
                deletedChangeVersionCriteria = $" AND {deletedChangeVersionCriteria}";
            }

            if (!string.IsNullOrEmpty(sourceTableChangeVersionCriteria))
            {
                sourceTableChangeVersionCriteria =
                    $" AND (({sourceTableChangeVersionCriteria}) OR {queryMetadata.SourceChangeVersionTableAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName} IS NULL)";
            }

            string selectClause = string.Format(selectClauseFormat, queryMetadata.SelectColumnsListSql);

            var cmdSql = $@"
{selectClause}
FROM {ChangeQueriesDatabaseConstants.SchemaName}{ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix}.{queryMetadata.ChangeTableSchema}_{queryMetadata.ChangeTableName} AS {TrackedChangesAlias}
LEFT JOIN {queryMetadata.SourceTableSchema}.{queryMetadata.SourceTableName} src 
    ON {queryMetadata.SourceTableJoinCriteria}
{queryMetadata.SourceBaseTableJoin}
    {sourceTableChangeVersionCriteria}
WHERE {queryMetadata.SourceTableExclusionCriteria}
    {queryMetadata.DeletesOnlyWhereClause}
    {queryMetadata.DiscriminatorCriteria}
    {deletedChangeVersionCriteria}
{orderByClause}";

            return cmdSql;
        }

        private static Dictionary<string, object> GetIdentifierKeyValues(
            ProjectionMetadata[] identifierProjections, 
            Hashtable deletedItem)
        {
            var keyValues = new Dictionary<string, object>();

            foreach (var identifierMetadata in identifierProjections)
            {
                if (identifierMetadata.IsDescriptorProperty)
                {
                    string namespaceColumn = identifierMetadata.SelectColumns[0].ColumnName;
                    string codeValueColumn = identifierMetadata.SelectColumns[1].ColumnName;

                    keyValues[identifierMetadata.JsonPropertyName] =
                        $"{deletedItem[namespaceColumn]}#{deletedItem[codeValueColumn]}";
                }
                else
                {
                    // Copy the value without transformation
                    var selectColumn = identifierMetadata.SelectColumns.First();

                    keyValues[selectColumn.ColumnAlias] =
                        deletedItem[selectColumn.ColumnAlias ?? selectColumn.ColumnName];
                }
            }

            return keyValues;
        }

        private string AndIfNeeded(string criteria)
        {
            return string.IsNullOrEmpty(criteria) ? string.Empty : " AND ";
        }
    }
}

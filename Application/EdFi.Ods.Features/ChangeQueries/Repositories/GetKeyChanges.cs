// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
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
    public interface IGetKeyChanges
    {
        Task<KeyChangesResponse> ExecuteAsync(string schema, string resource, IQueryParameters queryParameters);
    }
    
    public class KeyChangesResponse
    {
        public IReadOnlyList<KeyChange> KeyChanges { get; set; }
            
        public long? Count { get; set; }
    }

    public class GetKeyChanges : NHibernateRepositoryOperationBase, IGetKeyChanges
    {
        private const string TrackedChangesAlias = "c";
        private const string SourceTableAlias = "src";
        private const string SourceBaseTableAlias = "src_base";
        
        private readonly ISessionFactory _sessionFactory;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly int _maxPageSize;

        private readonly ConcurrentDictionary<FullName, TrackedKeyChangesQueryMetadata> _keyChangesQueryMetadataByResourceName =
            new ConcurrentDictionary<FullName, TrackedKeyChangesQueryMetadata>();

        public GetKeyChanges(
            ISessionFactory sessionFactory, 
            IDomainModelProvider domainModelProvider, 
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _domainModelProvider = domainModelProvider;

            _maxPageSize = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
        }

        public async Task<KeyChangesResponse> ExecuteAsync(string schemaUriSegment, string urlResourcePluralName, IQueryParameters queryParameters)
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

            var queryMetadata = _keyChangesQueryMetadataByResourceName.GetOrAdd(resource.FullName, 
                fn => CreateTrackedKeyChangesQueryMetadata(resource));

            return await GetKeyChangesResponseAsync(queryMetadata, queryParameters);
        }

        private async Task<KeyChangesResponse> GetKeyChangesResponseAsync(
            TrackedKeyChangesQueryMetadata queryMetadata,
            IQueryParameters queryParameters)
        {
            string keyChangesSql = GetKeyChangesSql(queryMetadata, queryParameters);

            var keyChangesResponse = new KeyChangesResponse();

            using (var sessionScope = new SessionScope(_sessionFactory))
            {
                var query = sessionScope.Session.CreateSQLQuery(keyChangesSql)
                    .SetFirstResult(queryParameters.Offset ?? 0)
                    .SetMaxResults(queryParameters.Limit ?? _maxPageSize)
                    .SetResultTransformer(Transformers.AliasToEntityMap);

                var keyChangeItems = await query.ListAsync();

                IReadOnlyList<KeyChange> keyChanges = keyChangeItems
                    .Cast<Hashtable>()
                    .Select(
                        keyChangesItem => new KeyChange
                        {
                            Id = (Guid) keyChangesItem["Id"],
                            ChangeVersion = (long) keyChangesItem[ChangeQueriesDatabaseConstants.ChangeVersionColumnName],
                            OldKeyValues = GetIdentifierKeyValues(ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix, queryMetadata.IdentifierProjections, keyChangesItem),
                            NewKeyValues = GetIdentifierKeyValues(ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix, queryMetadata.IdentifierProjections, keyChangesItem),
                        })
                    .ToList();

                keyChangesResponse.KeyChanges = keyChanges;

                if (queryParameters.TotalCount)
                {
                    string cmdCountSql = GetKeyChangesCountSql(queryMetadata, queryParameters);

                    var count = await sessionScope.Session.CreateSQLQuery(cmdCountSql).UniqueResultAsync();
                    keyChangesResponse.Count = Convert.ToInt64(count);
                }
            }

            return keyChangesResponse;
        }

        private TrackedKeyChangesQueryMetadata CreateTrackedKeyChangesQueryMetadata(Resource resource)
        {
            string discriminatorCriteria = null;
            string sourceBaseTableJoin = null;
            
            if (resource.IsDerived)
            {
                discriminatorCriteria = resource.IsDerived
                    ? $" AND {TrackedChangesAlias}.Discriminator = '{resource.Entity.FullName}'"
                    : null;

                // TODO: GKM - Needs Column name translations 
                var baseTableJoinSegments = resource.Entity.BaseAssociation.PropertyMappings
                    .Select(pm => $"{SourceTableAlias}.{pm.ThisProperty.PropertyName} = {SourceBaseTableAlias}.{pm.OtherProperty.PropertyName}");

                string baseTableJoinSegmentsSql = string.Join(" AND ", baseTableJoinSegments);

                // TODO: GKM - Needs Table name translations 
                sourceBaseTableJoin = resource.IsDerived
                    ? $" LEFT JOIN {resource.Entity.BaseEntity.Schema}.{resource.Entity.BaseEntity.Name} {SourceBaseTableAlias} "
                    + $" ON {baseTableJoinSegmentsSql}"
                    : null;
            }
            
            // TODO: GKM - Needs Column name translations
            var identifierProjections = resource
                .IdentifyingProperties
                .Select(
                    rp => new ProjectionMetadata
                    {
                        JsonPropertyName = rp.JsonPropertyName,
                        SelectColumns = GetSelectColumns(rp, ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix).ToArray(),
                        ChangeTableJoinColumnName = $"{(rp.EntityProperty.BaseProperty ?? rp.EntityProperty).PropertyName}",
                        SourceTableJoinColumnName = rp.EntityProperty.PropertyName,
                        IsDescriptorUsage = rp.IsDescriptorUsage,
                    })
                .ToArray();

            string selectColumnsSql = string.Join(
                ", ",
                identifierProjections
                    .SelectMany(x => x.SelectColumns)
                    .SelectMany(
                        x => (new [] { ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix, ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix })
                            .Select(prefix =>
                                x.ColumnAlias == null
                                    ? $"{prefix}{TrackedChangesAlias}.{x.ColumnName}"
                                    : $"{prefix}{TrackedChangesAlias}.{x.ColumnName} AS {prefix}{x.ColumnAlias}")));
            
            // TODO: GKM - Needs Column name translations
            string keyChangesOnlyCriteria = $" AND {TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{(resource.Entity.BaseEntity ?? resource.Entity).Identifier.Properties.First().PropertyName} IS NOT NULL";

            // TODO: GKM - Needs Table name translations
            var queryMetadata = new TrackedKeyChangesQueryMetadata(
                ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix + (resource.Entity.BaseEntity ?? resource.Entity).Schema,
                (resource.Entity.BaseEntity ?? resource.Entity).Name,
                selectColumnsSql,
                keyChangesOnlyCriteria,
                discriminatorCriteria,
                sourceBaseTableJoin,
                identifierProjections);

            return queryMetadata;
        }

        private IEnumerable<SelectColumn> GetSelectColumns(ResourceProperty resourceProperty, string columnNamePrefix)
        {
            if (resourceProperty.IsDescriptorUsage)
            {
                yield return new SelectColumn
                {
                    ColumnName = $"{columnNamePrefix}{resourceProperty.EntityProperty.PropertyName.ReplaceSuffix("Id", "Namespace")}",
                    ColumnAlias = null,
                };

                yield return new SelectColumn
                {
                    ColumnName = $"{columnNamePrefix}{resourceProperty.EntityProperty.PropertyName.ReplaceSuffix("Id", "CodeValue")}",
                    ColumnAlias = null,
                };
            }
            else
            {
                if (resourceProperty.EntityProperty.IsInheritedIdentifyingRenamed)
                {
                    yield return new SelectColumn
                    {
                        ColumnName = $"{columnNamePrefix}{resourceProperty.EntityProperty.BaseProperty.PropertyName}",
                        ColumnAlias = $"{columnNamePrefix}{resourceProperty.JsonPropertyName}",
                    };
                }
                else
                {
                    yield return new SelectColumn
                    {
                        ColumnName = $"{columnNamePrefix}{resourceProperty.PropertyName}",
                        ColumnAlias = $"{columnNamePrefix}{resourceProperty.JsonPropertyName}",
                    };
                }
            }
        }

        private string GetKeyChangesSql(TrackedKeyChangesQueryMetadata queryMetadata, IQueryParameters queryParameters)
        {
            string selectClauseFormat = $"SELECT {TrackedChangesAlias}.Id, {TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}, {{0}}";
            string orderByClause = $"ORDER BY {TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName}";
            
            return BuildCompleteKeyChangesSql(queryMetadata, queryParameters, selectClauseFormat, orderByClause);
        }
        
        private string GetKeyChangesCountSql(TrackedKeyChangesQueryMetadata queryMetadata, IQueryParameters queryParameters)
        {
            string selectClauseFormat = $"SELECT Count(1)";

            return BuildCompleteKeyChangesSql(queryMetadata, queryParameters, selectClauseFormat);
        }

        private string BuildCompleteKeyChangesSql(
            TrackedKeyChangesQueryMetadata queryMetadata,
            IQueryParameters queryParameters,
            string selectClauseFormat,
            string orderByClause = null)
        {
            // string sourceTableChangeVersionCriteria = null;
            string keyChangeChangeVersionCriteria = null;

            if (queryParameters.MinChangeVersion.HasValue)
            {
                keyChangeChangeVersionCriteria +=
                    $" {TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName} >= {queryParameters.MinChangeVersion.Value}";
            }

            if (queryParameters.MaxChangeVersion.HasValue)
            {
                keyChangeChangeVersionCriteria +=
                    $" {AndIfNeeded(keyChangeChangeVersionCriteria)}{TrackedChangesAlias}.{ChangeQueriesDatabaseConstants.ChangeVersionColumnName} <= {queryParameters.MaxChangeVersion.Value}";
            }

            if (!string.IsNullOrEmpty(keyChangeChangeVersionCriteria))
            {
                keyChangeChangeVersionCriteria = $" AND {keyChangeChangeVersionCriteria}";
            }

            string selectClause = string.Format(selectClauseFormat, queryMetadata.SelectColumnsListSql);

            var cmdSql = $@"
{selectClause}
FROM {queryMetadata.ChangeTableSchema}.{queryMetadata.ChangeTableName} AS {TrackedChangesAlias}
{queryMetadata.SourceBaseTableJoin}
WHERE
    {queryMetadata.KeyChangesOnlyWhereClause}
    {queryMetadata.DiscriminatorCriteria}
    {keyChangeChangeVersionCriteria}
{orderByClause}";

            return cmdSql;
        }

        private static Dictionary<string, object> GetIdentifierKeyValues(
            string identifiersColumnPrefix,
            ProjectionMetadata[] identifierProjections,
            Hashtable keyChanges)
        {
            var keyValues = new Dictionary<string, object>();

            foreach (var identifierMetadata in identifierProjections)
            {
                if (identifierMetadata.IsDescriptorUsage)
                {
                    string namespaceColumn = identifiersColumnPrefix + identifierMetadata.SelectColumns[0].ColumnName;
                    string codeValueColumn = identifiersColumnPrefix + identifierMetadata.SelectColumns[1].ColumnName;

                    keyValues[identifierMetadata.JsonPropertyName] =
                        $"{keyChanges[namespaceColumn]}#{keyChanges[codeValueColumn]}";
                }
                else
                {
                    // Copy the value without transformation
                    var selectColumn = identifierMetadata.SelectColumns.First();

                    string trackedChangeColumnName = identifiersColumnPrefix 
                        + (selectColumn.ColumnAlias ?? selectColumn.ColumnName);
                        
                    keyValues[identifierMetadata.JsonPropertyName] = keyChanges[trackedChangeColumnName];
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

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
    public interface IGetKeyChanges
    {
        KeyChangesResponse Execute(string schema, string resource, IQueryParameters queryParameters);
    }
    
    public class KeyChangesResponse
    {
        public IReadOnlyList<KeyChange> KeyChanges { get; set; }
            
        public long? Count { get; set; }
    }

    public class GetKeyChanges : NHibernateRepositoryOperationBase, IGetKeyChanges
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IDomainModelProvider _domainModelProvider;

        private readonly ConcurrentDictionary<FullName, TrackedKeyChangesQueryMetadata> _deletesQueryMetadataByResourceName =
            new ConcurrentDictionary<FullName, TrackedKeyChangesQueryMetadata>();

        public GetKeyChanges(ISessionFactory sessionFactory, IDomainModelProvider domainModelProvider)
            : base(sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _domainModelProvider = domainModelProvider;
        }

        public KeyChangesResponse Execute(string schemaUriSegment, string urlResourcePluralName, IQueryParameters queryParameters)
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
                fn => CreateTrackedKeyChangesQueryMetadata(resource));

            return GetKeyChangesResponse(queryMetadata, queryParameters);
        }

        private KeyChangesResponse GetKeyChangesResponse(
            TrackedKeyChangesQueryMetadata queryMetadata,
            IQueryParameters queryParameters)
        {
            string keyChangesSql = GetKeyChangesSql(queryMetadata, queryParameters);

            var keyChangesResponse = new KeyChangesResponse();

            using (var sessionScope = new SessionScope(_sessionFactory))
            {
                var query = sessionScope.Session.CreateSQLQuery(keyChangesSql)
                    .SetFirstResult(queryParameters.Offset ?? 0)
                    .SetMaxResults(queryParameters.Limit ?? 25)
                    .SetResultTransformer(Transformers.AliasToEntityMap);

                var keyChangeItems = query.List();

                IReadOnlyList<KeyChange> keyChanges = keyChangeItems
                    .Cast<Hashtable>()
                    .Select(
                        deletedItem => new KeyChange
                        {
                            Id = (Guid) deletedItem["Id"],
                            ChangeVersion = (long) deletedItem[ChangeQueriesDatabaseConstants.ChangeVersionColumnName],
                            OldKeyValues = GetIdentifierKeyValues(queryMetadata.IdentifierProjections, deletedItem),
                            NewKeyValues = GetIdentifierKeyValues(queryMetadata.IdentifierProjections, deletedItem),
                        })
                    .ToList();

                keyChangesResponse.KeyChanges = keyChanges;

                if (queryParameters.TotalCount)
                {
                    string cmdCountSql = GetKeyChangesCountSql(queryMetadata, queryParameters);

                    var count = sessionScope.Session.CreateSQLQuery(cmdCountSql).UniqueResult();
                    keyChangesResponse.Count = Convert.ToInt64(count);
                }
            }

            return keyChangesResponse;
        }

        private TrackedKeyChangesQueryMetadata CreateTrackedKeyChangesQueryMetadata(Resource resource)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<SelectColumn> GetSelectColumns(ResourceProperty resourceProperty)
        {
            throw new NotImplementedException();
        }

        private string GetKeyChangesSql(TrackedKeyChangesQueryMetadata queryMetadata, IQueryParameters queryParameters)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        private static Dictionary<string, object> GetIdentifierKeyValues(
            ProjectionMetadata[] identifierProjections,
            Hashtable deletedItem)
        {
            throw new NotImplementedException();
        }
        
        private string AndIfNeeded(string criteria)
        {
            return string.IsNullOrEmpty(criteria) ? string.Empty : " AND ";
        }
    }
}

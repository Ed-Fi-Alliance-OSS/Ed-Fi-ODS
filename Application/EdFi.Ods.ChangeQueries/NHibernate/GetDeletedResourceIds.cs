// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Infrastructure.Architecture;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Api.Common.Infrastructure.Repositories;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.ChangeQueries.SqlServer;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using NHibernate;
using NHibernate.Transform;

namespace EdFi.Ods.ChangeQueries.NHibernate
{
    public class GetDeletedResourceIds : NHibernateRepositoryOperationBase, IGetDeletedResourceIds
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly DatabaseEngine _databaseEngine;

        public GetDeletedResourceIds(
            ISessionFactory sessionFactory,
            IDomainModelProvider domainModelProvider,
            DatabaseEngine databaseEngine)
            : base(sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _domainModelProvider = domainModelProvider;
            _databaseEngine = databaseEngine;
        }

        public IReadOnlyList<DeletedResource> Execute(string schemaUriSegment, string urlResourcePluralName, IQueryParameters queryParameters)
        {
            var entity = _domainModelProvider.GetDomainModel().ResourceModel.GetAllResources().SingleOrDefault(
                r => r.SchemaUriSegment() == schemaUriSegment &&
                     r.PluralName.EqualsIgnoreCase(urlResourcePluralName))?.Entity;

            if (entity == null)
            {
                throw new ArgumentException(
                    $"Unable to find entity for provided schema uri segment {schemaUriSegment} and url resource {urlResourcePluralName}.");
            }

            var cmdSql = $"SELECT Id, {ChangeQueriesDatabaseConstants.ChangeVersionColumnName}" +
                         $" FROM {ChangeQueriesDatabaseConstants.TrackedDeletesSchemaPrefix}{entity.Schema}.{entity.TableName(_databaseEngine)}";

            if (queryParameters.MinChangeVersion.HasValue)
            {
                cmdSql += $" WHERE {ChangeQueriesDatabaseConstants.ChangeVersionColumnName} >= {queryParameters.MinChangeVersion.Value}";
            }

            if (queryParameters.MaxChangeVersion.HasValue)
            {
                cmdSql += queryParameters.MinChangeVersion.HasValue
                    ? " AND "
                    : " WHERE ";

                cmdSql += $"{ChangeQueriesDatabaseConstants.ChangeVersionColumnName} <= {queryParameters.MaxChangeVersion.Value}";
            }

            cmdSql += $" ORDER BY {ChangeQueriesDatabaseConstants.ChangeVersionColumnName}";

            using (var sessionScope = new SessionScope(_sessionFactory))
            {
                var query = sessionScope.Session.CreateSQLQuery(cmdSql)
                                        .SetFirstResult(queryParameters.Offset ?? 0)
                                        .SetMaxResults(queryParameters.Limit ?? 25)
                                        .SetResultTransformer(Transformers.AliasToBean<DeletedResource>());

                return query.List<DeletedResource>().ToReadOnlyList();
            }
        }
    }
}

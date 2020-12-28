// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Features.ChangeQueries
{
    public interface IGetDeletedResourceIds
    {
        IReadOnlyList<DeletedResource> Execute(string schema, string resource, IQueryParameters queryParameters);
    }
    
    public class GetDeletedResourceIds : IGetDeletedResourceIds
    {
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly DatabaseEngine _databaseEngine;

        public GetDeletedResourceIds(
            IDomainModelProvider domainModelProvider,
            DatabaseEngine databaseEngine)
        {
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

            // TODO: API Simplification - Needs to be converted to use Dapper
            throw new NotImplementedException("Needs conversion from NHibernate to Dapper.");
            // using (var sessionScope = new SessionScope(_sessionFactory))
            // {
            //     var query = sessionScope.Session.CreateSQLQuery(cmdSql)
            //                             .SetFirstResult(queryParameters.Offset ?? 0)
            //                             .SetMaxResults(queryParameters.Limit ?? 25)
            //                             .SetResultTransformer(Transformers.AliasToBean<DeletedResource>());
            //
            //     return query.List<DeletedResource>().ToReadOnlyList();
            // }
        }
    }
}

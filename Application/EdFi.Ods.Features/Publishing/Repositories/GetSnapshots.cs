// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Common.Configuration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Features.Publishing.Resources;

namespace EdFi.Ods.Features.Publishing.Repositories
{
    public class GetSnapshots : IGetSnapshots
    {
        private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;

        public GetSnapshots(DatabaseEngine databaseEngine, IOdsDatabaseConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public Task<IList<Snapshot>> GetAllAsync(IQueryParameters queryParameters)
        {
            var cmdSql = $@"
SELECT   Id, SnapshotIdentifier, SnapshotDateTime
FROM     publishing.Snapshot
ORDER BY SnapshotDateTime DESC";

            // TODO: API Simplification - Needs to be converted to use Dapper
            throw new NotImplementedException("Needs conversion from NHibernate to Dapper.");
            // using (var sessionScope = new SessionScope(_sessionFactory))
            // {
            //     var query = sessionScope.Session.CreateSQLQuery(cmdSql)
            //         .SetFirstResult(queryParameters.Offset ?? 0)
            //         .SetMaxResults(queryParameters.Limit ?? 25)
            //         .SetResultTransformer(Transformers.AliasToBean<Snapshot>());
            //
            //     return await query.ListAsync<Snapshot>().ConfigureAwait(false);
            // }
        }

        public Task<Snapshot> GetByIdAsync(Guid id)
        {
            var cmdSql = $@"
SELECT   Id, SnapshotIdentifier, SnapshotDateTime
FROM     publishing.Snapshot
WHERE    Id = :id";
            
            // TODO: API Simplification - Needs to be converted to use Dapper
            throw new NotImplementedException("Needs conversion from NHibernate to Dapper.");
            //
            // using (var sessionScope = new SessionScope(_sessionFactory))
            // {
            //     var query = sessionScope.Session.CreateSQLQuery(cmdSql)
            //         .SetGuid("id", id)
            //         .SetResultTransformer(Transformers.AliasToBean<Snapshot>());
            //
            //     return await query.UniqueResultAsync<Snapshot>().ConfigureAwait(false);
            // }
        }
    }
}

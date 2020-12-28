// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Features.TokenInfo
{
    public class TokenInfoProvider : ITokenInfoProvider
    {
        private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;
        
        private const string ColumnsSql =
            @"select distinct column_name from information_schema.columns where table_name = 'educationorganizationidentifiers' and table_schema = 'auth'and column_name like '%id';";

        private const string EdOrgIdentifiersSql = @"select distinct * from auth.educationorganizationidentifiers where {0};";

        public TokenInfoProvider(IOdsDatabaseConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public Task<TokenInfo> GetTokenInfoAsync(ApiKeyContext apiContext)
        {
            // TODO: API Simplification - Needs to be converted to use Dapper
            throw new NotImplementedException("Needs conversion from NHibernate to Dapper.");

            // using (var session = _sessionFactory.OpenStatelessSession())
            // {
            //     var columns = await session.CreateSQLQuery(ColumnsSql)
            //         .ListAsync<string>(CancellationToken.None);
            //
            //     string edOrgIds = string.Join(",", apiContext.EducationOrganizationIds);
            //
            //     string whereClause = string.Join(" or ", columns.Select(x => $"{x} in ({edOrgIds})"));
            //
            //     var educationOrganizationIdentifiers =
            //         await session.CreateSQLQuery(string.Format(EdOrgIdentifiersSql, whereClause))
            //             .SetResultTransformer(Transformers.AliasToBean<EducationOrganizationIdentifiers>())
            //             .ListAsync<EducationOrganizationIdentifiers>(CancellationToken.None);
            //
            //     return TokenInfo.Create(apiContext, educationOrganizationIdentifiers);
            // }
        }
    }
}

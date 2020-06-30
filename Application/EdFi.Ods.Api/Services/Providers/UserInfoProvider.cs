// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security;
using NHibernate;
using NHibernate.Transform;

namespace EdFi.Ods.Api.Services.Providers
{
    public class UserInfoProvider : IUserInfoProvider
    {
        private const string ColumnsSql =
            "select distinct column_name from information_schema.columns where table_name = 'educationorganizationidentifiers' and table_schema = 'auth'and column_name like '%id';";

        private const string EdOrgIdentifiersSql = "select distinct * from auth.educationorganizationidentifiers where {0};";

        private const string EdOrIdsParameterName = "edorgs";
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly ISessionFactory _sessionFactory;

        public UserInfoProvider(IApiKeyContextProvider apiKeyContextProvider, ISessionFactory sessionFactory)
        {
            _apiKeyContextProvider = apiKeyContextProvider;
            _sessionFactory = sessionFactory;
        }

        public async Task<UserInfo> GetUserInfoAsync()
        {
            ApiKeyContext apiContext = _apiKeyContextProvider.GetApiKeyContext();

            using (var session = _sessionFactory.OpenStatelessSession())
            {
                var columns = await session.CreateSQLQuery(ColumnsSql)
                    .ListAsync<string>(CancellationToken.None);

                string edOrgIds = string.Join(",", apiContext.EducationOrganizationIds);

                var whereClause = string.Join(" or ", columns.Select(x => $"{x} in (:{EdOrIdsParameterName})"));

                var educationOrganizationIdentifiers =
                    await session.CreateSQLQuery(string.Format(EdOrgIdentifiersSql, whereClause))
                        .SetParameter($"{EdOrIdsParameterName}", edOrgIds)
                        .SetResultTransformer(Transformers.AliasToBean<EducationOrganizationIdentifiers>())
                        .ListAsync<EducationOrganizationIdentifiers>(CancellationToken.None);

                return UserInfo.Create(apiContext, educationOrganizationIdentifiers);
            }
        }
    }
}

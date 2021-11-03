// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security;
using NHibernate;
using NHibernate.Transform;

namespace EdFi.Ods.Features.TokenInfo
{
    public class TokenInfoProvider : ITokenInfoProvider
    {
        private const string EdOrgIdentifiersSql = @"SELECT	targetEdOrg.EducationOrganizationId AS ClaimEducationOrganizationId, 
		targetEdOrg.NameOfInstitution AS ClaimNameOfInstitution,
		targetEdOrg.Discriminator AS ClaimDiscriminator,
		sourceEdOrg.Discriminator, sourceEdOrg.EducationOrganizationId
        FROM	auth.EducationOrganizationIdToEducationOrganizationId e2e
		INNER JOIN edfi.EducationOrganization sourceEdOrg
		ON e2e.SourceEducationOrganizationId = sourceEdOrg.EducationOrganizationId
		INNER JOIN edfi.EducationOrganization targetEdOrg
		ON e2e.TargetEducationOrganizationId = targetEdOrg.EducationOrganizationId
        WHERE e2e.SourceEducationOrganizationId IN {0};";

        private readonly ISessionFactory _sessionFactory;

        public TokenInfoProvider(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public async Task<TokenInfo> GetTokenInfoAsync(ApiKeyContext apiContext)
        {
            using (var session = _sessionFactory.OpenStatelessSession())
            {
                string edOrgIds = string.Join(",", apiContext.EducationOrganizationIds);

                var tokenInfoData =
                    await session.CreateSQLQuery(string.Format(EdOrgIdentifiersSql, $"({edOrgIds})"))
                        .SetResultTransformer(Transformers.AliasToBean<TokenInfoData>())
                        .ListAsync<TokenInfoData>(CancellationToken.None);

                return TokenInfo.Create(apiContext, tokenInfoData);
            }
        }
    }
}

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
        private const string EdOrgIdentifiersSql = @"
SELECT  accessibleEdOrg.EducationOrganizationId,
        accessibleEdOrg.NameOfInstitution,
        accessibleEdOrg.Discriminator,
        ancestorTuples.SourceEducationOrganizationId AS AncestorEducationOrganizationId,
        ancestorEdOrg.Discriminator AS AncestorDiscriminator
FROM    auth.EducationOrganizationIdToEducationOrganizationId accessibleTuples
        INNER JOIN edfi.EducationOrganization accessibleEdOrg
            ON accessibleTuples.TargetEducationOrganizationId = accessibleEdOrg.EducationOrganizationId
        INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId ancestorTuples
            ON accessibleTuples.TargetEducationOrganizationId = ancestorTuples.TargetEducationOrganizationId
        INNER JOIN edfi.EducationOrganization ancestorEdOrg
            ON ancestorTuples.SourceEducationOrganizationId = ancestorEdOrg.EducationOrganizationId
WHERE	accessibleTuples.SourceEducationOrganizationId IN ({0});";

        private readonly ISessionFactory _sessionFactory;

        public TokenInfoProvider(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public async Task<TokenInfo> GetTokenInfoAsync(ApiClientContext apiContext)
        {
            using (var session = _sessionFactory.OpenStatelessSession())
            {
                string edOrgIds = string.Join(",", apiContext.EducationOrganizationIds);

                var tokenInfoEducationOrganizationData =
                    await session.CreateSQLQuery(string.Format(EdOrgIdentifiersSql, edOrgIds))
                        .SetResultTransformer(Transformers.AliasToBean<TokenInfoEducationOrganizationData>())
                        .ListAsync<TokenInfoEducationOrganizationData>(CancellationToken.None);

                return TokenInfo.Create(apiContext, tokenInfoEducationOrganizationData);
            }
        }
    }
}

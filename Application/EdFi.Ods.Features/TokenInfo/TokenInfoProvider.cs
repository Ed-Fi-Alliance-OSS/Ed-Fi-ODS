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
        private const string EdOrgIdentifiersSql = @"SELECT tuple.TargetEducationOrganizationId AS educationOrganizationId, 
                             REPLACE(edorg.Discriminator, 'edfi.', '') AS educationOrganizationType, 
                            edorg.Discriminator AS fullEducationOrganizationType,  edorg.NameOfInstitution AS nameOfInstitution,
                            tuple.sourceEducationOrganizationId  AS localEducationAgencyId  FROM auth.EducationOrganizationIdToEducationOrganizationId tuple
                            INNER JOIN edfi.EducationOrganization edorg 
                            ON  tuple.TargetEducationOrganizationId = edorg.EducationOrganizationId WHERE SourceEducationOrganizationId in {0};";

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

                var educationOrganizationIdentifiers =
                    await session.CreateSQLQuery(string.Format(EdOrgIdentifiersSql, $"({edOrgIds})"))
                        .SetResultTransformer(Transformers.AliasToBean<EducationOrganizationIdentifiers>())
                        .ListAsync<EducationOrganizationIdentifiers>(CancellationToken.None);

                return TokenInfo.Create(apiContext, educationOrganizationIdentifiers);
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;
using NHibernate;
using NHibernate.Transform;

namespace EdFi.Ods.Features.TokenInfo
{
    public class TokenInfoProvider(
        ISessionFactory sessionFactory,
        IResourceModelProvider resourceModelProvider,
        IClaimSetClaimsProvider claimSetClaimsProvider,
        IResourceClaimUriProvider resourceClaimUriProvider,
        ISecurityRepository securityRepository,
        IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector)
        : ITokenInfoProvider
    {
        public async Task<TokenInfo> GetTokenInfoAsync(ApiClientContext apiContext)
        {
            return TokenInfo.Create(
                apiContext,
                await GetAuthorizedEducationOrganizations(apiContext),
                GetAuthorizedResources(apiContext),
                GetAuthorizedServices(apiContext));
        }

        private async Task<IList<TokenInfoEducationOrganizationData>> GetAuthorizedEducationOrganizations(ApiClientContext apiContext)
        {
            const string EdOrgIdentifiersSql = """
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
                                               WHERE	accessibleTuples.SourceEducationOrganizationId IN ({0});
                                               """;

            string edOrgIds = string.Join(",", apiContext.EducationOrganizationIds);

            using var session = sessionFactory.OpenStatelessSession();

            return await session.CreateSQLQuery(string.Format(EdOrgIdentifiersSql, edOrgIds))
                .SetResultTransformer(Transformers.AliasToBean<TokenInfoEducationOrganizationData>())
                .ListAsync<TokenInfoEducationOrganizationData>(CancellationToken.None);
        }

        private IReadOnlyList<TokenInfoResource> GetAuthorizedResources(ApiClientContext apiContext)
        {
            return resourceModelProvider.GetResourceModel()
                .GetAllResources()
                .Where(r => !r.IsAbstract())
                .Select(r =>
                {
                    var claimUris = resourceClaimUriProvider.GetResourceClaimUris(r);

                    var authorizedActions = securityRepository.GetActions()
                        .Where(action =>
                        {
                            try
                            {
                                return authorizationBasisMetadataSelector.PerformClaimCheck(
                                    apiContext.ClaimSetName, claimUris, action.ActionUri).Success;
                            }
                            catch (AuthorizationContextException)
                            {
                                return false;
                            }
                        })
                        .Select(action => action.ActionName)
                        .ToList();

                    return new TokenInfoResource
                    {
                        Resource = $"/{r.SchemaUriSegment()}/{r.PluralName.ToCamelCase()}",
                        Operations = authorizedActions
                    };
                })
                .Where(tir => tir.Operations.Any())
                .ToList();
        }

        private IReadOnlyList<TokenInfoService> GetAuthorizedServices(ApiClientContext apiContext)
        {
            return claimSetClaimsProvider.GetClaims(apiContext.ClaimSetName)
                .Where(c => c.ClaimName.StartsWith(EdFiOdsApiClaimTypes.ServicesPrefix, StringComparison.OrdinalIgnoreCase))
                .Select(c => new TokenInfoService
                {
                    Service = c.ClaimName[EdFiOdsApiClaimTypes.ServicesPrefix.Length..],
                    Operations = c.ClaimValue.Actions
                        .Select(a => securityRepository.GetActionByUri(a.Name).ActionName)
                        .ToList()
                })
                .Where(tis => tis.Operations.Any())
                .ToList();
        }
    }
}

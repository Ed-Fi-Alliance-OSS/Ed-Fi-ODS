// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.Controllers;
using EdFi.Security.DataAccess.Repositories;
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
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly IClaimSetClaimsProvider _claimSetClaimsProvider;
        private readonly IResourceClaimUriProvider _resourceClaimUriProvider;
        private readonly ISecurityTableGateway _securityTableGateway;
        private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;

        public TokenInfoProvider(
            ISessionFactory sessionFactory,
            IResourceModelProvider resourceModelProvider,
            IClaimSetClaimsProvider claimSetClaimsProvider,
            IResourceClaimUriProvider resourceClaimUriProvider,
            ISecurityTableGateway securityTableGateway,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector)
        {
            _sessionFactory = sessionFactory;
            _resourceModelProvider = resourceModelProvider;
            _claimSetClaimsProvider = claimSetClaimsProvider;
            _resourceClaimUriProvider = resourceClaimUriProvider;
            _securityTableGateway = securityTableGateway;
            _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
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

                return TokenInfo.Create(
                    apiContext,
                    tokenInfoEducationOrganizationData,
                    GetAuthorizedResources(apiContext),
                    GetAuthorizedServices(apiContext));
            }
        }

        private IReadOnlyList<TokenInfoResource> GetAuthorizedResources(ApiClientContext apiContext)
        {
            var actions = _securityTableGateway.GetActions();

            return _resourceModelProvider.GetResourceModel().GetAllResources()
                .Where(r => !r.IsAbstract() && !r.FullName.IsEdFiSchoolYearType())
                .Select(
                    r =>
                    {
                        var claimUris = _resourceClaimUriProvider.GetResourceClaimUris(r);

                        var authorizedActions = actions
                            .Where(
                                a => _authorizationBasisMetadataSelector.PerformClaimCheck(
                                    apiContext.ClaimSetName, claimUris, a.ActionUri).Success);

                        return new TokenInfoResource
                        {
                            Resource = AggregateDependencyController.GetNodeId(r),
                            Operations = authorizedActions.Select(a => a.ActionName).ToList()
                        };
                    })
                .Where(r => r.Operations.Any())
                .ToList();
        }

        private IReadOnlyList<TokenInfoService> GetAuthorizedServices(ApiClientContext apiContext)
        {
            var actionsByUri = _securityTableGateway.GetActions().ToDictionary(a => a.ActionUri);

            return _claimSetClaimsProvider.GetClaims(apiContext.ClaimSetName)
                .Where(r => r.ClaimName.StartsWith(EdFiOdsApiClaimTypes.ServicesPrefix))
                .Select(r => new TokenInfoService
                {
                    Service = r.ClaimName.Replace(EdFiOdsApiClaimTypes.ServicesPrefix, string.Empty),
                    Operations = r.ClaimValue.Actions.Select(a => actionsByUri[a.Name].ActionName).ToList()
                })
                .Where(r => r.Operations.Any())
                .ToList();
        }
    }
}

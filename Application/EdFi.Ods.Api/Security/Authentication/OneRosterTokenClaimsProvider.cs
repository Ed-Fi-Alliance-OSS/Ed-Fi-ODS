// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Common.Security;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using static EdFi.Ods.Common.Constants.RequestActions;

namespace EdFi.Ods.Api.Security.Authentication;

public interface IOneRosterTokenClaimsProvider
{
    OneRosterTokenClaimsResult CreateClaims(ApiClientDetails apiClientDetails, AccessToken token, string scope);
}

public class OneRosterTokenClaimsResult(IReadOnlyCollection<Claim> claims, IReadOnlyCollection<string> oneRosterScopes)
{
    public IReadOnlyCollection<Claim> Claims { get; } = claims;

    public IReadOnlyCollection<string> OneRosterScopes { get; } = oneRosterScopes;
}

public class OneRosterTokenClaimsProvider(
    IClaimSetClaimsProvider _claimSetClaimsProvider,
    IOptions<SecuritySettings> _securitySettings,
    IFeatureManager _featureManager,
    IUsersContextFactory _usersContextFactory,
    IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider) : IOneRosterTokenClaimsProvider
{
    public OneRosterTokenClaimsResult CreateClaims(ApiClientDetails apiClientDetails, AccessToken token, string scope)
    {
        List<Claim> claims = [new(JwtRegisteredClaimNames.Jti, token.Id)];

        claims.AddRange(_securitySettings.Value.Jwt.Audiences.Select(a => new Claim(JwtRegisteredClaimNames.Aud, a)));

        claims.AddRange(
            apiClientDetails.EducationOrganizationIds.Select(id => new Claim("educationOrganizationId", id.ToString())));

        if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
        {
            var tenantConfig = _tenantConfigurationContextProvider.Get();

            if (tenantConfig != null)
            {
                claims.Add(new Claim("tenantId", tenantConfig.TenantIdentifier));
            }
        }

        using var usersContext = _usersContextFactory.CreateContext();

        var apiClientOdsInstanceIds = usersContext.ApiClientOdsInstances
            .AsQueryable()
            .Where(x => x.ApiClient != null && x.ApiClient.ApiClientId == apiClientDetails.ApiClientId)
            .Select(x => x.OdsInstance)
            .Where(o => o != null)
            .Select(o => o.OdsInstanceId)
            .Distinct()
            .ToArray();

        var odsInstanceContextsList = usersContext.OdsInstanceContexts
            .AsQueryable()
            .Where(context => context.OdsInstance != null && apiClientOdsInstanceIds.Contains(context.OdsInstance.OdsInstanceId))
            .Select(context => new
            {
                context.OdsInstance.OdsInstanceId,
                context.ContextKey,
                context.ContextValue
            })
            .ToList();

        var odsInstancesJson = new
        {
            OdsInstances = apiClientOdsInstanceIds.Select(id => new
            {
                OdsInstanceId = id,
                OdsInstanceContext = odsInstanceContextsList
                    .Where(context => context.OdsInstanceId == id)
                    .Select(context => new
                    {
                        context.ContextKey,
                        context.ContextValue
                    })
                    .FirstOrDefault()
            }).ToArray()
        };

        claims.Add(new Claim("odsInstances", JsonSerializer.Serialize(odsInstancesJson)));

        var oneRosterScopes = GetOneRosterScopes(apiClientDetails.ClaimSetName, scope);

        if (oneRosterScopes.Length != 0)
        {
            claims.AddRange(oneRosterScopes.Select(s => new Claim("scope", s)));
        }

        return new OneRosterTokenClaimsResult(claims, oneRosterScopes);
    }

    private string[] GetOneRosterScopes(string claimSetName, string scope)
    {
        if (scope == null)
        {
            return [];
        }

        var claimsMetadata = _claimSetClaimsProvider.GetClaims(claimSetName)
            .Where(c => c.ClaimName.StartsWith(SecuritySettings.OneRosterScopePrefix))
            .Select(c => new
            {
                c.ClaimName,
                Actions = c.Actions
                    .Select(a => a.Name switch
                    {
                        CreateActionUri => 1,
                        ReadActionUri => 2,
                        UpdateActionUri => 4,
                        DeleteActionUri => 8,
                        _ => 0
                    })
                    .Aggregate((a, b) => a | b)
            })
            .ToList();

        const int readOnly = 2;
        const int createPut = 5;
        const int delete = 8;

        var scopeList =
            claimsMetadata.Where(c => (c.Actions & readOnly) != 0).Select(s => $"{s.ClaimName}.readonly")
                .Concat(claimsMetadata.Where(c => (c.Actions & createPut) != 0).Select(s => $"{s.ClaimName}.createput"))
                .Concat(claimsMetadata.Where(c => (c.Actions & delete) != 0).Select(s => $"{s.ClaimName}.delete"))
                .Intersect(scope.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

        return scopeList;
    }
}

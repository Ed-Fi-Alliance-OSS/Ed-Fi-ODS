// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
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
using EdFi.Ods.Common.Security;
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
            GetEducationOrganizationIdsInScope(apiClientDetails.EducationOrganizationIds, scope)
                .Select(id => new Claim("educationOrganizationId", id.ToString(CultureInfo.InvariantCulture))));

        if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
        {
            var tenantConfig = _tenantConfigurationContextProvider.Get();

            if (tenantConfig != null)
            {
                claims.Add(new Claim(EdFiOdsApiClaimTypes.TenantId, tenantConfig.TenantIdentifier));
            }
        }

        using var usersContext = _usersContextFactory.CreateContext();

        var apiClientOdsInstanceIds = usersContext.ApiClientOdsInstances
            .Where(x => x.ApiClient != null && x.ApiClient.ApiClientId == apiClientDetails.ApiClientId)
            .Select(x => x.OdsInstance)
            .Where(o => o != null)
            .Select(o => o.OdsInstanceId)
            .Distinct()
            .ToArray();

        var odsInstanceContextsList = usersContext.OdsInstanceContexts
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

        // The OneRoster scope claims describe the token for external OneRoster services. The ODS/API does not read them:
        // it authorizes each request from the client's claim set and education organizations stored in the Admin database.
        var oneRosterScopes = GetOneRosterScopes(apiClientDetails.ClaimSetName, scope);

        if (oneRosterScopes.Length != 0)
        {
            claims.AddRange(oneRosterScopes.Select(s => new Claim("scope", s)));
        }

        return new OneRosterTokenClaimsResult(claims, oneRosterScopes);
    }

    private static IEnumerable<long> GetEducationOrganizationIdsInScope(IEnumerable<long> educationOrganizationIds, string scope)
    {
        // A numeric scope narrows the token to a single education organization. The parsing rule matches the scope
        // validation in ClientCredentialsTokenRequestProvider, so the narrowed id is the one that was validated.
        if (int.TryParse(scope?.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out int educationOrganizationScope))
        {
            return educationOrganizationIds.Where(id => id == educationOrganizationScope);
        }

        return educationOrganizationIds;
    }

    private string[] GetOneRosterScopes(string claimSetName, string scope)
    {
        if (scope == null)
        {
            return [];
        }

        const int create = 1;
        const int read = 2;
        const int update = 4;
        const int delete = 8;
        const int createPut = create | update;

        var claimsMetadata = _claimSetClaimsProvider.GetClaims(claimSetName)
            .Where(c => c.ClaimName.StartsWith(SecuritySettings.OneRosterScopePrefix))
            .Select(c => new
            {
                c.ClaimName,
                Actions = c.Actions
                    .Select(a => a.Name switch
                    {
                        CreateActionUri => create,
                        ReadActionUri => read,
                        UpdateActionUri => update,
                        DeleteActionUri => delete,
                        _ => 0
                    })
                    .Aggregate((a, b) => a | b)
            })
            .ToList();

        var scopeList =
            claimsMetadata.Where(c => (c.Actions & read) != 0).Select(s => $"{s.ClaimName}.readonly")
                .Concat(claimsMetadata.Where(c => (c.Actions & createPut) == createPut).Select(s => $"{s.ClaimName}.createput"))
                .Concat(claimsMetadata.Where(c => (c.Actions & delete) != 0).Select(s => $"{s.ClaimName}.delete"))
                .Intersect(scope.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

        return scopeList;
    }
}

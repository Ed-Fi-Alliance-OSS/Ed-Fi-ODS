// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;

public class PostgresViewBasedSingleItemAuthorizationQuerySupport : IViewBasedSingleItemAuthorizationQuerySupport
{
    public string GetItemExistenceCheckSql(ViewBasedAuthorizationFilterDefinition filterDefinition, AuthorizationFilterContext filterContext)
    {
        // Use literal IN clause approach
        var edOrgIdsList = string.Join(',', filterContext.ClaimEndpointValues);
            
        return
            $"SELECT 1 FROM auth.{filterDefinition.ViewName} AS authvw WHERE authvw.{filterDefinition.ViewTargetEndpointName} = @{filterContext.SubjectEndpointName} AND authvw.{RelationshipAuthorizationConventions.ViewSourceColumnName} IN ({edOrgIdsList})";  
    }

    public void ApplyClaimsParametersToCommand(DbCommand cmd, EdFiAuthorizationContext authorizationContext)
    {
        // Nothing to do -- using inline IN clause
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;

public class SqlServerViewBasedSingleItemAuthorizationQuerySupport : IViewBasedSingleItemAuthorizationQuerySupport
{
    private const int SqlServerParameterCountThreshold = 2000;

    public string GetItemExistenceCheckSql(ViewBasedAuthorizationFilterDefinition filterDefinition, AuthorizationFilterContext filterContext)
    {
        if (filterContext.ClaimEndpointValues.Length < SqlServerParameterCountThreshold)
        {
            // Use literal IN clause approach
            var edOrgIdsList = string.Join(',', filterContext.ClaimEndpointValues);
            
            return
                $"SELECT 1 FROM auth.{filterDefinition.ViewName} AS authvw WHERE authvw.{filterDefinition.ViewTargetEndpointName} = @{filterDefinition.SubjectEndpointName} AND authvw.{RelationshipAuthorizationConventions.ViewSourceColumnName} IN ({edOrgIdsList})";  
        }

        // Use TVP approach
        return $"SELECT 1 FROM auth.{filterDefinition.ViewName} AS authvw INNER JOIN @{RelationshipAuthorizationConventions.ClaimsParameterName} c ON authvw.{RelationshipAuthorizationConventions.ViewSourceColumnName} = c.Id AND authvw.{filterDefinition.ViewTargetEndpointName} = @{filterDefinition.SubjectEndpointName}";
    }

    public void ApplyClaimsParametersToCommand(DbCommand cmd, EdFiAuthorizationContext authorizationContext)
    {
        // No parameters needed if less than 2,000 EdOrgIds present
        if (authorizationContext.ApiKeyContext.EducationOrganizationIds.Length < SqlServerParameterCountThreshold)
        {
            return;
        }
        
        // Assign EdOrgId claims
        var claimEdOrgIds = authorizationContext.ApiKeyContext.EducationOrganizationIds;

        var sqlParameter = cmd.CreateParameter() as SqlParameter;

        DataTable dt = new();
        dt.Columns.Add("Id", typeof(int));

        foreach (int claimEdOrgId in claimEdOrgIds)
        {
            dt.Rows.Add(claimEdOrgId);
        }

        sqlParameter!.ParameterName = "ClaimEducationOrganizationIds";
        sqlParameter.SqlDbType = SqlDbType.Structured;
        sqlParameter.TypeName = "dbo.IntTable";
        sqlParameter.Value = dt;

        cmd.Parameters.Add(sqlParameter);
    }
}

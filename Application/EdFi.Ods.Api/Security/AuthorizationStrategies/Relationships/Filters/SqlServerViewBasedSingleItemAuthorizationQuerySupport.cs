// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.SqlClient;
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
            var edOrgIdsList = filterContext.ClaimEndpointValues.Any()
                ? string.Join(',', filterContext.ClaimEndpointValues)
                : "NULL";
            
            return
                $"SELECT 1 FROM auth.{filterDefinition.ViewName} AS authvw WHERE authvw.{filterDefinition.ViewTargetEndpointName} = @{filterContext.SubjectEndpointName} AND authvw.{filterDefinition.ViewSourceEndpointName} IN ({edOrgIdsList})";  
        }

        // Use TVP approach
        return $"SELECT 1 FROM auth.{filterDefinition.ViewName} AS authvw INNER JOIN @{RelationshipAuthorizationConventions.ClaimsParameterName} c ON authvw.{filterDefinition.ViewSourceEndpointName} = c.Id AND authvw.{filterDefinition.ViewTargetEndpointName} = @{filterContext.SubjectEndpointName}";
    }

    public void ApplyClaimsParametersToCommand(DbCommand cmd, EdFiAuthorizationContext authorizationContext)
    {
        // No parameters needed if less than 2,000 EdOrgIds present
        if (authorizationContext.ApiClientContext.EducationOrganizationIds.Count < SqlServerParameterCountThreshold)
        {
            return;
        }
        
        // Assign EdOrgId claims
        var claimEdOrgIds = authorizationContext.ApiClientContext.EducationOrganizationIds;

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

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Infrastructure.Filtering;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased
{
    public class SqlServerRelationshipBasedAuthorizationViewJoinApplicator : IRelationshipBasedAuthorizationViewJoinApplicator
    {
        public void ApplyAuthorizationViewJoin(
            SqlBuilder sqlBuilder,
            AliasGenerator authViewAliasGenerator,
            RelationshipBasedAuthorizationFilterDetails authorizationFilterDetails)
        {
            string authViewAlias = authViewAliasGenerator.GetNextAlias();

            sqlBuilder.InnerJoin(
                $"{SystemConventions.AuthSchema}.{authorizationFilterDetails.ViewName} {authViewAlias} ON e.{authorizationFilterDetails.TargetEntityColumnName} = {authViewAlias}.{authorizationFilterDetails.TargetViewColumnName}");

            var claimEntityName = authorizationFilterDetails.ClaimEducationOrganizationEntityName;
            string claimViewColumnName = authorizationFilterDetails.ClaimViewColumnName;

            // TODO: API Simplification - May want to revisit the approach here, and use an inner join to the TVP rather than a sub-SELECT.
            sqlBuilder.Where(
                $"{authViewAlias}.{claimViewColumnName} IN (SELECT Id FROM @{claimEntityName.Schema}_{claimEntityName.Name}Ids)");
        }
    }
}

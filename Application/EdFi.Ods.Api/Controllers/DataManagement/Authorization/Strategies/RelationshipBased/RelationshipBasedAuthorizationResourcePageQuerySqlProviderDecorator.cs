// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Text;
using EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims;
using EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQueryTemplating;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased
{
    public class RelationshipBasedAuthorizationResourcePageQuerySqlProviderDecorator 
        : IResourcePageQuerySqlProvider
    {
        private readonly IResourcePageQuerySqlProvider _resourcePageQuerySqlProvider;
        private readonly IEducationOrganizationClaimsProvider _educationOrganizationClaimsProvider;

        public RelationshipBasedAuthorizationResourcePageQuerySqlProviderDecorator(
            IResourcePageQuerySqlProvider resourcePageQuerySqlProvider, 
            IEducationOrganizationClaimsProvider educationOrganizationClaimsProvider)
        {
            _resourcePageQuerySqlProvider = resourcePageQuerySqlProvider;
            _educationOrganizationClaimsProvider = educationOrganizationClaimsProvider;
        }
        
        public string GetSqlTemplate(Entity entity)
        {
            // TODO: API Simplification - Revisit: How to make it so this only runs for the relationship-based authorization strategy?
            
            // Get the page query's SQL template
            string pagedQuerySqlTemplate = _resourcePageQuerySqlProvider.GetSqlTemplate(entity);
            
            var sqlStringBuilder = new StringBuilder();

            foreach (var educationOrganizationClaims in _educationOrganizationClaimsProvider.GetEducationOrganizationClaims())
            {
                var fullName = educationOrganizationClaims.EntityFullName;
                string tvpName = $"@{fullName.Schema}_{fullName.Name}Ids";
                
                // Declare the TVP
                sqlStringBuilder.AppendLine($"DECLARE {tvpName} as dbo.IntTable");

                // Insert the EdOrgIds into the TVP
                foreach (int claimEducationOrganizationId in educationOrganizationClaims.EducationOrganizationIds)
                {
                    // TODO: API Simplification - May (or may not) want to consider Dapper's built-in support for TVP's described here: https://stackoverflow.com/a/43128585/368847
                    sqlStringBuilder.AppendLine($"INSERT INTO {tvpName} VALUES ({claimEducationOrganizationId})");
                }

                sqlStringBuilder.AppendLine();
            }
                
            // Insert the declaration for the EdOrgId TVPs at the top of the SQL template
            return $"{sqlStringBuilder}{pagedQuerySqlTemplate}";
        }

        public bool IsBatchable
        {
            get => _resourcePageQuerySqlProvider.IsBatchable;
        }
    }
}

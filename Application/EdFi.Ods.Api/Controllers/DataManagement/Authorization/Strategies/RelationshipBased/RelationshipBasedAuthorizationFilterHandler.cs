// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using Dapper;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased
{
    public class RelationshipBasedAuthorizationFilterHandler : IAuthorizationFilterHandler
    {
        private readonly IRelationshipBasedAuthorizationFilterHandler[] _relationshipBasedFilterHandlers;

        public RelationshipBasedAuthorizationFilterHandler(
            IRelationshipBasedAuthorizationFilterHandler[] relationshipBasedFilterHandlers)
        {
            _relationshipBasedFilterHandlers = relationshipBasedFilterHandlers;
        }

        public bool CanHandle(string authorizationStrategyName)
        {
            // Exit quickly if authorization strategy name doesn't follow prefix conventions
            if (!authorizationStrategyName.StartsWith(RelationshipBasedAuthorizationConventions.AuthorizationStrategyNamePrefix))
            {
                return false;
            }

            return _relationshipBasedFilterHandlers.Any(
                applicator => applicator.CanHandle(authorizationStrategyName));
        }

        public void ApplyFilter(string authorizationStrategyName, SqlBuilder sqlBuilder, Entity entity)
        {
            var filterApplicator =
                _relationshipBasedFilterHandlers.FirstOrDefault(a => a.CanHandle(authorizationStrategyName));

            if (filterApplicator == null)
            {
                throw new Exception($"Relationship-based authorization filter handler not found for authorization strategy '{authorizationStrategyName}'.");
            }

            filterApplicator.ApplyAuthorizationFilter(sqlBuilder, entity);
        }

        public void ApplyParameters(string authorizationStrategyName, DynamicParameters parameters, IQueryCollection query)
        {
            // Nothing to do
        }
    }

    // TODO: API Simplification - This might be needed in future if we use parameter-based TVPs from Dapper instead of SQL template-based TVPs 
    #region Possibly useful in future
    // public class RelationshipBasedAuthorizationStrategyFilterParameterApplicator : IAuthorizationStrategyFilterParameterApplicator
    // {
    //     private readonly IRelationshipBasedAuthorizationFilterApplicator[] _relationshipBasedAuthorizationFilterApplicators;
    //     private readonly IGroupedEducationOrganizationClaimsProvider _groupedEducationOrganizationClaimsProvider;
    //
    //     public RelationshipBasedAuthorizationStrategyFilterParameterApplicator(
    //         IRelationshipBasedAuthorizationFilterApplicator[] relationshipBasedAuthorizationFilterApplicators,
    //         IGroupedEducationOrganizationClaimsProvider groupedEducationOrganizationClaimsProvider)
    //     {
    //         _relationshipBasedAuthorizationFilterApplicators = relationshipBasedAuthorizationFilterApplicators;
    //         _groupedEducationOrganizationClaimsProvider = groupedEducationOrganizationClaimsProvider;
    //     }
    //     public bool TryApplyAuthorizationStrategyFilterParameters(
    //         string authorizationStrategy,
    //         DynamicParameters parameters,
    //         IQueryCollection query)
    //     {
    //         // Use the filter applicators to determine if the authorization strategy is handled by an implemented relationship-based authorization
    //         if (!_relationshipBasedAuthorizationFilterApplicators.Any(a => a.CanHandleAuthorization(authorizationStrategy)))
    //         {
    //             return false;
    //         }
    //
    //         // Apply the API client's EducationOrganizationId claims as parameters
    //         var educationOrganizationIdsGroupedByFullName =
    //             _groupedEducationOrganizationClaimsProvider.GetGroupedEducationOrganizationIds();
    //
    //         foreach (var grouping in educationOrganizationIdsGroupedByFullName)
    //         {
    //             parameters.Add();
    //         }
    //     }
    // }
    #endregion
}

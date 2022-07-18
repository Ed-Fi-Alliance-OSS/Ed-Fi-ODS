// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public class ViewBasedAuthorizationFilterDefinition : AuthorizationFilterDefinition
    {
        public ViewBasedAuthorizationFilterDefinition(
            string filterName,
            string viewName,
            string viewTargetEndpointName,
            Action<AuthorizationFilterDefinition, AuthorizationFilterContext, Resource, int, QueryBuilder, bool> trackedChangesCriteriaApplicator,
            Func<EdFiAuthorizationContext, AuthorizationFilterContext, InstanceAuthorizationResult> authorizeInstance,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport)
            : base(
                filterName, 
                $@"{{currentAlias}}.{{subjectEndpointName}} IN (
                    SELECT {{newAlias1}}.{viewTargetEndpointName} 
                    FROM " + GetFullNameForView($"auth_{viewName}") + $@" {{newAlias1}} 
                    WHERE {{newAlias1}}.{RelationshipAuthorizationConventions.ViewSourceColumnName} IN (:{RelationshipAuthorizationConventions.ClaimsParameterName}))",
                (criteria, @where, subjectEndpointName, parameters, joinType) => criteria.ApplyJoinFilter(
                    @where,
                    parameters,
                    viewName,
                    subjectEndpointName,
                    viewTargetEndpointName,
                    joinType,
                    Guid.NewGuid().ToString("N")),
                trackedChangesCriteriaApplicator,
                authorizeInstance)
        {
            ViewName = viewName;
            ViewTargetEndpointName = viewTargetEndpointName;
            ViewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        }

        public string ViewName { get; }

        public string ViewTargetEndpointName { get; }

        public IViewBasedSingleItemAuthorizationQuerySupport ViewBasedSingleItemAuthorizationQuerySupport { get; set; }

        private static string GetFullNameForView(string viewName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
        }
    }
}

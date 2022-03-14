// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure.Filtering;
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
            string subjectEndpointName,
            Func<EdFiAuthorizationContext, AuthorizationFilterContext, InstanceAuthorizationResult> authorizeInstance)
            : base(
                filterName,
                $@"{subjectEndpointName} IN (
                    SELECT {{newAlias1}}.{viewTargetEndpointName} 
                    FROM auth.{viewName} {{newAlias1}} 
                    WHERE {{newAlias1}}.{RelationshipAuthorizationConventions.ViewSourceColumnName} IN (:{RelationshipAuthorizationConventions.ClaimsParameterName}))", 
                $@"{{currentAlias}}.{subjectEndpointName} IN (
                    SELECT {{newAlias1}}.{viewTargetEndpointName} 
                    FROM " + GetFullNameForView($"auth_{viewName}") + $@" {{newAlias1}} 
                    WHERE {{newAlias1}}.{RelationshipAuthorizationConventions.ViewSourceColumnName} IN (:{RelationshipAuthorizationConventions.ClaimsParameterName}))",
                (criteria, @where, parameters, joinType) => criteria.ApplyJoinFilter(
                    @where,
                    parameters,
                    viewName,
                    subjectEndpointName,
                    viewTargetEndpointName,
                    joinType,
                    Guid.NewGuid().ToString("N")), // TODO: GKM - review usage of alias generator here instead of generating GUIDs
                authorizeInstance,
                (t, p) => p.HasPropertyNamed(subjectEndpointName ?? viewTargetEndpointName))
        {
            FilterName = filterName;
            ViewName = viewName;
            ViewTargetEndpointName = viewTargetEndpointName;
            SubjectEndpointName = subjectEndpointName ?? viewTargetEndpointName;
            ItemExistenceSql = $"SELECT 1 FROM auth.{viewName} AS authvw INNER JOIN @{RelationshipAuthorizationConventions.ClaimsParameterName} c ON authvw.{RelationshipAuthorizationConventions.ViewSourceColumnName} = c.Id AND authvw.{viewTargetEndpointName} = @{subjectEndpointName}";
        }

        public string FilterName { get; }

        public string ViewName { get; }

        public string ViewTargetEndpointName { get; }

        public string SubjectEndpointName { get; }

        public string ItemExistenceSql { get; }

        private static string GetFullNameForView(string viewName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
        }
    }
}

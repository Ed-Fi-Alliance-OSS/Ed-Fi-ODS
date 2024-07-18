// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

// ------------------------------------------------------------------------------------------
// TODO: ODS-6426, ODS-6427 - This file is a work-in-progress across multiple stories.
// ------------------------------------------------------------------------------------------

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public class ViewBasedAuthorizationFilterDefinition : AuthorizationFilterDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewBasedAuthorizationFilterDefinition"/> class using parameters for a
        /// relationship-based authorization view join using a single column.
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="viewName"></param>
        /// <param name="viewSourceEndpointName"></param>
        /// <param name="viewTargetEndpointName"></param>
        /// <param name="trackedChangesCriteriaApplicator"></param>
        /// <param name="authorizeInstance"></param>
        /// <param name="viewBasedSingleItemAuthorizationQuerySupport"></param>
        /// <param name="multiValueRestrictions"></param>
        public ViewBasedAuthorizationFilterDefinition(
            string filterName,
            string viewName,
            string viewSourceEndpointName,
            string viewTargetEndpointName,
            Action<AuthorizationFilterDefinition, AuthorizationFilterContext, Resource, int, QueryBuilder, bool> trackedChangesCriteriaApplicator,
            Func<EdFiAuthorizationContext, AuthorizationFilterContext, string, InstanceAuthorizationResult> authorizeInstance,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
            IMultiValueRestrictions multiValueRestrictions)
            : base(
                filterName,
                $@"{{currentAlias}}.{{subjectEndpointName}} IN (
                    SELECT {{newAlias1}}.{viewTargetEndpointName} 
                    FROM {GetFullNameForView($"auth_{viewName}")} {{newAlias1}} 
                    WHERE {{newAlias1}}.{viewSourceEndpointName} IN (:{RelationshipAuthorizationConventions.ClaimsParameterName}))",
                (criteria, @where, subjectEndpointNames, parameters, joinType, authorizationStrategy) =>
                {
                    if (subjectEndpointNames?.Length != 1)
                    {
                        throw new ArgumentException("Exactly one authorization subject endpoint name is expected for single-column view-based authorization.");
                    }

                    criteria.ApplySingleColumnJoinFilter(
                        multiValueRestrictions,
                        @where,
                        parameters,
                        viewName,
                        subjectEndpointNames[0],
                        viewSourceEndpointName,
                        viewTargetEndpointName,
                        joinType,
                        Guid.NewGuid().ToString("N"));
                },
                trackedChangesCriteriaApplicator,
                authorizeInstance)
        {
            ViewName = viewName;
            ViewSourceEndpointName = viewSourceEndpointName;
            ViewTargetEndpointName = viewTargetEndpointName;
            ViewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewBasedAuthorizationFilterDefinition"/> class using parameters for a
        /// custom view-based authorization join.
        /// </summary>
        /// <param name="filterName"></param>
        /// <param name="viewName"></param>
        /// <param name="viewTargetEndpointNames"></param>
        /// <param name="trackedChangesCriteriaApplicator"></param>
        /// <param name="authorizeInstance"></param>
        /// <param name="viewBasedSingleItemAuthorizationQuerySupport"></param>
        public ViewBasedAuthorizationFilterDefinition(
            string filterName,
            string viewName,
            // string viewSourceEndpointName,
            string[] viewTargetEndpointNames,
            Action<AuthorizationFilterDefinition, AuthorizationFilterContext, Resource, int, QueryBuilder, bool> trackedChangesCriteriaApplicator,
            Func<EdFiAuthorizationContext, AuthorizationFilterContext, string, InstanceAuthorizationResult> authorizeInstance,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport) //,
            // IMultiValueRestrictions multiValueRestrictions)
            : base(
                filterName,
                $@"{{currentAlias}}.{{subjectEndpointName}} IN (
                    SELECT {{newAlias1}}.{viewTargetEndpointNames[0]} // TODO: Fix HQL 
                    FROM {GetFullNameForView($"auth_{viewName}")} {{newAlias1}} )",
                    //WHERE {{newAlias1}}.{viewSourceEndpointName} IN (:{RelationshipAuthorizationConventions.ClaimsParameterName}))",
                (criteria, @where, subjectEndpointNames, parameters, joinType, authorizationStrategy) 
                    => criteria.ApplyCustomViewJoinFilter(
                        // multiValueRestrictions,
                        // @where,
                        // parameters,
                        viewName,
                        subjectEndpointNames,
                        // viewSourceEndpointName,
                        viewTargetEndpointNames,
                        joinType,
                        Guid.NewGuid().ToString("N"),
                        authorizationStrategy),
                trackedChangesCriteriaApplicator,
                authorizeInstance)
        {
            ViewName = viewName;
            // ViewSourceEndpointName = viewSourceEndpointName;
            ViewTargetEndpointNames = viewTargetEndpointNames;
            ViewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        }

        public string ViewName { get; }

        public string ViewSourceEndpointName { get; }
        public string ViewTargetEndpointName { get; }
        public string[] ViewTargetEndpointNames { get; }

        public IViewBasedSingleItemAuthorizationQuerySupport ViewBasedSingleItemAuthorizationQuerySupport { get; set; }

        private static string GetFullNameForView(string viewName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
        }
    }
}

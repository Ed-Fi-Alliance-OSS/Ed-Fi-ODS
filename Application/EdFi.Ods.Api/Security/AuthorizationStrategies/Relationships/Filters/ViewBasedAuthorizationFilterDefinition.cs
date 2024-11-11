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

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public class ViewBasedAuthorizationFilterDefinition : AuthorizationFilterDefinition
    {
        private AliasGenerator _aliasGenerator = new AliasGenerator("authvw");

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
            Func<DataManagementRequestContext, AuthorizationFilterContext, string, InstanceAuthorizationResult> authorizeInstance,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport)
            : base(
                filterName,
                $@"{{currentAlias}}.{{subjectEndpointName}} IN (
                    SELECT {{newAlias1}}.{viewTargetEndpointName} 
                    FROM {GetFullNameForView($"auth_{viewName}")} {{newAlias1}} 
                    WHERE {{newAlias1}}.{viewSourceEndpointName} IN (:{RelationshipAuthorizationConventions.ClaimsParameterName}))",
                (queryBuilder, @where, resource, subjectEndpointNames, parameters, joinType, authorizationStrategy) =>
                {
                    if (subjectEndpointNames?.Length != 1)
                    {
                        throw new ArgumentException("Exactly one authorization subject endpoint name is expected for single-column view-based authorization.");
                    }

                    @where.ApplySingleColumnJoinFilter(
                        resource,
                        parameters,
                        viewName,
                        subjectEndpointNames[0],
                        viewSourceEndpointName,
                        viewTargetEndpointName,
                        joinType,
                        Guid.NewGuid().ToString("N").Substring(0, 6));
                },
                trackedChangesCriteriaApplicator,
                authorizeInstance)
        {
            ViewName = viewName;
            ViewSourceEndpointNames = [viewSourceEndpointName];
            ViewTargetEndpointNames = [viewTargetEndpointName];
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
            string[] viewTargetEndpointNames,
            Action<AuthorizationFilterDefinition, AuthorizationFilterContext, Resource, int, QueryBuilder, bool> trackedChangesCriteriaApplicator,
            Func<DataManagementRequestContext, AuthorizationFilterContext, string, InstanceAuthorizationResult> authorizeInstance,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport)
            : base(
                filterName,
                null, // HQL condition (not supported by view-based authorization)
                (criteria, @where, resource, subjectEndpointNames, parameters, joinType, authorizationStrategy) 
                    => criteria.ApplyCustomViewJoinFilter(
                        viewName,
                        subjectEndpointNames,
                        viewTargetEndpointNames,
                        joinType,
                        Guid.NewGuid().ToString("N"),
                        authorizationStrategy),
                trackedChangesCriteriaApplicator,
                authorizeInstance)
        {
            ViewName = viewName;
            ViewTargetEndpointNames = viewTargetEndpointNames;
            ViewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        }

        public string ViewName { get; }
        public string[] ViewSourceEndpointNames { get; }
        public string[] ViewTargetEndpointNames { get; }

        // Single-value property retained for backwards compatibility with existing use of single-column joins
        public string ViewSourceEndpointName
        {
            get
            {
                return ViewSourceEndpointNames?.Length switch
                {
                    0 => null,
                    1 => ViewSourceEndpointNames[0],
                    _ => throw new InvalidOperationException(
                        "Multiple view source endpoint names were found in the filter definition when exactly one was expected.")
                };
            }
        }

        // Single-value property retained for backwards compatibility with existing use of single-column joins
        public string ViewTargetEndpointName
        {
            get
            {
                return ViewTargetEndpointNames?.Length switch
                {
                    0 => null,
                    1 => ViewTargetEndpointNames[0],
                    _ => throw new InvalidOperationException(
                        "Multiple view target endpoint names were found in the filter definition when exactly one was expected.")
                };
            }
        }

        public IViewBasedSingleItemAuthorizationQuerySupport ViewBasedSingleItemAuthorizationQuerySupport { get; set; }

        private static string GetFullNameForView(string viewName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
        }
    }
}

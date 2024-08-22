// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.CustomViewBased;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public static class QueryBuilderExtensions
    {
        /// <summary>
        /// Applies a join-based filter to the criteria for the specified authorization view.
        /// </summary>
        /// <param name="queryBuilder"></param>
        /// <param name="parameters">The named parameters to be used to satisfy additional filtering requirements.</param>
        /// <param name="viewName">The name of the view to be filtered.</param>
        /// <param name="subjectEndpointName">The name of the property to be joined for the entity being queried.</param>
        /// <param name="viewSourceEndpointName">The name of the property to be filtered using the claim values.</param> 
        /// <param name="viewTargetEndpointName">The name of the property to be joined for the other property as authorization view.</param> 
        /// <param name="joinType">The <see cref="JoinType" /> to be used.</param>
        /// <param name="authViewAlias">The name of the property to be used for auth View Alias name.</param>
        public static void ApplySingleColumnJoinFilter(
            this QueryBuilder queryBuilder,
            IDictionary<string, object> parameters,
            string viewName,
            string subjectEndpointName,
            string viewSourceEndpointName,
            string viewTargetEndpointName,
            JoinType joinType,
            string authViewAlias = null)
        {
            authViewAlias = string.IsNullOrWhiteSpace(authViewAlias) ? $"authView{viewName}" : $"authView{authViewAlias}";

            // Apply authorization join using ICriteria
            if (joinType == JoinType.InnerJoin)
            {
                queryBuilder.Join(
                    $"auth.{viewName} AS {authViewAlias}",
                    j => j.On($"r.{subjectEndpointName}", $"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else if (joinType == JoinType.LeftOuterJoin)
            {
                queryBuilder.LeftJoin(
                    $"auth.{viewName} AS {authViewAlias}",
                    j => j.On($"r.{subjectEndpointName}", $"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else
            {
                throw new NotSupportedException("Unsupported authorization view join type.");
            }
            
            // Defensive check to ensure required parameter is present
            if (!parameters.TryGetValue(RelationshipAuthorizationConventions.ClaimsParameterName, out object value))
            {
                throw new Exception($"Unable to find parameter for filtering '{RelationshipAuthorizationConventions.ClaimsParameterName}' on view '{viewName}'. Available parameters: '{string.Join("', '", parameters.Keys)}'");
            }

            if (value is object[] arrayOfValues)
            {
                if (joinType == JoinType.InnerJoin)
                {
                    queryBuilder.WhereIn($"{authViewAlias}.{viewSourceEndpointName}", arrayOfValues);
                }
                else
                {
                    queryBuilder.Where(qb => 
                        qb.WhereIn($"{authViewAlias}.{viewSourceEndpointName}", arrayOfValues)
                            .WhereNotNull($"{authViewAlias}.{viewTargetEndpointName}"));
                }
            }
            else
            {
                if (joinType == JoinType.InnerJoin)
                {
                    queryBuilder.Where($"{authViewAlias}.{viewSourceEndpointName}", value);
                }
                else
                {
                    queryBuilder.Where(qb => 
                        qb.Where($"{authViewAlias}.{viewSourceEndpointName}", value)
                            .WhereNotNull($"{authViewAlias}.{viewTargetEndpointName}"));
                }
            }
        }

        private static string GetFullNameForView(this string viewName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
        }

        /// <summary>
        /// Applies a join-based filter to the criteria for the specified custom authorization view.
        /// </summary>
        /// <param name="criteria">The criteria to which filters should be applied.</param>
        /// <param name="viewName">The name of the view to be filtered.</param>
        /// <param name="subjectEndpointNames">The name of the property to be joined for the entity being queried.</param>
        /// <param name="viewTargetEndpointNames">The name of the property to be joined for the other property as authorization view.</param> 
        /// <param name="joinType">The <see cref="JoinType" /> to be used.</param>
        /// <param name="authViewAlias">The name of the property to be used for auth View Alias name.</param>
        /// <param name="authorizationStrategy">The authorization strategy instance (which may be an instance providing additional context for authorization).</param>
        public static void ApplyCustomViewJoinFilter(
            this QueryBuilder queryBuilder,
            string viewName,
            string[] subjectEndpointNames,
            string[] viewTargetEndpointNames,
            JoinType joinType,
            string authViewAlias,
            IAuthorizationStrategy authorizationStrategy)
        {
            if (authorizationStrategy is not CustomViewBasedAuthorizationStrategy customViewBasedAuthorizationStrategy)
            {
                throw new Exception(
                    $"The authorization strategy supplied to the '{nameof(ApplyCustomViewJoinFilter)}' was not of the expected type '{nameof(CustomViewBasedAuthorizationStrategy)}'.");
            }
            
            string authViewFullAlias = $"{CustomViewHelpers.GetAliasPrefix(viewName)}{authViewAlias}";

            if (subjectEndpointNames.Length == 1)
            {
                // Apply authorization join using the query builder
                queryBuilder.Join(
                    $"auth.{viewName} AS {authViewFullAlias}",
                    j => j.On($"r.{subjectEndpointNames[0]}", $"{authViewFullAlias}.{viewTargetEndpointNames[0]}"),
                    joinType);
            }
            else
            {
                // Apply authorization join using ICriteria
                queryBuilder.Join(
                    $"auth.{viewName} AS {authViewFullAlias}", j =>
                    {
                        for (int i = 0; i < subjectEndpointNames.Length; i++)
                        {
                            j.On($"r.{subjectEndpointNames[i]}", $"{authViewFullAlias}.{viewTargetEndpointNames[i]}");
                        }

                        return j;
                    },
                    joinType);
            }
        }
    }
}

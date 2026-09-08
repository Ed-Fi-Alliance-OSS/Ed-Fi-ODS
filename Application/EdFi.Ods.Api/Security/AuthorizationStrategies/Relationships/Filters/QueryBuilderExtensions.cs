// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.CustomViewBased;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public static class QueryBuilderExtensions
    {
        private static readonly CallContextStorage _callContextStorage = new();

        internal const string EducationOrganizationIdToEducationOrganizationIdViewName =
            "EducationOrganizationIdToEducationOrganizationId";

        /// <summary>
        /// Applies a join-based filter to the criteria for the specified authorization view.
        /// </summary>
        /// <param name="queryBuilder">The <see cref="QueryBuilder" /> to which criteria should be applied.</param>
        /// <param name="resource"></param>
        /// <param name="parameters">The named parameters to be used to satisfy additional filtering requirements.</param>
        /// <param name="viewName">The name of the view to be filtered.</param>
        /// <param name="subjectEndpointName">The name of the property to be joined for the entity being queried.</param>
        /// <param name="viewSourceEndpointName">The name of the property to be filtered using the claim values.</param> 
        /// <param name="viewTargetEndpointName">The name of the property to be joined for the other property as authorization view.</param> 
        /// <param name="joinType">The <see cref="JoinType" /> to be used.</param>
        /// <param name="authViewAlias">The name of the property to be used for auth View Alias name.</param>
        public static void ApplySingleColumnJoinFilter(
            this QueryBuilder queryBuilder,
            Resource resource,
            IDictionary<string, object> parameters,
            string viewName,
            string subjectEndpointName,
            string viewSourceEndpointName,
            string viewTargetEndpointName,
            JoinType joinType,
            string authViewAlias = null)
        {
            // Undocumented opt-in to using original join-based authorization
            bool useJoinAuth = _callContextStorage.GetValue<bool>("UseJoinAuth"); 

            if (useJoinAuth || queryBuilder.Context.UsesJoinFilterStrategy())
            {
                ApplySingleColumnJoinFilterUsingJoins(
                    queryBuilder,
                    resource,
                    parameters,
                    viewName,
                    subjectEndpointName,
                    viewSourceEndpointName,
                    viewTargetEndpointName,
                    joinType,
                    authViewAlias);
            }
            else if (queryBuilder.Context.UsesCteFilterStrategy())
            {
                ApplySingleColumnJoinFilterUsingCtes(
                    queryBuilder,
                    resource,
                    parameters,
                    viewName,
                    subjectEndpointName,
                    viewSourceEndpointName,
                    viewTargetEndpointName,
                    joinType,
                    authViewAlias);
            }
            else if (queryBuilder.Context.UsesExistsSubqueryFilterStrategy())
            {
                ApplySingleColumnExistsSubqueryFilter(
                    queryBuilder,
                    resource,
                    parameters,
                    viewName,
                    subjectEndpointName,
                    viewSourceEndpointName,
                    viewTargetEndpointName);
            }
            else
            {
                if (queryBuilder.Context.TryGetValue(nameof(QueryBuilderFilterStrategy), out var filterStrategy))
                {
                    throw new NotSupportedException($"Authorization filter strategy '{filterStrategy}' has not been implemented.");
                }
                
                throw new NotSupportedException($"Authorization filter strategy has not been implemented.");
            }
        }

        private static void ApplySingleColumnExistsSubqueryFilter(
            this QueryBuilder queryBuilder,
            Resource resource,
            IDictionary<string, object> parameters,
            string viewName,
            string subjectEndpointName,
            string viewSourceEndpointName,
            string viewTargetEndpointName)
        {
            // Defensive check to ensure required parameter is present
            if (!parameters.TryGetValue(RelationshipAuthorizationConventions.ClaimsParameterName, out object value))
            {
                throw new Exception($"Unable to find parameter for filtering '{RelationshipAuthorizationConventions.ClaimsParameterName}' on view '{viewName}'. Available parameters: '{string.Join("', '", parameters.Keys)}'");
            }

            // Create a CTE query for the authorization view
            var existsQuery = new QueryBuilder(queryBuilder.Dialect, queryBuilder.ParameterIndexer);
            existsQuery.From($"auth.{viewName} AS av");
            existsQuery.Select("1");

            // Apply target join to subject in containing query
            var subjectJoin =  GetSubjectJoinDetails(resource, subjectEndpointName);
            existsQuery.WhereRaw($"av.{viewTargetEndpointName} = {subjectJoin.tableAlias}.{subjectEndpointName}");

            // Apply claims to the CTE query
            if (value is object[] arrayOfValues)
            {
                existsQuery.WhereIn($"av.{viewSourceEndpointName}", arrayOfValues, $"@{RelationshipAuthorizationConventions.ClaimsParameterName}");
            }
            else
            {
                existsQuery.Where($"av.{viewSourceEndpointName}", value, $"@{RelationshipAuthorizationConventions.ClaimsParameterName}");
            }

            // Add the CTE to the main query, with alias
            queryBuilder.WhereExists(existsQuery);
        }

        private static void ApplySingleColumnJoinFilterUsingCtes(
            this QueryBuilder queryBuilder,
            Resource resource,
            IDictionary<string, object> parameters,
            string viewName,
            string subjectEndpointName,
            string viewSourceEndpointName,
            string viewTargetEndpointName,
            JoinType joinType,
            string authViewAlias = null)
        {
            // Defensive check to ensure required parameter is present
            if (!parameters.TryGetValue(RelationshipAuthorizationConventions.ClaimsParameterName, out object value))
            {
                throw new Exception($"Unable to find parameter for filtering '{RelationshipAuthorizationConventions.ClaimsParameterName}' on view '{viewName}'. Available parameters: '{string.Join("', '", parameters.Keys)}'");
            }

            authViewAlias = string.IsNullOrWhiteSpace(authViewAlias) ? $"authView{viewName}" : $"authView{authViewAlias}";

            // Record the kind of authorization view applied, so the dialect can decide on query hints
            if (viewName == EducationOrganizationIdToEducationOrganizationIdViewName)
            {
                queryBuilder.MarkEducationOrganizationAuthorizationFilter();
            }
            else
            {
                queryBuilder.MarkPersonAuthorizationFilter(IsPersonTheCompleteResourceKey(resource, subjectEndpointName));
            }

            QueryBuilder cte;

            // For SQL Server, land the ed-org expansion for the claim into a temp table so the optimizer gets
            // value-level statistics on the authorized ed-org ids (the landing INSERT is the exact query this CTE
            // would otherwise run, so consuming the temp table is semantically identical).
            //
            // Restricted to the forward orientation on purpose. The inverted relationship strategies reuse this same
            // view with the source and target columns swapped, so they expand the claim in the opposite direction and
            // the landing statement below would authorize the wrong set of education organizations for them.
            if (queryBuilder.Dialect is SqlServerDialect
                && IsForwardEducationOrganizationExpansion(viewName, viewSourceEndpointName, viewTargetEndpointName)
                && value is object[] claimValues
                && claimValues.Length > 0)
            {
                var tvpParameters = SqlServerDialect.CreateTableValuedParameters(
                    SqlServerDialect.ClaimsParameterName,
                    claimValues);

                queryBuilder.Prologue(SqlServerDialect.ClaimsTempTableLandingSql, tvpParameters);
                queryBuilder.Prologue(SqlServerDialect.AuthEdOrgsTempTableLandingSql);

                cte = new QueryBuilder(queryBuilder.Dialect, queryBuilder.ParameterIndexer);
                cte.From($"{SqlServerDialect.AuthEdOrgsTempTableName} AS av");
                cte.Select($"av.Id AS {viewTargetEndpointName}");
            }
            else
            {
                // Create a CTE query for the authorization view
                cte = new QueryBuilder(queryBuilder.Dialect, queryBuilder.ParameterIndexer);
                cte.From($"auth.{viewName} AS av");
                cte.Select($"av.{viewTargetEndpointName}");
                cte.Distinct();

                // Apply claims to the CTE query
                if (value is object[] arrayOfValues)
                {
                    cte.WhereIn($"av.{viewSourceEndpointName}", arrayOfValues, $"@{RelationshipAuthorizationConventions.ClaimsParameterName}");
                }
                else
                {
                    cte.Where($"av.{viewSourceEndpointName}", value, $"@{RelationshipAuthorizationConventions.ClaimsParameterName}");
                }
            }

            // Add the CTE to the main query, with alias
            queryBuilder.With(authViewAlias, cte);

            var subjectJoin =  GetSubjectJoinDetails(resource, subjectEndpointName);

            // Apply join to the authorization CTE
            if (joinType == JoinType.InnerJoin)
            {
                queryBuilder.Join(
                    authViewAlias,
                    j => j.On($"{subjectJoin.tableAlias}.{subjectJoin.endpointName}", $"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else if (joinType == JoinType.LeftOuterJoin)
            {
                queryBuilder.LeftJoin(
                    authViewAlias,
                    j => j.On($"{subjectJoin.tableAlias}.{subjectJoin.endpointName}", $"{authViewAlias}.{viewTargetEndpointName}"));
            
                queryBuilder.Where(qb => qb.WhereNotNull($"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else
            {
                throw new NotSupportedException("Unsupported authorization view join type.");
            }
        }

        private static void ApplySingleColumnJoinFilterUsingJoins(
            QueryBuilder queryBuilder,
            Resource resource,
            IDictionary<string, object> parameters,
            string viewName,
            string subjectEndpointName,
            string viewSourceEndpointName,
            string viewTargetEndpointName,
            JoinType joinType,
            string authViewAlias)
        {
            // Defensive check to ensure required parameter is present
            if (!parameters.TryGetValue(RelationshipAuthorizationConventions.ClaimsParameterName, out object value))
            {
                throw new Exception($"Unable to find parameter for filtering '{RelationshipAuthorizationConventions.ClaimsParameterName}' on view '{viewName}'. Available parameters: '{string.Join("', '", parameters.Keys)}'");
            }

            authViewAlias = string.IsNullOrWhiteSpace(authViewAlias) ? $"authView{viewName}" : $"authView{authViewAlias}";

            var subjectJoin =  GetSubjectJoinDetails(resource, subjectEndpointName);

            // Apply join to the authorization view
            if (joinType == JoinType.InnerJoin)
            {
                queryBuilder.Join(
                    $"auth.{viewName} AS {authViewAlias}",
                    j => j.On($"{subjectJoin.tableAlias}.{subjectJoin.tableAlias}", $"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else if (joinType == JoinType.LeftOuterJoin)
            {
                queryBuilder.LeftJoin(
                    $"auth.{viewName} AS {authViewAlias}",
                    j => j.On($"{subjectJoin.tableAlias}.{subjectJoin.endpointName}", $"{authViewAlias}.{viewTargetEndpointName}"));
            }
            else
            {
                throw new NotSupportedException("Unsupported authorization view join type.");
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

        /// <summary>
        /// Indicates whether the supplied authorization view and column pair is the forward education organization
        /// expansion, which is the only orientation the temp table landing statement is written for. The inverted
        /// relationship strategies reuse the same view with the source and target columns swapped, so they expand the
        /// claim in the opposite direction and must not take that path.
        /// </summary>
        internal static bool IsForwardEducationOrganizationExpansion(
            string viewName,
            string viewSourceEndpointName,
            string viewTargetEndpointName)
        {
            return viewName == EducationOrganizationIdToEducationOrganizationIdViewName
                && viewSourceEndpointName == EducationOrganizationAuthorizationViewConstants.SourceColumnName
                && viewTargetEndpointName == EducationOrganizationAuthorizationViewConstants.TargetColumnName;
        }

        /// <summary>
        /// Indicates whether the supplied person endpoint is the resource's entire primary key, meaning the resource
        /// holds at most one row per authorized person.
        /// </summary>
        private static bool IsPersonTheCompleteResourceKey(Resource resource, string subjectEndpointName)
        {
            var identifyingProperties = resource.Entity.Identifier.Properties;

            return identifyingProperties.Count == 1
                && identifyingProperties[0].PropertyName.Equals(subjectEndpointName, StringComparison.OrdinalIgnoreCase);
        }

        private static (string tableAlias, string endpointName) GetSubjectJoinDetails(Resource resource, string subjectEndpointName)
        {
            // If the resource is derived and the subject property is identifying (part of the PK), join using the base table
            // to take advantage of indexes that are built on the base table and not each of the derived tables.
            if (resource.Entity.IsDerived
                && resource.Entity.PropertyByName.TryGetValue(subjectEndpointName, out var subjectProperty)
                && subjectProperty.IsIdentifying)
            {
                return (AliasConstants.BaseAlias, subjectProperty.BaseProperty.PropertyName);
            }

            return (AliasConstants.RootAlias, subjectEndpointName);
        }


        /// <summary>
        /// Applies a join-based filter to the <see cref="QueryBuilder" /> for the specified custom authorization view.
        /// </summary>
        /// <param name="queryBuilder">The <see cref="QueryBuilder" /> to which filters should be applied.</param>
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
        
        /// <summary>
        /// Applies property-level filter expressions to the query builder as either Equal or In expressions based on the supplied parameters.
        /// </summary>
        /// <param name="whereQueryBuilder">The <see cref="QueryBuilder" /> for adding WHERE clause-only criteria.</param>
        /// <param name="parameters">The named parameters to be processed into the criteria query.</param>
        /// <param name="availableFilterProperties">The array of property names that can be used for filtering.</param>
        public static void ApplyPropertyFilters(this QueryBuilder whereQueryBuilder, IDictionary<string, object> parameters, params string[] availableFilterProperties)
        {
            foreach (var nameAndValue in parameters.Where(x => availableFilterProperties.Contains(x.Key, StringComparer.OrdinalIgnoreCase)))
            {
                if (nameAndValue.Value is object[] arrayOfValues)
                {
                    whereQueryBuilder.WhereIn($"{nameAndValue.Key}", arrayOfValues);
                }
                else
                {
                    whereQueryBuilder.Where($"{nameAndValue.Key}", nameAndValue.Value);
                }
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.Extensions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Implements a filter configurator that uses the semantic API model to generate filters with default behavior
    /// for all permutations of education organizations and person types.  
    /// </summary>
    public class RelationshipsAuthorizationStrategyFilterDefinitionsFactory : IAuthorizationFilterDefinitionsFactory
    {
        private readonly IEducationOrganizationIdNamesProvider _educationOrganizationIdNamesProvider;
        private readonly IApiClientContextProvider _apiClientContextProvider;
        private readonly IViewBasedSingleItemAuthorizationQuerySupport _viewBasedSingleItemAuthorizationQuerySupport;
        private readonly IPersonTypesProvider _personTypesProvider;
        private readonly IMultiValueRestrictions _multiValueRestrictions;

        public RelationshipsAuthorizationStrategyFilterDefinitionsFactory(
            IEducationOrganizationIdNamesProvider educationOrganizationIdNamesProvider,
            IApiClientContextProvider apiClientContextProvider,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
            IPersonTypesProvider personTypesProvider,
            IMultiValueRestrictions multiValueRestrictions)
        {
            _educationOrganizationIdNamesProvider = educationOrganizationIdNamesProvider;
            _apiClientContextProvider = apiClientContextProvider;
            _viewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
            _personTypesProvider = personTypesProvider;
            _multiValueRestrictions = multiValueRestrictions;
        }
        
        public AuthorizationFilterDefinition CreateAuthorizationFilterDefinition(string filterName)
        {
            // Only pre-defined filter definitions are created by this factory
            return null;
        }

        public virtual IReadOnlyList<AuthorizationFilterDefinition> CreatePredefinedAuthorizationFilterDefinitions()
        {
            return CreateAllEducationOrganizationToPersonFilters()
                .Concat(CreateAllEducationOrganizationToEducationOrganizationFilters())
                .ToArray();
        }

        protected IEnumerable<ViewBasedAuthorizationFilterDefinition> CreateAllEducationOrganizationToPersonFilters(
            string authorizationPathModifier = null,
            Func<string, bool> shouldIncludePersonType = null)
        {
            string[] personUsiNames = _personTypesProvider.PersonTypes
                .Where(usiName => shouldIncludePersonType == null || shouldIncludePersonType(usiName))
                // Sort the person types to ensure a determinate alias generation during filter definition
                .OrderBy(p => p)
                .Select(personType => $"{personType}USI")
                .ToArray();

            return personUsiNames.Select(usiName => 
                new ViewBasedAuthorizationFilterDefinition(
                    $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{usiName}{authorizationPathModifier}",
                    $"EducationOrganizationIdTo{usiName}{authorizationPathModifier}",
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                    usiName,
                    ApplyTrackedChangesAuthorizationCriteria,
                    AuthorizeInstance,
                    _viewBasedSingleItemAuthorizationQuerySupport
                )
            );
        }

        protected IEnumerable<ViewBasedAuthorizationFilterDefinition> CreateAllEducationOrganizationToEducationOrganizationFilters()
        {
            string[] concreteEdOrgIdNames = _educationOrganizationIdNamesProvider.GetAllNames(); 
            
            return concreteEdOrgIdNames
                // Sort the edorg id names to ensure a determinate alias generation during filter definition
                .OrderBy(n => n)
                .Select(concreteEdOrgId => 
                    new ViewBasedAuthorizationFilterDefinition(
                        $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{concreteEdOrgId}",
                        "EducationOrganizationIdToEducationOrganizationId",
                        EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                        EducationOrganizationAuthorizationViewConstants.TargetColumnName,
                        ApplyTrackedChangesAuthorizationCriteria,
                        AuthorizeInstance,
                        _viewBasedSingleItemAuthorizationQuerySupport
                    )
                )
                // Add filter definitions for using the EdOrg hierarchy inverted
                .Concat(concreteEdOrgIdNames
                    // Sort the edorg id names to ensure a determinate alias generation during filter definition
                    .OrderBy(n => n)
                    .Select(concreteEdOrgId => 
                        new ViewBasedAuthorizationFilterDefinition(
                            $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{concreteEdOrgId}{RelationshipAuthorizationConventions.InvertedSuffix}",
                            "EducationOrganizationIdToEducationOrganizationId",
                            EducationOrganizationAuthorizationViewConstants.TargetColumnName,
                            EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                            ApplyTrackedChangesAuthorizationCriteria,
                            AuthorizeInstance,
                            _viewBasedSingleItemAuthorizationQuerySupport
                        )
                    )
                );
        }

        private InstanceAuthorizationResult AuthorizeInstance(
            DataManagementRequestContext authorizationContext,
            AuthorizationFilterContext filterContext,
            string authorizationStrategyName)
        {
            if (filterContext.SubjectEndpointValue == null)
            {
                if (!filterContext.SubjectEndpointName.EndsWith("USI"))
                {
                    string existingLiteral = authorizationContext.AuthorizationPhase.GetPhaseText("existing ");

                    throw new SecurityAuthorizationException(
                        SecurityAuthorizationException.DefaultDetail + $" The {existingLiteral}'{filterContext.SubjectEndpointName}' value is required for authorization purposes.",
                        authorizationContext.AuthorizationPhase.GetPhaseText($"The existing resource item is inaccessible to clients using the '{authorizationStrategyName}' authorization strategy."))
                    {
                        InstanceTypeParts = authorizationContext.AuthorizationPhase == AuthorizationPhase.ProposedData
                            // On proposed data
                            ? ["relationships", "access-denied", "element-required"]
                            // On existing data
                            : ["relationships", "invalid-data", "element-uninitialized"]
                    };
                }

                // We will defer to the final authorization check to produce identical messages
                // whether the endpoint values are null or not.
                return InstanceAuthorizationResult.NotPerformed();
            }

            // If the subject's endpoint name is an Education Organization Id, we can try to authenticate it here.
            if (_educationOrganizationIdNamesProvider.IsEducationOrganizationIdName(filterContext.SubjectEndpointName))
            {
                // NOTE: Could consider caching the EdOrgToEdOrgId tuple table.
                // If the EdOrgId values match, then we can report the filter as successfully authorized
                if (_apiClientContextProvider.GetApiClientContext()
                    .EducationOrganizationIds.Contains((long) filterContext.SubjectEndpointValue))
                {
                    return InstanceAuthorizationResult.Success();
                }
            }

            return InstanceAuthorizationResult.NotPerformed();
        }

        /// <summary>
        /// For SQL Server, applies a person authorization filter by landing the claim's expansion through the view
        /// into a temp table and reading it as a semi-join, replacing the join this filter would otherwise apply.
        /// </summary>
        /// <returns><b>true</b> when the filter was applied this way; otherwise <b>false</b>, leaving it to the caller.</returns>
        /// <remarks>
        /// The claims landing on its own leaves this expansion estimated from average density, and the better claim
        /// estimate actually lowers that estimate, which shrinks the memory grant on a hash join that is already
        /// spilling. Restricted to the person views: the education organization expansion is not the misestimated
        /// side, and the inverted relationship strategies reuse that view with the source and target columns
        /// swapped, so a landing written for one orientation would authorize the wrong set for the other.
        /// </remarks>
        private static bool TryApplyPersonExpansionAuthorizationCriteria(
            QueryBuilder queryBuilder,
            ViewBasedAuthorizationFilterDefinition viewBasedFilterDefinition,
            AuthorizationFilterContext filterContext,
            string trackedChangesPropertyName,
            int filterIndex,
            bool useOuterJoins)
        {
            string viewName = viewBasedFilterDefinition.ViewName;

            if (queryBuilder.Dialect is not SqlServerDialect
                || viewName == QueryBuilderExtensions.EducationOrganizationIdToEducationOrganizationIdViewName
                || filterContext.ClaimParameterValues is not { Length: > 0 } claimValues)
            {
                return false;
            }

            string personColumnName = viewBasedFilterDefinition.ViewTargetEndpointName;

            var claimsParameters = SqlServerDialect.CreateTableValuedParameters(
                SqlServerDialect.ClaimsParameterName,
                claimValues);

            // The person landing reads from the claims temp table, so both statements are emitted here rather than
            // relying on another filter in the same query to have produced the first one. Duplicates are suppressed.
            queryBuilder.Prologue(SqlServerDialect.ClaimsTempTableLandingSql, claimsParameters);

            // The tracked changes table and the criterion selecting the kind of change are taken as a unit:
            // restricting by the table without the criterion leaves the case the restriction exists to avoid.
            string trackedChangesTableName = null;
            string trackedChangesCriterion = null;

            if (queryBuilder.Context.TryGetTrackedChangesTableName(out string contextTableName)
                && queryBuilder.Context.TryGetTrackedChangesCriterion(out string contextCriterion))
            {
                trackedChangesTableName = contextTableName;
                trackedChangesCriterion = contextCriterion;
            }

            string trackedChangesPersonColumnName = trackedChangesTableName == null
                ? null
                : $"Old{trackedChangesPropertyName}";

            queryBuilder.Prologue(
                SqlServerDialect.GetAuthPersonsTempTableLandingSql(
                    viewName,
                    viewBasedFilterDefinition.ViewSourceEndpointName,
                    personColumnName,
                    trackedChangesTableName,
                    trackedChangesPersonColumnName,
                    trackedChangesCriterion));

            string authPersonsAlias = $"ap{filterIndex}";

            string authPersonsTempTableName = SqlServerDialect.GetAuthPersonsTempTableName(
                viewName,
                trackedChangesPersonColumnName);

            string semiJoinCriteria =
                $"EXISTS (SELECT 1 FROM {authPersonsTempTableName} AS {authPersonsAlias}"
                + $" WHERE {authPersonsAlias}.{personColumnName} = c.Old{trackedChangesPropertyName})";

            if (useOuterJoins)
            {
                queryBuilder.OrWhereRaw(semiJoinCriteria);
            }
            else
            {
                queryBuilder.WhereRaw(semiJoinCriteria);
            }

            return true;
        }

        private static void ApplyTrackedChangesAuthorizationCriteria(
            AuthorizationFilterDefinition filterDefinition, 
            AuthorizationFilterContext filterContext, 
            Resource resource, 
            int filterIndex,
            QueryBuilder queryBuilder,
            bool useOuterJoins)
        {
            if (filterDefinition is not ViewBasedAuthorizationFilterDefinition viewBasedFilterDefinition)
            {
                 throw new Exception($"Expected a view-based filter definition of type '{nameof(ViewBasedAuthorizationFilterDefinition)}'.");
            }

            string viewName = viewBasedFilterDefinition.ViewName;

            string trackedChangesPropertyName = resource.Entity.IsDerived
                ? GetBasePropertyNameForSubjectEndpointName()
                : filterContext.SubjectEndpointName;

            if (TryApplyPersonExpansionAuthorizationCriteria(
                    queryBuilder,
                    viewBasedFilterDefinition,
                    filterContext,
                    trackedChangesPropertyName,
                    filterIndex,
                    useOuterJoins))
            {
                return;
            }

            if (useOuterJoins)
            {
                queryBuilder.LeftJoin(
                    $"auth.{viewName} AS rba{filterIndex}",
                    $"c.Old{trackedChangesPropertyName}",
                    $"rba{filterIndex}.{viewBasedFilterDefinition.ViewTargetEndpointName}");

                // Apply claim value criteria (named as the claims parameter so the SQL Server dialect lands the
                // TVP into the statistics-bearing temp table, as with the primary queries)
                queryBuilder.OrWhereIn(
                    $"rba{filterIndex}.{viewBasedFilterDefinition.ViewSourceEndpointName}",
                    filterContext.ClaimParameterValues,
                    $"@{RelationshipAuthorizationConventions.ClaimsParameterName}");
            }
            else
            {
                queryBuilder.Join(
                    $"auth.{viewName} AS rba{filterIndex}",
                    $"c.Old{trackedChangesPropertyName}",
                    $"rba{filterIndex}.{viewBasedFilterDefinition.ViewTargetEndpointName}");

                // Apply claim value criteria (named as the claims parameter so the SQL Server dialect lands the
                // TVP into the statistics-bearing temp table, as with the primary queries)
                queryBuilder.WhereIn(
                    $"rba{filterIndex}.{viewBasedFilterDefinition.ViewSourceEndpointName}",
                    filterContext.ClaimParameterValues,
                    $"@{RelationshipAuthorizationConventions.ClaimsParameterName}");
            }
            
            string GetBasePropertyNameForSubjectEndpointName()
            {
                if (!resource.Entity.PropertyByName.TryGetValue(filterContext.SubjectEndpointName, out var entityProperty))
                {
                    throw new Exception(
                        $"Unable to find property '{filterContext.SubjectEndpointName}' on entity '{resource.Entity.FullName}'.");
                }

                return entityProperty.BaseProperty.PropertyName;
            }
        }
    }
}

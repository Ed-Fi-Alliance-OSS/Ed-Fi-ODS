// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EdFi.Common;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Features.Composites.Infrastructure;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using log4net;

namespace EdFi.Ods.Features.Composites
{
    public class HqlBuilderAuthorizationDecorator : ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>
    {
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IDataManagementAuthorizationPlanFactory _dataManagementAuthorizationPlanFactory;

        private readonly ICompositeItemBuilder<HqlBuilderContext, CompositeQuery> _next;
        private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;

        public HqlBuilderAuthorizationDecorator(
            ICompositeItemBuilder<HqlBuilderContext, CompositeQuery> next,
            IDataManagementAuthorizationPlanFactory dataManagementAuthorizationPlanFactory,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider,
            IAuthorizationContextProvider authorizationContextProvider)
        {
            _next = Preconditions.ThrowIfNull(next, nameof(next));
            _dataManagementAuthorizationPlanFactory = Preconditions.ThrowIfNull(dataManagementAuthorizationPlanFactory, nameof(dataManagementAuthorizationPlanFactory));
            _authorizationFilterDefinitionProvider = Preconditions.ThrowIfNull(authorizationFilterDefinitionProvider, nameof(authorizationFilterDefinitionProvider));
            _authorizationContextProvider = authorizationContextProvider;
        }

        /// <summary>
        /// Applies processing related to the usage/entry to another top-level resource (e.g. applying authorization concerns).
        /// </summary>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <param name="builderContext">The current builder context.</param>
        /// <returns><b>true</b> if the resource can be processed; otherwise <b>false</b>.</returns>
        public bool TryIncludeResource(CompositeDefinitionProcessorContext processorContext, HqlBuilderContext builderContext)
        {
            var resourceClass = processorContext.CurrentResourceClass;

            if (resourceClass is not Resource resource)
            {
                throw new InvalidOperationException(
                    $"Unable to evaluate resource '{resourceClass.FullName}' for inclusion in HQL query because it is not the root class of the resource.");
            }

            // A resource that is not flattened is authorized on its own, so the rows of its members are not subject to the
            // authorization of any flattened references that contain it
            if (!builderContext.IsFlattenedReferenceChildContext)
            {
                builderContext.ContainingReferenceAuthorizations = Array.Empty<ContainingReferenceAuthorizationFiltering>();
            }

            // --------------------------
            //   Determine inclusion
            // --------------------------

            // In the case where we have an abstract class and it has no claim, eg EducationOrganization, we will allow the join if the subtype has been included.
            if (processorContext.IsAbstract())
            {
                if (processorContext.ShouldIncludeResourceSubtype())
                {
                    Logger.DebugFormat(
                        "Resource is abstract and so target resource '{0}' cannot be authorized. Join will be included, but non-identifying resource members should be stripped from results.",
                        processorContext.CurrentResourceClass.Name);

                    // The members of a flattened reference to an abstract resource (e.g. its collections) cannot be authorized
                    // either, so no rows are returned for them
                    if (builderContext.IsFlattenedReferenceChildContext)
                    {
                        builderContext.ContainingReferenceAuthorizations = builderContext.ContainingReferenceAuthorizations
                            .Append(new ContainingReferenceAuthorizationFiltering(null, builderContext.ParentAlias))
                            .ToArray();
                    }

                    return true;
                }

                Logger.DebugFormat("Resource '{0}' has been excluded from the response because it is abstract and only concrete types can be authorized. To include this referenced resource, use the 'includeResourceSubtype' attribute on the 'ReferencedResource' element in the composite definition.", processorContext.CurrentResourceClass.Name);
                return false;
            }

            // Authorize and apply filtering
            DataManagementAuthorizationPlan authorizationPlan;

            try
            {
                authorizationPlan =
                    _dataManagementAuthorizationPlanFactory.CreateAuthorizationPlan(resource, RequestActions.ReadActionUri);

                // Make sure that all applied filtering has HQL support 
                if (!authorizationPlan.Filtering.All(
                        filtering => filtering.Filters.All(
                            f => (_authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(
                                    f.FilterName,
                                    out var authorizationFilterDefinition)
                                && authorizationFilterDefinition.HqlConditionFormatString != null))))
                {
                    throw new SecurityConfigurationException(
                        SecurityConfigurationException.DefaultDetail,
                        $"The request cannot be authorized because an authorization strategy has been used for the '{resource.FullName}' resource that does not support Composites requests. Should a different authorization strategy be used?");
                }
            }
            catch (SecurityAuthorizationException ex)
            {
                // If this is the base resource, rethrow the exception to achieve a 401 response
                if (processorContext.IsBaseResource())
                {
                    Logger.DebugFormat("BaseResource: {0} could not be authorized.", processorContext.CurrentResourceClass.Name);

                    throw;
                }

                Logger.DebugFormat("Resource {0} is excluded from the request.", processorContext.CurrentResourceClass.Name);
                Logger.DebugFormat("AuthorizationException Message: {0}.", ex.Message);

                return false;
            }

            // Save the filters to be applied to this query for use later in the process
            builderContext.CurrentQueryAuthorizationFiltering = authorizationPlan.Filtering;

            // The child queries for the members of a flattened reference (e.g. its collections) must be authorized
            // against the referenced resource
            if (builderContext.IsFlattenedReferenceChildContext)
            {
                // The referenced resource's alias is the parent alias of the context used to process the reference's
                // children (see CreateFlattenedReferenceChildContext)
                builderContext.ContainingReferenceAuthorizations = builderContext.ContainingReferenceAuthorizations
                    .Append(new ContainingReferenceAuthorizationFiltering(authorizationPlan.Filtering, builderContext.ParentAlias))
                    .ToArray();
            }

            return true;
        }

        /// <summary>
        /// Builds the artifact for the root resource of the composite definition.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <param name="buildResult">The build result.</param>
        /// <returns><b>true</b> if the result could be built; otherwise <b>false</b>.</returns>
        public bool TryBuildForRootResource(
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext,
            out CompositeQuery buildResult)
        {
            ApplyFilters(processorContext, builderContext);

            return _next.TryBuildForRootResource(builderContext, processorContext, out buildResult);
        }

        /// <summary>
        /// Builds the artifact for the root resource of the composite definition.
        /// </summary>
        /// <param name="parentResult">The parent build result, for compositional behavior (if applicable).</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        /// <returns>The build result.</returns>
        public CompositeQuery BuildForChildResource(
            CompositeQuery parentResult,
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            ApplyFilters(processorContext, builderContext);
            ApplyContainingReferenceFilters(processorContext, builderContext);

            return _next.BuildForChildResource(parentResult, builderContext, processorContext);
        }

        /// <summary>
        /// Applies the composite resource's root resource to the build result using the supplied builder context.
        /// </summary>
        /// <param name="processorContext"></param>
        /// <param name="builderContext">The builder context.</param>
        public void ApplyRootResource(CompositeDefinitionProcessorContext processorContext, HqlBuilderContext builderContext)
        {
            _next.ApplyRootResource(processorContext, builderContext);
        }

        /// <summary>
        /// Applies the composite resource's child resource to the build result using the supplied builder context.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        public void ApplyChildResource(
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            _next.ApplyChildResource(builderContext, processorContext);
        }

        /// <summary>
        /// Apply the provided property projections onto the build result with the provided builder and composite
        /// definition processor contexts.
        /// </summary>
        /// <param name="propertyProjections">A list of property projections to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        public void ProjectProperties(
            IReadOnlyList<CompositePropertyProjection> propertyProjections,
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            _next.ProjectProperties(propertyProjections, builderContext, processorContext);
        }

        /// <summary>
        /// Builds a new context from the curent builder context for use in processing a flattened reference.
        /// </summary>
        /// <param name="builderContext">The builder context.</param>
        /// <returns>The new builder context for use in processing a flattened reference.</returns>
        public HqlBuilderContext CreateFlattenedMemberContext(HqlBuilderContext builderContext)
        {
            return _next.CreateFlattenedMemberContext(builderContext);
        }

        /// <summary>
        /// Applies the provided flattened resource reference to the build result using the suplied builder context.
        /// </summary>
        /// <param name="member">The flattened ReferencedResource or EmbeddedObject to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        public void ApplyFlattenedMember(ResourceMemberBase member, HqlBuilderContext builderContext)
        {
            _next.ApplyFlattenedMember(member, builderContext);

            // Only contexts created for projecting a flattened member's properties carry that member's authorization
            // filtering. Flattened members are also applied to the contexts of child queries (before the member is
            // authorized) just to join to the members they contain, and no properties are projected there.
            if (!builderContext.IsFlattenedMemberContext)
            {
                return;
            }

            // Embedded objects are part of the containing resource (any filtering present on the context was established
            // for the containing resource, not for the embedded object's alias).
            if (member is EmbeddedObject)
            {
                return;
            }

            ApplyFlattenedReferenceAuthorizationFlag(builderContext);
        }

        /// <summary>
        /// Projects a hidden column indicating whether the API client is authorized to read the resource referenced by a
        /// flattened reference, so that the reference's values can be removed from the response when it is not.
        /// </summary>
        /// <remarks>The containing rows are not filtered here because the flattened values are an optional part of
        /// the containing resource's representation.</remarks>
        private void ApplyFlattenedReferenceAuthorizationFlag(HqlBuilderContext builderContext)
        {
            var authorizationFiltering = builderContext.CurrentQueryAuthorizationFiltering;

            if (authorizationFiltering == null || !authorizationFiltering.SelectMany(f => f.Filters).Any())
            {
                return;
            }

            if (!TryBuildAuthorizationPredicate(
                    authorizationFiltering,
                    builderContext.CurrentAlias,
                    builderContext.CurrentQueryFilterParameterValueByName,
                    out string predicate))
            {
                return;
            }

            string flagAlias = $"{CompositeDefinitionHelper.Marker}Auth_{builderContext.CurrentAlias}";

            builderContext.Select.Append(
                $"{(builderContext.Select.Length > 0 ? $",{Environment.NewLine}\t" : string.Empty)}case when ({predicate}) then 1 else 0 end as {flagAlias}");

            builderContext.AuthorizationFlagAlias = flagAlias;
        }

        /// <summary>
        /// Applies the provided local identifying properties to the build result using the suplied builder context.
        /// </summary>
        /// <param name="locallyDefinedIdentifyingProperties">The list of local identifying properties to be applied to the build result.</param>
        /// <param name="builderContext">The builder context.</param>
        /// <param name="processorContext">The composite definition processor context.</param>
        public void ApplyLocalIdentifyingProperties(
            IReadOnlyList<EntityProperty> locallyDefinedIdentifyingProperties,
            HqlBuilderContext builderContext,
            CompositeDefinitionProcessorContext processorContext)
        {
            _next.ApplyLocalIdentifyingProperties(locallyDefinedIdentifyingProperties, builderContext, processorContext);
        }

        /// <summary>
        /// Captures context from the current builder context to be used as the baseline for processing children
        /// while allowing additional changes to be made to the current context.
        /// </summary>
        /// <seealso cref="ICompositeItemBuilder{TBuilderContext,TBuildResult}.CreateParentingContext"/>
        /// <param name="builderContext">The current build context.</param>
        /// <remarks>Implementations should use this as a means for preserving part of the current
        /// context for future use by storing the snapshotted context within the current context.</remarks>
        public void SnapshotParentingContext(HqlBuilderContext builderContext)
        {
            _next.SnapshotParentingContext(builderContext);
        }

        /// <summary>
        /// Creates a new builder context by applying previously snapshotted parental context.
        /// </summary>
        /// <param name="builderContext">The current builder context.</param>
        /// <returns>The new builder context to be used for child processing.</returns>
        public HqlBuilderContext CreateParentingContext(HqlBuilderContext builderContext)
        {
            return _next.CreateParentingContext(builderContext);
        }

        /// <summary>
        /// Creates a new builder context to be used for processing a child element.
        /// </summary>
        /// <param name="parentingBuilderContext">The parent context to be used to derive the new child context.</param>
        /// <param name="childProcessorContext"></param>
        /// <returns>The new builder context.</returns>
        public HqlBuilderContext CreateChildContext(
            HqlBuilderContext parentingBuilderContext,
            CompositeDefinitionProcessorContext childProcessorContext)
        {
            return _next.CreateChildContext(parentingBuilderContext, childProcessorContext);
        }

        /// <summary>
        /// Creates a new builder context to be used for processing a flattened reference.
        /// </summary>
        /// <param name="parentingBuilderContext">The parent builder context.</param>
        /// <returns>The new builder context.</returns>
        public HqlBuilderContext CreateFlattenedReferenceChildContext(HqlBuilderContext parentingBuilderContext)
        {
            return _next.CreateFlattenedReferenceChildContext(parentingBuilderContext);
        }

        private void ApplyFilters(
            CompositeDefinitionProcessorContext processorContext,
            HqlBuilderContext builderContext)
        {
            // Authorization filters are only applied to the resource roots
            if (!(processorContext.CurrentResourceClass is Resource))
            {
                return;
            }

            if (TryBuildAuthorizationPredicate(
                    builderContext.CurrentQueryAuthorizationFiltering,
                    builderContext.CurrentAlias,
                    builderContext.CurrentQueryFilterParameterValueByName,
                    out string predicate))
            {
                builderContext.Where.Append($"{AndIfNeeded(builderContext.Where)}{predicate}");
            }
        }

        /// <summary>
        /// Applies the authorization filters of the flattened references containing the member to the member's child query,
        /// so that the rows of the members of a referenced resource (e.g. its collections) are only returned when the API
        /// client is authorized to read the referenced resource.
        /// </summary>
        private void ApplyContainingReferenceFilters(
            CompositeDefinitionProcessorContext processorContext,
            HqlBuilderContext builderContext)
        {
            // Resources are authorized on their own (see TryIncludeResource and ApplyFilters)
            if (processorContext.CurrentResourceClass is Resource)
            {
                return;
            }

            foreach (var containingReferenceAuthorization in builderContext.ContainingReferenceAuthorizations)
            {
                // The referenced resource is abstract, and cannot be authorized
                if (containingReferenceAuthorization.Filtering == null)
                {
                    Logger.DebugFormat(
                        "No rows will be returned for '{0}' because it is a member of a flattened reference to an abstract resource, which cannot be authorized.",
                        processorContext.CurrentResourceClass.Name);

                    builderContext.Where.Append($"{AndIfNeeded(builderContext.Where)}1 = 0");

                    continue;
                }

                if (TryBuildAuthorizationPredicate(
                        containingReferenceAuthorization.Filtering,
                        containingReferenceAuthorization.Alias,
                        builderContext.CurrentQueryFilterParameterValueByName,
                        out string predicate))
                {
                    builderContext.Where.Append($"{AndIfNeeded(builderContext.Where)}{predicate}");
                }
            }
        }

        /// <summary>
        /// Builds the HQL predicate that combines the authorization filters of the supplied authorization strategies,
        /// and captures the values of the named parameters used by the predicate.
        /// </summary>
        /// <param name="authorizationFiltering">The filtering of the authorization strategies to be combined.</param>
        /// <param name="currentAlias">The alias of the entity in the HQL query to which the filters apply.</param>
        /// <param name="parameterValueByName">The parameter values of the query that will contain the predicate. A parameter
        /// value already present in the query is reused if it's equal, and a distinct parameter name is used if it's not
        /// (several resources can be authorized in the same query, and the query string criteria also use named parameters).</param>
        /// <param name="predicate">The HQL predicate, if any filters were applied.</param>
        /// <returns><b>true</b> if any filters were applied; otherwise <b>false</b>.</returns>
        private bool TryBuildAuthorizationPredicate(
            IReadOnlyList<AuthorizationStrategyFiltering> authorizationFiltering,
            string currentAlias,
            IDictionary<string, object> parameterValueByName,
            out string predicate)
        {
            predicate = null;

            // Create the "AND" junction
            var mainConjunction = new StringBuilder();

            // Create the "OR" junction
            var mainDisjunction = new StringBuilder();
            
            // NOTE: This follows the implementation structure of the repository authorization for the standard data management resources.
            // In a future implementation that is based on SQL and uses joins to the authorization views instead of HQL and sub-selects in
            // WHERE criteria (due to limitations of HQL needing all joins to auth views to be mapped as relationships), we'll want to use
            // the result of this method in forming those joins. Basically, if there are multiple authorization strategies using view-based
            // authorization, we must use left *outer* joins in conjunction with null/not null checks to ensure we are able to correctly
            // implement the OR behavior applied to multiple authorization strategies. 
            // var joinType = DetermineJoinType();
            var unsupportedAuthorizationFilters = GetUnsupportedAuthorizationFilters();

            bool conjunctionFiltersWereApplied = ApplyAuthorizationStrategiesCombinedWithAndLogic();
            bool disjunctionFiltersWereApplied = ApplyAuthorizationStrategiesCombinedWithOrLogic();

            predicate = CombineJunctions();

            return predicate != null;

            HashSet<string> GetUnsupportedAuthorizationFilters()
            {
                var unsupportedFilters = new HashSet<string>(
                    authorizationFiltering.SelectMany(
                        af => af.Filters
                            .Where(
                                afd => !_authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(
                                    afd.FilterName,
                                    out var ignored))
                            .Select(afd => afd.FilterName)));

                return unsupportedFilters;
            }

            bool ApplyAuthorizationStrategiesCombinedWithAndLogic()
            {
                var andStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.And).ToArray();

                // Combine 'AND' strategies
                bool conjunctionFiltersApplied = false;

                foreach (var andStrategy in andStrategies)
                {
                    if (!TryApplyFilters(mainConjunction, andStrategy.Filters))
                    {
                        // All filters for AND strategies must be applied, and if not, this is an error condition
                        throw new Exception($"The following authorization filters are not recognized: {string.Join(" ", unsupportedAuthorizationFilters)}");
                    }

                    conjunctionFiltersApplied = true;
                }

                return conjunctionFiltersApplied;
            }

            bool ApplyAuthorizationStrategiesCombinedWithOrLogic()
            {
                var orStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.Or).ToArray();

                // Combine 'OR' strategies
                bool disjunctionFiltersApplied = false;

                foreach (var orStrategy in orStrategies)
                {
                    var filtersConjunction = new StringBuilder(); // Combine filters with 'AND' within each Or strategy

                    if (TryApplyFilters(filtersConjunction, orStrategy.Filters))
                    {
                        // mainDisjunction.Add(filtersConjunction);
                        mainDisjunction.Append($"{OrIfNeeded(mainDisjunction)} {filtersConjunction}");

                        disjunctionFiltersApplied = true;
                    }
                }

                // If we have some OR strategies with filters defined, but no filters were applied, this is an error condition
                if (orStrategies.SelectMany(s => s.Filters).Any() && !disjunctionFiltersApplied)
                {
                    throw new Exception($"The following authorization filters are not recognized: {string.Join(" ", unsupportedAuthorizationFilters)}");
                }
                
                return disjunctionFiltersApplied;
            }

            bool TryApplyFilters(StringBuilder conjunction, IReadOnlyList<AuthorizationFilterContext> filterContexts)
            {
                bool allFiltersCanBeApplied = true;
                
                foreach (var filterContext in filterContexts)
                {
                    if (!_authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(
                            filterContext.FilterName,
                            out var ignored))
                    {
                        unsupportedAuthorizationFilters.Add(filterContext.FilterName);

                        allFiltersCanBeApplied = false;
                    }
                }

                if (!allFiltersCanBeApplied)
                {
                    return false;
                }

                bool filtersApplied = false;
                
                foreach (var filterContext in filterContexts)
                {
                    _authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(
                        filterContext.FilterName,
                        out var filterApplicationDetails);

                    string filterHqlFormat = filterApplicationDetails.HqlConditionFormatString;

                    if (!string.IsNullOrWhiteSpace(filterHqlFormat))
                    {
                        // Set the current alias for the contextual fields
                        string filterHql = string.Format(filterHqlFormat, currentAlias, filterContext.SubjectEndpointName);

                        string parameterName = filterContext.ClaimParameterName;

                        // Copy over the values of the named parameters, but only if they are actually present in the filter
                        if (filterHql.Contains($":{parameterName}"))
                        {
                            var claimParameterValues = filterContext.ClaimParameterValues;

                            if (claimParameterValues.Length > 1
                                && TryExpandLikeComparison(filterHql, parameterName, claimParameterValues.Length, out string expandedFilterHql))
                            {
                                // LIKE compares with a single value (e.g. a client with several namespace prefixes), so
                                // compare with each value separately
                                filterHql = expandedFilterHql;

                                for (int i = 0; i < claimParameterValues.Length; i++)
                                {
                                    filterHql = SetParameterValue(filterHql, $"{parameterName}_{i + 1}", claimParameterValues[i]);
                                }
                            }
                            else
                            {
                                object parameterValue = claimParameterValues.Length == 1
                                    ? claimParameterValues.Single()
                                    : claimParameterValues;

                                filterHql = SetParameterValue(filterHql, parameterName, parameterValue);
                            }
                        }

                        // Add HQL to the predicate
                        conjunction.Append($"{AndIfNeeded(conjunction)}({filterHql})");
                    }
                    else
                    {
                        // NOTE: The HqlBuilderAuthorizationDecorator's TryIncludeResource method should prevent this code from
                        // ever executing, but for defensive purposes, we'll still catch and throw an exception here to prevent
                        // request processing.
                        throw new SecurityConfigurationException(
                            SecurityConfigurationException.DefaultDetail,
                            $"The '{filterContext.FilterName}' filter has been applied as part of an authorization strategy that does not support Composites requests. Should a different authorization strategy be used?");
                    }

                    filtersApplied = true;
                }
                
                return filtersApplied;
            }

            string CombineJunctions()
            {
                if (disjunctionFiltersWereApplied)
                {
                    if (conjunctionFiltersWereApplied)
                    {
                        // Apply grouped disjunction (OR criteria) to the conjunction (AND criteria) containing other strategies combined using AND
                        mainConjunction.Append($"{AndIfNeeded(mainConjunction)}({mainDisjunction})");

                        return mainConjunction.ToString();
                    }

                    // Grouped disjunction (OR criteria)
                    return $"({mainDisjunction})";
                }

                // When only conjunction filters were applied (AND)
                if (conjunctionFiltersWereApplied)
                {
                    return mainConjunction.ToString();
                }

                return null;
            }

            string SetParameterValue(string filterHql, string parameterName, object parameterValue)
            {
                if (!parameterValueByName.TryGetValue(parameterName, out object existingValue)
                    || ParameterValuesAreEqual(existingValue, parameterValue))
                {
                    parameterValueByName[parameterName] = parameterValue;

                    return filterHql;
                }

                // The query already uses the parameter name with a different value, so use a distinct name
                string distinctParameterName = $"{parameterName}_{currentAlias}";

                for (int i = 2; parameterValueByName.TryGetValue(distinctParameterName, out existingValue)
                         && !ParameterValuesAreEqual(existingValue, parameterValue); i++)
                {
                    distinctParameterName = $"{parameterName}_{currentAlias}_{i}";
                }

                parameterValueByName[distinctParameterName] = parameterValue;

                return Regex.Replace(
                    filterHql,
                    $@":{Regex.Escape(parameterName)}(?!\w)",
                    $":{distinctParameterName}");
            }
        }

        /// <summary>
        /// Rewrites the LIKE comparisons with a named parameter (e.g. <c>x.Namespace LIKE :Namespace</c>) as one comparison
        /// per value, combined with OR, using parameters named <c>{parameterName}_1</c> to <c>{parameterName}_{valueCount}</c>.
        /// </summary>
        /// <returns><b>true</b> if the filter only uses the parameter in LIKE comparisons and was rewritten; otherwise
        /// <b>false</b>.</returns>
        private static bool TryExpandLikeComparison(
            string filterHql,
            string parameterName,
            int valueCount,
            out string expandedFilterHql)
        {
            var likeComparison = new Regex(
                $@"(?<operand>[\w.]+)\s+LIKE\s+:{Regex.Escape(parameterName)}(?!\w)",
                RegexOptions.IgnoreCase);

            expandedFilterHql = likeComparison.Replace(
                filterHql,
                m => "("
                    + string.Join(
                        " OR ",
                        Enumerable.Range(1, valueCount).Select(i => $"{m.Groups["operand"].Value} LIKE :{parameterName}_{i}"))
                    + ")");

            // Only use the rewritten filter if no other usages of the parameter remain
            if (expandedFilterHql == filterHql
                || Regex.IsMatch(expandedFilterHql, $@":{Regex.Escape(parameterName)}(?!\w)"))
            {
                expandedFilterHql = null;
                return false;
            }

            return true;
        }

        private static bool ParameterValuesAreEqual(object value1, object value2)
        {
            if (value1 is not string && value1 is IEnumerable values1
                && value2 is not string && value2 is IEnumerable values2)
            {
                return values1.Cast<object>().SequenceEqual(values2.Cast<object>());
            }

            return Equals(value1, value2);
        }

        private static string AndIfNeeded(StringBuilder where)
        {
            return where.Length > 0
                ? " AND "
                : string.Empty;
        }

        private static string OrIfNeeded(StringBuilder where)
        {
            return where.Length > 0
                ? " OR "
                : string.Empty;
        }
    }
}

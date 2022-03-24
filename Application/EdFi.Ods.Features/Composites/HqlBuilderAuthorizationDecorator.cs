// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using EdFi.Common;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Features.Composites.Infrastructure;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using log4net;

namespace EdFi.Ods.Features.Composites
{
    public class HqlBuilderAuthorizationDecorator : ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>
    {
        private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IAuthorizationFilteringProvider _authorizationFilteringProvider;

        private readonly ConcurrentDictionary<string, Type> _entityTypeByName
            = new ConcurrentDictionary<string, Type>(StringComparer.InvariantCultureIgnoreCase);
        private readonly ICompositeItemBuilder<HqlBuilderContext, CompositeQuery> _next;
        private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;
        private readonly IResourceClaimUriProvider _resourceClaimUriProvider;

        public HqlBuilderAuthorizationDecorator(
            ICompositeItemBuilder<HqlBuilderContext, CompositeQuery> next,
            IAuthorizationFilteringProvider authorizationFilteringProvider,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider,
            IResourceClaimUriProvider resourceClaimUriProvider,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
            IApiKeyContextProvider apiKeyContextProvider)
        {
            _next = Preconditions.ThrowIfNull(next, nameof(next));
            _authorizationFilteringProvider = Preconditions.ThrowIfNull(authorizationFilteringProvider, nameof(authorizationFilteringProvider));
            _authorizationFilterDefinitionProvider = Preconditions.ThrowIfNull(authorizationFilterDefinitionProvider, nameof(authorizationFilterDefinitionProvider));
            _resourceClaimUriProvider = Preconditions.ThrowIfNull(resourceClaimUriProvider, nameof(resourceClaimUriProvider));
            _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
            _apiKeyContextProvider = apiKeyContextProvider;
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

            if (!(resourceClass is Resource))
            {
                throw new InvalidOperationException(
                    $"Unable to evaluate resource '{resourceClass.FullName}' for inclusion in HQL query because it is not the root class of the resource.");
            }

            var resource = (Resource) resourceClass;

            // --------------------------
            //   Determine inclusion
            // --------------------------
            var entityType = GetEntityType(resource);

            var authorizationContext = new EdFiAuthorizationContext(
                _apiKeyContextProvider.GetApiKeyContext(),
                ClaimsPrincipal.Current,
                _resourceClaimUriProvider.GetResourceClaimUris(resource),
                RequestActions.ReadActionUri,
                entityType);

            // Authorize and apply filtering
            IReadOnlyList<AuthorizationStrategyFiltering> authorizationFiltering;

            try
            {
                var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(authorizationContext);
                
                // NOTE: Possible performance optimization - Allow for "Try" semantics (so no exceptions are thrown here)
                authorizationFiltering = _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);
            }
            catch (EdFiSecurityException ex)
            {
                // If this is the base resource, rethrow the exception to achieve a 401 response
                if (processorContext.IsBaseResource())
                {
                    Logger.Debug($"BaseResource: {processorContext.CurrentResourceClass.Name} could not be authorized.");
                    throw;
                }

                // In the case where we have an abstract class and it has no claim, eg EducationOrganization, we will allow
                // the join if the subtype has been included.
                if (processorContext.IsAbstract())
                {
                    Logger.Debug($"Resource {processorContext.CurrentResourceClass.Name} has no claim.");

                    if (processorContext.ShouldIncludeResourceSubtype())
                    {
                        Logger.Debug(
                            $"Resource is abstract and so target resource '{processorContext.CurrentResourceClass.Name}' cannot be authorized. Join will be included, but non-identifying resource members should be stripped from results.");

                        return true;
                    }
                }

                Logger.Debug($"Resource {processorContext.CurrentResourceClass.Name} is excluded from the request.");
                Logger.Debug($"Security Exception Message: {ex.Message}.");

                return false;
            }

            // Save the filters to be applied to this query for use later in the process
            builderContext.CurrentQueryFilterByName = authorizationFiltering
                // Flattens the filters as per legacy code (effectively combining them using "AND" logic), but we still need to implement support for combining multiple authorization strategies correctly
                .SelectMany(x => x.Filters)
                .ToDictionary(x => x.FilterName, x => x);

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

        private Type GetEntityType(ResourceClassBase currentResourceClass)
        {
            var assemblyName = currentResourceClass.IsEdFiStandardResource
                ? Namespaces.Standard.BaseNamespace
                : $"{Namespaces.Extensions.BaseNamespace}.{currentResourceClass.SchemaProperCaseName}";

            return _entityTypeByName.GetOrAdd(
                currentResourceClass.Name,
                r =>
                {
                    string entityTypeAssemblyQualifiedName =
                        $"{currentResourceClass.Entity.EntityTypeFullName(currentResourceClass.SchemaProperCaseName)}, {assemblyName}";

                    Type type = Type.GetType(entityTypeAssemblyQualifiedName);

                    return type;
                });
        }

        private void ApplyFilters(
            CompositeDefinitionProcessorContext processorContext,
            HqlBuilderContext builderContext)
        {
            var entityType = GetEntityType(processorContext.CurrentResourceClass);
            var filters = builderContext.CurrentQueryFilterByName;

            // --------------------------
            //   Add security filtering
            // --------------------------
            if (filters != null && filters.Any())
            {
                foreach (var filterInfo in filters)
                {
                    // Get the filter text
                    string filterName = filterInfo.Key;

                    if (!_authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(filterName, out var filterApplicationDetails))
                    {
                        throw new Exception(
                            $"Unable to apply authorization to query because filter '{filterName}' could not be found.");
                    }

                    string filterHqlFormat = filterApplicationDetails.HqlConditionFormatString;
                    
                    if (string.IsNullOrWhiteSpace(filterHqlFormat))
                    {
                        throw new Exception(
                            $"Unable to apply authorization to query because filter '{filterName}' on entity '{entityType.Name}' was found, but was null or empty.");
                    }

                    // Set the current alias for the contextual fields
                    string filterHql = string.Format(filterHqlFormat, builderContext.CurrentAlias);

                    if (!string.IsNullOrWhiteSpace(filterHql))
                    {
                        // Add HQL to the current resource query's WHERE clause
                        builderContext.Where.AppendFormat(
                            "{0}({1})",
                            AndIfNeeded(builderContext.Where),
                            filterHql);

                        // Copy over the values of the named parameters, but only if they are actually present in the filter
                        var authorizationFilterDetails = filterInfo.Value;

                        string parameterName = authorizationFilterDetails.ClaimParameterName;

                        if (filterHql.Contains($":{parameterName}"))
                        {
                            if (authorizationFilterDetails.ClaimParameterValues.Length == 1)
                            {
                                builderContext.CurrentQueryFilterParameterValueByName[parameterName] =
                                    authorizationFilterDetails.ClaimParameterValues.Single();
                            }
                            else
                            {
                                builderContext.CurrentQueryFilterParameterValueByName[parameterName] =
                                    authorizationFilterDetails.ClaimParameterValues;
                            }
                        }
                    }
                }
            }
        }

        private static string AndIfNeeded(StringBuilder where)
        {
            return where.Length > 0
                ? " AND "
                : string.Empty;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Extensions;
using QuickGraph;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public abstract class RelationshipsAuthorizationStrategyBase<TContextData> : IAuthorizationStrategy
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        private List<ValidationResult> _dependencyValidationResults;

        private readonly Lazy<string> _authorizationStrategyName;

        protected RelationshipsAuthorizationStrategyBase()
        {
            _authorizationStrategyName = new Lazy<string>(
                () =>
                {
                    // Ensure name of class follows conventions
                    if (!this.GetType().Name.TrimAt("`1").TryTrimSuffix("AuthorizationStrategy", out string authorizationStrategyName))
                    {
                        throw new Exception(
                            $"Naming of authorization strategy implementation class '{this.GetType().Name}' did not follow expected convention of using a suffix of 'AuthorizationStrategy'.");
                    }

                    return authorizationStrategyName;
                });
        }

        // Define all required dependencies, injected through property injection for brevity in custom implementations
        [Required]
        public IRelationshipsAuthorizationContextDataProviderFactory<TContextData> RelationshipsAuthorizationContextDataProviderFactory { get; set; }

        [Required]
        public IAuthorizationSegmentsToFiltersConverter AuthorizationSegmentsToFiltersConverter { get; set; }

        [Required]
        public IEducationOrganizationCache EducationOrganizationCache { get; set; }

        [Required]
        public IAuthorizationSegmentsVerifier AuthorizationSegmentsVerifier { get; set; }

        [Required]
        public IEducationOrganizationAuthorizationSegmentsValidator EducationOrganizationAuthorizationSegmentsValidator { get; set; }

        /// <summary>
        /// Applies filtering to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The list of filters to be applied to the query for authorization.</returns>
        public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            EnsurePropertyDependenciesInitialized();

            // Find a generated context data provider for the entity
            var authorizationContextDataProvider = RelationshipsAuthorizationContextDataProviderFactory.GetProvider(authorizationContext.Type ?? authorizationContext.Data.GetType());
            var authorizationContextPropertyNames = authorizationContextDataProvider.GetAuthorizationContextPropertyNames();

            // If present, extract the authorization context data for assembling the segments, with authorization subject's values
            var authorizationContextData = authorizationContext.Data == null 
                ? null 
                : authorizationContextDataProvider.GetContextData(authorizationContext.Data);

            var authorizationSegments = GetAuthorizationSegments(relevantClaims, authorizationContextPropertyNames, authorizationContextData);

            // Convert the segments to general-purpose filters
            var filters = AuthorizationSegmentsToFiltersConverter.Convert(authorizationSegments);

            return new AuthorizationStrategyFiltering
            {
                AuthorizationStrategyName = _authorizationStrategyName.Value,
                Filters = filters,
                Operator = FilterOperator.Or
            };
        }

        private IReadOnlyList<ClaimsAuthorizationSegment> GetAuthorizationSegments(
            IEnumerable<Claim> claims,
            string[] authorizationContextPropertyNames,
            TContextData authorizationContextData)
        {
            var builder = new AuthorizationBuilder<TContextData>(claims, EducationOrganizationCache, authorizationContextData);

            BuildAuthorizationSegments(builder, authorizationContextPropertyNames);

            // Get the rules for execution
            return builder.GetSegments();
        }

        protected abstract void BuildAuthorizationSegments(
            AuthorizationBuilder<TContextData> authorizationBuilder,
            string[] authorizationContextPropertyNames);

        /// <summary>
        /// Verifies all required dependencies have been injected successfully through property injection.
        /// </summary>
        private void EnsurePropertyDependenciesInitialized()
        {
            // Have we already validate the dependencies successfully?
            if (_dependencyValidationResults != null && !_dependencyValidationResults.Any())
            {
                return;
            }

            // Have we not yet validated the dependencies?
            if (_dependencyValidationResults == null)
            {
                // Validate the dependencies
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);
                _dependencyValidationResults = validationResults;
            }

            // Throw an exception if there are any missing dependencies
            if (_dependencyValidationResults.Any())
            {
                string message = string.Format(
                    "The following injected dependencies were not satisfied: {0}{1}",
                    Environment.NewLine, _dependencyValidationResults.GetAllMessages(1));

                throw new Exception(message);
            }
        }
    }
}

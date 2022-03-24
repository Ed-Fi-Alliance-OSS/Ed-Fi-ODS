// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public class SubjectEndpoint
    {
        public SubjectEndpoint((string name, object value) tuple)
        {
            Name = tuple.name;
            Value = tuple.value;
        }
        
        public SubjectEndpoint((string name, object value) tuple, string authorizationPathModifier)
        {
            Name = tuple.name;
            Value = tuple.value;
            AuthorizationPathModifier = authorizationPathModifier;
        }

        public string Name { get; set; }
        public string AuthorizationPathModifier { get; set; }
        public object Value { get; set; }
    }
    
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

            // TODO: GKM - Modify codegen to produce this output directly rather than strongly typed context data
            
            // ---------------------------------------------------------------------
            // Convert the authorization context to tuples
            // ---------------------------------------------------------------------
            IEnumerable<(string name, object value)> authorizationContextTuples;

            if (authorizationContext.Data == null)
            {
                authorizationContextTuples = authorizationContextPropertyNames.Select(n => (n, null as object));
            }
            else
            {
                var authorizationContextData = authorizationContextDataProvider.GetContextData(authorizationContext.Data);
                
                // TODO: GKM - Would need optimization -- preferably would be provided by reimplementing code generated artifacts here
                authorizationContextTuples = authorizationContextPropertyNames.Select(n => (n, (typeof(TContextData)).GetProperty(n).GetValue(authorizationContextData)));
            }
            // ---------------------------------------------------------------------
            
            // // If present, extract the authorization context data for assembling the segments, with authorization subject's values
            // var authorizationContextData = authorizationContext.Data == null 
            //     ? null 
            //     : authorizationContextDataProvider.GetContextData(authorizationContext.Data);

            var authorizationSubjectEndpoints = 
                GetAuthorizationSubjectEndpoints(authorizationContextTuples);

            // Convert the segments to general-purpose filters
            // var filters = 
            //     authorizationSegmentEndpoints.Select(x => new AuthorizationFilterContext
            //     {
            //         ClaimEndpointNames = new []{ "EducationOrganizationId" },
            //         ClaimEndpointValues = authorizationContext.ApiKeyContext.EducationOrganizationIds.Cast<object>().ToArray(),
            //         ClaimParameterName = RelationshipAuthorizationConventions.ClaimsParameterName,
            //         FilterName = 
            //     })

            var filters = authorizationSubjectEndpoints
                // .GroupBy( s => (s.Name, s.AuthorizationPathModifier))
                .Select(subjectEndpoint =>
                    {
                        // Get the name of the filter to use for this segment
                        string filterName = GetAuthorizationFilterName(subjectEndpoint.Name, subjectEndpoint.AuthorizationPathModifier);

                        return new AuthorizationFilterContext
                        {
                            FilterName = filterName,
                            ClaimEndpointNames = new [] { "EducationOrganizationId" },
                            ClaimEndpointValues = authorizationContext.ApiKeyContext.EducationOrganizationIds.Cast<object>().ToArray(),
                            SubjectEndpointName = subjectEndpoint.Name,
                            SubjectEndpointValue = subjectEndpoint.Value,
                            ClaimParameterName = RelationshipAuthorizationConventions.ClaimsParameterName,
                        };
                    })
                .ToArray();

            return new AuthorizationStrategyFiltering
            {
                AuthorizationStrategyName = _authorizationStrategyName.Value,
                Filters = filters,
                Operator = FilterOperator.Or
            };
            
            string GetAuthorizationFilterName(string subjectEndpointName, string authorizationPathModifier)
            {
                // NOTE: If a role-named subject endpoint happens to be used here, logic will be needed to build the filter name without the role name
                // This logic was originally implemented in the private CreateSegment method of the AuthorizationBuilder class, last available in v5.3 
                return _filterNameBySubjectAndPathModifier.GetOrAdd(
                    (subjectEndpointName, authorizationPathModifier),
                    (x) => $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{x.Item1}{x.Item2}");
            }
        }

        private readonly ConcurrentDictionary<(string, string), string> _filterNameBySubjectAndPathModifier = new();

        protected abstract SubjectEndpoint[] GetAuthorizationSubjectEndpoints(
            IEnumerable<(string name, object value)> authorizationContextTuples);

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

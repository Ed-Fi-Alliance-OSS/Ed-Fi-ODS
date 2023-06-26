// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public abstract class RelationshipsAuthorizationStrategyBase<TContextData> : IAuthorizationStrategy
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        private List<ValidationResult> _dependencyValidationResults;

        private readonly Lazy<string> _authorizationStrategyName;

        private readonly DomainModel _domainModel;

        protected RelationshipsAuthorizationStrategyBase(IDomainModelProvider domainModelProvider)
        {
            _domainModel = domainModelProvider.GetDomainModel();

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
            EdFiResourceClaim[] relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            EnsurePropertyDependenciesInitialized();

            // Find a generated context data provider for the entity
            var authorizationContextDataProvider = RelationshipsAuthorizationContextDataProviderFactory.GetProvider(authorizationContext.Type ?? authorizationContext.Data.GetType());
            var authorizationContextPropertyNames = authorizationContextDataProvider.GetAuthorizationContextPropertyNames();

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

                authorizationContextTuples = authorizationContextData.GetAuthorizationContextTuples(
                    authorizationContextPropertyNames.Select(p => (p, GetNonRoleNamedProperty(p))).ToArray());
            }
            // ---------------------------------------------------------------------
            
            var authorizationSubjectEndpoints = GetAuthorizationSubjectEndpoints(authorizationContextTuples);

            var filters = authorizationSubjectEndpoints
                .Select(subjectEndpoint =>
                    {
                        // Get the name of the filter to use for this segment
                        string filterName = GetAuthorizationFilterName(subjectEndpoint.Name, subjectEndpoint.AuthorizationPathModifier);

                        return new AuthorizationFilterContext
                        {
                            FilterName = filterName,
                            ClaimEndpointValues = authorizationContext.ApiClientContext.EducationOrganizationIds.Cast<object>().ToArray(),
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

            string GetNonRoleNamedProperty(string propertyName)
            {
                //Look for the corresponding non - role named property on the model using its DefiningConcreteProperty

                return _nonRoleNamedByRawPropertyName.GetOrAdd(propertyName, x =>
                {
                    var schema = authorizationContext.Type.GetCustomAttribute<SchemaAttribute>(false)?.Schema ??
                                 throw new Exception(
                                     $"The {nameof(SchemaAttribute)} is required for the entity '{authorizationContext.Type.FullName}'.");

                    var expectedEntityFullName = new FullName(schema, authorizationContext.Type.Name);

                    if (!_domainModel.EntityByFullName.TryGetValue(expectedEntityFullName, out var entity))
                    {
                        throw new Exception($"Unable to locate entity '{expectedEntityFullName}' in the model.");
                    }

                    if (!entity.PropertyByName.TryGetValue(x, out var property))
                    {
                        throw new Exception($"Property '{x}' not found in entity '{expectedEntityFullName}'.");
                    }

                    return property.DefiningConcreteProperty.PropertyName;
                });
            }

            string GetAuthorizationFilterName(string subjectEndpointName, string authorizationPathModifier)
            {
                return _filterNameBySubjectAndPathModifier.GetOrAdd(
                    (GetNonRoleNamedProperty(subjectEndpointName), authorizationPathModifier),
                    (x) => $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{x.Item1}{x.Item2}");
            }
        }

        private readonly ConcurrentDictionary<(string, string), string> _filterNameBySubjectAndPathModifier = new();
        private readonly ConcurrentDictionary<string, string> _nonRoleNamedByRawPropertyName = new();

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

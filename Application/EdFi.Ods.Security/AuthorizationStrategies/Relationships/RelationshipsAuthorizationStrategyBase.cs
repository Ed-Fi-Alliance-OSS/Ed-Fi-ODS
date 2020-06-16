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
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Extensions;
using QuickGraph;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    public abstract class RelationshipsAuthorizationStrategyBase<TContextData> : IEdFiAuthorizationStrategy
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        private readonly IConcreteEducationOrganizationIdAuthorizationContextDataTransformer<TContextData>
            _concreteEducationOrganizationIdAuthorizationContextDataTransformer;

        private readonly Lazy<AdjacencyGraph<string, Edge<string>>> _educationOrganizationHierarchy;

        private List<ValidationResult> _dependencyValidationResults;

        protected RelationshipsAuthorizationStrategyBase(
            IConcreteEducationOrganizationIdAuthorizationContextDataTransformer<TContextData> concreteEducationOrganizationIdAuthorizationContextDataTransformer)
        {
            _concreteEducationOrganizationIdAuthorizationContextDataTransformer = concreteEducationOrganizationIdAuthorizationContextDataTransformer;

            _educationOrganizationHierarchy = new Lazy<AdjacencyGraph<string, Edge<string>>>(
                () =>
                    EducationOrganizationHierarchyProvider.GetEducationOrganizationHierarchy());
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
        public IEducationOrganizationHierarchyProvider EducationOrganizationHierarchyProvider { get; set; }

        public async Task AuthorizeSingleItemAsync(IEnumerable<Claim> relevantClaims, EdFiAuthorizationContext authorizationContext,
            CancellationToken cancellationToken)
        {
            EnsureDependencies();

            // Find a generated context data provider for the entity
            var authorizationContextDataProvider =
                RelationshipsAuthorizationContextDataProviderFactory.GetProvider(authorizationContext.Data.GetType());

            var authorizationContextPropertyNames = authorizationContextDataProvider.GetAuthorizationContextPropertyNames();

            // Extract the context data for making the final authorization decision.
            TContextData contextData = authorizationContextDataProvider.GetContextData(authorizationContext.Data);

            // Convert any EducationOrganizationIds into their concrete types
            var concreteContextData =
                _concreteEducationOrganizationIdAuthorizationContextDataTransformer.GetConcreteAuthorizationContextData(contextData);

            var authorizationSegments = GetAuthorizationSegments(relevantClaims, authorizationContextPropertyNames, concreteContextData);

            var multipleSegmentsErrorMessages = new List<string>();

            foreach (var segment in authorizationSegments)
            {
                var isSubjectEndpointReachableFromAnyClaimEndpointsInSegment = false;
                var errorMessages = new List<string>();

                foreach (var name in segment.ClaimsEndpoints.Select(s => s.Name))
                {
                    // NOTE: Embedded convention (trimming Id suffix to get EdOrg type)
                    string claimEducationOrganizationType = name.TrimSuffix("Id");

                    // Get a list of identifiers that are not accessible from the claim's associated EdOrg
                    var graph = _educationOrganizationHierarchy.Value;

                    var inaccessibleIdentifierNames = graph
                        .Vertices
                        .Except(graph.GetDescendantsOrSelf(claimEducationOrganizationType))
                        .Select(edOrgType => edOrgType + "Id") // NOTE: Embedded convention (adding Id suffix to EdOrg type)
                        .ToList();

                    if (inaccessibleIdentifierNames.Any(s => s.Equals(segment.SubjectEndpoint.Name)))
                    {
                        errorMessages.Add($"Authorization denied.  The claims associated with an identifier of '{name}' " +
                            $"cannot be used to authorize a request associated with an identifier of '{segment.SubjectEndpoint.Name}'."); ;
                    }
                    else
                    {
                        isSubjectEndpointReachableFromAnyClaimEndpointsInSegment = true;
                    }
                }

                if (!isSubjectEndpointReachableFromAnyClaimEndpointsInSegment)
                {
                    multipleSegmentsErrorMessages.AddRange(errorMessages);
                }
            }

            // Validate all segments before throwing an exception if one or more segments are invalid. 
            if (multipleSegmentsErrorMessages.Any())
            {
                throw new EdFiSecurityException(string.Join(" ", multipleSegmentsErrorMessages));
            }

            var inlineAuthorizationResults = PerformInlineClaimsAuthorizations();

            // Check for state where no more segments remain to be authorized
            if (!inlineAuthorizationResults.SegmentsStillRequiringAuthorization.Any())
            {
                // If we got to this point and did not perform any inline authorizations, there's nothing that can authorize
                if (!inlineAuthorizationResults.InlineAuthorizationOccurred)
                {
                    // NOTE: It seems like this check and exception could be moved to right after the call to GetAuthorizationSegments,
                    // which would eliminate the need for tracking the InlineAuthorizationOccurred in the inline authorization results.
                    throw new NotSupportedException(
                        "Relationship-based authorization could not be performed on the request because there were no authorization segments defined indicating the resource shouldn't be authorized with a relationship-based strategy.");
                }

                // Inline authorization was performed, was sufficient.
                return;
            }

            // Execute authorization
            await AuthorizationSegmentsVerifier.VerifyAsync(inlineAuthorizationResults.SegmentsStillRequiringAuthorization, cancellationToken);

            InlineAuthorizationResults PerformInlineClaimsAuthorizations()
            {
                // Create a list to store segments that have been locally authorized (because claim and entity values are the same type and are equal)
                var subsequentAuthorizationSegments = new List<ClaimsAuthorizationSegment>();

                bool inlineAuthorizationOccurred = false;

                foreach (var claimsAuthorizationSegment in authorizationSegments)
                {
                    var subjectEndpointWithValue = claimsAuthorizationSegment.SubjectEndpoint as AuthorizationSegmentEndpointWithValue;

                    // This should never happen
                    if (subjectEndpointWithValue == null)
                    {
                        throw new Exception(
                            "The subject endpoint association for a single-item claims authorization check did not have a value available from context.");
                    }

                    // Segment can possibly be authorized here using value if any of the claims are of the same type and value as the target

                    // Find all the claims endpoint (values) on this segment that *could* be used to authorize the segment
                    var inlinableClaimsEndpoints =
                        claimsAuthorizationSegment.ClaimsEndpoints
                            .Where(x => x.Name.EqualsIgnoreCase(subjectEndpointWithValue.Name))
                            .ToList();

                    var nonInlinableClaimsEndpoints =
                        claimsAuthorizationSegment.ClaimsEndpoints
                            .Where(x => !x.Name.EqualsIgnoreCase(subjectEndpointWithValue.Name));

                    //If we found any claim values that *could* authorize the current segment...
                    if (inlinableClaimsEndpoints.Any())
                    {
                        // Do we have any that actually *do* authorize the segment?
                        if (inlinableClaimsEndpoints.Any(x => x.Value.Equals(subjectEndpointWithValue.Value)))
                        {
                            inlineAuthorizationOccurred = true;
                            continue;
                        }

                        // The claims endpoints we checked couldn't authorize this segment.
                        // If there are not any others to check (i.e. using relationships in the database), then we should preemptively fail authorization now.
                        if (!nonInlinableClaimsEndpoints.Any())
                        {
                            throw new EdFiSecurityException(
                                $"Authorization denied.  Access to the requested '{subjectEndpointWithValue.Name}' was denied.");
                        }

                        // We found claim value(s) for inlining the authorization check, but it failed to authorize and should not be retried with the database.
                        // Therefore, create a new authorization segment that excludes these specific claim endpoints to allow the others to be checked through database relationships
                        subsequentAuthorizationSegments.Add(new ClaimsAuthorizationSegment(
                            nonInlinableClaimsEndpoints.ToArray(),
                            claimsAuthorizationSegment.SubjectEndpoint,
                            claimsAuthorizationSegment.AuthorizationPathModifier));
                    }
                    else
                    {
                        //The segment could not be authorized inline, so add it for subsequent authorization
                        subsequentAuthorizationSegments.Add(claimsAuthorizationSegment);
                    }
                }

                // Continue with other rules that are not referencing the same types of values available on the claim (e.g. LEA Id to LEA Id)
                return new InlineAuthorizationResults(subsequentAuthorizationSegments, inlineAuthorizationOccurred);
            }
        }

        private class InlineAuthorizationResults
        {
            public InlineAuthorizationResults(
                IReadOnlyList<ClaimsAuthorizationSegment> segmentsStillRequiringAuthorization,
                bool inlineAuthorizationOccurred)
            {
                InlineAuthorizationOccurred = inlineAuthorizationOccurred;
                SegmentsStillRequiringAuthorization = segmentsStillRequiringAuthorization;
            }

            /// <summary>
            /// Indicates whether any authorizations were able to be performed inline.
            /// </summary>
            public bool InlineAuthorizationOccurred { get; }

            /// <summary>
            /// Gets the authorization segments that were not able to be authorized inline and still need to be authorized.
            /// </summary>
            public IReadOnlyList<ClaimsAuthorizationSegment> SegmentsStillRequiringAuthorization { get; }
        }

        /// <summary>
        /// Applies filtering to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The list of filters to be applied to the query for authorization.</returns>
        public IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            EnsureDependencies();

            // Find a generated context data provider for the entity
            var authorizationContextDataProvider = RelationshipsAuthorizationContextDataProviderFactory.GetProvider(authorizationContext.Type);
            var authorizationContextPropertyNames = authorizationContextDataProvider.GetAuthorizationContextPropertyNames();

            var authorizationSegments = GetAuthorizationSegments(relevantClaims, authorizationContextPropertyNames, null);

            // Convert segments to general-purpose filters
            return AuthorizationSegmentsToFiltersConverter.Convert(authorizationSegments);
        }

        private IReadOnlyList<ClaimsAuthorizationSegment> GetAuthorizationSegments(
            IEnumerable<Claim> claims,
            string[] signatureProperties,
            TContextData authorizationContextData)
        {
            var builder = new AuthorizationBuilder<TContextData>(claims, EducationOrganizationCache, authorizationContextData);

            BuildAuthorizationSegments(builder, signatureProperties);

            // Get the rules for execution
            return builder.GetSegments();
        }

        protected abstract void BuildAuthorizationSegments(
            AuthorizationBuilder<TContextData> authorizationBuilder,
            string[] authorizationContextPropertyNames);

        /// <summary>
        /// Verifies all required dependencies have been injected successfully through property injection.
        /// </summary>
        private void EnsureDependencies()
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
                    "The following injected dependencies were not satisfied: \r\n{0}",
                    _dependencyValidationResults.GetAllMessages(1));

                throw new Exception(message);
            }
        }
    }
}

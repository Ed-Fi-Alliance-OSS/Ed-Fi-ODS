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

            // Find the signature authorization provider and authorize
            Type entityType = authorizationContext.Type;

            var authorizationSegments = GetAuthorizationSegments(relevantClaims, entityType, authorizationContextPropertyNames, concreteContextData);

            var multipleSegmentsErrorMessages = new List<string>();

            foreach (var segment in authorizationSegments)
            {
                var isTargetEndpointReachableFromAnyClaimEndpointsInSegment = false;
                var errorMessages = new List<string>();

                foreach (var name in segment.ClaimsEndpoints.Select(s => s.Name))
                {
                    // TODO: Embedded convention (trimming Id suffix to get EdOrg type)
                    string claimEducationOrganizationType = name.TrimSuffix("Id");

                    // Get a list of identifiers that are not accessible from the claim's associated EdOrg
                    var graph = _educationOrganizationHierarchy.Value;

                    var inaccessibleIdentifierNames = graph
                        .Vertices
                        .Except(graph.GetDescendantsOrSelf(claimEducationOrganizationType))
                        .Select(edOrgType => edOrgType + "Id") // TODO: Embedded convention (adding Id suffix to EdOrg type)
                        .ToList();

                    if (inaccessibleIdentifierNames.Any(s => s.Equals(segment.TargetEndpoint.Name)))
                    {
                        errorMessages.Add($"Authorization denied.  The claims associated with an identifier of '{name}' " +
                            $"cannot be used to authorize a request associated with an identifier of '{segment.TargetEndpoint.Name}'."); ;
                    }
                    else
                    {
                        isTargetEndpointReachableFromAnyClaimEndpointsInSegment = true;
                    }
                }

                if (!isTargetEndpointReachableFromAnyClaimEndpointsInSegment)
                {
                    multipleSegmentsErrorMessages.AddRange(errorMessages);
                }
            }

            //Validate all segments before throwing an exception if one or more segments are invalid. 
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
                    var targetEndpointWithValue = claimsAuthorizationSegment.TargetEndpoint as AuthorizationSegmentEndpointWithValue;

                    // This should never happen
                    if (targetEndpointWithValue == null)
                    {
                        throw new Exception(
                            "The target endpoint association for a single-item claims authorization check did not have a value available from context.");
                    }

                    // Segment can possibly be authorized here using value if any of the claims are of the same type and value as the target

                    // Find all the claims endpoint (values) on this segment that *could* be used to authorize the segment
                    var inlinableClaimsEndpoints =
                        claimsAuthorizationSegment.ClaimsEndpoints
                            .Where(x => x.Name.EqualsIgnoreCase(targetEndpointWithValue.Name))
                            .ToList();

                    var nonInlinableClaimsEndpoints =
                        claimsAuthorizationSegment.ClaimsEndpoints
                            .Where(x => !x.Name.EqualsIgnoreCase(targetEndpointWithValue.Name));

                    //If we found any claim values that *could* authorize the current segment...
                    if (inlinableClaimsEndpoints.Any())
                    {
                        // Do we have any that actually *do* authorize the segment?
                        if (inlinableClaimsEndpoints.Any(x => x.Value.Equals(targetEndpointWithValue.Value)))
                        {
                            inlineAuthorizationOccurred = true;
                            continue;
                        }

                        // The claims endpoints we checked couldn't authorize this segment.
                        // If there are not any others to check (i.e. using relationships in the database), then we should preemptively fail authorization now.
                        if (!nonInlinableClaimsEndpoints.Any())
                        {
                            throw new EdFiSecurityException(
                                $"Authorization denied.  Access to the requested '{targetEndpointWithValue.Name}' was denied.");
                        }

                        // We found claim value(s) for inlining the authorization check, but it failed to authorize and should not be retried with the database.
                        // Therefore, create a new authorization segment that excludes these specific claim endpoints to allow the others to be checked through database relationships
                        subsequentAuthorizationSegments.Add(new ClaimsAuthorizationSegment(
                            nonInlinableClaimsEndpoints.ToArray(),
                            claimsAuthorizationSegment.TargetEndpoint,
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
        /// <param name="filterBuilder">A builder used to activate filters and assign parameter values.</param>
        /// <returns>The dictionary containing the filter information as appropriate, or <b>null</b> if no filters are required.</returns>
        public void ApplyAuthorizationFilters(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext,
            ParameterizedFilterBuilder filterBuilder)
        {
            EnsureDependencies();

            // Find a generated context data provider for the entity
            var authorizationContextDataProvider = RelationshipsAuthorizationContextDataProviderFactory.GetProvider(authorizationContext.Type);
            var authorizationContextPropertyNames = authorizationContextDataProvider.GetAuthorizationContextPropertyNames();

            Type entityType = authorizationContext.Type;

            var authorizationSegments = GetAuthorizationSegments(relevantClaims, entityType, authorizationContextPropertyNames, null);

            // Ensure that there is only a single type of EdOrg identifier in the endpoints
            EnsureSingleTypeOfIdentifierInSegments(authorizationSegments);

            // Convert segments to general-purpose filters
            AuthorizationSegmentsToFiltersConverter.Convert(entityType, authorizationSegments, filterBuilder);
        }

        private IReadOnlyList<ClaimsAuthorizationSegment> GetAuthorizationSegments(
            IEnumerable<Claim> claims,
            Type entityType,
            string[] signatureProperties,
            TContextData authorizationContextData)
        {
            var builder = new AuthorizationBuilder<TContextData>(claims, EducationOrganizationCache, authorizationContextData);

            BuildAuthorizationSegments(builder, entityType, signatureProperties);

            // Get the rules for execution
            return builder.GetSegments();
        }

        private static void EnsureSingleTypeOfIdentifierInSegments(
            IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments)
        {
            // Simply ignore the return value for this usage
            GetSingleEducationOrganizationIdentifierNameFromClaimsSegments(authorizationSegments);
        }

        private static string GetSingleEducationOrganizationIdentifierNameFromClaimsSegments(
            IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments)
        {
            // Look through all the claims-based segments for different EdOrg types...
            var claimsSegmentsGroupedByName =
                (from cs in authorizationSegments
                 from cv in cs.ClaimsEndpoints
                 group cs by cv.Name
                 into g
                 select g)
               .ToList();

            // Note: For single item requests, multiple types of EdOrgs may be supported by the code, but has not been tested.
            // As of the time of this writing, filtering on multiple EdOrg types is not supported (due to limitations with 
            // NHibernate filters only being capable of being combined using ANDs), so we're being proactive here to maintain
            // a consistent behavior across the 2 use cases.  However, it would not be unfeasible to support multiple types for 
            // single-item requests.
            if (claimsSegmentsGroupedByName.Count() > 1)
            {
                throw new NotSupportedException(
                    string.Format(
                        "Relationship-based authorization does not support claims with multiple types of values (e.g. claims associated with multiple types of education organizations).  The claim types found were '{0}'.",
                        string.Join("', '", claimsSegmentsGroupedByName.Select(x => x.Key))));
            }

            // This should never happen.
            if (!claimsSegmentsGroupedByName.Any())
            {
                throw new Exception(
                    "There were no claims authorization segment endpoint names available for authorization.  Check the issued claims for a lack of education organization values, and the signature authorization implementation for a lack of 'ClaimsMustBeAssociatedWith' calls on the AuthorizationBuilder.");
            }

            // Get the one education organization type in the claims
            string claimEducationOrganizationIdentifierName = claimsSegmentsGroupedByName
                                                             .Select(x => x.Key)
                                                             .SingleOrDefault();

            return claimEducationOrganizationIdentifierName;
        }

        protected abstract void BuildAuthorizationSegments(
            AuthorizationBuilder<TContextData> authorizationBuilder,
            Type entityType,
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

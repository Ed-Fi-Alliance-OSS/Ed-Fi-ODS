// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Extensions;
using EdFi.Ods.Common.Security.Authorization;
using QuickGraph;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public class EducationOrganizationAuthorizationSegmentsValidator : IEducationOrganizationAuthorizationSegmentsValidator
    {
        private readonly Lazy<AdjacencyGraph<string, Edge<string>>> _educationOrganizationIdHierarchy;

        private readonly ConcurrentDictionary<string, string[]> _inaccessibleIdentifierNameByClaimEndpointName =
            new ConcurrentDictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);

        public EducationOrganizationAuthorizationSegmentsValidator(IEducationOrganizationIdHierarchyProvider educationOrganizationIdHierarchyProvider)
        {
            _educationOrganizationIdHierarchy = new Lazy<AdjacencyGraph<string, Edge<string>>>(
                educationOrganizationIdHierarchyProvider.GetEducationOrganizationIdHierarchy);
        }
        
        public IReadOnlyList<string> ValidateAuthorizationSegments(
            IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments)
        {
            var allMessages = new List<string>();

            foreach (var segment in authorizationSegments)
            {
                var isSubjectEndpointReachableFromAnyClaimEndpointsInSegment = false;
                var segmentMessages = new List<string>();

                foreach (var claimEndpointName in segment.ClaimsEndpoints.Select(s => s.Name).Distinct())
                {
                    // Get a list of identifiers that are not accessible from the claim's associated EdOrg
                    var graph = _educationOrganizationIdHierarchy.Value;

                    var inaccessibleIdentifierNames = _inaccessibleIdentifierNameByClaimEndpointName.GetOrAdd(claimEndpointName,
                        (n) => graph.Vertices.Except(graph.GetDescendantsOrSelf(n)).ToArray());

                    if (inaccessibleIdentifierNames.Contains(segment.SubjectEndpoint.Name))
                    {
                        segmentMessages.Add(
                            $"The claims associated with an identifier of '{claimEndpointName}' "
                            + $"cannot be used to authorize a request associated with an identifier of '{segment.SubjectEndpoint.Name}'.");
                    }
                    else
                    {
                        // This segment is authorizable with the current claim endpoint
                        isSubjectEndpointReachableFromAnyClaimEndpointsInSegment = true;
                        break;
                    }
                }

                // Only add messages if the segment cannot be authorized with current claims
                if (!isSubjectEndpointReachableFromAnyClaimEndpointsInSegment)
                {
                    allMessages.AddRange(segmentMessages);
                }
            }

            return allMessages;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public interface IAuthorizationSegmentsToFiltersConverter
    {
        IReadOnlyList<AuthorizationFilterDetails> Convert(IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments);
    }

    public class AuthorizationSegmentsToFiltersConverter : IAuthorizationSegmentsToFiltersConverter
    {
        public IReadOnlyList<AuthorizationFilterDetails> Convert(IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments)
        {
            if (!authorizationSegments.Any())
            {
                return Array.Empty<AuthorizationFilterDetails>();
            }

            var filterByName = new Dictionary<string, AuthorizationFilterDetails>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var segment in authorizationSegments)
            {
                var subjectEndpointName = segment.SubjectEndpoint.Name;

                var segmentFilters = segment
                    .ClaimsEndpoints
                    .GroupBy(x => x.Name)
                    .Select(g =>
                    {
                        string claimEndpointName = g.Key;

                        // Get the name of the view to use for this segment
                        string filterName = GetAuthorizationFilterName(subjectEndpointName, segment.AuthorizationPathModifier);

                        return new AuthorizationFilterDetails
                        {
                            FilterName = filterName,
                            ClaimEndpointName = claimEndpointName,
                            ClaimValues = g.Select(x => x.Value).Distinct().ToArray(),
                            SubjectEndpointName = subjectEndpointName,
                        };
                    });

                foreach (var segmentFilter in segmentFilters)
                {
                    if (!filterByName.ContainsKey(segmentFilter.FilterName))
                    {
                        filterByName[segmentFilter.FilterName] = segmentFilter;
                    }
                }
            }

            return filterByName.Values.ToArray();
            
            string GetAuthorizationFilterName(string subjectEndpointName, string authorizationPathModifier)
            {
                return $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{subjectEndpointName}{authorizationPathModifier}";
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public interface IAuthorizationSegmentsToFiltersConverter
    {
        IReadOnlyList<AuthorizationFilterContext> Convert(IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments);
    }

    public class AuthorizationSegmentsToFiltersConverter : IAuthorizationSegmentsToFiltersConverter
    {
        private readonly ConcurrentDictionary<(string, string), string> _filterNameBySubjectAndPathModifier = new();
        
        public IReadOnlyList<AuthorizationFilterContext> Convert(IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments)
        {
            if (!authorizationSegments.Any())
            {
                return Array.Empty<AuthorizationFilterContext>();
            }

            var authorizationFilterDetails = authorizationSegments
                .GroupBy( s => (s.SubjectEndpoint.Name, s.AuthorizationPathModifier))
                .Select(
                    g =>
                    {
                        var (subjectEndpointName, authorizationPathModifier) = g.Key;

                        // Get the name of the filter to use for this segment
                        string filterName = GetAuthorizationFilterName(subjectEndpointName, authorizationPathModifier);

                        return new AuthorizationFilterContext
                        {
                            FilterName = filterName,
                            ClaimParameterName = RelationshipAuthorizationConventions.ClaimsParameterName,
                            ClaimParameterValues = g.SelectMany(cs => cs.ClaimsEndpoints.Select(asv => asv.Value)).Distinct().ToArray(),
                            SubjectEndpointName = subjectEndpointName,
                            SubjectEndpointValue = g.Select(cs => cs.SubjectEndpoint).FirstOrDefault() is AuthorizationSegmentEndpointWithValue endpointWithValue ? endpointWithValue.Value : null,
                            ClaimEndpointNames = g.SelectMany(cs => cs.ClaimsEndpoints.Select(asv => asv.Name)).ToArray(),
                        };
                    })
                .ToArray();

            return authorizationFilterDetails; 
            
            string GetAuthorizationFilterName(string subjectEndpointName, string authorizationPathModifier)
            {
                return _filterNameBySubjectAndPathModifier.GetOrAdd(
                    (subjectEndpointName, authorizationPathModifier),
                    (x) => $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{x.Item1}{x.Item2}");
            }
        }
    }
}

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

            var authorizationFilterDetails = authorizationSegments.GroupBy(s => (s.SubjectEndpoint.Name, s.AuthorizationPathModifier))
                .Select(
                    g =>
                    {
                        var (subjectEndpointName, authorizationPathModifier) = g.Key;

                        // Get the name of the filter to use for this segment
                        string filterName = GetAuthorizationFilterName(subjectEndpointName, authorizationPathModifier);

                        return new AuthorizationFilterDetails
                        {
                            FilterName = filterName,
                            ClaimParameterName = RelationshipAuthorizationConventions.ClaimsParameterName,
                            ClaimParameterValues = g.SelectMany(cs => cs.ClaimsEndpoints.Select(asv => asv.Value)).Distinct().ToArray(),
                            SubjectEndpointName = subjectEndpointName,
                            ClaimEndpointNames = g.SelectMany(cs => cs.ClaimsEndpoints.Select(asv => asv.Name)).ToArray(),
                        };
                    })
                .ToArray();

            return authorizationFilterDetails; 
            
            string GetAuthorizationFilterName(string subjectEndpointName, string authorizationPathModifier)
            {
                return $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{subjectEndpointName}{authorizationPathModifier}";
            }
        }
    }
}

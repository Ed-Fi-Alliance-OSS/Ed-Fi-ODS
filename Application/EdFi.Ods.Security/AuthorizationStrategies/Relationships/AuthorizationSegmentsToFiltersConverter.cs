// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Security.Authorization;
using NHibernate;
using NHibernate.Metadata;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
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
                return new AuthorizationFilterDetails[0];
            }

            var filterByName = new Dictionary<string, AuthorizationFilterDetails>();

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
                        string filterName = ViewNameHelper.GetAuthorizationViewName(
                            subjectEndpointName,
                            claimEndpointName,
                            segment.AuthorizationPathModifier);

                        return new AuthorizationFilterDetails
                        {
                            FilterName = filterName,
                            SubjectEndpointName = subjectEndpointName,
                            ClaimEndpointName = claimEndpointName,
                            ClaimValues = g.Select(x => x.Value).Distinct().ToArray(),
                        };
                    });

                foreach (var segmentFilter in segmentFilters)
                {
                    if (!filterByName.TryGetValue(segmentFilter.FilterName, out AuthorizationFilterDetails filter))
                    {
                        filterByName[segmentFilter.FilterName] = segmentFilter;
                    }
                }
            }

            return filterByName.Values.ToArray();
        }
    }
}

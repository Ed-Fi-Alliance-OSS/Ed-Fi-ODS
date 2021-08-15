// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Represents an authorization segment involving claims on one side and an endpoint that must be related to at least one of the claims.
    /// </summary>
    public class ClaimsAuthorizationSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimsAuthorizationSegment"/> class using the supplied claim values and target endpoint.
        /// </summary>
        /// <param name="claimNamesAndValues">The claim names and values, represented as a collection of tuples.</param>
        /// <param name="subjectEndpoint"></param>
        public ClaimsAuthorizationSegment(IEnumerable<Tuple<string, object>> claimNamesAndValues,
            AuthorizationSegmentEndpoint subjectEndpoint)
            : this(claimNamesAndValues, subjectEndpoint, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimsAuthorizationSegment"/> class using the supplied claim values and target endpoint.
        /// </summary>
        /// <param name="claimNamesAndValues">The claim names and values, represented as a collection of tuples.</param>
        /// <param name="subjectEndpoint">The endpoint representing the subject of authorization.</param>
        /// <param name="authorizationPathModifier">A value that identifies an alternative path through the ODS data model for authorization.</param>
        public ClaimsAuthorizationSegment(
            IEnumerable<Tuple<string, object>> claimNamesAndValues,
            AuthorizationSegmentEndpoint subjectEndpoint,
            string authorizationPathModifier)
        {
            var entities = new List<string>()
            {
                "ThroughEdOrgAssociation",
                "ParentUSI",
                "StaffUSI"
            };

            // When subject Endpoint ends with StudentUSI and also not ends with ThroughEdOrgAssociation
            // use new Student view 
            if (subjectEndpoint.Name.EqualsIgnoreCase("StudentUSI"))

            {
                ClaimsEndpoints = claimNamesAndValues
                    .Select(
                        cv =>
                            new AuthorizationSegmentEndpointWithValue(
                                "EducationOrganizationId",
                                cv.Item2.GetType(),
                                cv.Item2))
                    .ToList()
                    .AsReadOnly();
            }

            // When subject Endpoint does not have ParentUSI or StaffUSI or  ThroughEdOrgAssociation
            // Then use tuple table for authorization 
            else if (!entities.Contains(subjectEndpoint.Name))
            {
                ClaimsEndpoints = claimNamesAndValues
                    .Select(
                        cv =>
                            new AuthorizationSegmentEndpointWithValue(
                                "EducationOrganizationId",
                                cv.Item2.GetType(),
                                cv.Item2))
                    .ToList()
                    .AsReadOnly();

                subjectEndpoint.Name = "EducationOrganizationId";
            }
            else
            {
                ClaimsEndpoints = claimNamesAndValues
                    .Select(
                        cv =>
                            new AuthorizationSegmentEndpointWithValue(
                                cv.Item1,
                                cv.Item2.GetType(),
                                cv.Item2))
                    .ToList()
                    .AsReadOnly();
            }

            SubjectEndpoint = subjectEndpoint;
            AuthorizationPathModifier = authorizationPathModifier;
        }

        public ClaimsAuthorizationSegment(
            IReadOnlyList<AuthorizationSegmentEndpointWithValue> claimsEndpoints,
            AuthorizationSegmentEndpoint subjectEndpoint,
            string authorizationPathModifier)
        {
            ClaimsEndpoints = claimsEndpoints;
            SubjectEndpoint = subjectEndpoint;
            AuthorizationPathModifier = authorizationPathModifier;
        }

        /// <summary>
        /// Gets the collection of claim endpoints (with values), one of which must be associated with the <see cref="SubjectEndpoint"/>.
        /// </summary>
        public IReadOnlyList<AuthorizationSegmentEndpointWithValue> ClaimsEndpoints { get; }

        /// <summary>
        /// Gets the endpoint for the subject of authorization.
        /// </summary>
        public AuthorizationSegmentEndpoint SubjectEndpoint { get; }

        /// <summary>
        /// Gets a value that identifies an alternative path through the ODS data model for authorization.
        /// </summary>
        /// <remarks>By convention, this value will be used as a suffix on the database view used for authorization, enabling alternative paths for authorization.</remarks>
        public string AuthorizationPathModifier { get; }

        /// <summary>
        /// Returns a text representation of the claims authorization segment.
        /// </summary>
        /// <returns>A representation of the claims authorization segment.</returns>
        public override string ToString()
        {
            string claimEndpointNames = string.Join(", ", ClaimsEndpoints.Select(x => x.ToString()));

            return $"Claims: {claimEndpointNames} to {SubjectEndpoint}";
        }
    }
}

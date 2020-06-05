// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Represents an authorization segment involving two arbitrary endpoints that must be related to eachother.
    /// </summary>
    public class ExistingValuesAuthorizationSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingValuesAuthorizationSegment"/> class using the supplied endpoints.
        /// </summary>
        /// <param name="endpoint1">One of the endpoints of the segment.</param>
        /// <param name="endpoint2">Another endpoint in the segment.</param>
        public ExistingValuesAuthorizationSegment(
            AuthorizationSegmentEndpoint endpoint1,
            AuthorizationSegmentEndpoint endpoint2)
            : this(endpoint1, endpoint2, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingValuesAuthorizationSegment"/> class using the supplied endpoints.
        /// </summary>
        /// <param name="endpoint1">One of the endpoints of the segment.</param>
        /// <param name="endpoint2">Another endpoint in the segment.</param>
        /// <param name="authorizationPathModifier">A value that identifies an alternative path through the ODS data model for authorization.</param>
        public ExistingValuesAuthorizationSegment(
            AuthorizationSegmentEndpoint endpoint1,
            AuthorizationSegmentEndpoint endpoint2,
            string authorizationPathModifier)
        {
            Endpoints = new List<AuthorizationSegmentEndpoint>
                        {
                            endpoint1, endpoint2
                        }
               .AsReadOnly();

            AuthorizationPathModifier = authorizationPathModifier;
        }

        /// <summary>
        /// Gets the endpoints for the authorization segment.
        /// </summary>
        public IReadOnlyList<AuthorizationSegmentEndpoint> Endpoints { get; }

        /// <summary>
        /// Gets a value that identifies an alternative path through the ODS data model for authorization.
        /// </summary>
        /// <remarks>By convention, this value will be used as a suffix on the database view used for authorization, enabling alternative paths for authorization.</remarks>
        public string AuthorizationPathModifier { get; }

        /// <summary>
        /// Returns a text representation of the existing values segment.
        /// </summary>
        /// <returns>A representation of the existing values segment.</returns>
        public override string ToString()
        {
            return string.Format(
                "Existing Values: {0}",
                string.Join(" and ", Endpoints.Select(x => x.ToString())));
        }
    }
}

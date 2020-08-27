// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Represents an authorization segment endpoint without a value.
    /// </summary>
    public class AuthorizationSegmentEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationSegmentEndpoint"/> class using the specified name, type and value.
        /// </summary>
        /// <param name="name">The name of the rule value (e.g. a property name from the <see cref="EdFiAuthorizationContextData"/>).</param>
        /// <param name="type">The <see cref="Type"/> of the rule value.</param>
        public AuthorizationSegmentEndpoint(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Gets the name of the rule value (e.g. a property name from the <see cref="EdFiRelationshipsAuthorizationContextData"/>).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the <see cref="Type"/> of the rule value.
        /// </summary>
        public Type Type { get; } // TODO: GKM 3/19 - This may not be needed.

        /// <summary>
        /// Returns the <see cref="Name"/> of the segment endpoint.
        /// </summary>
        /// <returns>The endpoint's name.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}

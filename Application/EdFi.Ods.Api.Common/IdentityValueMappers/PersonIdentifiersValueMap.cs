// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Common.IdentityValueMappers
{
    /// <summary>
    /// Holds values of the various identifiers used to identify a person.
    /// </summary>
    public class PersonIdentifiersValueMap
    {
        /// <summary>
        /// An ODS-specific surrogate identifier for a specific representation of 
        /// a person (e.g. Staff, Student or Parent).
        /// </summary>
        public int Usi { get; set; }

        /// <summary>
        /// The resource identifier for the person.
        /// </summary>
        /// <remarks>
        /// This value is used primarily by the REST API to provide access
        /// to resources without requiring a full composite primary key-based query.
        /// 
        /// Depending on the system implementation, this value may uniquely identify 
        /// a person or just a specific representation of a person (as a Staff, 
        /// Student or Parent).
        /// </remarks>
        public Guid Id { get; set; }

        /// <summary>
        /// The character-based unique identifier for the person.
        /// </summary>
        /// <remarks>
        /// This value is used to identify a person using an externally defined 
        /// non-integer based identifier.
        /// 
        /// Depending on the system implementation, this value may uniquely identify 
        /// a person or just a specific representation of a person (as a Staff, 
        /// Student or Parent).
        /// </remarks>
        public string UniqueId { get; set; }
    }
}

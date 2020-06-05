// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.IdentityValueMappers
{
    public class PersonIdentificationCodesValueMap
    {
        /// <summary>
        /// Gets the person's descriptor Uri for the system.
        /// </summary>
        public string IdentificationSystemDescriptorUri { get; set; }

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
        public string IdentificationCode { get; set; }

        /// <summary>
        /// Gets the assigning organization's code value.
        /// </summary>
        public string AssigningOrganizationIdentificationCode { get; set; }

        /// <summary>
        /// The associated education organization id
        /// </summary>
        public string EducationOrganizationId { get; set; }
    }
}

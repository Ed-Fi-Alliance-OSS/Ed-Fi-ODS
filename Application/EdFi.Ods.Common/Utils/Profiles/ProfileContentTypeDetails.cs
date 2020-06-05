// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Utils.Profiles
{
    /// <summary>
    /// Defines the component parts of an Ed-Fi profile content type name.
    /// </summary>
    public class ProfileContentTypeDetails
    {
        /// <summary>
        /// Gets or sets the name identifying the implementation of Ed-Fi.
        /// </summary>
        public string Implementation { get; set; }

        /// <summary>
        /// Gets or sets the name of the API resource (singular form).
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets the name of the profile.
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Gets or sets the usage of the content type with the API (for reading or writing).
        /// </summary>
        public ContentTypeUsage Usage { get; set; }
    }
}

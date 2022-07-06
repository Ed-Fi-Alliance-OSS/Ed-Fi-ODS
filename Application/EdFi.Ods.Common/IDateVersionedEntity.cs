// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines properties associated with date-based versioning or metadata.
    /// </summary>
    public interface IDateVersionedEntity
    {
        /// <summary>
        /// Gets or sets the last modified date associated with the implementer.
        /// </summary>
        /// <remarks>This value is used to implement ETag support in the API, as well as to expose the
        /// last modified date of each resource item as metadata in the responses.</remarks>
        DateTime LastModifiedDate { get; set; }
    }
}

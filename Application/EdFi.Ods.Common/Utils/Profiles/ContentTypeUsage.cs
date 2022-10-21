// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Utils.Profiles
{
    /// <summary>
    /// Defines how a content type is used with the Ed-Fi API.
    /// </summary>
    public enum ContentTypeUsage
    {
        /// <summary>
        /// Indicates that the content type is to be used for reading data.
        /// </summary>
        Readable = 1,
        /// <summary>
        /// Indicates that the content type is to be used for writing data.
        /// </summary>
        Writable
    }
}

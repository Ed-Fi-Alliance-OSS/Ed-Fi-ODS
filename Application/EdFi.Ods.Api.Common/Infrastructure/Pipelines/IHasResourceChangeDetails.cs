// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines
{
    /// <summary>
    /// Defines properties that indicate the result of an operation on a persistent resource.
    /// </summary>
    public interface IHasResourceChangeDetails
    {
        /// <summary>
        /// Indicates whether the operation resulted in the creation of a new resource.
        /// </summary>
        bool ResourceWasCreated { get; set; }

        /// <summary>
        /// Indicates whether the operation resulted in the update of an existing resource.
        /// </summary>
        bool ResourceWasUpdated { get; set; }

        /// <summary>
        /// Indicates whether the operation resulted in the deletion of an existing resource.
        /// </summary>
        bool ResourceWasDeleted { get; set; }
    }
}

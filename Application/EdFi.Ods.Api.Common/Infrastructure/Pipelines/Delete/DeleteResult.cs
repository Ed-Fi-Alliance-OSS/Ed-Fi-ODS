// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Delete
{
    public class DeleteResult : PipelineResultBase, IHasResourceChangeDetails
    {
        /// <summary>
        /// Indicates whether the operation resulted in the creation of a new resource.
        /// </summary>
        public bool ResourceWasCreated { get; set; }

        /// <summary>
        /// Indicates whether the operation resulted in the update of an existing resource.
        /// </summary>
        public bool ResourceWasUpdated { get; set; }

        /// <summary>
        /// Indicates whether the operation resulted in the deletion of an existing resource.
        /// </summary>
        public bool ResourceWasDeleted { get; set; }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines
{
    public abstract class PipelineResultBase
    {
        /// <summary>
        /// Gets or sets the exception that occurred during pipeline processing.
        /// </summary>
        public Exception Exception { get; set; }

        public ResultMetadata ResultMetadata { get; set; }
    }
}

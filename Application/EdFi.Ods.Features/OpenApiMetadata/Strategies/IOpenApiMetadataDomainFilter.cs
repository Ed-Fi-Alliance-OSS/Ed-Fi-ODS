// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies
{
    /// <summary>
    /// Provides domain-based filtering logic for OpenAPI metadata components.
    /// </summary>
    public interface IOpenApiMetadataDomainFilter
    {
        /// <summary>
        /// Determines if an entity should be excluded based on its domains.
        /// Returns true if the entity should be excluded from OpenAPI metadata.
        /// </summary>
        /// <param name="entity">The entity to check for exclusion.</param>
        /// <returns>True if the entity should be excluded; otherwise, false.</returns>
        bool ShouldExcludeByDomain(Entity entity);
    }
}

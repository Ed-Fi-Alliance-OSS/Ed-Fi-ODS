// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models;

/// <summary>
/// Defines a method for obtaining a mapping contract appropriate for a resource/entity in the current context that indicates
/// what should be mapped/synchronized between entities/resources.
/// </summary>
public interface IMappingContractProvider : IClearable
{
    /// <summary>
    /// Gets a mapping contract appropriate for a resource/entity in the current context.
    /// </summary>
    /// <param name="resourceClassName">The <see cref="FullName" /> of the resource/entity class.</param>
    /// <returns>The mapping contract appropriate for the current context.</returns>
    IMappingContract GetMappingContract(FullName resourceClassName);
}

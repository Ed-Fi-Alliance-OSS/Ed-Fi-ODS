// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Providers.Queries;

/// <summary>
/// Provides an interface for retrieving the properties of the identificationCode for an entity
/// </summary>
public interface IEntityIdentificationCodeQueryablePropertiesProvider
{
    /// <summary>
    /// Attempts to get the queryable properties of an entity's identificationCode.
    /// </summary>
    /// <param name="entity">The entity to try and get the identificationCode properties for.</param>
    /// <param name="identificationCodePropertiesByParameterName">A dictionary with the identificationCode properties of the <paramref name="entity"/> by query parameter name.</param>
    /// <returns><c>true</c> if the entity has an identificationCode with any queryable properties.</returns>
    public bool TryGetIdentificationCodePropertiesByParameterName(Entity entity, out Dictionary<string, EntityProperty> identificationCodePropertiesByParameterName);
}

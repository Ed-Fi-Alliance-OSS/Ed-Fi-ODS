// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.SerializedData.Repositories;

/// <summary>
/// Defines a method for registering the unresolved reference data of an entity with the current reference data lookup
/// context so that the resource identifiers used in resource reference links can be resolved before it is serialized.
/// </summary>
public interface IReferenceDataTracker
{
    /// <summary>
    /// Registers all fully defined, but unresolved, reference data that will be serialized with the supplied entity (including
    /// its child collections, one-to-one children and extensions) with the current reference data lookup context.
    /// </summary>
    /// <param name="entity">The entity whose reference data should be tracked.</param>
    void TrackUnresolvedReferenceData(object entity);
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common;

/// <summary>
/// Defines members for obtaining key values and reference data (including Id and Discriminator).
/// </summary>
public interface IEntityReferenceData : IHasPrimaryKeyValues
{
    /// <summary>
    /// Gets the schema/entity name of the associated <see cref="Entity" />.
    /// </summary>
    FullName FullName { get; }
        
    /// <summary>
    /// The id of the referenced entity (used as the resource identifier in the API).
    /// </summary>
    Guid? Id { get; set; }

    /// <summary>
    /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
    /// when that entity has been derived; otherwise <b>null</b>.
    /// </summary>
    string Discriminator { get; set; }

    /// <summary>
    /// Indicates whether the reference is fully defined.
    /// </summary>
    /// <returns><b>true</b> if the reference's data is fully defined; otherwise <b>false</b>.</returns>
    bool IsFullyDefined();
}

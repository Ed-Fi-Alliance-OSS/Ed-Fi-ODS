// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Defines a method for applying connection string overrides to a supplied <see cref="OdsInstanceConfiguration" />.
/// </summary>
public interface IConnectionStringOverridesApplicator
{
    /// <summary>
    /// Applies connection string overrides to the supplied <see cref="OdsInstanceConfiguration" />.
    /// </summary>
    /// <param name="odsInstanceConfiguration">The ODS instance configuration whose connection strings are be modified.</param>
    void ApplyOverrides(OdsInstanceConfiguration odsInstanceConfiguration);
}

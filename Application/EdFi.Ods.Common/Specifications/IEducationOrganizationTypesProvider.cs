// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Specifications;

/// <summary>
/// Defines a method for obtaining the names of the Education Organization type entities
/// in the model.
/// </summary>
public interface IEducationOrganizationTypesProvider
{
    /// <summary>
    /// Gets the names of the entities of the Education Organization types found in the
    /// model.
    /// </summary>
    string[] EducationOrganizationTypes { get; }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.Composites
{
    /// <summary>
    /// Defines a method for obtaining the names of the concrete education organization ids in the current model.
    /// </summary>
    public interface IConcreteEducationOrganizationIdNamesProvider
    {
        /// <summary>
        /// Gets the names of the concrete education organization ids in the current model.
        /// </summary>
        /// <returns>An array containing the property names.</returns>
        string[] GetNames();
    }
}

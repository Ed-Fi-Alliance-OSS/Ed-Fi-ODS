// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models;

/// <summary>
/// Defines a method for supporting the mapping/synchronizing of Ed-Fi extensions.
/// </summary>
public interface IExtensionsMappingContract
{
    /// <summary>
    /// Indicates whether the named extension is supported in the current mapping contract.
    /// </summary>
    /// <param name="name">The name of the extension.</param>
    /// <returns><b>true</b> if the extension is supported; otherwise <b>false</b>.</returns>
    bool IsExtensionSupported(string name);
}

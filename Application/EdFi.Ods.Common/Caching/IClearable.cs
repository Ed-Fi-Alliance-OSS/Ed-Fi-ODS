// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Caching;

/// <summary>
/// Defines a method for clearing the data maintained by an object.
/// </summary>
public interface IClearable
{
    /// <summary>
    /// Clears the data maintained by the object.
    /// </summary>
    void Clear();
}

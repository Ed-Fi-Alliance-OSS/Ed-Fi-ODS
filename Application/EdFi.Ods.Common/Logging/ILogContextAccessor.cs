// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Logging;

/// <summary>
/// Defines a method for reading and writing values in the logger's context.
/// </summary>
public interface ILogContextAccessor
{
    /// <summary>
    /// Gets the specified named value from the logger's context.
    /// </summary>
    /// <param name="name">The name of the value to be retrieved from the logger's context.</param>
    /// <returns>The contextual value if it has been previously set; otherwise <b>null</b>.</returns>
    object GetValue(string name);

    /// <summary>
    /// Sets the specified name/value pair into the logger's context.
    /// </summary>
    /// <param name="name">The name of the value to be stored in the logger's context.</param>
    /// <param name="value">The value to be stored in the logger's context.</param>
    void SetValue(string name, object value);
}

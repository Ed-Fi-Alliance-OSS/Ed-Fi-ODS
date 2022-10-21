// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Context;

/// <summary>
/// Defines methods for setting and getting values into context.
/// </summary>
/// <typeparam name="T">The <see cref="Type" /> of the object containing the context to be stored.</typeparam>
public interface IContextProvider<T>
{
    /// <summary>
    /// Gets the current context.
    /// </summary>
    /// <returns>The context object previously stored.</returns>
    T Get();
    
    /// <summary>
    /// Sets the current context.
    /// </summary>
    /// <param name="context">The context object to be stored.</param>
    void Set(T context);
}

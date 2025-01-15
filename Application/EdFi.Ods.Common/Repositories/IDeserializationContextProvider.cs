// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Repositories;

/// <summary>
/// Defines a property for indicating whether the deserialization of an aggregate is in progress.
/// </summary>
public interface IDeserializationContextProvider
{
    /// <summary>
    /// Sets the context-based state that indicates whether the deserialization of an aggregate is in progress.
    /// </summary>
    void SetState(bool isDeserializing);
    
    /// <summary>
    /// Indicates whether we are deserializing an aggregate in the current context.
    /// </summary>
    /// <returns><b>true</b> if we're deserializing; otherwise <b>false</b>.</returns>
    bool IsDeserializing();
}

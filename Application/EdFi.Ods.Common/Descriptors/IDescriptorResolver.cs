// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Descriptors;

/// <summary>
/// Defines methods for obtaining descriptorId from descriptor URI representation, and vice-versa.
/// </summary>
public interface IDescriptorResolver
{
    /// <summary>
    /// Gets the DescriptorId for the supplied descriptor URI; otherwise 0;
    /// </summary>
    /// <param name="descriptorName">The name of the descriptor.</param>
    /// <param name="uri">The URI representation of the descriptor.</param>
    /// <returns>The descriptorId if it exists; otherwise 0.</returns>
    int GetDescriptorId(string descriptorName, string uri);
    
    /// <summary>
    /// Gets the URI for the supplied descriptorId; otherwise <b>null</b>.
    /// </summary>
    /// <param name="descriptorName">The name of the descriptor.</param>
    /// <param name="descriptorId">The DescriptorId for the descriptor.</param>
    /// <returns>The URI representation of the descriptor if it exists; otherwise <b>null</b>.</returns>
    string GetUri(string descriptorName, int descriptorId);
}

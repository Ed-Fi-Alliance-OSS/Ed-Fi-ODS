// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Descriptors;

/// <summary>
/// Defines methods for obtaining details for all descriptors, and individual descriptors by DescriptorId or Uri representations.
/// </summary>
public interface IDescriptorDetailsProvider
{
    /// <summary>
    /// Gets details for all descriptors.
    /// </summary>
    /// <returns>A list of descriptor details.</returns>
    IList<DescriptorDetails> GetAllDescriptorDetails();

    /// <summary>
    /// Gets the details for the descriptor if it exists; otherwise <b>null</b>.
    /// </summary>
    /// <param name="descriptorName">The name of the descriptor.</param>
    /// <param name="descriptorId">The identifier of the descriptor.</param>
    /// <returns>The details for the descriptor if it exists; otherwise <b>null</b></returns>
    DescriptorDetails GetDescriptorDetails(string descriptorName, int descriptorId);

    /// <summary>
    /// Gets the details for the descriptor if it exists; otherwise <b>null</b>.
    /// </summary>
    /// <param name="descriptorName">The name of the descriptor.</param>
    /// <param name="uri">The uri representation of the descriptor namespace and code value.</param>
    /// <returns>The details for the descriptor if it exists; otherwise <b>null</b></returns>
    DescriptorDetails GetDescriptorDetails(string descriptorName, string uri);
}

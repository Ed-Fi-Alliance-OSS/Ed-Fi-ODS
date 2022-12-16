// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Xml.Linq;
using EdFi.Ods.Common.Metadata.Profiles;

namespace EdFi.Ods.Common.Metadata.Composites;

/// <summary>
/// Defines methods for getting composite categories, API route definitions and composite definitions. 
/// </summary>
public interface ICompositesMetadataProvider
{
    bool TryGetCompositeDefinition(string organizationCode, string compositeCategoryName, string compositeName, out XElement compositeDefinition);

    /// <summary>
    /// Gets lists of composite metadata route definitions grouped by composite category name.
    /// </summary>
    /// <returns></returns>
    IReadOnlyDictionary<CompositeCategory, IReadOnlyList<XElement>> GetAllRoutes();

    /// <summary>
    /// Gets a list of names of all the composite categories available.
    /// </summary>
    /// <returns>A list of composite category names.</returns>
    IReadOnlyList<CompositeCategory> GetAllCategories();

    /// <summary>
    /// Attempts to retrieve all the composite definitions for a composite category by name.
    /// </summary>
    /// <param name="organizationCode">A code representing the organization that created the composite definition.</param>
    /// <param name="compositeCategoryName">The name of the composite category.</param>
    /// <param name="compositeDefinitions">Upon return, contains the list of composite definitions <see cref="XElement"/>, if found.</param>
    /// <returns><b>true</b> if found; otherwise <b>false</b>.</returns>
    bool TryGetCompositeDefinitions(
        string organizationCode,
        string compositeCategoryName,
        out IReadOnlyList<XElement> compositeDefinitions);

    /// <summary>
    /// Gets lists of composite metadata route definitions grouped by composite category name.
    /// </summary>
    /// <returns></returns>
    bool TryGetRoutes(string organizationCode, string categoryName, out IReadOnlyList<XElement> routeDefinitions);
    
    /// <summary>
    /// Gets the validation results for all composite metadata that has been loaded (or attempted to be loaded).
    /// </summary>
    /// <returns></returns>
    MetadataValidationResult[] GetValidationResults();
}
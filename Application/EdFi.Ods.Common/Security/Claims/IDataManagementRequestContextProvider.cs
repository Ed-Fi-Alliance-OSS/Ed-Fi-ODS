// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Security.Claims;

/// <summary>
/// Defines methods for getting and setting contextual information about the current
/// data management API request.
/// </summary>
public interface IDataManagementRequestContextProvider
{
    /// <summary>
    /// Gets the <see cref="Resource" /> associated with the current request.
    /// </summary>
    /// <returns>The resource associated with the current context.</returns>
    Resource GetResource();
    
    /// <summary>
    /// Sets the <see cref="Resource" /> associated with the current request.
    /// </summary>
    /// <param name="resource">The resource to be associated with the current context.</param>
    void SetResource(Resource resource);
}

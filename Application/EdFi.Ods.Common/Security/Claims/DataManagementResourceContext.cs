// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Security.Claims;

/// <summary>
/// Contains the contextual <see cref="Resource" /> for the current API request. 
/// </summary>
public class DataManagementResourceContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataManagementResourceContext"/> class using the supplied <see cref="Resource" /> instance.
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="httpMethod">The HTTP method used on the current request.</param>
    public DataManagementResourceContext(Resource resource, string httpMethod)
    {
        Resource = resource;
        HttpMethod = httpMethod;
    }

    public DataManagementResourceContext(Resource resource)
    {
        Resource = resource;
        HttpMethod = "GET";
    }
    
    /// <summary>
    /// Gets the contextual <see cref="Resource" /> for the current API request.
    /// </summary>
    public Resource Resource { get; }

    /// <summary>
    /// Gets the HTTP method used with the request.
    /// </summary>
    public string HttpMethod { get; }
}
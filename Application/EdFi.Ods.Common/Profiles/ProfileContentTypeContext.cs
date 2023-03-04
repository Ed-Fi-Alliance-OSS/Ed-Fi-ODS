// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Utils.Profiles;

namespace EdFi.Ods.Common.Profiles
{
/// <summary>
/// Contains the information related to the Profile-specific content type on the current API request.
/// </summary>
public class ProfileContentTypeContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProfileContentTypeContext"/> class using the supplied profile and resource names, and <see cref="ContentTypeUsage" />.
    /// </summary>
    /// <param name="profileName">The name of the profile from the content type used on the current request.</param>
    /// <param name="resourceName">The name of the API resource from the content type used on the current request.</param>
    /// <param name="contentTypeUsage">The content type usage (readable or writable).</param>
    public ProfileContentTypeContext(string profileName, string resourceName, ContentTypeUsage contentTypeUsage)
    {
        ProfileName = profileName;
        ResourceName = resourceName;
        ContentTypeUsage = contentTypeUsage;
    }

    /// <summary>
    /// Gets the name of the profile from the content type used on the current request.
    /// </summary>
    public string ProfileName { get; }

    /// <summary>
    /// Gets the name of the API resource from the content type used on the current request.
    /// </summary>
    public string ResourceName { get; }

    /// <summary>
    /// Gets the content type usage (readable or writable).
    /// </summary>
    public ContentTypeUsage ContentTypeUsage { get; }
}
}

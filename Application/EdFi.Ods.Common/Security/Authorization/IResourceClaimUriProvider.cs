// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Defines methods for obtaining resource claim URIs used for authorization.
    /// </summary>
    public interface IResourceClaimUriProvider 
    {
        /// <summary>
        /// Gets the resource claim URIs for the specified resource Type using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="resourceType">The resource Type for which to build the resource claim URIs.</param>
        /// <returns>The resource URIs.</returns>
        string[] GetResourceClaimUris(Type resourceType);

        /// <summary>
        /// Gets the resource claim URIs for the specified Resource class using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="resource">The <see cref="EdFi.Ods.Common.Models.Resource.Resource" /> for which to build the resource claim URIs.</param>
        /// <returns>The resource URIs.</returns>
        string[] GetResourceClaimUris(Resource resource);

        /// <summary>
        /// Gets the resource URIs for the specified entity class using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="entity">The <see cref="EdFi.Ods.Common.Models.Domain.Entity" /> for which to build the resource URIs.</param>
        /// <returns>The resource claim URIs.</returns>
        string[] GetResourceClaimUris(Entity entity);

        /// <summary>
        /// Gets the full name of the resource associated with the specified resource claim URIs.
        /// </summary>
        /// <param name="resourceClaimUris">The resource claim URIs for which the associated resource name is to be obtained.</param>
        /// <returns>The <see cref="FullName" /> of the resource associated with the supplied resource claim URIs.</returns>
        FullName GetResourceFullName(string[] resourceClaimUris);
    }
}

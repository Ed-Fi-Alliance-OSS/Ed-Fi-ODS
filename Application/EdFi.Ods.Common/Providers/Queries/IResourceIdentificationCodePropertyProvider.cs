// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Providers.Queries;

/// <summary>
/// Provides an interface for retrieving the queryable properties of the identificationCode collection of a resource
/// </summary>
public interface IResourceIdentificationCodePropertiesProvider
{
    /// <summary>
    /// Attempts to get the queryable properties of an resource's identificationCode collection.
    /// </summary>
    /// <param name="resource">The entity to try and get the identificationCode properties for.</param>
    /// <param name="queryableIdentificationCodeProperties">The queryable properties of the identificationCode of the <paramref name="resource"/>.</param>
    /// <returns><c>true</c> if the resource has an identificationCode collection with any queryable properties.</returns>
    public bool TryGetIdentificationCodeProperties(Resource resource,
        out List<ResourceProperty> queryableIdentificationCodeProperties);
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Models
{
    /// <summary>
    /// Gets the Resource model representation for the API.
    /// </summary>
    public interface IResourceModelProvider
    {
        ResourceModel GetResourceModel();
    }
}

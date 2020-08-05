// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Models
{
    /// <summary>
    /// Static helper class to access the ResourceModel. This is used in conjunction with reference links in the resource class
    /// to retrieve the ResourceModel from the container so that the calculation for links can be done using the discriminator value.
    /// </summary>
    public static class ResourceModelHelper
    {
        /// <summary>
        /// Returns the resource model from the container.
        /// </summary>
        public static Lazy<ResourceModel> ResourceModel;
    }
}

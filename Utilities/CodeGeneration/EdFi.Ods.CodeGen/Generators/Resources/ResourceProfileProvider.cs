// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators.Resources
{
    public interface IResourceProfileProvider
    {
        ResourceModel ResourceModel { get; }

        IEnumerable<ResourceData> GetResourceProfileData();
    }

    public class ResourceProfileProvider : IResourceProfileProvider
    {
        public ResourceProfileProvider(
            IResourceModelProvider resourceModelProvider)
        {
            ResourceModel = resourceModelProvider.GetResourceModel();
        }

        public ResourceModel ResourceModel { get; }

        public IEnumerable<ResourceData> GetResourceProfileData()
        {
            // sorting for template comparison.
            return ResourceModel
                .GetAllResources()
                .Select(
                    resource =>
                        new ResourceData
                        {
                            Resource = resource,
                        })
                .OrderBy(x => x.ResourceName);
        }
    }
}

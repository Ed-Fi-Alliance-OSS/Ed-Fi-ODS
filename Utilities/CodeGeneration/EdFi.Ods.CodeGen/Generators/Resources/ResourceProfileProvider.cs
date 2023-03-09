// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Models.Validation;

namespace EdFi.Ods.CodeGen.Generators.Resources
{
    public interface IResourceProfileProvider
    {
        ResourceModel ResourceModel { get; }

        IEnumerable<ResourceProfileData> GetResourceProfileData();
    }

    public class ResourceProfileProvider : IResourceProfileProvider
    {
        public ResourceProfileProvider(
            IResourceModelProvider resourceModelProvider)
        {
            ResourceModel = resourceModelProvider.GetResourceModel();
        }

        public ResourceModel ResourceModel { get; }

        public IEnumerable<ResourceProfileData> GetResourceProfileData()
        {
            // sorting for template comparison.
            return ResourceModel
                .GetAllResources()
                .Select(
                    resource =>
                        new ResourceProfileData
                        {
                            SuppliedResource = resource,
                            UnfilteredResource = (Resource) resource.FilterContext?.UnfilteredResourceClass ?? resource,
                            ContextualRootResource = resource
                        })
                .OrderBy(x => x.ResourceName);
        }
    }
}

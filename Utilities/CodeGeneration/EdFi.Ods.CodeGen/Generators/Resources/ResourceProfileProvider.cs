// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EdFi.Ods.CodeGen.Metadata;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Metadata.StreamProviders.Profiles;
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
        private const string ReadableContext = "_Readable";
        private const string WritableContext = "_Writable";
        private readonly IProfileResourceModelProvider _profileResourceModelProvider;
        private readonly IProfileResourceNamesProvider _profileResourceNamesProvider;

        public ResourceProfileProvider(
            IResourceModelProvider resourceModelProvider,
            TemplateContext templateContext,
            IProfileValidationReporter profileValidationReporter)
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

        private IEnumerable<ResourceProfileData> CreateProfileModel(
            Resource resource,
            string profileName,
            string context,
            bool isReadable)
        {
            if (resource == null)
            {
                yield break;
            }

            var baseResource = GetBaseResource(resource);

            if (baseResource != null)
            {
                yield return new ResourceProfileData
                {
                    SuppliedResource = resource,
                    UnfilteredResource = (Resource) resource.FilterContext?.UnfilteredResourceClass ?? resource,
                    ContextualRootResource = baseResource,
                    ProfileName = profileName,
                    Context = context + "." + resource.Name,
                    ReadableWritableContext = context,
                    ConcreteResourceContext = resource.Name,
                    IsBaseResource = true,
                    IsReadable = isReadable,
                    IsWritable = !isReadable
                };
            }

            yield return new ResourceProfileData
            {
                SuppliedResource = resource,
                UnfilteredResource = (Resource) resource.FilterContext?.UnfilteredResourceClass ?? resource,
                ContextualRootResource = resource,
                ProfileName = profileName,
                Context = context,
                ReadableWritableContext = context,
                ConcreteResourceContext = null,
                IsBaseResource = false,
                IsReadable = isReadable,
                IsWritable = !isReadable
            };
        }

        private Resource GetBaseResource(ResourceClassBase resource)
        {
            return resource.IsDerived && resource.Entity.BaseEntity != null
                ? ResourceModel.GetResourceByFullName(resource.Entity.BaseEntity.FullName)
                : null;
        }
    }
}

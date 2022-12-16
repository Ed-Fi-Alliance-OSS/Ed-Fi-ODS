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
        bool ProjectHasProfileDefinition { get; }

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
            var profileMetadataProvider = MetadataHelper.GetProfileMetadataProvider(resourceModelProvider, templateContext.ProjectPath);
            _profileResourceNamesProvider = profileMetadataProvider;

            _profileResourceModelProvider = new ProfileResourceModelProvider(
                resourceModelProvider,
                profileMetadataProvider,
                profileValidationReporter);

            ProjectHasProfileDefinition = profileMetadataProvider.HasProfileData;

            ResourceModel = resourceModelProvider.GetResourceModel();
        }

        public bool ProjectHasProfileDefinition { get; }

        public ResourceModel ResourceModel { get; }

        public IEnumerable<ResourceProfileData> GetResourceProfileData()
        {
            if (ProjectHasProfileDefinition)
            {
                var profileNamesAndResourceModels =
                    _profileResourceNamesProvider
                        .GetProfileResourceNames()
                        .Select(prn => prn.ProfileName)
                        .Distinct()
                        .Select(
                            profileName =>
                                new
                                {
                                    ProfileName = profileName,
                                    ProfileResourceModel = _profileResourceModelProvider.GetProfileResourceModel(profileName)
                                });

                var readablesAndWritables =
                    profileNamesAndResourceModels
                        .Select(
                            x =>
                            {
                                // we need to include resources if they are derived from other entities that are writable so we can
                                // satisfy the interface
                                var includeInWritable = new List<Resource>();

                                if (x.ProfileResourceModel.Resources.Any(y => y.Writable == null))
                                {
                                    var possibleWritable = x.ProfileResourceModel.Resources.Where(
                                            y => y.Writable == null)
                                        .Select(y => y.Readable);

                                    var writable = x.ProfileResourceModel.Resources.Where(y => y.Writable != null)
                                        .Select(y => y.Writable)
                                        .ToList();

                                    foreach (var resource in possibleWritable)
                                    {
                                        includeInWritable.AddRange(
                                            writable.Where(wr => wr.IsDerivedFrom(resource))
                                                .Select(wr => resource));
                                    }
                                }

                                // to satisfy future profiles that may have this situation also.
                                var includeInReadable = new List<Resource>();

                                if (x.ProfileResourceModel.Resources.Any(y => y.Readable == null))
                                {
                                    var possibleReadable = x.ProfileResourceModel.Resources.Where(
                                            y => y.Readable == null)
                                        .Select(y => y.Writable);

                                    var readable = x.ProfileResourceModel.Resources.Where(y => y.Readable != null)
                                        .Select(y => y.Readable)
                                        .ToList();

                                    foreach (var resource in possibleReadable)
                                    {
                                        includeInReadable.AddRange(
                                            readable.Where(wr => wr.IsDerivedFrom(resource))
                                                .Select(wr => resource));
                                    }
                                }

                                return new
                                {
                                    ProfileName = x.ProfileName,
                                    Readable = x.ProfileResourceModel.Resources
                                        .Where(y => y.Readable != null)
                                        .Select(y => y.Readable)
                                        .Concat(
                                            includeInReadable) // Added to ensure that the pipeline step, which defines 2 generic parameters for readable and writable, has a type available
                                        .ToList(),
                                    Writable = x.ProfileResourceModel.Resources
                                        .Where(y => y.Writable != null)
                                        .Select(y => y.Writable)
                                        .Concat(
                                            includeInWritable) // Added to ensure that the pipeline step, which defines 2 generic parameters for readable and writable, has a type available
                                        .ToList()
                                };
                            });

                var finalReadablesAndWritables =
                    readablesAndWritables.Select(
                            prm =>
                            {
                                return new
                                {
                                    ProfileName = prm.ProfileName,
                                    Readable = prm.Readable
                                        .SelectMany(
                                            pct =>
                                                CreateProfileModel(
                                                    pct,
                                                    prm.ProfileName,
                                                    ReadableContext,
                                                    true))
                                        .ToList(),
                                    Writable = prm.Writable
                                        .SelectMany(
                                            pct => CreateProfileModel(
                                                pct,
                                                prm.ProfileName,
                                                WritableContext,
                                                false))
                                        .ToList()
                                };
                            })
                        .SelectMany(
                            y => y.Readable.OrderBy(q => q.ResourceName)
                                .Concat(y.Writable.OrderBy(q => q.ResourceName)))
                        .ToList();

                return finalReadablesAndWritables;
            }

            // sorting for template comparison.
            return ResourceModel
                .GetAllResources()
                .Select(
                    resource =>
                        new ResourceProfileData
                        {
                            HasProfile = ProjectHasProfileDefinition,
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
                    HasProfile = ProjectHasProfileDefinition,
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
                HasProfile = ProjectHasProfileDefinition,
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

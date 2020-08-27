// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators
{
    public class CreateOrUpdatePipelines : GeneratorBase
    {
        protected override void Configure()
        {
            var validatingProfileMetadataProvider = new ValidatingProfileMetadataProvider(
                TemplateContext.ProjectPath,
                ResourceModelProvider);

            ProfileResourceNamesProvider = validatingProfileMetadataProvider;

            ProfileResourceModelProvider = new ProfileResourceModelProvider(
                ResourceModelProvider,
                validatingProfileMetadataProvider);

            ProjectHasProfileDefinition = validatingProfileMetadataProvider.HasProfileData;
        }

        protected override object Build()
            => ProjectHasProfileDefinition
                ? GetTemplateModelFromProfileResourceModel()
                : GetTemplateModelFromResourceModel();

        private object GetTemplateModelFromProfileResourceModel()
        {
            var profileResourceModels = GetProfileResourceModels();

            return new
            {
                RenderGroups = profileResourceModels
                    .Select(
                        model => new
                        {
                            Model = model,
                            Namespace = GetNamespace(model.ProfileName)
                        })
                    .Select(
                        x => new
                        {
                            x.Namespace,
                            Resources = x.Model.ResourceByName
                                .OrderBy(resourceEntry => resourceEntry.Key)
                                .Where(
                                    resource => !x.Model.GetResourceByName(resource.Key)
                                                    .IsAbstract()
                                                && x.Model.ResourceByName.Any(
                                                    resourceInProfile
                                                        => x.Model.ResourceIsWritable(
                                                            resourceInProfile
                                                                .Key)))
                                .Select(
                                    resource => new
                                    {
                                        ResourceName = resource.Key.Name,
                                        ResourceTypeName =
                                            NamespaceHelper
                                                .GetRelativeNamespace(
                                                    x.Namespace,
                                                    GetResourceTypeName(
                                                        x.Model
                                                            .GetResourceByName(
                                                                resource.Key),
                                                        x.Model.ProfileName)),
                                        EntityTypeName =
                                            NamespaceHelper
                                                .GetRelativeNamespace(
                                                    x.Namespace,
                                                    GetEntityTypeName(
                                                        x.Model
                                                            .GetResourceByName(
                                                                resource.Key)))
                                    })
                        })
            };
        }

        private object GetTemplateModelFromResourceModel()
        {
            return new
            {
                RenderGroups = new object[]
                {
                    new
                    {
                        Namespace = GetNamespace(),
                        Resources = ResourceModelProvider
                            .GetResourceModel()
                            .GetAllResources()
                            .Where(
                                resource => !resource.IsAbstract()
                                            && TemplateContext.ShouldRenderResourceClass(
                                                resource))
                            .Select(
                                resource => new
                                {
                                    ResourceName = resource.Name,
                                    ResourceTypeName =
                                        NamespaceHelper.GetRelativeNamespace(
                                            GetNamespace(),
                                            GetResourceTypeName(resource)),
                                    EntityTypeName =
                                        NamespaceHelper.GetRelativeNamespace(
                                            GetNamespace(),
                                            GetEntityTypeName(resource))
                                })
                    }
                }
            };
        }

        private IEnumerable<ProfileResourceModel> GetProfileResourceModels()
        {
            return ProfileResourceNamesProvider
                .GetProfileResourceNames()
                .Select(prn => prn.ProfileName)
                .Distinct()
                .Select(
                    profileName =>
                        ProfileResourceModelProvider.GetProfileResourceModel(profileName));
        }

        private static string FormatProfileNameForNamespace(string profileName)
        {
            return profileName == null
                ? string.Empty
                : string.Format(".{0}", profileName.Replace("-", "_"));
        }

        private string GetResourceTypeName(Resource resource, string profileName = null)
        {
            string resourceNamespace = EdFiConventions.CreateResourceNamespace(
                resource,
                profileName?.Replace('-', '_'),
                profileName == null
                    ? null
                    : "_Writable");

            return $"{resourceNamespace}.{resource.Name}";
        }

        private string GetEntityTypeName(Resource resource)
        {
            return resource.Entity.EntityTypeFullName(
                resource.SchemaProperCaseName);
        }

        private string GetNamespace(string profileName = null)
        {
            var fullyQualifiedNamespace =
                string.Format(
                    "{0}{1}",
                    Namespaces.Api.Pipelines,
                    TemplateContext.IsExtension || TemplateContext.IsEdFi
                        ? $".{TemplateContext.SchemaProperCaseName}"
                        : string.Empty);

            return profileName == null
                ? fullyQualifiedNamespace
                : string.Format(
                    "{0}{1}",
                    fullyQualifiedNamespace,
                    FormatProfileNameForNamespace(profileName));
        }
    }
}

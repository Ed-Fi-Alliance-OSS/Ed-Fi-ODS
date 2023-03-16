// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators
{
    public class CreateOrUpdatePipelines : GeneratorBase
    {
        protected override void Configure()
        {

        }

        protected override object Build()
            => GetTemplateModelFromResourceModel();

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


        private string GetResourceTypeName(Resource resource)
        {
            string resourceNamespace = EdFiConventions.CreateResourceNamespace(resource);

            return $"{resourceNamespace}.{resource.Name}";
        }

        private string GetEntityTypeName(Resource resource)
        {
            return resource.Entity.EntityTypeFullName(
                resource.SchemaProperCaseName);
        }

        private string GetNamespace()
        {
            var fullyQualifiedNamespace =
                string.Format(
                    "{0}{1}",
                    Namespaces.Api.Pipelines,
                    TemplateContext.IsExtension || TemplateContext.IsEdFi
                        ? $".{TemplateContext.SchemaProperCaseName}"
                        : string.Empty);

            return fullyQualifiedNamespace;
        }
    }
}

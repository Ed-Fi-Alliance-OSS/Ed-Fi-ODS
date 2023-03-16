// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators
{
    public class Requests : GeneratorBase
    {
        protected string BaseNamespaceName
        {
            get => Namespaces.Requests.BaseNamespace;
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
                        Resources = ResourceModelProvider.GetResourceModel()
                            .GetAllResources()
                            .Where(
                                resource
                                    => !resource.IsAbstract()
                                       && TemplateContext
                                           .ShouldRenderResourceClass(
                                               resource))
                            .Select(
                                resource =>
                                    GetTemplateModelPropertiesForResource(
                                        GetNamespace(
                                            resource),
                                        resource,
                                        GetResourceClassTypeName(
                                            resource),
                                        true,
                                        true,
                                        false))
                    }
                }
            };
        }

        private object GetReadableContentTypeForResource(Resource resource)
        {
            return new
            {
                IdentifyingProperties = new
                {
                    Properties = resource.AllRequestProperties()
                        .Where(property => property.IsIdentifying)
                        .OrderBy(x => x.PropertyName)
                        .Select(
                            property => new
                            {
                                property.PropertyName,
                                Systype = GetPropertyDatatype(property)
                            })
                },
                AllProperties = new
                {
                    Properties = resource.AllRequestProperties()
                        .OrderBy(x => x.PropertyName)
                        .Select(
                            property => new
                            {
                                property.PropertyName,
                                Systype = GetPropertyDatatype(property)
                            })
                }
            };
        }

        private object GetTemplateModelPropertiesForResource(
            string namespaceName,
            Resource resource,
            string resourceClassTypeName,
            bool readableContentType,
            bool writableContentType,
            bool generateWritableFormat)
        {
            return new
            {
                Namespace = namespaceName,
                ResourceName = resource.Name,
                ResourcePluralName = resource.Entity.PluralName,
                RouteName = resource.Entity.PluralName.ToCamelCase(),
                ResourceClassTypeName = NamespaceHelper.GetRelativeNamespace(namespaceName, resourceClassTypeName),
                ReadableContentType =
                    readableContentType
                        ? GetReadableContentTypeForResource(resource)
                        : null,
                WritableContentType = writableContentType,
                GenerateWritableFormat = generateWritableFormat
            };
        }

        private string GetNamespace(Resource resource)
        {
            return
                EdFiConventions.BuildNamespace(
                    BaseNamespaceName,
                    TemplateContext.SchemaProperCaseName,
                    resource.Entity.PluralName,
                    resource.Entity.IsExtensionEntity);
        }

        private string GetResourceClassTypeName(Resource resource)
        {
            string resourceNamespace = EdFiConventions.CreateResourceNamespace(resource);

            return $"{resourceNamespace}.{resource.Name}";
        }

        private string GetPropertyDatatype(ResourceProperty property)
        {
            return property.IsDescriptorUsage || property.PropertyName.EndsWith("UniqueId")
                ? "string"
                : property.PropertyType.ToCSharp();
        }
    }
}

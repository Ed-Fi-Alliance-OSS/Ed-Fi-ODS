// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators
{
    public class Controllers : GeneratorBase
    {
        private string BaseNamespaceName { get; set; }

        private string RequestBaseNamespaceName { get; set; }

        protected override void Configure()
        {
            BaseNamespaceName = Namespaces.Api.Controllers;
            RequestBaseNamespaceName = Namespaces.Requests.RelativeNamespace;
        }

        protected override object Build()
        {
            return new
            {
                Controllers = GetResourcesToRender()
                    .Where(r => !r.IsAbstract())
                    .Select(GetControllersModel)
                    .ToList(),
                ControllersBaseNamespace = BaseNamespaceName,
                ProperCaseName = TemplateContext.SchemaProperCaseName
            };
        }

        private object GetControllersModel(Resource resource)
        {
            return new
            {
                ControllersNamespace = FormatControllersNamespace(resource),
                ControllerClass = $"{resource.PluralName}Controller",
                RouteTemplate = $"{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}",
                ResourceModel = FormatResourceModel(resource),
                EntityInterface = FormatEntityInterface(resource),
                AggregateRoot = FormatAggregateRoot(resource),
                PutRequest = FormatRequest(resource, "Put"),
                PostRequest = FormatRequest(resource, "Post"),
                DeleteRequest = FormatDeleteRequest(resource),
                GetByExampleRequest = FormatRequest(resource, "GetByExample"),
                ResourceName = resource.Name,
                MapAllExpression = FormatReadExpressions(
                    resource,
                    r => r.AllRequestProperties()),
                ExtensionNamespacePrefix = FormatExtensionNamespacePrefix(resource),
                IsExtensionContext = TemplateContext.IsExtension
            };
        }

        private object FormatReadExpressions(
            Resource resource,
            Func<Resource, IEnumerable<ResourceProperty>> resourcePropertiesToRender)
        {
            return new
            {
                HasProperties = true,
                Properties = resourcePropertiesToRender.Invoke(resource)
                    .OrderBy(x => x.EntityProperty.PropertyName)
                    .Select(
                        y => new
                        {
                            SpecificationProperty = y.PropertyName,
                            RequestProperty = y.PropertyName
                        })
            };
        }

        private string FormatControllersNamespace(Resource resource)
        {
            return EdFiConventions.BuildNamespace(
                    BaseNamespaceName,
                    TemplateContext.GetSchemaProperCaseNameForResource(resource),
                    resource.PluralName,
                    resource.Entity.IsExtensionEntity);
        }

        private string FormatDeleteRequest(Resource resource)
        {
            return string.Format(
                "{0}.{1}{2}",
                EdFiConventions.BuildNamespace(
                    Namespaces.Requests.RelativeNamespace,
                    TemplateContext.GetSchemaProperCaseNameForResource(resource),
                    resource.PluralName,
                    resource.Entity.IsExtensionEntity),
                resource.Name,
                "Delete");
        }

        private static string RemoveEdFiNamespacePrefix(string namespaceName)
        {
            return namespaceName.Replace(Namespaces.OdsBaseNamespace, string.Empty)
                .TrimStart('.');
        }

        private string FormatResourceModel(Resource resource)
        {
            return RemoveEdFiNamespacePrefix(
                string.Format(
                    "{0}.{1}",
                    EdFiConventions.CreateResourceNamespace(resource, null),
                    resource.Name));
        }

        private string FormatRequest(Resource resource, string requestType)
        {
            return string.Format(
                "{0}.{1}{2}",
                EdFiConventions.BuildNamespace(
                    Namespaces.Requests.RelativeNamespace,
                    TemplateContext.GetSchemaProperCaseNameForResource(resource),
                    resource.PluralName,
                    resource.Entity.IsExtensionEntity),
                resource.Name,
                requestType);
        }

        private string FormatEntityInterface(ResourceClassBase resource)
        {
            string properCaseName = resource.IsEdFiResource()
                ? TemplateContext.SchemaProperCaseName
                : resource.ResourceModel.SchemaNameMapProvider
                    .GetSchemaMapByPhysicalName(resource.Entity.Schema)
                    .ProperCaseName;

            return RemoveEdFiNamespacePrefix(
                string.Format(
                    "{0}.I{1}",
                    EdFiConventions.BuildNamespace(
                        Namespaces.Entities.Common.BaseNamespace,
                        properCaseName),
                    resource.Name));
        }

        private string FormatAggregateRoot(ResourceClassBase resource)
        {
            string properCaseName = resource.IsEdFiResource()
                ? TemplateContext.SchemaProperCaseName
                : resource.ResourceModel.SchemaNameMapProvider
                    .GetSchemaMapByPhysicalName(resource.Entity.Schema)
                    .ProperCaseName;

            return RemoveEdFiNamespacePrefix(
                $"{resource.Entity.AggregateNamespace(properCaseName)}.{resource.Name}");
        }

        private IEnumerable<Resource> GetResourcesToRender()
        {
            return ResourceModelProvider.GetResourceModel()
                .GetAllResources()
                .Where(r => !r.IsAbstract() && TemplateContext.ShouldRenderResourceClass(r))
                .OrderBy(x => x.Name);
        }

        private string FormatExtensionNamespacePrefix(Resource resource)
        {
            var extensionsName = resource.ResourceModel.SchemaNameMapProvider
                .GetSchemaMapByPhysicalName(resource.Entity.Schema)
                .ProperCaseName;

            return $"{Namespaces.Entities.Common.RelativeNamespace}.{extensionsName}.";
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators
{
    public abstract class ControllersBase : GeneratorBase
    {
        private const string NullRequest = "Null{0}Request";
        private const string ProfileContentTypeBase = "application/vnd.ed-fi.{0}.{1}.{2}";

        protected string BaseNamespaceName { get; set; }

        protected string RequestBaseNamespaceName { get; set; }

        protected override object Build()
        {
            return new
            {
                Controllers = GetStandardizedResourceProfileData()
                    .Where(
                        r => (r.Readable == null || !r.Readable.IsAbstract()) && (r.Writable == null || !r.Writable.IsAbstract()))
                    .Select(GetControllersModel)
                    .ToList(),
                ControllersBaseNamespace = BaseNamespaceName,
                ProperCaseName = TemplateContext.SchemaProperCaseName
            };
        }

        private object GetControllersModel(StandardizedResourceProfileData resourceData)
        {
            return new
            {
                ControllersNamespace = FormatControllersNamespace(resourceData),
                NullRequests = GetNullRequests(resourceData),
                ControllerClass = $"{resourceData.ResolvedResource.PluralName}Controller",
                RouteTemplate = $"{resourceData.ResolvedResource.SchemaUriSegment()}/{resourceData.ResolvedResource.PluralName.ToCamelCase()}",
                ResourceReadModel = FormatResourceReadModel(resourceData),
                ResourceWriteModel = FormatResourceWriteModel(resourceData),
                EntityInterface = FormatEntityInterface(resourceData.ResolvedResource),
                AggregateRoot = FormatAggregateRoot(resourceData.ResolvedResource),
                PutRequest = FormatWritableRequest(resourceData, "Put"),
                PostRequest = FormatWritableRequest(resourceData, "Post"),
                DeleteRequest = FormatDeleteRequest(resourceData),
                GetByExampleRequest = FormatReadableRequest(resourceData, "GetByExample"),
                ResourceName = resourceData.ResolvedResource.Name,
                MapAllExpression = FormatReadExpressions(
                    resourceData,
                    r => r.AllRequestProperties()),
                ResourceCollectionName = resourceData.ResolvedResource.PluralName.ToCamelCase(),
                ReadContentType = FormatReadContentType(resourceData),
                OverrideHttpFunctions = FormatHttpFunctionOverides(resourceData),
                ExtensionNamespacePrefix = FormatExtensionNamespacePrefix(resourceData),
                IsExtensionContext = TemplateContext.IsExtension
            };
        }

        private object FormatHttpFunctionOverides(StandardizedResourceProfileData resourceData)
        {
            const string ReadOnlyHttpMethods = "PUT, POST, DELETE and OPTIONS";
            const string WriteOnlyHttpMethods = "GET, DELETE and OPTIONS";

            if (resourceData.Readable == null)
            {
                return new[]
                {
                    new
                    {
                        MethodName = "Get",
                        MethodParameters = "Guid id",
                        resourceData.ProfileName,
                        AllowedHttpMethods = ReadOnlyHttpMethods
                    },
                    new
                    {
                        MethodName = "GetAll",
                        MethodParameters =
                            string.Format(
                                "UrlQueryParametersRequest urlQueryParametersRequest, {0} specification = null",
                                FormatReadableRequest(resourceData, "GetAll")),
                        resourceData.ProfileName,
                        AllowedHttpMethods = ReadOnlyHttpMethods
                    }
                };
            }

            if (resourceData.Writable == null)
            {
                return new[]
                {
                    new
                    {
                        MethodName = "Post",
                        MethodParameters = string.Format(
                            "{0} request",
                            FormatWritableRequest(resourceData, "Post")),
                        resourceData.ProfileName,
                        AllowedHttpMethods = WriteOnlyHttpMethods
                    },
                    new
                    {
                        MethodName = "Put",
                        MethodParameters = string.Format(
                            "{0} request, Guid id",
                            FormatWritableRequest(resourceData, "Put")),
                        resourceData.ProfileName,
                        AllowedHttpMethods = WriteOnlyHttpMethods
                    }
                };
            }

            return null;
        }

        private object FormatReadExpressions(
            StandardizedResourceProfileData resourceData,
            Func<Resource, IEnumerable<ResourceProperty>> resourcePropertiesToRender)
        {
            if (resourceData.Readable == null)
            {
                return new {HasProperties = false};
            }

            //For matching purposes
            var unfilteredResource = ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(resourceData.Readable.Entity.FullName);

            //otherwise resourceData.Readable
            return new
            {
                HasProperties = true,
                Properties = resourcePropertiesToRender.Invoke(unfilteredResource)
                    .OrderBy(x => x.EntityProperty.PropertyName)
                    .Select(
                        y => new
                        {
                            SpecificationProperty = y.PropertyName,
                            RequestProperty = y.PropertyName
                        })
            };
        }

        private static string FormatReadContentType(StandardizedResourceProfileData resourceData)
        {
            return resourceData.ProfileName == null
                ? null
                : string.Format(ProfileContentTypeBase, resourceData.ResolvedResource, resourceData.ProfileName, "readable+json")
                    .ToLower();
        }

        private static string FormatWriteContentType(StandardizedResourceProfileData resourceData)
        {
            return resourceData.ProfileName == null
                ? null
                : string.Format(ProfileContentTypeBase, resourceData.ResolvedResource, resourceData.ProfileName, "writable+json")
                    .ToLower();
        }

        private string FormatControllersNamespace(StandardizedResourceProfileData resourceData)
        {
            return string.Format(
                "{0}{1}",
                EdFiConventions.BuildNamespace(
                    BaseNamespaceName,
                    TemplateContext.GetSchemaProperCaseNameForResource(resourceData.ResolvedResource),
                    resourceData.ResolvedResource.PluralName,
                    resourceData.ResolvedResource.Entity.IsExtensionEntity),
                resourceData.ProfileNamespaceSection);
        }

        private string FormatDeleteRequest(StandardizedResourceProfileData resourceData)
        {
            //For some reason delete is included in the read only profiles.
            //If that ever changes:
            //FormatWritableRequest(resourceData, "Delete");

            return string.Format(
                "{0}{1}.{2}{3}",
                EdFiConventions.BuildNamespace(
                    Namespaces.Requests.RelativeNamespace,
                    TemplateContext.GetSchemaProperCaseNameForResource(resourceData.ResolvedResource),
                    resourceData.ResolvedResource.PluralName,
                    resourceData.ResolvedResource.Entity.IsExtensionEntity),
                resourceData.ProfileNamespaceSection,
                resourceData.ResolvedResource.Name,
                "Delete");
        }

        private static string FormatNullReadRequest(StandardizedResourceProfileData resourceData)
        {
            return string.Format(
                "{0}{1}",
                resourceData.ResolvedResource.PluralName,
                string.Format(NullRequest, "Read"));
        }

        private static string FormatNullWriteRequest(StandardizedResourceProfileData resourceData)
        {
            return string.Format(
                "{0}{1}",
                resourceData.ResolvedResource.PluralName,
                string.Format(NullRequest, "Write"));
        }

        private static string RemoveEdFiNamespacePrefix(string namespaceName)
        {
            return namespaceName.Replace(Namespaces.OdsBaseNamespace, string.Empty)
                .TrimStart('.');
        }

        private string FormatResourceReadModel(StandardizedResourceProfileData resourceData)
        {
            if (resourceData.Readable == null)
            {
                return FormatNullReadRequest(resourceData);
            }

            return RemoveEdFiNamespacePrefix(
                string.Format(
                    "{0}.{1}",
                    EdFiConventions.CreateResourceNamespace(
                        resourceData.Readable,
                        resourceData.ProfileNamespaceName,
                        resourceData.ProfileNamespaceName != null
                            ? "_Readable"
                            : null),
                    resourceData.Readable.Name));
        }

        private string FormatResourceWriteModel(StandardizedResourceProfileData resourceData)
        {
            if (resourceData.Writable == null)
            {
                return FormatNullWriteRequest(resourceData);
            }

            return RemoveEdFiNamespacePrefix(
                string.Format(
                    "{0}.{1}",
                    EdFiConventions.CreateResourceNamespace(
                        resourceData.Writable,
                        resourceData.ProfileNamespaceName,
                        resourceData.ProfileNamespaceName != null
                            ? "_Writable"
                            : null),
                    resourceData.Writable.Name));
        }

        private string FormatReadableRequest(StandardizedResourceProfileData resourceData, string requestType)
        {
            if (resourceData.Readable == null)
            {
                return FormatNullReadRequest(resourceData);
            }

            return string.Format(
                "{0}{1}.{2}{3}",
                EdFiConventions.BuildNamespace(
                    Namespaces.Requests.RelativeNamespace,
                    TemplateContext.GetSchemaProperCaseNameForResource(resourceData.ResolvedResource),
                    resourceData.Readable.PluralName,
                    resourceData.Readable.Entity.IsExtensionEntity),
                resourceData.ProfileNamespaceSection,
                resourceData.Readable.Name,
                requestType);
        }

        private string FormatWritableRequest(StandardizedResourceProfileData resourceData, string requestType)
        {
            if (resourceData.Writable == null)
            {
                return FormatNullWriteRequest(resourceData);
            }

            return string.Format(
                "{0}{1}.{2}{3}",
                EdFiConventions.BuildNamespace(
                    Namespaces.Requests.RelativeNamespace,
                    TemplateContext.GetSchemaProperCaseNameForResource(resourceData.ResolvedResource),
                    resourceData.Writable.PluralName,
                    resourceData.Writable.Entity.IsExtensionEntity),
                resourceData.ProfileNamespaceSection,
                resourceData.Writable.Name,
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

        private static object GetNullRequests(StandardizedResourceProfileData resourceData)
        {
            if (resourceData.Readable != null && resourceData.Writable != null)
            {
                return null;
            }

            var readRequest = resourceData.Readable != null
                ? null
                : new
                {
                    ContentType = FormatReadContentType(resourceData),
                    ClassName = FormatNullReadRequest(resourceData)
                };

            var writeRequest = resourceData.Writable != null
                ? null
                : new
                {
                    ContentType = FormatWriteContentType(resourceData),
                    ClassName = FormatNullWriteRequest(resourceData)
                };

            //One of the requests has to be populated.
            return readRequest ?? writeRequest;
        }

        private IEnumerable<StandardizedResourceProfileData> GetStandardizedResourceProfileData()
        {
            if (ProjectHasProfileDefinition)
            {
                return ProfileResourceNamesProvider
                    .GetProfileResourceNames()
                    .Select(prn => prn.ProfileName)
                    .Distinct()
                    .Select(
                        profileName =>
                            ProfileResourceModelProvider.GetProfileResourceModel(profileName))
                    .SelectMany(
                        prm => prm.Resources.Select(
                            pct =>
                                new StandardizedResourceProfileData
                                {
                                    Readable = pct.Readable,
                                    Writable = pct.Writable,
                                    ProfileName = prm.ProfileName
                                }))
                    .OrderBy(spd => spd.ProfileName.ToLower())
                    .ThenBy(x => x.ResolvedResource.Name);
            }

            return ResourceModelProvider.GetResourceModel()
                .GetAllResources()
                .Where(r => !r.IsAbstract() && TemplateContext.ShouldRenderResourceClass(r))
                .OrderBy(x => x.Name)
                .Select(
                    resource =>
                        new StandardizedResourceProfileData
                        {
                            Readable = resource,
                            Writable = resource,
                            ProfileName = null
                        })
                .OrderBy(x => x.ResolvedResource.Name);
        }

        private string FormatExtensionNamespacePrefix(StandardizedResourceProfileData profileData)
        {
            Resource resource = profileData.Readable != null
                ? profileData.Readable
                : profileData.Writable;

            if (resource.IsEdFiResource())
            {
                return string.Empty;
            }

            var extensionsName = resource.ResourceModel.SchemaNameMapProvider
                .GetSchemaMapByPhysicalName(resource.Entity.Schema)
                .ProperCaseName;

            return $"{Namespaces.Entities.Common.RelativeNamespace}.{extensionsName}.";
        }

        private class StandardizedResourceProfileData
        {
            public string ProfileName { get; set; }

            public string ProfileNamespaceName
            {
                get { return ProfileName?.Replace('-', '_'); }
            }

            public string ProfileNamespaceSection
            {
                get
                {
                    if (ProfileName == null)
                    {
                        return string.Empty;
                    }

                    return "." + ProfileName.Replace("-", "_");
                }
            }

            public Resource Readable { get; set; }

            public Resource Writable { get; set; }

            public Resource ResolvedResource
            {
                get { return Readable ?? Writable; }
            }
        }
    }
}

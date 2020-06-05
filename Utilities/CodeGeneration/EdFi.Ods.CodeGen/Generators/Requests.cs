// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
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
            => ProjectHasProfileDefinition
                ? GetTemplateModelFromProfileResourceModel()
                : GetTemplateModelFromResourceModel();

        private object GetTemplateModelFromProfileResourceModel()
        {
            return new
            {
                ConditionalInclude = GetConditionalInclude(),
                RenderGroups = GetProfileResourceModels()
                    .Select(
                        model => new
                        {
                            Resources = model.ResourceByName.OrderBy(resource => resource.Key)
                                .Where(
                                    resource => !model.GetResourceByName(resource.Key)
                                        .IsAbstract())
                                .Select(
                                    resource =>
                                        GetTemplateModelPropertiesForResource(
                                            GetNamespace(model.GetResourceByName(resource.Key), model.ProfileName),
                                            ResourceModelProvider.GetResourceModel()
                                                .GetResourceByFullName(resource.Key),
                                            GetResourceClassTypeName(
                                                model.GetResourceByName(resource.Key),
                                                model.ProfileName),
                                            model.ResourceIsReadable(resource.Key),
                                            model.ResourceIsWritable(resource.Key)
                                            || model.ResourceByName
                                                .Any(
                                                    r => r.Value.Writable != null
                                                         && r.Value.Writable.Entity.IncomingAssociations
                                                             .Any(
                                                                 a => a.OtherEntity.FullName == resource.Key
                                                                      && a.AssociationType
                                                                      == AssociationViewType.FromBase)),
                                            model.ResourceIsWritable(resource.Key)
                                            || model.ResourceByName
                                                .Any(
                                                    r => r.Value.Writable != null
                                                         && r.Value.Writable.Entity.IncomingAssociations
                                                             .Any(
                                                                 a => a.OtherEntity.FullName == resource.Key
                                                                      && a.AssociationType
                                                                      == AssociationViewType.FromBase)),
                                            GetProfileContentWritableFormat(resource.Key.Name, model.ProfileName)
                                        ))
                        })
            };
        }

        private object GetTemplateModelFromResourceModel()
        {
            return new
            {
                ConditionalInclude = string.Empty,
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
            bool generateWritableFormat,
            string profileContentWritableFormat = "")
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
                GenerateWritableFormat = generateWritableFormat,
                ProfileContentWritableFormat = profileContentWritableFormat
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

        private string GetProfileNamespaceName(string profileName)
        {
            return profileName.Replace("-", "_");
        }

        private string GetConditionalInclude()
        {
            return string.Format(
                "using {0};{1}",
                Namespaces.Api.Architecture,
                Environment.NewLine);
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

        private string GetNamespace(Resource resource, string profileName)
        {
            string baseNamespace = EdFiConventions.BuildNamespace(
                BaseNamespaceName,
                TemplateContext.GetSchemaProperCaseNameForResource(resource),
                resource.Entity.PluralName,
                resource.Entity.IsExtensionEntity);

            return $"{baseNamespace}.{GetProfileNamespaceName(profileName)}";
        }

        private string GetResourceClassTypeName(Resource resource)
        {
            string resourceNamespace = EdFiConventions.CreateResourceNamespace(resource);

            return $"{resourceNamespace}.{resource.Name}";
        }

        private string GetResourceClassTypeName(Resource resource, string profileName)
        {
            string resourceNamespace =
                EdFiConventions.CreateResourceNamespace(
                    resource,
                    GetProfileNamespaceName(profileName),
                    "_Writable");

            return $"{resourceNamespace}.{resource.Name}";
        }

        private string GetPropertyDatatype(ResourceProperty property)
        {
            return property.IsLookup || property.PropertyName.EndsWith("UniqueId")
                ? "string"
                : property.PropertyType.ToCSharp();
        }

        private string GetProfileContentWritableFormat(string resourceName, string profileName)
        {
            return string.Format(
                "[ProfileContentType(\"application/vnd.ed-fi.{0}.{1}.writable+json\")]",
                resourceName.ToCamelCase(),
                profileName);
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntityAuthorizationContextProviders : GeneratorBase
    {
        private const string EducationOrganizationTableName = "EducationOrganization";
        private const string EducationOrganizationKey = "EducationOrganizationId";
        private Dictionary<Resource, IEnumerable<AuthorizationContextProperty>> _authorizationPropertiesByResource;
        private IEnumerable<ResourceProperty> _primaryKeysInheritedFromEducationOrganization;
        private ResourceModel _resourceModel;
        private IEnumerable<Resource> _resourcesToRender;

        private IEnumerable<ResourceProperty> EducationOrganizationColumns
        {
            get
            {
                if (_primaryKeysInheritedFromEducationOrganization == null)
                {
                    var educationOrganization =
                        _resourceModel.GetResourceByFullName(
                            new FullName(EdFiConventions.PhysicalSchemaName, EducationOrganizationTableName));

                    var derivedProperties =
                        DerivedResources(
                                _resourceModel.GetResourceByFullName(
                                    new FullName(EdFiConventions.PhysicalSchemaName, EducationOrganizationTableName)))
                            .SelectMany(r => r.IdentifyingProperties)
                            .ToList();

                    derivedProperties.Add(
                        educationOrganization.Properties.First(
                            p => p.PropertyName == EducationOrganizationKey));

                    _primaryKeysInheritedFromEducationOrganization =
                        derivedProperties.Distinct(ModelComparers.ResourceProperty);
                }

                return _primaryKeysInheritedFromEducationOrganization;
            }
        }

        protected override void Configure()
        {
            _resourceModel = ResourceModelProvider.GetResourceModel();

            _resourcesToRender = ResourceModelProvider.GetResourceModel()
                .GetAllResources()
                .Where(r => TemplateContext.ShouldRenderResourceClass(r));

            _authorizationPropertiesByResource = InitializeAuthorizationPropertiesByResource();
        }

        protected override object Build()
        {
            var model =
                new
                {
                    ClaimsNamespace = Namespaces.Common.Claims,
                    EntitiesNamespace =
                        EdFiConventions.BuildNamespace(
                            Namespaces.Entities.Common.BaseNamespace,
                            TemplateContext.SchemaProperCaseName),
                    AuthorizationStrategyNamespace = Namespaces.Security.Relationships,
                    AggregateEntityIncludes = GetAggregateEntityIncludes()
                        .Select(
                            i => new {Include = i}),
                    ContextDataProviderNamespace =
                        EdFiConventions.BuildNamespace(
                            Namespaces.Security.ContextDataProviders,
                            TemplateContext.SchemaProperCaseName),
                    ResourcesToRender = _authorizationPropertiesByResource.Select(
                        r => new
                        {
                            r.Key.Entity.Schema,
                            ResourceName = r.Key.Name,
                            ResourceNameCamelCase = r.Key.Name.ToCamelCase(),
                            SchemaIsEdFi = r.Key.IsEdFiResource(),
                            AuthorizationResourceProperties = r.Value.OrderBy(p => p.PropertyName)
                                .Select(
                                    p => new
                                    {
                                        ContextPropertyIsIncludedAndNumeric
                                            = p.IsIncluded && p
                                                  .IsNumeric,
                                        ContextPropertyIsIncludedOrNumeric
                                            = p.IsIncluded ^ p
                                                  .IsNumeric,
                                        ContextPropertyIsNotIncludedAndNumeric
                                            = !p.IsIncluded && p
                                                  .IsNumeric,
                                        ContextPropertyName =
                                            p.PropertyName,
                                        ContextPropertyType =
                                            p.PropertyType,
                                        ContextPropertyReason =
                                            p.Reason,
                                        p.IsIdentifying,
                                        p.IsIncluded
                                    })
                        })
                };

            return model;
        }

        private Dictionary<Resource, IEnumerable<AuthorizationContextProperty>> InitializeAuthorizationPropertiesByResource()
        {
            return _resourcesToRender
                .Where(
                    r => !DescriptorEntitySpecification.IsEdFiDescriptorEntity(r.Name))
                .Select(
                    r =>
                        new
                        {
                            Resource = r,
                            AuthorizationResourceProperties =
                                AuthorizationResourceProperties(r)
                        })
                .Where(r => r.AuthorizationResourceProperties.Any())
                .ToDictionary(
                    k => k.Resource,
                    v => v.AuthorizationResourceProperties);
        }

        private IEnumerable<string> GetAggregateEntityIncludes()
        {
            return
                _authorizationPropertiesByResource.Select(
                    r => r.Key.Entity.AggregateNamespace(TemplateContext.SchemaProperCaseName));
        }

        private IEnumerable<AuthorizationContextProperty> AuthorizationResourceProperties(Resource resource)
        {
            return UniqueIdProperties(resource)
                .Concat(EducationOrganizationProperties(resource));
        }

        private IEnumerable<AuthorizationContextProperty> UniqueIdProperties(Resource resource)
        {
            return resource.Entity.Properties.Where(p => UniqueIdSpecification.IsUSI(p.PropertyName))
                .Select(
                    p => new AuthorizationContextProperty
                    {
                        PropertyName = p.PropertyName,
                        PropertyType = "int",
                        IsIdentifying = p.IsIdentifying,
                        IsIncluded = p.IsIdentifying,
                        Reason = p.IsIdentifying
                            ? "USI"
                            : "Not part of primary key"
                    });
        }

        private IEnumerable<AuthorizationContextProperty> EducationOrganizationProperties(Resource resource)
        {
            var educationOrganizationColumnsInResource =
                EducationOrganizationColumns.Intersect(
                    resource.IdentifyingProperties,
                    ModelComparers.ResourcePropertyNameOnly);

            var roleNamedEducationOrganizationColumnsInResource =
                resource.AllProperties
                    .Where(
                        p =>
                            EducationOrganizationColumns.Any(
                                c => c.PropertyName != p.PropertyName && p.PropertyName.EndsWith(c.PropertyName)))
                    .Except(educationOrganizationColumnsInResource, ModelComparers.ResourcePropertyNameOnly)
                    .Distinct(ModelComparers.ResourcePropertyNameOnly);

            var nonRoleOrIdentifyingColumnsInResource =
                resource.NonIdentifyingProperties
                    .Where(
                        p =>
                            EducationOrganizationColumns.Any(c => c.PropertyName == p.PropertyName))
                    .Except(roleNamedEducationOrganizationColumnsInResource, ModelComparers.ResourcePropertyNameOnly);

            return educationOrganizationColumnsInResource.Take(1)
                .Select(
                    p => new AuthorizationContextProperty
                    {
                        PropertyName = p.PropertyName,
                        PropertyType = p.PropertyType.ToCSharp(),
                        IsIdentifying = p.IsIdentifying,
                        IsIncluded = true,
                        Reason =
                            educationOrganizationColumnsInResource.Count() == 1
                                ? "Only Education Organization Id present"
                                : "Most specific Education Organization type present"
                    })
                .Concat(
                    educationOrganizationColumnsInResource.Skip(1)
                        .Select(
                            p => new AuthorizationContextProperty
                            {
                                PropertyName = p.PropertyName,
                                PropertyType = p
                                    .PropertyType
                                    .ToCSharp(),
                                IsIdentifying = p.IsIdentifying,
                                IsIncluded = false,
                                Reason =
                                    "More specific Education Organization type already present"
                            }))
                .Concat(
                    roleNamedEducationOrganizationColumnsInResource
                        .Select(
                            p => new AuthorizationContextProperty
                            {
                                PropertyName = p.PropertyName,
                                PropertyType = p.PropertyType.ToCSharp(),
                                IsIdentifying = p.IsIdentifying,
                                IsIncluded = false,
                                Reason =
                                    "Role name applied" + (p.IsIdentifying
                                        ? string.Empty
                                        : " and not part of primary key")
                            }))
                .Concat(
                    nonRoleOrIdentifyingColumnsInResource
                        .Select(
                            p => new AuthorizationContextProperty
                            {
                                PropertyName = p.PropertyName,
                                PropertyType = p.PropertyType.ToCSharp(),
                                IsIdentifying = p.IsIdentifying,
                                IsIncluded = false,
                                Reason = "Not part of primary key"
                            }));
        }

        public IEnumerable<ResourceClassBase> DerivedResources(ResourceClassBase resourceClassBase)
        {
            return _resourceModel.GetAllResources()
                .Where(
                    r => resourceClassBase.Entity.DerivedEntities.Contains(
                        r.Entity,
                        ModelComparers.Entity));
        }

        private class AuthorizationContextProperty
        {
            private readonly IEnumerable<string> _numericTypes = new[]
            {
                "long",
                "short",
                "int",
                "Guid"
            };

            public string PropertyName { get; set; }

            public string PropertyType { get; set; }

            public bool IsIdentifying { get; set; }

            public bool IsIncluded { get; set; }

            public string Reason { get; set; }

            public bool IsNumeric
            {
                get { return _numericTypes.Contains(PropertyType); }
            }
        }
    }
}

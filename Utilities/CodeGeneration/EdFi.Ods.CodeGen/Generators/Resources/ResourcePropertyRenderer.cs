// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Generators.Resources
{
    public class ResourcePropertyRenderer
    {
        public object AssembleProperties(ResourceClassBase resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            var props = CreateProperties(resource)
                .ToList();

            return props.Any()
                ? new {Properties = CreatePropertyDtos(props)}
                : ResourceRenderer.DoNotRenderProperty;
        }

        public object AssemblePrimaryKeys(
            ResourceData resourceData,
            ResourceClassBase resourceClass,
            TemplateContext templateContext)
        {
            if (resourceData == null)
            {
                throw new ArgumentNullException(nameof(resourceData));
            }

            if (resourceClass == null)
            {
                throw new ArgumentNullException(nameof(resourceClass));
            }

            if (templateContext == null)
            {
                throw new ArgumentNullException(nameof(templateContext));
            }

            var pks = new List<object>();

            var filteredResource = resourceData.GetContainedResource(resourceClass) ?? resourceClass; // TODO: Revisit

            if (resourceClass is ResourceChildItem resourceChildItem)
            {
                pks.Add(
                    new
                    {
                        HasParent = ResourceRenderer.DoRenderProperty,
                        Property = new
                        {
                            PropertyName =
                                resourceClass.GetResourceInterfaceName(
                                    templateContext.GetSchemaProperCaseNameForResource(resourceClass),
                                    templateContext.IsExtension),
                            ReferencesWithUnifiedKey =
                                resourceClass.References
                                    .Where(@ref => @ref.Properties.Any(rp => rp.IsUnified()))
                                    .Select(@ref => new
                                    {
                                        ReferencePropertyName = @ref.PropertyName,
                                        ReferenceFieldName = @ref.PropertyName.ToCamelCase(),
                                        UnifiedKeyProperties = @ref.Properties
                                            .Where(rp => rp.IsUnified())
                                            .Select(rp => new
                                            {
                                                PropertyPath = resourceChildItem is
                                                    {
                                                        IsResourceExtension: true,
                                                        IsResourceExtensionClass: false, 
                                                    } 
                                                    ? string.Join(
                                                        string.Empty,
                                                        resourceChildItem.GetLineage().TakeWhile(l => !l.IsResourceExtension)
                                                            .Select(l => "." + l.Name))
                                                    : null,
                                                UnifiedKeyPropertyName = rp.PropertyName
                                            })
                                    })
                        }
                    });
            }

            var props = new List<PropertyData>();

            foreach (var property in resourceClass.AllProperties
                .Where(x => x.IsIdentifying)
                .OrderBy(x => x.PropertyName))
            {
                if (resourceClass.IsDescriptorEntity())
                {
                    props.Add(PropertyData.CreateDerivedProperty(property));
                    continue;
                }

                if (resourceClass.IsAggregateRoot())
                {
                    if (resourceClass.IsDerived)
                    {
                        props.Add(AssembleDerivedProperty(property));
                    }
                    else
                    {
                        props.Add(
                            property.IsPersonOrUsi() && !templateContext.IsExtension
                                ? PropertyData.CreateUsiPrimaryKey(property)
                                : property.HasAssociations() && !property.IsDirectDescriptorUsage
                                    ? PropertyData.CreateReferencedProperty(property, resource: filteredResource)
                                    : PropertyData.CreateStandardProperty(property));
                    }
                }
                else
                {
                    // non aggregate root
                    if (resourceClass.References.Any())
                    {
                        if (property.IsPersonOrUsi())
                        {
                            props.Add(PropertyData.CreateUsiPrimaryKey(property));
                            continue;
                        }

                        if (resourceClass.HasBackReferences()
                            && resourceClass.BackReferencedProperties()
                                .Contains(property, ModelComparers.ResourcePropertyNameOnly))
                        {
                            continue;
                        }

                        props.Add(
                            property.HasAssociations() && !property.IsDirectDescriptorUsage
                                ? PropertyData.CreateReferencedProperty(property)
                                : PropertyData.CreateStandardProperty(property));
                    }
                    else
                    {
                        props.Add(PropertyData.CreateStandardProperty(property));
                    }
                }
            }

            pks.AddRange(CreatePropertyDtos(props));

            return pks.Any()
                ? new {Properties = pks}
                : ResourceRenderer.DoNotRenderProperty;
        }

        public object AssembleIdentifiers(ResourceClassBase resource, AssociationView association = null)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (!resource.IdentifyingProperties.Any() && association == null)
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            IList<ResourceProperty> properties;

            if (resource.IsAggregateRoot())
            {
                properties = resource.IdentifyingProperties
                    .OrderBy(x => x.PropertyName)
                    .ToList();
            }
            else
            {
                if (association != null)
                {
                    properties = association.ThisProperties
                        .Where(x => !(x.IsUnified && x.IsIdentifying))
                        .Select(
                            x =>
                                association.PropertyMappingByThisName[x.PropertyName]
                                    .OtherProperty
                                    .ToResourceProperty(resource))
                        .OrderBy(x => x.PropertyName)
                        .ToList();
                }
                else
                {
                    properties = resource.IdentifyingProperties
                        .Where(x => !x.EntityProperty.IsLocallyDefined)
                        .OrderBy(x => x.PropertyName)
                        .ToList();
                }
            }

            ResourceProperty first = properties.FirstOrDefault();
            ResourceProperty last = properties.LastOrDefault();

            return properties.Any()
                ? properties.Select(
                        y => new PropertyData(y)
                        {
                            IsFirstProperty = y == first,
                            IsLastProperty = y == last
                        }.Render())
                    .ToList()
                : ResourceRenderer.DoNotRenderProperty;
        }

        public object AssembleInheritedProperties(ResourceClassBase resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            IList<ResourceProperty> includedProperties = null;

            includedProperties = resource.InheritedProperties()
                    .OrderBy(x => x.PropertyName)
                    .Where(x => !x.IsIdentifying && !x.PropertyName.Equals("Id"))
                    .ToList();

            var propertiesToRender = new List<PropertyData>();

            if (resource.IsDescriptorEntity()
                && resource.InheritedProperties()
                    .Any(x => !x.IsIdentifying && !x.PropertyName.Equals("Id")))
            {
                propertiesToRender.AddRange(
                    includedProperties.Select(
                        x =>
                        {
                            var propertyData = PropertyData.CreateStandardProperty(x);

                            propertyData[ResourceRenderer.MiscellaneousComment] = "// NOT in a reference, NOT a lookup column ";
                            return propertyData;
                        }));
            }
            else if (resource.IsDerived)
            {
                propertiesToRender.AddRange(
                    includedProperties.Select(
                        PropertyData.CreateStandardProperty));
            }

            return propertiesToRender.Any()
                ? new {Properties = CreatePropertyDtos(propertiesToRender)}
                : ResourceRenderer.DoNotRenderProperty;
        }

        public object AssembleReferenceFullyDefined(ResourceClassBase resource, AssociationView association = null)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            // populates the reference is fully defined method for an aggregate reference.
            if (resource.HasBackReferences() && resource.IsAggregateRoot() || !resource.IdentifyingProperties.Any())
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            var ids = association != null
                ? Resources.GetIdentifyingPropertiesWithAttributes(resource, association)
                    .OrderBy(x => x.Target.PropertyName)
                    .ToList()
                : resource.IdentifyingProperties.Where(x => !x.IsLocallyDefined)
                    .OrderBy(x => x.PropertyName)
                    .Select(
                        x => new HrefData
                        {
                            Source = x,
                            Target = x,
                            IsUnified = false
                        })
                    .ToList();

            if (!ids.Any())
            {
                return ResourceRenderer.DoNotRenderProperty;
            }

            ResourceProperty first = ids.First()
                .Source;

            ResourceProperty last = ids.Last()
                .Source;

            return ids
                .Select(
                    x =>
                        new PropertyData(x.Source)
                        {
                            IsFirstProperty = x.Source == first,
                            IsLastProperty = x.Source == last,
                            IsReferencedProperty = x.IsUnified
                        }.Render())
                .ToList();
        }

        public bool HasRequiredMembersWithMeaningfulDefaultValues(ResourceClassBase resource)
        {
            return resource.Properties.Any(
                p => !p.PropertyType.IsNullable && !p.IsServerAssigned && p.CSharpDefaultHasDomainMeaning());
        }

        public object RequiredMembersWithMeaningfulDefaultValues(ResourceClassBase resource)
        {
            return resource.Properties
                .Where(p => !p.PropertyType.IsNullable && !p.IsServerAssigned && p.CSharpDefaultHasDomainMeaning())
                .Select(p => new
                {
                    CSharpSafePropertyName = p.PropertyName.MakeSafeForCSharpClass(resource.Name), 
                    PropertyFieldName = p.PropertyName.ToCamelCase(),
                })
                .ToList();
        }

        private IList<object> CreatePropertyDtos(IEnumerable<PropertyData> propertiesToRender)
        {
            return propertiesToRender.Select(PropertyData.CreatePropertyDto)
                .ToList();
        }

        private PropertyData AssembleDerivedProperty(ResourceProperty property)
        {
            var propertyData = PropertyData.CreateDerivedProperty(property);

            if (property.EntityProperty.IsInheritedIdentifyingRenamed)
            {
                return propertyData;
            }

            if (property.IsInherited)
            {
                var baseProperty = property.BaseEntityProperty();

                if (!baseProperty.IncomingAssociations.Any())
                {
                    propertyData[ResourceRenderer.RenderType] = ResourceRenderer.RenderStandard;
                    return propertyData;
                }

                return PropertyData.CreateReferencedProperty(
                    baseProperty.ToResourceProperty(property.Parent),
                    UniqueIdConventions.IsUniqueId(property.PropertyName)
                        ? string.Format(
                            "A unique alphanumeric code assigned to a {0}.",
                            property.RemoveUniqueIdOrUsiFromPropertyName()
                                .ToCamelCase())
                        : property.Description.ScrubForXmlDocumentation(),
                    property.Parent.Name);
            }

            propertyData[ResourceRenderer.RenderType] = ResourceRenderer.RenderStandard;
            return propertyData;
        }

        private IEnumerable<PropertyData> CreateProperties(ResourceClassBase resourceClass)
        {
            var allPossibleProperties = resourceClass.FilterContext.UnfilteredResourceClass?.NonIdentifyingProperties ??
                resourceClass.NonIdentifyingProperties;

            var currentProperties = resourceClass.AllProperties;

            var propertyPairs =
                (from p in allPossibleProperties
                    join c in currentProperties on p.PropertyName equals c.PropertyName into leftJoin
                    from _c in leftJoin.DefaultIfEmpty()
                    where

                        // Non-identifying properties only
                        !p.IsIdentifying

                        // Exclude boilerplate "id" property
                        && !p.PropertyName.Equals("Id")

                        // Exclude inherited properties
                        && !p.IsInheritedProperty()
                    orderby p.PropertyName
                    select new
                    {
                        UnderlyingProperty = p,
                        CurrentProperty = _c
                    })
                .ToList();

            foreach (var propertyPair in propertyPairs)
            {
                var property = propertyPair.CurrentProperty;

                if (property.IsSynchronizable())
                {
                    if (resourceClass.IsDescriptorEntity())
                    {
                        if (!property.IsInheritedProperty())
                        {
                            yield return AssembleDerivedProperty(property);
                        }
                    }
                    else if (property.IsDirectDescriptorUsage)
                    {
                        yield return PropertyData.CreateStandardProperty(property);
                    }
                    else
                    {
                        yield return
                            property.HasAssociations()
                                ? PropertyData.CreateReferencedProperty(property)
                                : PropertyData.CreateStandardProperty(property);
                    }
                }
                else
                {
                    if (property.HasAssociations())
                    {
                        yield return property.IsDescriptorUsage
                            ? PropertyData.CreateStandardProperty(property)
                            : PropertyData.CreateReferencedProperty(property);
                    }
                    else
                    {
                        yield return PropertyData.CreateStandardProperty(property);
                    }
                }
            }
        }
    }
}

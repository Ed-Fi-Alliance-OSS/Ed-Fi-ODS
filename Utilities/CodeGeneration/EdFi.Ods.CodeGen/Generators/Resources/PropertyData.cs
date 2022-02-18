// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Generators.Resources
{
    public class PropertyData
    {
        private readonly Dictionary<string, string> _context;

        public PropertyData(ResourceProperty property)
        {
            Property = property;
            IsReferencedProperty = false;
            IsFirstProperty = false;
            IsLastProperty = false;
            Associations = new List<AssociationView>();
            ExtensionAssociations = new List<AssociationView>();

            _context = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get
            {
                if (_context.ContainsKey(key))
                {
                    return _context[key];
                }

                return null;
            }
            set { _context[key] = value; }
        }

        public ResourceProperty Property { get; }

        public bool IsReferencedProperty { get; set; }

        public bool IsFirstProperty { get; set; }

        public bool IsLastProperty { get; set; }

        public bool IsDerived { get; set; }

        public bool IsUnique
        {
            get { return Property.IsPersonOrUsi() && Property.IsIdentifying; }
        }

        public List<AssociationView> Associations { get; }

        public List<AssociationView> ExtensionAssociations { get; }

        private object AssembleOtherUnifiedChild(IEnumerable<AssociationView> associations)
        {
            return associations
                .OrderBy(y => y.Name)
                .Select(
                    y => new
                    {
                        ReferenceName = y.Name,
                        ReferenceFieldName = y.Name.ToCamelCase()
                    })
                .ToList();
        }

        public object Render()
        {
            AssociationView derivedBaseProperty = Property.DerivedBaseProperty();

            var derivedName = derivedBaseProperty != null
                ? derivedBaseProperty.OtherEntity.Name
                : null;

            var desc = this[ResourceRenderer.DescriptionOverride] != null
                ? this[ResourceRenderer.DescriptionOverride]
                    .ScrubForXmlDocumentation()
                : UniqueIdSpecification.IsUniqueId(Property.PropertyName)
                    ? string.Format(
                        "A unique alphanumeric code assigned to a {0}.",
                        Property.RemoveUniqueIdOrUsiFromPropertyName()
                            .ToLower())
                    : Property.Description.ScrubForXmlDocumentation();

            var propertyNamespacePrefix = Property.ProperCaseSchemaName() == null
                ? null
                : $"{Namespaces.Entities.Common.RelativeNamespace}.{Property.ProperCaseSchemaName()}.";

            return new
            {
                Description = desc,
                Misc = this[ResourceRenderer.MiscellaneousComment],
                JsonPropertyName = Property.JsonPropertyName,
                PropertyName = IsReferencedProperty
                    ? string.Format(
                        "backReference.{0} != null && backReference.{0}.{1}",
                        Property.EntityProperty.Entity.Aggregate.Name,
                        Property.PropertyName)
                    : Property.PropertyName,
                CSharpSafePropertyName = Property.PropertyName.MakeSafeForCSharpClass(Property.ParentFullName.Name),
                ParentName =
                    Property.EntityProperty.IsFromParent
                        ? Property.EntityProperty.Entity.Parent.Name
                        : Property.EntityProperty.Entity.Name,
                PropertyFieldName = Property.EntityProperty.Entity
                    .ResolvedEdFiEntityName()
                    .ToCamelCase(),
                PropertyType = Property.PropertyType.ToCSharp(true),
                IsFirstProperty = IsFirstProperty,
                IsLastProperty = IsLastProperty,
                IsUnique = IsUnique,
                NumericAttribute = Property.ToRangeAttributeCSharp(),
                IsDateOnlyProperty = Property.PropertyType.DbType == DbType.Date,
                IsTimeSpanProperty = Property.PropertyType.DbType == DbType.Time,
                ClassName = this[ResourceRenderer.ClassName]
                            ?? Property.EntityProperty.Entity
                                .ResolvedEdFiEntityName(),
                UnifiedKeys = Associations.Any()
                    ? AssembleOtherUnifiedChild(Associations)
                    : null,
                UnifiedExtensions = ExtensionAssociations.Any()
                    ? AssembleOtherUnifiedChild(ExtensionAssociations)
                    : null,
                ImplicitPropertyName = Associations.Any()
                    ? Associations.OrderByDescending(x => x.IsRequired)
                        .First()
                        .Name
                    : null,
                ImplicitNullable = Property.PropertyType.IsNullableCSharpType()
                    ? ".GetValueOrDefault()"
                    : null,
                ParentPropertyName = this[ResourceRenderer.ParentPropertyName],
                DerivedName = derivedName,
                PropertyNamespacePrefix = propertyNamespacePrefix,
                NullPropertyPrefix = Property.EntityProperty.Entity.IsEntityExtension
                    ? $"{propertyNamespacePrefix}I{Property.EntityProperty.Entity.Name}."
                    : $"{propertyNamespacePrefix}I{Property.EntityProperty.Entity.ResolvedEdFiEntityName()}.",
                IsNullable = Property.PropertyType.IsNullable
            };
        }

        public static object CreatePropertyDto(PropertyData propertyData)
        {
            switch (propertyData[ResourceRenderer.RenderType])
            {
                case ResourceRenderer.RenderNull:

                    return new
                    {
                        Null = new { },
                        Property = propertyData.Render()
                    };
                case ResourceRenderer.RenderNullLookup:

                    return new
                    {
                        NullLookup = new { },
                        Property = propertyData.Render()
                    };
                case ResourceRenderer.RenderStandard:

                    return new
                    {
                        Standard = new { },
                        Property = propertyData.Render()
                    };
                case ResourceRenderer.RenderUnified:

                    return new
                    {
                        UnifiedType = new { },
                        Property = propertyData.Render()
                    };
                case ResourceRenderer.RenderUsi:

                    return new
                    {
                        Usi = new { },
                        Property = propertyData.Render()
                    };
                case ResourceRenderer.RenderReferenced:

                    return new
                    {
                        Referenced = new { },
                        Property = propertyData.Render()
                    };
                case ResourceRenderer.RenderDerived:

                    return new
                    {
                        Property = propertyData.Render(),
                        Derived = new { }
                    };
                default:

                    return new {Property = propertyData.Render()};
            }
        }

        public static PropertyData CreateStandardProperty(ResourceProperty property)
        {
            var data = new PropertyData(property);
            data[ResourceRenderer.RenderType] = ResourceRenderer.RenderStandard;

            data[ResourceRenderer.MiscellaneousComment] = property.IsLookup
                ? "// NOT in a reference, IS a lookup column "
                : "// NOT in a reference, NOT a lookup column ";

            return data;
        }

        public static PropertyData CreateDerivedProperty(ResourceProperty property)
        {
            var data = new PropertyData(property);
            data[ResourceRenderer.RenderType] = ResourceRenderer.RenderDerived;

            data[ResourceRenderer.MiscellaneousComment] = property.IsLookup
                ? "// NOT in a reference, IS a lookup column "
                : "// NOT in a reference, NOT a lookup column ";

            data.IsDerived = true;

            return data;
        }

        public static PropertyData CreateReferencedProperty(
            ResourceProperty property,
            string desc = null,
            string className = null,
            ResourceClassBase resource = null)
        {
            var propertyData = new PropertyData(property);

            var associations = resource == null || !resource.References.Any()
                ? property.EntityProperty.IncomingAssociations
                : resource.References.Where(
                        r =>
                            r.Properties.Contains(
                                property,
                                ModelComparers.ResourcePropertyNameOnly))
                    .Select(r => r.Association)
                    .ToList();

            // we want to prioritize identifiers that are not optional.
            var association =
                associations
                    .OrderBy(x => x.ThisProperties.Any(y => y.PropertyType.IsNullable))
                    .ThenBy(x => x.Name)
                    .FirstOrDefault(
                        x => x.PropertyMappingByThisName.ContainsKey(property.PropertyName)
                             || x.PropertyMappingByThisName.ContainsKey(property.EntityProperty.PropertyName));

            var parent = association != null
                ? association.PropertyMappingByThisName.ContainsKey(property.PropertyName)
                    ? association.PropertyMappingByThisName[property.PropertyName]
                        .OtherProperty
                    : association.PropertyMappingByThisName.ContainsKey(property.EntityProperty.PropertyName)
                        ? association.PropertyMappingByThisName[property.EntityProperty.PropertyName]
                            .OtherProperty
                        : null
                : null;

            string parentPropertyName = parent != null
                ? property.IsLookup
                    ? parent.PropertyName.TrimSuffix("Id")
                    : UniqueIdSpecification.GetUniqueIdPropertyName(parent.PropertyName)
                : property.ParentFullName.Name;

            propertyData[ResourceRenderer.ParentPropertyName] = UniqueIdSpecification.GetUniqueIdPropertyName(parentPropertyName);

            if (className != null)
            {
                propertyData[ResourceRenderer.ClassName] = className;
            }

            if (desc != null)
            {
                propertyData[ResourceRenderer.DescriptionOverride] = desc;
            }

            if (associations.Any())
            {
                propertyData.Associations.AddRange(associations);
            }

            if (property.IsLookup)
            {
                propertyData[ResourceRenderer.RenderType] = ResourceRenderer.RenderUnified;

                propertyData[ResourceRenderer.MiscellaneousComment] =
                    string.Format(
                        "// IS in a reference ({0}.{1}Id), IS a lookup column ",
                        className ?? property.EntityProperty.Entity.ResolvedEdFiEntityName(),
                        property.PropertyName);
            }
            else
            {
                propertyData[ResourceRenderer.MiscellaneousComment] = "// IS in a reference, NOT a lookup column ";
                propertyData[ResourceRenderer.RenderType] = ResourceRenderer.RenderReferenced;
            }

            return propertyData;
        }

        public static PropertyData CreateUsiPrimaryKey(ResourceProperty property)
        {
            var data = new PropertyData(property);
            data[ResourceRenderer.RenderType] = ResourceRenderer.RenderUsi;
            data[ResourceRenderer.MiscellaneousComment] = "// NOT in a reference, NOT a lookup column ";

            return data;
        }

        public static PropertyData CreateNullProperty(ResourceProperty property)
        {
            var propertyData = CreateStandardProperty(property);

            propertyData[ResourceRenderer.RenderType] =
                property.IsLookup
                    ? ResourceRenderer.RenderNullLookup
                    : ResourceRenderer.RenderNull;

            return propertyData;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly IPersonEntitySpecification _personEntitySpecification;
        private readonly Dictionary<string, string> _context;

        public PropertyData(ResourceProperty property, IPersonEntitySpecification personEntitySpecification)
        {
            _personEntitySpecification = personEntitySpecification;
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

        public bool PropertyDefaultHasDomainMeaning
        {
            get
            {
                return !Property.PropertyType.IsNullable && !Property.IsServerAssigned && Property.CSharpDefaultHasDomainMeaning();
            }
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
                : UniqueIdConventions.IsUniqueId(Property.PropertyName)
                    ? string.Format(
                        "A unique alphanumeric code assigned to a {0}.",
                        Property.RemoveUniqueIdOrUsiFromPropertyName()
                            .ToLower())
                    : Property.Description.ScrubForXmlDocumentation();

            var propertyNamespacePrefix = Property.ProperCaseSchemaName() == null
                ? null
                : $"{Namespaces.Entities.Common.RelativeNamespace}.{Property.ProperCaseSchemaName()}.";

            var parentName =
                Property.EntityProperty.IsFromParent
                    ? Property.EntityProperty.Entity.Parent.Name
                    : Property.EntityProperty.Entity.Name;

            var propertyName = IsReferencedProperty
                    ? string.Format(
                        "backReference.{0} != null && backReference.{0}.{1}",
                        Property.EntityProperty.Entity.Aggregate.Name,
                        Property.PropertyName)
                    : Property.PropertyName;

            if (Property.IsLocallyDefined && Property.IsUnified() && Property.PropertyType.IsNullable)
            {
                throw new Exception(
                    $"A locally defined property that participates in key unification (through references) cannot be optional (as it implies the use of the property to allow for capturing partially defined references). Review the model (Resource: '{parentName}', Property: '{propertyName}') and either make the property required or change the name of the property to prevent unification.");
            }

            return new
            {
                Description = desc,
                Misc = this[ResourceRenderer.MiscellaneousComment],
                StringComparer = this[ResourceRenderer.StringComparer],
                JsonPropertyName = Property.JsonPropertyName,
                JsonIgnore = Property.JsonIgnore,
                PropertyName = propertyName,
                CSharpSafePropertyName = Property.PropertyName.MakeSafeForCSharpClass(Property.ParentFullName.Name),
                ParentName = parentName,
                PropertyFieldName = propertyName.ToCamelCase(),
                PropertyType = Property.PropertyType.ToCSharp(true),
                IsFirstProperty = IsFirstProperty,
                IsLastProperty = IsLastProperty,
                IsUnique = IsUnique,
                IsUniqueId = UniqueIdConventions.IsUniqueId(propertyName),
                UniqueIdPersonType = UniqueIdConventions.IsUniqueId(propertyName) 
                    ? Resources.PersonEntitySpecification.GetUniqueIdPersonType(propertyName)
                    : null,
                IsDateOnlyProperty = Property.PropertyType.DbType == DbType.Date,
                IsTimeSpanProperty = Property.PropertyType.DbType == DbType.Time,
                IsString = Property.PropertyType.IsString(),
                MaxLength = Property.PropertyType.IsString() ? (int?) Property.PropertyType.MaxLength : null,
                MinLength = (Property.PropertyType.IsString() && Property.PropertyType.MinLength > 0) 
                    ? (int?) Property.PropertyType.MinLength 
                    : null,
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
                    ? Associations.OrderByDescending(x => x.Association.IsRequired)
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
                IsNullable = Property.PropertyType.IsNullable,
                PropertyIsUnifiedAndLocallyDefined = Property.IsUnified() && Property.IsLocallyDefined,
                PropertyDefaultHasDomainMeaning = PropertyDefaultHasDomainMeaning,
                IsRequiredWithNonDefault = !Property.PropertyType.IsNullable
                    && !Property.IsServerAssigned
                    && !Property.CSharpDefaultHasDomainMeaning(),
                NoWhiteSpace = Property.PropertyType.IsString()
                    && (Property.IsIdentifying || IsUniqueIdPropertyOnPersonEntity(Property.EntityProperty.Entity, Property.EntityProperty)),
                ValidationReferenceName = UniqueIdConventions.IsUSI(Property.PropertyName)
                    ? _personEntitySpecification.GetUSIPersonType(Property.PropertyName)
                    : null,
                RangeAttribute = Property.EntityProperty.ToRangeAttributeCSharp(),
                DisplayName = (propertyName == Property.Parent.Name) ? propertyName : null,
            };
        }

        private bool IsUniqueIdPropertyOnPersonEntity(Entity entity, EntityProperty p)
        {
            return UniqueIdConventions.IsUniqueId(p.PropertyName)
                && entity.Name == _personEntitySpecification.GetUniqueIdPersonType(p.PropertyName);
        }

        public static object CreatePropertyDto(PropertyData propertyData)
        {
            switch (propertyData[ResourceRenderer.RenderType])
            {
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

        public static PropertyData CreateStandardProperty(ResourceProperty property, IPersonEntitySpecification personEntitySpecification)
        {
            var data = new PropertyData(property, personEntitySpecification);
            data[ResourceRenderer.RenderType] = ResourceRenderer.RenderStandard;

            data[ResourceRenderer.StringComparer] = property.IsDescriptorUsage
                ? "StringComparer.OrdinalIgnoreCase"
                : property.PropertyType.IsString()
                    ? "GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer"
                    : null;

            data[ResourceRenderer.MiscellaneousComment] = property.IsDescriptorUsage
                ? "// NOT in a reference, IS a lookup column "
                : "// NOT in a reference, NOT a lookup column ";

            return data;
        }

        public static PropertyData CreateDerivedProperty(ResourceProperty property, IPersonEntitySpecification personEntitySpecification)
        {
            var data = new PropertyData(property, personEntitySpecification);
            data[ResourceRenderer.RenderType] = ResourceRenderer.RenderDerived;

            data[ResourceRenderer.StringComparer] = property.IsDescriptorUsage
                ? "StringComparer.OrdinalIgnoreCase"
                : property.PropertyType.IsString()
                    ? "GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer"
                    : null;

            data[ResourceRenderer.MiscellaneousComment] = property.IsDescriptorUsage
                ? "// NOT in a reference, IS a lookup column "
                : "// NOT in a reference, NOT a lookup column ";

            data.IsDerived = true;

            return data;
        }

        public static PropertyData CreateReferencedProperty(
            ResourceProperty property,
            IPersonEntitySpecification personEntitySpecification,
            string desc = null,
            string className = null,
            ResourceClassBase resource = null)
        {
            var propertyData = new PropertyData(property, personEntitySpecification);

            var associations = resource == null || !resource.References.Any()
                ? property.EntityProperty.IncomingAssociations
                : resource.References.Where(
                        r =>
                            r.AbstractionProperties.Contains(
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
                ? property.IsDescriptorUsage
                    ? parent.PropertyName.TrimSuffix("Id")
                    : UniqueIdConventions.GetUniqueIdPropertyName(parent.PropertyName)
                : property.ParentFullName.Name;

            propertyData[ResourceRenderer.ParentPropertyName] = UniqueIdConventions.GetUniqueIdPropertyName(parentPropertyName);

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

            if (property.IsDescriptorUsage)
            {
                propertyData[ResourceRenderer.RenderType] = ResourceRenderer.RenderUnified;

                propertyData[ResourceRenderer.StringComparer] = "StringComparer.OrdinalIgnoreCase";

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
                
                propertyData[ResourceRenderer.StringComparer] = 
                    property.PropertyType.IsString()
                        ? "GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer"
                        : null;
            }

            return propertyData;
        }

        public static PropertyData CreateUsiPrimaryKey(ResourceProperty property, IPersonEntitySpecification personEntitySpecification)
        {
            var data = new PropertyData(property, personEntitySpecification);
            data[ResourceRenderer.RenderType] = ResourceRenderer.RenderUsi;
            data[ResourceRenderer.MiscellaneousComment] = "// NOT in a reference, NOT a lookup column ";

            return data;
        }
    }
}

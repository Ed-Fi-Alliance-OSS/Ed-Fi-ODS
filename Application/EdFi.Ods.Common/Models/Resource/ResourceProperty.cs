// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Models.Resource
{
    public class PropertyCharacteristics
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PropertyCharacteristics"/> class.
        /// </summary>
        public PropertyCharacteristics(
            bool isLookup,
            bool isDirectLookup,
            bool isIdentifying,
            bool isLocallyDefined,
            bool isServerAssigned,
            FullName? lookupEntityName)
        {
            IsLookup = isLookup;
            IsDirectLookup = isDirectLookup;
            IsIdentifying = isIdentifying;
            IsLocallyDefined = isLocallyDefined;
            IsServerAssigned = isServerAssigned;
            LookupEntityName = lookupEntityName;
        }

        public bool IsLookup { get; }

        public bool IsDirectLookup { get; }

        public bool IsIdentifying { get; }

        public bool IsLocallyDefined { get; }

        public bool IsServerAssigned { get; }

        public FullName? LookupEntityName { get; }
    }

    public class ResourceProperty : ResourceMemberBase
    {
        private readonly ResourceMemberBase _containingMember;
        private Lazy<IReadOnlyList<ResourceProperty>> _unifiedProperties;
        private Lazy<Resource> _descriptorResource;

        public ResourceProperty(ResourceClassBase resourceClass, EntityProperty entityProperty)
            : this(null, resourceClass, entityProperty) { }

        public ResourceProperty(ResourceMemberBase containingMember, ResourceClassBase resourceClass, EntityProperty entityProperty)
            : base(resourceClass, GetResourcePropertyName(entityProperty))
        {
            _containingMember = containingMember;
            
            EntityProperty = entityProperty;

            // Assign property characteristics
            IsDescriptorUsage = entityProperty.IsDescriptorUsage;
            IsDirectDescriptorUsage = entityProperty.IsDirectDescriptorUsage;

            IsIdentifying = entityProperty.IsIdentifying
                            || UniqueIdSpecification.TryGetUniqueIdPersonType(entityProperty.PropertyName, out string personType)
                            && personType == resourceClass.Name;

            IsLocallyDefined = entityProperty.IsLocallyDefined;
            IsServerAssigned = entityProperty.IsServerAssigned;

            DescriptorName = entityProperty.DescriptorEntity?.Name;

            PropertyType = GetResourcePropertyType(entityProperty);
            Description = entityProperty.Description;
            IsDeprecated = entityProperty.IsDeprecated;
            DeprecationReasons = entityProperty.DeprecationReasons;

            // Cannot just use resourceClass.Name here because properties may be from a base class which
            // produces a different result.  Base class properties should retain their lineage
            // when "merged" into the resource model.
            ParentFullName = EntityProperty.Entity.FullName;

            InitializeLazyMembers();
        }

        public ResourceProperty(
            ResourceClassBase resourceClass,
            string propertyName,
            PropertyType propertyType,
            PropertyCharacteristics characteristics,
            string description)
            : base(resourceClass, propertyName, propertyName.ToCamelCase())
        {
            PropertyType = propertyType;
            Description = description;
            IsDeprecated = resourceClass.IsDeprecated;
            DeprecationReasons = resourceClass.DeprecationReasons;

            // Assign property characteristics
            IsDirectDescriptorUsage = characteristics.IsDirectLookup;
            IsIdentifying = characteristics.IsIdentifying;
            IsLocallyDefined = characteristics.IsLocallyDefined;
            IsServerAssigned = characteristics.IsServerAssigned;

            DescriptorName = characteristics.LookupEntityName?.Name;

            if (resourceClass.Entity != null)
            {
                ParentFullName = resourceClass.Entity.FullName;
            }

            InitializeLazyMembers();
        }

        private void InitializeLazyMembers()
        {
            _unifiedProperties = new Lazy<IReadOnlyList<ResourceProperty>>(
                () =>
                {
                    if (ResourceClass.UnifiedPropertiesByPropertyName.Value.TryGetValue(PropertyName, out var unifiedProperties))
                    {
                        return unifiedProperties.Except(new[] {this}).ToArray();
                    }

                    return Array.Empty<ResourceProperty>();
                });

            _descriptorResource = new Lazy<Resource>(
                () => EntityProperty.DescriptorEntity == null
                    ? null
                    : ResourceClass?.ResourceModel?.GetResourceByFullName(EntityProperty.DescriptorEntity.FullName));
        }
        
        public string DescriptorName { get; }

        [Obsolete("Use DescriptorName instead.")]
        public string LookupTypeName => DescriptorName;
        
        /// <summary>
        /// For descriptors, gets the <see cref="Resource" /> representing the descriptor referenced by the property;
        /// otherwise <b>null</b>.
        /// </summary>
        public Resource DescriptorResource { get => _descriptorResource.Value; }

        public EntityProperty EntityProperty { get; }

        public PropertyType PropertyType { get; }

        public string Description { get; }

        public bool IsDeprecated { get; set; }

        public string[] DeprecationReasons { get; set; }

        public bool IsDirectDescriptorUsage { get; }
        
        [Obsolete("Use IsDirectDescriptorUsage instead.")]
        public bool IsDirectLookup
        {
            get => IsDirectDescriptorUsage;
        }

        /// <summary>
        /// Indicates whether the property is part of the identity of the resource.
        /// </summary>
        /// <remarks>When based upon an <see cref="EntityProperty" /> instance, the property is treated as identifying in 
        /// the resource model when it is a UniqueId property on a resource matching the convention of "{resourceName}UniqueId".</remarks>
        public bool IsIdentifying { get; }

        public bool IsLocallyDefined { get; }

        [Obsolete("Use IsDescriptorUsage instead.")]
        public bool IsLookup
        {
            get => IsDescriptorUsage;
        }

        /// <summary>
        /// Indicates whether the property represents the usage of a descriptor.
        /// </summary>
        public bool IsDescriptorUsage { get; }
        
        public bool IsServerAssigned { get; }

        /// <summary>
        /// Gets the FullName of the resource containing this property, or the FullName of the 
        /// containing <see cref="Entity"/> if the current property was constructed from 
        /// an <see cref="EntityProperty"/>.
        /// </summary>
        public override FullName ParentFullName { get; }

        /// <summary>
        /// Indicates whether the property is based on an <see cref="EntityProperty"/> inherited from a base entity type.
        /// </summary>
        public bool IsInherited
        {
            get
            {
                if (EntityProperty == null)
                {
                    return false;
                }

                return Parent.Entity.InheritedProperties
                             .Contains(EntityProperty, ModelComparers.EntityPropertyNameOnly);
            }
        }

        private PropertyType GetResourcePropertyType(EntityProperty property)
        {
            if (property.IsDescriptorUsage)
            {
                // NOTE: the property length for lookups has changed in data standard 3.0.
                // The new formula is:  255 (namespace max length) + 1 (separator length) + 50 (code value max length), or 306
                return new PropertyType(
                    DbType.String,
                    306,
                    isNullable: property.PropertyType.IsNullable);
            }

            var propertyType = IsUsiWithTransformedResourcePropertyName(property)
                ? GetBasePersonUniqueIdPropertyType(property)
                : property.PropertyType;

            return new PropertyType(
                propertyType.DbType,
                propertyType.MaxLength,
                propertyType.Precision,
                propertyType.Scale,
                propertyType.IsNullable,
                propertyType.MinValue,
                propertyType.MaxValue);
        }

        private static PropertyType GetBasePersonUniqueIdPropertyType(EntityProperty property)
        {
            return property.DefiningProperty.Entity.Properties
                .Where(
                    x => !UniqueIdSpecification.IsUSI(x.PropertyName)
                        && PersonEntitySpecification.IsPersonIdentifier(x.PropertyName))
                .Select(x => x.PropertyType)
                .Single();
        }

        private static string GetResourcePropertyName(EntityProperty property)
        {
            // Simplistic conversion using conventions
            if (property.IsDescriptorUsage)
            {
                return property.PropertyName.TrimSuffix("Id");
            }

            // Convert USIs to UniqueIds everywhere but on the people
            if (UniqueIdSpecification.IsUSI(property.PropertyName)
                && !PersonEntitySpecification.IsPersonEntity(property.Entity.Name))
            {
                return property.PropertyName.Replace("USI", "UniqueId");
            }

            return property.PropertyName;
        }

        private bool IsUsiWithTransformedResourcePropertyName(EntityProperty property)
        {
            //Not: Use C# 7 '_' wildcard instead when available.
            string notUsed;

            //If the resource property name was flipped to a UniqueId for this USI property
            return UniqueIdSpecification.IsUSI(property.PropertyName)
                   && UniqueIdSpecification.TryGetUniqueIdPersonType(PropertyName, out notUsed);
        }

        /// <inheritdoc cref="ResourceMemberBase.JsonPath" />
        public override string JsonPath
        {
            get
            {
                if (_containingMember == null)
                {
                    return base.JsonPath;
                }

                return $"{_containingMember?.JsonPath ?? Parent.JsonPath}.{JsonPropertyName}";
            }
        }

        /// <summary>
        /// Gets any other <see cref="ResourceProperty" /> instances present on other references
        /// that are <em>unifying properties</em> -- properties whose values (if present) must all
        /// match because they are unified into a single database column for persistence.
        /// </summary>
        public IReadOnlyList<ResourceProperty> UnifiedProperties 
        {
            get => _unifiedProperties.Value;
        }
    }
}

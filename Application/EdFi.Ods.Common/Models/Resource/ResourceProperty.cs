// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Linq;
using System.Xml;
using EdFi.Common.Extensions;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Common.Utils.Extensions;

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
        private ResourceMemberBase _containingMember;

        public ResourceProperty(ResourceClassBase resourceClass, EntityProperty entityProperty)
            : this(null, resourceClass, entityProperty) { }

        public ResourceProperty(ResourceMemberBase containingMember, ResourceClassBase resourceClass, EntityProperty entityProperty)
            : base(resourceClass, GetResourcePropertyName(entityProperty))
        {
            _containingMember = containingMember;
            
            EntityProperty = entityProperty;

            string personType;

            // Assign property characteristics
            IsLookup = entityProperty.IsLookup;
            IsDirectLookup = entityProperty.IsDirectLookup;

            IsIdentifying = entityProperty.IsIdentifying
                            || UniqueIdSpecification.TryGetUniqueIdPersonType(entityProperty.PropertyName, out personType)
                            && personType == resourceClass.Name;

            IsLocallyDefined = entityProperty.IsLocallyDefined;
            IsServerAssigned = entityProperty.IsServerAssigned;

            LookupTypeName = entityProperty.LookupEntity == null
                ? null
                : entityProperty.LookupEntity.Name;

            DescriptorResource = entityProperty.LookupEntity == null
                ? null
                : resourceClass?.ResourceModel?.GetResourceByFullName(entityProperty.LookupEntity.FullName);

            PropertyType = GetResourcePropertyType(entityProperty);
            Description = entityProperty.Description;
            IsDeprecated = entityProperty.IsDeprecated;
            DeprecationReasons = entityProperty.DeprecationReasons;

            // Cannot just use resourceClass.Name here because properties may be from a base class which
            // produces a different result.  Base class properties should retain their lineage
            // when "merged" into the resource model.
            ParentFullName = EntityProperty.Entity.FullName;
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
            IsDirectLookup = characteristics.IsDirectLookup;
            IsIdentifying = characteristics.IsIdentifying;
            IsLocallyDefined = characteristics.IsLocallyDefined;
            IsServerAssigned = characteristics.IsServerAssigned;

            LookupTypeName = characteristics.LookupEntityName == null
                ? null
                : characteristics.LookupEntityName.Value.Name;

            DescriptorResource = characteristics.LookupEntityName == null
                ? null
                : resourceClass?.ResourceModel?.GetResourceByFullName(characteristics.LookupEntityName.GetValueOrDefault());
            
            if (resourceClass.Entity != null)
            {
                ParentFullName = resourceClass.Entity.FullName;
            }
        }

        public string LookupTypeName { get; }
        
        /// <summary>
        /// For descriptors, gets the <see cref="Resource" /> representing the descriptor referenced by the property;
        /// otherwise <b>null</b>.
        /// </summary>
        public Resource DescriptorResource { get; }

        public EntityProperty EntityProperty { get; }

        public PropertyType PropertyType { get; }

        public string Description { get; }

        public bool IsDeprecated { get; set; }

        public string[] DeprecationReasons { get; set; }

        public bool IsDirectLookup { get; }

        /// <summary>
        /// Indicates whether the property is part of the identity of the resource.
        /// </summary>
        /// <remarks>When based upon an <see cref="EntityProperty" /> instance, the property is treated as identifying in 
        /// the resource model when it is a UniqueId property on a resource matching the convention of "{resourceName}UniqueId".</remarks>
        public bool IsIdentifying { get; }

        public bool IsLocallyDefined { get; }

        public bool IsLookup { get; }

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
            if (property.IsLookup)
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
                propertyType.IsNullable);
        }

        private static PropertyType GetBasePersonUniqueIdPropertyType(EntityProperty property)
        {
            //we need to go find the correct PropertyType information by looking through
            //the incoming associations for the ones that have the USI property
            //and walking those entities until we find the person type that is the base of this
            //property, then return the entity's unique id property's property type from there.
            return GetNestedPersonEntityProperty(property, property.PropertyName)
                  .Entity.Properties
                  .Where(x => !UniqueIdSpecification.IsUSI(x.PropertyName) && PersonEntitySpecification.IsPersonIdentifier(x.PropertyName))
                  .Select(x => x.PropertyType)
                  .Single();
        }

        private static string GetResourcePropertyName(EntityProperty property)
        {
            // Simplistic conversion using conventions
            if (property.IsLookup)
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

        private static EntityProperty GetNestedPersonEntityProperty(EntityProperty entityProperty, string entityPropertyName)
        {
            if (PersonEntitySpecification.IsPersonEntity(entityProperty.Entity.Name))
            {
                return entityProperty;
            }

            var interestingProperties = entityProperty.IncomingAssociations
                                                      .Select(
                                                           x => x.PropertyMappingByThisName[entityPropertyName]
                                                                 .OtherProperty)
                                                      .ToList();

            if (interestingProperties.None())
            {
                return null;
            }

            return interestingProperties.Select(x => GetNestedPersonEntityProperty(x, x.PropertyName))
                                        .FirstOrDefault(x => x != null);
        }

        private bool IsUsiWithTransformedResourcePropertyName(EntityProperty property)
        {
            //Not: Use C# 7 '_' wildcard instead when available.
            string notUsed;

            //If the resource property name was flipped to a UniqueId for this USI property
            return UniqueIdSpecification.IsUSI(property.PropertyName)
                   && UniqueIdSpecification.TryGetUniqueIdPersonType(PropertyName, out notUsed);
        }

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
    }
}

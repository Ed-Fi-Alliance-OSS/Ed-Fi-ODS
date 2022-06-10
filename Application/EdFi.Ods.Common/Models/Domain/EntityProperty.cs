// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Models.Domain
{
    /// <summary>
    /// Represents a property on an <see cref="Entity"/>.
    /// </summary>
    public class EntityProperty : DomainPropertyBase
    {
        private Lazy<Entity> _descriptorEntity;
        private Lazy<bool> _isUnified;
        private Lazy<EntityProperty> _definingProperty;
        private Lazy<EntityProperty> _definingConcreteProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityProperty" /> class using the specified property definition.
        /// </summary>
        /// <param name="entityPropertyDefinition"></param>
        public EntityProperty(EntityPropertyDefinition entityPropertyDefinition)
            : base(entityPropertyDefinition)
        {
            // Property is locally defined when built directly from an entity property definition
            IsLocallyDefined = true;

            IsDeprecated = entityPropertyDefinition.IsDeprecated;
            DeprecationReasons = entityPropertyDefinition.DeprecationReasons;

            InitializeLazyMembers();
        }

        /// <summary>
        /// Actualizes a new instance of the <see cref="EntityProperty" /> class using the
        /// specified association property.
        /// </summary>
        /// <param name="associationProperty">The association property on which to base the entity property.</param>
        protected internal EntityProperty(AssociationProperty associationProperty)
            : base(new EntityPropertyDefinition
                   {
                       PropertyName = associationProperty.PropertyName,
                       PropertyType = associationProperty.PropertyType,
                       Description = associationProperty.Description,
                       IsIdentifying = associationProperty.IsIdentifying,
                       IsServerAssigned = associationProperty.IsServerAssigned,
                       ColumnNames = associationProperty.ColumnNameByDatabaseEngine,
                   })
        {
            // Property is NOT locally defined when built from an association property
            IsLocallyDefined = false;

            InitializeLazyMembers();
        }

        private void InitializeLazyMembers()
        { 
            // A property that is part of a "unified key" has multiple incoming associations
            _isUnified = new Lazy<bool>(
                () => IncomingAssociations.Count > 1);

            _definingProperty = new Lazy<EntityProperty>(() => GetDefiningProperty(restrictToConcreteEntity: false));
            
            _definingConcreteProperty = new Lazy<EntityProperty>(() => GetDefiningProperty(restrictToConcreteEntity: true));
            
            _descriptorEntity = new Lazy<Entity>(
                () =>
                {
                    if (DefiningConcreteProperty?.Entity?.IsDescriptorEntity == true && DefiningConcreteProperty.Entity != Entity)
                    {
                        return DefiningConcreteProperty.Entity;
                    }

                    return null;
                });
        }

        [Obsolete("Use IsDescriptorUsage.")]
        public bool IsLookup
        {
            get => IsDescriptorUsage;
        }
        
        /// <summary>
        /// Indicates whether the property represents the usage of a descriptor.
        /// </summary>
        public bool IsDescriptorUsage
        {
            get
            {
                return DescriptorEntity != null && !IncomingAssociations.Any(a => a.IsSelfReferencing);
            }
        }

        /// <summary>
        /// Gets the corresponding property in the base entity, if current entity is derived; otherwise <b>null</b>.
        /// </summary>
        public EntityProperty BaseProperty
        {
            get => Entity.BaseAssociation?.PropertyMappingByThisName[PropertyName].OtherProperty;
        }

        /// <summary>
        /// Indicates whether or not the property participates in key unification (is a property
        /// introduced by multiple associations, indicating deep referential integrity in
        /// the underlying model).
        /// </summary>
        public bool IsUnified => _isUnified.Value;

        /// <summary>
        /// Indicates whether the the property is a type or descriptor value that is directly referenced
        /// from the corresponding lookup entity (as opposed to migrated into the entity via an association
        /// from a non-lookup entity).
        /// </summary>
        [Obsolete("Use IsDirectDescriptorUsage instead.")]
        public bool IsDirectLookup => IsDirectDescriptorUsage;

        /// <summary>
        /// Indicates whether the the property is a descriptor value that is directly referenced
        /// from the corresponding descriptor entity (as opposed to migrated into the entity via an association
        /// from a non-descriptor entity).
        /// </summary>
        public bool IsDirectDescriptorUsage => IsDescriptorUsage && IncomingAssociations.Any(x => x.OtherEntity == DescriptorEntity);

        /// <summary>
        /// Gets the corresponding descriptor entity (if applicable); otherwise null.
        /// </summary>
        [Obsolete("Use DescriptorEntity instead.")]
        public Entity LookupEntity => DescriptorEntity;
        
        /// <summary>
        /// Gets the corresponding descriptor entity (if applicable); otherwise null.
        /// </summary>
        public Entity DescriptorEntity => _descriptorEntity.Value;

        /// <summary>
        /// Gets the associations that contribute the property to the current entity.
        /// </summary>
        public IList<AssociationView> IncomingAssociations
        {
            get
            {
                return Entity.IncomingAssociations.Where(
                                  a => a.ThisProperties.Any(p => p.PropertyName.EqualsIgnoreCase(PropertyName)))
                             .ToList();
            }
        }

        /// <summary>
        /// Indicates whether the property is defined by (and was migrated from) the parent entity.
        /// </summary>
        public bool IsFromParent => Entity.ParentAssociation != null
                                    && Entity.ParentAssociation.ThisProperties.Contains(this, ModelComparers.DomainPropertyNameOnly);

        /// <summary>
        /// Indicates whether the property is an identifying property inherited from the base type.
        /// </summary>
        public bool IsInheritedIdentifying => Entity.BaseAssociation != null
                                              && Entity.BaseAssociation.ThisProperties.Contains(this, ModelComparers.DomainPropertyNameOnly);

        /// <summary>
        /// Indicates whether the property is an identifying property inherited from the base type that has been renamed in the derived type.
        /// </summary>
        public bool IsInheritedIdentifyingRenamed
        {
            get
            {
                if (Entity.BaseAssociation == null)
                {
                    return false;
                }

                if (!IsIdentifying)
                {
                    return false;
                }

                PropertyMapping mapping;

                if (!Entity.BaseAssociation.PropertyMappingByThisName.TryGetValue(PropertyName, out mapping))
                {
                    throw new Exception(
                        string.Format(
                            "Unable to find property '{0}' in the base type association view of entity '{1}'.",
                            PropertyName,
                            Entity.Name));
                }

                // If names don't match, this property has been renamed
                return !mapping.ThisProperty.PropertyName.EqualsIgnoreCase(mapping.OtherProperty.PropertyName);
            }
        }

        /// <summary>
        /// Indicates whether a role name has been applied to the property as part of an incoming association.
        /// </summary>
        public bool HasRoleNameApplied
        {
            // TODO: GKM - May need to deal with detecting role names applied to the association, but with key unification removing the role name on a particular property.
            get { return IncomingAssociations.Any(av => !string.IsNullOrEmpty(av.RoleName)); }
        }

        /// <summary>
        /// Indicates whether or not the property is defined locally on an entity (or is defined as part of an association).
        /// </summary>
        public bool IsLocallyDefined { get; internal set; }

        /// <summary>
        /// Gets the <see cref="EntityProperty" /> where the property was originally defined in a concrete entity (i.e. it will not
        /// return the property of the abstract base entity). If the property is part of a foreign key relationship, the property
        /// returned will be a property associated with a different <see cref="Entity" />. 
        /// </summary>
        /// <remarks>
        /// For properties that are identifying properties of an abstract base type (e.g. descriptors,
        /// education organizations, student program associations, etc.), this will return the property of the concrete (derived)
        /// <see cref="Entity" />.
        /// </remarks>
        /// <seealso cref="DefiningProperty"/>
        public EntityProperty DefiningConcreteProperty
        {
            get => _definingConcreteProperty.Value;
        }

        /// <summary>
        /// Gets the <see cref="EntityProperty" /> where the property was originally defined in the model regardless of whether
        /// the original definition is in a concrete or abstract entity. If the property is part of a foreign key relationship, the property returned will be a property associated
        /// with a different <see cref="Entity" />. 
        /// </summary>
        /// <remarks>
        /// For properties that are identifying properties of an abstract base type (e.g. descriptors,
        /// education organizations, student program associations, etc.), this will return that property (rather than the property
        /// as it is represented in the concrete (derived) <see cref="Entity" />.
        /// </remarks>
        /// <seealso cref="DefiningConcreteProperty"/>
        public EntityProperty DefiningProperty
        {
            get => _definingProperty.Value;
        }

        private EntityProperty GetDefiningProperty(bool restrictToConcreteEntity)
        {
            if (IsLocallyDefined)
            {
                return this;
            }
            
            var currentProperty = this;

            while (currentProperty.IncomingAssociations.Any(a => 
                a.AssociationType == AssociationViewType.ManyToOne 
                || a.AssociationType == AssociationViewType.OneToOneIncoming
                // Follow relationship into the core Ed-Fi model from an extension
                || a.AssociationType == AssociationViewType.FromCore
                // Follow base type relationships if they don't originate there, or are explicitly allowed by caller
                || (a.AssociationType == AssociationViewType.FromBase 
                    && (a.OtherProperties.Any(p => !p.IsLocallyDefined) || !restrictToConcreteEntity))))
            {
                currentProperty = currentProperty.IncomingAssociations.First()
                    .PropertyMappingByThisName[currentProperty.PropertyName]
                    .OtherProperty;
            }

            return currentProperty;
        }
        
        /// <summary>
        /// Indicates whether the current property is deprecated.
        /// </summary>
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// Indicates reasons over the property when it is deprecated.
        /// </summary>
        public string[] DeprecationReasons { get; set; }

        public override string ToString() => PropertyName;
    }
}

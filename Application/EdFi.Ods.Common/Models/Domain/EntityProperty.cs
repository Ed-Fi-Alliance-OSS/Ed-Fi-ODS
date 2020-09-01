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
        private Lazy<Entity> _lookupEntity;
        private Lazy<bool> _isUnified;

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

            _lookupEntity = new Lazy<Entity>(
                () =>
                {
                    // Detached properties are not lookup properties
                    if (Entity == null)
                    {
                        return null;
                    }

                    // Is this property a TypeId or DescriptorId on the table?  If so, it's not a lookup property.
                    if (DescriptorEntitySpecification.IsEdFiDescriptorEntity(Entity.Name)
                        && PropertyName == Entity.Name + "Id") // TODO: Embedded convention - Types/descriptor properties use entity name + "Id" suffix
                    {
                        return null;
                    }

                    var currentAssociation = IncomingAssociations.FirstOrDefault(
                        x =>
                            x.AssociationType == AssociationViewType.FromBase
                            || x.AssociationType == AssociationViewType.OneToOneIncoming
                            || x.AssociationType == AssociationViewType.ManyToOne

                            // Prevent processing self-recursive relationships with key unification on current property (prevent endless loop)
                            && !(x.IsSelfReferencing && PropertyName.EqualsIgnoreCase(
                                     x.PropertyMappingByThisName[PropertyName]
                                      .OtherProperty.PropertyName)));

                    if (currentAssociation == null)
                    {
                        return null;
                    }

                    var currentThisProperty = this;

                    while (currentAssociation != null)
                    {
                        var otherProperty = currentAssociation.PropertyMappingByThisName[currentThisProperty.PropertyName]
                                                              .OtherProperty;

                        if (ModelComparers.EntityProperty.Equals(currentThisProperty, otherProperty))
                        {
                            throw new Exception(
                                "Association property mapping endpoints refer to the same property.");
                        }

                        currentThisProperty = otherProperty;

                        // Stop looking if we've hit a lookup table (Type or Descriptor)
                        if (currentThisProperty.Entity.IsLookup)
                        {
                            break;
                        }

                        currentAssociation = otherProperty.IncomingAssociations.FirstOrDefault(
                            x =>
                                x.AssociationType == AssociationViewType.FromBase
                                || x.AssociationType == AssociationViewType.OneToOneIncoming
                                || x.AssociationType == AssociationViewType.ManyToOne
                                && !(x.IsSelfReferencing && currentThisProperty.PropertyName.EqualsIgnoreCase(
                                         x.PropertyMappingByThisName[
                                               currentThisProperty
                                                  .PropertyName]
                                          .OtherProperty
                                          .PropertyName)));
                    }

                    return
                        currentThisProperty.Entity.IsLookup
                        && currentThisProperty.Entity.Aggregate != Entity.Aggregate
                            ? currentThisProperty.Entity
                            : null;
                });
        }

        public bool IsLookup
        {
            get
            {
                // This prevents a known inconsistency in the Ed-Fi ODS from being reported as a descriptor lookup
                if (PropertyName == "PriorDescriptorId") // TODO: Embedded convention - hardcoded logic
                {
                    return false;
                }

                return LookupEntity != null
                       && DescriptorEntitySpecification.IsEdFiDescriptorEntity(LookupEntity.Name);
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
        public bool IsDirectLookup => IsLookup && IncomingAssociations.Any(x => x.OtherEntity == LookupEntity);

        /// <summary>
        /// Gets the type or descriptor lookup entity (if applicable); otherwise null.
        /// </summary>
        public Entity LookupEntity => _lookupEntity.Value;

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
        /// Indicates whether the current property is deprecated.
        /// </summary>
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// Indicates reasons over the property when it is deprecated.
        /// </summary>
        public string[] DeprecationReasons { get; set; }
    }
}

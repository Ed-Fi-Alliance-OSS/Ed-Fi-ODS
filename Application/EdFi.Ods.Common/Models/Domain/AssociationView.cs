// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Models.Domain
{
    public class AssociationView : IHasNameContext
    {
        private static readonly IReadOnlyList<PropertyMapping> EmptyPropertyMappingList
            = new PropertyMapping[0];
        private readonly DomainModel _domainModel;
        private readonly Lazy<ForeignKeyNameParts> _foreignKeyNameParts;
        private readonly bool _isPrimaryEntity;
        private readonly Lazy<EntityProperty[]> _otherProperties;
        private readonly Lazy<AssociationProperty[]> _otherAssociationProperties;

        private readonly Lazy<IReadOnlyList<PropertyMapping>> _propertyMappings;
        private readonly Lazy<IReadOnlyDictionary<string, PropertyMapping>> _propertyMappingsByOtherName;
        private readonly Lazy<IReadOnlyDictionary<string, PropertyMapping>> _propertyMappingsByThisName;

        private readonly Lazy<EntityProperty[]> _thisProperties;
        private readonly Lazy<AssociationProperty[]> _thisAssociationProperties;
        private readonly Lazy<bool> _isSoftDependency;

        private bool _backReferencesAlreadyInitialized;

        internal AssociationView(DomainModel domainModel, Association association, bool isPrimaryEntity)
        {
            _domainModel = domainModel;
            Association = association;
            _isPrimaryEntity = isPrimaryEntity;

            _thisProperties = new Lazy<EntityProperty[]>(
                () => _thisAssociationProperties.Value.Select(ap => ap.EntityProperty).ToArray());

            _otherProperties = new Lazy<EntityProperty[]>(
                () => _otherAssociationProperties.Value.Select(ap => ap.EntityProperty).ToArray());

            _thisAssociationProperties = new Lazy<AssociationProperty[]>(
                () =>
                {
                    InitializeAssociationPropertyEntityBackReferences();

                    return _isPrimaryEntity
                        ? association.PrimaryEntityAssociationProperties
                        : association.SecondaryEntityAssociationProperties;
                });

            _otherAssociationProperties = new Lazy<AssociationProperty[]>(
                () =>
                {
                    InitializeAssociationPropertyEntityBackReferences();

                    return _isPrimaryEntity
                        ? association.SecondaryEntityAssociationProperties
                        : association.PrimaryEntityAssociationProperties;
                });

            _propertyMappings = new Lazy<IReadOnlyList<PropertyMapping>>(
                () =>
                    _thisProperties.Value.Select((p, i) => new PropertyMapping(p, _otherProperties.Value[i]))
                                   .ToList());

            _propertyMappingsByThisName = new Lazy<IReadOnlyDictionary<string, PropertyMapping>>(
                () =>
                    new ReadOnlyDictionary<string, PropertyMapping>(
                        _propertyMappings.Value.ToDictionary(
                            m => m.ThisProperty.PropertyName,
                            m => m,
                            StringComparer.InvariantCultureIgnoreCase)));

            _propertyMappingsByOtherName = new Lazy<IReadOnlyDictionary<string, PropertyMapping>>(
                () =>
                    new ReadOnlyDictionary<string, PropertyMapping>(
                        _propertyMappings.Value.ToDictionary(
                            m => m.OtherProperty.PropertyName,
                            m => m,
                            StringComparer.InvariantCultureIgnoreCase)));

            _foreignKeyNameParts = new Lazy<ForeignKeyNameParts>(
                () => GetForeignKeyNameParts(this));

            _isSoftDependency = new Lazy<bool>(
                () =>
                {
                    // Navigable relationships do not span aggregates and do not represent aggregate dependencies
                    if (IsNavigable)
                    {
                        return false;
                    }

                    bool isContainingEntityPresenceOptional = ThisEntity.AncestorsOrSelf.Select(e => e.ParentAssociation)
                        // Exclude root's ParentAssociation (which will be null)
                        .Where(av => av != null)
                        .Any(av =>
                            // An optional collection
                            (av.AssociationType == AssociationViewType.ManyToOne && !av.Association.IsRequiredCollection)

                            // An optional incoming one-to-one reference
                            || (av.AssociationType == AssociationViewType.OneToOneIncoming && !av.IsRequired));

                    if (isContainingEntityPresenceOptional)
                    {
                        return true;
                    }

                    // Containing entity is required, so evaluate the reference itself
                    if (AssociationType == AssociationViewType.ManyToOne
                        || AssociationType == AssociationViewType.OneToOneIncoming)
                    {
                        return !IsRequired;
                    }

                    // All other associations do not represent dependencies
                    return false;
                });
        }

        public AssociationViewType AssociationType
        {
            get
            {
                switch (Association.Cardinality)
                {
                    case Cardinality.OneToOne:
                    case Cardinality.OneToZeroOrOne:

                        return _isPrimaryEntity
                            ? AssociationViewType.OneToOneOutgoing
                            : AssociationViewType.OneToOneIncoming;

                    case Cardinality.OneToZeroOrMore:
                    case Cardinality.OneToOneOrMore:

                        return _isPrimaryEntity
                            ? AssociationViewType.OneToMany
                            : AssociationViewType.ManyToOne;

                    case Cardinality.OneToOneInheritance:

                        return _isPrimaryEntity
                            ? AssociationViewType.ToDerived
                            : AssociationViewType.FromBase;

                    case Cardinality.OneToOneExtension:
                    case Cardinality.OneToZeroOrOneExtension:

                        return _isPrimaryEntity
                            ? AssociationViewType.ToExtension
                            : AssociationViewType.FromCore;

                    default:
                        throw new NotSupportedException(Association.Cardinality.ToString());
                }
            }
        }

        public Entity ThisEntity
        {
            get
            {
                return _isPrimaryEntity
                    ? _domainModel.EntityByFullName[Association.PrimaryEntityFullName]
                    : _domainModel.EntityByFullName[Association.SecondaryEntityFullName];
            }
        }

        internal AssociationProperty[] ThisAssociationProperties
        {
            get { return _thisAssociationProperties.Value; }
        }

        public EntityProperty[] ThisProperties
        {
            get { return _thisProperties.Value; }
        }

        public IReadOnlyList<PropertyMapping> PropertyMappings
        {
            get { return _propertyMappings.Value; }
        }

        public IReadOnlyDictionary<string, PropertyMapping> PropertyMappingByThisName
        {
            get { return _propertyMappingsByThisName.Value; }
        }

        public IReadOnlyDictionary<string, PropertyMapping> PropertyMappingByOtherName
        {
            get { return _propertyMappingsByOtherName.Value; }
        }

        public Entity OtherEntity
        {
            get
            {
                Entity entity;

                if (_isPrimaryEntity)
                {
                    if (!_domainModel.EntityByFullName.TryGetValue(Association.SecondaryEntityFullName, out entity))
                    {
                        throw new Exception(
                            string.Format(
                                "Entity '{0}' was not found in the domain model for an association defined with entity '{1}'.",
                                Association.SecondaryEntityFullName,
                                Association.PrimaryEntityFullName));
                    }

                    return entity;
                }

                if (!_domainModel.EntityByFullName.TryGetValue(Association.PrimaryEntityFullName, out entity))
                {
                    throw new Exception(
                        string.Format(
                            "Entity '{0}' was not found in the domain model for an association defined with entity '{1}'.",
                            Association.PrimaryEntityFullName,
                            Association.SecondaryEntityFullName));
                }

                return entity;
            }
        }

        internal AssociationProperty[] OtherAssociationProperties
        {
            get { return _otherAssociationProperties.Value; }
        }

        public EntityProperty[] OtherProperties
        {
            get { return _otherProperties.Value; }
        }

        /// <summary>
        /// Indicates whether the association is internal to its aggregate, and is navigable (self-referencing
        /// relationships are not navigable).
        /// </summary>
        /// <seealso cref="AssociatesEntitiesOfTheSameAggregate"/>
        public bool IsNavigable
        {
            get
            {
                return

                    // Association must be between entities that are members of the same aggregate
                    AssociatesEntitiesOfTheSameAggregate

                    // Except that self-recursive relationships are non-navigable
                    && !IsSelfReferencing

                    // Except self-recursive many-to-many relationships (which use an associative entity) are only navigable from the one-to-many side
                    && !IsSelfReferencingManyToMany;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="Entity"/> referenced by the association is a member of the same <see cref="Aggregate" />,
        /// or whether the association represents a relationship to an Entity in a different Aggregate.
        /// </summary>
        /// <seealso cref="IsNavigable"/>
        public bool AssociatesEntitiesOfTheSameAggregate
        {
            get
            {
                FullName primaryEntityAggregateName;

                if (!_domainModel.AggregateFullNameByEntityFullName.TryGetValue(Association.PrimaryEntityFullName, out primaryEntityAggregateName))
                {
                    throw new Exception(string.Format("Entity '{0}' was not found in any aggregate.", Association.PrimaryEntityFullName));
                }

                FullName secondaryEntityAggregateName;

                if (!_domainModel.AggregateFullNameByEntityFullName.TryGetValue(
                    Association.SecondaryEntityFullName,
                    out secondaryEntityAggregateName))
                {
                    throw new Exception(string.Format("Entity '{0}' was not found in any aggregate.", Association.SecondaryEntityFullName));
                }

                return
                    primaryEntityAggregateName == secondaryEntityAggregateName;
            }
        }

        public bool IsIdentifying
        {
            get { return Association.IsIdentifying; }
        }

        public bool IsSelfReferencing
        {
            get { return Association.IsSelfReferencing; }
        }

        /// <summary>
        /// Gets the property mappings of the association whose values differ, and thus directly support the parent/child self-referencing
        /// behavior.
        /// </summary>
        /// <returns>The list of self-referencing property mappings if the association is self-referencing; otherwise an empty list.</returns>
        public IReadOnlyList<PropertyMapping> SelfReferencingPropertyMappings
        {
            get
            {
                if (!Association.IsSelfReferencing)
                {
                    return EmptyPropertyMappingList;
                }

                return
                    PropertyMappings.Where(
                                         m => !m.ThisProperty.PropertyName.EqualsIgnoreCase(m.OtherProperty.PropertyName))
                                    .ToList();
            }
        }

        /// <summary>
        /// Indicates whether the underlying <see cref="Association"/> represents the secondary role-named association
        /// which establishes the self-referencing many-to-many relationship.
        /// </summary>
        /// <remarks>In order to fit the Ed-Fi composite key style of a self-many-to-many relationship,
        /// the relationship must be identifying, and the relationship introducing the self-recursion
        /// must have a role name applied, while the "primary" relationship does not.
        /// </remarks>
        public bool IsSelfReferencingManyToMany
        {
            get
            {
                var requiredAssociationViewType =
                    _isPrimaryEntity
                        ? AssociationViewType.OneToMany
                        : AssociationViewType.ManyToOne;

                // In order to fit the Ed-Fi composite key style of a self-many-to-many relationship,
                // the relationship must be identifying, and have a role name applied
                if (!IsIdentifying || string.IsNullOrEmpty(RoleName) || AssociationType != requiredAssociationViewType)
                {
                    return false;
                }

                var otherIdentifyingAssociationsToSameEntity =
                    _domainModel.AssociationViewsByEntityFullName[ThisEntity.FullName]
                                .Except(
                                     new[]
                                     {
                                         this
                                     })
                                .Where(
                                     x => x.AssociationType == requiredAssociationViewType
                                          && x.OtherEntity == OtherEntity
                                          && x.IsIdentifying)
                                .ToList();

                // If there is only 1 other identifying association to the same entity
                if (otherIdentifyingAssociationsToSameEntity.Count == 1

                    // ... and it does NOT have a role name
                    && string.IsNullOrEmpty(
                        otherIdentifyingAssociationsToSameEntity.Single()
                                                                .RoleName))
                {
                    // ... then the current association is the association that establishes the self-referencing many-to-many relationship.
                    return true;
                }

                return false;
            }
        }

        public string Name
        {
            get
            {
                switch (AssociationType)
                {
                    case AssociationViewType.OneToMany:

                        return ApplyRoleNameToCollection(
                            RoleName,
                            CompositeTermInflector.MakePlural(OtherEntity.Name.TrimSuffix("Extension")),
                            ThisEntity.Name);

                    case AssociationViewType.OneToOneIncoming: // TODO: Infer role names?
                    case AssociationViewType.OneToOneOutgoing:
                    case AssociationViewType.ManyToOne:
                        return ApplyRoleNameToReference(RoleName, OtherEntity.Name);

                    // Added special handling for extension relationship name, for matching from profiles and composites
                    case AssociationViewType.ToExtension:

                        return _domainModel
                              .SchemaNameMapProvider
                              .GetSchemaMapByPhysicalName(Association.SecondaryEntityFullName.Schema)
                              .ProperCaseName;
                }

                return OtherEntity.Name;
            }
        }

        /// <summary>
        /// Returns the role name applied to the target of the association, as relevant to this association view.
        /// </summary>
        public string RoleName
        {
            get
            {
                if (_foreignKeyNameParts.Value == null)
                {
                    return null;
                }

                return _foreignKeyNameParts.Value.RoleName;
            }
        }

        public Association Association { get; }

        /// <summary>
        /// Gets the <see cref="AssociationView"/> representing the inverse view of the underlying <see cref="Association"/>.
        /// </summary>
        public AssociationView Inverse { get; internal set; }

        public bool IsRequired
        {
            get { return Association.IsRequired; }
        }

        public bool IsRequiredCollection
        {
            get { return Association.IsRequiredCollection; }
        }

        FullName IHasNameContext.ParentFullName
        {
            get { return ThisEntity.FullName; }
        }

        string IHasNameContext.PropertyName
        {
            get { return Name; }
        }

        /// <summary>
        /// Indicates whether the association represents a <em>incoming</em> dependency from another aggregate where the association itself is not required
        /// to be present either because the association is optional or it is a member of a child entity that is not required to be present in the aggregate
        /// (because the collection, or one the containing collections, is not a required collections).
        /// </summary>
        public bool IsSoftDependency
        {
            get => _isSoftDependency.Value;
        }

        private void InitializeAssociationPropertyEntityBackReferences()
        {
            if (_backReferencesAlreadyInitialized)
            {
                return;
            }

            if (_isPrimaryEntity)
            {
                Association.PrimaryEntityAssociationProperties.ForEach(p => p.Entity = ThisEntity);
                Association.SecondaryEntityAssociationProperties.ForEach(p => p.Entity = OtherEntity);
            }
            else
            {
                Association.PrimaryEntityAssociationProperties.ForEach(p => p.Entity = OtherEntity);
                Association.SecondaryEntityAssociationProperties.ForEach(p => p.Entity = ThisEntity);
            }

            _backReferencesAlreadyInitialized = true;
        }

        /// <summary>
        /// Prevents a role name from introducing a redundant prefix on the subject.
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="subjectName"></param>
        /// <returns></returns>
        private string ApplyRoleNameToReference(string roleName, string subjectName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return subjectName;
            }

            // Prevent redundant role names from being applied except when it's the parent side of a self-referencing many-to-many relationship.
            if (subjectName.StartsWith(roleName) && !(IsSelfReferencingManyToMany && AssociationType == AssociationViewType.OneToMany))
            {
                return subjectName;
            }

            return roleName + subjectName;
        }

        /// <summary>
        /// Prevents a role name from introducing a redundant prefix on the subject.
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        private string ApplyRoleNameToCollection(string roleName, string collectionName, string parentClassName)
        {
            // For the purposes of avoiding breaking changes
            return ApplyRoleNameToReference(roleName, collectionName);

            // TODO: GKM - ODS-1182
            // Recommended implementation for collection names:
            // ------------------------------------------------------------------------------------------------------------------------------
            // Sample Collection Name Changes:
            //     AttemptedCourseTranscripts                 -->  CourseTranscriptsForAttemptedCreditType
            //     CumulativeAttemptedStudentAcademicRecords  -->  StudentAcademicRecordsForCumulativeAttemptedCreditType
            //     CumulativeEarnedStudentAcademicRecords     -->  StudentAcademicRecordsForCumulativeEarnedCreditType
            //     PeerEducationOrganizationPeerAssociations  -->  EducationOrganizationPeerAssociationsForPeerEducationOrganization
            // ------------------------------------------------------------------------------------------------------------------------------

            //if (string.IsNullOrEmpty(roleName))
            //    return collectionName;

            //return collectionName + "For" + roleName + parentClassName;
        }

        private ForeignKeyNameParts GetForeignKeyNameParts(AssociationView associationView)
        {
            AssociationProperty[] baseProperties = null;
            AssociationProperty[] roleNamedProperties = null;

            if (associationView.AssociationType == AssociationViewType.OneToMany)
            {
                baseProperties = associationView.ThisAssociationProperties;
                roleNamedProperties = associationView.OtherAssociationProperties;
            }
            else if (associationView.AssociationType == AssociationViewType.ManyToOne)
            {
                baseProperties = associationView.OtherAssociationProperties;
                roleNamedProperties = associationView.ThisAssociationProperties;
            }
            else if (associationView.AssociationType == AssociationViewType.OneToOneOutgoing)
            {
                baseProperties = associationView.ThisAssociationProperties;
                roleNamedProperties = associationView.OtherAssociationProperties;
            }
            else if (associationView.AssociationType == AssociationViewType.OneToOneIncoming)
            {
                baseProperties = associationView.OtherAssociationProperties;
                roleNamedProperties = associationView.ThisAssociationProperties;
            }
            else
            {
                return null;
            }

            for (int i = 0; i < associationView.ThisAssociationProperties.Length; i++)
            {
                if (baseProperties[i]
                       .PropertyName != roleNamedProperties[i]
                       .PropertyName)
                {
                    // NOTE: When a role name is applied, some of the members of the association may be
                    // unified with the target entity's properties.  Usually this results in the role
                    // name prefix disappearing from the target's property name (which is why we are
                    // looping through all the properties of the association looking for the role name).
                    // However, it is conceivable (but not currently an actual scenario anywhere in Ed-Fi)
                    // that a key unification could occur on a property that has already been role named
                    // by another association on the target entity.  In this case, this logic might
                    // fail to find the correct role name (detecting the role name from another association),
                    // and to fully support this remotely conceivable scenario would require some fairly
                    // careful logic to work with the interactions of all the other incoming associations
                    // on the target entity.  Since it is not currently an issue, nor is it likely to become
                    // an issue, support for this scenario is not being added, and these notes are being left
                    // here for possible future maintenance work, should this ever actually be required.

                    string coreName = baseProperties[i]
                                     .PropertyName.TrimSuffix("Id");

                    string pattern = @"^(?<RoleName>\w*)" + coreName + @"(?<Qualifier>\w*)$";

                    var match = Regex.Match(
                        roleNamedProperties[i]
                           .PropertyName,
                        pattern);

                    if (match.Success)
                    {
                        var parts = new ForeignKeyNameParts
                                    {
                                        RoleName = match.Groups["RoleName"]
                                                        .Value,
                                        Core = coreName, Qualifier = match.Groups["Qualifier"]
                                                                          .Value
                                    };

                        // We only need one-to-many associations to have a role name when there is more than one relationship
                        // because often times the role name applied on the receiving end is for preventing an otherwise
                        // unified key property, but that role name only has meaning within the context of the target.  The only
                        // time a role name is truly applicable on the one sie of a one-to-many is when we need to delineate
                        // between two different child collections.
                        if (associationView.AssociationType == AssociationViewType.OneToMany
                            && associationView.ThisEntity.OutgoingAssociations.Count(a => a.OtherEntity.Equals(associationView.OtherEntity)) < 2)
                        {
                            // Role names are only required on the one side of a one-to-many when
                            // there are multiple relationships present
                            parts.RoleName = null;
                        }

                        // Don't let role name be the same as the other table, or strangeness in naming will occur
                        if (parts.RoleName == associationView.OtherEntity.Name)
                        {
                            parts.RoleName = null;
                        }

                        // Don't let qualifier be "Id"
                        if (parts.Qualifier == "Id")
                        {
                            parts.Qualifier = null;
                        }

                        if (string.IsNullOrEmpty(parts.RoleName) && string.IsNullOrEmpty(parts.Qualifier))
                        {
                            return null;
                        }

                        return parts;
                    }
                }
            }

            return null;
        }

        public override string ToString()
        {
            string cardinality;

            switch (AssociationType)
            {
                case AssociationViewType.OneToMany:
                    cardinality = "(1)-->(M)";
                    break;

                case AssociationViewType.ManyToOne:
                    cardinality = "(M)<--(1)";
                    break;

                case AssociationViewType.OneToOneIncoming:
                    cardinality = "(1)<--(1)";
                    break;

                case AssociationViewType.OneToOneOutgoing:
                    cardinality = "(1)-->(1)";
                    break;

                case AssociationViewType.FromBase:
                    cardinality = "---|>";
                    break;

                case AssociationViewType.ToDerived:
                    cardinality = "<|---";
                    break;

                case AssociationViewType.ToExtension:
                    cardinality = "(1)-->(X)";
                    break;

                case AssociationViewType.FromCore:
                    cardinality = "(X)<--(1)";
                    break;

                default:
                    throw new NotImplementedException(string.Format("Unimplemented association view type: '{0}.", AssociationType));
            }

            return string.Format(
                "{0}{1}{2}{3}",
                _isPrimaryEntity
                    ? Association.PrimaryEntityFullName
                    : Association.SecondaryEntityFullName,
                cardinality,
                _isPrimaryEntity
                    ? Association.SecondaryEntityFullName
                    : Association.PrimaryEntityFullName,
                string.IsNullOrEmpty(RoleName)
                    ? null
                    : $" ({RoleName})"
                );
        }

        private class ForeignKeyNameParts
        {
            public string RoleName { get; set; }

            public string Core { get; set; }

            public string Qualifier { get; set; }
        }
    }

    public class PropertyMapping
    {
        public PropertyMapping(EntityProperty thisProperty, EntityProperty otherProperty)
        {
            ThisProperty = thisProperty;
            OtherProperty = otherProperty;
        }

        public EntityProperty ThisProperty { get; }

        public EntityProperty OtherProperty { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return ThisProperty + " <---> " + OtherProperty;
        }
    }
}

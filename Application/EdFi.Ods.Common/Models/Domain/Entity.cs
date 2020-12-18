// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Common.Inflection;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Models.Domain
{
    public class Entity
    {
        private readonly Lazy<AssociationView[]> _aggregateExtensionChildren;
        private readonly Lazy<AssociationView[]> _aggregateExtensionOneToOnes;
        private readonly Lazy<IReadOnlyList<EntityIdentifier>> _alternateIdentifiers;
        private readonly Lazy<AssociationView> _baseAssociation;
        private readonly Lazy<Entity[]> _derivedEntities;
        private readonly Lazy<Entity> _edFiStandardEntity;
        private readonly Lazy<AssociationView> _edFiStandardEntityAssociation;
        private readonly Lazy<Entity[]> _extensions;
        private readonly Lazy<AssociationView[]> _extensionAssociations;
        private readonly IReadOnlyList<EntityIdentifier> _identifiers;
        private readonly Lazy<bool> _isEntityExtension;
        private readonly IList<EntityProperty> _locallyDefinedProperties;
        private readonly Lazy<IReadOnlyList<EntityProperty>> _nonIdentifyingProperties;
        private readonly Lazy<EntityIdentifier> _primaryIdentifier;
        private readonly Lazy<IReadOnlyList<EntityProperty>> _properties;
        private readonly Lazy<IReadOnlyDictionary<string, EntityProperty>> _propertyByName;
        private readonly Lazy<IReadOnlyList<PropertyMapping>> _childToAggregateRootIdentifierPropertyMappings;
        private string _pluralName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class with a name and a list of
        /// properties that are defined locally on the entity (and are not part of incoming associations).
        /// </summary>
        /// <param name="domainModel">The incoming <seealso cref="DomainModel"/></param>
        /// <param name="entityDefinition">The incoming <seealso cref="EntityDefinition"/></param>
        internal Entity(DomainModel domainModel, EntityDefinition entityDefinition)
        {
            DomainModel = domainModel;

            Schema = entityDefinition.Schema;
            Name = entityDefinition.Name;

            TableNameByDatabaseEngine = new Dictionary<DatabaseEngine, string>(entityDefinition.TableNames);

            Description = entityDefinition.Description?.Trim();
            IsAbstract = entityDefinition.IsAbstract;
            IsDeprecated = entityDefinition.IsDeprecated;
            DeprecationReasons = entityDefinition.DeprecationReasons;

            _locallyDefinedProperties = entityDefinition.LocallyDefinedProperties.Select(x => new EntityProperty(x))
                                                        .ToList();

            _identifiers = entityDefinition.Identifiers.Select(x => new EntityIdentifier(x))
                                           .ToReadOnlyList();

            // Assign entity references to the identifiers, properties
            _identifiers.ForEach(i => i.Entity = this);
            _locallyDefinedProperties.ForEach(p => p.Entity = this);

            _properties = new Lazy<IReadOnlyList<EntityProperty>>(
                () =>
                {
                    // All properties, identifying ones first
                    var properties =
                        IncomingAssociations.Where(a => a.IsIdentifying)
                                            .SelectMany(x => x.ThisAssociationProperties.Cast<DomainPropertyBase>())
                                            .Concat(_locallyDefinedProperties.Where(p => p.IsIdentifying))
                                            .Concat(
                                                 IncomingAssociations.Where(a => !a.IsIdentifying)
                                                                     .SelectMany(x => x.ThisAssociationProperties))
                                            .Concat(_locallyDefinedProperties.Where(p => !p.IsIdentifying))
                                            .ToList();

                    var distinctProperties = properties
                                            .Distinct(ModelComparers.DomainPropertyNameOnly)
                                            .ToList()
                                            .AsReadOnly();

                    // Return the distinct set of EntityProperty instances,
                    // constructing new EntityProperty instances for the "winning" AssociationProperty
                    var entityProperties = distinctProperties.Select(dp =>
                        (dp as EntityProperty) ?? new EntityProperty(dp as AssociationProperty))
                        .ToList();

                    // Ensure back-references to the Entity are set
                    entityProperties.ForEach(p => p.Entity = this);

                    return entityProperties;
                });

            _nonIdentifyingProperties = new Lazy<IReadOnlyList<EntityProperty>>(
                () =>
                    Properties.Where(p => !p.IsIdentifying)
                              .ToList()
                              .AsReadOnly());

            _derivedEntities = new Lazy<Entity[]>(
                () =>
                {
                    AssociationView[] associations;

                    if (!DomainModel.AssociationViewsByEntityFullName.TryGetValue(FullName, out associations))
                    {
                        return new Entity[0];
                    }

                    return associations
                          .Where(x => x.AssociationType == AssociationViewType.ToDerived)
                          .Select(x => x.OtherEntity)
                          .ToArray();
                });

            _propertyByName = new Lazy<IReadOnlyDictionary<string, EntityProperty>>(
                () =>
                    Properties.ToDictionary(x => x.PropertyName, x => x, StringComparer.InvariantCultureIgnoreCase));

            _primaryIdentifier = new Lazy<EntityIdentifier>(
                () =>
                    _identifiers.SingleOrDefault(x => x.IsPrimary));

            _alternateIdentifiers = new Lazy<IReadOnlyList<EntityIdentifier>>(
                () =>
                    _identifiers.Where(x => !x.IsPrimary)
                                .ToList());

            _baseAssociation = new Lazy<AssociationView>(
                () =>
                {
                    AssociationView[] associations;

                    if (!DomainModel.AssociationViewsByEntityFullName.TryGetValue(FullName, out associations))
                    {
                        return null;
                    }

                    return associations.SingleOrDefault(a => a.AssociationType == AssociationViewType.FromBase);
                });

            _isEntityExtension = new Lazy<bool>(
                () => EdFiStandardEntityAssociation != null);

            _extensions = new Lazy<Entity[]>(
                () =>
                {
                    AssociationView[] associations;

                    if (!DomainModel.AssociationViewsByEntityFullName.TryGetValue(FullName, out associations))
                    {
                        return new Entity[0];
                    }

                    return associations
                          .Where(x => x.AssociationType == AssociationViewType.ToExtension)
                          .Select(x => x.OtherEntity)
                          .ToArray();
                });

            _extensionAssociations = new Lazy<AssociationView[]>(
                () =>
                {
                    AssociationView[] associations;

                    if (!DomainModel.AssociationViewsByEntityFullName.TryGetValue(FullName, out associations))
                    {
                        return new AssociationView[0];
                    }

                    return associations
                        .Where(x => x.AssociationType == AssociationViewType.ToExtension)
                        .ToArray();
                });

            _aggregateExtensionOneToOnes = new Lazy<AssociationView[]>(
                () =>
                {
                    return NavigableOneToOnes.Where(a => a.ThisEntity.Schema != a.OtherEntity.Schema)
                                             .ToArray();
                });

            _aggregateExtensionChildren = new Lazy<AssociationView[]>(
                () =>
                {
                    return NavigableChildren.Where(a => a.ThisEntity.Schema != a.OtherEntity.Schema)
                                            .ToArray();
                });

            _edFiStandardEntity = new Lazy<Entity>(
                () =>
                {
                    if (EdFiStandardEntityAssociation == null)
                    {
                        return null;
                    }

                    return EdFiStandardEntityAssociation.OtherEntity;
                });

            _edFiStandardEntityAssociation = new Lazy<AssociationView>(
                () =>
                    IncomingAssociations
                       .SingleOrDefault(a => a.AssociationType == AssociationViewType.FromCore)
            );

            _childToAggregateRootIdentifierPropertyMappings =
                new Lazy<IReadOnlyList<PropertyMapping>>(() => BuildChildToAggregateRootPropertyMappings(this));
        }

        /// <summary>
        /// Gets a reference to the <see cref="Domain.DomainModel"/> in which the current entity is defined.
        /// </summary>
        public DomainModel DomainModel { get; }

        /// <summary>
        /// Gets the physical schema name of the current entity.
        /// </summary>
        public string Schema { get; }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a mapping of the entity's physical table names by database engine identifier.
        /// </summary>
        public IDictionary<DatabaseEngine, string> TableNameByDatabaseEngine { get; }

        /// <summary>
        /// Gets the pluralized name of the entity.
        /// </summary>
        public string PluralName
        {
            get
            {
                if (_pluralName == null)
                {
                    _pluralName = CompositeTermInflector.MakePlural(Name);
                }

                return _pluralName;
            }
            private set { _pluralName = value; } // TODO: Allow for future support for explicit assignment of singular/plural names
        }

        /// <summary>
        /// Gets the full name of the entity (combining <see cref="Schema"/> and <see cref="Name"/>).
        /// </summary>
        public FullName FullName => new FullName(Schema, Name);

        /// <summary>
        /// Gets the <see cref="Aggregate"/> of which the current entity is a member.
        /// </summary>
        public Aggregate Aggregate
        {
            get
            {
                FullName aggregateName;
                Aggregate aggregate;

                DomainModel.AggregateFullNameByEntityFullName.TryGetValue(
                    FullName,
                    out aggregateName);

                DomainModel.AggregateByName.TryGetValue(aggregateName, out aggregate);

                return aggregate;
            }
        }

        /// <summary>
        /// Gets the association with the <see cref="BaseEntity"/> from which the current entity is derived; otherwise <b>null</b>.
        /// </summary>
        public AssociationView BaseAssociation => _baseAssociation.Value;

        /// <summary>
        /// Gets the base entity from which the current entity is derived; otherwise <b>null</b>.
        /// </summary>
        public Entity BaseEntity => _baseAssociation.Value?.OtherEntity;

        /// <summary>
        /// Gets the <see cref="Entity"/> that is the root of the current type hierarchy, or the current <see cref="Entity"/> if it is not derived (see <see cref="IsDerived"/>).
        /// </summary>
        public Entity TypeHierarchyRootEntity
        {
            get
            {
                if (!IsDerived)
                    return this;

                var currentBaseEntity = BaseEntity;

                while (currentBaseEntity.IsDerived)
                    currentBaseEntity = currentBaseEntity.BaseEntity;

                return currentBaseEntity;
            }
        }

        /// <summary>
        /// Indicates whether the entity is an extension entity that was added to an Ed-Fi Standard aggregate.
        /// </summary>
        public bool IsAggregateExtension => IsExtensionEntity && Aggregate.AggregateRoot.IsEdFiStandardEntity;

        ///<summary>
        /// Indicates whether the entity is an extension that was added to an Ed-Fi Standard aggregate as a direct child of an Ed-Fi Standard entity.
        /// </summary>
        public bool IsAggregateExtensionTopLevelEntity => IsAggregateExtension && Parent.IsEdFiStandardEntity;

        /// <summary>
        /// Indicates whether the current entity is derived from another entity through an inheritance relationship (see <see cref="BaseEntity"/>).
        /// </summary>
        public bool IsDerived => BaseEntity != null;

        /// <summary>
        /// Indicates whether the current entity is deprecated.
        /// </summary>
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// Indicates reasons over the entity when it is deprecated.
        /// </summary>
        public string[] DeprecationReasons { get; set; }

        /// <summary>
        /// Indicates whether the current entity is a base type from which other entities are derived.
        /// </summary>
        public bool IsBase => _derivedEntities.Value.Any();

        /// <summary>
        /// Indicates whether the current entity is an abstract base entity.
        /// </summary>
        public bool IsAbstract { get; }

        /// <summary>
        /// Indicates whether the current entity is an entity defined in the Ed-Fi Standard.
        /// </summary>
        public bool IsEdFiStandardEntity => EdFiConventions.IsEdFiPhysicalSchemaName(Schema);

        /// <summary>
        /// Indicates whether the entity is a new entity defined by an extension to the Ed-Fi standard.
        /// </summary>
        /// <returns><b>true</b> if the entity is an extension entity; otherwise <b>false</b>.</returns>
        /// <remarks>Entity extensions are not considered extension entities since they exist only to supply additional properties
        /// for an existing Ed-Fi standard entity.
        /// </remarks>
        public bool IsExtensionEntity => !IsEdFiStandardEntity && !IsEntityExtension;

        /// <summary>
        /// Gets the list of entities that are derived from the current entity.
        /// </summary>
        public Entity[] DerivedEntities => _derivedEntities.Value;

        /// <summary>
        /// Gets the entity extensions (entities that extend the current entity with additional properties).
        /// </summary>
        public Entity[] Extensions => _extensions.Value;

        /// <summary>
        /// Gets the associations for the entity extensions (entities that extend the current entity with additional properties).
        /// </summary>
        public AssociationView[] ExtensionAssociations => _extensionAssociations.Value;

        /// <summary>
        /// Gets the associations that represent the navigable one-to-one relationships that are extensions to the current aggregate (i.e. entities defined by an extension to the Ed-Fi Standard, and added to the standard aggregate).
        /// </summary>
        public AssociationView[] AggregateExtensionOneToOnes => _aggregateExtensionOneToOnes.Value;

        /// <summary>
        /// Gets the associations that represent the navigable children that are extensions to the current aggregate (i.e. entities defined by an extension to the Ed-Fi Standard, and added to the standard aggregate).
        /// </summary>
        public AssociationView[] AggregateExtensionChildren => _aggregateExtensionChildren.Value;

        /// <summary>
        /// Indicates whether the entity is an extension of a "core" entity (see <see cref="EdFiStandardEntity"/>).
        /// </summary>
        public bool IsEntityExtension => _isEntityExtension.Value;

        /// <summary>
        /// Gets the Ed-Fi Standard entity if the current entity is an entity extension; otherwise <b>null</b>.
        /// </summary>
        public Entity EdFiStandardEntity => _edFiStandardEntity.Value;

        /// <summary>
        /// Gets the Ed-Fi Standard entity association if the current entity is an entity extension; otherwise <b>null</b>.
        /// </summary>
        public AssociationView EdFiStandardEntityAssociation => _edFiStandardEntityAssociation.Value;

        /// <summary>
        /// Gets the alternate key identifiers logically inherited from the entity's base type hierarchy. 
        /// </summary>
        public IReadOnlyList<EntityIdentifier> InheritedAlternateIdentifiers
        {
            get
            {
                if (BaseEntity == null)
                {
                    return new EntityIdentifier[0];
                }

                return BaseEntity.InheritedAlternateIdentifiers
                    .Concat(BaseEntity.AlternateIdentifiers)
                    .ToList();
            }
        }
        
        /// <summary>
        /// Gets all the properties logically inherited via the entity's base type hierarchy, with the identifying properties first, followed by non-identifying properties.
        /// </summary>
        public IReadOnlyList<EntityProperty> InheritedProperties
        {
            get
            {
                if (BaseEntity == null)
                {
                    return new EntityProperty[0];
                }

                var inheritedProperties =
                    BaseEntity.InheritedProperties
                              .Except(BaseAssociation.OtherProperties)
                              .Concat(BaseAssociation.ThisProperties)
                              .Concat(BaseEntity.Properties.Except(BaseAssociation.OtherProperties))
                              .ToList();

                return

                    // Inherited identifying properties first
                    inheritedProperties.Where(p => p.IsIdentifying)

                                        // Inherited non-identifying properties
                                       .Concat(inheritedProperties.Where(p => !p.IsIdentifying))
                                       .ToReadOnlyList();
            }
        }

        /// <summary>
        /// Gets all the properties available on the entity, with the identifying properties first, followed by non-identifying properties.
        /// </summary>
        public IReadOnlyList<EntityProperty> Properties => _properties.Value;

        /// <summary>
        /// Provides a dictionary for accessing the entity's properties by name.
        /// </summary>
        public IReadOnlyDictionary<string, EntityProperty> PropertyByName => _propertyByName.Value;

        /// <summary>
        /// Gets the identifier (i.e. the primary key) for the entity.
        /// </summary>
        public EntityIdentifier Identifier => _primaryIdentifier.Value;

        /// <summary>
        /// Gets alternate identifiers (i.e. alternate keys) for the entity.
        /// </summary>
        public IReadOnlyList<EntityIdentifier> AlternateIdentifiers => _alternateIdentifiers.Value;

        public IReadOnlyList<PropertyMapping> ChildToAggregateRootIdentifierPropertyMappings => _childToAggregateRootIdentifierPropertyMappings.Value;

        /// <summary>
        /// Gets all the properties logically inherited via the entity's base type hierarchy that are not part of the entity's identity.
        /// </summary>
        public IReadOnlyList<EntityProperty> InheritedNonIdentifyingProperties
        {
            get
            {
                if (BaseEntity == null)
                {
                    return new EntityProperty[0];
                }

                return BaseEntity
                      .InheritedNonIdentifyingProperties
                      .Concat(BaseEntity.NonIdentifyingProperties)
                      .ToReadOnlyList();
            }
        }

        /// <summary>
        /// Gets all the properties on the entity that are not part of the entity's identity.
        /// </summary>
        public IReadOnlyList<EntityProperty> NonIdentifyingProperties => _nonIdentifyingProperties.Value;

        /// <summary>
        /// Gets all the incoming associations on the entity logically inherited via the entity's base type hierarchy (including many-to-one, one-to-one incoming, from "base" entity, and from the Ed-Fi standard entity [for extensions]).
        /// </summary>
        public IReadOnlyList<AssociationView> InheritedIncomingAssociations
        {
            get
            {
                if (BaseEntity == null)
                {
                    return new AssociationView[0];
                }

                return BaseEntity
                      .InheritedIncomingAssociations
                      .Concat(BaseEntity.IncomingAssociations)
                      .ToReadOnlyList();
            }
        }

        /// <summary>
        /// Gets all the incoming associations on the entity (including many-to-one, one-to-one incoming, from "base" entity, and from "core" entity).
        /// </summary>
        public IReadOnlyList<AssociationView> IncomingAssociations => GetOrderedAssociations(
            AssociationViewType.ManyToOne,
            AssociationViewType.OneToOneIncoming,
            AssociationViewType.FromBase,
            AssociationViewType.FromCore);

        /// <summary>
        /// Gets all the outgoing associations on the entity logically inherited via the entity's base type hierarchy (including one-to-many, one-to-one outgoing, to "derived" entity, and to "extension" entity).
        /// </summary>
        public IReadOnlyList<AssociationView> InheritedOutgoingAssociations
        {
            get
            {
                if (BaseEntity == null)
                {
                    return new AssociationView[0];
                }

                return BaseEntity
                      .InheritedOutgoingAssociations
                      .Concat(BaseEntity.OutgoingAssociations)
                      .ToReadOnlyList();
            }
        }

        /// <summary>
        /// Gets all the outgoing associations on the entity (including one-to-many, one-to-one outgoing, to "derived" entity, and to "extension" entity).
        /// </summary>
        public IReadOnlyList<AssociationView> OutgoingAssociations => GetOrderedAssociations(
            AssociationViewType.OneToMany,
            AssociationViewType.OneToOneOutgoing,
            AssociationViewType.ToDerived,
            AssociationViewType.ToExtension);

        public IReadOnlyList<AssociationView> InheritedNonNavigableParents
        {
            get
            {
                if (BaseEntity == null)
                {
                    return new AssociationView[0];
                }

                return BaseEntity
                      .InheritedNonNavigableParents
                      .Concat(BaseEntity.NonNavigableParents)
                      .ToReadOnlyList();
            }
        }

        /// <summary>
        /// For non-aggregate-root entities, gets the association to the parent.
        /// </summary>
        public AssociationView ParentAssociation => GetNavigableAssociations(
                AssociationViewType.ManyToOne,
                AssociationViewType.OneToOneIncoming,
                AssociationViewType.FromCore)
           .SingleOrDefault();

        public Entity Parent => ParentAssociation?.OtherEntity;

        /// <summary>
        /// Gets a list of "ancestor" entities starting with the parent and going up the aggregate hierarchy
        /// to the aggregate root, which will be the last entity in the list.
        /// </summary>
        public IReadOnlyList<Entity> Ancestors => Parent == null
            ? new List<Entity>()
            : new[]
              {
                  Parent
              }.Concat(Parent.Ancestors)
               .ToList();

        /// <summary>
        /// Gets a list of "ancestor" entities starting with the current entity and going up the aggregate hierarchy
        /// to the aggregate root, which will be the last entity in the list.
        /// </summary>
        public IReadOnlyList<Entity> AncestorsOrSelf => Parent == null
            ? new List<Entity>
              {
                  this
              }
            : new[]
              {
                  this
              }.Concat(Ancestors)
               .ToList();

        /// <summary>
        /// Gets a list of associations that represent many-to-one or one-to-one incoming relationships.
        /// </summary>
        public IReadOnlyList<AssociationView> NonNavigableParents => GetNonNavigableAssociations(
            AssociationViewType.ManyToOne,
            AssociationViewType.OneToOneIncoming);

        public IReadOnlyList<AssociationView> InheritedNavigableChildren => BaseEntity == null
            ? new AssociationView[0]
            : BaseEntity
             .InheritedNavigableChildren
             .Concat(BaseEntity.NavigableChildren)
             .ToReadOnlyList();

        /// <summary>
        /// Gets all "one-to-many" associations with child entities within the current aggregate, including aggregate extensions.
        /// </summary>
        public IReadOnlyList<AssociationView> NavigableChildren => GetNavigableAssociations(AssociationViewType.OneToMany);

        /// <summary>
        /// For derived entities, gets all associations to child entities inherited from the <see cref="BaseEntity"/> that are not within the current aggregate.
        /// </summary>
        public IReadOnlyList<AssociationView> InheritedNonNavigableChildren => BaseEntity == null
            ? new AssociationView[0]
            : BaseEntity
             .InheritedNonNavigableChildren
             .Concat(BaseEntity.NonNavigableChildren)
             .ToReadOnlyList();

        /// <summary>
        /// Gets all associations to child entities that are not within the current aggregate.
        /// </summary>
        public IReadOnlyList<AssociationView> NonNavigableChildren => GetNonNavigableAssociations(AssociationViewType.OneToMany);

        /// <summary>
        /// For derived entities, gets all "one-to-one" associations inherited from the base entity with entities within the current aggregate.
        /// </summary>
        public IReadOnlyList<AssociationView> InheritedNavigableOneToOnes => BaseEntity == null
            ? new AssociationView[0]
            : BaseEntity
             .InheritedNavigableOneToOnes
             .Concat(BaseEntity.NavigableOneToOnes)
             .ToReadOnlyList();

        /// <summary>
        /// Gets all "one-to-one" associations with entities within the current aggregate, including aggregate extensions.
        /// </summary>
        public IReadOnlyList<AssociationView> NavigableOneToOnes => GetNavigableAssociations(AssociationViewType.OneToOneOutgoing);

        /// <summary>
        /// For derived entities, gets all "one-to-one" associations inherited from the base entity with entities not within the current aggregate.
        /// </summary>
        public IReadOnlyList<AssociationView> InheritedNonNavigableOneToOnes
        {
            get
            {
                if (BaseEntity == null)
                {
                    return new AssociationView[0];
                }

                return BaseEntity
                      .InheritedNonNavigableOneToOnes
                      .Concat(BaseEntity.NonNavigableOneToOnes)
                      .ToReadOnlyList();
            }
        }

        public IReadOnlyList<AssociationView> NonNavigableOneToOnes => GetNonNavigableAssociations(AssociationViewType.OneToOneOutgoing);

        /// <summary>
        /// Returns the primary key properties that are defined locally (and are not received via an incoming foreign key relationship).
        /// </summary>
        public IReadOnlyList<EntityProperty> LocallyDefinedIdentifyingProperties => Properties.Where(p => p.IsIdentifying && p.IsLocallyDefined)
                                                                                              .ToReadOnlyList();

        /// <summary>
        /// Returns the primary key properties that are unique to the context of the current entity (and are not received via the parent entity's foreign key relationship).
        /// </summary>
        public IReadOnlyList<EntityProperty> ContextualIdentifyingProperties => Properties.Where(p => p.IsIdentifying && !p.IsFromParent)
                                                                                          .ToReadOnlyList();

        public bool IsAggregateRoot => DomainModel.AggregateFullNameByEntityFullName[FullName] == FullName;

        /// <summary>
        /// Indicates whether the entity represents a descriptor, or the SchoolYearType.
        /// </summary>
        public bool IsLookup => this.IsLookupEntity();

        /// <summary>
        /// Indicates whether the entity has any self-referencing associations, representing a hierarchical data structure.
        /// </summary>
        public bool HasSelfReferencingAssociations => IncomingAssociations.Any(a => a.IsSelfReferencing);

        /// <summary>
        /// Gets a list of inherited self-referencing associations (filtered from <see cref="OutgoingAssociations"/>).
        /// </summary>
        public IReadOnlyList<AssociationView> InheritedSelfReferencingAssociations => BaseEntity == null
            ? new AssociationView[0]
            : BaseEntity
             .InheritedSelfReferencingAssociations
             .Concat(BaseEntity.SelfReferencingAssociations)
             .ToReadOnlyList();

        /// <summary>
        /// Gets a list of self-referencing associations (filtered from <see cref="OutgoingAssociations"/>).
        /// </summary>
        public IReadOnlyList<AssociationView> SelfReferencingAssociations => OutgoingAssociations.Where(a => a.IsSelfReferencing)
                                                                                                 .ToList();

        public bool IsDescriptorEntity => this.IsDescriptorEntity();

        public string Description { get; }

        private IReadOnlyList<AssociationView> GetNavigableAssociations(
            params AssociationViewType[] associationTypes)
        {
            return GetAssociations(x => x.IsNavigable, false, associationTypes);
        }

        private IReadOnlyList<AssociationView> GetNonNavigableAssociations(
            params AssociationViewType[] associationTypes)
        {
            return GetAssociations(x => !x.IsNavigable, false, associationTypes);
        }

        /// <summary>
        /// Gets the associations, with the identifying association(s) before non-identifying associations.
        /// </summary>
        /// <param name="associationTypes"></param>
        /// <returns></returns>
        private IReadOnlyList<AssociationView> GetOrderedAssociations(
            params AssociationViewType[] associationTypes)
        {
            return GetAssociations(null, true, associationTypes);
        }

        private IReadOnlyList<AssociationView> GetAssociations(
            Func<AssociationView, bool> shouldInclude,
            bool orderByIdentifying,
            params AssociationViewType[] associationTypes)
        {
            AssociationView[] associations;

            if (!DomainModel.AssociationViewsByEntityFullName.TryGetValue(FullName, out associations))
            {
                return new List<AssociationView>().AsReadOnly();
            }

            return
                (orderByIdentifying
                    ? associations

                      // Identifying relationships first
                     .OrderByDescending(x => x.IsIdentifying)

                      // Relationships internal to the aggregate before external ones
                     .ThenByDescending(x => x.AssociatesEntitiesOfTheSameAggregate)
                        as IEnumerable<AssociationView>
                    : associations)
               .Where(
                    x =>
                        (shouldInclude == null
                            ? true
                            : shouldInclude(x))
                        && associationTypes.Contains(x.AssociationType))
               .ToList();
        }

        private static List<PropertyMapping> BuildChildToAggregateRootPropertyMappings(Entity entity)
        {
            //If this is an aggregate root then it doesn't have parents and we're done.
            if (entity.IsAggregateRoot)
            {
                return new List<PropertyMapping>();
            }

            //Go get the parent mappings of this entity's parent.
            var parentMappings = BuildChildToAggregateRootPropertyMappings(entity.Parent);

            //If the parent doesn't have a parent what we're looking for is just the mapping that's
            //already on the ParentAssociation view so just return that.
            if (!parentMappings.Any())
            {
                return entity.ParentAssociation.PropertyMappingByOtherName.Values.ToList();
            }

            //If the parent DOES have mappings to it's parent, create a new property mappings from this
            //entity's properties to the parent's parent's same property.
            var childToParentsParentPropertyMappingArray =
                parentMappings.Select(
                                   mapping =>
                                       new PropertyMapping(
                                           entity.ParentAssociation.PropertyMappingByOtherName[mapping.ThisProperty.PropertyName]
                                                 .ThisProperty,
                                           mapping.OtherProperty))
                              .ToList();

            return childToParentsParentPropertyMappingArray;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return FullName.ToString();
        }
    }
}

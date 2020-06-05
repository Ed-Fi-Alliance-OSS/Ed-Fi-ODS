// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Models.Domain
{
    public class DomainModel
    {
        private readonly IDictionary<FullName, Aggregate> _aggregateByName;
        private readonly IDictionary<FullName, FullName> _aggregateNameByEntityName;

        private readonly IList<Aggregate> _aggregates;
        private readonly IDictionary<FullName, Association> _associationByFullName;
        private readonly IList<Association> _associations;
        private readonly Lazy<IReadOnlyDictionary<FullName, AssociationView[]>> _associationViewsByEntityFullName;
        private readonly IDictionary<FullName, List<AssociationView>> _associationViewsByEntityNameMutable;
        private readonly IList<Entity> _entities;
        private readonly IDictionary<FullName, Entity> _entityByFullName;
        private readonly IDictionary<FullName, FullName[]> _entityFullNamesByAggregateFullName;

        private readonly Lazy<IReadOnlyDictionary<FullName, FullName>> _finalizedAggregateFullNameByEntityFullName;
        private readonly Lazy<ISchemaNameMapProvider> _schemaNameMapProvider;
        private readonly IDictionary<string, Schema> _schemas;

        private readonly IList<AggregateExtension> _aggregateExtensions =
            new List<AggregateExtension>();

        private ResourceModel _resourceModel;

        internal DomainModel()
        {
            _aggregates = new List<Aggregate>();
            _entities = new List<Entity>();
            _associations = new List<Association>();

            _associationByFullName = new SortedDictionary<FullName, Association>();
            _entityByFullName = new SortedDictionary<FullName, Entity>();
            _entityFullNamesByAggregateFullName = new SortedDictionary<FullName, FullName[]>();
            _aggregateByName = new SortedDictionary<FullName, Aggregate>();
            _aggregateNameByEntityName = new Dictionary<FullName, FullName>();
            _associationViewsByEntityNameMutable = new Dictionary<FullName, List<AssociationView>>();
            _schemas = new Dictionary<string, Schema>();

            _associationViewsByEntityFullName = new Lazy<IReadOnlyDictionary<FullName, AssociationView[]>>(
                () =>
                    new ReadOnlyDictionary<FullName, AssociationView[]>(
                        _associationViewsByEntityNameMutable
                           .ToDictionary(
                                kvp => kvp.Key,
                                kvp => kvp.Value.ToArray())));

            _finalizedAggregateFullNameByEntityFullName = new Lazy<IReadOnlyDictionary<FullName, FullName>>(
                () =>
                {
                    var finalizedAggregateNameByEntityName = new SortedDictionary<FullName, FullName>(_aggregateNameByEntityName);

                    // Process the aggregate extensions into the Ed-Fi Standard aggregates
                    foreach (var aggregateExtension in _aggregateExtensions)
                    {
                        Aggregate aggregate;

                        if (!_aggregateByName.TryGetValue(aggregateExtension.AggregateRootEntityName, out aggregate))
                        {
                            throw new Exception($"Aggregate '{aggregateExtension.AggregateRootEntityName}' was not found in the domain model.");
                        }

                        aggregate.AppendExtensionEntities(aggregateExtension.ExtensionEntityNames);

                        // Update aggregate, and its members (by name)
                        _entityFullNamesByAggregateFullName[aggregate.FullName] =
                            _entityFullNamesByAggregateFullName[aggregate.FullName]
                               .Concat(aggregateExtension.ExtensionEntityNames)
                               .ToArray();

                        // Build reverse index, entity to aggregate
                        aggregateExtension.ExtensionEntityNames.ForEach(
                            n => finalizedAggregateNameByEntityName.Add(n, aggregate.FullName));
                    }

                    // Use convention to filter down processing to just potential extension entities
                    var possibleExtensionEntities = _entities.Where(e => e.Name.EndsWith("Extension"));

                    foreach (var possibleExtensionEntity in possibleExtensionEntities)
                    {
                        AssociationView[] associations;

                        if (!AssociationViewsByEntityFullName.TryGetValue(
                            possibleExtensionEntity.FullName,
                            out associations))
                        {
                            continue;
                        }

                        // Rather than use semantic model functionality here which can lead to unwanted reentry, 
                        // use the raw properties that don't require additional processing
                        var coreAssociation = associations
                           .SingleOrDefault(x => x.AssociationType == AssociationViewType.FromCore);

                        if (coreAssociation != null)
                        {
                            var coreEntity = coreAssociation.OtherEntity;

                            finalizedAggregateNameByEntityName.Add(
                                possibleExtensionEntity.FullName,
                                _aggregateNameByEntityName[coreEntity.FullName]);
                        }
                    }

                    return new ReadOnlyDictionary<FullName, FullName>(finalizedAggregateNameByEntityName);
                }
            );

            _schemaNameMapProvider = new Lazy<ISchemaNameMapProvider>(() => new SchemaNameMapProvider(Schemas));
        }

        public ISchemaNameMapProvider SchemaNameMapProvider
        {
            get { return _schemaNameMapProvider.Value; }
        }

        public IReadOnlyList<Entity> Entities => _entities.ToReadOnlyList();

        public IReadOnlyList<Association> Associations => _associations.ToReadOnlyList();

        public IReadOnlyList<Aggregate> Aggregates => _aggregates.ToReadOnlyList();

        public IReadOnlyDictionary<FullName, Association> AssociationByFullName
            => new ReadOnlyDictionary<FullName, Association>(_associationByFullName);

        public IReadOnlyDictionary<FullName, Entity> EntityByFullName => new ReadOnlyDictionary<FullName, Entity>(_entityByFullName);

        internal IReadOnlyDictionary<FullName, FullName[]> EntityFullNamesByAggregateFullName
            => new ReadOnlyDictionary<FullName, FullName[]>(_entityFullNamesByAggregateFullName);

        public IReadOnlyDictionary<FullName, Aggregate> AggregateByName => new ReadOnlyDictionary<FullName, Aggregate>(_aggregateByName);

        internal IReadOnlyDictionary<FullName, FullName> AggregateFullNameByEntityFullName => _finalizedAggregateFullNameByEntityFullName.Value;

        public IReadOnlyList<Schema> Schemas => _schemas.Values.ToList();

        public IReadOnlyDictionary<FullName, AssociationView[]> AssociationViewsByEntityFullName => _associationViewsByEntityFullName.Value;

        public ResourceModel ResourceModel => _resourceModel ?? (_resourceModel = new ResourceModel(this));

        internal void AddDomainModelDefinitions(DomainModelDefinitions domainModelDefinitions)
        {
            (domainModelDefinitions.AggregateDefinitions ?? new AggregateDefinition[0])
               .ForEach(AddAggregate);

            (domainModelDefinitions.EntityDefinitions ?? new EntityDefinition[0])
               .ForEach(AddEntity);

            (domainModelDefinitions.AssociationDefinitions ?? new AssociationDefinition[0])
               .ForEach(AddAssociation);

            (domainModelDefinitions.AggregateExtensionDefinitions ?? new AggregateExtensionDefinition[0])
               .ForEach(AddAggregateExtension);

            AddSchema(domainModelDefinitions.SchemaDefinition ?? new SchemaDefinition());
        }

        internal void AddEntity(EntityDefinition entityDefinition)
        {
            var entity = new Entity(this, entityDefinition);

            // Defensive programming to prevent unexpected behavior caused by "missing" extensions
            if (_finalizedAggregateFullNameByEntityFullName.IsValueCreated)
            {
                throw new InvalidOperationException(
                    $"Entity '{entity.FullName}' is being added after the domain model has been processed for extension entities.");
            }

            _entities.Add(entity);
            _entityByFullName.Add(entity.FullName, entity);
        }

        /// <summary>
        /// Adds an AggregateDefinition the DomainModel
        /// </summary>
        /// <param name="aggregateDefinition"></param>
        internal void AddAggregate(AggregateDefinition aggregateDefinition)
        {
            var aggregate = new Aggregate(this, aggregateDefinition);

            // Defensive programming to prevent unexpected behavior caused by "missing" extensions
            if (_finalizedAggregateFullNameByEntityFullName.IsValueCreated)
            {
                throw new InvalidOperationException(
                    $"Aggregate '{aggregate.FullName}' is being added after the domain model has been processed for extension entities.");
            }

            _aggregates.Add(aggregate);

            _aggregateByName.Add(aggregate.FullName, aggregate);

            // Record aggregate, and its members (by name)
            _entityFullNamesByAggregateFullName.Add(aggregate.FullName, aggregate.MemberEntityNames);

            // Build reverse index, entity to aggregate
            aggregate.MemberEntityNames.ForEach(
                n => _aggregateNameByEntityName.Add(n, aggregate.FullName));
        }

        internal void AddAssociation(AssociationDefinition associationDefinition)
        {
            var association = new Association(this, associationDefinition);

            // Defensive programming to prevent unexpected behavior caused by "missing" extensions
            if (_finalizedAggregateFullNameByEntityFullName.IsValueCreated)
            {
                throw new InvalidOperationException(
                    $"Association '{association.FullName}' is being added after the domain model has been processed for extension entities.");
            }

            if (_associationByFullName.ContainsKey(association.FullName))
            {
                throw new Exception($"Association '{association.FullName}' already exists.");
            }

            _associationByFullName.Add(association.FullName, association);
            _associations.Add(association);

            var primaryAssociation = new AssociationView(this, association, true);
            AddAssociationView(primaryAssociation, association.PrimaryEntityFullName);

            var secondaryAssociation = new AssociationView(this, association, false);
            AddAssociationView(secondaryAssociation, association.SecondaryEntityFullName);

            primaryAssociation.Inverse = secondaryAssociation;
            secondaryAssociation.Inverse = primaryAssociation;
        }

        internal void AddSchema(SchemaDefinition schemaDefinition)
        {
            Schema schema = new Schema(schemaDefinition.LogicalName, schemaDefinition.PhysicalName, schemaDefinition.Version);
            _schemas.Add(schema.PhysicalName, schema);
        }

        private void AddAssociationView(AssociationView associationView, FullName entityName)
        {
            List<AssociationView> associationViews;

            if (!_associationViewsByEntityNameMutable.TryGetValue(entityName, out associationViews))
            {
                associationViews = new List<AssociationView>();
                _associationViewsByEntityNameMutable[entityName] = associationViews;
            }

            associationViews.Add(associationView);
        }

        public void AddAggregateExtension(AggregateExtensionDefinition aggregateExtensionDefinition)
        {
            // Defensive programming to prevent unexpected behavior caused by "missing" extensions
            if (_finalizedAggregateFullNameByEntityFullName.IsValueCreated)
            {
                throw new InvalidOperationException(
                    $"Aggregate extensions to '{aggregateExtensionDefinition.AggregateRootEntityName}' aggregate are being added after the domain model has been processed for extension entities.");
            }

            var aggregateExtension = new AggregateExtension(this, aggregateExtensionDefinition);
            _aggregateExtensions.Add(aggregateExtension);
        }
    }
}

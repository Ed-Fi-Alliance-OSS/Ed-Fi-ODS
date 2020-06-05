// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;
using log4net;

namespace EdFi.Ods.Api.Common.Infrastructure.Extensibility
{
    public class EntityExtensionRegistrar : IEntityExtensionRegistrar
    {
        private readonly ConcurrentDictionary<Type, IList<string>> _aggregateExtensionEntityNamesByType
            = new ConcurrentDictionary<Type, IList<string>>();
        private readonly DomainModel _domainModel;

        private readonly ConcurrentDictionary<Type, Dictionary<string, EntityExtension>> _entityExtensionsByEntityType
            = new ConcurrentDictionary<Type, Dictionary<string, EntityExtension>>();

        private readonly ILog _logger = LogManager.GetLogger(typeof(EntityExtensionRegistrar));

        public EntityExtensionRegistrar(IEnumerable<Assembly> extensionAssemblies, DomainModel domainModel)
        {
            _domainModel = domainModel;

            foreach (Assembly extensionAssembly in extensionAssemblies)
            {
                RegisterExtensions(extensionAssembly);
            }
        }

        public IDictionary<Type, Dictionary<string, EntityExtension>> EntityExtensionsByEntityType
        {
            get => _entityExtensionsByEntityType;
        }

        public IDictionary<Type, IList<string>> AggregateExtensionEntityNamesByType
        {
            get => _aggregateExtensionEntityNamesByType;
        }

        /// <summary>
        /// Registers an Ed-Fi entity extension type to enable the creation of aggregate extension entries during entity initialization.
        /// </summary>
        /// <param name="edFiStandardEntityType">The type of the Ed-Fi Standard entity.</param>
        /// <param name="aggregateExtensionEntity">The <see cref="EdFi.Ods.Common.Models.Domain.Entity" /> representing the Ed-Fi extension entity added to an Ed-Fi standard aggregate.</param>
        private void RegisterAggregateExtensionEntity(Type edFiStandardEntityType, Entity aggregateExtensionEntity)
        {
            _logger.Debug($"updating {nameof(edFiStandardEntityType)} with aggregate extension {aggregateExtensionEntity.FullName}");
            if (!edFiStandardEntityType.IsSubclassOf(typeof(EntityWithCompositeKey)))
            {
                throw new ArgumentException(
                    $"{nameof(edFiStandardEntityType)} is not an entity Type.",
                    nameof(edFiStandardEntityType));
            }

            if (!aggregateExtensionEntity.IsAggregateExtension)
            {
                throw new Exception($"{nameof(aggregateExtensionEntity)} is not an aggregate extension entity.");
            }

            _aggregateExtensionEntityNamesByType.AddOrUpdate(
                edFiStandardEntityType,
                t => new List<string> {ExtensionsConventions.GetAggregateExtensionMemberName(aggregateExtensionEntity)},
                (t, n) =>
                {
                    string extensionCollectionName =
                        ExtensionsConventions.GetAggregateExtensionMemberName(aggregateExtensionEntity);

                    n.Add(extensionCollectionName);
                    return n;
                });
        }

        /// <summary>
        /// Registers an Ed-Fi entity extension type to enable the creation of the entity extension objects during entity initialization.
        /// </summary>
        /// <param name="edFiStandardEntityType">The <see cref="System.Type"/> of the Ed-Fi entity.</param>
        /// <param name="extensionName">The name of the Ed-Fi extension.</param>
        /// <param name="extensionType">The <see cref="System.Type"/> of the Ed-Fi extension entity.</param>
        /// <param name="isRequired">Indicates whether the presence of the entity extension is required or optional.</param>
        private void RegisterEntityExtensionType(
            Type edFiStandardEntityType,
            string extensionName,
            Type extensionType,
            bool isRequired)
        {
            _logger.Debug($"updating {nameof(edFiStandardEntityType)} with extension {extensionName}");
            if (string.IsNullOrWhiteSpace(extensionName))
            {
                throw new ArgumentNullException($"{nameof(extensionName)} cannot be null or empty.", nameof(extensionName));
            }

            if (!edFiStandardEntityType.IsSubclassOf(typeof(EntityWithCompositeKey)))
            {
                throw new ArgumentException($"Ed-Fi type '{edFiStandardEntityType.Name}' is not an entity Type.");
            }

            if (edFiStandardEntityType == extensionType)
            {
                throw new ArgumentException(
                    $"Ed-Fi type '{edFiStandardEntityType.Name}' is the same as the provided extension type '{extensionType.Name}'.");
            }

            _entityExtensionsByEntityType.AddOrUpdate(
                edFiStandardEntityType,
                type => new Dictionary<string, EntityExtension>
                {
                    {
                        extensionName, new EntityExtension
                        {
                            Type = extensionType,
                            IsRequired = isRequired
                        }
                    }
                },
                (type, extensions) =>
                {
                    if (extensions.ContainsKey(extensionName))
                    {
                        throw new Exception(
                            $"Extension '{extensionName}' for entity type '{edFiStandardEntityType.Name}' is already registered with '{extensionType.FullName}'.");
                    }

                    extensions.Add(
                        extensionName,
                        new EntityExtension
                        {
                            Type = extensionType,
                            IsRequired = isRequired
                        });

                    return extensions;
                });
        }

        private void RegisterExtensions(Assembly assembly)
        {
            try
            {
                string extensionAssemblyName = assembly.GetName()
                    .Name;

                _logger.Debug($"Registering extensions in assembly {extensionAssemblyName}");

                var extensionSchemaProperCaseName = ExtensionsConventions.GetProperCaseNameFromAssemblyName(extensionAssemblyName);

                string schemaPhysicalName = _domainModel.SchemaNameMapProvider
                    .GetSchemaMapByProperCaseName(extensionSchemaProperCaseName)
                    .PhysicalName;

                var extensionsByStandardEntity = _domainModel
                    .Entities
                    .Where(e => e.Schema.Equals(schemaPhysicalName) && (e.IsEntityExtension || e.IsAggregateExtensionTopLevelEntity))
                    .Select(
                        e => new
                        {
                            Parent = e.Parent,
                            Entity = e,
                            IsAggregateExtension = e.IsAggregateExtension,
                            IsEntityExtension = e.IsEntityExtension
                        })
                    .GroupBy(x => x.Parent, x => x)
                    .ToList();

                var aggregateExtensionEntities = extensionsByStandardEntity
                    .SelectMany(x => x)
                    .Where(x => x.IsAggregateExtension)
                    .Select(x => x.Entity);

                var entityExtensions = extensionsByStandardEntity
                    .SelectMany(x => x)
                    .Where(x => x.IsEntityExtension)
                    .Select(
                        x => new
                        {
                            Entity = x.Entity,
                            IsRequired = x.Entity.ParentAssociation.Association.Cardinality == Cardinality.OneToOneExtension
                        });

                // Register aggregate extensions
                foreach (var aggregateExtensionEntity in aggregateExtensionEntities)
                {
                    string standardTypeName = aggregateExtensionEntity.Parent.EntityTypeFullName(EdFiConventions.ProperCaseName);
                    var standardType = Type.GetType($"{standardTypeName}, {Namespaces.Standard.BaseNamespace}");

                    RegisterAggregateExtensionEntity(standardType, aggregateExtensionEntity);
                }

                // Register explicit entity extensions
                foreach (var entityExtension in entityExtensions)
                {
                    string standardTypeName =
                        entityExtension.Entity.EdFiStandardEntity.EntityTypeFullName(EdFiConventions.ProperCaseName);

                    var standardType = Type.GetType($"{standardTypeName}, {Namespaces.Standard.BaseNamespace}");

                    string extensionTypeName = entityExtension.Entity.EntityTypeFullName(extensionSchemaProperCaseName);
                    var extensionType = Type.GetType($"{extensionTypeName}, {extensionAssemblyName}");

                    RegisterEntityExtensionType(
                        standardType,
                        extensionSchemaProperCaseName,
                        extensionType,
                        entityExtension.IsRequired);
                }

                // Register implicit entity extensions
                // Filter down to just the standard entities that have aggregate extensions, but no entity extensions (need implicit extension classes registered)
                var implicitlyExtendedEntities = extensionsByStandardEntity
                    .Where(p => p.Any(x => x.IsAggregateExtension) && !p.Any(x => x.IsEntityExtension));

                foreach (var implicitlyExtendedEntity in implicitlyExtendedEntities)
                {
                    string standardTypeName = implicitlyExtendedEntity.Key.EntityTypeFullName(EdFiConventions.ProperCaseName);
                    var standardType = Type.GetType($"{standardTypeName}, {Namespaces.Standard.BaseNamespace}");

                    string extensionClassAssemblyQualifiedName =
                        ExtensionsConventions.GetExtensionClassAssemblyQualifiedName(standardType, extensionSchemaProperCaseName);

                    var extensionType = Type.GetType(extensionClassAssemblyQualifiedName);

                    RegisterEntityExtensionType(standardType, extensionSchemaProperCaseName, extensionType, isRequired: true);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }
    }
}

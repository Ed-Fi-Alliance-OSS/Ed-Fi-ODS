// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Extensibility
{
    /// <summary>
    /// Manages the registration and creation of Ed-Fi extension types.
    /// </summary>
    public class EntityExtensionsFactory : IEntityExtensionsFactory, IEntityExtensionRegistrar
    {
        protected static EntityExtensionsFactory _instance = new EntityExtensionsFactory();

        private readonly ConcurrentDictionary<Type, IList<string>> _aggregateExtensionEntityNamesByType
            = new ConcurrentDictionary<Type, IList<string>>();

        private readonly ConcurrentDictionary<Type, Dictionary<string, EntityExtension>> _entityExtensionsByEntityType
            = new ConcurrentDictionary<Type, Dictionary<string, EntityExtension>>();

        private class EntityExtension
        {
            public Type Type { get; set; }

            public bool IsRequired { get; set; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityExtensionsFactory"/> class, protected so as to implement the Singleton pattern.
        /// </summary>
        protected EntityExtensionsFactory() { }

        /// <summary>
        /// Gets the singleton instance of the factory for creating aggregate and entity extensions.
        /// </summary>
        /// <remarks>This property is used to make the factory available to the entity classes during initialization since they are not managed by the IoC container.</remarks>
        public static EntityExtensionsFactory Instance => _instance;

        /// <summary>
        /// Registers an Ed-Fi entity extension type to enable the creation of aggregate extension entries during entity initialization.
        /// </summary>
        /// <param name="edFiStandardEntityType">The type of the Ed-Fi Standard entity.</param>
        /// <param name="aggregateExtensionEntity">The <see cref="Entity" /> representing the Ed-Fi extension entity added to an Ed-Fi standard aggregate.</param>
        public void RegisterAggregateExtensionEntity(Type edFiStandardEntityType, Entity aggregateExtensionEntity)
        {
            if (!edFiStandardEntityType.IsSubclassOf(typeof(EntityWithCompositeKey)))
            {
                throw new ArgumentException($"{nameof(edFiStandardEntityType)} is not an entity Type.", nameof(edFiStandardEntityType));
            }

            if (!aggregateExtensionEntity.IsAggregateExtension)
            {
                throw new Exception($"{nameof(aggregateExtensionEntity)} is not an aggregate extension entity.");
            }

            _aggregateExtensionEntityNamesByType.AddOrUpdate(
                edFiStandardEntityType,
                t => new List<string>
                     {
                         ExtensionsConventions.GetAggregateExtensionMemberName(aggregateExtensionEntity)
                     },
                (t, n) =>
                {
                    string extensionCollectionName = ExtensionsConventions.GetAggregateExtensionMemberName(aggregateExtensionEntity);
                    n.Add(extensionCollectionName);
                    return n;
                });
        }

        /// <summary>
        /// Registers an Ed-Fi entity extension type to enable the creation of the entity extension objects during entity initialization.
        /// </summary>
        /// <param name="edFiStandardEntityType">The <see cref="Type"/> of the Ed-Fi entity.</param>
        /// <param name="extensionName">The name of the Ed-Fi extension.</param>
        /// <param name="extensionType">The <see cref="Type"/> of the Ed-Fi extension entity.</param>
        /// <param name="isRequired">Indicates whether the presence of the entity extension is required or optional.</param>
        public void RegisterEntityExtensionType(
            Type edFiStandardEntityType,
            string extensionName,
            Type extensionType,
            bool isRequired)
        {
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
                                extensionName, new EntityExtension { Type = extensionType, IsRequired = isRequired }
                            }
                        },
                (type, extensions) =>
                {
                    if (extensions.ContainsKey(extensionName))
                    {
                        throw new Exception(
                            $"Extension '{extensionName}' for entity type '{edFiStandardEntityType.Name}' is already registered with '{extensionType.FullName}'.");
                    }

                    extensions.Add(extensionName, new EntityExtension { Type = extensionType, IsRequired = isRequired });
                    return extensions;
                });
        }

        /// <summary>
        /// Creates an <see cref="IDictionary"/> containing new instances of the registered entity extension types 
        /// for the Ed-Fi "core" entity specified by <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The Ed-Fi "core" entity type.</typeparam>
        /// <returns>A <see cref="IDictionary"/> containing the initialized entity extension instances, by extension name.</returns>
        /// <remarks>The semantics of the database-level extensions behavior is that an extension instance is always present, even if all the values are the defaults.</remarks>
        public IDictionary<string, object> CreateRequiredEntityExtensions<TEntity>(object parentEntity)
            where TEntity : EntityWithCompositeKey
        {
            Dictionary<string, EntityExtension> extensions;

            return _entityExtensionsByEntityType.TryGetValue(typeof(TEntity), out extensions)
                ? extensions.Where(x => x.Value.IsRequired)
                    .ToDictionary(
                        x => x.Key,
                        x =>
                        {
                            var extensionObject = (IChildEntity) Activator.CreateInstance(x.Value.Type);
                            extensionObject.SetParent(parentEntity);

                            return (object) new List<object> {extensionObject};
                        })
                : new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates an <see cref="IDictionary"/> containing new instances of the registered aggregate extension types 
        /// for the Ed-Fi standard entity specified by <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The Ed-Fi standard entity type.</typeparam>
        /// <returns>A <see cref="IDictionary"/> containing the initialized aggregate extension instances, by collection name.</returns>
        public IDictionary<string, object> CreateAggregateExtensions<TEntity>()
            where TEntity : EntityWithCompositeKey
        {
            IList<string> aggregateExtensions;

            return _aggregateExtensionEntityNamesByType.TryGetValue(typeof(TEntity), out aggregateExtensions)
                ? aggregateExtensions.ToDictionary(x => x, x => (object) new List<object>())
                : new Dictionary<string, object>();
        }
    }
}

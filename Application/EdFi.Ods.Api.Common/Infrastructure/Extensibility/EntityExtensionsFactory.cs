// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Infrastructure.Extensibility
{
    /// <summary>
    /// Manages the registration and creation of Ed-Fi extension types.
    /// </summary>
    public class EntityExtensionsFactory : IEntityExtensionsFactory
    {
        private readonly IEntityExtensionRegistrar _entityExtensionRegistrar;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityExtensionsFactory"/> class, protected so as to implement the Singleton pattern.
        /// </summary>
        public EntityExtensionsFactory(IEntityExtensionRegistrar entityExtensionRegistrar)
        {
            _entityExtensionRegistrar = entityExtensionRegistrar;
        }

        /// <summary>
        /// Gets the singleton instance of the factory for creating aggregate and entity extensions.
        /// </summary>
        /// <remarks>This property is used to make the factory available to the entity classes during initialization since they are not managed by the IoC container.</remarks>
        public static IEntityExtensionsFactory Instance { get; set; }

        /// <summary>
        /// Creates an <see cref="System.Collections.IDictionary"/> containing new instances of the registered entity extension types 
        /// for the Ed-Fi "core" entity specified by <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The Ed-Fi "core" entity type.</typeparam>
        /// <returns>A <see cref="System.Collections.IDictionary"/> containing the initialized entity extension instances, by extension name.</returns>
        /// <remarks>The semantics of the database-level extensions behavior is that an extension instance is always present, even if all the values are the defaults.</remarks>
        public IDictionary<string, object> CreateRequiredEntityExtensions<TEntity>(object parentEntity)
            where TEntity : EntityWithCompositeKey
        {
            return _entityExtensionRegistrar.EntityExtensionsByEntityType.TryGetValue(
                typeof(TEntity), out Dictionary<string, EntityExtension> extensions)
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
        /// Creates an <see cref="System.Collections.IDictionary"/> containing new instances of the registered aggregate extension types 
        /// for the Ed-Fi standard entity specified by <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The Ed-Fi standard entity type.</typeparam>
        /// <returns>A <see cref="System.Collections.IDictionary"/> containing the initialized aggregate extension instances, by collection name.</returns>
        public IDictionary<string, object> CreateAggregateExtensions<TEntity>()
            where TEntity : EntityWithCompositeKey
        {
            return _entityExtensionRegistrar.AggregateExtensionEntityNamesByType.TryGetValue(
                typeof(TEntity), out IList<string> aggregateExtensions)
                ? aggregateExtensions.ToDictionary(x => x, x => (object) new List<object>())
                : new Dictionary<string, object>();
        }
    }
}

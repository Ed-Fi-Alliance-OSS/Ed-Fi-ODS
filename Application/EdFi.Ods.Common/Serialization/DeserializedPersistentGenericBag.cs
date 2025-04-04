// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using NHibernate.Collection.Generic;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Common.Serialization;

public class Persisters
{
    public IEntityPersister EntityPersister;
    public ICollectionPersister CollectionPersister;
    public string Role;
}

[SuppressMessage("ReSharper", "StaticMemberInGenericType")]
public class DeserializedPersistentGenericBag<T> : PersistentGenericBag<T>, IDeserializedPersistentGenericCollection
{
    private static readonly ConcurrentDictionary<(Type, string), Persisters> _persistersByTypeAndName = new();

    private readonly ISessionFactoryImplementor _sessionFactory;

    public DeserializedPersistentGenericBag(ISessionFactoryImplementor sessionFactoryImplementor, IList<T> collection)
    {
        _sessionFactory = sessionFactoryImplementor;

        InternalBag = collection;
        SetInitialized();
        IsDirectlyAccessible = true;
    }

    public void ForceInitialized()
    {
        SetInitialized();
    }

    protected override void Initialize(bool writing)
    {
        SetInitialized();
    }

    protected override Task InitializeAsync(bool writing, CancellationToken cancellationToken)
    {
        SetInitialized();

        return Task.CompletedTask;
    }

    public void Reattach(object parent, string collectionPropertyName)
    {
        // Only process if we haven't already
        if (Owner == null)
        {
            var persisters = GetPersisters(parent, collectionPropertyName);
    
            var id = persisters.EntityPersister.GetIdentifier(parent);
            var snapshot = GetSnapshot(persisters.CollectionPersister);
    
            Owner = parent;
            SetSnapshot(id, persisters.Role, snapshot);
        }
    }

    public void ReattachExtension(object parent, string schemaName)
    {
        if (Owner == null)
        {
            var persisters = GetPersisters(parent, $"Extensions.{schemaName}");

            // Don't process implicit entity extensions, for which the collection persister will be null
            if (persisters.CollectionPersister != null)
            {
                var id = persisters.EntityPersister.GetIdentifier(parent);
                var snapshot = GetSnapshot(persisters.CollectionPersister);

                Owner = parent;
                SetSnapshot(id, persisters.Role, snapshot);
            }

            // Set the back-reference for each item in the collection
            foreach (IChildEntity item in this)
            {
                item.SetParent(parent);
            }
        }
    }

    public void ReattachAggregateExtension(object parent, string schemaCollectionName)
    {
        if (Owner == null)
        {
            var persisters = GetPersisters(parent, $"AggregateExtensions.{schemaCollectionName}");

            var id = persisters.EntityPersister.GetIdentifier(parent);
            var snapshot = GetSnapshot(persisters.CollectionPersister);

            foreach (IChildEntity item in this)
            {
                item.SetParent(parent);
            }
            
            Owner = parent;
            SetSnapshot(id, persisters.Role, snapshot);
        }
    }

    private Persisters GetPersisters(object parent, string collectionPropertyName)
    {
        return _persistersByTypeAndName.GetOrAdd(
            (parent.GetType(), collectionPropertyName),
            static (pt, args) =>
            {
                string parentTypeName = pt.Item1.FullName;
                var entityPersister = args.sessionFactory.GetEntityPersister(parentTypeName);

                ICollectionPersister collectionPersister = null;
                string role = null;

                if (entityPersister.IsInherited)
                {
                    try
                    {
                        // Look on the base class first
                        role = $"{entityPersister.EntityMetamodel.Superclass}.{args.collectionPropertyName}";
                        collectionPersister = args.sessionFactory.GetCollectionPersister(role);
                    }
                    catch { /* Ignore */ }
                }

                if (collectionPersister == null)
                {
                    try
                    {
                        role = $"{parentTypeName}.{args.collectionPropertyName}";
                        collectionPersister = args.sessionFactory.GetCollectionPersister(role);
                    }
                    catch { /* Ignore */ }
                }

                return new Persisters()
                {
                    EntityPersister = entityPersister,
                    CollectionPersister = collectionPersister,
                    Role = role
                };
            }, (collectionPropertyName, sessionFactory: _sessionFactory ));
    }
}

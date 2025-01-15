// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Repositories;
using NHibernate.Engine;

namespace EdFi.Ods.Common.Serialization;

/// <summary>
/// Implements a decorator that wraps the collection that contains the entity extension objects for persistence in a
/// deserialization-friendly generic persistent bag.
/// </summary>
public class DeserializedEntityExtensionContainingCollectionInitializerDecorator : IEntityExtensionContainingCollectionInitializer
{
    private readonly IEntityExtensionContainingCollectionInitializer _decoratedInstance;
    private readonly IDeserializationContextProvider _deserializationContextProvider;
    private readonly ISessionFactoryImplementor _sessionFactoryImplementor;

    // private readonly Lazy<ISessionFactoryImplementor> _sessionFactoryImplementor;

    public DeserializedEntityExtensionContainingCollectionInitializerDecorator(
        IEntityExtensionContainingCollectionInitializer decoratedInstance,
        IDeserializationContextProvider deserializationContextProvider,
        ISessionFactoryImplementor sessionFactoryImplementor)
        // Func<ISessionFactoryImplementor> getSessionFactoryImplementor)
    {
        _decoratedInstance = decoratedInstance;
        _deserializationContextProvider = deserializationContextProvider;
        _sessionFactoryImplementor = sessionFactoryImplementor;

        // _sessionFactoryImplementor = new Lazy<ISessionFactoryImplementor>(() => getSessionFactoryImplementor());
    }

    public object CreateContainingCollection()
    {
        var collection = _decoratedInstance.CreateContainingCollection();

        // If we're deserializing, wrap the collection in a persistent bag for reassociating with NHibernate session
        if (_deserializationContextProvider.IsDeserializing())
        {
            return DeserializedPersistentCollectionHelpers.CreatePersistentBag(
                _sessionFactoryImplementor,
                collection);
        }

        return collection;
    }

    public object CreateContainingCollection(object extensionObject)
    {
        // If we're deserializing, do not add the supplied default extension object instance to the collection
        if (_deserializationContextProvider.IsDeserializing())
        {
            var collection = CreateContainingCollection();

            return DeserializedPersistentCollectionHelpers.CreatePersistentBag(
                _sessionFactoryImplementor,
                collection);
        }

        // Return the simple list when not deserializing
        return CreateContainingCollection(extensionObject);
    }
}

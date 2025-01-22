// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.AspNetCore.Http;
using NHibernate.Engine;

namespace EdFi.Ods.Common.Serialization;

/// <summary>
/// Implements a decorator that wraps the collection initializer that, when deserializing an aggregate for subsequent
/// modification with NHibernate, creates deserialization-friendly generic persistent bags to provide support for
/// re-associating the collections with the current NHibernate session.
/// </summary>
public class DeserializedEntityExtensionContainingCollectionInitializerDecorator : IEntityExtensionContainingCollectionInitializer
{
    private readonly IEntityExtensionContainingCollectionInitializer _decoratedInstance;
    private readonly IDeserializationContextProvider _deserializationContextProvider;
    private readonly Func<ISessionFactoryImplementor> _getSessionFactoryImplementor;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementRequestContextProvider;

    public DeserializedEntityExtensionContainingCollectionInitializerDecorator(
        IEntityExtensionContainingCollectionInitializer decoratedInstance,
        IDeserializationContextProvider deserializationContextProvider,
        Func<ISessionFactoryImplementor> getSessionFactoryImplementor,
        IContextProvider<DataManagementResourceContext> dataManagementRequestContextProvider)
    {
        _decoratedInstance = decoratedInstance;
        _deserializationContextProvider = deserializationContextProvider;
        _getSessionFactoryImplementor = getSessionFactoryImplementor;
        _dataManagementRequestContextProvider = dataManagementRequestContextProvider;
    }

    /// <inheritdoc cref="IEntityExtensionContainingCollectionInitializer.CreateContainingCollection()" />
    public object CreateContainingCollection()
    {
        // If we're initializing for deserialization of a PUT/POST/DELETE request, create an empty persistent collection
        // to enable re-associating it with the current NHibernate session in the  event there is no extension present in
        // the serialized data (which will replace the work being done here).
        if (_deserializationContextProvider.IsDeserializing()
            && (_dataManagementRequestContextProvider.Get()?.HttpMethod == HttpMethods.Post
                || _dataManagementRequestContextProvider.Get()?.HttpMethod == HttpMethods.Delete
                || _dataManagementRequestContextProvider.Get()?.HttpMethod == HttpMethods.Put))
        {
            return DeserializedPersistentCollectionHelpers.CreatePersistentBag(_getSessionFactoryImplementor());
        }

        // Return the simple list when not deserializing
        return _decoratedInstance.CreateContainingCollection();
    }

    /// <inheritdoc cref="IEntityExtensionContainingCollectionInitializer.CreateContainingCollection(System.Type,object)" />
    public object CreateContainingCollection(Type extensionObjectType, object parentEntity)
    {
        // If we're initializing for deserialization of a PUT/POST/DELETE request, create an empty persistent collection
        // (without any default extension object) to enable re-associating it with the current NHibernate session in the
        // event there is no extension present in the serialized data (which will replace the work being done here).
        if (_deserializationContextProvider.IsDeserializing()
            && (_dataManagementRequestContextProvider.Get()?.HttpMethod == HttpMethods.Post 
                || _dataManagementRequestContextProvider.Get()?.HttpMethod == HttpMethods.Delete
                || _dataManagementRequestContextProvider.Get()?.HttpMethod == HttpMethods.Put))
        {
            return DeserializedPersistentCollectionHelpers.CreatePersistentBag(_getSessionFactoryImplementor());
        }

        // Create and return the default entity in a simple list
        return _decoratedInstance.CreateContainingCollection(extensionObjectType, parentEntity);
    }
}

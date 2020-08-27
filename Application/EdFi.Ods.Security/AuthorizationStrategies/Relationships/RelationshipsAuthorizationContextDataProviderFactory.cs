// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using EdFi.Ods.Common.InversionOfControl;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Defines a method for obtaining an <see cref="IRelationshipsAuthorizationContextDataProvider{TContextData}"/>
    /// for the specified <i>concrete</i> model type.
    /// </summary>
    /// <remarks>This interface is intended to be used as a non-generic invocation mechanism from within the
    /// <see cref="RelationshipsAuthorizationContextDataProviderFactory{TContextData}"/> for invoking the non-generic implementation
    /// after obtaining it from the <see cref="IServiceLocator"/>.  The crux of the issue is that the context
    /// data providers are implemented and registered based on the model abstraction (e.g. IStudent) rather than 
    /// either of the concrete models (e.g. Student (resource) or Student (entity)).</remarks>
    public class RelationshipsAuthorizationContextDataProviderFactory<TContextData>
        : IRelationshipsAuthorizationContextDataProviderFactory<TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        // ReSharper disable once StaticMemberInGenericType
        private static readonly ConcurrentDictionary<Type, Type> ProvidersByModelType = new ConcurrentDictionary<Type, Type>();
        private readonly IServiceLocator _serviceLocator;

        public RelationshipsAuthorizationContextDataProviderFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        /// <summary>
        /// Get the <see cref="IRelationshipsAuthorizationContextDataProvider{TContextData}"/> implementation appropriate for the
        /// concrete model type specified (resolving to the IoC registration for the model's interface 
        /// abstraction [e.g. IStudent]).
        /// </summary>
        ///// <typeparam name="TConcreteModel">The concrete model class type.</typeparam>
        /// <returns>The non-generic context data provider for the requested concrete model type.</returns>
        public IRelationshipsAuthorizationContextDataProvider<TContextData> GetProvider(Type entityType)
        {
            Type lookupType = GetProviderLookupType(entityType);

            try
            {
                var provider = (IRelationshipsAuthorizationContextDataProvider<TContextData>)
                    _serviceLocator.Resolve(lookupType);

                return provider;
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(
                    string.Format(
                        "Unable to locate a relationships authorization context data provider for entity type '{0}'.  Does it have any properties related to relationship-based authorization, and should it be getting authorized using a relationships-based authorization strategy?",
                        entityType.FullName),
                    ex);
            }
        }

        protected Type GetProviderLookupType(Type model)
        {
            var providerType = ProvidersByModelType.GetOrAdd(
                model,
                mt =>
                {
                    // TODO: Embedded convention
                    // Look for abstraction by convention (I + model's class name)
                    var modelInterface = mt.IsInterface
                        ? mt
                        : mt.GetInterface("I" + mt.Name);

                    // Create the type to be used to find the model's abstraction-based container registration
                    var lookupType = typeof(IRelationshipsAuthorizationContextDataProvider<,>)
                       .MakeGenericType(modelInterface, typeof(TContextData));

                    return lookupType;
                });

            return providerType;
        }
    }
}

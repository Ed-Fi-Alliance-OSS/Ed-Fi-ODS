// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.InversionOfControl;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Defines a generic method for obtaining Ed-Fi authorization context data for a specific entity type.
    /// </summary>
    /// <typeparam name="TAbstractModel">The abstract model type (e.g. IStudent) for which to retrieve authorization context data.</typeparam>
    /// <typeparam name="TContextData"></typeparam>
    public interface IRelationshipsAuthorizationContextDataProvider<in TAbstractModel, out TContextData>
        : IRelationshipsAuthorizationContextDataProvider<TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Gets the Ed-Fi authorization context data to be used in an authorization decision.
        /// </summary>
        /// <param name="resource">The resource model from which authorization context data is to be derived.</param>
        /// <returns>The authorization context data.</returns>
        TContextData GetContextData(TAbstractModel resource);
    }

    /// <summary>
    /// Defines a non-generic method for obtaining Ed-Fi authorization context data for a specific entity type.
    /// </summary>
    /// <remarks>This interface is intended to be used as a non-generic invocation mechanism from within the
    /// <see cref="RelationshipsAuthorizationContextDataProviderFactory{TContextData}"/> for invoking the non-generic implementation
    /// after obtaining it from the <see cref="IServiceLocator"/>.  The crux of the issue is that the context
    /// data providers are implemented and registered based on the model abstraction (e.g. IStudent) rather than 
    /// either of the concrete models (e.g. Student (resource) or Student (entity)).
    /// </remarks>
    public interface IRelationshipsAuthorizationContextDataProvider<out TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        /// <summary>
        /// Gets the Ed-Fi authorization context data to be used in an authorization decision.
        /// </summary>
        /// <param name="resource">The resource model from which authorization context data is to be derived.</param>
        /// <returns>The authorization context data.</returns>
        TContextData GetContextData(object resource);

        /// <summary>
        /// Gets the properties that are relevant for relationship-based authorization.
        /// </summary>
        /// <returns>The names of the properties to be used for the authorization context.</returns>
        string[] GetAuthorizationContextPropertyNames();
    }
}

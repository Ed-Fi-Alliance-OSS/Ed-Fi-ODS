// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Security.Authorization.Repositories
{
    /// <summary>
    /// Authorizes calls to the "GetByKey" repository method.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of entity being queried.</typeparam>
    public class GetEntityByKeyAuthorizationDecorator<T>
        : RepositoryOperationAuthorizationDecoratorBase<T>, IGetEntityByKey<T>
        where T : class, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IGetEntityByKey<T> _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEntityByKeyAuthorizationDecorator{T}"/> class. 
        /// </summary>
        /// <param name="next">The decorated instance for which authorization is being performed.</param>
        /// <param name="authorizationContextProvider">Provides access to the authorization context, such as the resource and action.</param>
        /// <param name="authorizationProvider">The component capable of authorizing the request, given necessary context.</param>
        public GetEntityByKeyAuthorizationDecorator(
            IGetEntityByKey<T> next,
            IAuthorizationContextProvider authorizationContextProvider,
            IEdFiAuthorizationProvider authorizationProvider)
            : base(authorizationContextProvider, authorizationProvider)
        {
            _next = next;
        }

        /// <summary>
        /// Authorizes a call to get a single entity by its key.
        /// </summary>
        /// <param name="specification">An entity instance that has all the primary key properties assigned with values.</param>
        /// <returns>The specified entity if found; otherwise null.</returns>
        public async Task<T> GetByKeyAsync(T specification, CancellationToken cancellationToken)
        {
            // Pass the call through to the decorated repository method to get the entity
            // to allow the 404 "Not Found" exception to be detected prior to an authorization
            // exception.
            var entity = await _next.GetByKeyAsync(specification, cancellationToken);

            // Now that we know the entity exists, authorize access to it
            if (entity != null)
            {
                await AuthorizeSingleItemAsync(entity, cancellationToken);
            }

            return entity;
        }
    }
}

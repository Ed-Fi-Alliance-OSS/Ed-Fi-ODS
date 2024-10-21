// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Api.Security.Authorization.Repositories;

/// <summary>
/// Authorizes calls to the "GetByAggregateIds" repository method.
/// </summary>
/// <typeparam name="T">The Type of entity being queried.</typeparam>
public class GetEntitiesByAggregateIdsAuthorizationDecorator<T> : IGetEntitiesByAggregateIds<T>
    where T : class, IHasIdentifier, IDateVersionedEntity
{
    private readonly IGetEntitiesByAggregateIds<T> _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetEntitiesByAggregateIdsAuthorizationDecorator{T}"/> class.
    /// </summary>
    /// <param name="next">The decorated instance for which authorization is being performed.</param>
    public GetEntitiesByAggregateIdsAuthorizationDecorator(IGetEntitiesByAggregateIds<T> next)
    {
        _next = next;
    }

    /// <summary>
    /// Authorizes a call to get multiple records by their record identifiers.
    /// </summary>
    /// <param name="aggregateIds">The values of the record identifiers to be retrieved.</param>
    /// <returns>The specified entity if found; otherwise null.</returns>
    public async Task<IList<T>> GetByAggregateIdsAsync(IList<int> aggregateIds, CancellationToken cancellationToken)
    {
        return await _next.GetByAggregateIdsAsync(aggregateIds, cancellationToken);
    }
}

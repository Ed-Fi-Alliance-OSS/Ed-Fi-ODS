// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Features.SerializedData.Repositories;

/// <summary>
/// Preserves the reference data lookups registered by deserialized aggregates while other aggregates of the same request
/// are loaded through NHibernate.
/// </summary>
/// <remarks>
/// When a page mixes aggregates served from their serialized data with aggregates that must be hydrated by NHibernate
/// (because their serialized data is missing or stale), the NHibernate hydration suppresses reference data tracking and
/// clears the lookup context. The lookups registered by the deserialized aggregates are restored afterward (without
/// resuming tracking) so their missing resource identifiers are still resolved.
/// </remarks>
public class GetEntitiesByAggregateIdsReferenceDataLookupDecorator<TEntity> : IGetEntitiesByAggregateIds<TEntity>
    where TEntity : IHasIdentifier, IDateVersionedEntity
{
    private readonly IGetEntitiesByAggregateIds<TEntity> _decoratedInstance;
    private readonly IContextProvider<ReferenceDataLookupContext> _referenceDataLookupContextProvider;

    public GetEntitiesByAggregateIdsReferenceDataLookupDecorator(
        IGetEntitiesByAggregateIds<TEntity> decoratedInstance,
        IContextProvider<ReferenceDataLookupContext> referenceDataLookupContextProvider)
    {
        _decoratedInstance = decoratedInstance;
        _referenceDataLookupContextProvider = referenceDataLookupContextProvider;
    }

    public async Task<IList<TEntity>> GetByAggregateIdsAsync(IList<int> aggregateIds, CancellationToken cancellationToken)
    {
        var referenceDataLookupContext = _referenceDataLookupContextProvider.Get();

        var pendingReferenceDataLookups = referenceDataLookupContext?.Any() == true
            ? referenceDataLookupContext.Items.ToArray()
            : null;

        var result = await _decoratedInstance.GetByAggregateIdsAsync(aggregateIds, cancellationToken);

        if (pendingReferenceDataLookups != null)
        {
            referenceDataLookupContext.Restore(pendingReferenceDataLookups);
        }

        return result;
    }
}

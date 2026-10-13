// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Features.SerializedData.Repositories;

public class UpdateEntityReferenceDataLookupDecorator<TEntity> : IUpdateEntity<TEntity>
    where TEntity : IHasIdentifier, IDateVersionedEntity
{
    private readonly IUpdateEntity<TEntity> _decoratedInstance;
    private readonly IReferenceDataResolver _referenceDataResolver;

    public UpdateEntityReferenceDataLookupDecorator(
        IUpdateEntity<TEntity> decoratedInstance,
        IReferenceDataResolver referenceDataResolver)
    {
        _decoratedInstance = decoratedInstance;
        _referenceDataResolver = referenceDataResolver;
    }

    public async Task UpdateAsync(TEntity persistentEntity, CancellationToken cancellationToken)
    {
        // Track any reference data of the persisted aggregate that still needs to be resolved (e.g. child items added during
        // synchronization, or existing items of an aggregate hydrated by NHibernate) before it is serialized
        ReferenceDataTracking.TrackUnresolvedReferenceData(persistentEntity);

        await _referenceDataResolver.ResolveReferenceDataAsync();
        
        await _decoratedInstance.UpdateAsync(persistentEntity, cancellationToken);
    }
}

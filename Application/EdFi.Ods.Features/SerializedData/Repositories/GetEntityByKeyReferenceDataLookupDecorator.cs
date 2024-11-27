// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Features.SerializedData.Repositories;

public class GetEntityByKeyReferenceDataLookupDecorator<TEntity> : IGetEntityByKey<TEntity>
    where TEntity : IHasIdentifier, IDateVersionedEntity
{
    private readonly IGetEntityByKey<TEntity> _decoratedInstance;
    private readonly IContextProvider<ReferenceDataLookupContext> _referenceDataLookupContextProvider;

    public GetEntityByKeyReferenceDataLookupDecorator(
        IGetEntityByKey<TEntity> decoratedInstance,
        IContextProvider<ReferenceDataLookupContext> referenceDataLookupContextProvider)
    {
        _decoratedInstance = decoratedInstance;
        _referenceDataLookupContextProvider = referenceDataLookupContextProvider;
    }
    
    public async Task<TEntity> GetByKeyAsync(TEntity specification, CancellationToken cancellationToken)
    {
        var result = await _decoratedInstance.GetByKeyAsync(specification, cancellationToken);

        // If the entity already exists
        if (result != null)
        {
            // Clear the context (if it exists), deferring to synch processing for lookup context
            _referenceDataLookupContextProvider.Get()?.Clear();
        }

        return result;
    }
}

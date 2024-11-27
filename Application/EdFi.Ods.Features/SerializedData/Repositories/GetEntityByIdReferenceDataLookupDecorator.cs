// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Features.SerializedData.Repositories;

public class GetEntityByIdReferenceDataLookupDecorator<TEntity> : IGetEntityById<TEntity>
    where TEntity : IHasIdentifier, IDateVersionedEntity
{
    private readonly IGetEntityById<TEntity> _decoratedInstance;
    private readonly IContextProvider<ReferenceDataLookupContext> _referenceDataLookupContextProvider;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

    public GetEntityByIdReferenceDataLookupDecorator(
        IGetEntityById<TEntity> decoratedInstance,
        IContextProvider<ReferenceDataLookupContext> referenceDataLookupContextProvider,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
    {
        _decoratedInstance = decoratedInstance;
        _referenceDataLookupContextProvider = referenceDataLookupContextProvider;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
    }
    
    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _decoratedInstance.GetByIdAsync(id, cancellationToken);

        // If the entity already exists and we're writing (via a PUT request)
        if (result != null && _dataManagementResourceContextProvider.Get()?.HttpMethod == HttpMethods.Put)
        {
            // Clear the context (if it exists), deferring to synch processing for lookup context
            _referenceDataLookupContextProvider.Get()?.Clear();
        }

        return result;
    }
}

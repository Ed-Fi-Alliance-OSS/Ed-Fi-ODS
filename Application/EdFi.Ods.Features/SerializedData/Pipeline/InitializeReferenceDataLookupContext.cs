// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Features.SerializedData.Pipeline;

public class InitializeReferenceDataLookupContext<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
{
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly IContextProvider<ReferenceDataLookupContext> _referenceDataLookupContextProvider;

    public InitializeReferenceDataLookupContext(
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IContextProvider<ReferenceDataLookupContext> referenceDataLookupContextProvider)
    {
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _referenceDataLookupContextProvider = referenceDataLookupContextProvider;
    }

    public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
    {
        // Establish the necessary context
        _referenceDataLookupContextProvider.Set(new ReferenceDataLookupContext());

        return Task.CompletedTask;
    }
}

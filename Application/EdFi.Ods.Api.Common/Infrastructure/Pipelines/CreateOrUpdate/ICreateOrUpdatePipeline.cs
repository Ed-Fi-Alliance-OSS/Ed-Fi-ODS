// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Put;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.CreateOrUpdate
{
    public interface ICreateOrUpdatePipeline<TResourceModel, TEntityModel>
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier
    {
        Task<PutResult> ProcessAsync(PutContext<TResourceModel, TEntityModel> context, CancellationToken cancellationToken);
    }
}

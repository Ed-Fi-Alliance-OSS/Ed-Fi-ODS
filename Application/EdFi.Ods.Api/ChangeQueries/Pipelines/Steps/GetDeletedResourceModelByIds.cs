// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.ChangeQueries.Pipelines.GetDeletedResource;
using EdFi.Ods.Common;
using EdFi.Ods.Pipelines;
using EdFi.Ods.Pipelines.Common;

namespace EdFi.Ods.Api.ChangeQueries.Pipelines.Steps
{
    public class GetDeletedResourceModelByIds<TContext, TResult, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : GetDeletedResourceContext<TEntityModel>
        where TResult : PipelineResultBase
        where TEntityModel : class, IHasIdentifier
    {
        private readonly IGetDeletedResourceIds _repository;

        public GetDeletedResourceModelByIds(IGetDeletedResourceIds repository)
        {
            _repository = repository;
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}

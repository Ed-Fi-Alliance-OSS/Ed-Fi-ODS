// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Delete;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps
{
    public class DeleteEntityModel<TContext, TResult, TResourceModel, TEntityModel> : IStep<DeleteContext, DeleteResult>
        where TEntityModel : IHasIdentifier
    {
        private readonly IDeleteEntityById<TEntityModel> _repository;

        public DeleteEntityModel(IDeleteEntityById<TEntityModel> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(DeleteContext context, DeleteResult result, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteByIdAsync(context.Id, context.ETag, cancellationToken);
                result.ResourceWasDeleted = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
        }
    }
}

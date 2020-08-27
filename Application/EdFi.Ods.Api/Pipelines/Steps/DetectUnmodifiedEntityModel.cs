// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Exceptions;
using EdFi.Ods.Common;
using EdFi.Ods.Pipelines;
using EdFi.Ods.Pipelines.Common;

namespace EdFi.Ods.Api.Pipelines.Steps
{
    public class DetectUnmodifiedEntityModel<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : IHasPersistentModel<TEntityModel>, IHasETag
        where TResult : PipelineResultBase
        where TEntityModel : class
    {
        private readonly IETagProvider etagProvider;

        public DetectUnmodifiedEntityModel(IETagProvider etagProvider)
        {
            this.etagProvider = etagProvider;
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            // NOTE: the etag provide is always synchronous so it makes no sense to move this code into the async method.
            try
            {
                // Don't process model if ETag isn't present
                if (context.ETag == null)
                {
                    return Task.CompletedTask;
                }

                // Check the ETag for no modifications
                if (context.ETag == etagProvider.GetETag(context.PersistentModel))
                {
                    // TODO: Consider using System.Net.HttpResult for these results instead of exceptions
                    result.Exception = new NotModifiedException();
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return Task.CompletedTask;
        }
    }
}

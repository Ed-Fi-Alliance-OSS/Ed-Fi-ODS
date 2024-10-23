// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Pipelines;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Steps
{
    public class DetectUnmodifiedEntityModel<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
        where TContext : IHasPersistentModel<TEntityModel>, IHasETag
        where TResult : PipelineResultBase
        where TEntityModel : class, IMappable
    {
        private readonly IETagProvider _etagProvider;

        public DetectUnmodifiedEntityModel(IETagProvider etagProvider)
        {
            _etagProvider = etagProvider;
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            try
            {
                // Don't process model if ETag isn't present
                if (context.ETag == null)
                {
                    return Task.CompletedTask;
                }

                // Check the ETag for no modifications
                if (context.ETag == _etagProvider.GetETag(context.PersistentModel))
                {
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

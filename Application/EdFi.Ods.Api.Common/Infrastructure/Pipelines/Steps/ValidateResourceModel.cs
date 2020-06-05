// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps
{
    public class ValidateResourceModel<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
        where TContext : IHasResource<TResourceModel>
        where TResourceModel : IHasETag
        where TEntityModel : class
        where TResult : PipelineResultBase
    {
        private readonly IEnumerable<IResourceValidator> _validators;

        public ValidateResourceModel(IEnumerable<IResourceValidator> validators)
        {
            _validators = validators;
        }

        public void Execute(TContext context, TResult result)
        {
            // NOTE this talk will always run synchronously, therefore we are not moving it to the async method
            var validationResults = _validators.ValidateObject(context.Resource);

            if (!validationResults.IsValid())
            {
                result.Exception = new ValidationException(
                    $"Validation of '{((Object) context.Resource).GetType().Name}' failed.\n{string.Join("\n", validationResults.GetAllMessages(indentLevel: 1))}");
            }
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            Execute(context, result);
            return Task.CompletedTask;
        }
    }
}

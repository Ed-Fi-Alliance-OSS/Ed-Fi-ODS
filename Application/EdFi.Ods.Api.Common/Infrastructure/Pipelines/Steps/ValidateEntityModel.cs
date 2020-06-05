// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps
{
    public class ValidateEntityModel<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
        where TContext : IHasPersistentModel<TEntityModel>
        where TResourceModel : IHasETag
        where TEntityModel : class
        where TResult : PipelineResultBase
    {
        private readonly IEnumerable<IEntityValidator> _validators;

        public ValidateEntityModel(IEnumerable<IEntityValidator> validators)
        {
            _validators = validators;
        }

        public void Execute(TContext context, TResult result)
        {
            // NOTE this step will always run synchronously therefore we are not moving it to the async method
            var validationResults = _validators.ValidateObject(context.PersistentModel);

            if (!validationResults.IsValid())
            {
                result.Exception = new ValidationException(
                    $"Validation of '{context.PersistentModel.GetType().Name}' failed.\n{string.Join("\n", validationResults.GetAllMessages(indentLevel: 1))}");
            }
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            Execute(context, result);
            return Task.CompletedTask;
        }
    }
}

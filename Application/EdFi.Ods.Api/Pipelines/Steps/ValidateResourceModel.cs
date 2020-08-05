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
using EdFi.Ods.Pipelines;
using EdFi.Ods.Pipelines.Common;

namespace EdFi.Ods.Api.Pipelines.Steps
{
    public class ValidateResourceModel<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
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

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            var validationResults = _validators.ValidateObject(context.Resource);

            if (!validationResults.IsValid())
            {
                result.Exception = new ValidationException(
                    $"Validation of '{context.Resource.GetType().Name}' failed.\n{string.Join("\n", validationResults.GetAllMessages(indentLevel: 1))}");
            }

            return Task.CompletedTask;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Pipelines.Common;

namespace EdFi.Ods.Pipelines
{
    public interface IPipeline
    {
        object Process(object context);

        Task<object> ProcessAsync(object context, CancellationToken cancellationToken);
    }

    public abstract class PipelineBase<TContext, TResult> : IPipeline
        where TResult : PipelineResultBase, new()
    {
        protected IStep<TContext, TResult>[] _steps;
        private readonly IExceptionTranslationProvider _exceptionTranslationProvider;

        protected PipelineBase(IStep<TContext, TResult>[] steps, IExceptionTranslationProvider exceptionTranslationProvider)
        {
            _steps = steps;
            _exceptionTranslationProvider = exceptionTranslationProvider;
        }

        public object Process(object context) => ProcessAsync((TContext) context, CancellationToken.None).GetResultSafely();

        async Task<object> IPipeline.ProcessAsync(object context, CancellationToken cancellationToken)
        {
            return await ProcessAsync((TContext) context, cancellationToken);
        }

        public async Task<TResult> ProcessAsync(TContext context, CancellationToken cancellationToken)
        {
            var result = new TResult();

            foreach (var step in _steps)
            {
                await step.ExecuteAsync(context, result, cancellationToken);

                // If we have experienced an exception, quit processing steps now
                if (result.Exception != null)
                {
                    var translationResult = _exceptionTranslationProvider.TranslateException(result.Exception);
                    result.ExceptionTranslation = translationResult;
                    
                    break;
                }
            }

            return result;
        }
    }
}

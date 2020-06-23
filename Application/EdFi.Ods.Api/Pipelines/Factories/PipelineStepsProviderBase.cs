// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Pipelines.Common;

namespace EdFi.Ods.Api.Pipelines.Factories
{
    public abstract class PipelineStepsProviderBase
    {
        private readonly IServiceLocator _serviceLocator;

        protected PipelineStepsProviderBase(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
        
        protected IEnumerable<Type> GetGenericTypes<TContext, TResult, TResourceModel, TEntityModel>(IEnumerable<string> genericArgNames)
        {
            foreach (var genericArgName in genericArgNames)
            {
                switch (genericArgName)
                {
                    case "TContext":
                        yield return typeof(TContext);

                        break;

                    case "TResult":
                        yield return typeof(TResult);

                        break;

                    case "TResourceModel":
                        yield return typeof(TResourceModel);

                        break;

                    case "TEntityModel":
                        yield return typeof(TEntityModel);

                        break;

                    default:

                        // Defensive programming
                        throw new Exception($"Unsupported generic type argument name '{genericArgName}'.");
                }
            }
        }

        protected IStep<TContext, TResult>[] ResolvePipelineSteps<TContext, TResult, TResourceModel, TEntityModel>(IEnumerable<Type> stepTypes)
        {
            var pipelineStepTypes = new List<IStep<TContext, TResult>>();

            foreach (var pipelineStepType in stepTypes)
            {
                Type resolutionType;

                if (pipelineStepType.IsGenericTypeDefinition)
                {
                    var typeArgsNames = pipelineStepType.GetGenericArguments()
                        .Select(x => x.Name);

                    var typeArgs = GetGenericTypes<TContext, TResult, TResourceModel, TEntityModel>(typeArgsNames);

                    resolutionType = pipelineStepType.MakeGenericType(typeArgs.ToArray());
                }
                else
                {
                    resolutionType = pipelineStepType;
                }

                pipelineStepTypes.Add((IStep<TContext, TResult>) _serviceLocator.Resolve(resolutionType));
            }

            return pipelineStepTypes.ToArray();
        }
    }
}

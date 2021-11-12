// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.InversionOfControl;
using EdFi.Ods.Api.Infrastructure.Pipelines.Get;
using EdFi.Ods.Api.Infrastructure.Pipelines.GetMany;
using EdFi.Ods.Api.Infrastructure.Pipelines.Put;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Infrastructure.Pipelines.Delete;
using EdFi.Ods.Common.Infrastructure.Pipelines.GetMany;
using NHibernate;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Factories
{
    public class PipelineFactory : IPipelineFactory
    {
        private readonly IServiceLocator _locator;
        private readonly IDeletePipelineStepsProvider _deletePipelineStepsProvider;
        private readonly IGetBySpecificationPipelineStepsProvider _getBySpecificationPipelineStepsProvider;
        private readonly IGetPipelineStepsProvider _getPipelineStepsProvider;
        private readonly IPutPipelineStepsProvider _putPipelineStepsProvider;
        private readonly ISessionFactory _sessionFactory;

        public PipelineFactory(
            IServiceLocator locator,
            IGetPipelineStepsProvider getPipelineStepsProvider,
            IGetBySpecificationPipelineStepsProvider getBySpecificationPipelineStepsProvider,
            IPutPipelineStepsProvider putPipelineStepsProvider,
            IDeletePipelineStepsProvider deletePipelineStepsProvider,
            ISessionFactory sessionFactory)
        {
            _locator = locator;
            _getPipelineStepsProvider = getPipelineStepsProvider;
            _getBySpecificationPipelineStepsProvider = getBySpecificationPipelineStepsProvider;
            _putPipelineStepsProvider = putPipelineStepsProvider;
            _deletePipelineStepsProvider = deletePipelineStepsProvider;
            _sessionFactory = sessionFactory;
        }

        public GetPipeline<TResourceModel, TEntityModel> CreateGetPipeline<TResourceModel, TEntityModel>()
            where TResourceModel : IHasETag
            where TEntityModel : class
        {
            var stepTypes = _getPipelineStepsProvider.GetSteps();

            var steps =
                ResolvePipelineSteps<GetContext<TEntityModel>, GetResult<TResourceModel>, TResourceModel, TEntityModel>(
                    stepTypes);

            return new GetPipeline<TResourceModel, TEntityModel>(steps, _sessionFactory);
        }

        public GetManyPipeline<TResourceModel, TEntityModel> CreateGetManyPipeline<TResourceModel, TEntityModel>()
            where TResourceModel : IHasETag
            where TEntityModel : class
        {
            var stepTypes = _getBySpecificationPipelineStepsProvider.GetSteps();

            var steps =
                ResolvePipelineSteps<GetManyContext<TResourceModel, TEntityModel>, GetManyResult<TResourceModel>, TResourceModel,
                    TEntityModel>(
                    stepTypes);

            return new GetManyPipeline<TResourceModel, TEntityModel>(steps, _sessionFactory);
        }

        public PutPipeline<TResourceModel, TEntityModel> CreatePutPipeline<TResourceModel, TEntityModel>()
            where TEntityModel : class, IHasIdentifier, new()
            where TResourceModel : IHasETag
        {
            var stepTypes = _putPipelineStepsProvider.GetSteps();

            var steps =
                ResolvePipelineSteps<PutContext<TResourceModel, TEntityModel>, PutResult, TResourceModel, TEntityModel>(
                    stepTypes);

            return new PutPipeline<TResourceModel, TEntityModel>(steps);
        }

        public DeletePipeline CreateDeletePipeline<TResourceModel, TEntityModel>()
        {
            var stepTypes = _deletePipelineStepsProvider.GetSteps();
            var steps = ResolvePipelineSteps<DeleteContext, DeleteResult, TResourceModel, TEntityModel>(stepTypes);
            return new DeletePipeline(steps);
        }

        private IStep<TContext, TResult>[] ResolvePipelineSteps<TContext, TResult, TResourceModel, TEntityModel>(
            IEnumerable<Type> stepTypes)
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

                pipelineStepTypes.Add((IStep<TContext, TResult>) _locator.Resolve(resolutionType));
            }

            return pipelineStepTypes.ToArray();
        }

        private IEnumerable<Type> GetGenericTypes<TContext, TResult, TResourceModel, TEntityModel>(
            IEnumerable<string> genericArgNames)
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
                        throw new Exception(string.Format("Unsupported generic type argument name '{0}'.", genericArgName));
                }
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Steps
{
    public class MapResourceModelToEntityModel<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
        where TContext : IHasPersistentModel<TEntityModel>, IHasResource<TResourceModel>
        where TResult : PipelineResultBase
        where TResourceModel : class, IMappable, IHasETag
        where TEntityModel : class, new()
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MapResourceModelToEntityModel<TContext, TResult, TResourceModel, TEntityModel>));
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

        public MapResourceModelToEntityModel(IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
        {
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            // NOTE this step will always run synchronously so we are not moving the logic to the async method.
            try
            {
                if (context.Resource == default(TResourceModel))
                {
                    return Task.CompletedTask;
                }

                if (_dataManagementResourceContextProvider.Get()?.HttpMethod == HttpMethods.Post
                    && context.Resource.GetType().FullName?.Contains(".StudentAssessments.") == true)
                {
                    string bodyBeforeMapping = JsonConvert.SerializeObject(context.Resource);
                    _logger.Warn($"Resource before mapping='{bodyBeforeMapping}'");
                }

                var entity = new TEntityModel();
                context.Resource.Map(entity);
                context.PersistentModel = entity;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return Task.CompletedTask;
        }
    }
}

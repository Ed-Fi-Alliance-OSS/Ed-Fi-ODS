﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Infrastructure.Pipelines.GetMany;
using NHibernate;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.GetMany
{
    public class GetManyPipeline<TResourceModel, TEntityModel>
        : PipelineBase<GetManyContext<TResourceModel, TEntityModel>, GetManyResult<TResourceModel>>
        where TResourceModel : IHasETag
        where TEntityModel : class
    {
        public GetManyPipeline(
            IStep<GetManyContext<TResourceModel, TEntityModel>, GetManyResult<TResourceModel>>[] steps,
            ISessionFactory sessionFactory)
            : base(steps, sessionFactory) { }
    }
}

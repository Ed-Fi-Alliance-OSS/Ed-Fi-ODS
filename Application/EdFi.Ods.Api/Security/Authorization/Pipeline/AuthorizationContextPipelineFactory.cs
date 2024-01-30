﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Pipelines;

namespace EdFi.Ods.Api.Security.Authorization.Pipeline
{
    public class AuthorizationContextGetPipelineStepsProviderDecorator : IGetPipelineStepsProvider
    {
        private readonly IGetPipelineStepsProvider _next;

        public AuthorizationContextGetPipelineStepsProviderDecorator(IGetPipelineStepsProvider next)
        {
            _next = next;
        }

        public Type[] GetSteps()
        {
            return _next.GetSteps()
                        .InsertAtHead(typeof(SetAuthorizationContextForGet<,,,>))
                        .ToArray();
        }
    }

    public class AuthorizationContextGetBySpecificationPipelineStepsProviderDecorator : IGetBySpecificationPipelineStepsProvider
    {
        private readonly IGetBySpecificationPipelineStepsProvider _next;

        public AuthorizationContextGetBySpecificationPipelineStepsProviderDecorator(IGetBySpecificationPipelineStepsProvider next)
        {
            _next = next;
        }

        public Type[] GetSteps()
        {
            return _next.GetSteps()
                        .InsertAtHead(typeof(SetAuthorizationContextForGet<,,,>))
                        .ToArray();
        }
    }

    public class AuthorizationContextUpsertPipelineStepsProviderDecorator : IUpsertPipelineStepsProvider
    {
        private readonly IUpsertPipelineStepsProvider _next;

        public AuthorizationContextUpsertPipelineStepsProviderDecorator(IUpsertPipelineStepsProvider next)
        {
            _next = next;
        }

        public Type[] GetSteps()
        {
            return _next.GetSteps()
                        .InsertAtHead(typeof(SetAuthorizationContextForPut<,,,>))
                        .ToArray();
        }
    }

    public class AuthorizationContextDeletePipelineStepsProviderDecorator : IDeletePipelineStepsProvider
    {
        private readonly IDeletePipelineStepsProvider _next;

        public AuthorizationContextDeletePipelineStepsProviderDecorator(IDeletePipelineStepsProvider next)
        {
            _next = next;
        }

        public Type[] GetSteps()
        {
            return _next.GetSteps()
                        .InsertAtHead(typeof(SetAuthorizationContextForDelete<,,,>))
                        .ToArray();
        }
    }
}

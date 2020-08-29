// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Api.Pipelines.Factories;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Security.Authorization.Pipeline
{
    public class AuthorizationContextGetPipelineStepTypesProviderDecorator : IGetPipelineStepTypesProvider
    {
        private readonly IGetPipelineStepTypesProvider _next;

        public AuthorizationContextGetPipelineStepTypesProviderDecorator(IGetPipelineStepTypesProvider next)
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

    public class AuthorizationContextGetBySpecificationPipelineStepTypesProviderDecorator : IGetBySpecificationPipelineStepTypesProvider
    {
        private readonly IGetBySpecificationPipelineStepTypesProvider _next;

        public AuthorizationContextGetBySpecificationPipelineStepTypesProviderDecorator(IGetBySpecificationPipelineStepTypesProvider next)
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

    public class AuthorizationContextPutPipelineStepTypesProviderDecorator : IPutPipelineStepTypesProvider
    {
        private readonly IPutPipelineStepTypesProvider _next;

        public AuthorizationContextPutPipelineStepTypesProviderDecorator(IPutPipelineStepTypesProvider next)
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

    public class AuthorizationContextDeletePipelineStepTypesProviderDecorator : IDeletePipelineStepTypesProvider
    {
        private readonly IDeletePipelineStepTypesProvider _next;

        public AuthorizationContextDeletePipelineStepTypesProviderDecorator(IDeletePipelineStepTypesProvider next)
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

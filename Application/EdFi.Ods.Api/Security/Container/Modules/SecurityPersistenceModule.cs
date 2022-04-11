// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Autofac;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Api.Security.Authorization.Pipeline;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Security.DataAccess.Contexts;

namespace EdFi.Ods.Api.Security.Container.Modules
{
    public class SecurityPersistenceModule : Module
    {
        private readonly IDictionary<Type, Type> _genericServiceByAuthorizationDecorator = new Dictionary<Type, Type>
        {
            // NHibernate authorization decorators
            {typeof(IGetEntityByKey<>), typeof(GetEntityByKeyAuthorizationDecorator<>)},
            {typeof(IGetEntitiesBySpecification<>), typeof(GetEntitiesBySpecificationAuthorizationDecorator<>)},
            {typeof(IPagedAggregateIdsCriteriaProvider<>), typeof(PagedAggregateIdsCriteriaProviderAuthorizationDecorator<>)},
            {typeof(ITotalCountCriteriaProvider<>), typeof(TotalCountCriteriaProviderAuthorizationDecorator<>)},
            {typeof(IGetEntityById<>), typeof(GetEntityByIdAuthorizationDecorator<>)},
            {typeof(IGetEntitiesByIds<>), typeof(GetEntitiesByIdsAuthorizationDecorator<>)},
            {typeof(ICreateEntity<>), typeof(CreateEntityAuthorizationDecorator<>)},
            {typeof(IDeleteEntityById<>), typeof(DeleteEntityByIdAuthorizationDecorator<>)},
            {typeof(IUpdateEntity<>), typeof(UpdateEntityAuthorizationDecorator<>)},
            {typeof(IUpsertEntity<>), typeof(UpsertEntityAuthorizationDecorator<>)},
        };

        private readonly IDictionary<Type, Type> _serviceByAuthorizationDecorator = new Dictionary<Type, Type>
        {
            // pipeline steps authorization decorators
            {typeof(IGetPipelineStepsProvider), typeof(AuthorizationContextGetPipelineStepsProviderDecorator)},
            {
                typeof(IGetBySpecificationPipelineStepsProvider),
                typeof(AuthorizationContextGetBySpecificationPipelineStepsProviderDecorator)
            },
            {typeof(IPutPipelineStepsProvider), typeof(AuthorizationContextPutPipelineStepsProviderDecorator)},
            {typeof(IDeletePipelineStepsProvider), typeof(AuthorizationContextDeletePipelineStepsProviderDecorator)}
        };

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var decoratorRegistration in _genericServiceByAuthorizationDecorator)
            {
                builder.RegisterGenericDecorator(decoratorRegistration.Value, decoratorRegistration.Key);
            }

            foreach (var decoratorRegistration in _serviceByAuthorizationDecorator)
            {
                builder.RegisterDecorator(decoratorRegistration.Value, decoratorRegistration.Key);
            }

            builder.RegisterType<ClientAppRepo>()
                .As<IClientAppRepo>()
                .SingleInstance();

            builder.RegisterType<AccessTokenClientRepo>()
                .As<IAccessTokenClientRepo>()
                .SingleInstance();

            builder.RegisterType<UsersContextFactory>()
                .As<IUsersContextFactory>()
                .SingleInstance();

            builder.RegisterType<SecurityContextFactory>()
                .As<ISecurityContextFactory>()
                .SingleInstance();
        }
    }
}

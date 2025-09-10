// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Autofac;
using EdFi.Admin.DataAccess.Authentication;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Api.Security.Authorization.Pipeline;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.StartupCommands;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Models.Domain.DomainModelEnhancers;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Security.DataAccess.Contexts;

namespace EdFi.Ods.Api.Security.Container.Modules
{
    public class SecurityPersistenceModule : Module
    {
        private readonly IDictionary<Type, Type> _genericServiceByAuthorizationDecorator = new Dictionary<Type, Type>
        {
            // NHibernate authorization decorators
            {typeof(GetEntityByKeyAuthorizationDecorator<>), typeof(IGetEntityByKey<>)},
            {typeof(GetEntitiesBySpecificationAuthorizationDecorator<>), typeof(IGetEntitiesBySpecification<>)},
            {typeof(GetEntityByIdAuthorizationDecorator<>), typeof(IGetEntityById<>)},
            {typeof(GetEntitiesByIdsAuthorizationDecorator<>), typeof(IGetEntitiesByIds<>)},
            {typeof(GetEntitiesByAggregateIdsAuthorizationDecorator<>), typeof(IGetEntitiesByAggregateIds<>)},
            {typeof(CreateEntityAuthorizationDecorator<>), typeof(ICreateEntity<>)},
            {typeof(DeleteEntityByIdAuthorizationDecorator<>), typeof(IDeleteEntityById<>)},
            {typeof(UpdateEntityAuthorizationDecorator<>), typeof(IUpdateEntity<>)},
            {typeof(UpsertEntityAuthorizationDecorator<>), typeof(IUpsertEntity<>)},
        };

        private readonly IDictionary<Type, Type> _serviceByAuthorizationDecorator = new Dictionary<Type, Type>
        {
            // pipeline steps authorization decorators
            {typeof(AuthorizationContextGetPipelineStepsProviderDecorator), typeof(IGetPipelineStepsProvider)},
            {
                typeof(AuthorizationContextGetBySpecificationPipelineStepsProviderDecorator),
                typeof(IGetBySpecificationPipelineStepsProvider)
            },
            {typeof(AuthorizationContextUpsertPipelineStepsProviderDecorator), typeof(IUpsertPipelineStepsProvider)},
            {typeof(AuthorizationContextDeletePipelineStepsProviderDecorator), typeof(IDeletePipelineStepsProvider)},
            
            {typeof(AggregateRootQueryBuilderProviderAuthorizationDecorator), typeof(IAggregateRootQueryBuilderProvider)},
        };

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var decoratorRegistration in _genericServiceByAuthorizationDecorator)
            {
                builder.RegisterGenericDecorator(decoratorRegistration.Key, decoratorRegistration.Value);
            }

            foreach (var decoratorRegistration in _serviceByAuthorizationDecorator)
            {
                builder.RegisterDecorator(decoratorRegistration.Key, decoratorRegistration.Value);
            }

            builder.RegisterType<ClientAppRepo>()
                .As<IClientAppRepo>()
                .SingleInstance();

            builder.RegisterType<ExpiredAccessTokenDeleter>()
                .As<IExpiredAccessTokenDeleter>()
                .SingleInstance();

            builder.RegisterType<UsersContextFactory>()
                .As<IUsersContextFactory>()
                .SingleInstance();

            builder.RegisterType<SecurityContextFactory>()
                .As<ISecurityContextFactory>()
                .SingleInstance();
            
            // General authorization support (associating mapped entity types with semantic API model entities)
            builder.RegisterType<NHibernateEntityTypeDomainModelEnhancer>()
                .As<IDomainModelEnhancer>()
                .SingleInstance();

            builder.RegisterType<EnhanceDomainModelStartupCommand>()
                .As<IStartupCommand>()
                .SingleInstance();
        }
    }
}

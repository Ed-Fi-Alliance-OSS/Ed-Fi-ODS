// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using System;
using System.Collections.Generic;
using Autofac;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Pipeline;
using EdFi.Ods.Security.Authorization.Repositories;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Security.Container.Modules
{
    public class PersistenceModule : Module
    {
        private readonly IDictionary<Type, Type> _genericServiceByAuthorizationDecorator = new Dictionary<Type, Type>
        {
            // NHibernate authorization decorators
            {typeof(IGetEntityByKey<>), typeof(GetEntityByKeyAuthorizationDecorator<>)},
            {typeof(IGetEntitiesBySpecification<>), typeof(GetEntitiesBySpecificationAuthorizationDecorator<>)},
            {typeof(IPagedAggregateIdsCriteriaProvider<>), typeof(PagedAggregateIdsCriteriaProviderDecorator<>)},
            {typeof(ITotalCountCriteriaProvider<>), typeof(TotalCountCriteriaProviderDecorator<>)},
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

            builder.RegisterType<EducationOrganizationCache>()
                .WithParameter(new NamedParameter("synchronousInitialization", false))
                .As<IEducationOrganizationCache>()
                .AsSelf();

            builder.RegisterType<EducationOrganizationCacheDataProvider>()
                .As<IEducationOrganizationCacheDataProvider>()
                .As<IEducationOrganizationIdentifiersValueMapper>()
                .AsSelf();

            builder.RegisterType<SecurityRepository>().As<ISecurityRepository>();
            builder.RegisterType<ClientAppRepo>().As<IClientAppRepo>();
            builder.RegisterType<AccessTokenClientRepo>().As<IAccessTokenClientRepo>();
            builder.RegisterType<UsersContextFactory>().As<IUsersContextFactory>();
            builder.RegisterType<SecurityContextFactory>().As<ISecurityContextFactory>();
        }
    }
}
#endif
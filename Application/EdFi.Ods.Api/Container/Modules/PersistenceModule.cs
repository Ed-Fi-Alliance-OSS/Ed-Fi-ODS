// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using Autofac;
using Autofac.Core;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Database;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.Ods.Common.Repositories;
using EdFi.Security.DataAccess.Providers;
using Microsoft.Extensions.Caching.Memory;

namespace EdFi.Ods.Api.Container.Modules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdminDatabaseConnectionStringProvider>().As<IAdminDatabaseConnectionStringProvider>()
                .SingleInstance();

            builder.Register(c => new MemoryCache(new MemoryCacheOptions())).As<IMemoryCache>();

            builder.RegisterType<MemoryCacheProvider>().AsSelf().As<ICacheProvider>();
            builder.RegisterType<ConcurrentDictionaryCacheProvider>().AsSelf().SingleInstance();

            builder.RegisterType<DescriptorsCache>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(IDescriptorsCache),
                        (p, c) => c.Resolve<ConcurrentDictionaryCacheProvider>()))
                .As<IDescriptorsCache>()
                .SingleInstance();

            builder.Register(c => c.Resolve<ApiSettings>().GetDatabaseEngine())
                .SingleInstance();

            builder.RegisterType<DbConnectionStringBuilderAdapterFactory>()
                .As<IDbConnectionStringBuilderAdapterFactory>()
                .SingleInstance();

            builder.RegisterType<PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider>()
                .WithParameter(new NamedParameter("prototypeConnectionStringName", "EdFi_Ods"))
                .As<IOdsDatabaseConnectionStringProvider>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(PagedAggregateIdsCriteriaProvider<>))
                .As(typeof(IPagedAggregateIdsCriteriaProvider<>));

            builder.RegisterGeneric(typeof(TotalCountCriteriaProvider<>))
                .As(typeof(ITotalCountCriteriaProvider<>));

            // This is a cache, and it needs to be a singleton
            builder.RegisterType<FilterCriteriaApplicatorProvider>()
                .As<IFilterCriteriaApplicatorProvider>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(NHibernateRepository<>))
                .As(typeof(IRepository<>));

            builder.RegisterGeneric(typeof(CreateEntity<>))
                .As(typeof(ICreateEntity<>));

            builder.RegisterGeneric(typeof(DeleteEntityById<>))
                .As(typeof(IDeleteEntityById<>));

            builder.RegisterGeneric(typeof(DeleteEntityByKey<>))
                .As(typeof(IDeleteEntityByKey<>));

            builder.RegisterGeneric(typeof(GetEntitiesByIds<>))
                .As(typeof(IGetEntitiesByIds<>));

            builder.RegisterGeneric(typeof(GetEntitiesBySpecification<>))
                .As(typeof(IGetEntitiesBySpecification<>));

            builder.RegisterGeneric(typeof(GetEntityById<>))
                .As(typeof(IGetEntityById<>));

            builder.RegisterGeneric(typeof(GetEntityByKey<>))
                .As(typeof(IGetEntityByKey<>));

            builder.RegisterGeneric(typeof(UpdateEntity<>))
                .As(typeof(IUpdateEntity<>));

            builder.RegisterGeneric(typeof(UpsertEntity<>))
                .As(typeof(IUpsertEntity<>));

            builder.RegisterType<SecurityDatabaseConnectionStringProvider>()
                .As<ISecurityDatabaseConnectionStringProvider>();

            builder.RegisterType<UniqueIdToUsiValueMapper>().As<IUniqueIdToUsiValueMapper>().PreserveExistingDefaults()
                .SingleInstance();

            builder.RegisterType<PersonUniqueIdToUsiCache>()
                .WithParameter(new NamedParameter("synchronousInitialization", false))
                .WithParameter(new NamedParameter("slidingExpiration", TimeSpan.FromSeconds(14400)))
                .WithParameter(new NamedParameter("absoluteExpirationPeriod", TimeSpan.FromSeconds(86400)))
                .As<IPersonUniqueIdToUsiCache>().SingleInstance();
        }
    }
}
#endif
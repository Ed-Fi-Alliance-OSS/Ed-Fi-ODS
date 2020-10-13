// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.Ods.Common.Repositories;
using EdFi.Security.DataAccess.Providers;
using Microsoft.Extensions.Caching.Memory;
using NHibernate;

namespace EdFi.Ods.Api.Container.Modules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdminDatabaseConnectionStringProvider>()
                .As<IAdminDatabaseConnectionStringProvider>()
                .SingleInstance();

            builder.Register(c => new MemoryCache(new MemoryCacheOptions()))
                .As<IMemoryCache>();

            builder.RegisterType<MemoryCacheProvider>()
                .As<ICacheProvider>();

            builder.RegisterType<ConcurrentDictionaryCacheProvider>()
                .AsSelf()
                .SingleInstance();

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

            builder.RegisterType<OrmMappingFileDataProvider>()
                .WithParameter(new NamedParameter("assemblyName", OrmMappingFileConventions.OrmMappingAssembly))
                .As<IOrmMappingFileDataProvider>()
                .SingleInstance();

            builder.RegisterType<NHibernateConfigurator>()
                .As<INHibernateConfigurator>()
                .SingleInstance();

            builder.Register(
                    c => c.Resolve<INHibernateConfigurator>()
                        .Configure())
                .As<NHibernate.Cfg.Configuration>()
                .AsSelf()
                .SingleInstance();

            builder.Register(
                    c => c.Resolve<NHibernate.Cfg.Configuration>()
                        .BuildSessionFactory())
                .As<ISessionFactory>()
                .SingleInstance();

            // ----------------------------------------------------------------------------------------------------
            // NOTE: Sometimes ISessionFactory cannot be injected, so we're injecting a Func<IStatelessSession> rather
            // than the ISessionFactory or IStatelessSession (the latter of which can result in a memory leak).
            // Read on for more details.
            //
            // If the container manages the creation of the IStatelessSession (or ISession) as a transient instance,
            // it will track the session instance until it is explicitly released by calling the container's Release
            // method. This is because these interfaces also implement IDisposable. Usually Release is invoked
            // automatically by the using a lifecycle other than transient (e.g. per web request), but in our case this
            // is not always possible as the code needing to open a session is sometimes running outside of the context
            // of the current ASP.NET web request (e.g. background cache initialization) and because of a runtime
            // cyclical dependency exception, an ISessionFactory cannot be resolved and injected.
            //
            // By using a singleton factory method of type Func<IStatelessSession>, we can keep the management of the
            // session instance out of the container's hands, avoid the cyclical dependency exception, and we only need
            // to dispose of the session when we're done.
            // ----------------------------------------------------------------------------------------------------

            // The function is a singleton, not the session
            // Autofac needs to first resolve the context into a variable before it can assign the function.
            builder.Register<Func<IStatelessSession>>(
                    c =>
                    {
                        var ctx = c.Resolve<IComponentContext>();

                        return () => ctx.Resolve<ISessionFactory>()
                            .OpenStatelessSession();
                    })
                .SingleInstance();

            builder.Register<Func<ISession>>(
                    c =>
                    {
                        var ctx = c.Resolve<IComponentContext>();

                        return () => ctx.Resolve<ISessionFactory>()
                            .OpenSession();
                    })
                .SingleInstance();
        }
    }
}

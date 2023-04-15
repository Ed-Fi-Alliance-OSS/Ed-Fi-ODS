// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Database;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.Ods.Common.Repositories;
using EdFi.Security.DataAccess.Providers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using NHibernate;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace EdFi.Ods.Api.Container.Modules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdminDatabaseConnectionStringProvider>()
                .As<IAdminDatabaseConnectionStringProvider>()
                .PreserveExistingDefaults()
                .SingleInstance();

            builder.RegisterType<SecurityDatabaseConnectionStringProvider>()
                .As<ISecurityDatabaseConnectionStringProvider>()
                .PreserveExistingDefaults()
                .SingleInstance();

            builder.Register(c => new MemoryCache(new MemoryCacheOptions()))
                .As<IMemoryCache>()
                .SingleInstance();

            builder.RegisterType<MemoryCacheProvider>()
                .As<ICacheProvider<string>>()
                .SingleInstance();

            builder.RegisterType<ConcurrentDictionaryCacheProvider<string>>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<DescriptorResolver>()
                .As<IDescriptorResolver>()
                .SingleInstance();

            builder.RegisterType<DescriptorMapsProvider>()
                .As<IDescriptorMapsProvider>()
                .EnableInterfaceInterceptors()
                .SingleInstance();

            builder.RegisterType<ContextualCachingInterceptor<OdsInstanceConfiguration>>()
                .Named<IInterceptor>("cache-descriptors")
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();
            
                        return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "Descriptors",
                            TimeSpan.FromSeconds(apiSettings.Caching.Descriptors.AbsoluteExpirationSeconds));
                    });

            builder.RegisterType<DescriptorDetailsProvider>()
                .As<IDescriptorDetailsProvider>()
                .SingleInstance();
            
            builder.Register(c => c.Resolve<ApiSettings>().GetDatabaseEngine())
                .SingleInstance();

            builder.RegisterType<DbConnectionStringBuilderAdapterFactory>()
                .As<IDbConnectionStringBuilderAdapterFactory>()
                .SingleInstance();

            builder.RegisterType<OdsDatabaseConnectionStringProvider>()
                .As<IOdsDatabaseConnectionStringProvider>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(PagedAggregateIdsCriteriaProvider<>))
                .As(typeof(IPagedAggregateIdsCriteriaProvider<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(TotalCountCriteriaProvider<>))
                .As(typeof(ITotalCountCriteriaProvider<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(CreateEntity<>))
                .As(typeof(ICreateEntity<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(DeleteEntityById<>))
                .As(typeof(IDeleteEntityById<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(DeleteEntityByKey<>))
                .As(typeof(IDeleteEntityByKey<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(GetEntitiesByIds<>))
                .As(typeof(IGetEntitiesByIds<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(GetEntitiesBySpecification<>))
                .As(typeof(IGetEntitiesBySpecification<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(GetEntityById<>))
                .As(typeof(IGetEntityById<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(GetEntityByKey<>))
                .As(typeof(IGetEntityByKey<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(UpdateEntity<>))
                .As(typeof(IUpdateEntity<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(UpsertEntity<>))
                .As(typeof(IUpsertEntity<>))
                .SingleInstance();

            builder.RegisterType<UniqueIdToUsiValueMapper>()
                .As<IUniqueIdToUsiValueMapper>()
                .PreserveExistingDefaults()
                .SingleInstance();

            builder.RegisterType<PersonUniqueIdToUsiCache>()
                .WithParameter(new NamedParameter("synchronousInitialization", false))
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.Equals("slidingExpiration", StringComparison.InvariantCultureIgnoreCase),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            int period = apiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;

                            return TimeSpan.FromSeconds(period);
                        }))
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.Equals("absoluteExpirationPeriod", StringComparison.InvariantCultureIgnoreCase),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            int period = apiSettings.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds;

                            return TimeSpan.FromSeconds(period);
                        }))
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.Equals("suppressStudentCache", StringComparison.InvariantCultureIgnoreCase),
                        (p, c) =>
                        {
                            var configuration = c.Resolve<IConfiguration>();

                            return configuration.GetValue<bool?>("ApiSettings:Caching:PersonUniqueIdToUsi:SuppressStudentCache") ?? false;
                        }))
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.Equals("suppressStaffCache", StringComparison.InvariantCultureIgnoreCase),
                        (p, c) =>
                        {
                            var configuration = c.Resolve<IConfiguration>();

                            return configuration.GetValue<bool?>("ApiSettings:Caching:PersonUniqueIdToUsi:SuppressStaffCache") ?? false;
                        }))
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.Equals("suppressParentCache", StringComparison.InvariantCultureIgnoreCase),
                        (p, c) =>
                        {
                            var configuration = c.Resolve<IConfiguration>();

                            return configuration.GetValue<bool?>("ApiSettings:Caching:PersonUniqueIdToUsi:SuppressParentCache") ?? false;
                        }))
                .As<IPersonUniqueIdToUsiCache>()
                .SingleInstance();

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

            // Autofac needs to first resolve the context into a variable before it can assign the function.
            // When resolving this function we need to use Owned<Func<T>> since they are scoped.
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

            builder.RegisterType<DatabaseConnectionNHibernateConfigurationActivity>()
                .As<INHibernateConfigurationActivity>()
                .SingleInstance();

            builder.RegisterType<NHibernateOdsConnectionProvider>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}

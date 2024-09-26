// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Autofac.Features.AttributeFilters;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Database;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.Person;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Providers.Queries.Criteria;
using EdFi.Ods.Common.Providers.Queries.Paging;
using EdFi.Ods.Common.Repositories;
using EdFi.Security.DataAccess.Providers;
using Microsoft.Extensions.Caching.Memory;
using NHibernate;
using IInterceptor = Castle.DynamicProxy.IInterceptor;
using Module = Autofac.Module;

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
                .AsSelf()
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
                .Named<IInterceptor>(InterceptorCacheKeys.Descriptors)
                .WithParameter(
                    ctx =>
                    {
                        var apiSettings = ctx.Resolve<ApiSettings>();
            
                        return (ICacheProvider<ulong>) new ExpiringConcurrentDictionaryCacheProvider<ulong>(
                            "Descriptors",
                            TimeSpan.FromSeconds(apiSettings.Caching.Descriptors.AbsoluteExpirationSeconds));
                    })
                .SingleInstance();

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

            builder.RegisterType<OdsDatabaseAccessIntentProvider>()
                .As<IOdsDatabaseAccessIntentProvider>()
                .SingleInstance();

            // Paged query builder
            builder.RegisterType<PagedAggregateIdsQueryBuilderProvider>()
                .Keyed<IAggregateRootQueryBuilderProvider>(PagedAggregateIdsQueryBuilderProvider.RegistrationKey)
                .SingleInstance();

            // Limit/offset paging support
            builder.RegisterType<LimitOffsetPagingStrategy>()
                .Keyed<IPagingStrategy>(PagingStrategy.LimitOffset)
                .SingleInstance();

            // Key set paging support
            builder.RegisterType<KeySetPagingStrategy>()
                .Keyed<IPagingStrategy>(PagingStrategy.KeySet)
                .SingleInstance();

            // Additional criteria applicators
            builder.RegisterAssemblyTypes(typeof(IAggregateRootQueryCriteriaApplicator).Assembly)
                .Where(t => t.IsImplementationOf<IAggregateRootQueryCriteriaApplicator>())
                .As<IAggregateRootQueryCriteriaApplicator>();

            // Repository operations
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
                .WithAttributeFiltering()
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

            // Register decorators on Person types to delete associated map cache entries
            builder.RegisterGenericDecorator(
                typeof(PersonMapCacheDeleteEntityByIdDecorator<>),
                typeof(IDeleteEntityById<>),
                ctx => ctx.ImplementationType.GetGenericArguments()[0].IsImplementationOf<IIdentifiablePerson>());

            RegisterPersonIdentifierCaching(builder);

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

        private static void RegisterPersonIdentifierCaching(ContainerBuilder builder)
        {
            builder
                .RegisterType<InMemoryMapCache<(ulong odsInstanceHashId, string personType, PersonMapType personMapType), string, int>>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.Equals("slidingExpirationPeriod", StringComparison.InvariantCultureIgnoreCase),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            int slidingExpirationSeconds = apiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;

                            return TimeSpan.FromSeconds(slidingExpirationSeconds);
                        }))
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.Equals("absoluteExpirationPeriod", StringComparison.InvariantCultureIgnoreCase),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            int slidingExpirationSeconds = apiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;
                            int absoluteExpirationSeconds = apiSettings.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds;

                            return slidingExpirationSeconds <= 0 ? TimeSpan.FromSeconds(absoluteExpirationSeconds) : TimeSpan.Zero;
                        }))
                .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int>>()
                .SingleInstance();

            builder.RegisterType<InMemoryMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string>>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.Equals("slidingExpirationPeriod", StringComparison.InvariantCultureIgnoreCase),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            int slidingExpirationSeconds = apiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;

                            return TimeSpan.FromSeconds(slidingExpirationSeconds);
                        }))
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.Equals("absoluteExpirationPeriod", StringComparison.InvariantCultureIgnoreCase),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            int slidingExpirationSeconds = apiSettings.Caching.PersonUniqueIdToUsi.SlidingExpirationSeconds;
                            int absoluteExpirationSeconds = apiSettings.Caching.PersonUniqueIdToUsi.AbsoluteExpirationSeconds;

                            return slidingExpirationSeconds <= 0 ? TimeSpan.FromSeconds(absoluteExpirationSeconds) : TimeSpan.Zero;
                        }))
                .As<IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string>>()
                .SingleInstance();

            builder.RegisterType<PersonMapCacheInitializer>().As<IPersonMapCacheInitializer>().SingleInstance();

            builder.RegisterType<UsiCacheInitializationMarkerKeyProvider>()
                .As<ICacheInitializationMarkerKeyProvider<int>>()
                .SingleInstance();

            builder.RegisterType<UniqueIdCacheInitializationMarkerKeyProvider>()
                .As<ICacheInitializationMarkerKeyProvider<string>>()
                .SingleInstance();
            
            builder.RegisterType<PersonUniqueIdResolver>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.EqualsIgnoreCase("cacheSuppressionByPersonType"),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            return apiSettings.Caching.PersonUniqueIdToUsi.CacheSuppression;
                        }))
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.EqualsIgnoreCase("useProgressiveLoading"),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            return apiSettings.Caching.PersonUniqueIdToUsi.UseProgressiveLoading;
                        }))
                .As<IPersonUniqueIdResolver>()
                .SingleInstance();

            builder.RegisterType<PersonUsiResolver>()
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.EqualsIgnoreCase("cacheSuppressionByPersonType"),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            return apiSettings.Caching.PersonUniqueIdToUsi.CacheSuppression;
                        }))
                .WithParameter(
                    new ResolvedParameter(
                        (p, c) => p.Name.EqualsIgnoreCase("useProgressiveLoading"),
                        (p, c) =>
                        {
                            var apiSettings = c.Resolve<ApiSettings>();

                            return apiSettings.Caching.PersonUniqueIdToUsi.UseProgressiveLoading;
                        }))
                .As<IPersonUsiResolver>()
                .SingleInstance();
        }
    }
}

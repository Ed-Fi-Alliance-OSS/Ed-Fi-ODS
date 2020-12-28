// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using Autofac;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Database;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using EdFi.Security.DataAccess.Providers;
using Microsoft.Extensions.Caching.Memory;

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
                .As<ICacheProvider>()
                .SingleInstance();

            builder.RegisterType<ConcurrentDictionaryCacheProvider>()
                .AsSelf()
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

            // TODO: API Simplification - Review this comment for relevance after converting from NHibernate to Dapper 
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

            // TODO: API Simplification - Convert from ISessionFactory to ADO.NET
            // builder.Register<Func<IDbConnection>>(
            //         c =>
            //         {
            //             var ctx = c.Resolve<IComponentContext>();
            //
            //             return () => ctx.Resolve<DbProviderFactory(?)>()
            //                 .OpenSession();
            //         })
            //     .SingleInstance();
        }
    }
}

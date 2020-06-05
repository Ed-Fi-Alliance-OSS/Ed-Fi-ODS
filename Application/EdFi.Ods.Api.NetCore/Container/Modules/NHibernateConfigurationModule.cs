// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Infrastructure.Configuration;
using EdFi.Ods.Api.Common.Providers;
using NHibernate;

namespace EdFi.Ods.Api.NetCore.Container.Modules
{
    public class NHibernateConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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

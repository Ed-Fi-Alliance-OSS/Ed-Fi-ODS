// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Infrastructure.Configuration;
using EdFi.Ods.Api.Common.Infrastructure.ConnectionProviders;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common._Installers.ComponentNaming;
using EdFi.Ods.Common.Configuration;
using NHibernate;
using NHibernate.Cfg;
using Environment = NHibernate.Cfg.Environment;

namespace EdFi.Ods.Api._Installers
{
    public class NHibernateConfiguratorInstaller : IWindsorInstaller
    {
        private readonly IApiConfigurationProvider _apiConfigurationProvider;

        public NHibernateConfiguratorInstaller(IApiConfigurationProvider apiConfigurationProvider)
        {
            _apiConfigurationProvider =  Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IOrmMappingFileDataProvider>()
                    .ImplementedBy<OrmMappingFileDataProvider>()
                    .DependsOn(Dependency.OnValue<string>(OrmMappingFileConventions.OrmMappingAssembly))
                    .LifestyleSingleton(),
                Component.For<INHibernateConfigurator>()
                    .ImplementedBy<NHibernateConfigurator>()
                    .LifestyleSingleton(),
                Component.For<Configuration>()
                         .UsingFactoryMethod(kernel => kernel.Resolve<INHibernateConfigurator>().Configure())
                         .LifestyleSingleton(),
                Component
                   .For<ISessionFactory>()
                   .UsingFactoryMethod(kernel => kernel.Resolve<Configuration>().BuildSessionFactory())
                   .LifestyleSingleton(),
                
                // ----------------------------------------------------------------------------------------------------
                // NOTE: Sometimes ISessionFactory cannot be injected, so we're injecting a Func<IStatelessSession> rather
                // than the ISessionFactory or IStatelessSession (the latter of which can result in a memory leak).
                // Read on for more details.
                //
                // If Windsor manages the creation of the IStatelessSession (or ISession) as a transient instance,
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
                Component
                    .For<Func<IStatelessSession>>()
                    .UsingFactoryMethod<Func<IStatelessSession>>(kernel => () => kernel.Resolve<ISessionFactory>().OpenStatelessSession())
                    .LifestyleSingleton(), // The function is a singleton, not the session
                Component
                   .For<EdFiOdsConnectionProvider>()
                   .DependsOn(
                        Dependency.OnComponent(
                            typeof(IDatabaseConnectionStringProvider),
                            typeof(IDatabaseConnectionStringProvider).GetServiceNameWithSuffix(Databases.Ods.ToString())))
                   .IsFallback()
            );

            // NHibernate Dependency Injection
            Environment.ObjectsFactory = new WindsorObjectsFactory(container);
        }
    }
}

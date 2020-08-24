// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Autofac;
using Castle.Windsor;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Repositories.NHibernate.Tests.Modules;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NUnit.Framework;
using EdFi.Ods.Standard;
using System.Reflection;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    public abstract class BaseDatabaseTest
    {
        protected IContainer container;

        protected ISessionFactory SessionFactory { get; set; }

        [SetUp]
        public void BaseSetUp()
        {
            RegisterDependencies();

            IPersonUniqueIdToUsiCache personUniqueIdToUsiCache = null;

            PersonUniqueIdToUsiCache.GetCache = ()
                    => personUniqueIdToUsiCache ??= container.Resolve<IPersonUniqueIdToUsiCache>();

            SessionFactory = container.Resolve<ISessionFactory>();
        }

        private void RegisterDependencies()
        {
            Assembly.Load("EdFi.Ods.Standard");

            var builder = new ContainerBuilder();

            var config = new ConfigurationBuilder()
                   .SetBasePath(TestContext.CurrentContext.TestDirectory)
                   .AddJsonFile("appsettings.json", optional: true)
                   .Build();
            builder.RegisterInstance(config).As<IConfiguration>();

            var apiSettings = new ApiSettings { Engine = ApiConfigurationConstants.SqlServer, Mode = ApiConfigurationConstants.SharedInstance };
            builder.RegisterInstance(apiSettings).As<ApiSettings>()
                .SingleInstance();

            var apiConFigurationProvider = A.Fake<IApiConfigurationProvider>();
            A.CallTo(() => apiConFigurationProvider.DatabaseEngine).Returns(DatabaseEngine.SqlServer);
            builder.RegisterInstance(apiConFigurationProvider).As<IApiConfigurationProvider>()
                .SingleInstance();

            builder.Register(kernal => kernal.Resolve<IApiConfigurationProvider>().DatabaseEngine).As<DatabaseEngine>();

            builder.RegisterModule(new NHibernateConfigurationModule());
            builder.RegisterModule(new RepositoryFilterProvidersModule());
            builder.RegisterModule(new OdsConnectionStringProviderModule());
            builder.RegisterModule(new EdFiCommonModule());
            builder.RegisterModule(new UsiModule());
            builder.RegisterModule(new CachingModule());
            builder.RegisterModule(new EdFiOdsInstanceIdentificationProviderModule());
            builder.RegisterModule(new PersonIdentifiersModule());
            builder.RegisterModule(new ContextStorageModule());
            builder.RegisterModule(new ContextProviderModule());
            builder.RegisterModule(new DbConnnectionStringBuilderAdapterFactoryModule());
            builder.RegisterModule(new SharedInstanceDatabaseNameReplacementTokenProviderModule(apiSettings));

            ///
            //builder.RegisterType<SharedInstanceDatabaseNameReplacementTokenProvider>()
            //    .As<IDatabaseNameReplacementTokenProvider>()
            //    .SingleInstance();

            //builder.RegisterType<DbConnectionStringBuilderAdapterFactory>()
            //    .As<IDbConnectionStringBuilderAdapterFactory>()
            //    .SingleInstance();

            //builder.RegisterType<ApiKeyContextProvider>()
            //    .As<IApiKeyContextProvider>()
            //    .SingleInstance();

            //builder.RegisterType<HashtableContextStorage>()
            //    .As<IContextStorage>()
            //    .SingleInstance();

            ///


            container = builder.Build();
        }
    }
}
#endif
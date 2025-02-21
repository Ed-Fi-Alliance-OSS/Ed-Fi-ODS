// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Reflection;
using Autofac;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Container.Modules;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Repositories.NHibernate.Tests.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [TestFixture]
    public abstract class BaseDatabaseTest
    {
        protected IContainer Container;

        protected ISessionFactory SessionFactory { get; set; }

        [OneTimeSetUp]
        public void BaseSetUp()
        {
            RegisterDependencies();

            Environment.ObjectsFactory = new NHibernateAutofacObjectsFactory(Container);
            SessionFactory = Container.Resolve<ISessionFactory>();
        }

        private void RegisterDependencies()
        {
            Assembly.Load("EdFi.Ods.Standard");

            var builder = new ContainerBuilder();
            builder.RegisterInstance(OneTimeGlobalDatabaseSetup.Instance.Configuration).As<IConfiguration>();

            var apiSettings = new ApiSettings
            {
                Engine = OneTimeGlobalDatabaseSetup.Instance.DatabaseEngine.Value,
            };
            
            var fakeFeatureManager = new FakeFeatureManager();

            builder.RegisterInstance(apiSettings).As<ApiSettings>().SingleInstance();
            builder.RegisterInstance(fakeFeatureManager).As<IFeatureManager>().SingleInstance();

            builder.Register(c => apiSettings.GetDatabaseEngine()).As<DatabaseEngine>();

            builder.RegisterModule(new NHibernateConfigurationModule());
            builder.RegisterModule(new RepositoryFilterProvidersModule());
            builder.RegisterModule(new OdsConnectionStringProviderModule());
            builder.RegisterModule(new OdsDatabaseAccessIntentProviderModule());
            builder.RegisterModule(new EdFiCommonModule());
            builder.RegisterModule(new CachingModule());
            builder.RegisterModule(new EdFiOdsInstanceIdentificationProviderModule());
            builder.RegisterModule(new PersonIdentifiersModule());
            builder.RegisterModule(new ContextStorageModule());
            builder.RegisterModule(new ContextProviderModule());
            builder.RegisterModule(new DbConnnectionStringBuilderAdapterFactoryModule());
            builder.RegisterModule(new SqlServerSpecificModule(fakeFeatureManager, apiSettings.GetDatabaseEngine()));
            builder.RegisterModule(new PostgresSpecificModule(fakeFeatureManager, apiSettings.GetDatabaseEngine()));

            builder.RegisterType<AuthorizationContextProvider>()
                .As<IAuthorizationContextProvider>()
                .SingleInstance();
            
            Container = builder.Build();

            var contextProvider = Container.Resolve<IContextProvider<OdsInstanceConfiguration>>();

            contextProvider.Set(
                new OdsInstanceConfiguration(
                    1,
                    1,
                    OneTimeGlobalDatabaseSetup.Instance.Configuration.GetSection("ConnectionStrings")["EdFi_Ods"],
                    new Dictionary<string, string>(),
                    new Dictionary<DerivativeType, string>()));
        }
    }
}

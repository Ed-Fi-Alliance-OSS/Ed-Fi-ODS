// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using Autofac;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Container.Modules;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Repositories.NHibernate.Tests.Modules;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;

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

            IPersonUniqueIdToUsiCache personUniqueIdToUsiCache = null;

            PersonUniqueIdToUsiCache.GetCache = ()
                    => personUniqueIdToUsiCache ??= Container.Resolve<IPersonUniqueIdToUsiCache>();

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
                Mode = ApiConfigurationConstants.Sandbox
            };
            builder.RegisterInstance(apiSettings).As<ApiSettings>()
                .SingleInstance();

            builder.Register(c => apiSettings.GetDatabaseEngine()).As<DatabaseEngine>();

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
            builder.RegisterModule(new SqlServerSpecificModule(apiSettings));
            builder.RegisterModule(new PostgresSpecificModule(apiSettings));
            builder.RegisterModule(new SandboxDatabaseReplacementTokenProviderModule(apiSettings));

            Container = builder.Build();
        }
    }
}
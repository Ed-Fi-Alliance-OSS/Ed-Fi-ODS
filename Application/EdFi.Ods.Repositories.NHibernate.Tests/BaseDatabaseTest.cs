// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Data.SqlClient;
using System.Transactions;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api._Installers;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.Infrastructure.Configuration;
using EdFi.Ods.Api.Common.Infrastructure.ConnectionProviders;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.InversionOfControl;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common._Installers;
using EdFi.Ods.Common._Installers.ComponentNaming;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Claims;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Standard.Container.Installers;
using FakeItEasy;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using Test.Common._Stubs;
using ApiConfigurationProvider = EdFi.Ods.Common.Configuration.ApiConfigurationProvider;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    public abstract class BaseDatabaseTest
    {
        private TransactionScope _transactionScope;

        public string BaseDatabase
        {
            get => GlobalDatabaseSetupFixture.PopulatedDatabaseName;
        }

        public string DatabaseName
        {
            get => GlobalDatabaseSetupFixture.TestPopulatedDatabaseName;
        }

        protected IWindsorContainer Container { get; set; }

        protected ISessionFactory SessionFactory { get; set; }

        [SetUp]
        public void BaseSetUp()
        {
            _transactionScope = new TransactionScope();
            RegisterDependencies();
            SessionFactory = Container.Resolve<ISessionFactory>();
        }

        [TearDown]
        public void BaseTearDown()
        {
            _transactionScope.Dispose();
        }

        private void RegisterDependencies()
        {
            var factory = new InversionOfControlContainerFactory();

            var apiConFigurationProvider = A.Fake<IApiConfigurationProvider>();

            A.CallTo(() => apiConFigurationProvider.DatabaseEngine).Returns(DatabaseEngine.SqlServer);

            Container = factory.CreateContainer(
                c =>
                {
                    c.AddFacility<TypedFactoryFacility>();
                    c.AddFacility<DatabaseConnectionStringProviderFacility>();
                });

            Container.Install(new LegacyEdFiOdsCommonInstaller());
            Container.Install(new EdFiOdsStandardInstaller());

            Container.Register(Component.For<IApiConfigurationProvider>().Instance(apiConFigurationProvider).LifestyleSingleton());

            Container.Register(
                Component.For<IConfigConnectionStringsProvider>()
                    .ImplementedBy<AppConfigConnectionStringsProvider>());

            Container.Register(
                Component.For<IDatabaseConnectionStringProvider>()
                    .Named("IDatabaseConnectionStringProvider.Ods")
                    .Instance(CreateDatabaseConnectionStringProvider()));

            Container.Install(new LegacyEdFiOdsNHibernateInstaller());
            Container.Install(new LegacyEdFiOdsApiInstaller());

            Container.Register(
                Component.For<IConfigValueProvider>()
                    .ImplementedBy<AppConfigValueProvider>());

            Container.Register(
                Component.For<ICacheProvider>()
                    .ImplementedBy<MemoryCacheProvider>());

            Container.Register(Component.For<IAssembliesProvider>().ImplementedBy<AssembliesProvider>());

            Container.Register(
                Component.For<DatabaseEngine>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<IApiConfigurationProvider>().DatabaseEngine));

            Container.Install(new NHibernateConfiguratorInstaller(Container.Resolve<IApiConfigurationProvider>()));

            // Register security component
            Container.Register(
                Component
                    .For<IAuthorizationContextProvider>()
                    .ImplementedBy<AuthorizationContextProvider>());

            Container.Register(
                Component
                    .For<IContextStorage>()
                    .ImplementedBy<HashtableContextStorage>());

            Container.Register(
                Component.For<IClaimsIdentityProvider>()
                    .ImplementedBy<ClaimsIdentityProvider>()
                    .LifestyleTransient());

            Container.Register(
                Component.For<ISecurityRepository>()
                    .ImplementedBy<StubSecurityRepository>());
        }

        private IDatabaseConnectionStringProvider CreateDatabaseConnectionStringProvider()
        {
            var nameDatabaseConnectionStringProvider = new NamedDatabaseConnectionStringProvider("EdFi_Ods");
            var connectionString = nameDatabaseConnectionStringProvider.GetConnectionString();
            var builder = new SqlConnectionStringBuilder(connectionString) { InitialCatalog = DatabaseName };

            var databaseConnectionStringProvider = A.Fake<IDatabaseConnectionStringProvider>();

            A.CallTo(() => databaseConnectionStringProvider.GetConnectionString())
                .Returns(builder.ConnectionString);

            return databaseConnectionStringProvider;
        }

        private static void InitializeNHibernate(IWindsorContainer container)
        {
            Environment.ObjectsFactory = new WindsorObjectsFactory(container);
            var nHibernateConfiguration = new Configuration().Configure();

            nHibernateConfiguration.AddCreateDateHooks();

            container
                .Register(
                    Component
                        .For<ISessionFactory>()
                        .UsingFactoryMethod(nHibernateConfiguration.BuildSessionFactory)
                        .LifeStyle.Singleton);

            container.Register(
                Component
                    .For<EdFiOdsConnectionProvider>()
                    .DependsOn(
                        Dependency
                            .OnComponent(
                                typeof(IDatabaseConnectionStringProvider),
                                typeof(IDatabaseConnectionStringProvider).GetServiceNameWithSuffix(Databases.Ods.ToString()))));
        }
    }
}

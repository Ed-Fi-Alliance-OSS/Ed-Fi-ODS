// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.SqlClient;
using System.Linq;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Diagnostics;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common._Installers.ComponentNaming;
using EdFi.Ods.Profiles.Test;
using EdFi.Ods.Security;
using EdFi.Ods.Standard;
//using Rhino.Mocks;
using FakeItEasy;

namespace EdFi.Ods.WebService.Tests.Owin
{
    internal abstract class OwinTestStartupBase : WebServiceTestsStartupBase
    {
        protected string BaseDatabase { get; set; }

        protected OwinTestStartupBase()
        {
            BaseDatabase = string.IsNullOrEmpty(BaseDatabase)
                ? GlobalDatabaseSetupFixture.PopulatedTemplateDatabaseName
                : BaseDatabase;
        }

        protected abstract void InstallTestSpecificInstaller(IWindsorContainer container);

        protected override void InstallConfigurationSpecificInstaller(IWindsorContainer container)
        {
            EnsureAssembliesLoaded();

            container.Register(
                Component.For<IConfigConnectionStringsProvider>()
                         .ImplementedBy<AppConfigConnectionStringsProvider>());

            container.Register(
                Component.For<IConfigValueProvider>()
                         .ImplementedBy<AppConfigValueProvider>());

            container.Register(
                Component.For<IConfigSectionProvider>()
                         .ImplementedBy<AppConfigSectionProvider>());

            container.Register(
                Component.For<IDatabaseEngineProvider>()
                         .ImplementedBy<DatabaseEngineProvider>());

            container.Register(
                Component.For<IApiConfigurationProvider>()
                    .ImplementedBy<ApiConfigurationProvider>()
            );

            container.Register(
                Component.For<ICacheProvider>()
                         .ImplementedBy<AspNetCacheProvider>());

            container.Register(
                Component.For<IDatabaseConnectionStringProvider>()
                         .Named("IDatabaseConnectionStringProvider.Admin")
                         .ImplementedBy<NamedDatabaseConnectionStringProvider>()
                         .DependsOn(Dependency.OnValue("connectionStringName", "EdFi_Admin")));

            container.Register(
                Component.For<IDatabaseConnectionStringProvider>()
                         .Named("IDatabaseConnectionStringProvider.EduId")
                         .ImplementedBy<NamedDatabaseConnectionStringProvider>()
                         .DependsOn(Dependency.OnValue("connectionStringName", "EduIdContext")));

            container.Register(
                Component.For<IDatabaseConnectionStringProvider>()
                         .Named("IDatabaseConnectionStringProvider.Master")
                         .ImplementedBy<NamedDatabaseConnectionStringProvider>()
                         .DependsOn(Dependency.OnValue("connectionStringName", "EdFi_master")));

            container.Register(
                Component.For<IContextStorage>()
                         .ImplementedBy<HashtableContextStorage>()
                         .IsDefault());

            RegisterOdsDatabase(container);

            InstallTestSpecificInstaller(container);

            container.Register(Component.For<DatabaseEngine>().UsingFactoryMethod(() => DatabaseEngine.SqlServer));
        }

        protected virtual void RegisterOdsDatabase(IWindsorContainer container)
        {
            var databaseConnectionStringProvider = CreateDatabaseConnectionStringProvider(BaseDatabase);

            container.Register(
                Component.For<IDatabaseConnectionStringProvider>()
                    .Named("IDatabaseConnectionStringProvider.Ods")
                    .Instance(databaseConnectionStringProvider));
        }

        protected IDatabaseConnectionStringProvider CreateDatabaseConnectionStringProvider(string database)
        {
            var nameDatabaseConnectionStringProvider = new NamedDatabaseConnectionStringProvider("EdFi_Ods");
            var connectionString = nameDatabaseConnectionStringProvider.GetConnectionString();
            var builder = new SqlConnectionStringBuilder(connectionString) { InitialCatalog = database };

            var databaseConnectionStringProvider = A.Fake<IDatabaseConnectionStringProvider>();

            A.CallTo(() => databaseConnectionStringProvider.GetConnectionString())
                .Returns(builder.ConnectionString);

            return databaseConnectionStringProvider;
        }

        public ILookup<IHandler, object> GetTrackedComponents()
        {
            var host = (IDiagnosticsHost) Container.Kernel.GetSubSystem(SubSystemConstants.DiagnosticsKey);
            var diagnostics = host.GetDiagnostic<ITrackedComponentsDiagnostic>();
            var trackedComponents = diagnostics.Inspect();
            return trackedComponents;
        }

        protected override void EnsureAssembliesLoaded()
        {
            base.EnsureAssembliesLoaded();

            AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Standard>();
            AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Security>();
        }

        protected override void InstallOpenApiMetadata(IWindsorContainer container)
        {
            // No OpenApiMetadata installation required.
        }

        protected override void InstallExtensions(IWindsorContainer container)
        {
            // No Extension installation required.
        }
    }
}

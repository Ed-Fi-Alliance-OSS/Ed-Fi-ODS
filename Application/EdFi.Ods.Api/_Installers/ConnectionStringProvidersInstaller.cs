// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Common;
using EdFi.Ods.Common._Installers;
using EdFi.Ods.Common._Installers.ComponentNaming;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Api._Installers
{
    public class ConnectionStringProvidersInstaller : IWindsorInstaller
    {
        private const string PrototypeConnectionStringName = "prototypeConnectionStringName";
        private const string EdFiOds = "EdFi_Ods";
        private readonly IApiConfigurationProvider _apiConfigurationProvider;

        public ConnectionStringProvidersInstaller(IApiConfigurationProvider apiConfigurationProvider)
        {
            _apiConfigurationProvider = Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbConnectionStringBuilderAdapterFactory>()
                    .ImplementedBy<DbConnectionStringBuilderAdapterFactory>());

            RegisterDatabaseNameProvider(container);
            RegisterAdminDatabaseProvider(container);
            RegisterSandboxAdminDatabaseProvider(container);
        }

        private void RegisterDatabaseNameProvider(IWindsorContainer container)
        {
            if (_apiConfigurationProvider.Mode.Equals(ApiMode.Sandbox))
            {
                RegisterSandbox(container);
            }
            else if (_apiConfigurationProvider.Mode.Equals(ApiMode.YearSpecific))
            {
                RegisterYearSpecific(container);
            }
            else if (_apiConfigurationProvider.Mode.Equals(ApiMode.SharedInstance))
            {
                RegisterSharedInstance(container);
            }
            else if (_apiConfigurationProvider.Mode.Equals(ApiMode.DistrictSpecific))
            {
                RegisterDistrictSpecific(container);
            }
            else
            {
                throw new NotSupportedException(
                    $"Unable to register a database provider and connection string for {_apiConfigurationProvider.Mode.DisplayName}.");
            }
        }

        private static void RegisterSharedInstance(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IDatabaseConnectionStringProvider>()
                    .NamedForDatabase(Databases.Ods)
                    .ImplementedBy<PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider>()
                    .DependsOn(Dependency.OnValue(PrototypeConnectionStringName, Databases.Ods.GetConnectionStringName()))
                    .DependsOn(
                        Dependency.OnComponent(
                            typeof(IDatabaseNameReplacementTokenProvider), DatabaseNameReplacementTokenStrategyRegistrationKeys.SharedInstance)),
                Component
                    .For<IDatabaseNameReplacementTokenProvider>()
                    .Named(DatabaseNameReplacementTokenStrategyRegistrationKeys.SharedInstance)
                    .ImplementedBy<SharedInstanceDatabaseNameReplacementTokenProvider>()
                    .DependsOn(Dependency.OnValue(PrototypeConnectionStringName,Databases.Ods.GetConnectionStringName()))
            );
        }

        private static void RegisterYearSpecific(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IDatabaseConnectionStringProvider>()
                    .NamedForDatabase(Databases.Ods)
                    .ImplementedBy<PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider>()
                    .DependsOn(Dependency.OnValue(PrototypeConnectionStringName, Databases.Ods.GetConnectionStringName()))
                    .DependsOn(
                        Dependency.OnComponent(
                            typeof(IDatabaseNameReplacementTokenProvider), DatabaseNameReplacementTokenStrategyRegistrationKeys.YearSpecific)),
                Component
                    .For<IDatabaseNameReplacementTokenProvider>()
                    .Named(DatabaseNameReplacementTokenStrategyRegistrationKeys.YearSpecific)
                    .ImplementedBy<YearSpecificDatabaseNameReplacementTokenProvider>()
            );
        }

        private static void RegisterSandbox(IWindsorContainer container)
        {
            // For ODS Sandboxes
            container.Register(
                Component
                    .For<IDatabaseConnectionStringProvider>()
                    .NamedForDatabase(Databases.Ods)
                    .ImplementedBy<PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider>()
                    .DependsOn(Dependency.OnValue(PrototypeConnectionStringName, EdFiOds))
                    .DependsOn(
                        Dependency.OnComponent(
                            typeof(IDatabaseNameReplacementTokenProvider), DatabaseNameReplacementTokenStrategyRegistrationKeys.Sandbox))
                    .IsFallback(),

                // Returns value that replaces token found in database connection string
                Component
                    .For<IDatabaseNameReplacementTokenProvider>()
                    .ImplementedBy<SandboxDatabaseNameReplacementTokenProvider>()
                    .Named(DatabaseNameReplacementTokenStrategyRegistrationKeys.Sandbox)
                    .IsFallback()
            );
        }

        private static void RegisterDistrictSpecific(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IDatabaseConnectionStringProvider>()
                    .NamedForDatabase(Databases.Ods)
                    .ImplementedBy<PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider>()
                    .DependsOn(Dependency.OnValue(PrototypeConnectionStringName, Databases.Ods.GetConnectionStringName()))
                    .DependsOn(
                        Dependency.OnComponent(
                            typeof(IDatabaseNameReplacementTokenProvider), DatabaseNameReplacementTokenStrategyRegistrationKeys.DistrictSpecific)),
                Component
                    .For<IDatabaseNameReplacementTokenProvider>()
                    .Named(DatabaseNameReplacementTokenStrategyRegistrationKeys.DistrictSpecific)
                    .ImplementedBy<DistrictSpecificDatabaseNameReplacementTokenProvider>()
            );
        }

        private static void RegisterSandboxAdminDatabaseProvider(IWindsorContainer container)
        {
            // Master database connection (for creating sandboxes)
            ConnectionStringProviderRegistrationHelper.RegisterNamedConnectionStringProvider(container, Databases.Master);
        }

        private static void RegisterAdminDatabaseProvider(IWindsorContainer container)
        {
            // Admin database
            ConnectionStringProviderRegistrationHelper.RegisterNamedConnectionStringProvider(container, Databases.Admin);
        }
    }
}

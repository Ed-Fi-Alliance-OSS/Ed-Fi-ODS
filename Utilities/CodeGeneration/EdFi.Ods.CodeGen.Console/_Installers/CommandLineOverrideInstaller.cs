// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.CodeGen.Console._Installers
{
    public class CommandLineOverrideInstaller : IWindsorInstaller
    {
        private readonly Options _options;

        public CommandLineOverrideInstaller(Options options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (!string.IsNullOrEmpty(_options.CodeRepositoryPath))
            {
                container.Register(
                    Component
                        .For<ICodeRepositoryProvider>()
                        .ImplementedBy<CodeRepositoryProvider>()
                        .DependsOn(Dependency.OnValue("codeRepositoryPath", _options.CodeRepositoryPath)));
            }

            if (_options.ViewsFromDatabase)
            {
                container.Register(
                    Component
                        .For<IViewsProvider>()
                        .ImplementedBy<DatabaseViewsProvider>());

                container.Register(
                    Component
                        .For<IEngineTypeProvider>()
                        .ImplementedBy<EngineTypeProvider>()
                        .DependsOn(Dependency.OnValue("engineType", _options.Engine)));

                container.Register(
                    Component
                        .For<IDatabaseConnectionStringProvider>()
                        .ImplementedBy<EngineBasedDatabaseConnectionStringProvider>());

                container.Register(
                    Component
                        .For<IDatabaseConnectionProvider>()
                        .ImplementedBy<EngineBasedDatabaseConnectionProvider>());
            }
            else
            {
                container.Register(
                    Component
                        .For<IViewsProvider>()
                        .ImplementedBy<ViewsProvider>());
            }
        }
    }
}

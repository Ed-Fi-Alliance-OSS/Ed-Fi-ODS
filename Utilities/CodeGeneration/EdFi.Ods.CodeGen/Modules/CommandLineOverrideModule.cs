// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.CodeGen.Modules
{
    public class CommandLineOverrideModule : Module
    {
        public Options Options { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (Options != null && !string.IsNullOrEmpty(Options.CodeRepositoryPath))
            {
                builder.RegisterType<CodeRepositoryProvider>()
                    .WithParameter(new NamedParameter("codeRepositoryPath", Options.CodeRepositoryPath))
                    .As<ICodeRepositoryProvider>();
            }

            if (!Options.ViewsFromDatabase)
            {
                builder.RegisterType<JsonViewsProvider>()
                    .As<IViewsProvider>();

                return;
            }

            builder.RegisterType<EngineTypeProvider>()
                .WithParameter(new NamedParameter("engineType", Options.Engine))
                .As<IEngineTypeProvider>();

            builder.RegisterType<EngineBasedDatabaseConnectionStringProvider>()
                .As<IDatabaseConnectionStringProvider>();

            builder.RegisterType<EngineBasedDatabaseConnectionProvider>()
                .As<IDatabaseConnectionProvider>();

            builder.RegisterType<DatabaseViewsProvider>()
                .As<IViewsProvider>();
        }
    }
}

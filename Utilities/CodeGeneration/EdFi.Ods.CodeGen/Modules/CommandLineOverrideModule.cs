﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;

namespace EdFi.Ods.CodeGen.Modules
{
    public class CommandLineOverrideModule : Module
    {
        public Options Options { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Options>();

            builder.RegisterType<CodeRepositoryProvider>()
                .WithParameter(new NamedParameter("codeRepositoryPath", Options.CodeRepositoryPath))
                .As<ICodeRepositoryProvider>()
                .OnlyIf(x => !string.IsNullOrWhiteSpace(Options.CodeRepositoryPath));

            builder.RegisterType<EngineTypeProvider>()
                .WithParameter(new NamedParameter("engineType", Options.Engine))
                .As<IEngineTypeProvider>();

            builder.RegisterType<ExtensionPluginsProvider>()
                .WithParameter(new NamedParameter("extensionPaths", Options.ExtensionPaths))
                .As<IExtensionPluginsProvider>();

            builder.RegisterType<IncludePluginsProvider>()
                .WithParameter(new NamedParameter("includePlugins", Options.IncludePlugins))
                .As<IIncludePluginsProvider>();

            builder.RegisterType<AuthorizationDatabaseTableViewsProvider>()
                .As<IAuthorizationDatabaseTableViewsProvider>()
                .OnlyIf(x => Options.ViewsFromDatabase);

            builder.RegisterType<JsonViewsProvider>()
                .As<IAuthorizationDatabaseTableViewsProvider>()
                .OnlyIf(x => !Options.ViewsFromDatabase);

            builder.RegisterType<ExtensionVersionsPathProvider>()
                .WithParameter(new NamedParameter("extensionVersion", Options.ExtensionVersion))
                .As<IExtensionVersionsPathProvider>();

            builder.RegisterType<StandardVersionPathProvider>()
                .WithParameter(new NamedParameter("standardVersion", Options.StandardVersion))
                .As<IStandardVersionPathProvider>();
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
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

            builder.RegisterType<DatabaseViewsProvider>()
                .As<IViewsProvider>()
                .OnlyIf(x => Options.ViewsFromDatabase);

            builder.RegisterType<JsonViewsProvider>()
                .As<IViewsProvider>()
                .OnlyIf(x => !Options.ViewsFromDatabase);

            builder.RegisterType<DatabaseTupleTableProvider>()
                .As<ITupleTableProvider>()
                .OnlyIf(x => Options.TupleTableFromDatabase);

            builder.RegisterType<JsonTupleTableProvider>()
                .As<ITupleTableProvider>()
                .OnlyIf(x => !Options.TupleTableFromDatabase);
        }
    }
}

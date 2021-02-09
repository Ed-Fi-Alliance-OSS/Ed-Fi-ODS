// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using Autofac;
using EdFi.Common.Database;
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
            if (Options == null)
            {
                return;
            }

            builder.RegisterType<CodeRepositoryProvider>()
                .WithParameter(new NamedParameter("codeRepositoryPath", Options.CodeRepositoryPath))
                .As<ICodeRepositoryProvider>();

            builder.RegisterType<EngineTypeProvider>()
                .WithParameter(new NamedParameter("engineType", Options.Engine))
                .As<IEngineTypeProvider>();

            builder.RegisterType<ExtensionLocationPluginsProvider>()
                .WithParameter(new NamedParameter("extensionPaths", Options.ExtensionPaths))
                .As<IExtensionLocationPluginsProvider>();

            builder.RegisterType<IncludePluginsProvider>()
                .WithParameter(new NamedParameter("includePlugins", Options.IncludePlugins))
                .As<IIncludePluginsProvider>();

            if (Options.ViewsFromDatabase)
            {
                builder.RegisterType<DatabaseViewsProvider>()
                    .As<IViewsProvider>();
            }
            else
            {
                builder.RegisterType<JsonViewsProvider>()
                    .As<IViewsProvider>();
            }
        }
    }
}

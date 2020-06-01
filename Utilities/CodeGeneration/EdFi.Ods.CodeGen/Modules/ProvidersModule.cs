// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Generators;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen.Processing.Impl;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;

namespace EdFi.Ods.CodeGen.Modules
{
    public class ProvidersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GeneratorBase).Assembly)
                .AssignableTo<IGenerator>()
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterType<JsonFileProvider>()
                .As<IJsonFileProvider>();

            builder.RegisterType<AssemblyDataProvider>()
                .As<IAssemblyDataProvider>();

            builder.RegisterType<DeveloperCodeRepositoryProvider>()
                .As<ICodeRepositoryProvider>()
                .PreserveExistingDefaults();

            builder.RegisterType<GeneratorProvider>()
                .As<IGeneratorProvider>();

            builder.RegisterType<DatabaseTypeTranslator>()
                .As<IDatabaseTypeTranslator>();

            builder.RegisterType<MetadataFolderProvider>()
                .As<IMetadataFolderProvider>();

            builder.RegisterType<MustacheTemplateProvider>()
                .As<IMustacheTemplateProvider>();

            builder.RegisterType<TemplateSetProvider>()
                .As<ITemplateSetProvider>();

            builder.RegisterType<TemplateContextProvider>()
                .As<ITemplateContextProvider>();

            builder.RegisterType<DomainModelDefinitionProvidersProvider>()
                .As<IDomainModelDefinitionsProviderProvider>();

            builder.RegisterType<SchemaFileProvider>()
                .As<ISchemaFileProvider>();

            builder.RegisterType<ViewsProvider>()
                .As<IViewsProvider>();
        }
    }
}

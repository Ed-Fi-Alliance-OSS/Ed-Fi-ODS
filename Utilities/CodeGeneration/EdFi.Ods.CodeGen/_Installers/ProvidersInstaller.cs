// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Generators;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen.Processing.Impl;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;

namespace EdFi.Ods.CodeGen._Installers
{
    public class ProvidersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssembly(GetType().Assembly).BasedOn<IGenerator>().WithService.FromInterface(),
                Component.For<IJsonFileProvider>().ImplementedBy<JsonFileProvider>(),
                Component.For<IAssemblyDataProvider>().ImplementedBy<AssemblyDataProvider>(),
                Component.For<ICodeRepositoryProvider>().ImplementedBy<DeveloperCodeRepositoryProvider>().IsFallback(),
                Component.For<IGeneratorProvider>().ImplementedBy<GeneratorProvider>(),
                Component.For<IDatabaseTypeTranslator>().ImplementedBy<DatabaseTypeTranslator>(),
                Component.For<IMetadataFolderProvider>().ImplementedBy<MetadataFolderProvider>(),
                Component.For<IMustacheTemplateProvider>().ImplementedBy<MustacheTemplateProvider>(),
                Component.For<ITemplateSetProvider>().ImplementedBy<TemplateSetProvider>(),
                Component.For<ITemplateContextProvider>().ImplementedBy<TemplateContextProvider>(),
                Component.For<IDomainModelDefinitionsProviderProvider>().ImplementedBy<DomainModelDefinitionProvidersProvider>(),
                Component.For<ISchemaFileProvider>().ImplementedBy<SchemaFileProvider>());
        }
    }
}

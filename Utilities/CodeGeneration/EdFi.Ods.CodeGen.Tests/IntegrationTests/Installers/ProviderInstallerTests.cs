// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen._Installers;
using EdFi.Ods.CodeGen.Console;
using EdFi.Ods.CodeGen.Console._Installers;
using EdFi.Ods.CodeGen.Generators;
using EdFi.Ods.CodeGen.Models;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Installers
{
    [TestFixture(Category = "localonly")]
    public class ProviderInstallerTests
    {
        public class When_using_the_provider_installer : TestFixtureBase
        {
            private IWindsorContainer _container;

            protected override void Arrange()
            {
                _container = new WindsorContainer();
                _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));

                _container.Install(new AppConfigInstaller());
                _container.Install(new CommandLineOverrideInstaller(new Options { Engine = EngineType.SQLServer }));
            }

            protected override void Act() => _container.Install(new ProvidersInstaller());

            [Test]
            public void Should_resolve_all_the_generators() => _container.ResolveAll<IGenerator>().Length.ShouldBeGreaterThan(1);

            [Test, LocalTestOnly]
            public void Should_resolve_assembly_data_provider() => _container.Resolve<IAssemblyDataProvider>().ShouldNotBeNull();

            [Test, LocalTestOnly]
            public void Should_resolve_code_repository_provider() => _container.Resolve<ICodeRepositoryProvider>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_database_schema_provider() => _container.Resolve<IViewsProvider>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_database_type_translator() => _container.Resolve<IDatabaseTypeTranslator>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_domain_model_definitions_provider()
                => _container.Resolve<IDomainModelDefinitionsProviderProvider>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_json_file_provider() => _container.Resolve<IJsonFileProvider>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_metadata_directory_provider() => _container.Resolve<IMetadataFolderProvider>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_mustache_template_provider_provider() => _container.Resolve<IMustacheTemplateProvider>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_schema_file_provider() => _container.Resolve<ISchemaFileProvider>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_template_context_provider() => _container.Resolve<ITemplateContextProvider>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_template_model_provider() => _container.Resolve<IGeneratorProvider>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_template_set_provider() => _container.Resolve<ITemplateSetProvider>().ShouldNotBeNull();
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen._Installers;
using EdFi.Ods.CodeGen.Console;
using EdFi.Ods.CodeGen.Console._Installers;
using EdFi.Ods.CodeGen.Models;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Installers
{
    [TestFixture]
    public class ProcessingInstallerTests
    {
        public class When_using_the_processing_installer : TestFixtureBase
        {
            private IWindsorContainer _container;

            protected override void Arrange()
            {
                _container = new WindsorContainer();
                _container.Install(new AppConfigInstaller());
                _container.Install(new ProvidersInstaller());
                _container.Install(new CommandLineOverrideInstaller(new Options { Engine = EngineType.SQLServer }));
            }

            protected override void Act()
            {
                _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
                _container.Install(new ProcessingInstaller());
            }

            [Test]
            public void Should_resolve_ITemplateProcessor() => _container.Resolve<ITemplateProcessor>().ShouldNotBeNull();

            [Test]
            public void Should_resolve_ITemplateWriter() => _container.Resolve<ITemplateWriter>().ShouldNotBeNull();
        }
    }
}

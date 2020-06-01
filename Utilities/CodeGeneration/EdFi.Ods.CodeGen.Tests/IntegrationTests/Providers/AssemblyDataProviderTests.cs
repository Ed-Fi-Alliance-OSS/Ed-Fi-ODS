// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen._Installers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Providers
{
    [TestFixture, LocalTestOnly]
    public class AssemblyDataProviderTests
    {
        [LocalTestOnly]
        public class When_getting_code_generation_assembly_files : TestFixtureBase
        {
            private WindsorContainer _container;
            private IAssemblyDataProvider _assemblyDataProvider;
            private List<AssemblyData> _assemblyDatas;

            protected override void Arrange()
            {
                _container = new WindsorContainer();
                _container.Install(new AppConfigInstaller(), new ProvidersInstaller());
                _assemblyDataProvider = _container.Resolve<IAssemblyDataProvider>();
            }

            protected override void Act() => _assemblyDatas = _assemblyDataProvider.Get().ToList();

            [Test]
            public void Should_not_be_empty() => _assemblyDatas.ShouldNotBeEmpty();

            [Test]
            public void Should_have_correct_number_of_assemblies_for_processing() => _assemblyDatas.Count.ShouldBe(9);
        }
    }
}

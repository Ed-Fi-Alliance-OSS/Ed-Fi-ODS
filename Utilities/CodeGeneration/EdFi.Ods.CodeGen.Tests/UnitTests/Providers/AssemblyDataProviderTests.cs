// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Autofac;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers;
using EdFi.Ods.Common.Models;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.UnitTests.Providers
{
    [TestFixture]
    public class AssemblyDataProviderTests
    {
        public class When_loading_assembly_data : TestFixtureBase
        {
            private IAssemblyDataProvider _assemblyDataProvider;
            private IJsonFileProvider _jsonFileProvider;
            private IDomainModelDefinitionsProviderProvider _domainModelDefinitionsProviderProvider;
            private ICodeRepositoryProvider _codeRepositoryProvider;
            private IIncludePluginsProvider _includePluginsProvider;
            private IExtensionPluginsProvider _extensionLocationPluginsProvider;
            private List<AssemblyData> _assemblyData;

            protected override void Arrange()
            {
                _domainModelDefinitionsProviderProvider = Stub<IDomainModelDefinitionsProviderProvider>();
                _jsonFileProvider = Stub<IJsonFileProvider>();
                _codeRepositoryProvider = Stub<ICodeRepositoryProvider>();
                var codeRepositoryHelper = new CodeRepositoryHelper(TestContext.CurrentContext.TestDirectory);

                A.CallTo(() => _codeRepositoryProvider.GetResolvedCodeRepositoryByName(A<string>._, A<string>._))
                    .Returns(codeRepositoryHelper[CodeRepositoryConventions.ExtensionsRepositoryName]);

                string extensionsPath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                    CodeRepositoryConventions.ExtensionsRepositoryName,
                    "Extensions");

                _includePluginsProvider = A.Fake<IncludePluginsProvider>(
                    x => x.WithArgumentsForConstructor(() => new IncludePluginsProvider(true)));

                _extensionLocationPluginsProvider = A.Fake<ExtensionPluginsProvider>(
                    x => x.WithArgumentsForConstructor(
                        () => new ExtensionPluginsProvider(new[] {extensionsPath})));

                A.CallTo(() => _codeRepositoryProvider.GetCodeRepositoryByName(A<string>._))
                    .Returns(codeRepositoryHelper[CodeRepositoryConventions.Implementation]);

                var domainModelDefinitionsByPath =
                    new Dictionary<string, IDomainModelDefinitionsProvider>(StringComparer.InvariantCultureIgnoreCase);

                domainModelDefinitionsByPath.Add(
                    "EdFi.Ods.Standard",
                    new DomainModelDefinitionsJsonFileSystemProvider(
                        codeRepositoryHelper[CodeRepositoryConventions.Ods] +
                        "Application\\EdFi.Ods.Standard\\Artifacts\\Metadata\\ApiModel.json"));

                domainModelDefinitionsByPath.Add(
                    "EdFi.Ods.Extensions.Homograph",
                    new DomainModelDefinitionsJsonFileSystemProvider(
                        codeRepositoryHelper[CodeRepositoryConventions.ExtensionsRepositoryName] +
                        "\\Extensions\\EdFi.Ods.Extensions.Homograph\\Artifacts\\Metadata\\ApiModel-EXTENSION.json"));

                domainModelDefinitionsByPath.Add(
                    "EdFi.Ods.Extensions.Sample",
                    new DomainModelDefinitionsJsonFileSystemProvider(
                        codeRepositoryHelper[CodeRepositoryConventions.ExtensionsRepositoryName] +
                        "\\Extensions\\EdFi.Ods.Extensions.Sample\\Artifacts\\Metadata\\ApiModel-EXTENSION.json"));

                domainModelDefinitionsByPath.Add(
                    "EdFi.Ods.Extensions.TPDM",
                    new DomainModelDefinitionsJsonFileSystemProvider(
                        codeRepositoryHelper[CodeRepositoryConventions.ExtensionsRepositoryName] +
                        "\\Extensions\\EdFi.Ods.Extensions.TPDM\\Artifacts\\Metadata\\ApiModel-EXTENSION.json"));

                A.CallTo(() => _domainModelDefinitionsProviderProvider.DomainModelDefinitionsProvidersByProjectName())
                    .Returns(domainModelDefinitionsByPath);

                //_assemblyDataProvider = new AssemblyDataProvider(
                //    _codeRepositoryProvider,
                //    _includePluginsProvider,
                //    _extensionLocationPluginsProvider);
            }

            protected override void Act() => _assemblyData = _assemblyDataProvider.Get().ToList();

            [Test]
            public void Should_have_five_assemblies_for_processing() => _assemblyData.Count.ShouldBe(5);
        }

        public class When_getting_known_assembly_data_without_extensions_or_plugins : TestFixtureBase
        {
            private IAssemblyDataProvider _assemblyDataProvider;
            private List<AssemblyData> _assemblyData;

            protected override void Arrange()
            {
                var codeRepositoryProvider = A.Fake<ICodeRepositoryProvider>();
                var assemblyDataHelper = A.Fake<AssemblyDataHelper>();
                var includePluginsProvider = A.Fake<IIncludePluginsProvider>();
                var extensionLocationPluginsProvider = A.Fake<IExtensionPluginsProvider>();

                A.CallTo(() => includePluginsProvider.IncludePlugins()).Returns(false);
                A.CallTo(() => extensionLocationPluginsProvider.GetExtensionLocationPlugins()).Returns(Array.Empty<string>());

                A.CallTo(() => Directory.GetFiles(A<string>.Ignored)).MustHaveHappened();

                //_assemblyDataProvider =
                //    new AssemblyDataProvider(
                //        codeRepositoryProvider,
                //        assemblyDataHelper,
                //        includePluginsProvider,
                //        extensionLocationPluginsProvider);
            }

            protected override void Act() => _assemblyData = _assemblyDataProvider.Get().ToList();

            [Test]
            public void Should_have_five_assemblies_for_processing() => _assemblyData.ShouldNotBeNull();
        }
    }
}

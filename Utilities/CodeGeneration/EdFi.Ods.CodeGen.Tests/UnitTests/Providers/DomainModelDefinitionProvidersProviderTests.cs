// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.Common.Models;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.UnitTests.Providers
{
    [TestFixture]
    public class DomainModelDefinitionProvidersProviderTests
    {
        public class When_loading_domain_model_definitions : TestFixtureBase
        {
            private IDomainModelDefinitionsProviderProvider _domainModelDefinitionProvidersProvider;
            private ICodeRepositoryProvider _codeRepositoryProvider;
            private IIncludePluginsProvider _includePluginsProvider;
            private IExtensionPluginsProvider _extensionPluginsProvider;
            private IEnumerable<IDomainModelDefinitionsProvider> _domainModelDefinitionProviders;
            private IDictionary<string, IDomainModelDefinitionsProvider> _domainModelDefinitionsProvidersByProjectName;
            private Dictionary<string, IDomainModelDefinitionsProvider> _createDomainModelDefinitionsByPath;

            protected override void Arrange()
            {
                _codeRepositoryProvider = Stub<ICodeRepositoryProvider>();
                var codeRepositoryHelper = new CodeRepositoryHelper(TestContext.CurrentContext.TestDirectory);

                A.CallTo(() => _codeRepositoryProvider.GetResolvedCodeRepositoryByName(A<string>._, A<string>._))
                    .Returns(codeRepositoryHelper[CodeRepositoryConventions.ExtensionsRepositoryName]);

                string extensionsPath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                    CodeRepositoryConventions.ExtensionsRepositoryName,
                    "Extensions");
                
                _includePluginsProvider = A.Fake<IncludePluginsProvider>(
                    x => x.WithArgumentsForConstructor(() => new IncludePluginsProvider(true)));

                _extensionPluginsProvider = A.Fake<ExtensionPluginsProvider>(
                    x => x.WithArgumentsForConstructor(
                        () => new ExtensionPluginsProvider(new[] { extensionsPath })));

                A.CallTo(() => _codeRepositoryProvider.GetCodeRepositoryByName(A<string>._))
                    .Returns(codeRepositoryHelper[CodeRepositoryConventions.Implementation]);

                _domainModelDefinitionProvidersProvider = new DomainModelDefinitionProvidersProvider(
                    _codeRepositoryProvider,
                    _extensionPluginsProvider,
                    _includePluginsProvider);
            }

            protected override void Act()
            {
                _domainModelDefinitionProviders = _domainModelDefinitionProvidersProvider.DomainModelDefinitionProviders();
                _domainModelDefinitionsProvidersByProjectName= _domainModelDefinitionProvidersProvider.DomainModelDefinitionsProvidersByProjectName();
                _createDomainModelDefinitionsByPath = _domainModelDefinitionProvidersProvider.CreateDomainModelDefinitionsByPath();
            }

            [Test]
            public void Should_call_get_meta_data_directory_once()
                => A.CallTo(() => _codeRepositoryProvider.GetCodeRepositoryByName(A<string>.That.Not.IsNullOrEmpty()))
                    .MustHaveHappenedOnceExactly();

            [Test]
            public void Should_call_get_domain_model_definition_providers()
                =>  _domainModelDefinitionProviders.ShouldNotBeNull();
            

            [Test]
            public void Should_call_get_domain_model_definition_providers_by_projectName()
            {
                _domainModelDefinitionsProvidersByProjectName["EdFi.Ods.Standard"].ShouldNotBeNull();
                _domainModelDefinitionsProvidersByProjectName["EdFi.Ods.Extensions.Homograph"].ShouldNotBeNull();
                _domainModelDefinitionsProvidersByProjectName["EdFi.Ods.Extensions.Sample"].ShouldNotBeNull();
                _domainModelDefinitionsProvidersByProjectName["EdFi.Ods.Extensions.TPDM"].ShouldNotBeNull();
            }

            [Test]
            public void Should_call_create_domain_model_definitions_bypath()
            {
               _createDomainModelDefinitionsByPath["EdFi.Ods.Standard"].ShouldNotBeNull();
               _createDomainModelDefinitionsByPath["EdFi.Ods.Extensions.Homograph"].ShouldNotBeNull();
               _createDomainModelDefinitionsByPath["EdFi.Ods.Extensions.Sample"].ShouldNotBeNull();
               _createDomainModelDefinitionsByPath["EdFi.Ods.Extensions.TPDM"].ShouldNotBeNull();
            }
        }
    }
}

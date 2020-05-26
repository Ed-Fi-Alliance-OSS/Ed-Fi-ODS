// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Processing.Impl;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.UnitTests.Processing
{
    [TestFixture]
    public class TemplateContextProviderTests
    {
        public class When_getting_the_template_context : TestFixtureBase
        {
            private IDomainModelDefinitionsProviderProvider _domainModelDefinitionsProviderProvider;
            private TemplateContext _result;
            private CodeRepositoryHelper _codeRepositoryHelper;
            private TemplateContextProvider _templateContextProvider;
            private AssemblyData _assemblyData;
            private IEnumerable<IDomainModelDefinitionsProvider> _domainModelDefinitionsProviders;

            protected override void Arrange()
            {
                _codeRepositoryHelper = new CodeRepositoryHelper(Environment.CurrentDirectory);

                _assemblyData = new AssemblyData
                                {
                                    AssemblyName = "testAssembly", Path = "testFolder", TemplateSet = "standard", IsExtension = false,
                                    IsProfile = false, SchemaName = EdFiConventions.ProperCaseName
                                };

                var domainModelDefinition = new DomainModelDefinitions
                                            {
                                                SchemaDefinition = new SchemaDefinition("Ed-Fi", "edfi")
                                            };

                var domainModelDefinitionsProvider = Stub<IDomainModelDefinitionsProvider>();

                A.CallTo(() => domainModelDefinitionsProvider.GetDomainModelDefinitions())
                 .Returns(domainModelDefinition);

                _domainModelDefinitionsProviders = new[]
                                                   {
                                                       domainModelDefinitionsProvider
                                                   };

                _domainModelDefinitionsProviderProvider = Stub<IDomainModelDefinitionsProviderProvider>();

                A.CallTo(() => _domainModelDefinitionsProviderProvider.DomainModelDefinitionProviders())
                 .Returns(_domainModelDefinitionsProviders);

                _templateContextProvider = new TemplateContextProvider(_domainModelDefinitionsProviderProvider);
            }

            protected override void Act()
            {
                _result = _templateContextProvider.Create(_assemblyData);
            }

            [Test]
            public void Should_call_domain_model_definition_provider_once() 
                => A.CallTo(() => _domainModelDefinitionsProviderProvider.DomainModelDefinitionProviders())
                    .MustHaveHappenedOnceExactly();

            [Test]
            public void Should_not_return_null() => _result.ShouldNotBeNull();
        }

        public class When_getting_the_template_context_for_profile : TestFixtureBase
        {
            private IDomainModelDefinitionsProviderProvider _domainModelDefinitionsProviderProvider;
            private TemplateContext _result;
            private TemplateContextProvider _templateContextProvider;
            private AssemblyData _assemblyData;
            private IEnumerable<IDomainModelDefinitionsProvider> _domainModelDefinitionsProviders;

            protected override void Arrange()
            {
                _assemblyData = new AssemblyData
                                {
                                    AssemblyName = "testAssembly", Path = "testFolder", TemplateSet = "standard",
                                    IsExtension = false,IsProfile = true, SchemaName = EdFiConventions.ProperCaseName
                                };

                var domainModelDefinition = new DomainModelDefinitions
                                            {
                                                SchemaDefinition = new SchemaDefinition("Ed-Fi", "edfi")
                                            };

                var domainModelDefinitionsProvider = Stub<IDomainModelDefinitionsProvider>();

                A.CallTo(() => domainModelDefinitionsProvider.GetDomainModelDefinitions())
                 .Returns(domainModelDefinition);

                _domainModelDefinitionsProviders = new[]
                                                   {
                                                       domainModelDefinitionsProvider
                                                   };

                _domainModelDefinitionsProviderProvider = Stub<IDomainModelDefinitionsProviderProvider>();

                A.CallTo(() => _domainModelDefinitionsProviderProvider.DomainModelDefinitionProviders())
                 .Returns(_domainModelDefinitionsProviders);

                _templateContextProvider = new TemplateContextProvider(_domainModelDefinitionsProviderProvider);
            }

            protected override void Act()
            {
                _result = _templateContextProvider.Create(_assemblyData);
            }

            public override void RunOnceAfterAll() { }

            [Test]
            public void Should_call_domain_model_definition_provider_once() 
                => A.CallTo(() => _domainModelDefinitionsProviderProvider.DomainModelDefinitionProviders())
                    .MustHaveHappenedOnceExactly();

            [Test]
            public void Should_not_return_null() => _result.ShouldNotBeNull();
        }
    }
}

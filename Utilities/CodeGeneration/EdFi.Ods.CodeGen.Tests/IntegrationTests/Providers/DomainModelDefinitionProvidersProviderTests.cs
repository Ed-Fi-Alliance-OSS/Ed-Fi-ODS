// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers;
using EdFi.Ods.Common.Models;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Providers
{
    [TestFixture]
    public class DomainModelDefinitionProvidersProviderTests
    {
        public class When_loading_domain_model_definitions : TestFixtureBase
        {
            private IDomainModelDefinitionsProviderProvider _domainModelDefinitionProvidersProvider;
            private IEnumerable<IDomainModelDefinitionsProvider> _domainModelDefinitionProviders;
            private IDictionary<string, IDomainModelDefinitionsProvider> _domainModelDefinitionsProvidersByProjectName;

            protected override void Arrange()
            {
                var container = ContainerHelper.CreateContainer(
                    new Options
                    {
                        ExtensionPaths = new[]
                        {
                            new CodeRepositoryHelper(TestContext.CurrentContext.TestDirectory)[
                                CodeRepositoryConventions.ExtensionsRepositoryName]
                        },
                        StandardVersion = "5.0.0",
                        ExtensionVersion = "1.1.0"
                    });

                _domainModelDefinitionProvidersProvider = container.Resolve<IDomainModelDefinitionsProviderProvider>();
            }

            protected override void Act()
            {
                _domainModelDefinitionProviders = _domainModelDefinitionProvidersProvider.DomainModelDefinitionProviders();
                _domainModelDefinitionsProvidersByProjectName = _domainModelDefinitionProvidersProvider.DomainModelDefinitionsProvidersByProjectName();
            }

            [Test]
            public void Should_call_get_domain_model_definition_providers()
            {
                _domainModelDefinitionProviders.ShouldNotBeNull();
            }

            [Test]
            public void Should_call_get_domain_model_definition_providers_by_projectName()
            {
                _domainModelDefinitionsProvidersByProjectName["EdFi.Ods.Standard"].ShouldNotBeNull();
                _domainModelDefinitionsProvidersByProjectName["EdFi.Ods.Extensions.Homograph"].ShouldNotBeNull();
                _domainModelDefinitionsProvidersByProjectName["EdFi.Ods.Extensions.Sample"].ShouldNotBeNull();
                _domainModelDefinitionsProvidersByProjectName["EdFi.Ods.Extensions.TPDM"].ShouldNotBeNull();
            }
        }
    }
}

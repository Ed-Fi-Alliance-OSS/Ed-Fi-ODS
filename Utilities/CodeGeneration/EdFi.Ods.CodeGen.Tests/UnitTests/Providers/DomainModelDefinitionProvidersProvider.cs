﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;
using FakeItEasy;
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.UnitTests.Providers
{
    [TestFixture]
    public class DomainModelDefinitionProvidersProviderTests
    {
        public class When_loading_domain_model_definitions : TestFixtureBase
        {
            private DomainModelDefinitionProvidersProvider _domainModelDefinitionProvidersProvider;
            private ICodeRepositoryProvider _codeRepositoryProvider;

            protected override void Arrange()
            {
                _codeRepositoryProvider = Stub<ICodeRepositoryProvider>();
                var codeRepositoryHelper = new CodeRepositoryHelper(TestContext.CurrentContext.TestDirectory);

                A.CallTo(() => _codeRepositoryProvider.GetCodeRepositoryByName(A<string>._))
                    .Returns(codeRepositoryHelper[CodeRepositoryConventions.Implementation]);

                _domainModelDefinitionProvidersProvider = new DomainModelDefinitionProvidersProvider(_codeRepositoryProvider);
            }

            protected override void Act() => _domainModelDefinitionProvidersProvider.DomainModelDefinitionProviders();

            [Test]
            public void Should_call_get_meta_data_directory_once()
                => A.CallTo(() => _codeRepositoryProvider.GetCodeRepositoryByName(A<string>.That.Not.IsNullOrEmpty()))
                    .MustHaveHappenedOnceExactly();
        }
    }
}

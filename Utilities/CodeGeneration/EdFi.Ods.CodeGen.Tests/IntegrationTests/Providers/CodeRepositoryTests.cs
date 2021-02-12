// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using Autofac;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Providers
{
    [TestFixture]
    [LocalTestOnly]
    public class CodeRepositoryTests
    {
        [LocalTestOnly]
        public class When_getting_items_from_the_code_repository : TestFixtureBase
        {
            private IContainer _container;
            private ICodeRepositoryProvider _codeRepositoryProvider;

            protected override void Arrange() => _container = ContainerHelper.CreateContainer(new Options());

            protected override void Act() => _codeRepositoryProvider = _container.Resolve<ICodeRepositoryProvider>();

            [Test]
            public void Should_have_a_valid_resolved_implementation_path()
                => Directory
                    .Exists(
                        _codeRepositoryProvider.GetCodeRepositoryByName(
                            CodeRepositoryConventions.Implementation))
                    .ShouldBeTrue();

            [Test]
            public void Should_have_a_valid_resolved_ods_path()
                => Directory.Exists(_codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Ods))
                    .ShouldBeTrue();

            [Test]
            public void Should_have_a_valid_resolved_root_path()
                => Directory.Exists(_codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Root))
                    .ShouldBeTrue();
        }
    }
}

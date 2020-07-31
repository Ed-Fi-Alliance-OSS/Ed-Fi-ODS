// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers
{
    [TestFixture]
    [LocalTestOnly]
    public class CodeRepositoryHelperTests
    {
        [LocalTestOnly]
        public class When_getting_code_repository_entries : TestFixtureBase
        {
            private CodeRepositoryHelper _codeRepositoryHelper;

            protected override void Act()
                => _codeRepositoryHelper = new CodeRepositoryHelper(TestContext.CurrentContext.TestDirectory);

            [Test]
            public void Should_have_valid_implementation_path()
                => Directory.Exists(_codeRepositoryHelper[CodeRepositoryConventions.Implementation])
                    .ShouldBeTrue();

            [Test]
            public void Should_have_valid_ods_path()
                => Directory.Exists(_codeRepositoryHelper[CodeRepositoryConventions.Ods])
                    .ShouldBeTrue();

            [Test]
            public void Should_have_valid_root_path()
                => Directory.Exists(_codeRepositoryHelper[CodeRepositoryConventions.Root])
                    .ShouldBeTrue();
        }
    }
}

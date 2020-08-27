// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Security;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    public class SandboxDatabaseNameProviderTests : TestBase
    {
        [TestFixture]
        public class When_calling_SandboxDatabaseNameProvider_GetDatabaseName : TestBase
        {
            [Test]
            public void Should_return_the_database_name()
            {
                var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();
                A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                    .Returns(new ApiKeyContext("TheApiKey", null, null, null, null, null, null, null));

                var expected = "Ods_Sandbox_TheApiKey";
                var provider = new SandboxDatabaseNameProvider(apiKeyContextProvider);
                var actual = provider.GetDatabaseName();
                actual.ShouldBe(expected);
            }
        }
    }
}

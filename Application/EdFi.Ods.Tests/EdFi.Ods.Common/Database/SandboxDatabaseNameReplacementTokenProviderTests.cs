// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Security;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    public class When_using_sandbox_database_name_replacement_token_provider_with_valid_api_key
        : TestFixtureBase
    {
        private const string ApiKey = "UrzHS2q8Oh0R9ovVusGQp";
        private string _actualReplacementToken;

        private IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(ApiKey,
                        string.Empty,
                        Enumerable.Empty<int>(),
                        Enumerable.Empty<string>(),
                        Enumerable.Empty<string>(),
                        string.Empty,
                        null, null));

            _databaseNameReplacementTokenProvider =
                new SandboxDatabaseNameReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _actualReplacementToken = _databaseNameReplacementTokenProvider.GetReplacementToken();
        }

        [Test]
        public void Should_return_correct_value()
        {
            _actualReplacementToken.ShouldBe($"Ods_Sandbox_{ApiKey}");
        }
    }

    public class When_using_sandbox_database_name_replacement_token_provider_with_blank_api_key
        : TestFixtureBase
    {
        private const string ApiKey = "   ";
        private string _actualReplacementToken;

        private IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(ApiKey,
                    string.Empty,
                    Enumerable.Empty<int>(),
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null));

            _databaseNameReplacementTokenProvider =
                new SandboxDatabaseNameReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _actualReplacementToken = _databaseNameReplacementTokenProvider.GetReplacementToken();
        }

        [Test]
        public void Should_return_correct_value()
        {
            _actualReplacementToken.ShouldBe($"Ods_Sandbox_{ApiKey}");
        }
    }

    public class When_using_sandbox_database_name_replacement_token_provider_with_null_api_key : TestFixtureBase
    {
        private IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(null,
                    string.Empty,
                    Enumerable.Empty<int>(),
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null));

            _databaseNameReplacementTokenProvider =
                new SandboxDatabaseNameReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseNameReplacementTokenProvider.GetReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }

    public class When_using_sandbox_database_name_replacement_token_provider_with_empty_api_key : TestFixtureBase
    {
        private IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(string.Empty,
                    string.Empty,
                    Enumerable.Empty<int>(),
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null));

            _databaseNameReplacementTokenProvider =
                new SandboxDatabaseNameReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseNameReplacementTokenProvider.GetReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }
}
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
    public class When_using_sandbox_database_replacement_token_provider_with_valid_api_key
        : TestFixtureBase
    {
        private const string ApiKey = "UrzHS2q8Oh0R9ovVusGQp";
        private string _actualDatabaseNameReplacementToken;
        private string _actualServerNameReplacementToken;

        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(ApiKey,
                        string.Empty,
                        Array.Empty<int>(),
                        Enumerable.Empty<string>(),
                        Enumerable.Empty<string>(),
                        string.Empty,
                        null, null,0));

            _databaseReplacementTokenProvider =
                new SandboxDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _actualDatabaseNameReplacementToken = _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
            _actualServerNameReplacementToken = _databaseReplacementTokenProvider.GetServerNameReplacementToken();
        }

        [Test]
        public void Should_return_correct_database_name_replacement_token()
        {
            _actualDatabaseNameReplacementToken.ShouldBe($"Ods_Sandbox_{ApiKey}");
        }

        [Test]
        public void Should_return_correct_server_name_replacement_token()
        {
            _actualServerNameReplacementToken.ShouldBe($"Ods_Sandbox_{ApiKey}");
        }
    }

    public class When_using_sandbox_database_replacement_token_provider_with_blank_api_key
        : TestFixtureBase
    {
        private const string ApiKey = "   ";
        private string _actualReplacementToken;

        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(ApiKey,
                    string.Empty,
                    Array.Empty<int>(),
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null,0));

            _databaseReplacementTokenProvider =
                new SandboxDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _actualReplacementToken = _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
        }

        [Test]
        public void Should_return_correct_value()
        {
            _actualReplacementToken.ShouldBe($"Ods_Sandbox_{ApiKey}");
        }
    }

    public class When_getting_database_name_replacement_token_with_null_api_key : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(null,
                    string.Empty,
                    Array.Empty<int>(),
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null,0));

            _databaseReplacementTokenProvider =
                new SandboxDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }

    public class When_getting_database_name_replacement_token_with_empty_api_key : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(string.Empty,
                    string.Empty,
                    Array.Empty<int>(),
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null,0));

            _databaseReplacementTokenProvider =
                new SandboxDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }

    public class When_getting_server_name_replacement_token_with_null_api_key : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(null,
                    string.Empty,
                    Array.Empty<int>(),
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null,0));

            _databaseReplacementTokenProvider =
                new SandboxDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetServerNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }

    public class When_getting_server_name_replacement_token_with_empty_api_key : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(string.Empty,
                    string.Empty,
                    Array.Empty<int>(),
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null,0));

            _databaseReplacementTokenProvider =
                new SandboxDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetServerNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }
}
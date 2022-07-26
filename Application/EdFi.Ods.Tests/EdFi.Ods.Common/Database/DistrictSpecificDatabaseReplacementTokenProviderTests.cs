// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    public class When_using_district_specific_database_replacement_token_provider_with_one_valid_education_organization
        : TestFixtureBase
    {
        private const int EducationOrganizationId = 777777;
        private string _actualDatabaseNameReplacementToken;
        private string _actualServerNameReplacementToken;

        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(string.Empty,
                    string.Empty,
                    new[] { EducationOrganizationId },
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null,0));

            _databaseReplacementTokenProvider =
                new DistrictSpecificDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _actualDatabaseNameReplacementToken = _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
            _actualServerNameReplacementToken = _databaseReplacementTokenProvider.GetServerNameReplacementToken();
        }

        [Test]
        public void Should_return_correct_database_name_replacement_token()
        {
            _actualDatabaseNameReplacementToken.ShouldBe($"Ods_{EducationOrganizationId}");
        }

        [Test]
        public void Should_return_correct_server_name_replacement_token()
        {
            _actualServerNameReplacementToken.ShouldBe($"Ods_{EducationOrganizationId}");
        }
    }

    public class When_getting_database_name_replacement_token_with_no_api_key_context
        : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(null);

            _databaseReplacementTokenProvider =
                new DistrictSpecificDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
            ActualException.MessageShouldContain("no available education organizations");
        }
    }

    public class When_getting_database_name_replacement_token_with_no_education_organizations
        : TestFixtureBase
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
                new DistrictSpecificDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
            ActualException.MessageShouldContain("no available education organizations");
        }
    }

    public class When_getting_database_name_replacement_token_with_more_than_one_education_organization
        : TestFixtureBase
    {
        private const int EducationOrganizationId = 777777;

        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(string.Empty,
                    string.Empty,
                    new [] { EducationOrganizationId, 123 },
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null,0));

            _databaseReplacementTokenProvider =
                new DistrictSpecificDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
            ActualException.MessageShouldContain("more than one available education organization");
        }
    }

    public class When_getting_server_name_replacement_token_with_no_api_key_context
        : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(null);

            _databaseReplacementTokenProvider =
                new DistrictSpecificDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetServerNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
            ActualException.MessageShouldContain("no available education organizations");
        }
    }

    public class When_getting_server_name_replacement_token_with_no_education_organizations
        : TestFixtureBase
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
                new DistrictSpecificDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetServerNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
            ActualException.MessageShouldContain("no available education organizations");
        }
    }

    public class When_getting_server_name_replacement_token_with_more_than_one_education_organization
        : TestFixtureBase
    {
        private const int EducationOrganizationId = 777777;

        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => apiKeyContextProvider.GetApiKeyContext())
                .Returns(new ApiKeyContext(string.Empty,
                    string.Empty,
                    new [] { EducationOrganizationId, 123 },
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<string>(),
                    string.Empty,
                    null, null,0));

            _databaseReplacementTokenProvider =
                new DistrictSpecificDatabaseReplacementTokenProvider(apiKeyContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetServerNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
            ActualException.MessageShouldContain("more than one available education organization");
        }
    }
}
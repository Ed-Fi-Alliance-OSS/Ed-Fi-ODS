// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Sandbox.Repositories;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

// ReSharper disable InconsistentNaming

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Authorization
{
    [TestFixture]
    public class When_validating_an_access_token
    {
        [SetUp]
        protected void SetUp()
        {
            _accessTokenClientRepo = A.Fake<IAccessTokenClientRepo>();

            _systemUnderTest = new OAuthTokenValidator(_accessTokenClientRepo);
        }

        // Did not use TestFixtureBase here because the Arrange and Act should not be called one
        // time for the fixture, but rather once per test.

        private const string TokenGuid = "5C40B691-50D3-4DF8-B38C-0DB5B3241AFA";

        private IAccessTokenClientRepo _accessTokenClientRepo;
        private OAuthTokenValidator _systemUnderTest;

        private ApiClientDetails _response;

        private string Token { get; set; }

        protected void Act(string token)
        {
            _response = _systemUnderTest.GetClientDetailsForTokenAsync(token).Result;
        }

        [Test]
        public void Given_token_is_invalid_then_return_default_object()
        {
            A.CallTo(() => _accessTokenClientRepo.GetClientForTokenAsync(Guid.Parse(TokenGuid)))
                .Returns(new OAuthTokenClient[0]);

            Act(TokenGuid);

            ApiClientDetailsTests.AssertIsDefaultObject(_response);

            A.CallTo(() => _accessTokenClientRepo.GetClientForTokenAsync(Guid.Parse(TokenGuid)))
                .MustHaveHappened();
        }

        [Test]
        public void Given_token_is_not_Guid_then_return_default_object()
        {
            Act("not a Guid");

            ApiClientDetailsTests.AssertIsDefaultObject(_response);
        }

        [Test]
        public void Given_token_is_valid_then_return_token_client_information()
        {
            const string claimSetName = "a";

            A.CallTo(() => _accessTokenClientRepo.GetClientForTokenAsync(Guid.Parse(TokenGuid)))
                .Returns(new[] {new OAuthTokenClient {ClaimSetName = claimSetName}});

            Act(TokenGuid);

            _response.ClaimSetName.ShouldBe(claimSetName);

            A.CallTo(() => _accessTokenClientRepo.GetClientForTokenAsync(Guid.Parse(TokenGuid)))
                .MustHaveHappened();
        }

        [Test]
        public void Then_delete_expired_tokens()
        {
            Act(TokenGuid);

            A.CallTo(() => _accessTokenClientRepo.DeleteExpiredTokensAsync()).MustHaveHappened();
        }
    }
}

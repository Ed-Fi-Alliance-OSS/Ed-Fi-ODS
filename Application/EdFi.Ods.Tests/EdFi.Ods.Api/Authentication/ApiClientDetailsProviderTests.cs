// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Ods.Api.Authentication;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Authorization;

[TestFixture]
public class ApiClientDetailsProviderTests
{
    [Test]
    public async Task
        When_Admin_database_returns_an_empty_set_of_raw_API_client_token_data_should_return_an_instance_of_ApiClientDetails_with_default_values()
    {
        // Arrange
        var accessTokenClientRepo = A.Fake<IAccessTokenClientRepo>();
        var suppliedToken = Guid.NewGuid();

        A.CallTo(() => accessTokenClientRepo.GetClientForTokenAsync(suppliedToken)).Returns(Array.Empty<OAuthTokenClient>());

        ApiClientDetailsProvider provider = new(accessTokenClientRepo);

        var actual = await provider.GetClientDetailsForTokenAsync(suppliedToken.ToString("n"));

        actual.ShouldSatisfyAllConditions(
            () => actual.ApiKey.ShouldBe(default),
            () => actual.ExpiresUtc.ShouldBe(default),
            () => actual.EducationOrganizationIds.ShouldBeEmpty(),
            () => actual.ApplicationId.ShouldBe(default),
            () => actual.ClaimSetName.ShouldBe(default),
            () => actual.NamespacePrefixes.ShouldBeEmpty(),
            () => actual.Profiles.ShouldBeEmpty(),
            () => actual.IsSandboxClient.ShouldBe(default),
            () => actual.StudentIdentificationSystemDescriptor.ShouldBe(default),
            () => actual.CreatorOwnershipTokenId.ShouldBe(default),
            () => actual.OwnershipTokenIds.ShouldBeEmpty(),
            () => actual.ApiClientId.ShouldBe(default));
    }
    
    [Test]
    public async Task
        When_token_is_not_parseable_as_a_GUID_should_return_an_instance_of_ApiClientDetails_with_default_values()
    {
        // Arrange
        var accessTokenClientRepo = A.Fake<IAccessTokenClientRepo>();
        var suppliedToken = Guid.NewGuid();

        ApiClientDetailsProvider provider = new(accessTokenClientRepo);

        var actual = await provider.GetClientDetailsForTokenAsync("not-a-guid");

        actual.ShouldSatisfyAllConditions(
            () => A.CallTo(() => accessTokenClientRepo.GetClientForTokenAsync(A<Guid>.Ignored)).MustNotHaveHappened(),
            () => actual.ApiKey.ShouldBe(default),
            () => actual.ExpiresUtc.ShouldBe(default),
            () => actual.EducationOrganizationIds.ShouldBeEmpty(),
            () => actual.ApplicationId.ShouldBe(default),
            () => actual.ClaimSetName.ShouldBe(default),
            () => actual.NamespacePrefixes.ShouldBeEmpty(),
            () => actual.Profiles.ShouldBeEmpty(),
            () => actual.IsSandboxClient.ShouldBe(default),
            () => actual.StudentIdentificationSystemDescriptor.ShouldBe(default),
            () => actual.CreatorOwnershipTokenId.ShouldBe(default),
            () => actual.OwnershipTokenIds.ShouldBeEmpty(),
            () => actual.ApiClientId.ShouldBe(default));
    }

    [Test]
    public async Task
        When_Admin_database_returns_a_set_of_raw_API_client_token_data_should_return_the_unflattened_representation_of_the_data_in_the_ApiClientDetails()
    {
        // Arrange
        var accessTokenClientRepo = A.Fake<IAccessTokenClientRepo>();
        var suppliedToken = Guid.NewGuid();
        var suppliedExpirationUtc = DateTime.UtcNow;

        var suppliedOAuthTokenClients = new[]
        {
            CreateOAuthTokenClient(educationOrganizationId: 1000),
            CreateOAuthTokenClient(educationOrganizationId: 1001),
            CreateOAuthTokenClient(namespacePrefix: "uri://namespace.one"),
            CreateOAuthTokenClient(namespacePrefix: "uri://namespace.two"),
            CreateOAuthTokenClient(profileName: "ProfileOne"),
            CreateOAuthTokenClient(profileName: "ProfileTwo"),
            CreateOAuthTokenClient(ownershipTokenId: 50),
            CreateOAuthTokenClient(ownershipTokenId: 51),
        };

        A.CallTo(() => accessTokenClientRepo.GetClientForTokenAsync(suppliedToken)).Returns(suppliedOAuthTokenClients);

        ApiClientDetailsProvider provider = new(accessTokenClientRepo);

        var actual = await provider.GetClientDetailsForTokenAsync(suppliedToken.ToString("n"));

        actual.ShouldSatisfyAllConditions(

            // Property assertions
            () => actual.ApiKey.ShouldBe("theApiKey"),
            () => actual.ExpiresUtc.ShouldBe(suppliedExpirationUtc),
            () => actual.ApplicationId.ShouldBe(default), // Should ApplicationId be removed?
            () => actual.ClaimSetName.ShouldBe("claimSetOne"),
            () => actual.IsSandboxClient.ShouldBe(true),
            () => actual.StudentIdentificationSystemDescriptor.ShouldBe("uri://test.org/system"),
            () => actual.CreatorOwnershipTokenId.ShouldBe(short.MaxValue),
            () => actual.ApiClientId.ShouldBe(7),

            // Collection assertions
            () => actual.EducationOrganizationIds.ToArray().ShouldBeEquivalentTo(
                new[]
                {
                    1000,
                    1001
                }),
            () => actual.NamespacePrefixes.ToArray().ShouldBeEquivalentTo(
                new[]
                {
                    "uri://namespace.one",
                    "uri://namespace.two"
                }),
            () => actual.Profiles.ToArray().ShouldBeEquivalentTo(
                new[]
                {
                    "ProfileOne",
                    "ProfileTwo"
                }),
            () => actual.OwnershipTokenIds.ToArray().ShouldBeEquivalentTo(
                new short?[]
                {
                    50,
                    51
                }));

        OAuthTokenClient CreateOAuthTokenClient(
            int? educationOrganizationId = null,
            string namespacePrefix = null,
            string profileName = null,
            short? ownershipTokenId = null)
        {
            return new OAuthTokenClient
            {
                // Base property values (repeated in every raw record due to joins in query)
                Key = "theApiKey",
                Expiration = suppliedExpirationUtc,
                ClaimSetName = "claimSetOne",
                UseSandbox = true,
                StudentIdentificationSystemDescriptor = "uri://test.org/system",
                CreatorOwnershipTokenId = short.MaxValue,

                // Values for individual collections (some records will be null and others will have values)
                EducationOrganizationId = educationOrganizationId,
                NamespacePrefix = namespacePrefix,
                ProfileName = profileName,
                OwnershipTokenId = ownershipTokenId,
                ApiClientId = 7
            };
        }
    }
}

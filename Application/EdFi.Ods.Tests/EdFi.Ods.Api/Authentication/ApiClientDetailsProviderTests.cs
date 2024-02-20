// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Security.Authentication;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Authorization;

[TestFixture]
public class ApiClientDetailsProviderTests
{
    [Test]
    public Task
        When_Admin_database_returns_an_empty_set_of_raw_API_client_token_data_should_return_aargumentnullexception_ApiClientDetails_reference()
    {
        // Arrange
        var rawApiClientDetailsProvider = A.Fake<IEdFiAdminRawApiClientDetailsProvider>();
        var suppliedToken = Guid.NewGuid();

        A.CallTo(() => rawApiClientDetailsProvider.GetRawClientDetailsDataAsync(suppliedToken))
            .Returns(Task.FromResult(Array.Empty<RawApiClientDetailsDataRow>().ToReadOnlyList()));
        
        ApiClientDetailsProvider provider = new(rawApiClientDetailsProvider);

        var ex  = Assert.ThrowsAsync<ArgumentNullException>(async () =>  await provider.GetApiClientDetailsForTokenAsync(suppliedToken.ToString("N")));

        Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'apiClientRawDataRows')"));

        return Task.CompletedTask;
    }

    [Test]
    public async Task
        When_token_is_not_parseable_as_a_GUID_should_return_a_null_ApiClientDetails_reference()
    {
        // Arrange
        var rawApiClientDetailsProvider = A.Fake<IEdFiAdminRawApiClientDetailsProvider>();
        var suppliedToken = Guid.NewGuid();

        ApiClientDetailsProvider provider = new(rawApiClientDetailsProvider);

        var actual = await provider.GetApiClientDetailsForTokenAsync("not-a-guid");

        actual.ShouldBeNull();

    }

    [Test]
    public async Task
        When_Admin_database_returns_a_set_of_raw_API_client_token_data_should_return_the_unflattened_representation_of_the_data_in_the_ApiClientDetails()
    {
        // Arrange
        var rawApiClientDetailsProvider = A.Fake<IEdFiAdminRawApiClientDetailsProvider>();
        var suppliedToken = Guid.NewGuid();
        string suppliedTokenAsString = suppliedToken.ToString("N");
        var suppliedExpirationUtc = DateTime.UtcNow;

        var suppliedRawData = new[]
        {
            CreateRawApiClientDetailsRow(educationOrganizationId: 1000),
            CreateRawApiClientDetailsRow(educationOrganizationId: 1001),
            CreateRawApiClientDetailsRow(namespacePrefix: "uri://namespace.one"),
            CreateRawApiClientDetailsRow(namespacePrefix: "uri://namespace.two"),
            CreateRawApiClientDetailsRow(profileName: "ProfileOne"),
            CreateRawApiClientDetailsRow(profileName: "ProfileTwo"),
            CreateRawApiClientDetailsRow(ownershipTokenId: 50),
            CreateRawApiClientDetailsRow(ownershipTokenId: 51),
        };

        A.CallTo(() => rawApiClientDetailsProvider.GetRawClientDetailsDataAsync(suppliedToken))
            .Returns(Task.FromResult(suppliedRawData.ToReadOnlyList()));

        ApiClientDetailsProvider provider = new(rawApiClientDetailsProvider);

        var actual = await provider.GetApiClientDetailsForTokenAsync(suppliedTokenAsString);

        actual.ShouldSatisfyAllConditions(

            // Property assertions
            () => actual.ApiKey.ShouldBe("theApiKey"),
            () => actual.ExpiresUtc.ShouldBe(suppliedExpirationUtc),
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
                new short[]
                {
                    50,
                    51
                }));

        RawApiClientDetailsDataRow CreateRawApiClientDetailsRow(
            int? educationOrganizationId = null,
            string namespacePrefix = null,
            string profileName = null,
            short? ownershipTokenId = null)
        {
            return new RawApiClientDetailsDataRow()
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

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;
using static EdFi.Ods.Common.Configuration.SecuritySettings;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Authentication;

[TestFixture]
public class OneRosterJwtAccessTokenFactoryDecoratorTests
{
    private const string EdOrgScope = "255901";
    private const string RosterCoreReadonly = "https://purl.imsglobal.org/spec/or/v1p2/scope/roster-core.readonly";
    private const string RosterDemographicsReadonly = "https://purl.imsglobal.org/spec/or/v1p2/scope/roster-demographics.readonly";

    private IAccessTokenFactory _next;
    private IOneRosterTokenClaimsProvider _claimsProvider;
    private IOptions<SecuritySettings> _securitySettings;
    private ApiClientDetails _apiClientDetails;

    [SetUp]
    public void SetUp()
    {
        _next = A.Fake<IAccessTokenFactory>();
        _claimsProvider = A.Fake<IOneRosterTokenClaimsProvider>();
        _apiClientDetails = new ApiClientDetails { ApiClientId = 1, EducationOrganizationIds = [255901] };

        using var rsa = RSA.Create(2048);

        _securitySettings = A.Fake<IOptions<SecuritySettings>>();

        A.CallTo(() => _securitySettings.Value).Returns(
            new SecuritySettings
            {
                Jwt = new JwtSettings
                {
                    Issuer = "issuer",
                    Audiences = ["audience"],
                    SigningKey = new SigningKeySettings { PrivateKey = rsa.ExportRSAPrivateKeyPem() }
                }
            });
    }

    private async Task<AccessToken> CreateAccessTokenAsync(string requestedScope, string innerScope, params string[] oneRosterScopes)
    {
        A.CallTo(() => _next.CreateAccessTokenAsync(_apiClientDetails, requestedScope))
            .Returns(new AccessToken(Guid.NewGuid().ToString("N"), TimeSpan.FromMinutes(30), innerScope));

        A.CallTo(() => _claimsProvider.CreateClaims(_apiClientDetails, A<AccessToken>._, requestedScope))
            .Returns(new OneRosterTokenClaimsResult([new Claim("jti", "token-id")], oneRosterScopes));

        var decorator = new OneRosterJwtAccessTokenFactoryDecorator(_next, _claimsProvider, _securitySettings);

        return await decorator.CreateAccessTokenAsync(_apiClientDetails, requestedScope);
    }

    [Test]
    public async Task Should_return_the_EdOrg_scope_without_a_trailing_space()
    {
        var token = await CreateAccessTokenAsync(EdOrgScope, EdOrgScope);

        token.Scope.ShouldBe(EdOrgScope);
    }

    [Test]
    public async Task Should_return_the_OneRoster_scopes_separated_by_spaces()
    {
        var token = await CreateAccessTokenAsync(
            $"{RosterCoreReadonly} {RosterDemographicsReadonly}",
            null,
            RosterCoreReadonly,
            RosterDemographicsReadonly);

        token.Scope.ShouldBe($"{RosterCoreReadonly} {RosterDemographicsReadonly}");
    }

    [Test]
    public async Task Should_put_the_EdOrg_scope_before_the_OneRoster_scopes()
    {
        var token = await CreateAccessTokenAsync(EdOrgScope, EdOrgScope, RosterCoreReadonly);

        token.Scope.ShouldBe($"{EdOrgScope} {RosterCoreReadonly}");
    }

    [Test]
    public async Task Should_keep_the_inner_scope_when_no_scope_is_requested()
    {
        var token = await CreateAccessTokenAsync(null, null);

        token.Scope.ShouldBeNull();
    }

    [Test]
    public async Task Should_not_add_whitespace_when_no_OneRoster_scope_matches()
    {
        var token = await CreateAccessTokenAsync(RosterCoreReadonly, null);

        token.Scope.ShouldBeEmpty();
    }

    [Test]
    public async Task Should_return_a_signed_JWT_as_the_token_id()
    {
        var token = await CreateAccessTokenAsync(EdOrgScope, EdOrgScope);

        token.Id.Split('.').Length.ShouldBe(3);
    }
}

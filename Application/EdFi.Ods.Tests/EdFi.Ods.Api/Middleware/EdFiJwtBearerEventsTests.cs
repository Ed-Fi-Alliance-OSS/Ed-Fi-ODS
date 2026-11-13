// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using FakeItEasy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware;

[TestFixture]
public class EdFiJwtBearerEventsTests
{
    private const string Issuer = "issuer";
    private const string Audience = "audience";

    private RSA _signingKey;
    private RSA _otherKey;

    [SetUp]
    public void SetUp()
    {
        _signingKey = RSA.Create(2048);
        _otherKey = RSA.Create(2048);
    }

    [TearDown]
    public void TearDown()
    {
        _signingKey.Dispose();
        _otherKey.Dispose();
    }

    // Authenticates the header with the real JWT bearer handler, configured as the ODS/API does in JWT mode
    private async Task<AuthenticateResult> AuthenticateAsync(
        string authorizationHeader,
        string requestTenantIdentifier = null,
        bool registerTenantContextProvider = false)
    {
        var options = new JwtBearerOptions
        {
            Events = new EdFiJwtBearerEvents(),
            TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new RsaSecurityKey(_signingKey),
                ValidIssuer = Issuer,
                ValidAudience = Audience,
            }
        };

        var optionsMonitor = A.Fake<IOptionsMonitor<JwtBearerOptions>>();
        A.CallTo(() => optionsMonitor.Get(A<string>._)).Returns(options);

        var handler = new JwtBearerHandler(optionsMonitor, NullLoggerFactory.Instance, UrlEncoder.Default);

        var httpContext = new DefaultHttpContext();

        // The tenant identification middleware sets the request's tenant before authentication (multi-tenant only)
        if (requestTenantIdentifier != null || registerTenantContextProvider)
        {
            var tenantContextProvider = A.Fake<IContextProvider<TenantConfiguration>>();

            A.CallTo(() => tenantContextProvider.Get())
                .Returns(
                    requestTenantIdentifier == null
                        ? null
                        : new TenantConfiguration { TenantIdentifier = requestTenantIdentifier });

            httpContext.RequestServices = new ServiceCollection()
                .AddSingleton(tenantContextProvider)
                .BuildServiceProvider();
        }

        if (authorizationHeader != null)
        {
            httpContext.Request.Headers.Authorization = authorizationHeader;
        }

        await handler.InitializeAsync(
            new AuthenticationScheme(JwtBearerDefaults.AuthenticationScheme, null, typeof(JwtBearerHandler)),
            httpContext);

        return await handler.AuthenticateAsync();
    }

    private string CreateJwt(RSA key, DateTime expires, string tokenTenantIdentifier = null)
    {
        var subject = new ClaimsIdentity([new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))]);

        if (tokenTenantIdentifier != null)
        {
            subject.AddClaim(new Claim(OneRosterTokenClaimsProvider.TenantIdClaimType, tokenTenantIdentifier));
        }

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = Issuer,
            Audience = Audience,
            Subject = subject,
            NotBefore = expires.AddHours(-1),
            Expires = expires,
            SigningCredentials = new SigningCredentials(new RsaSecurityKey(key), SecurityAlgorithms.RsaSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(tokenHandler.CreateJwtSecurityToken(descriptor));
    }

    [Test]
    public async Task Should_return_no_result_when_the_Authorization_header_is_missing()
    {
        var result = await AuthenticateAsync(null);

        result.None.ShouldBeTrue();
    }

    [Test]
    public async Task Should_fail_with_unknown_scheme_when_the_scheme_is_not_Bearer()
    {
        var result = await AuthenticateAsync("Basic am9obmRvZToxMjM=");

        (result.Failure?.Message).ShouldBe(AuthenticationFailureMessages.UnknownAuthorizationHeaderScheme);
    }

    [Test]
    public async Task Should_fail_with_missing_token_value_when_the_Bearer_value_is_empty()
    {
        var result = await AuthenticateAsync("Bearer");

        (result.Failure?.Message).ShouldBe(AuthenticationFailureMessages.MissingAuthorizationHeaderBearerTokenValue);
    }

    [Test]
    public async Task Should_fail_with_invalid_token_when_the_token_is_not_a_JWT()
    {
        var result = await AuthenticateAsync("Bearer d49f5c606f03406db2e01b1c82d2997f");

        (result.Failure?.Message).ShouldBe(AuthenticationFailureMessages.InvalidToken);
    }

    [Test]
    public async Task Should_fail_with_invalid_token_when_the_signature_is_not_valid()
    {
        var result = await AuthenticateAsync($"Bearer {CreateJwt(_otherKey, DateTime.UtcNow.AddMinutes(30))}");

        (result.Failure?.Message).ShouldBe(AuthenticationFailureMessages.InvalidToken);
    }

    [Test]
    public async Task Should_fail_with_invalid_token_when_the_token_is_expired()
    {
        var result = await AuthenticateAsync($"Bearer {CreateJwt(_signingKey, DateTime.UtcNow.AddHours(-1))}");

        (result.Failure?.Message).ShouldBe(AuthenticationFailureMessages.InvalidToken);
    }

    [Test]
    public async Task Should_succeed_with_a_valid_token()
    {
        var result = await AuthenticateAsync($"Bearer {CreateJwt(_signingKey, DateTime.UtcNow.AddMinutes(30))}");

        result.Succeeded.ShouldBeTrue();
        result.Principal.HasClaim(c => c.Type == JwtRegisteredClaimNames.Jti).ShouldBeTrue();
    }

    [Test]
    public async Task Should_fail_with_invalid_token_when_the_token_was_issued_for_another_tenant()
    {
        var token = CreateJwt(_signingKey, DateTime.UtcNow.AddMinutes(30), tokenTenantIdentifier: "TenantA");

        var result = await AuthenticateAsync($"Bearer {token}", requestTenantIdentifier: "TenantB");

        result.Succeeded.ShouldBeFalse();
        (result.Failure?.Message).ShouldBe(AuthenticationFailureMessages.InvalidToken);
    }

    [Test]
    public async Task Should_succeed_when_the_token_was_issued_for_the_requested_tenant_regardless_of_case()
    {
        var token = CreateJwt(_signingKey, DateTime.UtcNow.AddMinutes(30), tokenTenantIdentifier: "TenantA");

        var result = await AuthenticateAsync($"Bearer {token}", requestTenantIdentifier: "tenanta");

        result.Succeeded.ShouldBeTrue();
    }

    [Test]
    public async Task Should_succeed_when_the_token_has_no_tenant_claim_in_a_multi_tenant_request()
    {
        // The token lookup by jti (in the requested tenant's Admin database) still applies to these tokens
        var token = CreateJwt(_signingKey, DateTime.UtcNow.AddMinutes(30));

        var result = await AuthenticateAsync($"Bearer {token}", requestTenantIdentifier: "TenantB");

        result.Succeeded.ShouldBeTrue();
    }

    [Test]
    public async Task Should_succeed_when_the_token_has_a_tenant_claim_in_a_single_tenant_request()
    {
        var token = CreateJwt(_signingKey, DateTime.UtcNow.AddMinutes(30), tokenTenantIdentifier: "TenantA");

        var result = await AuthenticateAsync($"Bearer {token}");

        result.Succeeded.ShouldBeTrue();
    }

    [Test]
    public async Task Should_succeed_when_the_token_has_a_tenant_claim_and_no_tenant_is_set_for_the_request()
    {
        // The tenant context provider is always registered; it has no tenant when multi-tenancy is not in use
        var token = CreateJwt(_signingKey, DateTime.UtcNow.AddMinutes(30), tokenTenantIdentifier: "TenantA");

        var result = await AuthenticateAsync($"Bearer {token}", registerTenantContextProvider: true);

        result.Succeeded.ShouldBeTrue();
    }
}

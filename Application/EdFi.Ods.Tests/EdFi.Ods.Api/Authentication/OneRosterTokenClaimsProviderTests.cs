// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.Json;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Common.Security;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Claims;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using NUnit.Framework;
using Shouldly;
using static EdFi.Ods.Common.Configuration.SecuritySettings;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Authentication;

[TestFixture]
public class OneRosterTokenClaimsProviderTests
{
    private IClaimSetClaimsProvider _claimSetClaimsProvider;
    private IOptions<SecuritySettings> _securitySettings;
    private IFeatureManager _featureManager;
    private IUsersContextFactory _usersContextFactory;
    private IContextProvider<TenantConfiguration> _tenantConfigProvider;

    private SecuritySettings _settings;

    [SetUp]
    public void SetUp()
    {
        _claimSetClaimsProvider = A.Fake<IClaimSetClaimsProvider>();
        _featureManager = A.Fake<IFeatureManager>();
        _usersContextFactory = A.Fake<IUsersContextFactory>();
        _tenantConfigProvider = A.Fake<IContextProvider<TenantConfiguration>>();

        _settings = new SecuritySettings
        {
            Jwt = new JwtSettings
            {
                SigningKey = new SigningKeySettings
                {
                    // Use a valid test key for your environment
                    PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
MIIBOgIBAAJBALeQw...
-----END RSA PRIVATE KEY-----"
                },
                Audiences = ["aud1", "aud2"],
                Issuer = "issuer"
            }
        };
        _securitySettings = A.Fake<IOptions<SecuritySettings>>();
        A.CallTo(() => _securitySettings.Value).Returns(_settings);
    }

    private OneRosterTokenClaimsProvider CreateProvider()
    {
        return new OneRosterTokenClaimsProvider(
            _claimSetClaimsProvider,
            _securitySettings,
            _featureManager,
            _usersContextFactory,
            _tenantConfigProvider);
    }

    [Test]
    public void Should_add_audiences_and_educationOrganizationIds_claims()
    {
        var apiClientDetails = new ApiClientDetails
        {
            ApiClientId = 1,
            EducationOrganizationIds = [100, 200],
            ClaimSetName = "TestClaimSet"
        };

        var claimSetResourceClaimMetadata = new ClaimSetResourceClaimMetadata("Ed-Fi Sandbox", []);

        // Setup UsersContext
        var usersContext = A.Fake<IUsersContext>(); 

        // Create fake DbSets
        var fakeApiClientOdsInstances = A.Fake<DbSet<ApiClientOdsInstance>>();
        var fakeOdsInstanceContexts = A.Fake<DbSet<OdsInstanceContext>>();
        var fakeApiClients = A.Fake<DbSet<ApiClient>>();

        // Setup the queryable behavior
        A.CallTo(() => fakeApiClientOdsInstances.AsQueryable())
            .Returns(new List<ApiClientOdsInstance>
            {
                new() {
                    ApiClient = new ApiClient { ApiClientId = 1 },
                    OdsInstance = new OdsInstance { OdsInstanceId = 10 }
                }
            }.AsQueryable());

        A.CallTo(() => fakeOdsInstanceContexts.AsQueryable())
            .Returns(new List<OdsInstanceContext>
            {
                new() {
                    OdsInstance = new OdsInstance { OdsInstanceId = 10 },
                    ContextKey = "key",
                    ContextValue = "value"
                }
            }.AsQueryable());
        A.CallTo(() => fakeApiClients.AsQueryable()).Returns(new List<ApiClient>
        {
            new() { ApiClientId = 1 }
        }.AsQueryable());

        // Setup the context properties
        A.CallTo(() => usersContext.ApiClientOdsInstances).Returns(fakeApiClientOdsInstances);
        A.CallTo(() => usersContext.OdsInstanceContexts).Returns(fakeOdsInstanceContexts);
        A.CallTo(() => usersContext.ApiClients).Returns(fakeApiClients);

        A.CallTo(() => _usersContextFactory.CreateContext()).Returns(usersContext);

        A.CallTo(() => _claimSetClaimsProvider.GetClaims("Ed-Fi Sandbox")).Returns([claimSetResourceClaimMetadata]);
        A.CallTo(() => _featureManager.IsEnabledAsync(A<string>._)).Returns(false);

        var provider = CreateProvider();
        var result = provider.CreateClaims(apiClientDetails, new AccessToken("id", TimeSpan.FromMinutes(5), "scope"), null);

        result.ShouldNotBeNull();
        result.Claims.Count(c => c.Type == JwtRegisteredClaimNames.Aud && c.Value == "aud1").ShouldBe(1);
        result.Claims.Count(c => c.Type == "educationOrganizationId" && c.Value == "100").ShouldBe(1);
        result.Claims.Any(c => c.Type == "odsInstances").ShouldBeTrue();
    }

    [Test]
    public void Should_add_tenantId_claim_when_multiTenancy_enabled()
    {
        var claimSetResourceClaimMetadata = new ClaimSetResourceClaimMetadata("Ed-Fi Sandbox", []);

        var apiClientDetails = new ApiClientDetails { ApiClientId = 1, ClaimSetName = "TestClaimSet" };

        var usersContext = A.Fake<IUsersContext>();
        A.CallTo(() => usersContext.ApiClientOdsInstances.AsQueryable()).Returns(new List<ApiClientOdsInstance>().AsQueryable());
        A.CallTo(() => usersContext.OdsInstanceContexts.AsQueryable()).Returns(new List<OdsInstanceContext>().AsQueryable());
        A.CallTo(() => _usersContextFactory.CreateContext()).Returns(usersContext);

        A.CallTo(() => _claimSetClaimsProvider.GetClaims("Ed-Fi Sandbox")).Returns([claimSetResourceClaimMetadata]);
        A.CallTo(() => _featureManager.IsEnabledAsync(A<string>._)).Returns(true);
        A.CallTo(() => _tenantConfigProvider.Get()).Returns(new TenantConfiguration { TenantIdentifier = "tenant1" });

        var provider = CreateProvider();
        var result = provider.CreateClaims(apiClientDetails, new AccessToken("id", TimeSpan.FromMinutes(5), "scope"), null);

        result.Claims.Any(c => c.Type == "tenantId" && c.Value == "tenant1").ShouldBeTrue();
    }

    [Test]
    public void Should_add_correct_odsInstances_claim_with_contexts()
    {
        var apiClientDetails = new ApiClientDetails
        {
            ApiClientId = 1,
            EducationOrganizationIds = [100],
            ClaimSetName = "TestClaimSet"
        };

        // Setup UsersContext with two OdsInstances, each with a context
        var usersContext = A.Fake<IUsersContext>();
        A.CallTo(() => usersContext.ApiClientOdsInstances.AsQueryable())
            .Returns(new List<ApiClientOdsInstance>
            {
            new() {
                ApiClient = new ApiClient { ApiClientId = 1 },
                OdsInstance = new OdsInstance { OdsInstanceId = 10 }
            },
            new() {
                ApiClient = new ApiClient { ApiClientId = 1 },
                OdsInstance = new OdsInstance { OdsInstanceId = 20 }
            }
            }.AsQueryable());

        A.CallTo(() => usersContext.OdsInstanceContexts.AsQueryable())
            .Returns(new List<OdsInstanceContext>
            {
            new() {
                OdsInstance = new OdsInstance { OdsInstanceId = 10 },
                ContextKey = "key1",
                ContextValue = "value1"
            },
            new() {
                OdsInstance = new OdsInstance { OdsInstanceId = 20 },
                ContextKey = "key2",
                ContextValue = "value2"
            }
            }.AsQueryable());

        A.CallTo(() => _usersContextFactory.CreateContext()).Returns(usersContext);

        var claimSetResourceClaimMetadata = new ClaimSetResourceClaimMetadata("Ed-Fi Sandbox", []);
        A.CallTo(() => _claimSetClaimsProvider.GetClaims("Ed-Fi Sandbox")).Returns([claimSetResourceClaimMetadata]);
        A.CallTo(() => _featureManager.IsEnabledAsync(A<string>._)).Returns(false);

        var provider = CreateProvider();
        var result = provider.CreateClaims(apiClientDetails, new AccessToken("id", TimeSpan.FromMinutes(5), "scope"), null);

        var odsInstancesClaim = result.Claims.FirstOrDefault(c => c.Type == "odsInstances");
        odsInstancesClaim.ShouldNotBeNull();

        // Deserialize and assert structure
        var json = odsInstancesClaim.Value;
        json.ShouldContain("OdsInstances");

        var doc = System.Text.Json.JsonDocument.Parse(json);
        var root = doc.RootElement;
        var instances = root.GetProperty("OdsInstances");
        instances.GetArrayLength().ShouldBe(2);

        var instance10 = instances.EnumerateArray().FirstOrDefault(e => e.GetProperty("OdsInstanceId").GetInt32() == 10);
        instance10.ValueKind.ShouldNotBe(JsonValueKind.Undefined);
        var context10 = instance10.GetProperty("OdsInstanceContext");
        context10.GetProperty("ContextKey").GetString().ShouldBe("key1");
        context10.GetProperty("ContextValue").GetString().ShouldBe("value1");

        var instance20 = instances.EnumerateArray().FirstOrDefault(e => e.GetProperty("OdsInstanceId").GetInt32() == 20);
        instance20.ValueKind.ShouldNotBe(JsonValueKind.Undefined);
        var context20 = instance20.GetProperty("OdsInstanceContext");
        context20.GetProperty("ContextKey").GetString().ShouldBe("key2");
        context20.GetProperty("ContextValue").GetString().ShouldBe("value2");
    }


    [Test]
    public void Should_add_OneRoster_scope_claims_when_present()
    {
        var apiClientDetails = new ApiClientDetails { ApiClientId = 1, ClaimSetName = "TestClaimSet" };

        var usersContext = A.Fake<IUsersContext>();
        A.CallTo(() => usersContext.ApiClientOdsInstances.AsQueryable()).Returns(new List<ApiClientOdsInstance>().AsQueryable());
        A.CallTo(() => usersContext.OdsInstanceContexts.AsQueryable()).Returns(new List<OdsInstanceContext>().AsQueryable());
        A.CallTo(() => _usersContextFactory.CreateContext()).Returns(usersContext);

        A.CallTo(() => _featureManager.IsEnabledAsync(A<string>._)).Returns(false);

        A.CallTo(() => _claimSetClaimsProvider.GetClaims(A<string>._))
            .Returns(
            [
                new(OneRosterScopePrefix + "students",
                    [
                        new ResourceAction { Name = "http://ed-fi.org/odsapi/actions/read" }
                    ])
            ]);
        var studentsReadOnlyScope = OneRosterScopePrefix + "students.readonly";

        var provider = CreateProvider();
        var result = provider.CreateClaims(apiClientDetails, new AccessToken("id", TimeSpan.FromMinutes(5), "scope"), studentsReadOnlyScope);

        result.Claims.Any(c => c.Type == "scope" && c.Value == studentsReadOnlyScope).ShouldBeTrue();
        result.OneRosterScopes.ShouldContain(studentsReadOnlyScope);
    }
}

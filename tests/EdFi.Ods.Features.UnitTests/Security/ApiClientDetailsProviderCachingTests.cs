// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Common.Security;
using EdFi.Ods.Api.Container.Modules;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Features.Container.Modules;
using FakeItEasy;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Features.UnitTests.Security;

/// <summary>
/// Resolves <see cref="IApiClientDetailsProvider" /> from the real module registrations to verify which of its
/// methods go through the "cache-api-client-details" interceptor.
/// </summary>
[TestFixture]
public class ApiClientDetailsProviderCachingTests
{
    private const string ApiKey = "the-key";

    private IEdFiAdminRawApiClientDetailsProvider _fakeRawProvider = null!;
    private IContextProvider<TenantConfiguration> _fakeTenantContextProvider = null!;
    private IContainer _container = null!;

    [TearDown]
    public void Teardown()
    {
        _container?.Dispose();
    }

    [TestCase(false, TestName = "Key lookup reads a changed secret on the next call (single-tenant)")]
    [TestCase(true, TestName = "Key lookup reads a changed secret on the next call (multi-tenant)")]
    public async Task Key_lookup_is_not_cached(bool isMultiTenant)
    {
        // Arrange
        var provider = CreateProvider(isMultiTenant);

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(ApiKey))
            .ReturnsNextFromSequence(Rows("old-secret"), Rows("new-secret"));

        // Act
        var beforeRotation = await provider.GetApiClientDetailsForKeyAsync(ApiKey);
        var afterRotation = await provider.GetApiClientDetailsForKeyAsync(ApiKey);

        // Assert
        beforeRotation.Secret.ShouldBe("old-secret");
        afterRotation.Secret.ShouldBe("new-secret");

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(ApiKey))
            .MustHaveHappenedTwiceExactly();
    }

    [TestCase(false, TestName = "Key lookup finds a key created after a failed lookup (single-tenant)")]
    [TestCase(true, TestName = "Key lookup finds a key created after a failed lookup (multi-tenant)")]
    public async Task Key_lookup_does_not_cache_a_missing_key(bool isMultiTenant)
    {
        // Arrange
        var provider = CreateProvider(isMultiTenant);

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(ApiKey))
            .ReturnsNextFromSequence(Array.Empty<RawApiClientDetailsDataRow>(), Rows("new-secret"));

        // Act
        var beforeCreation = await provider.GetApiClientDetailsForKeyAsync(ApiKey);
        var afterCreation = await provider.GetApiClientDetailsForKeyAsync(ApiKey);

        // Assert
        beforeCreation.ShouldBeNull();
        afterCreation.ShouldNotBeNull();

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(ApiKey))
            .MustHaveHappenedTwiceExactly();
    }

    [TestCase(false, TestName = "Token lookup is still cached (single-tenant)")]
    [TestCase(true, TestName = "Token lookup is still cached (multi-tenant)")]
    public async Task Token_lookup_is_still_cached(bool isMultiTenant)
    {
        // Arrange
        var provider = CreateProvider(isMultiTenant);
        var token = Guid.NewGuid();

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(token))
            .Returns(Rows("secret"));

        // Act
        var first = await provider.GetApiClientDetailsForTokenAsync(token.ToString());
        var second = await provider.GetApiClientDetailsForTokenAsync(token.ToString());

        // Assert
        second.ShouldBeSameAs(first);

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(token))
            .MustHaveHappenedOnceExactly();

        if (isMultiTenant)
        {
            // Proves the tenant-aware interceptor from MultiTenancyModule is the one in use
            A.CallTo(() => _fakeTenantContextProvider.Get()).MustHaveHappened();
        }
    }

    private IApiClientDetailsProvider CreateProvider(bool isMultiTenant)
    {
        _fakeRawProvider = A.Fake<IEdFiAdminRawApiClientDetailsProvider>();

        var builder = new ContainerBuilder();

        builder.RegisterModule(new ApplicationModule(Options.Create(new SecuritySettings())));

        if (isMultiTenant)
        {
            var fakeFeatureManager = A.Fake<IFeatureManager>();

            A.CallTo(() => fakeFeatureManager.IsEnabledAsync(ApiFeature.MultiTenancy.Value))
                .Returns(true);

            builder.RegisterModule(new MultiTenancyModule(fakeFeatureManager));

            _fakeTenantContextProvider = A.Fake<IContextProvider<TenantConfiguration>>();

            A.CallTo(() => _fakeTenantContextProvider.Get())
                .Returns(new TenantConfiguration { TenantIdentifier = "tenant1" });

            builder.RegisterInstance(_fakeTenantContextProvider);
        }

        builder.RegisterInstance(new ApiSettings());
        builder.RegisterInstance(_fakeRawProvider);

        _container = builder.Build();

        return _container.Resolve<IApiClientDetailsProvider>();
    }

    private static IReadOnlyList<RawApiClientDetailsDataRow> Rows(string secret)
    {
        return
        [
            new RawApiClientDetailsDataRow
            {
                ApiClientId = 1,
                Key = ApiKey,
                Secret = secret,
                SecretIsHashed = false,
                ClaimSetName = "SIS Vendor",
                Expiration = DateTime.UtcNow.AddMinutes(30)
            }
        ];
    }
}

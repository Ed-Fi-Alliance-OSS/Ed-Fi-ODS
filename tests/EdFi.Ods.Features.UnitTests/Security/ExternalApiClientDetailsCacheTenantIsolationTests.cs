// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using Autofac;
using EdFi.Common.Security;
using EdFi.Ods.Api.Container.Modules;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Features.Container.Modules;
using EdFi.Ods.Features.ExternalCache;
using EdFi.Ods.Features.Redis;
using FakeItEasy;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Features.UnitTests.Security;

/// <summary>
/// Resolves <see cref="IApiClientDetailsProvider" /> from the real module registrations with the external (Redis)
/// API client details cache enabled, replacing only Redis with an in-memory distributed cache.
/// </summary>
[TestFixture]
public class ExternalApiClientDetailsCacheTenantIsolationTests
{
    private const string TenantA = "tenantA";
    private const string TenantB = "tenantB";

    private IEdFiAdminRawApiClientDetailsProvider _fakeRawProvider = null!;
    private TenantConfiguration? _currentTenant;
    private InMemoryDistributedCache _distributedCache = null!;
    private IContainer? _container;

    [TearDown]
    public void Teardown()
    {
        _container?.Dispose();
        _container = null;
        _currentTenant = null;
    }

    [Test]
    public async Task Token_cached_for_one_tenant_is_not_returned_for_another_tenant()
    {
        // Arrange
        var provider = CreateProvider(isMultiTenant: true);
        var token = Guid.NewGuid();

        // The token exists only in tenant A's Admin database
        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(token))
            .ReturnsNextFromSequence(Rows(), Array.Empty<RawApiClientDetailsDataRow>());

        // Act
        _currentTenant = new TenantConfiguration { TenantIdentifier = TenantA };
        var tenantADetails = await provider.GetApiClientDetailsForTokenAsync(token.ToString());

        _currentTenant = new TenantConfiguration { TenantIdentifier = TenantB };
        var tenantBDetails = await provider.GetApiClientDetailsForTokenAsync(token.ToString());

        // Assert
        tenantADetails.ShouldNotBeNull();
        tenantBDetails.ShouldBeNull();

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(token))
            .MustHaveHappenedTwiceExactly();
    }

    [TestCase(false, TestName = "Token cached by the external cache is returned for the next request (single-tenant)")]
    [TestCase(true, TestName = "Token cached by the external cache is returned for the next request (multi-tenant)")]
    public async Task Token_cached_for_a_tenant_is_returned_for_the_same_tenant(bool isMultiTenant)
    {
        // Arrange
        var provider = CreateProvider(isMultiTenant);
        var token = Guid.NewGuid();

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(token))
            .Returns(Rows());

        _currentTenant = new TenantConfiguration { TenantIdentifier = TenantA };

        // Act
        var first = await provider.GetApiClientDetailsForTokenAsync(token.ToString());
        var second = await provider.GetApiClientDetailsForTokenAsync(token.ToString());

        // Assert
        first.ShouldNotBeNull();
        second.ShouldNotBeNull();
        second.ApiKey.ShouldBe(first.ApiKey);

        // The in-process cache sits behind the external cache, so only the external cache hit proves the key is stable
        _distributedCache.HitCount.ShouldBe(1);
        _distributedCache.Keys.ShouldHaveSingleItem();

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(token))
            .MustHaveHappenedOnceExactly();
    }

    [TestCase(false, TestName = "External cache key holds a hash of the token, not the token (single-tenant)")]
    [TestCase(true, TestName = "External cache key holds a hash of the token, not the token (multi-tenant)")]
    public async Task External_cache_key_does_not_contain_the_token(bool isMultiTenant)
    {
        // Arrange
        var provider = CreateProvider(isMultiTenant);
        var token = Guid.NewGuid();

        A.CallTo(() => _fakeRawProvider.GetRawClientDetailsDataAsync(token))
            .Returns(Rows());

        _currentTenant = new TenantConfiguration { TenantIdentifier = TenantA };

        // Act
        await provider.GetApiClientDetailsForTokenAsync(token.ToString());

        // Assert
        var cacheKey = _distributedCache.Keys.ShouldHaveSingleItem();

        cacheKey.ShouldNotContain(token.ToString(), Case.Insensitive);
        cacheKey.ShouldNotContain(token.ToString("N"), Case.Insensitive);

        var expectedPrefix = isMultiTenant
            ? $"{ApiClientDetailsCacheKeyProvider.CacheKeyPrefix}{TenantA}."
            : ApiClientDetailsCacheKeyProvider.CacheKeyPrefix;

        cacheKey.ShouldStartWith(expectedPrefix);
        cacheKey.Substring(expectedPrefix.Length).ShouldMatch("^[0-9A-F]{64}$");
    }

    [TestCase(false, null, TestName = "Multi-tenant cache key requires a tenant in context (no tenant configuration)")]
    [TestCase(true, null, TestName = "Multi-tenant cache key requires a tenant in context (null tenant identifier)")]
    [TestCase(true, "", TestName = "Multi-tenant cache key requires a tenant in context (empty tenant identifier)")]
    public void Multi_tenant_cache_key_requires_a_tenant_in_context(bool hasTenantConfiguration, string? tenantIdentifier)
    {
        // Arrange
        var fakeTenantContextProvider = A.Fake<IContextProvider<TenantConfiguration>>();

        A.CallTo(() => fakeTenantContextProvider.Get())
            .Returns(hasTenantConfiguration ? new TenantConfiguration { TenantIdentifier = tenantIdentifier! } : null!);

        var cacheKeyProvider = new MultiTenantApiClientDetailsCacheKeyProvider(fakeTenantContextProvider);

        // Act / Assert
        Should.Throw<CachingInterceptorCacheKeyGenerationException>(
            () => cacheKeyProvider.GetCacheKey(Guid.NewGuid().ToString()));
    }

    private IApiClientDetailsProvider CreateProvider(bool isMultiTenant)
    {
        _fakeRawProvider = A.Fake<IEdFiAdminRawApiClientDetailsProvider>();
        _distributedCache = new InMemoryDistributedCache();

        var apiSettings = new ApiSettings();
        apiSettings.Caching.ExternalCacheProvider = "Redis";
        apiSettings.Caching.ApiClientDetails.UseExternalCache = true;
        apiSettings.Services.Redis.Configuration = "localhost:6379";

        var fakeFeatureManager = A.Fake<IFeatureManager>();

        A.CallTo(() => fakeFeatureManager.IsEnabledAsync(ApiFeature.MultiTenancy.Value))
            .Returns(isMultiTenant);

        var fakeTenantContextProvider = A.Fake<IContextProvider<TenantConfiguration>>();

        A.CallTo(() => fakeTenantContextProvider.Get())
            .ReturnsLazily(() => _currentTenant!);

        var builder = new ContainerBuilder();

        builder.RegisterModule(new ApplicationModule(Options.Create(new SecuritySettings())));
        builder.RegisterModule(new MultiTenancyModule(fakeFeatureManager));
        builder.RegisterModule(new OverrideRedisExternalCacheModule(fakeFeatureManager, apiSettings));

        // Registered after the modules so that they replace Redis and the tenant context
        builder.RegisterInstance<IDistributedCache>(_distributedCache);
        builder.RegisterInstance(fakeTenantContextProvider);

        builder.RegisterInstance(apiSettings);
        builder.RegisterInstance(_fakeRawProvider);

        _container = builder.Build();

        return _container.Resolve<IApiClientDetailsProvider>();
    }

    private static IReadOnlyList<RawApiClientDetailsDataRow> Rows()
    {
        return
        [
            new RawApiClientDetailsDataRow
            {
                ApiClientId = 1,
                Key = "the-key",
                Secret = "secret",
                SecretIsHashed = false,
                ClaimSetName = "SIS Vendor",
                Expiration = DateTime.UtcNow.AddMinutes(30)
            }
        ];
    }

    private sealed class InMemoryDistributedCache : IDistributedCache
    {
        private readonly ConcurrentDictionary<string, byte[]> _entries = new();

        public ICollection<string> Keys => _entries.Keys;

        public int HitCount { get; private set; }

        public byte[]? Get(string key)
        {
            if (!_entries.TryGetValue(key, out var value))
            {
                return null;
            }

            HitCount++;
            return value;
        }

        public Task<byte[]?> GetAsync(string key, CancellationToken token = default) => Task.FromResult(Get(key));

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options) => _entries[key] = value;

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            Set(key, value, options);
            return Task.CompletedTask;
        }

        public void Refresh(string key) { }

        public Task RefreshAsync(string key, CancellationToken token = default) => Task.CompletedTask;

        public void Remove(string key) => _entries.TryRemove(key, out _);

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            Remove(key);
            return Task.CompletedTask;
        }
    }
}

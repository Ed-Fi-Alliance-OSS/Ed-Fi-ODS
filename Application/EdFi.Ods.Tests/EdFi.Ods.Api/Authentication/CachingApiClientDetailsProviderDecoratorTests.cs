// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Authentication;
using EdFi.Ods.Common.Caching;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Authorization
{
    [TestFixture]
    public class CachingOAuthTokenValidatorDecoratorTests
    {
        [Test]
        public async Task When_requesting_API_client_details_that_are_already_cached_for_a_token_should_return_the_cached_instance()
        {
            // Arrange
            var suppliedTokenString = Guid.NewGuid().ToString("n");
            var suppliedApiClientDetails = new ApiClientDetails();
            
            var apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();

            var cacheKeyProvider = A.Fake<IApiClientDetailsCacheKeyProvider>();
            A.CallTo(() => cacheKeyProvider.GetCacheKey(suppliedTokenString)).Returns("theCacheKey");

            var cacheProvider = A.Fake<ICacheProvider>();
            object outObject;

            A.CallTo(() => cacheProvider.TryGetCachedObject("theCacheKey", out outObject))
                .Returns(true)
                .AssignsOutAndRefParameters(suppliedApiClientDetails);

            // Act
            CachingApiClientDetailsProviderDecorator decorator = new(apiClientDetailsProvider, cacheProvider, cacheKeyProvider);
            var actualApiClientDetails = await decorator.GetClientDetailsForTokenAsync(suppliedTokenString);

            // Assert
            decorator.ShouldSatisfyAllConditions(
                () => actualApiClientDetails.ShouldBeSameAs(suppliedApiClientDetails, "Cached item was not returned."),
                
                // Should not call through to underlying store
                () => A.CallTo(() => apiClientDetailsProvider.GetClientDetailsForTokenAsync(suppliedTokenString))
                    .MustNotHaveHappened(),

                // Should not try to insert a new cache entry
                () => A.CallTo(() => cacheProvider.Insert(A<string>.Ignored, A<object>.Ignored, A<DateTime>.Ignored, A<TimeSpan>.Ignored))
                    .MustNotHaveHappened()
            );
        }

        [Test]
        public async Task When_requesting_API_client_details_that_are_NOT_already_cached_for_a_token_retrieve_and_cache_the_details()
        {
            // Arrange
            var suppliedTokenString = Guid.NewGuid().ToString("n");
            var suppliedApiClientDetails = new ApiClientDetails() { ExpiresUtc = DateTime.UtcNow.AddMinutes(30) };
            
            var cacheKeyProvider = A.Fake<IApiClientDetailsCacheKeyProvider>();
            A.CallTo(() => cacheKeyProvider.GetCacheKey(suppliedTokenString)).Returns("theCacheKey");

            var cacheProvider = A.Fake<ICacheProvider>();
            object outObject;

            A.CallTo(() => cacheProvider.TryGetCachedObject("theCacheKey", out outObject))
                .Returns(false);

            var apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();
            A.CallTo(() => apiClientDetailsProvider.GetClientDetailsForTokenAsync(suppliedTokenString))
                .Returns(suppliedApiClientDetails);

            // Act
            CachingApiClientDetailsProviderDecorator decorator = new(apiClientDetailsProvider, cacheProvider, cacheKeyProvider);
            var actualApiClientDetails = await decorator.GetClientDetailsForTokenAsync(suppliedTokenString);

            // Assert
            decorator.ShouldSatisfyAllConditions(
                () => actualApiClientDetails.ShouldBeSameAs(suppliedApiClientDetails),
                
                // Should call through to underlying store
                () => A.CallTo(() => apiClientDetailsProvider.GetClientDetailsForTokenAsync(suppliedTokenString))
                    .MustHaveHappened(),

                // Should insert a new cache entry with expiration date 15 minutes after the expiration of the token
                () => A.CallTo(() => cacheProvider.Insert("theCacheKey", suppliedApiClientDetails, 
                        A<DateTime>.That.Matches(expirationUtc => expirationUtc > suppliedApiClientDetails.ExpiresUtc.AddMinutes(14) && expirationUtc < suppliedApiClientDetails.ExpiresUtc.AddMinutes(16)), 
                            TimeSpan.Zero))
                    .MustHaveHappened()
            );
        }
   }
}
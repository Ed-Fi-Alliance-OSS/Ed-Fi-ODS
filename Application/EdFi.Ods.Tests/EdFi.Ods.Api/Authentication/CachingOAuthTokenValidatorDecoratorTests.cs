// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Authentication;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Authorization
{
    [TestFixture]
    public class CachingOAuthTokenValidatorDecoratorTests
    {
        public class When_requesting_API_client_details_for_a_valid_token_that_are_not_in_cache : TestFixtureBase
        {
            // Supplied values
            private readonly string _suppliedApiToken = Guid.NewGuid()
                                                            .ToString();
            private readonly int _suppliedDurationMinutes = 100;
            private ApiClientDetails _suppliedClientDetails;

            // Actual values
            private ApiClientDetails _actualDetails;

            // Dependencies
            private IOAuthTokenValidator _decoratedValidator;
            private ICacheProvider _cacheProvider;
            private ApiSettings _apiSettings;

            protected override void Arrange()
            {
                // Initialize dependencies
                _suppliedClientDetails = new ApiClientDetails
                {
                    ApiKey = "resolvedApiKey"
                };

                _decoratedValidator = Stub<IOAuthTokenValidator>();

                A.CallTo(() => _decoratedValidator.GetClientDetailsForTokenAsync(_suppliedApiToken))
                              .Returns(Task.FromResult(_suppliedClientDetails));

                _cacheProvider = Stub<ICacheProvider>();
                _apiSettings = Stub<ApiSettings>();
                _apiSettings.BearerTokenTimeoutMinutes = _suppliedDurationMinutes;
            }

            protected override void Act()
            {
                // Execute code under test
                var validator = new CachingOAuthTokenValidatorDecorator(
                    _decoratedValidator,
                    _cacheProvider,
                    _apiSettings);

                _actualDetails = validator.GetClientDetailsForTokenAsync(_suppliedApiToken)
                                          .GetResultSafely();
            }

            [Assert]
            public void Should_check_the_cache_for_the_details()
            {
                object objects = null;
                A.CallTo(() => _cacheProvider.TryGetCachedObject(A<string>._, out objects)).MustHaveHappened();
                var result= _cacheProvider.TryGetCachedObject(_suppliedApiToken, out objects);
                Assert.AreEqual(false, result);
            }

            [Assert]
            public void Should_call_through_to_the_decorated_implementation()
            {
                A.CallTo(() => _decoratedValidator.GetClientDetailsForTokenAsync(_suppliedApiToken)).MustHaveHappened();
            }

            [Assert]
            public void Should_save_returned_details_into_cache_with_a_fixed_expiration_half_of_the_configured_duration()
            {
                 A.CallTo(()=> _cacheProvider.Insert(A<string>._,A<ApiClientDetails>.That.IsSameAs(_suppliedClientDetails),
                    A<DateTime>.That.IsGreaterThan(DateTime.Now),A<TimeSpan>.That.IsEqualTo(TimeSpan.Zero)));
            }

            [Assert]
            public void Should_return_the_newly_obtained_ApiClientDetails()
            {
                _actualDetails.ShouldBeSameAs(_suppliedClientDetails);
            }
        }

        public class When_requesting_API_client_details_for_an_INVALID_token_that_are_not_in_cache : TestFixtureBase
        {
            // Supplied values
            private readonly string _suppliedInvalidApiToken = Guid.NewGuid()
                                                                   .ToString();
            private readonly int _suppliedDurationMinutes = 100;
            private ApiClientDetails _suppliedInvalidClientDetails;

            // Actual values
            private ApiClientDetails _actualDetails;

            // Dependencies
            private IOAuthTokenValidator _decoratedValidator;
            private ICacheProvider _cacheProvider;
            private ApiSettings _apiSettings;

            protected override void Arrange()
            {
                // Initialize dependencies

                // Create details for an invalid token (no API key assigned)
                _suppliedInvalidClientDetails = new ApiClientDetails();

                _decoratedValidator = Stub<IOAuthTokenValidator>();

                A.CallTo(()=> _decoratedValidator.GetClientDetailsForTokenAsync(_suppliedInvalidApiToken))
                    .Returns(Task.FromResult(_suppliedInvalidClientDetails));

                _cacheProvider = Stub<ICacheProvider>();

                // Mock config file to return duration
                _apiSettings = Stub<ApiSettings>();
                _apiSettings.BearerTokenTimeoutMinutes = _suppliedDurationMinutes;
            }

            protected override void Act()
            {
                // Execute code under test
                var validator = new CachingOAuthTokenValidatorDecorator(
                    _decoratedValidator,
                    _cacheProvider,
                    _apiSettings);

                _actualDetails = validator.GetClientDetailsForTokenAsync(_suppliedInvalidApiToken)
                                          .GetResultSafely();
            }

            [Assert]
            public void Should_check_the_cache_for_the_details()
            {
                object outobject=null;
                A.CallTo(()=> _cacheProvider.TryGetCachedObject(A<string>._,out outobject)).MustHaveHappened();
            }

            [Assert]
            public void Should_call_through_to_the_decorated_implementation()
            {
                A.CallTo(() => _decoratedValidator.GetClientDetailsForTokenAsync(_suppliedInvalidApiToken)).MustHaveHappened();
            }

            [Assert]
            public void Should_NOT_try_save_returned_details_into_cache()
            {
                A.CallTo(() => _cacheProvider.Insert(A<string>._,
                               A<object>.That.IsSameAs(_suppliedInvalidClientDetails),
                               A<DateTime>._,A<TimeSpan>._)).MustNotHaveHappened();
            }

            [Assert]
            public void Should_return_the_newly_obtained_ApiClientDetails()
            {
                _actualDetails.ShouldBeSameAs(_suppliedInvalidClientDetails);
            }
        }

        public class When_requesting_API_client_details_that_are_already_in_cache : TestFixtureBase
        {
            // Supplied values
            private readonly string _suppliedApiToken = Guid.NewGuid()
                                                            .ToString();
            private readonly int _suppliedDurationMinutes = 100;
            private ApiClientDetails _suppliedCachedClientDetails;

            // Actual values
            private ApiClientDetails _actualDetails;

            // Dependencies
            private IOAuthTokenValidator _decoratedValidator;
            private ICacheProvider _cacheProvider;
            private ApiSettings _apiSettings;

            protected override void Arrange()
            {
                // Initialize dependencies
                _suppliedCachedClientDetails = new ApiClientDetails();

                _decoratedValidator = Stub<IOAuthTokenValidator>();

                // Fake the cache to return the details
                _cacheProvider = Stub<ICacheProvider>();
                object outobject = _suppliedCachedClientDetails;
                A.CallTo(()=> _cacheProvider.TryGetCachedObject(A<string>._,out outobject)).Returns(true);

                // Mock config file to return duration
                _apiSettings = Stub<ApiSettings>();
                _apiSettings.BearerTokenTimeoutMinutes = _suppliedDurationMinutes;
            }

            protected override void Act()
            {
                // Execute code under test
                var validator = new CachingOAuthTokenValidatorDecorator(
                    _decoratedValidator,
                    _cacheProvider,
                    _apiSettings);

                _actualDetails = validator.GetClientDetailsForTokenAsync(_suppliedApiToken)
                                          .GetResultSafely();
            }

            [Assert]
            public void Should_check_the_cache_for_the_details()
            {
                object outobject = null;
                A.CallTo(()=> _cacheProvider.TryGetCachedObject(A<string>._,out outobject)).MustHaveHappened();
            }

            [Assert]
            public void Should_NOT_call_through_to_the_decorated_implementation()
            {
                A.CallTo(() => _decoratedValidator.GetClientDetailsForTokenAsync(A<string>._)).MustNotHaveHappened();
            }

            [Assert]
            public void Should_NOT_try_to_save_anything_in_the_cache()
            {
                A.CallTo(() => _cacheProvider.Insert(A<string>._,A<ApiClientDetails>._,A<DateTime>._,A<TimeSpan>._)).MustNotHaveHappened();
            }

            [Assert]
            public void Should_return_the_cached_ApiClientDetails()
            {
                _actualDetails.ShouldBeSameAs(_suppliedCachedClientDetails);
            }
        }
    }
}
#endif
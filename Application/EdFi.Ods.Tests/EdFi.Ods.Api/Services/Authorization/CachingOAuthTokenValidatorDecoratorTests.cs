// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using Rhino.Mocks;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Authorization
{
    public class CachingOAuthTokenValidatorDecoratorTests
    {
        public class When_requesting_API_client_details_for_a_valid_token_that_are_not_in_cache : LegacyTestFixtureBase
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
            private IConfigValueProvider _configValueProvider;

            protected override void Arrange()
            {
                // Initialize dependencies
                _suppliedClientDetails = new ApiClientDetails
                                         {
                                             ApiKey = "resolvedApiKey"
                                         };

                _decoratedValidator = Stub<IOAuthTokenValidator>();

                _decoratedValidator
                   .Stub(x => x.GetClientDetailsForTokenAsync(_suppliedApiToken))
                   .Return(Task.FromResult(_suppliedClientDetails));

                _cacheProvider = Stub<ICacheProvider>();

                // Mock config file to return duration
                _configValueProvider = Stub<IConfigValueProvider>();

                _configValueProvider.Stub(x => x.GetValue(Arg<string>.Is.Anything))
                                    .Return(_suppliedDurationMinutes.ToString());
            }

            protected override void Act()
            {
                // Execute code under test
                var validator = new CachingOAuthTokenValidatorDecorator(
                    _decoratedValidator,
                    _cacheProvider,
                    _configValueProvider);

                _actualDetails = validator.GetClientDetailsForTokenAsync(_suppliedApiToken)
                                          .GetResultSafely();
            }

            [Assert]
            public void Should_check_the_cache_for_the_details()
            {
                _cacheProvider.AssertWasCalled(
                    x =>
                        x.TryGetCachedObject(
                            Arg<string>.Is.Anything,
                            out Arg<object>.Out(null)
                                           .Dummy));
            }

            [Assert]
            public void Should_call_through_to_the_decorated_implementation()
            {
                _decoratedValidator.AssertWasCalled(
                    x =>
                        x.GetClientDetailsForTokenAsync(_suppliedApiToken));
            }

            [Assert]
            public void Should_save_returned_details_into_cache_with_a_fixed_expiration_half_of_the_configured_duration()
            {
                _cacheProvider.AssertWasCalled(
                    x =>
                        x.Insert(
                            Arg<string>.Is.Anything,
                            Arg<ApiClientDetails>.Is.Same(_suppliedClientDetails),
                            Arg<DateTime>.Is.LessThanOrEqual(DateTime.Now.AddMinutes(_suppliedDurationMinutes / 2.0)),
                            Arg<TimeSpan>.Is.Equal(TimeSpan.Zero)
                        ));
            }

            [Assert]
            public void Should_return_the_newly_obtained_ApiClientDetails()
            {
                _actualDetails.ShouldBeSameAs(_suppliedClientDetails);
            }
        }

        public class When_requesting_API_client_details_for_an_INVALID_token_that_are_not_in_cache : LegacyTestFixtureBase
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
            private IConfigValueProvider _configValueProvider;

            protected override void Arrange()
            {
                // Initialize dependencies

                // Create details for an invalid token (no API key assigned)
                _suppliedInvalidClientDetails = new ApiClientDetails();

                _decoratedValidator = Stub<IOAuthTokenValidator>();

                _decoratedValidator
                   .Stub(x => x.GetClientDetailsForTokenAsync(_suppliedInvalidApiToken))
                   .Return(Task.FromResult(_suppliedInvalidClientDetails));

                _cacheProvider = Stub<ICacheProvider>();

                // Mock config file to return duration
                _configValueProvider = Stub<IConfigValueProvider>();

                _configValueProvider.Stub(x => x.GetValue(Arg<string>.Is.Anything))
                                    .Return(_suppliedDurationMinutes.ToString());
            }

            protected override void Act()
            {
                // Execute code under test
                var validator = new CachingOAuthTokenValidatorDecorator(
                    _decoratedValidator,
                    _cacheProvider,
                    _configValueProvider);

                _actualDetails = validator.GetClientDetailsForTokenAsync(_suppliedInvalidApiToken)
                                          .GetResultSafely();
            }

            [Assert]
            public void Should_check_the_cache_for_the_details()
            {
                _cacheProvider.AssertWasCalled(
                    x =>
                        x.TryGetCachedObject(
                            Arg<string>.Is.Anything,
                            out Arg<object>.Out(null)
                                           .Dummy));
            }

            [Assert]
            public void Should_call_through_to_the_decorated_implementation()
            {
                _decoratedValidator.AssertWasCalled(
                    x =>
                        x.GetClientDetailsForTokenAsync(_suppliedInvalidApiToken));
            }

            [Assert]
            public void Should_NOT_try_save_returned_details_into_cache()
            {
                _cacheProvider.AssertWasNotCalled(
                    x =>
                        x.Insert(
                            Arg<string>.Is.Anything,
                            Arg<ApiClientDetails>.Is.Same(_suppliedInvalidClientDetails),
                            Arg<DateTime>.Is.Anything,
                            Arg<TimeSpan>.Is.Anything));
            }

            [Assert]
            public void Should_return_the_newly_obtained_ApiClientDetails()
            {
                _actualDetails.ShouldBeSameAs(_suppliedInvalidClientDetails);
            }
        }

        public class When_requesting_API_client_details_that_are_already_in_cache : LegacyTestFixtureBase
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
            private IConfigValueProvider _configValueProvider;

            protected override void Arrange()
            {
                // Initialize dependencies
                _suppliedCachedClientDetails = new ApiClientDetails();

                _decoratedValidator = Stub<IOAuthTokenValidator>();

                // Fake the cache to return the details
                _cacheProvider = Stub<ICacheProvider>();

                _cacheProvider.Stub(
                                   x =>
                                       x.TryGetCachedObject(
                                           Arg<string>.Is.Anything,
                                           out Arg<object>.Out(_suppliedCachedClientDetails)
                                                          .Dummy))
                              .Return(true);

                // Mock config file to return duration
                _configValueProvider = Stub<IConfigValueProvider>();

                _configValueProvider.Stub(x => x.GetValue(Arg<string>.Is.Anything))
                                    .Return(_suppliedDurationMinutes.ToString());
            }

            protected override void Act()
            {
                // Execute code under test
                var validator = new CachingOAuthTokenValidatorDecorator(
                    _decoratedValidator,
                    _cacheProvider,
                    _configValueProvider);

                _actualDetails = validator.GetClientDetailsForTokenAsync(_suppliedApiToken)
                                          .GetResultSafely();
            }

            [Assert]
            public void Should_check_the_cache_for_the_details()
            {
                _cacheProvider.AssertWasCalled(
                    x =>
                        x.TryGetCachedObject(
                            Arg<string>.Is.Anything,
                            out Arg<object>.Out(null)
                                           .Dummy));
            }

            [Assert]
            public void Should_NOT_call_through_to_the_decorated_implementation()
            {
                _decoratedValidator.AssertWasNotCalled(
                    x =>
                        x.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything));
            }

            [Assert]
            public void Should_NOT_try_to_save_anything_in_the_cache()
            {
                _cacheProvider.AssertWasNotCalled(
                    x =>
                        x.Insert(
                            Arg<string>.Is.Anything,
                            Arg<ApiClientDetails>.Is.Anything,
                            Arg<DateTime>.Is.Anything,
                            Arg<TimeSpan>.Is.Anything));
            }

            [Assert]
            public void Should_return_the_cached_ApiClientDetails()
            {
                _actualDetails.ShouldBeSameAs(_suppliedCachedClientDetails);
            }
        }
    }
}

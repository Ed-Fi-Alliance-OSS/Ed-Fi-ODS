// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.AuthorizationStrategies.NoFurtherAuthorization;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using QuickGraph;
using Shouldly;
using Test.Common;
using Test.Common._Stubs;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization
{
    [TestFixture]
    public class Feature_Validating_the_incoming_AuthorizationContext
    {
        public class When_attempting_to_authorize_with_a_null_authorization_context : TestFixtureBase
        {
            protected override void Act()
            {
                // Create provider with stubs
                var provider = new EdFiAuthorizationProvider(
                    Stub<IResourceAuthorizationMetadataProvider>(),
                    new IEdFiAuthorizationStrategy[0],
                    Stub<ISecurityRepository>(),
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(null, CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_an_ArgumentNullException()
            {
                ActualException.ShouldBeExceptionType<ArgumentNullException>();
            }
        }

        public class When_attempting_to_authorize_without_a_resource_value : TestFixtureBase
        {
            protected override void Act()
            {
                // Execute code under test
                var provider = new EdFiAuthorizationProvider(
                    Stub<IResourceAuthorizationMetadataProvider>(),
                    new IEdFiAuthorizationStrategy[0],
                    Stub<ISecurityRepository>(),
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(
                    new EdFiAuthorizationContext(
                        new ClaimsPrincipal(), 
                        new[] {" "}, 
                        "action", 
                        new object()),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_an_AuthorizationContextException()
            {
                ActualException.ShouldBeExceptionType<AuthorizationContextException>();
                ActualException.Message.ShouldContain("resource");
            }
        }

        public class When_attempting_to_authorize_with_a_null_resource : TestFixtureBase
        {
            protected override void Act()
            {
                // Execute code under test
                var provider = new EdFiAuthorizationProvider(
                    Stub<IResourceAuthorizationMetadataProvider>(),
                    new IEdFiAuthorizationStrategy[0],
                    Stub<ISecurityRepository>(),
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(
                    new EdFiAuthorizationContext(
                        new ClaimsPrincipal(), 
                        null, 
                        "action", 
                        new object()),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_an_ArgumentNullException()
            {
                ActualException.ShouldBeExceptionType<ArgumentNullException>();
                ((ArgumentNullException) ActualException).ParamName.ShouldBe("resourceClaimUris");
            }
        }

        public class When_attempting_to_authorize_without_an_action_value : TestFixtureBase
        {
            protected override void Act()
            {
                // Execute code under test
                var provider = new EdFiAuthorizationProvider(
                    Stub<IResourceAuthorizationMetadataProvider>(),
                    new IEdFiAuthorizationStrategy[0],
                    Stub<ISecurityRepository>(),
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(
                    new EdFiAuthorizationContext(
                        new ClaimsPrincipal(), 
                        new[] {"resource"}, 
                        " ", 
                        new object()),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_an_ArgumentNullException()
            {
                ActualException.ShouldBeOfType<AuthorizationContextException>();
                ActualException.Message.ShouldContain("action");
            }
        }

        public class When_attempting_to_authorize_with_a_null_action : TestFixtureBase
        {
            protected override void Act()
            {
                // Execute code under test
                var provider = new EdFiAuthorizationProvider(
                    Stub<IResourceAuthorizationMetadataProvider>(),
                    new IEdFiAuthorizationStrategy[0],
                    Stub<ISecurityRepository>(),
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(
                    new EdFiAuthorizationContext(
                        new ClaimsPrincipal(), 
                        new[] {"resource"}, 
                        null, 
                        new object()),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_an_ArgumentNullException()
            {
                ActualException.ShouldBeExceptionType<ArgumentNullException>();
                ActualException.Message.ShouldContain("action");
            }
        }

        public class When_attempting_to_authorize_with_more_than_2_resource_URI_representations : TestFixtureBase
        {
            protected override void Act()
            {
                // Execute code under test
                var provider = new EdFiAuthorizationProvider(
                    Stub<IResourceAuthorizationMetadataProvider>(),
                    new IEdFiAuthorizationStrategy[0],
                    Stub<ISecurityRepository>(),
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(
                    new EdFiAuthorizationContext(
                        new ClaimsPrincipal(),
                        new []{ "resourceUri1", "resourceUri2", "resourceUri3"},
                        "actionUri",
                        new object()),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_an_AuthorizationContextException()
            {
                ActualException.ShouldBeOfType<AuthorizationContextException>();
                ActualException.Message.ShouldContain("Expected up to 2, but found 3.");
            }
        }
    }

    [TestFixture]
    public class Feature_Validating_authorization_strategy_naming_conventions
    {
        private class AuthorizationStrategyNotFollowingConventions : IEdFiAuthorizationStrategy
        {
            public Task AuthorizeSingleItemAsync(IEnumerable<Claim> relevantClaims, EdFiAuthorizationContext authorizationContext,
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(
                IEnumerable<Claim> relevantClaims,
                EdFiAuthorizationContext authorizationContext)
            {
                throw new NotImplementedException();
            }
        }

        private class ConventionFollowingAuthorizationStrategy : IEdFiAuthorizationStrategy
        {
            public Task AuthorizeSingleItemAsync(IEnumerable<Claim> relevantClaims, EdFiAuthorizationContext authorizationContext,
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(
                IEnumerable<Claim> relevantClaims,
                EdFiAuthorizationContext authorizationContext)
            {
                throw new NotImplementedException();
            }
        }

        private class ConventionFollowing2AuthorizationStrategy
            : ConventionFollowingAuthorizationStrategy { }

        public class When_creating_the_authorization_provider_with_all_authorization_strategy_types_whose_names_end_with_AuthorizationStrategy
            : TestFixtureBase
        {
            protected override void Act()
            {
                // Execute code under test
                var authorizationStrategies = new IEdFiAuthorizationStrategy[]
                                              {
                                                  new ConventionFollowingAuthorizationStrategy(), new ConventionFollowing2AuthorizationStrategy()
                                              };

                var provider = new EdFiAuthorizationProvider(
                    Stub<IResourceAuthorizationMetadataProvider>(),
                    authorizationStrategies,
                    Stub<ISecurityRepository>(),
                    new IExplicitObjectValidator[0]);
            }

            [Assert]
            public void Should_not_throw_an_exception()
            {
                ActualException.ShouldBeNull();
            }
        }

        public class When_creating_the_authorization_provider_with_an_authorization_strategy_type_whose_name_does_not_end_with_AuthorizationStrategy
            : TestFixtureBase
        {
            protected override void Act()
            {
                // Execute code under test
                var authorizationStrategies = new IEdFiAuthorizationStrategy[]
                                              {
                                                  new ConventionFollowingAuthorizationStrategy(), new AuthorizationStrategyNotFollowingConventions()
                                              };

                var provider = new EdFiAuthorizationProvider(
                    Stub<IResourceAuthorizationMetadataProvider>(),
                    authorizationStrategies,
                    Stub<ISecurityRepository>(),
                    new IExplicitObjectValidator[0]);
            }

            [Assert]
            public void Should_throw_an_ArgumentException_indicating_that_the_authorization_strategy_doesnt_follow_proper_naming_conventions()
            {
                ActualException.ShouldBeExceptionType<ArgumentException>();
                ActualException.Message.ShouldContain(typeof(AuthorizationStrategyNotFollowingConventions).Name);
            }
        }
    }

    [TestFixture]
    public class Feature_Authorization_strategy_selection
    {
        public abstract class AuthorizationStrategyBase : IEdFiAuthorizationStrategy
        {
            public bool SingleItemWasCalled { get; private set; }

            public bool FilteringWasCalled { get; private set; }

            public Task AuthorizeSingleItemAsync(IEnumerable<Claim> relevantClaims, EdFiAuthorizationContext authorizationContext, CancellationToken cancellationToken)
            {
                SingleItemWasCalled = true;
                return Task.CompletedTask;
            }

            public IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(
                IEnumerable<Claim> relevantClaims,
                EdFiAuthorizationContext authorizationContext)
            {
                FilteringWasCalled = true;
                
                return new AuthorizationFilterDetails[0];
            }
        }

        public class FirstAuthorizationStrategy : AuthorizationStrategyBase { }

        public class SecondAuthorizationStrategy : AuthorizationStrategyBase { }

        public class FourthAuthorizationStrategy : AuthorizationStrategyBase { }

        public class OverrideAuthorizationStrategy : AuthorizationStrategyBase { }

        public abstract class When_authorizing_a_request : TestFixtureBase
        {
            // Claims represent a lineage (1 is the leaf, 4 is the root)
            protected const string Resource1ClaimUri = @"http://CLAIMS/resource1";
            protected const string Resource2ClaimUri = @"http://CLAIMS/resource2";
            protected const string Resource3ClaimUri = @"http://CLAIMS/resource3";
            protected const string Resource4ClaimUri = @"http://CLAIMS/resource4";

            protected const string ReadActionUri = @"http://ACTIONS/read";

            protected readonly SecondAuthorizationStrategy SecondAuthorizationStrategy = new SecondAuthorizationStrategy();
            protected readonly FourthAuthorizationStrategy FourthAuthorizationStrategy = new FourthAuthorizationStrategy();
            protected readonly OverrideAuthorizationStrategy OverrideAuthorizationStrategy = new OverrideAuthorizationStrategy();

            // Define all authorization strategies
            protected IEdFiAuthorizationStrategy[] AuthorizationStrategies;
            protected ISecurityRepository SecurityRepository;

            protected When_authorizing_a_request()
            {
                SecurityRepository = Given_a_security_repository_returning_all_actions_and_appropriate_claim_name_lineage();

                AuthorizationStrategies = new IEdFiAuthorizationStrategy[]
                                          {
                                              SecondAuthorizationStrategy, FourthAuthorizationStrategy, OverrideAuthorizationStrategy
                                          };
            }

            protected ClaimsPrincipal Given_a_principal_with_a_single_resource_claim(string resourceClaimUri, string actionUri)
            {
                // Issue Resource claim with action
                Claim[] claims =
                {
                    JsonClaimHelper.CreateClaim(resourceClaimUri, new EdFiResourceClaimValue(actionUri))
                };

                return
                    new ClaimsPrincipal(
                        new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));
            }

            private ISecurityRepository Given_a_security_repository_returning_all_actions_and_appropriate_claim_name_lineage()
            {
                var securityRepository = Stub<ISecurityRepository>();

                A.CallTo(() => securityRepository.GetActionByName("Create"))
                                  .Returns(
                                       new Action
                                       {
                                           ActionId = 1, ActionName = "Create", ActionUri = "http://ACTIONS/create"
                                       });

                A.CallTo(() => securityRepository.GetActionByName("Read"))
                                  .Returns(
                                       new Action
                                       {
                                           ActionId = 1, ActionName = "Read", ActionUri = "http://ACTIONS/read"
                                       });

                A.CallTo(() => securityRepository.GetActionByName("Update"))
                                  .Returns(
                                       new Action
                                       {
                                           ActionId = 1, ActionName = "Update", ActionUri = "http://ACTIONS/update"
                                       });

                A.CallTo(() => securityRepository.GetActionByName("Delete"))
                                  .Returns(
                                       new Action
                                       {
                                           ActionId = 1, ActionName = "Delete", ActionUri = "http://ACTIONS/delete"
                                       });

                A.CallTo(() => securityRepository.GetResourceClaimLineage(Resource1ClaimUri))
                                  .Returns(
                                       new[]
                                       {
                                           Resource1ClaimUri, Resource2ClaimUri, Resource3ClaimUri, Resource4ClaimUri
                                       });

                A.CallTo(() => securityRepository.GetResourceClaimLineage(Resource2ClaimUri))
                                  .Returns(
                                       new[]
                                       {
                                           Resource2ClaimUri, Resource3ClaimUri, Resource4ClaimUri
                                       });

                A.CallTo(() => securityRepository.GetResourceClaimLineage(Resource3ClaimUri))
                                  .Returns(
                                       new[]
                                       {
                                           Resource3ClaimUri, Resource4ClaimUri
                                       });

                A.CallTo(() => securityRepository.GetResourceClaimLineage(Resource4ClaimUri))
                                  .Returns(
                                       new[]
                                       {
                                           Resource4ClaimUri
                                       });

                return securityRepository;
            }

            protected abstract IResourceAuthorizationMetadataProvider CreateResourceAuthorizationMetadataProvider(
                string resourceClaim,
                string actionUri);
        }

        // ================ Begin Authorization Strategy Override Scenarios ===============

        public abstract class When_authorizing_a_request_affected_by_authorization_strategies : When_authorizing_a_request
        {
            protected virtual ClaimsPrincipal Given_a_principal_with_a_single_resource_claim_and_an_authorization_strategy_override(
                string resourceClaimUri,
                string actionUri,
                string authorizationStrategyNameOverride)
            {
                // Issue Resource claim with action
                Claim[] claims =
                {
                    JsonClaimHelper.CreateClaim(resourceClaimUri, new EdFiResourceClaimValue(actionUri, authorizationStrategyNameOverride))
                };

                return
                    new ClaimsPrincipal(
                        new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));
            }

            protected override IResourceAuthorizationMetadataProvider CreateResourceAuthorizationMetadataProvider(
                string resourceClaim,
                string actionUri)
            {
                // Return metadata with 4 resource claims, with Resource 3 not having an authorization strategy.
                var authorizationMetadataProvider = Stub<IResourceAuthorizationMetadataProvider>();

                A.CallTo(() => authorizationMetadataProvider.GetResourceClaimAuthorizationMetadata(resourceClaim, actionUri))
                                             .Returns(
                                                  new List<ResourceClaimAuthorizationMetadata>
                                                      {
                                                          new ResourceClaimAuthorizationMetadata
                                                          {
                                                              ClaimName = Resource1ClaimUri, AuthorizationStrategy = null //"First"
                                                          },
                                                          new ResourceClaimAuthorizationMetadata
                                                          {
                                                              ClaimName = Resource2ClaimUri, AuthorizationStrategy = "Second"
                                                          },
                                                          new ResourceClaimAuthorizationMetadata
                                                          {
                                                              ClaimName = Resource3ClaimUri, AuthorizationStrategy = null
                                                          },
                                                          new ResourceClaimAuthorizationMetadata
                                                          {
                                                              ClaimName = Resource4ClaimUri, AuthorizationStrategy = "Fourth"
                                                          }
                                                      }

                                                      // Trim out lineage from bottom up to incoming claim name
                                                     .SkipWhile(
                                                          rcas => !rcas.ClaimName.Equals(resourceClaim, StringComparison.InvariantCultureIgnoreCase))
                                                     .ToList());

                return authorizationMetadataProvider;
            }
        }

        public class When_authorizing_a_request_for_a_resource_with_an_explicit_authorization_strategy_defined
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4
                var claimsPrincipal = Given_a_principal_with_a_single_resource_claim(Resource4ClaimUri, ReadActionUri);

                // Request is for Read access to Resource 2
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource2ClaimUri},
                    ReadActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).Wait();
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_authorization_strategy_assigned_to_the_requested_resource_claim()
            {
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_with_an_explicit_authorization_strategy_defined_that_is_BELOW_the_callers_claim_with_an_authorization_override_defined
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4
                var claimsPrincipal =
                    Given_a_principal_with_a_single_resource_claim_and_an_authorization_strategy_override(
                        Resource4ClaimUri,
                        ReadActionUri,
                        "Override");

                // Request is for Read access to Resource 2
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource2ClaimUri},
                    ReadActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_override_authorization_strategy()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_with_an_explicit_authorization_strategy_defined_that_is_ABOVE_one_of_the_callers_claim_with_an_authorization_override_defined
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has claims for Resources 1 and 3 (out of order)
                Claim[] claims =
                {
                    // The "out of order" of these claims is intentional and is testing that the match is 
                    // made on the first matching claim based on the authorization metadata hierarchy
                    // rather than the order in which the claims are issued to the caller in the claim set.
                    // In this case, Resource2 is "lower" in the hierarchy, and should be the one matched first.
                    JsonClaimHelper.CreateClaim(Resource3ClaimUri, new EdFiResourceClaimValue(ReadActionUri)),
                    JsonClaimHelper.CreateClaim(Resource1ClaimUri, new EdFiResourceClaimValue(ReadActionUri, "Override"))

                    // This claim is "below" requested resource, so it should be ignored 
                    // (NOTE: This will not happen with the current implementation of the API, but has been added for full coverage/definition of expected behavior)
                };

                // Caller has Read access to Resources 1 and 3
                var claimsPrincipal =
                    new ClaimsPrincipal(
                        new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));

                // Request is for Read access to Resource 2
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource2ClaimUri},
                    ReadActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_strategy_obtained_from_the_next_lowest_level_resource_claim_with_an_assigned_authorization_strategy()
            {
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_authorization_strategy_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_BELOW_the_callers_assigned_claim_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4
                var claimsPrincipal = Given_a_principal_with_a_single_resource_claim(Resource4ClaimUri, ReadActionUri);

                // Request is for Read access to Resource 1
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource1ClaimUri},
                    ReadActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_strategy_obtained_from_the_next_lowest_level_resource_claim_with_an_assigned_authorization_strategy()
            {
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_authorization_strategy_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_ABOVE_the_callers_assigned_claim_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 3
                var claimsPrincipal = Given_a_principal_with_a_single_resource_claim(Resource3ClaimUri, ReadActionUri);

                // Request is for Read access to Resource 3
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource3ClaimUri},
                    ReadActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_strategy_obtained_from_the_next_lowest_level_resource_claim_with_an_assigned_authorization_strategy()
            {
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_authorization_strategy_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_BELOW_the_callers_assigned_claim_with_an_authorization_strategy_override_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4
                var claimsPrincipal =
                    Given_a_principal_with_a_single_resource_claim_and_an_authorization_strategy_override(
                        Resource4ClaimUri,
                        ReadActionUri,
                        "Override");

                // Request is for Read access to Resource 1
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource1ClaimUri},
                    ReadActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_override_authorization_strategy()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_authorization_strategy_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_ABOVE_the_callers_assigned_claim_with_an_authorization_strategy_override_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 3
                var claimsPrincipal =
                    Given_a_principal_with_a_single_resource_claim_and_an_authorization_strategy_override(
                        Resource3ClaimUri,
                        ReadActionUri,
                        "Override");

                // Request is for Read access to Resource 3
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource3ClaimUri},
                    ReadActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_override_authorization_strategy()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
            }
        }

        public class When_authorizing_a_request_for_which_the_principal_has_multiple_matching_claims_with_an_authorization_strategy_override_defined
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has claims for Resources 2 and 3 (out of order)
                Claim[] claims =
                {
                    // The "out of order" of these claims is intentional and is testing that the match is 
                    // made on the first matching claim based on the authorization metadata hierarchy
                    // rather than the order in which the claims are issued to the caller in the claim set.
                    // In this case, Resource2 is "lower" in the hierarchy, and should be the one matched first.
                    JsonClaimHelper.CreateClaim(Resource3ClaimUri, new EdFiResourceClaimValue(ReadActionUri)),
                    JsonClaimHelper.CreateClaim(Resource2ClaimUri, new EdFiResourceClaimValue(ReadActionUri))
                };

                var claimsPrincipal =
                    new ClaimsPrincipal(
                        new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));

                // Request is for Read access to Resource 1
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource1ClaimUri},
                    ReadActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void
                Should_resolve_claims_using_authorization_metadata_order_rather_than_callers_claims_order_and_invoke_lowest_matching_claims_authorization_strategy()
            {
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
            }
        }

        // ================ Begin Validation Rule Set Override Scenarios ===============
        public class FakeExplicitObjectValidator : IExplicitObjectValidator
        {
            public FakeExplicitObjectValidator()
            {
                Invocations = new List<Invocation>();
            }

            public List<Invocation> Invocations { get; }

            public string[] InvokedRuleSets
            {
                get
                {
                    return Invocations.Select(x => x.RuleSetName)
                                      .ToArray();
                }
            }

            /// <summary>
            /// Validates an object using a specific externally defined rule set.
            /// </summary>
            /// <param name="object">The object to be validated.</param>
            /// <param name="ruleSetName">The name of the externally defined rule set to be executed.</param>
            /// <returns>The results of the validation.</returns>
            public ICollection<ValidationResult> ValidateObject(object @object, string ruleSetName)
            {
                Invocations.Add(new Invocation(@object, ruleSetName));

                return new List<ValidationResult>();
            }

            public class Invocation
            {
                public Invocation(object @object, string ruleSetName)
                {
                    Object = @object;
                    RuleSetName = ruleSetName;
                }

                public object Object { get; set; }

                public string RuleSetName { get; set; }
            }
        }

        public abstract class When_authorizing_a_request_affected_by_authorization_validation_rule_sets : When_authorizing_a_request
        {
            protected FakeExplicitObjectValidator FakeExplicitObjectValidator1 = new FakeExplicitObjectValidator();
            protected FakeExplicitObjectValidator FakeExplicitObjectValidator2 = new FakeExplicitObjectValidator();

            protected const string CreateActionUri = @"http://ACTIONS/create";

            protected virtual ClaimsPrincipal Given_a_principal_with_a_single_resource_claim_and_a_validation_rule_set_override(
                string resourceClaimUri,
                string actionUri,
                string validationRuleSetNameOverride)
            {
                // Issue Resource claim with action
                Claim[] claims =
                {
                    JsonClaimHelper.CreateClaim(resourceClaimUri, new EdFiResourceClaimValue(actionUri, null, null, validationRuleSetNameOverride))
                };

                return
                    new ClaimsPrincipal(
                        new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));
            }

            protected override IResourceAuthorizationMetadataProvider CreateResourceAuthorizationMetadataProvider(
                string resourceClaim,
                string actionUri)
            {
                // Return metadata with 4 resource claims, with Resource 3 not having an authorization strategy.
                var authorizationMetadataProvider = Stub<IResourceAuthorizationMetadataProvider>();

                A.CallTo(() => authorizationMetadataProvider.GetResourceClaimAuthorizationMetadata(resourceClaim, actionUri))
                                             .Returns(
                                                  new List<ResourceClaimAuthorizationMetadata>
                                                      {
                                                          new ResourceClaimAuthorizationMetadata
                                                          {
                                                              ClaimName = Resource1ClaimUri, ValidationRuleSetName = null
                                                          },
                                                          new ResourceClaimAuthorizationMetadata
                                                          {
                                                              ClaimName = Resource2ClaimUri, ValidationRuleSetName = "RuleSetFor2"
                                                          },
                                                          new ResourceClaimAuthorizationMetadata
                                                          {
                                                              ClaimName = Resource3ClaimUri, ValidationRuleSetName = null
                                                          },
                                                          new ResourceClaimAuthorizationMetadata
                                                          {
                                                              ClaimName = Resource4ClaimUri, ValidationRuleSetName = "RuleSetFor4",
                                                              AuthorizationStrategy =
                                                                  "Fourth" // We need an authorization strategy defined somewhere in the lineage
                                                          }
                                                      }

                                                      // Trim out lineage from bottom up to incoming claim name
                                                     .SkipWhile(
                                                          rcas => !rcas.ClaimName.Equals(resourceClaim, StringComparison.InvariantCultureIgnoreCase))
                                                     .ToList());

                return authorizationMetadataProvider;
            }
        }

        public class When_authorizing_a_request_for_a_resource_with_an_explicit_validation_rule_set_defined
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4
                var claimsPrincipal = Given_a_principal_with_a_single_resource_claim(Resource4ClaimUri, CreateActionUri);

                // Request is for Read access to Resource 2
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource2ClaimUri},
                    CreateActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new[]
                    {
                        FakeExplicitObjectValidator1, FakeExplicitObjectValidator2
                    });

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_validation_rule_set_assigned_to_the_requested_resource_claim_executing_all_the_supplied_validators()
            {
                Assert.That(
                    FakeExplicitObjectValidator1.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));

                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_validation_rule_sets()
            {
                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets
                                                .Concat(FakeExplicitObjectValidator2.InvokedRuleSets)
                                                .Distinct()
                                                .ToArray(),
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));
            }

            [Assert]
            public void Should_only_attempt_to_authorize_using_the_sole_authorization_strategy_defined_on_the_top_level_claim_in_the_lineage()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_with_an_explicit_validation_rule_set_defined_that_is_BELOW_the_callers_claim_with_an_authorization_override_defined
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4
                var claimsPrincipal = Given_a_principal_with_a_single_resource_claim_and_a_validation_rule_set_override(
                    Resource4ClaimUri,
                    CreateActionUri,
                    "OverrideRuleSet");

                // Request is for Read access to Resource 2
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource2ClaimUri},
                    CreateActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new[]
                    {
                        FakeExplicitObjectValidator1, FakeExplicitObjectValidator2
                    });

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_override_validation_rule_set_executing_all_the_supplied_validators()
            {
                Assert.That(
                    FakeExplicitObjectValidator1.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "OverrideRuleSet"
                        }));

                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "OverrideRuleSet"
                        }));
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_validation_rule_sets()
            {
                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets
                                                .Concat(FakeExplicitObjectValidator2.InvokedRuleSets)
                                                .Distinct()
                                                .ToArray(),
                    Is.EqualTo(
                        new[]
                        {
                            "OverrideRuleSet"
                        }));
            }

            [Assert]
            public void Should_only_attempt_to_authorize_using_the_sole_authorization_strategy_defined_on_the_top_level_claim_in_the_lineage()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_with_an_explicit_validation_rule_set_defined_that_is_ABOVE_one_of_the_callers_claim_with_an_authorization_override_defined
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has claims for Resources 1 and 3 (out of order)
                Claim[] claims =
                {
                    // The "out of order" of these claims is intentional and is testing that the match is 
                    // made on the first matching claim based on the authorization metadata hierarchy
                    // rather than the order in which the claims are issued to the caller in the claim set.
                    // In this case, Resource2 is "lower" in the hierarchy, and should be the one matched first.
                    JsonClaimHelper.CreateClaim(Resource3ClaimUri, new EdFiResourceClaimValue(CreateActionUri)),
                    JsonClaimHelper.CreateClaim(Resource1ClaimUri, new EdFiResourceClaimValue(CreateActionUri, null, null, "OverrideRuleSet"))

                    // This claim is "below" requested resource, so it should be ignored 
                    // (NOTE: This will not happen with the current implementation of the API, but has been added for full coverage/definition of expected behavior)
                };

                // Caller has Read access to Resources 1 and 3
                var claimsPrincipal =
                    new ClaimsPrincipal(
                        new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));

                // Request is for Read access to Resource 2
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource2ClaimUri},
                    CreateActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new[]
                    {
                        FakeExplicitObjectValidator1, FakeExplicitObjectValidator2
                    });

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_validation_rule_set_obtained_from_the_next_lowest_level_resource_claim_with_an_assigned_validation_rule_set_executing_all_the_supplied_validators()
            {
                Assert.That(
                    FakeExplicitObjectValidator1.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));

                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_validation_rule_sets()
            {
                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets
                                                .Concat(FakeExplicitObjectValidator2.InvokedRuleSets)
                                                .Distinct()
                                                .ToArray(),
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));
            }

            [Assert]
            public void Should_only_attempt_to_authorize_using_the_sole_authorization_strategy_defined_on_the_top_level_claim_in_the_lineage()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_validation_rule_set_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_BELOW_the_callers_assigned_claim_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4
                var claimsPrincipal = Given_a_principal_with_a_single_resource_claim(Resource4ClaimUri, CreateActionUri);

                // Request is for Read access to Resource 1
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource1ClaimUri},
                    CreateActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new[]
                    {
                        FakeExplicitObjectValidator1, FakeExplicitObjectValidator2
                    });

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_validation_rule_set_obtained_from_the_next_lowest_level_resource_claim_with_an_assigned_validation_rule_set()
            {
                Assert.That(
                    FakeExplicitObjectValidator1.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));

                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_validation_rule_sets()
            {
                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets
                                                .Concat(FakeExplicitObjectValidator2.InvokedRuleSets)
                                                .Distinct()
                                                .ToArray(),
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));
            }

            [Assert]
            public void Should_only_attempt_to_authorize_using_the_sole_authorization_strategy_defined_on_the_top_level_claim_in_the_lineage()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_validation_rule_set_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_ABOVE_the_callers_assigned_claim_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 3
                var claimsPrincipal = Given_a_principal_with_a_single_resource_claim(Resource3ClaimUri, CreateActionUri);

                // Request is for Read access to Resource 3
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource3ClaimUri},
                    CreateActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new[]
                    {
                        FakeExplicitObjectValidator1, FakeExplicitObjectValidator2
                    });

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_validation_rule_set_obtained_from_the_next_lowest_level_resource_claim_with_an_assigned_validation_rule_set()
            {
                Assert.That(
                    FakeExplicitObjectValidator1.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor4"
                        }));

                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor4"
                        }));
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_validation_rule_sets()
            {
                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets
                                                .Concat(FakeExplicitObjectValidator2.InvokedRuleSets)
                                                .Distinct()
                                                .ToArray(),
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor4"
                        }));
            }

            [Assert]
            public void Should_only_attempt_to_authorize_using_the_sole_authorization_strategy_defined_on_the_top_level_claim_in_the_lineage()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_validation_rule_set_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_BELOW_the_callers_assigned_claim_with_a_validation_rule_set_override_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4
                var claimsPrincipal = Given_a_principal_with_a_single_resource_claim_and_a_validation_rule_set_override(
                    Resource4ClaimUri,
                    CreateActionUri,
                    "OverrideRuleSet");

                // Request is for Read access to Resource 1
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource1ClaimUri},
                    CreateActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new[]
                    {
                        FakeExplicitObjectValidator1, FakeExplicitObjectValidator2
                    });

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_override_validation_rule_set_executing_all_the_supplied_validators()
            {
                Assert.That(
                    FakeExplicitObjectValidator1.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "OverrideRuleSet"
                        }));

                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "OverrideRuleSet"
                        }));
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_validation_rule_sets()
            {
                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets
                                                .Concat(FakeExplicitObjectValidator2.InvokedRuleSets)
                                                .Distinct()
                                                .ToArray(),
                    Is.EqualTo(
                        new[]
                        {
                            "OverrideRuleSet"
                        }));
            }

            [Assert]
            public void Should_only_attempt_to_authorize_using_the_sole_authorization_strategy_defined_on_the_top_level_claim_in_the_lineage()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_validation_rule_set_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_ABOVE_the_callers_assigned_claim_with_a_validation_rule_set_override_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 3
                var claimsPrincipal = Given_a_principal_with_a_single_resource_claim_and_a_validation_rule_set_override(
                    Resource3ClaimUri,
                    CreateActionUri,
                    "OverrideRuleSet");

                // Request is for Read access to Resource 3
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource3ClaimUri},
                    CreateActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new[]
                    {
                        FakeExplicitObjectValidator1, FakeExplicitObjectValidator2
                    });

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_override_validation_rule_set_executing_all_the_supplied_validators()
            {
                Assert.That(
                    FakeExplicitObjectValidator1.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "OverrideRuleSet"
                        }));

                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "OverrideRuleSet"
                        }));
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_validation_rule_sets()
            {
                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets
                                                .Concat(FakeExplicitObjectValidator2.InvokedRuleSets)
                                                .Distinct()
                                                .ToArray(),
                    Is.EqualTo(
                        new[]
                        {
                            "OverrideRuleSet"
                        }));
            }

            [Assert]
            public void Should_only_attempt_to_authorize_using_the_sole_authorization_strategy_defined_on_the_top_level_claim_in_the_lineage()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }
        }

        public class When_authorizing_a_request_for_which_the_principal_has_multiple_matching_claims_with_a_validation_rule_set_override_defined
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has claims for Resources 2 and 3 (out of order)
                Claim[] claims =
                {
                    // The "out of order" of these claims is intentional and is testing that the match is 
                    // made on the first matching claim based on the authorization metadata hierarchy
                    // rather than the order in which the claims are issued to the caller in the claim set.
                    // In this case, Resource2 is "lower" in the hierarchy, and should be the one matched first.
                    JsonClaimHelper.CreateClaim(Resource3ClaimUri, new EdFiResourceClaimValue(CreateActionUri)),
                    JsonClaimHelper.CreateClaim(Resource2ClaimUri, new EdFiResourceClaimValue(CreateActionUri))
                };

                var claimsPrincipal =
                    new ClaimsPrincipal(
                        new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth));

                // Request is for Read access to Resource 1
                var authorizationContext = new EdFiAuthorizationContext(
                    claimsPrincipal,
                    new[] {Resource1ClaimUri},
                    CreateActionUri,
                    new object());

                // Get the strategy metadata provider, using the authorization context values
                var authorizationMetadataProvider = CreateResourceAuthorizationMetadataProvider(
                    authorizationContext.Resource.Single()
                                        .Value,
                    authorizationContext.Action.Single()
                                        .Value);

                var provider = new EdFiAuthorizationProvider(
                    authorizationMetadataProvider,
                    AuthorizationStrategies,
                    SecurityRepository,
                    new[]
                    {
                        FakeExplicitObjectValidator1, FakeExplicitObjectValidator2
                    });

                provider.AuthorizeSingleItemAsync(authorizationContext, CancellationToken.None).WaitSafely();
            }

            [Assert]
            public void
                Should_resolve_claims_using_authorization_metadata_order_rather_than_callers_claims_order_and_invoke_only_the_lowest_matching_claims_validation_rule_set()
            {
                Assert.That(
                    FakeExplicitObjectValidator1.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));

                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets,
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));

                Assert.That(
                    FakeExplicitObjectValidator2.InvokedRuleSets
                                                .Concat(FakeExplicitObjectValidator2.InvokedRuleSets)
                                                .Distinct()
                                                .ToArray(),
                    Is.EqualTo(
                        new[]
                        {
                            "RuleSetFor2"
                        }));
            }

            [Assert]
            public void Should_only_attempt_to_authorize_using_the_sole_authorization_strategy_defined_on_the_top_level_claim_in_the_lineage()
            {
                OverrideAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.SingleItemWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.SingleItemWasCalled.ShouldBeTrue();
            }
        }
    }

    [TestFixture]
    public class Feature_Authorizing_requests_focusing_on_actions
    {
        public abstract class When_authorizing : TestFixtureBase
        {
            protected const string TestResource = "http://ed-fi.org/ods/resource/test";

            protected string SuppliedPrincipalClaim;
            protected string SuppliedPrincipalAction;
            protected string SuppliedRequestedAction;
            protected string SuppliedResourceAuthorizationClaim;
            protected string SuppliedResourceAuthorizationStrategy;
            private EdFiAuthorizationContext _suppliedEdFiAuthorizationContext;

            private IResourceAuthorizationMetadataProvider _resourceAuthorizationMetadataProvider;
            private IEducationOrganizationHierarchyProvider _educationOrganizationHierarchyProvider;
            private StubSecurityRepository _securityRepository;

            protected override void Arrange()
            {
                SetPrincipalAndStrategyAndContextValues();

                var suppliedResourceClaimsAuthorizationStrategyMetadata =
                    GetEdFiClaimsAuthorizationStrategyMetadata(SuppliedResourceAuthorizationStrategy, SuppliedResourceAuthorizationClaim);

                _suppliedEdFiAuthorizationContext = GetEdFiAuthorizationContext(SuppliedRequestedAction);

                _resourceAuthorizationMetadataProvider = Stub<IResourceAuthorizationMetadataProvider>();

                A.CallTo(() => _resourceAuthorizationMetadataProvider.GetResourceClaimAuthorizationMetadata(A<string>.Ignored, A<string>.Ignored))
                                                      .Returns(suppliedResourceClaimsAuthorizationStrategyMetadata);

                var edOrgCache = Stub<IEducationOrganizationCache>();

                A.CallTo(() => edOrgCache.GetEducationOrganizationIdentifiers(A<int>.Ignored))
                          .Returns(new EducationOrganizationIdentifiers(4, "School", 1, 2, 3, 4, 5, 6, 7));

                _securityRepository = new StubSecurityRepository();
            }

            protected override void Act()
            {
                var provider = new EdFiAuthorizationProvider(
                    _resourceAuthorizationMetadataProvider,
                    GetAuthorizationStrategies(),
                    _securityRepository,
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(_suppliedEdFiAuthorizationContext, CancellationToken.None).WaitSafely();
            }

            protected virtual void SetPrincipalAndStrategyAndContextValues()
            {
                SuppliedPrincipalClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";
                SuppliedPrincipalAction = "http://ed-fi.org/ods/actions/read";

                SuppliedRequestedAction = "http://ed-fi.org/ods/actions/read";

                SuppliedResourceAuthorizationClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";
                SuppliedResourceAuthorizationStrategy = "EdFiTypes";
            }

            //Claims that are needed for the resource in context.
            protected virtual IEnumerable<ResourceClaimAuthorizationMetadata> GetEdFiClaimsAuthorizationStrategyMetadata(
                string strategy,
                string claim)
            {
                return new List<ResourceClaimAuthorizationMetadata>
                       {
                           new ResourceClaimAuthorizationMetadata
                           {
                               ClaimName = claim, AuthorizationStrategy = strategy
                           }
                       };
            }

            //The context to authorize.
            protected virtual EdFiAuthorizationContext GetEdFiAuthorizationContext(string action)
            {
                return GetEdFiAuthorizationContext(TestResource, action);
            }

            protected virtual EdFiAuthorizationContext GetEdFiAuthorizationContext(string resource, string action)
            {
                return new EdFiAuthorizationContext(
                    GetClaimsPrincipal(),
                    new[] {resource},
                    action,
                    new object());
            }

            //The current principal
            protected virtual ClaimsPrincipal GetClaimsPrincipal()
            {
                return GetClaimsPrincipal(SuppliedPrincipalClaim, SuppliedPrincipalAction);
            }

            protected virtual ClaimsPrincipal GetClaimsPrincipal(string claim, string action)
            {
                var claimsPrincipal = Stub<ClaimsPrincipal>();

                var claims = new List<Claim>
                             {
                                 JsonClaimHelper.CreateClaim(claim, new EdFiResourceClaimValue(action))
                             };

                A.CallTo(() => claimsPrincipal.Claims)
                               .Returns(claims);

                return claimsPrincipal;
            }

            protected virtual IEdFiAuthorizationStrategy[] GetAuthorizationStrategies()
            {
                _educationOrganizationHierarchyProvider = Stub<IEducationOrganizationHierarchyProvider>();

                A.CallTo(() => _educationOrganizationHierarchyProvider.GetEducationOrganizationHierarchy())
                                                       .Returns(new AdjacencyGraph<string, Edge<string>>());

                var edOrgCache = Stub<IEducationOrganizationCache>();

                A.CallTo(() => edOrgCache.GetEducationOrganizationIdentifiers(A<int>.Ignored))
                          .Returns(new EducationOrganizationIdentifiers(4, "School", 1, 2, 3, 4, 5, 6, 7));

                return new IEdFiAuthorizationStrategy[]
                       {
                           new RelationshipsWithEdOrgsAndPeopleAuthorizationStrategy<RelationshipsAuthorizationContextData>(
                               new ConcreteEducationOrganizationIdAuthorizationContextDataTransformer<RelationshipsAuthorizationContextData>(edOrgCache))
                           {
                               AuthorizationSegmentsToFiltersConverter = Stub<IAuthorizationSegmentsToFiltersConverter>(),
                               AuthorizationSegmentsVerifier = Stub<IAuthorizationSegmentsVerifier>(),
                               EducationOrganizationCache = Stub<IEducationOrganizationCache>(),
                               EducationOrganizationHierarchyProvider = _educationOrganizationHierarchyProvider,
                               RelationshipsAuthorizationContextDataProviderFactory =
                                   Stub<IRelationshipsAuthorizationContextDataProviderFactory<RelationshipsAuthorizationContextData>>()
                           },
                           new NoFurtherAuthorizationRequiredAuthorizationStrategy()
                       };
            }
        }

        public class When_authorizing_with_a_matching_resource_claim_and_action
            : When_authorizing
        {
            protected override void SetPrincipalAndStrategyAndContextValues()
            {
                //Claims and Actions are the same...
                SuppliedPrincipalClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";
                SuppliedResourceAuthorizationClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";

                SuppliedPrincipalAction = "http://ed-fi.org/ods/actions/read";
                SuppliedRequestedAction = "http://ed-fi.org/ods/actions/read";

                SuppliedResourceAuthorizationStrategy = "NoFurtherAuthorizationRequired";
            }

            [Assert]
            public void Should_NOT_throw_exception()
            {
                ActualException.ShouldBeNull();
            }
        }

        public class When_authorizing_WITHOUT_a_matching_resource_claim
            : When_authorizing
        {
            protected override void SetPrincipalAndStrategyAndContextValues()
            {
                //If the principal doesnt have the right claim for the resource it should fail.
                SuppliedPrincipalClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiDescriptors";
                SuppliedResourceAuthorizationClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";

                SuppliedPrincipalAction = "Not relevant for this test.";
                SuppliedRequestedAction = "Not relevant for this test.";
                SuppliedResourceAuthorizationStrategy = "Not relevant for this test.";
            }

            [Assert]
            public void Should_throw_exception()
            {
                ActualException.ShouldNotBeNull();
                ActualException.Message.ShouldContain("Are you missing a claim?");
            }
        }

        public class When_authorizing_with_a_matching_claim_but_without_a_matching_action
            : When_authorizing
        {
            protected override void SetPrincipalAndStrategyAndContextValues()
            {
                //If the principal doesnt have the right claim for the resource it should fail.
                SuppliedPrincipalClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";
                SuppliedResourceAuthorizationClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";

                SuppliedPrincipalAction = "http://ed-fi.org/ods/actions/read";
                SuppliedRequestedAction = "http://ed-fi.org/ods/actions/create";

                SuppliedResourceAuthorizationStrategy = "Not relevant for this test.";
            }

            [Assert]
            public void Should_throw_exception_indicating_authorization_failed_for_the_requested_action()
            {
                ActualException.ShouldNotBeNull();

                ActualException.Message.ShouldBe(
                    string.Format(
                        "Access to the resource could not be authorized for the requested action '{0}'.",
                        SuppliedRequestedAction));
            }
        }
    }

    [TestFixture]
    public class Feature_Detecting_missing_or_undefined_authorization_strategies
    {
        // Feature constants
        private const string Resource1ClaimUri = @"http://CLAIMS/resource1";
        private const string Resource2ClaimUri = @"http://CLAIMS/resource2";
        private const string ReadActionUri = @"http://ACTIONS/read";

        // Feature artifacts
        public class UnusedAuthorizationStrategy : IEdFiAuthorizationStrategy
        {
            public bool SingleItemWasCalled { get; private set; }

            public bool FilteringWasCalled { get; private set; }

            public Task AuthorizeSingleItemAsync(IEnumerable<Claim> relevantClaims, EdFiAuthorizationContext authorizationContext,
                CancellationToken cancellationToken)
            {
                SingleItemWasCalled = true;
                
                return Task.CompletedTask;
            }

            public IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(
                IEnumerable<Claim> relevantClaims,
                EdFiAuthorizationContext authorizationContext)
            {
                FilteringWasCalled = true;
                
                return new AuthorizationFilterDetails[0];
            }
        }

        public class When_no_matching_authorization_strategy_implementation_can_be_found
            : TestFixtureBase
        {
            // Supplied values

            // Actual values

            protected override void Act()
            {
                // Execute code under test
                var provider = new EdFiAuthorizationProvider(
                    Given_authorization_metadata_for_resource_claim_and_action_with_authorization_strategy(
                        Resource1ClaimUri,
                        ReadActionUri,
                        "Missing"),
                    Given_a_collection_of_unused_authorization_strategies(),
                    Given_a_security_repository_returning_all_actions(),
                    new IExplicitObjectValidator[0]);

                // Request is for Resource Claim 1
                provider.AuthorizeSingleItemAsync(
                    Given_an_authorization_context_for_a_request_to_read_a_resource_with_a_principal(
                        Resource1ClaimUri,
                        Given_a_ClaimsPrincipal_with_a_read_claim_for_resource(Resource1ClaimUri)),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_exception_indicating_that_the_authorization_strategy_could_not_be_found()
            {
                ActualException.ShouldBeExceptionType<Exception>();
                ActualException.Message.ShouldContain("Missing");
            }
        }

        public class When_there_is_no_authorization_strategy_defined_in_the_metadata_for_the_matched_claim
            : TestFixtureBase
        {
            // Supplied values

            // Actual values

            protected override void Act()
            {
                // Execute code under test

                var provider = new EdFiAuthorizationProvider(
                    Given_authorization_metadata_for_resource_claim_and_action_with_authorization_strategy(
                        Resource2ClaimUri,
                        ReadActionUri,
                        null),
                    Given_a_collection_of_unused_authorization_strategies(),
                    Given_a_security_repository_returning_all_actions(),
                    new IExplicitObjectValidator[0]);

                provider.AuthorizeSingleItemAsync(
                    Given_an_authorization_context_for_a_request_to_read_a_resource_with_a_principal(
                        Resource2ClaimUri,
                        Given_a_ClaimsPrincipal_with_a_read_claim_for_resource(Resource2ClaimUri)),
                    CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_exception_indicating_that_no_authorization_strategy_was_defined_in_the_metadata()
            {
                ActualException.ShouldBeExceptionType<Exception>();
                ActualException.Message.ShouldContain("No authorization strategy was defined");
            }
        }

#region Givens

        private static EdFiAuthorizationContext
            Given_an_authorization_context_for_a_request_to_read_a_resource_with_a_principal(
            string resourceClaimUri,
            ClaimsPrincipal principal)
        {
            return new EdFiAuthorizationContext(
                principal,
                new[] {resourceClaimUri},
                ReadActionUri,
                new object());
        }

        private static IResourceAuthorizationMetadataProvider
            Given_authorization_metadata_for_resource_claim_and_action_with_authorization_strategy(
            string resourceClaim,
            string actionUri,
            string authorizationStrategyName)
        {
            var authorizationMetadataProvider = A.Fake<IResourceAuthorizationMetadataProvider>();

            A.CallTo(() => authorizationMetadataProvider.GetResourceClaimAuthorizationMetadata(resourceClaim, actionUri))
               .Returns(
                    new List<ResourceClaimAuthorizationMetadata>
                        {
                            new ResourceClaimAuthorizationMetadata
                            {
                                ClaimName = resourceClaim, AuthorizationStrategy = authorizationStrategyName
                            }
                        }
                       .ToList());

            return authorizationMetadataProvider;
        }

        private static ISecurityRepository Given_a_security_repository_returning_all_actions()
        {
            var securityRepository = A.Fake<ISecurityRepository>();

            A.CallTo(() => securityRepository.GetActionByName("Create"))
                              .Returns(
                                   new Action
                                   {
                                       ActionId = 1, ActionName = "Create", ActionUri = "http://ACTIONS/create"
                                   });

            A.CallTo(() => securityRepository.GetActionByName("Read"))
                              .Returns(
                                   new Action
                                   {
                                       ActionId = 1, ActionName = "Read", ActionUri = "http://ACTIONS/read"
                                   });

            A.CallTo(() => securityRepository.GetActionByName("Update"))
                              .Returns(
                                   new Action
                                   {
                                       ActionId = 1, ActionName = "Update", ActionUri = "http://ACTIONS/update"
                                   });

            A.CallTo(() => securityRepository.GetActionByName("Delete"))
                              .Returns(
                                   new Action
                                   {
                                       ActionId = 1, ActionName = "Delete", ActionUri = "http://ACTIONS/delete"
                                   });

            return securityRepository;
        }

        private static IEdFiAuthorizationStrategy[] Given_a_collection_of_unused_authorization_strategies()
        {
            return new IEdFiAuthorizationStrategy[]
                   {
                       new UnusedAuthorizationStrategy()
                   };
        }

        private static ClaimsPrincipal Given_a_ClaimsPrincipal_with_a_read_claim_for_resource(
            string resourceClaim)
        {
            var claimsIdentity =
                new ClaimsIdentity(
                    new[]
                    {
                        JsonClaimHelper.CreateClaim(
                            resourceClaim,
                            new EdFiResourceClaimValue(ReadActionUri))
                    });

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }

#endregion
    }
}

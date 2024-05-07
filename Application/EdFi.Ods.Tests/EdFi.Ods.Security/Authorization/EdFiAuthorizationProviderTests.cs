// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NoFurtherAuthorization;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters.Hints;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Tests._Extensions;
using EdFi.Security.DataAccess.Repositories;
using EdFi.TestFixture;
using FakeItEasy;
using NHibernate;
using NUnit.Framework;
using Shouldly;
using Test.Common;
using Action = EdFi.Security.DataAccess.Models.Action;
using Helper = EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.AuthorizationTestsHelper;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization
{
    public class FakeEntity : AggregateRootWithCompositeKey { }

    public class FakeRepositoryOperationAuthorizationDecorator<TFakeEntity>
        : RepositoryOperationAuthorizationDecoratorBase<TFakeEntity>
        where TFakeEntity : class
    {
        public FakeRepositoryOperationAuthorizationDecorator(
            IAuthorizationContextProvider authorizationContextProvider,
            IAuthorizationFilteringProvider authorizationFilteringProvider,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
            IApiClientContextProvider apiClientContextProvider,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            IEntityAuthorizer entityAuthorizer)
            : base(
                authorizationContextProvider,
                authorizationFilteringProvider,
                authorizationBasisMetadataSelector,
                apiClientContextProvider,
                dataManagementResourceContextProvider,
                entityAuthorizer)
        { }

        public void AuthorizeSingleItem(TFakeEntity entity, CancellationToken cancellationToken)
        {
            base.AuthorizeExistingSingleItemAsync(entity, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }

    public static class AuthorizationTestsHelper
    {
        public static FakeRepositoryOperationAuthorizationDecorator<FakeEntity> CreateDecorator(
            IAuthorizationContextProvider authorizationContextProvider = null,
            IAuthorizationFilteringProvider authorizationFilteringProvider = null,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector = null,
            IApiClientContextProvider apiClientContextProvider = null,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider = null,
            IEntityAuthorizer entityAuthorizer = null
            )
        {
            return new FakeRepositoryOperationAuthorizationDecorator<FakeEntity>(
                authorizationContextProvider ?? A.Fake<IAuthorizationContextProvider>(),
                authorizationFilteringProvider ?? A.Fake<IAuthorizationFilteringProvider>(),
                authorizationBasisMetadataSelector ?? A.Fake<IAuthorizationBasisMetadataSelector>(),
                apiClientContextProvider ?? A.Fake<IApiClientContextProvider>(),
                dataManagementResourceContextProvider ?? A.Fake<IContextProvider<DataManagementResourceContext>>(),
                entityAuthorizer ?? A.Fake<IEntityAuthorizer>());
        }

        public static EntityAuthorizer CreateEntityAuthorizer(
            IAuthorizationContextProvider authorizationContextProvider = null,
            IAuthorizationFilteringProvider authorizationFilteringProvider = null,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider = null,
            IExplicitObjectValidator[] explicitObjectValidators = null,
            IApiClientContextProvider apiClientContextProvider = null,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector = null,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport = null,
            ISessionFactory sessionFactory = null,
            ISecurityRepository securityRepository = null,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider = null,
            IContextProvider<ViewBasedAuthorizationQueryContext> viewBasedAuthorizationQueryContextProvider = null,
            IAuthorizationViewHintProvider[] authorizationViewHintProviders = null
            )
        {
            return new EntityAuthorizer(
                authorizationContextProvider ?? A.Fake<IAuthorizationContextProvider>(),
                authorizationFilteringProvider ?? A.Fake<IAuthorizationFilteringProvider>(),
                authorizationFilterDefinitionProvider ?? A.Fake<IAuthorizationFilterDefinitionProvider>(),
                explicitObjectValidators ?? A.CollectionOfFake<IExplicitObjectValidator>(0).ToArray(),
                apiClientContextProvider ?? A.Fake<IApiClientContextProvider>(),
                authorizationBasisMetadataSelector ?? A.Fake<IAuthorizationBasisMetadataSelector>(),
                viewBasedSingleItemAuthorizationQuerySupport ?? A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>(),
                sessionFactory ?? A.Fake<ISessionFactory>(),
                securityRepository ?? A.Fake<ISecurityRepository>(),
                dataManagementResourceContextProvider ?? A.Fake<IContextProvider<DataManagementResourceContext>>(),
                viewBasedAuthorizationQueryContextProvider ?? A.Fake<IContextProvider<ViewBasedAuthorizationQueryContext>>(),
                authorizationViewHintProviders ?? A.CollectionOfFake<IAuthorizationViewHintProvider>(0).ToArray());
        }

        public static AuthorizationBasisMetadataSelector CreateAuthorizationBasisMetadataSelector(
            IResourceAuthorizationMetadataProvider resourceAuthorizationMetadataProvider = null,
            ISecurityRepository securityRepository = null,
            IAuthorizationStrategy[] authorizationStrategies = null,
            IClaimSetClaimsProvider claimSetClaimsProvider = null
            )
        {
            return new AuthorizationBasisMetadataSelector(
                resourceAuthorizationMetadataProvider ?? A.Fake<IResourceAuthorizationMetadataProvider>(),
                securityRepository ?? A.Fake<ISecurityRepository>(),
                authorizationStrategies ?? A.CollectionOfFake<IAuthorizationStrategy>(0).ToArray(),
                claimSetClaimsProvider ?? A.Fake<IClaimSetClaimsProvider>());
        }

        public static EdFiResourceClaim CreateResourceClaim(string resourceClaimUri,
                string actionUri,
                string[] authorizationStrategyNameOverrides = null,
                string validationRuleSetNameOverride = null)
        {
            return new EdFiResourceClaim(
                    resourceClaimUri, new EdFiResourceClaimValue { Actions = new[] { new ResourceAction(actionUri, authorizationStrategyNameOverrides, validationRuleSetNameOverride) } });
        }
    }

    [TestFixture]
    public class Feature_Validating_the_incoming_AuthorizationContext
    {
        public abstract class When_attempting_to_authorize : TestFixtureBase
        {
            protected IAuthorizationContextProvider AuthorizationContextProvider;

            protected virtual void Given_an_authorizationContextProvider()
            {
                AuthorizationContextProvider = new AuthorizationContextProvider(new HashtableContextStorage());
            }

            protected virtual void Given_an_authorizationContextProvider(string action)
            {
                Given_an_authorizationContextProvider();
                AuthorizationContextProvider.SetAction(action);
            }

            protected virtual void Given_an_authorizationContextProvider(string action, string[] resourceUris)
            {
                Given_an_authorizationContextProvider(action);
                AuthorizationContextProvider.SetResourceUris(resourceUris);
            }

            protected override void Act()
            {
                var entityAuthorizer = Helper.CreateEntityAuthorizer(AuthorizationContextProvider);

                var decorator = Helper.CreateDecorator(AuthorizationContextProvider, entityAuthorizer: entityAuthorizer);

                decorator.AuthorizeSingleItem(null, CancellationToken.None);
            }
        }

        public class When_attempting_to_authorize_without_an_action_value
            : When_attempting_to_authorize
        {
            protected override void Arrange()
            {
                Given_an_authorizationContextProvider();
            }

            [Assert]
            public void Should_throw_an_ArgumentNullException()
            {
                ActualException.ShouldBeExceptionType<AuthorizationContextException>()
                    .Message.ShouldBe("Authorization cannot be performed because no action has been stored in the current context.");
            }
        }

        public class When_attempting_to_authorize_with_a_null_action
            : When_attempting_to_authorize
        {
            protected override void Arrange()
            {
                Given_an_authorizationContextProvider(null);
            }

            [Assert]
            public void Should_throw_an_ArgumentNullException()
            {
                ActualException.ShouldBeExceptionType<AuthorizationContextException>()
                    .Message.ShouldBe("Authorization cannot be performed because no action has been stored in the current context.");
            }
        }

        public class When_attempting_to_authorize_without_a_resource_value
            : When_attempting_to_authorize
        {
            protected override void Arrange()
            {
                Given_an_authorizationContextProvider("Create");
            }

            [Assert]
            public void Should_throw_an_AuthorizationContextException()
            {
                ActualException.ShouldBeExceptionType<AuthorizationContextException>()
                    .Message.ShouldBe("Authorization cannot be performed because no resource has been stored in the current context.");
            }
        }

        public class When_attempting_to_authorize_with_a_null_resource
            : When_attempting_to_authorize
        {
            protected override void Arrange()
            {
                Given_an_authorizationContextProvider("Create", null);
            }

            [Assert]
            public void Should_throw_an_ArgumentNullException()
            {
                ActualException.ShouldBeExceptionType<AuthorizationContextException>()
                    .Message.ShouldBe("Authorization cannot be performed because no resource has been stored in the current context.");
            }
        }

        public class When_attempting_to_authorize_with_more_than_2_resource_URI_representations
            : When_attempting_to_authorize
        {
            protected override void Arrange()
            {
                Given_an_authorizationContextProvider("actionUri", new[] { "resourceUri1", "resourceUri2", "resourceUri3" });
            }

            protected override void Act()
            {
                var authorizationBasisMetadataSelector = Helper.CreateAuthorizationBasisMetadataSelector();

                var entityAuthorizer = Helper.CreateEntityAuthorizer(AuthorizationContextProvider, authorizationBasisMetadataSelector: authorizationBasisMetadataSelector);

                var decorator = Helper.CreateDecorator(AuthorizationContextProvider, entityAuthorizer: entityAuthorizer);

                decorator.AuthorizeSingleItem(null, CancellationToken.None);
            }

            [Assert]
            public void Should_throw_an_AuthorizationContextException()
            {
                ActualException.ShouldBeOfType<AuthorizationContextException>();
                ActualException.Message.ShouldContain("Unexpected number of Resource URIs found in the authorization context. Expected up to 2, but found 3.");
            }
        }
    }

    [TestFixture]
    public class Feature_Validating_authorization_strategy_naming_conventions
    {
        private class AuthorizationStrategyNotFollowingConventions : IAuthorizationStrategy
        {
            public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(EdFiResourceClaim[] relevantClaims, EdFiAuthorizationContext authorizationContext)
            {
                throw new NotImplementedException();
            }
        }

        private class ConventionFollowingAuthorizationStrategy : IAuthorizationStrategy
        {
            public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(EdFiResourceClaim[] relevantClaims, EdFiAuthorizationContext authorizationContext)
            {
                throw new NotImplementedException();
            }
        }

        private class Convention2FollowingAuthorizationStrategy
            : ConventionFollowingAuthorizationStrategy
        { }

        public abstract class When_creating_the_authorization_provider : TestFixtureBase
        {
            protected IAuthorizationStrategy[] AuthorizationStrategies;

            protected override void Act()
            {
                var selector = Helper.CreateAuthorizationBasisMetadataSelector(
                   authorizationStrategies: AuthorizationStrategies);
            }

            protected void Given_a_collection_of_authorizationStrategies(IAuthorizationStrategy[] authorizationStrategies)
            {
                AuthorizationStrategies = authorizationStrategies;
            }
        }

        public class When_creating_the_authorization_provider_with_all_authorization_strategy_types_whose_names_end_with_AuthorizationStrategy
            : When_creating_the_authorization_provider
        {
            protected override void Arrange()
            {
                Given_a_collection_of_authorizationStrategies(new IAuthorizationStrategy[]
                {
                    new ConventionFollowingAuthorizationStrategy(),
                    new Convention2FollowingAuthorizationStrategy()
                });
            }

            [Assert]
            public void Should_not_throw_an_exception()
            {
                ActualException.ShouldBeNull();
            }
        }

        public class When_creating_the_authorization_provider_with_an_authorization_strategy_type_whose_name_does_not_end_with_AuthorizationStrategy
            : When_creating_the_authorization_provider
        {
            protected override void Arrange()
            {
                Given_a_collection_of_authorizationStrategies(new IAuthorizationStrategy[]
                {
                    new ConventionFollowingAuthorizationStrategy(),
                    new AuthorizationStrategyNotFollowingConventions()
                });
            }

            [Assert]
            public void Should_throw_an_ArgumentException_indicating_that_the_authorization_strategy_doesnt_follow_proper_naming_conventions()
            {
                ActualException.ShouldBeExceptionType<ArgumentException>();
                ActualException.Message.ShouldContain(nameof(AuthorizationStrategyNotFollowingConventions));
            }
        }
    }

    [TestFixture]
    public class Feature_Authorization_strategy_selection
    {
        #region Authorization Strategies

        public abstract class AuthorizationStrategyBase : IAuthorizationStrategy
        {
            public bool FilteringWasCalled { get; private set; }

            public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
                EdFiResourceClaim[] relevantClaims,
                EdFiAuthorizationContext authorizationContext)
            {
                FilteringWasCalled = true;

                return new AuthorizationStrategyFiltering()
                {
                    AuthorizationStrategyName = "Test",
                    Filters = Array.Empty<AuthorizationFilterContext>()
                };
            }
        }

        public class SecondAuthorizationStrategy : AuthorizationStrategyBase { }

        public class AnotherSecondAuthorizationStrategy : AuthorizationStrategyBase { }

        public class FourthAuthorizationStrategy : AuthorizationStrategyBase { }

        public class AnotherFourthAuthorizationStrategy : AuthorizationStrategyBase { }

        public class OverrideAuthorizationStrategy : AuthorizationStrategyBase { }

        public class AnotherOverrideAuthorizationStrategy : AuthorizationStrategyBase { }

        #endregion

        public abstract class When_authorizing_a_request : TestFixtureBase
        {
            protected const string ClaimSetName = "ResourceClaims";

            // Claims represent a lineage (1 is the leaf, 4 is the root)
            protected const string Resource1ClaimUri = @"http://CLAIMS/resource1";
            protected const string Resource2ClaimUri = @"http://CLAIMS/resource2";
            protected const string Resource3ClaimUri = @"http://CLAIMS/resource3";
            protected const string Resource4ClaimUri = @"http://CLAIMS/resource4";

            protected const string CreateActionUri = "http://ACTIONS/create";
            protected const string ReadActionUri = "http://ACTIONS/read";
            protected const string UpdateActionUri = "http://ACTIONS/update";
            protected const string DeleteActionUri = "http://ACTIONS/delete";
            protected const string ReadChangesActionUri = "http://ACTIONS/readChanges";

            protected readonly SecondAuthorizationStrategy SecondAuthorizationStrategy = new SecondAuthorizationStrategy();
            protected readonly AnotherSecondAuthorizationStrategy AnotherSecondAuthorizationStrategy = new AnotherSecondAuthorizationStrategy();

            protected readonly FourthAuthorizationStrategy FourthAuthorizationStrategy = new FourthAuthorizationStrategy();
            protected readonly AnotherFourthAuthorizationStrategy AnotherFourthAuthorizationStrategy = new AnotherFourthAuthorizationStrategy();

            protected readonly OverrideAuthorizationStrategy OverrideAuthorizationStrategy = new OverrideAuthorizationStrategy();
            protected readonly AnotherOverrideAuthorizationStrategy AnotherOverrideAuthorizationStrategy = new AnotherOverrideAuthorizationStrategy();

            // Define all authorization strategies
            protected IAuthorizationStrategy[] AuthorizationStrategies;
            protected ISecurityRepository SecurityRepository;
            protected IClaimSetClaimsProvider ClaimSetClaimsProvider;
            protected IAuthorizationContextProvider AuthorizationContextProvider;
            protected IApiClientContextProvider ApiClientContextProvider;
            protected AuthorizationFilteringProvider AuthorizationFilteringProvider;
            protected IResourceAuthorizationMetadataProvider ResourceAuthorizationMetadataProvider;
            protected IAuthorizationBasisMetadataSelector AuthorizationBasisMetadataSelector;
            protected FakeRepositoryOperationAuthorizationDecorator<FakeEntity> RepositoryOperationAuthorizationDecorator;

            protected When_authorizing_a_request()
            {
                SecurityRepository = Given_a_security_repository_returning_all_actions_and_appropriate_claim_name_lineage();

                AuthorizationStrategies = new IAuthorizationStrategy[]
                {
                    SecondAuthorizationStrategy,
                    AnotherSecondAuthorizationStrategy,
                    FourthAuthorizationStrategy,
                    AnotherFourthAuthorizationStrategy,
                    OverrideAuthorizationStrategy,
                    AnotherOverrideAuthorizationStrategy
                };

                ApiClientContextProvider = Given_an_apiClientContextProvider();

                AuthorizationFilteringProvider = new AuthorizationFilteringProvider();
            }

            private IApiClientContextProvider Given_an_apiClientContextProvider()
            {
                var apiClientContextProvider = Stub<IApiClientContextProvider>();

                var apiClientContext = Stub<ApiClientContext>(x =>
                    x.WithArgumentsForConstructor(new object[] {
                            null, ClaimSetName, null, null, null, null, null, null, null, 0 })
                    );

                A.CallTo(() => apiClientContextProvider.GetApiClientContext())
                    .Returns(apiClientContext);

                return apiClientContextProvider;
            }

            private ISecurityRepository Given_a_security_repository_returning_all_actions_and_appropriate_claim_name_lineage()
            {
                var securityRepository = Stub<ISecurityRepository>();

                A.CallTo(() => securityRepository.GetActionByName("Create"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "Create",
                            ActionUri = CreateActionUri
                        });

                A.CallTo(() => securityRepository.GetActionByName("Read"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "Read",
                            ActionUri = ReadActionUri
                        });

                A.CallTo(() => securityRepository.GetActionByName("Update"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "Update",
                            ActionUri = UpdateActionUri
                        });

                A.CallTo(() => securityRepository.GetActionByName("Delete"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "Delete",
                            ActionUri = DeleteActionUri
                        });

                A.CallTo(() => securityRepository.GetActionByName("ReadChanges"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "ReadChanges",
                            ActionUri = ReadChangesActionUri
                        });

                // NOTE: These mocks create results for a implied resource claim lineage where Resource 1 is the lowest level claim,
                // and Resource Claim 4 is the highest level claim.
                //
                //     Resource4 
                //         ↑
                //     Resource3
                //         ↑
                //     Resource2
                //         ↑
                //     Resource1
                //
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

            protected void Given_a_claimSetProvider(EdFiResourceClaim[] resourceClaims)
            {
                var claimSetClaimsProvider = Stub<IClaimSetClaimsProvider>();

                A.CallTo(() => claimSetClaimsProvider.GetClaims(ClaimSetName))
                    .Returns(resourceClaims);

                ClaimSetClaimsProvider = claimSetClaimsProvider;
            }

            protected virtual void Given_an_authorizationContextProvider(string action, string[] resourceUris)
            {
                AuthorizationContextProvider = new AuthorizationContextProvider(new HashtableContextStorage());

                AuthorizationContextProvider.SetAction(action);
                AuthorizationContextProvider.SetResourceUris(resourceUris);
            }

            protected virtual void Given_an_AuthorizationBasisMetadataSelector()
            {
                AuthorizationBasisMetadataSelector = new AuthorizationBasisMetadataSelector(
                    ResourceAuthorizationMetadataProvider,
                    SecurityRepository,
                    AuthorizationStrategies,
                    ClaimSetClaimsProvider);
            }

            protected virtual void Given_a_RepositoryOperationAuthorizationDecorator()
            {
                var entityAuthorizer = Helper.CreateEntityAuthorizer(
                    AuthorizationContextProvider,
                    authorizationFilteringProvider: AuthorizationFilteringProvider,
                    apiClientContextProvider: ApiClientContextProvider,
                    authorizationBasisMetadataSelector: AuthorizationBasisMetadataSelector,
                    securityRepository: SecurityRepository);

                RepositoryOperationAuthorizationDecorator = Helper.CreateDecorator(
                    AuthorizationContextProvider,
                    authorizationFilteringProvider: AuthorizationFilteringProvider,
                    authorizationBasisMetadataSelector: AuthorizationBasisMetadataSelector,
                    apiClientContextProvider: ApiClientContextProvider,
                    entityAuthorizer: entityAuthorizer);
            }
        }

        // ================ Begin Authorization Strategy Override Scenarios ===============
        public abstract class When_authorizing_a_request_affected_by_authorization_strategies : When_authorizing_a_request
        {
            protected void Given_a_ResourceAuthorizationMetadataProvider()
            {
                // Set metadata with 4 data claims, with Resource 3 not having an authorization strategy.
                ResourceAuthorizationMetadataProvider = Stub<IResourceAuthorizationMetadataProvider>();

                var resourceClaim = AuthorizationContextProvider.GetResourceUris().Single();
                var actionUri = AuthorizationContextProvider.GetAction();

                A.CallTo(() => ResourceAuthorizationMetadataProvider.GetResourceClaimAuthorizationMetadata(resourceClaim, actionUri))
                    .Returns(
                        new List<ResourceClaimAuthorizationMetadata>
                            {
                                    new ResourceClaimAuthorizationMetadata
                                    {
                                        ClaimName = Resource1ClaimUri, AuthorizationStrategies = null //"First"
                                    },
                                    new ResourceClaimAuthorizationMetadata
                                    {
                                        ClaimName = Resource2ClaimUri, AuthorizationStrategies = new [] { "Second", "AnotherSecond" }
                                    },
                                    new ResourceClaimAuthorizationMetadata
                                    {
                                        ClaimName = Resource3ClaimUri, AuthorizationStrategies = null
                                    },
                                    new ResourceClaimAuthorizationMetadata
                                    {
                                        ClaimName = Resource4ClaimUri, AuthorizationStrategies = new [] { "Fourth", "AnotherFourth" }
                                    }
                            }

                            // Trim out lineage from bottom up to incoming claim name
                            .SkipWhile(
                                rcas => !rcas.ClaimName.Equals(resourceClaim, StringComparison.InvariantCultureIgnoreCase))
                            .ToList());
            }
        }

        public class When_authorizing_a_request_for_a_resource_with_a_default_authorization_strategy_defined
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            private IEnumerable<string> _actualAuthorizationStrategyNames;

            protected override void Act()
            {
                // Caller has Read access to Resource 4 (the top level claim)
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource4ClaimUri, ReadActionUri)
                });

                // Request is for Read access to Resource 2 (lower level claim)
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource2ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                var actualMetadataForAuthorization = AuthorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
                    ClaimSetName, new List<string> { Resource2ClaimUri }, ReadActionUri);

                _actualAuthorizationStrategyNames = actualMetadataForAuthorization.AuthorizationStrategies
                    .Select(strat => strat.GetType().Name)
                    .ToArray();
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_authorization_strategies_assigned_to_the_requested_resource_claim()
            {
                _actualAuthorizationStrategyNames.ShouldBeEquivalentTo(
                    new[]
                    {
                            nameof(Feature_Authorization_strategy_selection.SecondAuthorizationStrategy),
                            nameof(Feature_Authorization_strategy_selection.AnotherSecondAuthorizationStrategy)
                    });
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_default_authorization_strategies_from_higher_up_hierarchy()
            {
                _actualAuthorizationStrategyNames.ShouldSatisfyAllConditions(
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.FourthAuthorizationStrategy)),
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.AnotherFourthAuthorizationStrategy))
                );
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                _actualAuthorizationStrategyNames.ShouldSatisfyAllConditions(
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.OverrideAuthorizationStrategy)),
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.AnotherOverrideAuthorizationStrategy))
                );
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_with_an_explicit_authorization_strategy_defined_that_is_BELOW_the_callers_claim_with_an_authorization_override_defined
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4 (top level claim), with 2 auth strategies applied as an override
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource4ClaimUri, ReadActionUri, authorizationStrategyNameOverrides: new[] { "Override", "AnotherOverride" })
                });

                // Request is for Read access to Resource 2
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource2ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_override_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue(),
                    () => AnotherOverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_the_default_authorization_strategies_of_the_requested_resource()
            {
                "".ShouldSatisfyAllConditions(
                    () => SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherSecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherFourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_with_an_explicit_authorization_strategy_defined_that_is_ABOVE_one_of_the_callers_claim_with_an_authorization_override_defined
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            private string[] _actualAuthorizationStrategyNames;

            protected override void Act()
            {
                // Caller has claims for Resources 1 and 3 (intentionally supplied out of order)
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    // The "out of order" of these claims is intentional and is testing that the match is
                    // made on the first matching claim based on the authorization metadata hierarchy
                    // rather than the order in which the claims are issued to the caller in the claim set.
                    // In this test data, Resource2 is "lower" than Resource3 in the hierarchy, and should be the one matched first.
                    Helper.CreateResourceClaim(Resource3ClaimUri, ReadActionUri),

                    // This claim is "below" requested resource, so it should be ignored
                    // (NOTE: This will not happen with the current implementation of the API, but has been added for full coverage/definition of expected behavior)
                    Helper.CreateResourceClaim(Resource1ClaimUri, ReadActionUri, authorizationStrategyNameOverrides: new[] { "Override", "AnotherOverride" })
                });

                // Request is for Read access to Resource 2
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource2ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                var actualMetadataForAuthorization = AuthorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(ClaimSetName, new List<string> { Resource2ClaimUri }, ReadActionUri);

                _actualAuthorizationStrategyNames = actualMetadataForAuthorization.AuthorizationStrategies
                    .Select(strat => strat.GetType().Name)
                    .ToArray();
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_strategy_obtained_from_the_next_lowest_level_resource_claim_with_an_assigned_authorization_strategy()
            {
                _actualAuthorizationStrategyNames.ShouldBeEquivalentTo(
                    new[]
                    {
                            nameof(Feature_Authorization_strategy_selection.SecondAuthorizationStrategy),
                            nameof(Feature_Authorization_strategy_selection.AnotherSecondAuthorizationStrategy)
                    });
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_the_lower_level_resource_overridden_authorization_strategies()
            {
                _actualAuthorizationStrategyNames.ShouldSatisfyAllConditions(
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.OverrideAuthorizationStrategy)),
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.AnotherOverrideAuthorizationStrategy))
                );
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                _actualAuthorizationStrategyNames.ShouldSatisfyAllConditions(
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.FourthAuthorizationStrategy)),
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.AnotherFourthAuthorizationStrategy))
                );
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_authorization_strategy_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_BELOW_the_callers_assigned_claim_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource4ClaimUri, ReadActionUri)
                });

                // Request is for Read access to Resource 1
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource1ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_strategy_obtained_from_the_next_lowest_level_resource_claim_with_an_assigned_authorization_strategy()
            {
                "".ShouldSatisfyAllConditions(
                    () => SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue(),
                    () => AnotherSecondAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_the_top_level_claims_default_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherFourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherOverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_a_default_authorization_strategy_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_ABOVE_the_callers_assigned_claim_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 3
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource3ClaimUri, ReadActionUri)
                });

                // Request is for Read access to Resource 3
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource3ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
            }

            [Assert]
            public void
                Should_attempt_to_authorize_using_the_strategy_obtained_from_the_next_higher_level_resource_claim_with_an_assigned_authorization_strategy()
            {
                "".ShouldSatisfyAllConditions(
                    () => FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue(),
                    () => AnotherFourthAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherSecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherOverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_authorization_strategy_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_BELOW_the_callers_assigned_claim_with_an_authorization_strategy_override_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 4, with overrides
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource4ClaimUri, ReadActionUri, authorizationStrategyNameOverrides: new[] { "Override", "AnotherOverride" })
                });

                // Request is for Read access to Resource 1
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource1ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_override_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue(),
                    () => AnotherOverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_the_default_authorization_strategies_on_an_intermediate_resource()
            {
                "".ShouldSatisfyAllConditions(
                    () => SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherSecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherFourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_authorization_strategy_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_ABOVE_the_callers_assigned_claim_with_an_authorization_strategy_override_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has Read access to Resource 3, with overrides
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource3ClaimUri, ReadActionUri, authorizationStrategyNameOverrides: new[] { "Override", "AnotherOverride" })
                });

                // Request is for Read access to Resource 3
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource3ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
            }

            [Assert]
            public void Should_attempt_to_authorize_using_the_override_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue(),
                    () => AnotherOverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_the_higher_level_claims_default_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherFourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherSecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }
        }

        public class When_authorizing_a_request_for_which_the_principal_has_multiple_matching_claims
            : When_authorizing_a_request_affected_by_authorization_strategies
        {
            protected override void Act()
            {
                // Caller has claims for Resources 2 and 3 (out of order)
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    // The "out of order" of these claims is intentional and is testing that the match is
                    // made on the first matching claim based on the authorization metadata hierarchy
                    // rather than the order in which the claims are issued to the caller in the claim set.
                    // In this case, Resource2 is "lower" in the hierarchy, and should be the one matched first.
                    Helper.CreateResourceClaim(Resource3ClaimUri, ReadActionUri),
                    Helper.CreateResourceClaim(Resource2ClaimUri, ReadActionUri)
                });

                // Request is for Read access to Resource 1
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource1ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
            }

            [Assert]
            public void
                Should_resolve_claims_using_authorization_metadata_order_rather_than_callers_claims_order_and_invoke_lowest_matching_claims_authorization_strategy()
            {
                "".ShouldSatisfyAllConditions(
                    () => SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue(),
                    () => AnotherSecondAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_the_higher_level_claim_default_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherFourthAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
            }

            [Assert]
            public void Should_not_attempt_to_authorize_using_any_other_authorization_strategies()
            {
                "".ShouldSatisfyAllConditions(
                    () => OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse(),
                    () => AnotherOverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse());
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
            protected FakeExplicitObjectValidator FakeExplicitObjectValidator1 = new();
            protected FakeExplicitObjectValidator FakeExplicitObjectValidator2 = new();

            protected void Given_a_ResourceAuthorizationMetadataProvider()
            {
                // Set metadata with 4 data claims, with Resource 3 not having an authorization strategy.
                ResourceAuthorizationMetadataProvider = Stub<IResourceAuthorizationMetadataProvider>();

                var resourceClaim = AuthorizationContextProvider.GetResourceUris().Single();
                var actionUri = AuthorizationContextProvider.GetAction();

                A.CallTo(() => ResourceAuthorizationMetadataProvider.GetResourceClaimAuthorizationMetadata(resourceClaim, actionUri))
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

                                        // We need an authorization strategy defined somewhere in the lineage
                                        AuthorizationStrategies = new List<string> { "Fourth" }
                                    }
                            }

                            // Trim out lineage from bottom up to incoming claim name
                            .SkipWhile(
                                rcas => !rcas.ClaimName.Equals(resourceClaim, StringComparison.InvariantCultureIgnoreCase))
                            .ToList());
            }

            protected override void Given_a_RepositoryOperationAuthorizationDecorator()
            {
                var entityAuthorizer = Helper.CreateEntityAuthorizer(
                    AuthorizationContextProvider,
                    authorizationFilteringProvider: AuthorizationFilteringProvider,
                    explicitObjectValidators: new IExplicitObjectValidator[]
                    {
                            FakeExplicitObjectValidator1,
                            FakeExplicitObjectValidator2
                    },
                    apiClientContextProvider: ApiClientContextProvider,
                    authorizationBasisMetadataSelector: AuthorizationBasisMetadataSelector,
                    securityRepository: SecurityRepository);

                RepositoryOperationAuthorizationDecorator = Helper.CreateDecorator(
                    AuthorizationContextProvider,
                    authorizationFilteringProvider: AuthorizationFilteringProvider,
                    authorizationBasisMetadataSelector: AuthorizationBasisMetadataSelector,
                    apiClientContextProvider: ApiClientContextProvider,
                    entityAuthorizer: entityAuthorizer);
            }
        }

        public class When_authorizing_a_request_for_a_resource_with_an_explicit_validation_rule_set_defined
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            private string[] _actualAuthorizationStrategyNames;

            protected override void Act()
            {
                // Caller has Create access to Resource 4
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource4ClaimUri, CreateActionUri)
                });

                // Initialize authorization context provider with only the action
                Given_an_authorizationContextProvider(CreateActionUri, new[] { Resource2ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);

                var actualMetadataForAuthorization = AuthorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(ClaimSetName, new List<string> { Resource2ClaimUri }, CreateActionUri);

                _actualAuthorizationStrategyNames = actualMetadataForAuthorization.AuthorizationStrategies
                    .Select(strat => strat.GetType().Name)
                    .ToArray();
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
                _actualAuthorizationStrategyNames.ShouldSatisfyAllConditions(
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.OverrideAuthorizationStrategy)),
                    () => _actualAuthorizationStrategyNames.ShouldNotContain(nameof(Feature_Authorization_strategy_selection.SecondAuthorizationStrategy)),
                    () => _actualAuthorizationStrategyNames.ShouldContain(nameof(Feature_Authorization_strategy_selection.FourthAuthorizationStrategy))
                );
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_with_an_explicit_validation_rule_set_defined_that_is_BELOW_the_callers_claim_with_an_authorization_override_defined
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Create access to Resource 4
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource4ClaimUri, CreateActionUri, validationRuleSetNameOverride: "OverrideRuleSet")
                });

                // Request is for Create access to Resource 2
                Given_an_authorizationContextProvider(CreateActionUri, new[] { Resource2ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
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
                OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_with_an_explicit_validation_rule_set_defined_that_is_ABOVE_one_of_the_callers_claim_with_an_authorization_override_defined
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has claims for Resources 1 and 3 (out of order)
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    // The "out of order" of these claims is intentional and is testing that the match is
                    // made on the first matching claim based on the authorization metadata hierarchy
                    // rather than the order in which the claims are issued to the caller in the claim set.
                    // In this case, Resource2 is "lower" in the hierarchy, and should be the one matched first.
                    Helper.CreateResourceClaim(Resource3ClaimUri, CreateActionUri),

                    // This claim is "below" requested resource, so it should be ignored
                    // (NOTE: This will not happen with the current implementation of the API, but has been added for full coverage/definition of expected behavior)
                    Helper.CreateResourceClaim(Resource1ClaimUri, CreateActionUri, validationRuleSetNameOverride: "OverrideRuleSet")
                });

                // Request is for Create access to Resource 2
                Given_an_authorizationContextProvider(CreateActionUri, new[] { Resource2ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
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
                OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_validation_rule_set_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_BELOW_the_callers_assigned_claim_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Create access to Resource 4
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource4ClaimUri, CreateActionUri)
                });

                // Request is for Create access to Resource 1
                Given_an_authorizationContextProvider(CreateActionUri, new[] { Resource1ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
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
                OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_validation_rule_set_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_ABOVE_the_callers_assigned_claim_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Create access to Resource 3
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource3ClaimUri, CreateActionUri)
                });

                // Request is for Create access to Resource 3
                Given_an_authorizationContextProvider(CreateActionUri, new[] { Resource3ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
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
                OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_validation_rule_set_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_BELOW_the_callers_assigned_claim_with_a_validation_rule_set_override_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Create access to Resource 4
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource4ClaimUri, CreateActionUri, validationRuleSetNameOverride: "OverrideRuleSet")
                });

                // Request is for Create access to Resource 1
                Given_an_authorizationContextProvider(CreateActionUri, new[] { Resource1ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
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
                OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue();
            }
        }

        public class
            When_authorizing_a_request_for_a_resource_without_an_explicit_validation_rule_set_defined_but_with_a_parent_resource_claim_with_one_defined_that_is_ABOVE_the_callers_assigned_claim_with_a_validation_rule_set_override_in_the_taxonomy
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has Create access to Resource 3
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource3ClaimUri, CreateActionUri, validationRuleSetNameOverride: "OverrideRuleSet")
                });

                // Request is for Create access to Resource 3
                Given_an_authorizationContextProvider(CreateActionUri, new[] { Resource3ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
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
                OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue();
            }
        }

        public class When_authorizing_a_request_for_which_the_principal_has_multiple_matching_claims_with_a_validation_rule_set_override_defined
            : When_authorizing_a_request_affected_by_authorization_validation_rule_sets
        {
            protected override void Act()
            {
                // Caller has claims for Resources 2 and 3 (out of order)
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    // The "out of order" of these claims is intentional and is testing that the match is
                    // made on the first matching claim based on the authorization metadata hierarchy
                    // rather than the order in which the claims are issued to the caller in the claim set.
                    // In this case, Resource2 is "lower" in the hierarchy, and should be the one matched first.
                    Helper.CreateResourceClaim(Resource3ClaimUri, CreateActionUri),
                    Helper.CreateResourceClaim(Resource2ClaimUri, CreateActionUri)
                });

                // Request is for Create access to Resource 1
                Given_an_authorizationContextProvider(CreateActionUri, new[] { Resource1ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider();
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
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
                OverrideAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                SecondAuthorizationStrategy.FilteringWasCalled.ShouldBeFalse();
                FourthAuthorizationStrategy.FilteringWasCalled.ShouldBeTrue();
            }
        }

        // ================ Begin Detecting Missing or Undefined Authorization Strategy Scenarios ===============
        public class UnusedAuthorizationStrategy : AuthorizationStrategyBase { }

        public abstract class When_authorizing_a_request_with_missing_or_undefined_authorization_strategies
            : When_authorizing_a_request
        {
            protected void Given_a_ResourceAuthorizationMetadataProvider(string[] authorizationStrategyNames = null)
            {
                ResourceAuthorizationMetadataProvider = Stub<IResourceAuthorizationMetadataProvider>();

                var resourceClaim = AuthorizationContextProvider.GetResourceUris().Single();
                var actionUri = AuthorizationContextProvider.GetAction();

                A.CallTo(() => ResourceAuthorizationMetadataProvider.GetResourceClaimAuthorizationMetadata(resourceClaim, actionUri))
                    .Returns(
                        new List<ResourceClaimAuthorizationMetadata>
                            {
                                new ResourceClaimAuthorizationMetadata
                                {
                                    ClaimName = resourceClaim,
                                    AuthorizationStrategies  = authorizationStrategyNames
                                }
                            }
                    .ToList());
            }

            protected override void Given_an_AuthorizationBasisMetadataSelector()
            {
                AuthorizationBasisMetadataSelector = new AuthorizationBasisMetadataSelector(
                    ResourceAuthorizationMetadataProvider,
                    SecurityRepository,
                    new IAuthorizationStrategy[]
                    {
                        new UnusedAuthorizationStrategy()
                    },
                    ClaimSetClaimsProvider);
            }
        }

        public class When_no_matching_authorization_strategy_implementation_can_be_found
            : When_authorizing_a_request_with_missing_or_undefined_authorization_strategies
        {
            protected override void Act()
            {
                Given_a_claimSetProvider(new EdFiResourceClaim[] {
                    Helper.CreateResourceClaim(Resource1ClaimUri, ReadActionUri, authorizationStrategyNameOverrides: new[] { "Missing", "AnotherMissing" })
                });

                // Request is for Read access to Resource 1
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource1ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider(new[] { "Missing", "AnotherMissing" });
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
            }

            [Assert]
            public void Should_throw_exception_indicating_that_the_authorization_strategy_could_not_be_found()
            {
                ActualException.ShouldBeExceptionType<Exception>()
                    .Message.ShouldBe("Could not find authorization implementation for strategy 'Missing' based on naming convention of '{strategyName}AuthorizationStrategy'.");
            }
        }

        public class When_there_is_no_authorization_strategies_defined_in_the_metadata_for_the_matched_claim
            : When_authorizing_a_request_with_missing_or_undefined_authorization_strategies
        {
            protected override void Act()
            {
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource2ClaimUri, ReadActionUri, authorizationStrategyNameOverrides: Array.Empty<string>())
                });

                // Request is for Read access to Resource 2
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource2ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider(Array.Empty<string>());
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
            }

            [Assert]
            public void Should_throw_exception_indicating_that_no_authorization_strategy_were_defined_in_the_metadata()
            {
                ActualException.ShouldBeExceptionType<Exception>()
                    .Message.ShouldBe($"No authorization strategies were defined for the requested action '{ReadActionUri}' against resource URIs ['{Resource2ClaimUri}'] matched by the caller's claim '{Resource2ClaimUri}'.");
            }
        }

        public class When_there_is_no_value_present_for_the_authorization_strategies_defined_in_the_metadata_for_the_matched_claim
            : When_authorizing_a_request_with_missing_or_undefined_authorization_strategies
        {
            protected override void Act()
            {
                Given_a_claimSetProvider(new EdFiResourceClaim[]
                {
                    Helper.CreateResourceClaim(Resource2ClaimUri, ReadActionUri, authorizationStrategyNameOverrides: null)
                });

                // Request is for Read access to Resource 2
                Given_an_authorizationContextProvider(ReadActionUri, new[] { Resource2ClaimUri });

                // Set the strategy metadata provider, using the authorization context values
                Given_a_ResourceAuthorizationMetadataProvider(null);
                Given_an_AuthorizationBasisMetadataSelector();

                Given_a_RepositoryOperationAuthorizationDecorator();

                RepositoryOperationAuthorizationDecorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
            }

            [Assert]
            public void Should_throw_exception_indicating_that_no_authorization_strategy_were_defined_in_the_metadata()
            {
                ActualException.ShouldBeExceptionType<Exception>()
                    .Message.ShouldBe($"No authorization strategies were defined for the requested action '{ReadActionUri}' against resource URIs ['{Resource2ClaimUri}'] matched by the caller's claim '{Resource2ClaimUri}'.");
            }
        }
    }

    [TestFixture]
    public class Feature_Authorizing_requests_focusing_on_actions
    {
        public abstract class When_authorizing : TestFixtureBase
        {
            protected const string TestResource = "http://ed-fi.org/ods/resource/test";
            protected const string ClaimSetName = "TestClaimSet";

            protected string SuppliedPrincipalClaim;
            protected string SuppliedPrincipalAction;
            protected string SuppliedRequestedAction;
            protected string SuppliedResourceAuthorizationClaim;
            protected string SuppliedResourceAuthorizationStrategy;
            private IAuthorizationContextProvider _suppliedAuthorizationContextProvider;
            private IResourceAuthorizationMetadataProvider _resourceAuthorizationMetadataProvider;
            private ISecurityRepository _securityRepository;
            private IClaimSetClaimsProvider _claimSetClaimsProvider;
            private IApiClientContextProvider _apiClientContextProvider;
            private AuthorizationFilteringProvider _authorizationFilteringProvider;

            protected override void Arrange()
            {
                SetPrincipalAndStrategyAndContextValues();

                var suppliedResourceClaimsAuthorizationStrategyMetadata =
                    GetEdFiClaimsAuthorizationStrategyMetadata(SuppliedResourceAuthorizationStrategy, SuppliedResourceAuthorizationClaim);

                _suppliedAuthorizationContextProvider = GetAuthorizationContextProvider(SuppliedRequestedAction);

                _claimSetClaimsProvider = GetClaimsPrincipal();

                _resourceAuthorizationMetadataProvider = Stub<IResourceAuthorizationMetadataProvider>();

                A.CallTo(() => _resourceAuthorizationMetadataProvider.GetResourceClaimAuthorizationMetadata(A<string>.Ignored, A<string>.Ignored))
                    .Returns(suppliedResourceClaimsAuthorizationStrategyMetadata);

                _securityRepository = Stub<ISecurityRepository>();

                A.CallTo(() => _securityRepository.GetActionByName("Create"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "Create",
                            ActionUri = "http://ed-fi.org/ods/actions/create"
                        });

                A.CallTo(() => _securityRepository.GetActionByName("Read"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "Read",
                            ActionUri = "http://ed-fi.org/ods/actions/read"
                        });

                A.CallTo(() => _securityRepository.GetActionByName("Update"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "Update",
                            ActionUri = "http://ed-fi.org/ods/actions/update"
                        });

                A.CallTo(() => _securityRepository.GetActionByName("Delete"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "Delete",
                            ActionUri = "http://ed-fi.org/ods/actions/delete"
                        });

                A.CallTo(() => _securityRepository.GetActionByName("ReadChanges"))
                    .Returns(
                        new Action
                        {
                            ActionId = 1,
                            ActionName = "ReadChanges",
                            ActionUri = "http://ed-fi.org/ods/actions/readChanges"
                        });

                _authorizationFilteringProvider = new AuthorizationFilteringProvider();

                _apiClientContextProvider = Stub<IApiClientContextProvider>();

                var apiClientContext = Stub<ApiClientContext>(x =>
                    x.WithArgumentsForConstructor(new object[] {
                            null, ClaimSetName, null, null, null, null, null, null, null, 0 })
                    );

                A.CallTo(() => _apiClientContextProvider.GetApiClientContext())
                    .Returns(apiClientContext);
            }

            protected override void Act()
            {
                var authorizationBasisMetadataSelector = Helper.CreateAuthorizationBasisMetadataSelector(
                    _resourceAuthorizationMetadataProvider,
                    _securityRepository,
                    GetAuthorizationStrategies(),
                    _claimSetClaimsProvider);

                var entityAuthorizer = Helper.CreateEntityAuthorizer(
                    _suppliedAuthorizationContextProvider,
                    authorizationFilteringProvider: _authorizationFilteringProvider,
                    apiClientContextProvider: _apiClientContextProvider,
                    authorizationBasisMetadataSelector: authorizationBasisMetadataSelector,
                    securityRepository: _securityRepository);

                var decorator = Helper.CreateDecorator(
                    _suppliedAuthorizationContextProvider,
                    authorizationFilteringProvider: _authorizationFilteringProvider,
                    authorizationBasisMetadataSelector: authorizationBasisMetadataSelector,
                    apiClientContextProvider: _apiClientContextProvider,
                    entityAuthorizer: entityAuthorizer);

                decorator.AuthorizeSingleItem(new FakeEntity(), CancellationToken.None);
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
                        new()
                        {
                            ClaimName = claim,
                            AuthorizationStrategies = new List<string> { strategy }
                        }
                    };
            }

            //The context to authorize.
            protected virtual IAuthorizationContextProvider GetAuthorizationContextProvider(string action)
            {
                return GetAuthorizationContextProvider(TestResource, action);
            }

            protected virtual IAuthorizationContextProvider GetAuthorizationContextProvider(string resource, string action)
            {
                var _authorizationContextProvider = new AuthorizationContextProvider(new HashtableContextStorage());

                _authorizationContextProvider.SetAction(action);
                _authorizationContextProvider.SetResourceUris(new[] { resource });

                return _authorizationContextProvider;
            }

            protected virtual IClaimSetClaimsProvider GetClaimsPrincipal()
            {
                return GetClaimsPrincipal(SuppliedPrincipalClaim, SuppliedPrincipalAction);
            }

            protected virtual IClaimSetClaimsProvider GetClaimsPrincipal(string claim, string action)
            {
                var claimSetClaimsProvider = Stub<IClaimSetClaimsProvider>();

                EdFiResourceClaim[] resourceClaims =
                {
                    Helper.CreateResourceClaim(claim, action)
                };

                A.CallTo(() => claimSetClaimsProvider.GetClaims(ClaimSetName))
                    .Returns(resourceClaims);

                return claimSetClaimsProvider;
            }

            protected virtual IAuthorizationStrategy[] GetAuthorizationStrategies()
            {
                return new IAuthorizationStrategy[]
                {
                        new RelationshipsWithEdOrgsAndPeopleAuthorizationStrategy<RelationshipsAuthorizationContextData>(
                            Stub<IDomainModelProvider>()
                            )
                        {
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
                // If the principal doesn't have the right claim for the resource it should fail.
                SuppliedPrincipalClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiDescriptors";
                SuppliedResourceAuthorizationClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";

                SuppliedPrincipalAction = "Not relevant for this test.";
                SuppliedRequestedAction = "Not relevant for this test.";
                SuppliedResourceAuthorizationStrategy = "Not relevant for this test.";
            }

            [Assert]
            public void Should_throw_exception()
            {
                var exception = (SecurityAuthorizationException)ActualException.ShouldBeExceptionType<SecurityAuthorizationException>();
                exception.Detail.ShouldContain("Access to the data could not be authorized. You do not have permissions to access this data.");
                exception.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "security:authorization:access-denied:resource"));
                exception.Message.ShouldContain($"The API client's assigned claim set (currently '{ClaimSetName}') must " +
                    $"include one of the following data claims to provide access to this data: '{SuppliedResourceAuthorizationClaim}'.");
            }
        }

        public class When_authorizing_with_a_matching_claim_but_without_a_matching_action
            : When_authorizing
        {
            protected override void SetPrincipalAndStrategyAndContextValues()
            {
                // If the principal doesn't have the right claim for the resource it should fail.
                SuppliedPrincipalClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";
                SuppliedResourceAuthorizationClaim = "http://ed-fi.org/ods/identity/claims/domains/edFiTypes";

                SuppliedPrincipalAction = "http://ed-fi.org/ods/actions/read";
                SuppliedRequestedAction = "http://ed-fi.org/ods/actions/create";

                SuppliedResourceAuthorizationStrategy = "Not relevant for this test.";
            }

            [Assert]
            public void Should_throw_exception_indicating_authorization_failed_for_the_requested_action()
            {
                var exception = (SecurityAuthorizationException)ActualException.ShouldBeExceptionType<SecurityAuthorizationException>();
                exception.Detail.ShouldContain("Access to the data could not be authorized. You do not have permissions to perform the requested operation on the data.");
                exception.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "security:authorization:access-denied:action"));
                exception.Message.ShouldContain($"The API client's assigned claim set (currently '{ClaimSetName}') must grant permission of the '{SuppliedRequestedAction}' action on one of the following data claims: '{SuppliedResourceAuthorizationClaim}'.");
            }
        }
    }
}

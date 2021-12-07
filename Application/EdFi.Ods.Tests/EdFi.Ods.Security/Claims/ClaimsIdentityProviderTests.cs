// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Tests._Extensions;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;
using EdFi.TestFixture;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Claims
{
    public class ClaimsIdentityProviderTests
    {
        public class When_creating_a_ClaimsIdentity_with_no_API_key_context_available : TestFixtureBase
        {
            // Supplied values

            // Actual values

            // Dependencies

            /// <summary>
            /// Executes the code to be tested.
            /// </summary>
            protected override void Act()
            {
                var apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();
                A.CallTo(() => apiKeyContextProvider.GetApiKeyContext()).Returns(ApiKeyContext.Empty);

                var provider = new ClaimsIdentityProvider(apiKeyContextProvider, null);
                var unused = provider.GetClaimsIdentity();
            }

            [Assert]
            public void Should_throw_an_EdFiSecurityException_related_to_the_missing_API_key_context()
            {
                ActualException.ShouldBeExceptionType<EdFiSecurityException>();
                ActualException.MessageShouldContain("API key");
            }
        }

        public class When_creating_a_ClaimsIdentity_for_a_caller_with_associated_education_organizations : TestFixtureBase
        {
            // Supplied values
            private readonly List<int> _suppliedEducationOrganizationIds = new List<int>
            {
                1,
                2
            };
            private readonly List<string> _suppliedNamespacePrefixes = new List<string> { "namespacePrefix1" };
            private readonly List<string> _suppliedProfiles = new List<string>
            {
                "supplied-assigned-profile",
                "supplied-assigned-profile-2"
            };

            // Actual values
            private ClaimsIdentity _actualIdentity;

            // Dependencies
            private IApiKeyContextProvider _apiKeyContextProvider;
            private ISecurityRepository _securityRepository;

            protected override void Arrange()
            {
                // Initialize dependencies

                const string suppliedClaimSetName = "claimSetName";

                var apiKeyContext = new ApiKeyContext(
                    "apiKey",
                    suppliedClaimSetName,
                    _suppliedEducationOrganizationIds,
                    _suppliedNamespacePrefixes,
                    _suppliedProfiles,
                    null, null, null);

                _apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();
                A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext()).Returns(apiKeyContext);

                var suppliedResourceClaims = new List<ClaimSetResourceClaimAction>
                {
                    new ClaimSetResourceClaimAction
                    {
                        Action = new Action { ActionUri = "actionUri-1a" },
                        ResourceClaim = new ResourceClaim { ClaimName = "resourceClaimName1" },
                        AuthorizationStrategyOverrides = new List<ClaimSetResourceClaimActionAuthorizationStrategyOverrides>
                        {
                            new ClaimSetResourceClaimActionAuthorizationStrategyOverrides
                            {
                                AuthorizationStrategy = new AuthorizationStrategy { AuthorizationStrategyName=  "actionUri-1a-Strategy" }
                            }
                        },
                        ValidationRuleSetNameOverride = null
                    },
                    new ClaimSetResourceClaimAction
                    {
                        Action = new Action { ActionUri = "actionUri-1b" },
                        ResourceClaim = new ResourceClaim { ClaimName = "resourceClaimName1" },
                        AuthorizationStrategyOverrides = new List<ClaimSetResourceClaimActionAuthorizationStrategyOverrides>
                        {
                            new ClaimSetResourceClaimActionAuthorizationStrategyOverrides
                            {
                                AuthorizationStrategy = new AuthorizationStrategy { AuthorizationStrategyName=  "actionUri-1b-Strategy" }
                            }
                        },
                        ValidationRuleSetNameOverride = "actionUri-1b-RuleSetName"
                    },
                    new ClaimSetResourceClaimAction
                    {
                        Action = new Action { ActionUri = "actionUri-2" },
                        ResourceClaim = new ResourceClaim { ClaimName = "resourceClaimName2" },
                        AuthorizationStrategyOverrides = null,
                        ValidationRuleSetNameOverride = "actionUri-2-RuleSetName"
                    }
                };

                _securityRepository = A.Fake<ISecurityRepository>();
                A.CallTo(() => _securityRepository.GetClaimsForClaimSet(suppliedClaimSetName)).Returns(suppliedResourceClaims);
            }

            protected override void Act()
            {
                // Execute code under test
                var provider = new ClaimsIdentityProvider(
                    _apiKeyContextProvider,
                    _securityRepository);

                _actualIdentity = provider.GetClaimsIdentity();
            }

            [Assert]
            public void Should_issue_a_namespace_prefix_claim_per_namespace_prefix()
            {
                var namespaceClaims = _actualIdentity.Claims.Where(
                        c =>
                            c.Type == EdFiOdsApiClaimTypes.NamespacePrefix)
                    .ToList();

                namespaceClaims.Count.ShouldBe(1);

                namespaceClaims.Select(nc => nc.Value)
                    .ShouldBe(_suppliedNamespacePrefixes);
            }

            [Assert]
            public void Should_issue_one_claim_for_each_distinct_resource_claim_defined_in_the_callers_claim_set()
            {
                // Count the "resource" claims issued
                _actualIdentity.Claims.Count(c => c.Type.StartsWith("resource"))
                    .ShouldBe(2);

                _actualIdentity.Claims.Count(c => c.Type == "resourceClaimName1")
                    .ShouldBe(
                        1,
                        "Multiple actions associated with the same claim set should not result in multiple claims being issued.");

                _actualIdentity.Claims.Count(c => c.Type == "resourceClaimName2")
                    .ShouldBe(1);
            }

            [Assert]
            public void Should_combine_multiple_actions_for_the_same_resource_claim_into_an_array_under_a_single_issued_claim()
            {
                var claim1 = _actualIdentity.Claims.SingleOrDefault(c => c.Type == "resourceClaimName1");
                var edFiResourceClaim1 = claim1.ToEdFiResourceClaimValue();

                edFiResourceClaim1.Actions.Count()
                    .ShouldBe(2);

                edFiResourceClaim1.Actions.Select(x => x.Name)
                    .ShouldContain("actionUri-1a");

                edFiResourceClaim1.Actions.Select(x => x.Name)
                    .ShouldContain("actionUri-1b");
            }

            [Assert]
            public void Should_capture_assigned_authorization_strategy_overrides_to_associated_actions()
            {
                var claim1 = _actualIdentity.Claims.SingleOrDefault(c => c.Type == "resourceClaimName1");
                var edFiResourceClaim1 = claim1.ToEdFiResourceClaimValue();

                edFiResourceClaim1.Actions.Count()
                    .ShouldBe(2);

                Assert.AreEqual(edFiResourceClaim1.Actions.SelectMany(x => x.AuthorizationStrategyNameOverrides).ToArray(), new string[]{ "actionUri-1a-Strategy","actionUri-1b-Strategy" });
                Assert.AreEqual(edFiResourceClaim1.Actions.Select(x => x.Name).ToArray(), new string[] { "actionUri-1a", "actionUri-1b" });
                
            }

            [Assert]
            public void Should_leave_authorization_strategy_override_null_on_actions_without_an_override_assigned()
            {
                var claim2 = _actualIdentity.Claims.SingleOrDefault(c => c.Type == "resourceClaimName2");
                var edFiResourceClaim2 = claim2.ToEdFiResourceClaimValue();

                edFiResourceClaim2.Actions.Count().ShouldBe(1);

                Assert.AreEqual(edFiResourceClaim2.Actions.Where(x => x.AuthorizationStrategyNameOverrides != null).SelectMany(x => x.AuthorizationStrategyNameOverrides).ToArray(), new string[] {  });
                Assert.AreEqual(edFiResourceClaim2.Actions.Select(x => x.Name).ToArray(), new string[] { "actionUri-2" });
            }

            [Assert]
            public void
                Should_capture_assigned_validation_rule_set_name_overrides_to_associated_actions_leaving_them_null_on_actions_without_an_override_assigned()
            {
                var claim1 = _actualIdentity.Claims.SingleOrDefault(c => c.Type == "resourceClaimName1");
                var edFiResourceClaim1 = claim1.ToEdFiResourceClaimValue();

                edFiResourceClaim1.Actions.Count()
                    .ShouldBe(2);

                Assert.That(
                    edFiResourceClaim1.Actions.Select(
                        x => new
                        {
                            x.Name,
                            x.ValidationRuleSetNameOverride
                        }),
                    Is.EquivalentTo(
                        new[]
                        {
                            new
                            {
                                Name = "actionUri-1a",
                                ValidationRuleSetNameOverride = null as string
                            },
                            new
                            {
                                Name = "actionUri-1b",
                                ValidationRuleSetNameOverride = "actionUri-1b-RuleSetName"
                            }
                        }));

                var claim2 = _actualIdentity.Claims.SingleOrDefault(c => c.Type == "resourceClaimName2");
                var edFiResourceClaim2 = claim2.ToEdFiResourceClaimValue();

                edFiResourceClaim2.Actions.Count()
                    .ShouldBe(1);

                Assert.That(
                    edFiResourceClaim2.Actions.Select(
                        x => new
                        {
                            x.Name,
                            x.ValidationRuleSetNameOverride
                        }),
                    Is.EquivalentTo(
                        new[]
                        {
                            new
                            {
                                Name = "actionUri-2",
                                ValidationRuleSetNameOverride = "actionUri-2-RuleSetName"
                            }
                        }));
            }

            [Assert]
            public void Should_associate_the_callers_education_organizations_with_each_resource_claim()
            {
                var resourceClaim1 = _actualIdentity.Claims.SingleOrDefault(c => c.Type == "resourceClaimName1");
                var resourceClaim1Value = resourceClaim1.ToEdFiResourceClaimValue();

                resourceClaim1Value.EducationOrganizationIds.ShouldBe(_suppliedEducationOrganizationIds);

                var resourceClaim2 = _actualIdentity.Claims.SingleOrDefault(c => c.Type == "resourceClaimName2");
                var resourceClaim2Value = resourceClaim2.ToEdFiResourceClaimValue();

                resourceClaim2Value.EducationOrganizationIds.ShouldBe(_suppliedEducationOrganizationIds);
            }

            [Assert]
            public void Should_add_claims_for_assigned_profiles()
            {
                var profileClaims = _actualIdentity.Claims.Where(c => c.Type == EdFiOdsApiClaimTypes.Profile)
                    .ToList();

                Assert.That(profileClaims, Has.Count.EqualTo(2));

                Assert.That(
                    profileClaims.ElementAt(0)
                        .Value,
                    Is.EqualTo("supplied-assigned-profile"));

                Assert.That(
                    profileClaims.ElementAt(1)
                        .Value,
                    Is.EqualTo("supplied-assigned-profile-2"));
            }
        }

        public class When_creating_a_ClaimsIdentity_for_a_caller_with_empty_namespace_prefix : TestFixtureBase
        {
            // Supplied values
            private readonly List<int> _suppliedEducationOrganizationIds = new List<int>
            {
                1,
                2
            };
            private readonly List<string> _suppliedNamespacePrefixes = new List<string>();
            private readonly List<string> _suppliedProfiles = new List<string>
            {
                "supplied-assigned-profile",
                "supplied-assigned-profile-2"
            };

            // Actual values
            private ClaimsIdentity _actualIdentity;

            // Dependencies
            private IApiKeyContextProvider _apiKeyContextProvider;
            private ISecurityRepository _securityRepository;

            protected override void Arrange()
            {
                // Initialize dependencies

                const string suppliedClaimSetName = "claimSetName";

                var apiKeyContext = new ApiKeyContext(
                    "apiKey",
                    suppliedClaimSetName,
                    _suppliedEducationOrganizationIds,
                    _suppliedNamespacePrefixes,
                    _suppliedProfiles,
                    null, null, null);

                _apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();
                A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext()).Returns(apiKeyContext);

                var suppliedResourceClaims = new List<ClaimSetResourceClaimAction>
                {
                    new ClaimSetResourceClaimAction
                    {
                        Action = new Action { ActionUri = "actionUri-1a" },
                        ResourceClaim = new ResourceClaim { ClaimName = "resourceClaimName1" },
                        AuthorizationStrategyOverrides = new List<ClaimSetResourceClaimActionAuthorizationStrategyOverrides>
                        {
                            new ClaimSetResourceClaimActionAuthorizationStrategyOverrides
                            {
                                AuthorizationStrategy = new AuthorizationStrategy { AuthorizationStrategyName=  "actionUri-1a-Strategy" }
                            }
                        },
                        ValidationRuleSetNameOverride = null
                    },
                    new ClaimSetResourceClaimAction
                    {
                        Action = new Action { ActionUri = "actionUri-1b" },
                        ResourceClaim = new ResourceClaim { ClaimName = "resourceClaimName1" },
                        AuthorizationStrategyOverrides = new List<ClaimSetResourceClaimActionAuthorizationStrategyOverrides>
                        {
                            new ClaimSetResourceClaimActionAuthorizationStrategyOverrides
                            {
                                AuthorizationStrategy = new AuthorizationStrategy { AuthorizationStrategyName=  "actionUri-1b-Strategy" }
                            }
                        },
                        ValidationRuleSetNameOverride = "actionUri-1b-RuleSetName"
                    },
                    new ClaimSetResourceClaimAction
                    {
                        Action = new Action { ActionUri = "actionUri-2" },
                        ResourceClaim = new ResourceClaim { ClaimName = "resourceClaimName2" },
                        AuthorizationStrategyOverrides = null,
                        ValidationRuleSetNameOverride = "actionUri-2-RuleSetName"
                    }
                };

                _securityRepository = A.Fake<ISecurityRepository>();
                A.CallTo(() => _securityRepository.GetClaimsForClaimSet(suppliedClaimSetName)).Returns(suppliedResourceClaims);
            }

            protected override void Act()
            {
                // Execute code under test
                var provider = new ClaimsIdentityProvider(
                    _apiKeyContextProvider,
                    _securityRepository);

                _actualIdentity = provider.GetClaimsIdentity();
            }

            [Assert]
            public void Should_not_issue_a_namespace_claim_if_no_namespace_prefix_provided()
            {
                var namespaceClaims = _actualIdentity.Claims.Where(c => c.Type == EdFiOdsApiClaimTypes.NamespacePrefix).ToList();
                namespaceClaims.Count.ShouldBe(0);
            }
        }
    }
}
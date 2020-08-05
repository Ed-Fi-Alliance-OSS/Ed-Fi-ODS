// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Common.Security.Claims;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Security.Claims
{
    public class JsonClaimHelperTests
    {
        [TestFixture]
        public class When_serializing_from_EdFiClaimValue_to_Json_claim : TestBase
        {
            private const string SuppliedClaimType = "claimType";

            [Test]
            public void Should_create_claim_when_suppling_all_parameters()
            {
                var expected = new Claim(
                    SuppliedClaimType,
                    "{\"Actions\":[{\"Name\":\"action\"}],\"EducationOrganizationIds\":[1,2]}",
                    "application/json");

                var suppliedEdFiClaimValue = new EdFiResourceClaimValue(
                    "action",
                    new List<int>
                    {
                        1, 2
                    });

                var actual = JsonClaimHelper.CreateClaim(SuppliedClaimType, suppliedEdFiClaimValue);
                actual.Type.ShouldBe(expected.Type);
                actual.ValueType.ShouldBe(expected.ValueType);
                actual.Value.ShouldBe(expected.Value);
            }

            [Test]
            public void Should_create_claim_when_suppling_only_the_action()
            {
                var suppliedEdFiClaimValue = new EdFiResourceClaimValue("action");
                var actualClaim = JsonClaimHelper.CreateClaim(SuppliedClaimType, suppliedEdFiClaimValue);

                var expectedClaim = new Claim(SuppliedClaimType, "{\"Actions\":[{\"Name\":\"action\"}]}", "application/json");

                actualClaim.Type.ShouldBe(expectedClaim.Type);
                actualClaim.ValueType.ShouldBe(expectedClaim.ValueType);
                actualClaim.Value.ShouldBe(expectedClaim.Value);
            }

            [Test]
            public void Should_have_no_errors()
            {
                var suppliedEdFiClaimValue = new EdFiResourceClaimValue(
                    "action",
                    new List<int>
                    {
                        1, 2
                    });

                var thrown = TestForException<Exception>(() => JsonClaimHelper.CreateClaim(SuppliedClaimType, suppliedEdFiClaimValue));
                thrown.ShouldBeNull();
            }

            [Test]
            public void Should_have_no_errors_when_suppling_only_the_action()
            {
                var suppliedEdFiClaimValue = new EdFiResourceClaimValue("action");
                var thrown = TestForException<Exception>(() => JsonClaimHelper.CreateClaim(SuppliedClaimType, suppliedEdFiClaimValue));
                thrown.ShouldBeNull();
            }
        }

        [TestFixture]
        public class When_deserializing_from_a_Json_claim_to_EdFiClaimValue : TestBase
        {
            private const string ExpectedClaimType = "claimType";
            private const string ExpectedAction = "action";
            private readonly List<int> expectedLocalEducationAgencyIds = new List<int>
                                                                         {
                                                                             1, 2
                                                                         };

            [Test]
            public void Should_create_a_EdFiClaimValue()
            {
                var suppliedEdFiClaimValue = new EdFiResourceClaimValue(ExpectedAction, expectedLocalEducationAgencyIds);
                var claim = JsonClaimHelper.CreateClaim(ExpectedClaimType, suppliedEdFiClaimValue);
                var actual = claim.ToEdFiResourceClaimValue();

                actual.Actions.Select(x => x.Name)
                      .Single()
                      .ShouldBe(ExpectedAction);

                actual.EducationOrganizationIds.ShouldBe(expectedLocalEducationAgencyIds);
            }

            [Test]
            public void Should_create_a_EdFiClaimValue_when_only_action_is_supplied()
            {
                var suppliedEdFiClaimValue = new EdFiResourceClaimValue(ExpectedAction);
                var claim = JsonClaimHelper.CreateClaim(ExpectedClaimType, suppliedEdFiClaimValue);
                var actual = claim.ToEdFiResourceClaimValue();

                actual.Actions.Select(x => x.Name)
                      .Single()
                      .ShouldBe(ExpectedAction);

                actual.EducationOrganizationIds.ShouldBeEmpty();
            }

            [Test]
            public void Should_have_no_errors()
            {
                var suppliedEdFiClaimValue = new EdFiResourceClaimValue(ExpectedAction);
                var claim = JsonClaimHelper.CreateClaim(ExpectedClaimType, suppliedEdFiClaimValue);
                var thrown = TestForException<Exception>(() => claim.ToEdFiResourceClaimValue());
                thrown.ShouldBeNull();
            }
        }
    }
}

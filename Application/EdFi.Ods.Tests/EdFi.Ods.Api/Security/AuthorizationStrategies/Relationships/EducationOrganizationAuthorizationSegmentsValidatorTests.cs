// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Common.Security.Authorization;
using FakeItEasy;
using NUnit.Framework;
using QuickGraph;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    [TestFixture]
    public class EducationOrganizationAuthorizationSegmentsValidatorTests
    {
        // NOTE: Test graph is constructed as follows (2 separate, disconnected sections):
        // A --> B --> C  -- as with ESC/LEA/School
        // X --> Y        -- as with Community Organization/Community Provider 
        
        [Test]
        public void When_validating_an_authorization_segment_where_subject_is_lower_in_hierarchy_from_the_claim_Should_not_return_any_validation_messages()
        {
            var fakeHierarchyProvider = A.Fake<IEducationOrganizationIdHierarchyProvider>();
            A.CallTo(() => fakeHierarchyProvider.GetEducationOrganizationIdHierarchy()).Returns(CreateFakeGraph());

            var validator = new EducationOrganizationAuthorizationSegmentsValidator(fakeHierarchyProvider);

            var messages = validator.ValidateAuthorizationSegments(
                CreateAuthorizationSegment("B", "C"));
            
            messages.ShouldBeEmpty();
        }
        
        [Test]
        public void When_validating_an_authorization_segment_where_subject_is_higher_in_hierarchy_from_the_claim_Should_return_a_validation_message()
        {
            var fakeHierarchyProvider = A.Fake<IEducationOrganizationIdHierarchyProvider>();
            A.CallTo(() => fakeHierarchyProvider.GetEducationOrganizationIdHierarchy()).Returns(CreateFakeGraph());

            var validator = new EducationOrganizationAuthorizationSegmentsValidator(fakeHierarchyProvider);

            var messages = validator.ValidateAuthorizationSegments(
                CreateAuthorizationSegment("B", "A"));
            
            messages.ShouldSatisfyAllConditions(
                () =>
                {
                    messages.ShouldNotBeEmpty();
                    messages.ShouldHaveSingleItem();
                    messages.Single().ShouldBe("The claims associated with an identifier of 'B' cannot be used to authorize a request associated with an identifier of 'A'.");
                });
        }

        [Test]
        public void When_validating_an_authorization_segment_where_subject_is_in_a_different_hierarchy_from_the_claim_Should_return_a_validation_message()
        {
            var fakeHierarchyProvider = A.Fake<IEducationOrganizationIdHierarchyProvider>();
            A.CallTo(() => fakeHierarchyProvider.GetEducationOrganizationIdHierarchy()).Returns(CreateFakeGraph());

            var validator = new EducationOrganizationAuthorizationSegmentsValidator(fakeHierarchyProvider);

            var messages = validator.ValidateAuthorizationSegments(
                CreateAuthorizationSegment("B", "X"));
            
            messages.ShouldSatisfyAllConditions(
                () =>
                {
                    messages.ShouldNotBeEmpty();
                    messages.ShouldHaveSingleItem();
                    messages.Single().ShouldBe("The claims associated with an identifier of 'B' cannot be used to authorize a request associated with an identifier of 'X'.");
                });
        }

        [Test]
        public void When_validating_multiple_authorization_segments_where_subject_is_not_accessible_from_the_claim_Should_return_all_validation_messages()
        {
            var fakeHierarchyProvider = A.Fake<IEducationOrganizationIdHierarchyProvider>();
            A.CallTo(() => fakeHierarchyProvider.GetEducationOrganizationIdHierarchy()).Returns(CreateFakeGraph());

            var validator = new EducationOrganizationAuthorizationSegmentsValidator(fakeHierarchyProvider);

            var messages = validator.ValidateAuthorizationSegments(
                CreateAuthorizationSegment("B", "A")
                    .Concat(CreateAuthorizationSegment("B", "X"))
                    .ToArray());
            
            messages.ShouldSatisfyAllConditions(
                () =>
                {
                    messages.ShouldNotBeEmpty();
                    messages.Count.ShouldBe(2);
                    messages.ShouldContain("The claims associated with an identifier of 'B' cannot be used to authorize a request associated with an identifier of 'A'.");
                    messages.ShouldContain("The claims associated with an identifier of 'B' cannot be used to authorize a request associated with an identifier of 'X'.");
                });
        }
        
        [Test]
        public void When_validating_an_authorization_segment_where_subject_is_accessible_from_only_one_of_multiple_claims_Should_not_return_any_validation_messages()
        {
            var fakeHierarchyProvider = A.Fake<IEducationOrganizationIdHierarchyProvider>();
            A.CallTo(() => fakeHierarchyProvider.GetEducationOrganizationIdHierarchy()).Returns(CreateFakeGraph());

            var validator = new EducationOrganizationAuthorizationSegmentsValidator(fakeHierarchyProvider);

            var messages = validator.ValidateAuthorizationSegments(
                CreateAuthorizationSegment(new [] {"X", "B"}, "C"));
            
            messages.ShouldBeEmpty();
        }

        [Test]
        public void When_validating_an_authorization_segment_where_subject_is_not_accessible_from_any_of_multiple_claims_Should_return_multiple_messages()
        {
            var fakeHierarchyProvider = A.Fake<IEducationOrganizationIdHierarchyProvider>();
            A.CallTo(() => fakeHierarchyProvider.GetEducationOrganizationIdHierarchy()).Returns(CreateFakeGraph());

            var validator = new EducationOrganizationAuthorizationSegmentsValidator(fakeHierarchyProvider);

            var messages = validator.ValidateAuthorizationSegments(
                CreateAuthorizationSegment(new [] {"Y", "B"}, "X"));
            
            messages.ShouldSatisfyAllConditions(
                () =>
                {
                    messages.ShouldNotBeEmpty();
                    messages.Count.ShouldBe(2);
                    messages.ShouldContain("The claims associated with an identifier of 'Y' cannot be used to authorize a request associated with an identifier of 'X'.");
                    messages.ShouldContain("The claims associated with an identifier of 'B' cannot be used to authorize a request associated with an identifier of 'X'.");
                });
        }

        [Test]
        public void When_validating_multiple_authorization_segments_where_each_subject_is_accessible_from_one_of_multiple_claims_Should_not_return_any_messages()
        {
            var fakeHierarchyProvider = A.Fake<IEducationOrganizationIdHierarchyProvider>();
            A.CallTo(() => fakeHierarchyProvider.GetEducationOrganizationIdHierarchy()).Returns(CreateFakeGraph());

            var validator = new EducationOrganizationAuthorizationSegmentsValidator(fakeHierarchyProvider);

            var messages = validator.ValidateAuthorizationSegments(
                CreateAuthorizationSegment(new[] {"B", "X"}, "C")
                    .Concat(CreateAuthorizationSegment(new[] {"B", "X"}, "Y"))
                    .ToArray());
            
            messages.ShouldBeEmpty();
        }

        [Test]
        public void When_validating_an_authorization_segment_where_subject_is_not_in_the_graph_Should_not_return_any_validation_messages()
        {
            var fakeHierarchyProvider = A.Fake<IEducationOrganizationIdHierarchyProvider>();
            A.CallTo(() => fakeHierarchyProvider.GetEducationOrganizationIdHierarchy()).Returns(CreateFakeGraph());

            var validator = new EducationOrganizationAuthorizationSegmentsValidator(fakeHierarchyProvider);

            var messages = validator.ValidateAuthorizationSegments(
                CreateAuthorizationSegment("B", "NotAnEdOrg"));
            
            messages.ShouldBeEmpty();
        }

        private static ClaimsAuthorizationSegment[] CreateAuthorizationSegment(string claimEndpointName, string subjectEndpointName)
        {
            return new[]
            {
                new ClaimsAuthorizationSegment(
                    new[] { Tuple.Create(claimEndpointName, (object)1) },
                    new AuthorizationSegmentEndpoint(subjectEndpointName, typeof(object))),
            };
        }

        private static ClaimsAuthorizationSegment[] CreateAuthorizationSegment(string[] claimEndpointNames, string subjectEndpointName)
        {
            return new[]
            {
                new ClaimsAuthorizationSegment(
                    claimEndpointNames.Select(x => Tuple.Create(x, (object) 1)),
                    new AuthorizationSegmentEndpoint(subjectEndpointName, typeof(object))),
            };
        }

        private static AdjacencyGraph<string, Edge<string>> CreateFakeGraph()
        {
            var fakeGraph = new AdjacencyGraph<string, Edge<string>>();

            fakeGraph.AddVerticesAndEdgeRange(
                new[]
                {
                    new Edge<string>("A", "B"),
                    new Edge<string>("B", "C"),
                    new Edge<string>("X", "Y"),
                });

            return fakeGraph;
        }
    }
}

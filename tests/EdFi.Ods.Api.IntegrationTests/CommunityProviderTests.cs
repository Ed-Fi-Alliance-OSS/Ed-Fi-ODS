// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class CommunityProviderTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_inserting_and_deleting_community_provider_without_community_organization_should_update_tuples()
        {
            Builder
                .AddCommunityProvider(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001));
        }

        [Test]
        public void When_inserting_and_deleting_community_provider_with_community_organization_should_update_tuples()
        {
            Builder
                .AddCommunityOrganization(900)
                .AddCommunityProvider(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void
            When_updating_community_provider_without_community_organization_to_with_community_organization_should_update_tuples()
        {
            Builder
                .AddCommunityOrganization(900)
                .AddCommunityProvider(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001));

            Builder
                .UpdateCommunityProvider(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001), (900, 9001));
        }

        [Test]
        public void
            When_updating_community_provider_with_community_organization_to_without_community_organization_should_update_tuples()
        {
            Builder
                .AddCommunityOrganization(900)
                .AddCommunityProvider(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .UpdateCommunityProvider(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (900, 900), (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (900, 9001));
        }
    }
}

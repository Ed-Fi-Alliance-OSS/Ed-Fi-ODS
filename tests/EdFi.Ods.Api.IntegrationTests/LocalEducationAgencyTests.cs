// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests
{
    [TestFixture]
    public class LocalEducationAgencyTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_inserting_and_deleting_local_education_agency_without_education_service_center_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001));
        }

        [Test]
        public void When_inserting_and_deleting_local_education_agency_with_education_service_center_should_update_tuples()
        {
            Builder
                .AddEducationServiceCenter(900)
                .AddLocalEducationAgency(9001, educationServiceCenterId: 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (900, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_local_education_agency_without_education_service_center_to_with_education_service_center_should_update_tuples()
        {
            Builder
                .AddEducationServiceCenter(900)
                .AddLocalEducationAgency(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));

            Builder
                .UpdateLocalEducationAgency(9001, educationServiceCenterId: 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_local_education_agency_with_education_service_center_to_without_education_service_center_should_update_tuples()
        {
            Builder
                .AddEducationServiceCenter(900)
                .AddLocalEducationAgency(9001, educationServiceCenterId: 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (900, 9001));

            Builder
                .UpdateLocalEducationAgency(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (900, 9001));
        }

        [Test]
        public void When_updating_local_education_agency_with_schools_and_without_education_service_center_to_with_education_service_center_should_update_tuples()
        {
            Builder
                .AddEducationServiceCenter(900)
                .AddLocalEducationAgency(9001)
                .AddSchool(90010, 9001)
                .AddSchool(90011, 9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (9001, 90010), (9001, 90011));

            Builder
                .UpdateLocalEducationAgency(9001, educationServiceCenterId: 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (9001, 90010), (9001, 90011), (900, 9001), (900, 90010), (900, 90011));
        }
    }
}

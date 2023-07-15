﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests.DataStandard500
{
    [TestFixture]
    public class SchoolTests : DatabaseTestFixtureBase
    {
        [Test]
        public void When_inserting_and_deleting_school_without_local_education_agency_should_update_tuples()
        {
            Builder
                .AddSchool(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<long, long>(Connection, (9001, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples<long, long>(Connection, (9001, 9001));
        }

        [Test]
        public void When_inserting_and_deleting_school_with_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddSchool(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<long, long>(Connection, (9001, 9001), (900, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples<long, long>(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_school_without_local_education_agency_to_with_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddSchool(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<long, long>(Connection, (9001, 9001));

            Builder
                .UpdateSchool(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<long, long>(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_school_with_local_education_agency_to_without_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddSchool(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<long, long>(Connection, (9001, 9001), (900, 9001));

            Builder
                .UpdateSchool(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<long, long>(Connection, (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples<long, long>(Connection, (900, 9001));
        }

        [Test]
        public void When_inserting_and_deleting_school_without_local_education_agency_and_education_service_center_should_update_tuples()
        {
            Builder
                .AddEducationServiceCenter(90)
                .AddLocalEducationAgency(900, educationServiceCenterId: 90)
                .AddSchool(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<long, long>(Connection, (90, 900), (90, 9001), (900, 9001), (9001, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples<long, long>(Connection, (90, 9001), (900, 9001), (9001, 9001));
        }

        [Test]
        public void When_updating_school_without_local_education_agency_to_with_local_education_agency_with_education_service_center_should_update_tuples()
        {
            Builder
                .AddEducationServiceCenter(90)
                .AddLocalEducationAgency(900, educationServiceCenterId: 90)
                .AddSchool(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<long, long>(Connection, (90, 900), (9001, 9001));

            Builder
                .UpdateSchool(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<long, long>(Connection, (90, 900), (9001, 9001), (90, 9001), (900, 9001));
        }
    }
}

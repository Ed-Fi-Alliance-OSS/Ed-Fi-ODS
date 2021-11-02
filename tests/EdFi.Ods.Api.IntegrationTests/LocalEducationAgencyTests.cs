// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

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

        [Test]
        public void When_inserting_and_deleting_local_education_agency_with_state_education_agency_should_update_tuples()
        {
            Builder
                .AddStateEducationAgency(9)
                .AddLocalEducationAgency(9001, stateEducationAgencyId: 9)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (9, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9001, 9001), (9, 9001));
        }

        [Test]
        public void When_updating_local_education_agency_without_state_education_agency_to_with_state_education_agency_should_update_tuples()
        {
            Builder
                .AddStateEducationAgency(9)
                .AddLocalEducationAgency(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9, 9001));

            Builder
                .UpdateLocalEducationAgency(9001, stateEducationAgencyId: 9)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (9, 9001));
        }

        [Test]
        public void When_updating_local_education_agency_with_state_education_agency_to_without_state_education_agency_should_update_tuples()
        {
            Builder
                .AddStateEducationAgency(9)
                .AddLocalEducationAgency(9001, stateEducationAgencyId: 9)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001), (9, 9001));

            Builder
                .UpdateLocalEducationAgency(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection, (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples(Connection, (9, 9001));
        }

        // ---------- Advanced Scenarios -------------

        [Test]
        public void When_updating_local_education_agency_with_state_education_agency_and_education_service_center_progressively_to_without_state_education_agency_or_education_service_center_should_update_tuples()
        {
            Builder
                .AddStateEducationAgency(9)
                .AddEducationServiceCenter(900, stateEducationAgencyId: 9)
                .AddLocalEducationAgency(9001, stateEducationAgencyId: 9, educationServiceCenterId: 900)
                .AddSchool(90011, localEducationAgencyId: 9001)
                .AddSchool(90012, localEducationAgencyId: 9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(
                Connection,
                (9, 9),
                (900, 900),
                (9001, 9001),
                (90011, 90011),
                (90012, 90012),
                (9, 900),
                (9, 9001),
                (9, 90011),
                (9, 90012),
                (900, 9001),
                (900, 90011),
                (900, 90012),
                (9001, 90011),
                (9001, 90012));

            // Remove association of LEA to the ESC
            Builder
                .UpdateLocalEducationAgency(9001, stateEducationAgencyId: 9)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(
                Connection,
                (9, 9),
                (900, 900),
                (9001, 9001),
                (90011, 90011),
                (90012, 90012),
                (9, 900),
                (9, 9001),
                (9, 90011),
                (9, 90012),
                // ESC tuples through LEA should be removed
                // (900, 9001),
                // (900, 90011),
                // (900, 90012),
                (9001, 90011),
                (9001, 90012));

            EducationOrganizationHelper.ShouldNotContainTuples(Connection,
                // ESC tuples through LEA should be removed
                (900, 9001),
                (900, 90011),
                (900, 90012));
            
            // Now remove association of LEA to the SEA
            Builder
                .UpdateLocalEducationAgency(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(
                Connection,
                (9, 9),
                (900, 900),
                (9001, 9001),
                (90011, 90011),
                (90012, 90012),
                (9, 900),
                // SEA tuples through LEA should be removed
                // (9, 9001),
                // (9, 90011),
                // (9, 90012),
                // ESC tuples through LEA should be removed
                // (900, 9001),
                // (900, 90011),
                // (900, 90012),
                (9001, 90011),
                (9001, 90012));

            EducationOrganizationHelper.ShouldNotContainTuples(Connection,
                // SEA tuples through LEA should be removed
                (9, 9001),
                (9, 90011),
                (9, 90012),
                // ESC tuples through LEA should be removed
                (900, 9001),
                (900, 90011),
                (900, 90012));
        }
        
        [Test]
        public void When_updating_local_education_agency_from_one_education_service_center_to_another_should_update_tuples()
        {
            Builder
                .AddEducationServiceCenter(800)
                .AddEducationServiceCenter(900)
                .AddLocalEducationAgency(9001, educationServiceCenterId: 900)
                .AddSchool(90011, localEducationAgencyId: 9001)
                .AddSchool(90012, localEducationAgencyId: 9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(
                Connection,
                (800, 800),
                (900, 900),
                (9001, 9001),
                (90011, 90011),
                (90012, 90012),
                (900, 9001),
                (900, 90011),
                (900, 90012),
                (9001, 90011),
                (9001, 90012));

            // Now remove association of LEA to the SEA
            Builder
                .UpdateLocalEducationAgency(9001, educationServiceCenterId: 800)
                .Execute();
            
            EducationOrganizationHelper.ShouldContainTuples(
                Connection,
                (800, 800),
                (900, 900),
                (9001, 9001),
                (90011, 90011),
                (90012, 90012),
                (800, 9001),
                (800, 90011),
                (800, 90012),
                (9001, 90011),
                (9001, 90012));
            
            EducationOrganizationHelper.ShouldNotContainTuples(Connection,
                // Tuples for LEA's previously assigned ESC should have been removed
                (900, 9001),
                (900, 90011),
                (900, 90012));
        }
        
        [Test]
        public void When_updating_local_education_agency_with_parent_local_education_agencies_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(9001)
                .AddLocalEducationAgency(9002)
                .AddLocalEducationAgency(9003)
                .AddSchool(90011, localEducationAgencyId: 9001)
                .AddSchool(90012, localEducationAgencyId: 9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection,
                (9001, 9001),
                (9002, 9002),
                (9003, 9003),
                (90011, 90011),
                (90012, 90012),
                (9001, 90011),
                (9001, 90012));

            // Make 9003 the parent of LEA 9002
            Builder
                .UpdateLocalEducationAgency(9002, parentLocalEducationAgencyId: 9003)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(Connection,
                (9001, 9001),
                (9002, 9002),
                (9003, 9003),
                (90011, 90011),
                (90012, 90012),
                (9003, 9002),
                (9001, 90011),
                (9001, 90012));
            
            // Make 9002 the parent LEA
            Builder
                .UpdateLocalEducationAgency(9001, parentLocalEducationAgencyId: 9002)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples(
                Connection,
                (9001, 9001),
                (9002, 9002),
                (9003, 9003),
                (90011, 90011),
                (90012, 90012),
                (9001, 90011),
                (9001, 90012),
                (9002, 9001),
                (9002, 90011),
                (9002, 90012),
                (9003, 9002),
                (9003, 9001),
                (9003, 90011),
                (9003, 90012));
            
            // Update LEA 9001 to remove 9002 as its parent LEA
            Builder
                .UpdateLocalEducationAgency(9001)
                .Execute();
            
            EducationOrganizationHelper.ShouldContainTuples(
                Connection,
                (9001, 9001),
                (9002, 9002),
                (9003, 9003),
                (90011, 90011),
                (90012, 90012),
                (9001, 90011),
                (9001, 90012),
                // 9002 is no longer the parent of 9001
                // (9002, 9001),
                // (9002, 90011),
                // (9002, 90012),
                (9003, 9002));
                // 9003 is no longer an ancestor of 9001 through 9002
                // (9003, 9001),
                // (9003, 90011),
                // (9003, 90012));

            EducationOrganizationHelper.ShouldNotContainTuples(
                Connection,
                (9002, 9001),
                (9002, 90011),
                (9002, 90012),
                (9003, 9001),
                (9003, 90011),
                (9003, 90012));
        }
    }
}

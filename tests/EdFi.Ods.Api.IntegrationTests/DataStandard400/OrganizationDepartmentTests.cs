﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Api.IntegrationTests.DataStandard400
{
    [TestFixture]
    public class OrganizationDepartmentTests : DatabaseTestFixtureBase
    {
        [Test]
        public void
            When_inserting_and_deleting_organization_department_without_local_education_agency_or_school_should_update_tuples()
        {
            Builder
                .AddOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (9001, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldNotContainTuples<int, int>(Connection, (9001, 9001));
        }

        [Test]
        public void When_inserting_and_deleting_organization_department_with_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900));
            EducationOrganizationHelper.ShouldNotContainTuples<int, int>(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_inserting_and_deleting_organization_department_with_school_should_update_tuples()
        {
            Builder
                .AddSchool(900)
                .AddOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .DeleteEducationOrganization(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900));
            EducationOrganizationHelper.ShouldNotContainTuples<int, int>(Connection, (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_organization_department_without_local_education_agency_to_with_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001));

            Builder
                .UpdateOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_organization_department_without_school_to_with_school_should_update_tuples()
        {
            Builder
                .AddSchool(900)
                .AddOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001));

            Builder
                .UpdateOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001), (900, 9001));
        }

        [Test]
        public void When_updating_organization_department_with_local_education_agency_to_without_local_education_agency_should_update_tuples()
        {
            Builder
                .AddLocalEducationAgency(900)
                .AddOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .UpdateOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples<int, int>(Connection, (900, 9001));
        }

        [Test]
        public void When_updating_organization_department_with_school_to_without_school_should_update_tuples()
        {
            Builder
                .AddSchool(900)
                .AddOrganizationDepartment(9001, 900)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001), (900, 9001));

            Builder
                .UpdateOrganizationDepartment(9001)
                .Execute();

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, (900, 900), (9001, 9001));
            EducationOrganizationHelper.ShouldNotContainTuples<int, int>(Connection, (900, 9001));
        }
        
        // ---------- Advanced Scenarios -------------
        
        // This test creates multi-levels of Org Departments under both the LEA and a School.
        // It then moves the org dept from the LEA to the 2nd-level org department under the school
        // Finally, it moves it back up to under the LEA.
        // It ensures that all tuples are created and removed correctly as these updates occur.
        [Test]
        public void When_updating_organization_departments_parent_elsewhere_in_hierarchy_should_update_tuples()
        {
            var baselineTuples = EducationOrganizationHelper.GetExistingTuples<int, int>(Connection);
            var baselineTupleCount = baselineTuples.Count;
            
            Builder
                .AddLocalEducationAgency(901)
                .AddOrganizationDepartment(8901, parentEducationOrganizationId: 901)
                .AddOrganizationDepartment(88901, parentEducationOrganizationId: 8901)
                .AddSchool(901001, localEducationAgencyId: 901)
                .AddOrganizationDepartment(7901001, parentEducationOrganizationId: 901001)
                .AddOrganizationDepartment(8901001, parentEducationOrganizationId: 901001)
                .AddSchool(901002, localEducationAgencyId: 901)
                .AddOrganizationDepartment(7901002, parentEducationOrganizationId: 901002)
                .AddOrganizationDepartment(8901002, parentEducationOrganizationId: 901002)
                .AddOrganizationDepartment(88901002, parentEducationOrganizationId: 8901002)
                .Execute();

            var expectedTuplesAfterCreation = new (int, int) []
            {
                (901, 901),
                (8901, 8901),
                (88901, 88901),
                (901001, 901001),
                (7901001, 7901001),
                (8901001, 8901001),
                (901002, 901002),
                (7901002, 7901002),
                (8901002, 8901002),
                (88901002, 88901002),
                (901, 8901), // OrgDept will be moved down the hierarchy, but tuple should remain
                (901, 88901), // 2nd-level OrgDept will be moved down the hierarchy, but tuple should remain
                (8901, 88901),
                (901, 901001),
                (901, 7901001),
                (901, 8901001),
                (901001, 7901001),
                (901001, 8901001),
                (901, 901002),
                (901, 7901002), 
                (901, 8901002), 
                (901, 88901002), // LEA to 2nd level org department under school
                (901002, 7901002),
                (901002, 8901002),
                (901002, 88901002),
                (8901002, 88901002)
            };

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, expectedTuplesAfterCreation);
            
            var afterCreationCount = EducationOrganizationHelper.GetExistingTuples<int, int>(Connection).Count;
            
            // Make sure all the tuples above were added (and only those tuples)
            (baselineTupleCount + expectedTuplesAfterCreation.Length).ShouldBe(afterCreationCount);
            
            // Move the LEA org department to the bottom of the hierarchy (under 2nd-level school org dept)
            Builder.UpdateOrganizationDepartment(8901, parentEducationOrganizationId: 88901002).Execute();

            var afterMovedDown = EducationOrganizationHelper.GetExistingTuples<int, int>(Connection);

            var expectedTuplesAfterMovedDown = new (int, int)[]
            {
                (901, 901),
                (8901, 8901),
                (88901, 88901),
                (901001, 901001),
                (7901001, 7901001),
                (8901001, 8901001),
                (901002, 901002),
                (7901002, 7901002),
                (8901002, 8901002),
                (88901002, 88901002),
                (901, 8901), // OrgDept will be moved down the hierarchy, but tuple should remain
                (901, 88901), // 2nd-level OrgDept will be moved down the hierarchy, but tuple should remain
                (8901, 88901),
                (901, 901001),
                (901, 7901001),
                (901, 8901001),
                (901001, 7901001),
                (901001, 8901001),
                (901, 901002),
                (901, 7901002),
                (901, 8901002),
                (901, 88901002), // LEA to 2nd level org department under school
                (901002, 7901002),
                (901002, 8901002),
                (901002, 88901002),
                (8901002, 88901002),

                // Expected new tuples (6 entries)
                (901002, 8901), // School (to new descendants)
                (901002, 88901),
                (8901002, 8901), // First-level org dept
                (8901002, 88901),
                (88901002, 8901), // Second-level org dept
                (88901002, 88901),
            };
            
            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, expectedTuplesAfterMovedDown);
            
            afterMovedDown.Count.ShouldBe(afterCreationCount + 6,
                    $"The following additional tuples were found: {Environment.NewLine}"
                    + string.Join(Environment.NewLine,
                        afterMovedDown
                            .Except(baselineTuples)
                            .Except(expectedTuplesAfterMovedDown)
                            .Select(t => $"({t.Item1},{t.Item2})"))
            );
            
            // Move the original LEA org department back to the LEA
            Builder.UpdateOrganizationDepartment(8901, parentEducationOrganizationId: 901).Execute();

            var afterMoveBackUpCount = EducationOrganizationHelper.GetExistingTuples<int, int>(Connection).Count;

            EducationOrganizationHelper.ShouldContainTuples<int, int>(Connection, expectedTuplesAfterCreation);
            EducationOrganizationHelper.ShouldNotContainTuples<int, int>(Connection,
                // These are the tuples that were created when the Org Dept was moved to the bottom of the hierarchy
                (901002, 8901), // School (to new descendants)
                (901002, 88901),
                (8901002, 8901), // First-level org dept
                (8901002, 88901),
                (88901002, 8901), // Second-level org dept
                (88901002, 88901));
            
            afterMoveBackUpCount.ShouldBe(afterCreationCount);
        }
    }
}

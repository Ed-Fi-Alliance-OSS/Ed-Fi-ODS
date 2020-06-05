// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using EdFi.Ods.Api.Common.Models.Resources.BellSchedule.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.StaffEducationOrganizationAssignmentAssociation.EdFi;
using EdFi.Ods.Api.Common.Models.Resources.StudentSchoolAttendanceEvent.EdFi;
using EdFi.Ods.Entities.Common.EdFi;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi.Resources
{
    public class ResourceModelReferenceTests
    {
        public class When_initalizing_a_model_with_an_optional_reference_where_none_of_the_optional_references_properties_are_explicitly_set
            : LegacyTestFixtureBase
        {
            // Supplied values
            private StaffEducationOrganizationAssignmentAssociation _model;
            private IStaffEducationOrganizationAssignmentAssociation _modelInterface;

            // Actual values
            private string _actualSerializedJson;

            // External dependencies

            protected override void Arrange()
            {
                // Set up mocked dependences and supplied values
            }

            protected override void Act()
            {
                // Perform the action to be tested
                _model = new StaffEducationOrganizationAssignmentAssociation();

                // Populate the instance's value, including the shared FK value, but none of the optional reference's values
                _modelInterface = _model;

                // Set only the required "key" properties on the main model
                _modelInterface.StaffUniqueId =
                    "ABC123"; // This also serves as part of the optional reference, but is "unified" (or shared) from other references.

                _modelInterface.EducationOrganizationId = 123;
                _modelInterface.StaffClassificationDescriptor = "Hello";
                _modelInterface.BeginDate = DateTime.Today;

                // NOTE: No other properties for the optional reference have been set

                _actualSerializedJson = JsonConvert.SerializeObject(_model);
            }

            [Assert]
            public void Should_not_return_default_values_for_nullable_properties_from_optional_reference()
            {
                // Assert the expected results
                _modelInterface.EmploymentHireDate.ShouldBeNull();
                _modelInterface.EmploymentEducationOrganizationId.ShouldBeNull();
                _modelInterface.EmploymentStatusDescriptor.ShouldBeNull();
            }

            [Assert]
            public void Should_not_include_the_partially_defined_reference_in_JSON_output()
            {
                _actualSerializedJson.ShouldContain(@"""employmentStaffEducationOrganizationEmploymentAssociationReference"":null");
            }

            [Assert]
            public void Should_not_introduce_a_partially_defined_reference_on_JSON_deserialization()
            {
                var deserializedModel = DefaultTestJsonSerializer.DeserializeObject<StaffEducationOrganizationAssignmentAssociation>(_actualSerializedJson);

                deserializedModel.EmploymentStaffEducationOrganizationEmploymentAssociationReference.ShouldBeNull();
            }
        }

        public class When_setting_and_getting_properties_for_an_optional_reference_on_a_model : LegacyTestFixtureBase
        {
            private StaffEducationOrganizationAssignmentAssociation _model;
            private IStaffEducationOrganizationAssignmentAssociation _modelInterface;

            [Assert]
            public void Should_not_return_values_from_optional_reference_until_all_of_the_references_properties_have_been_set()
            {
                _model = new StaffEducationOrganizationAssignmentAssociation();
                _modelInterface = _model;

                // This property is "unified" with other references
                _modelInterface.StaffUniqueId = "ABC123";

                // Because it's shared by multiple references, this property should return its value 
                // immediately (it's not **specific** to the optional reference)
                _modelInterface.StaffUniqueId.ShouldBe("ABC123");

                All_optional_reference_properties_should_still_return_null_values();

                // ---------------------------------------------------------
                // These properties are specific to the optional reference
                // ---------------------------------------------------------
                _modelInterface.EmploymentEducationOrganizationId = 123;
                All_optional_reference_properties_should_still_return_null_values();
                Optional_reference_should_still_be_null();

                _modelInterface.EmploymentStatusDescriptor = "XYZ";
                All_optional_reference_properties_should_still_return_null_values();
                Optional_reference_should_still_be_null();

                // After the last property specific to the optional reference is set, they should all return values (reference is complete)
                _modelInterface.EmploymentHireDate = DateTime.Today;
                All_of_the_optional_reference_properties_should_now_return_values();
                Optional_reference_should_NOT_be_null();
            }

            private void Optional_reference_should_NOT_be_null()
            {
                _model.EmploymentStaffEducationOrganizationEmploymentAssociationReference.ShouldNotBeNull();
            }

            private void Optional_reference_should_still_be_null()
            {
                _model.EmploymentStaffEducationOrganizationEmploymentAssociationReference.ShouldBeNull();
            }

            private void All_optional_reference_properties_should_still_return_null_values()
            {
                _modelInterface.EmploymentEducationOrganizationId.ShouldBeNull();
                _modelInterface.EmploymentStatusDescriptor.ShouldBeNull();
                _modelInterface.EmploymentHireDate.ShouldBeNull();
            }

            private void All_of_the_optional_reference_properties_should_now_return_values()
            {
                _modelInterface.EmploymentEducationOrganizationId.ShouldNotBe(null);
                _modelInterface.EmploymentStatusDescriptor.ShouldNotBe(null);
                _modelInterface.EmploymentHireDate.ShouldNotBe(null);
            }
        }

        [TestFixture]
        public class When_setting_and_getting_properties_for_a_required_reference_on_a_model
        {
            [SetUp]
            protected void TestSetup()
            {
                _model = new StaffEducationOrganizationAssignmentAssociation();
                _modelInterface = _model;
            }

            private StaffEducationOrganizationAssignmentAssociation _model;
            private IStaffEducationOrganizationAssignmentAssociation _modelInterface;

            [Test]
            public void Property_should_be_cleared_by_explicitly_setting_reference_to_null()
            {
                _modelInterface.StaffUniqueId = "ABC123";
                _model.StaffReference = null;
                _modelInterface.StaffUniqueId.ShouldBeNull();
            }

            [Test]
            public void Reference_should_be_implicitly_restored_by_setting_the_property_value()
            {
                _model.StaffReference = null;
                _modelInterface.StaffUniqueId = "ABC123";
                _model.StaffReference.ShouldNotBeNull();
                _modelInterface.StaffUniqueId.ShouldBe("ABC123");
            }

            [Test]
            public void Reference_should_be_null_again_after_property_value_is_returned_to_its_default_value()
            {
                _modelInterface.StaffUniqueId = "ABC123";
                _modelInterface.StaffUniqueId = default(string);
                _model.StaffReference.ShouldBeNull();
            }

            [Test]
            public void Reference_should_be_null_before_property_value_is_set()
            {
                _model.StaffReference.ShouldBeNull();
            }

            [Test]
            public void Reference_should_NOT_be_null_after_property_value_is_set()
            {
                _modelInterface.StaffUniqueId = "ABC123";
                _model.StaffReference.ShouldNotBeNull();
            }
        }

        public class When_deserializing_a_model_with_a_reference_based_on_a_composite_key : LegacyTestFixtureBase
        {
            private StudentSchoolAttendanceEvent _model;

            protected override void Act()
            {
                var json = @"
                    {
                        ""id"" : ""00000000000000000000000000000000"",
                        ""schoolReference"" : null,
                        ""sessionReference"" : {
                            ""schoolId"" : 123,
                            ""sessionName"" : ""ABC"",
                            ""schoolYear"" : 2013,
                            ""link"" : {
                                ""rel"" : ""Session"",
                                ""href"" : ""/sessions?schoolId=123&schoolYear=2013""
                            }
                        },
                        ""studentReference"" : null,
                        ""eventDate"" : ""0001-01-01"",
                        ""attendanceEventCategoryDescriptor"" : null,
                        ""attendanceEventReason"" : null,
                        ""educationalEnvironmentType"" : null,
                        ""_etag"" : null
                    }
                ";

                _model = DefaultTestJsonSerializer.DeserializeObject<StudentSchoolAttendanceEvent>(json);
            }

            [Assert]
            public void Should_return_a_reference()
            {
                _model.SessionReference.ShouldNotBeNull();
            }

            [Assert]
            public void Reference_should_return_the_non_default_values()
            {
                _model.SessionReference.SchoolId.ShouldBe(123);
                _model.SessionReference.SessionName.ShouldBe("ABC");
                ((int) _model.SessionReference.SchoolYear).ShouldBe(2013);
            }
        }

        public class When_deserializing_a_model_with_a_reference_based_on_a_composite_key_with_backReference_presence : LegacyTestFixtureBase
        {
            private BellSchedule _model;
            /* C# initializer helper
            private BellSchedule _model = new BellSchedule
                {
                    BellScheduleName = "ScheduleName",
                    BellScheduleMeetingTimes = new[]
                    {
                        new BellScheduleMeetingTime
                        {
                            ClassPeriodReference = new BellScheduleMeetingTimeToClassPeriodReference
                            {
                                ClassPeriodName = "ABC"
                            },
                            StartTime = DateTime.Now.TimeOfDay,
                            EndTime = new TimeSpan(1, 0, 0),
                        }
                    },
                    CalendarDateReference = new CalendarDateReference
                    {
                        Date = DateTime.Now,
                        EducationOrganizationId = 1,
                    },
                    SchoolReference = new SchoolReference
                    {
                        SchoolId = 10
                    },
                    GradeLevelDescriptor = "A",
                };
*/

            protected override void Act()
            {
                const string json = @"
{
    'calendarDateReference' : {
        'Date' : '2000-01-01',
        'schoolId' : 1,
    },
    'schoolReference' : {
        'schoolId' : 10
    },
    'gradeLevelDescriptor' : 'A',
    'name' : 'ScheduleName',
    'classPeriods' : [
        {
            'classPeriodReference' : {
                'classPeriodName' : 'ABC',
                'schoolId' : 10,
            }
        }
    ],
}
";

                _model = JsonConvert.DeserializeObject<BellSchedule>(json);
            }

            [Assert]
            public void Should_return_a_reference()
            {
                _model.BellScheduleClassPeriods.First()
                      .ClassPeriodReference.ShouldNotBeNull();
            }

            [Assert]
            public void Reference_should_return_the_non_default_values()
            {
                _model.BellScheduleClassPeriods.First()
                      .ClassPeriodReference.ClassPeriodName.ShouldBe("ABC");
            }
        }
    }
}

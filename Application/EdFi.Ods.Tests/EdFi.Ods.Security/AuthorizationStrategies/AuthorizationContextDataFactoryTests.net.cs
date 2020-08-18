// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Security.AuthorizationStrategies;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Tests._Extensions;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.AuthorizationStrategies
{
    [TestFixture]
    public class AuthorizationContextDataFactoryTests
    {
        public class When_creating_authorization_context_WITHOUT_an_explicit_property_name_mapping
            : LegacyTestFixtureBase
        {
            private RelationshipsAuthorizationContextData _actualContextData;

            private EntityWithRoleNamedProperties _suppliedEntity;

            protected override void Act()
            {
                var factory = new AuthorizationContextDataFactory();

                _suppliedEntity = new EntityWithRoleNamedProperties
                                  {
                                      Name = "Bob", SchoolId = 1, FirstEducationOrganizationId = 10, SecondEducationOrganizationId = 20
                                  };

                _actualContextData = factory.CreateContextData<RelationshipsAuthorizationContextData>(_suppliedEntity);
            }

            [Assert]
            public void Should_create_authorization_context_using_exact_property_name_matches()
            {
                Assert.That(_actualContextData.SchoolId, Is.EqualTo(_suppliedEntity.SchoolId));
            }

            [Assert]
            public void Should_leave_unmatching_properties_on_the_authorization_context_with_default_values()
            {
                Assert.That(_actualContextData.EducationOrganizationId, Is.Null, "EducationOrganizationId");

                Assert.That(_actualContextData.StateEducationAgencyId, Is.Null, "StateEducationAgencyId");
                Assert.That(_actualContextData.EducationServiceCenterId, Is.Null, "EducationServiceCenterId");
                Assert.That(_actualContextData.LocalEducationAgencyId, Is.Null, "LocalEducationAgencyId");

                // SchoolId should be mapped by convention
                Assert.That(_actualContextData.SchoolId, Is.Not.Null, "SchoolId");

                Assert.That(_actualContextData.EducationOrganizationNetworkId, Is.Null, "EducationOrganizationNetworkId");

                Assert.That(_actualContextData.StudentUSI, Is.Null, "StudentUSI");
                Assert.That(_actualContextData.StaffUSI, Is.Null, "StaffUSI");
                Assert.That(_actualContextData.ParentUSI, Is.Null, "ParentUSI");
            }

            private class EntityWithRoleNamedProperties
            {
                public string Name { get; set; }

                public int SchoolId { get; set; }

                public int FirstEducationOrganizationId { get; set; }

                public int SecondEducationOrganizationId { get; set; }
            }
        }

        public class When_creating_authorization_context_WITH_an_explicit_property_name_mapping
            : LegacyTestFixtureBase
        {
            private RelationshipsAuthorizationContextData _actualContextData;

            private EntityWithRoleNamedProperties _suppliedEntity;

            protected override void Act()
            {
                var factory = new AuthorizationContextDataFactory();

                _suppliedEntity = new EntityWithRoleNamedProperties
                                  {
                                      Name = "Bob", SchoolId = 1, UnmappedEducationOrganizationId = 10, MappedEducationOrganizationId = 20
                                  };

                _actualContextData = factory.CreateContextData<RelationshipsAuthorizationContextData>(
                    _suppliedEntity,
                    new[]
                    {
                        new PropertyMapping("MappedEducationOrganizationId", "EducationOrganizationId")
                    });
            }

            [Assert]
            public void Should_create_authorization_context_using_supplied_property_name_mapping()
            {
                Assert.That(_actualContextData.EducationOrganizationId, Is.EqualTo(_suppliedEntity.MappedEducationOrganizationId));
            }

            [Assert]
            public void Should_leave_unmapped_properties_on_the_authorization_context_with_default_values()
            {
                // EducationOrganizationId should be explicitly mapped
                Assert.That(_actualContextData.EducationOrganizationId, Is.Not.Null, "EducationOrganizationId");

                Assert.That(_actualContextData.StateEducationAgencyId, Is.Null, "StateEducationAgencyId");
                Assert.That(_actualContextData.EducationServiceCenterId, Is.Null, "EducationServiceCenterId");
                Assert.That(_actualContextData.LocalEducationAgencyId, Is.Null, "LocalEducationAgencyId");
                Assert.That(_actualContextData.SchoolId, Is.Null, "SchoolId");
                Assert.That(_actualContextData.EducationOrganizationNetworkId, Is.Null, "EducationOrganizationNetworkId");

                Assert.That(_actualContextData.StudentUSI, Is.Null, "StudentUSI");
                Assert.That(_actualContextData.StaffUSI, Is.Null, "StaffUSI");
                Assert.That(_actualContextData.ParentUSI, Is.Null, "ParentUSI");
            }

            private class EntityWithRoleNamedProperties
            {
                public string Name { get; set; }

                public int SchoolId { get; set; }

                public int UnmappedEducationOrganizationId { get; set; }

                public int MappedEducationOrganizationId { get; set; }
            }
        }

        public class When_creating_authorization_context_WITH_an_explicit_property_name_mapping_where_named_properties_do_not_exist
            : LegacyTestFixtureBase
        {
            private EntityWithRoleNamedProperties _suppliedEntity;

            protected override void Act()
            {
                var factory = new AuthorizationContextDataFactory();

                _suppliedEntity = new EntityWithRoleNamedProperties
                                  {
                                      Name = "Bob", SchoolId = 1, UnmappedEducationOrganizationId = 10, MappedEducationOrganizationId = 20
                                  };

                factory.CreateContextData<RelationshipsAuthorizationContextData>(
                    _suppliedEntity,
                    new[]
                    {
                        new PropertyMapping("NonExistingSourcePropertyName", "SchoolId"),
                        new PropertyMapping("SchoolId", "NonExistingTargetPropertyName")
                    });
            }

            [Assert]
            public void Should_throw_a_MissingMember_exception_with_missing_members_and_associated_types_listed_in_the_message()
            {
                ActualException.ShouldBeExceptionType<MissingMemberException>();
                ActualException.MessageShouldContain("NonExistingSourcePropertyName");
                ActualException.MessageShouldContain("NonExistingTargetPropertyName");
                ActualException.MessageShouldContain(typeof(EntityWithRoleNamedProperties).FullName);
                ActualException.MessageShouldContain(typeof(RelationshipsAuthorizationContextData).FullName);
            }

            private class EntityWithRoleNamedProperties
            {
                public string Name { get; set; }

                public int SchoolId { get; set; }

                public int UnmappedEducationOrganizationId { get; set; }

                public int MappedEducationOrganizationId { get; set; }
            }
        }
    }
}

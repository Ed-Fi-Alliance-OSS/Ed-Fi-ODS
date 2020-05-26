// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.CodeGen.Metadata;
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Profiles
{
    [TestFixture, LocalTestOnly]
    public class ProfileMetadataValidatorTests
    {
        [LocalTestOnly]
        public class When_duplicate_profile_names_found_in_profiles_xml : TestFixtureBase
        {
            private const string DuplicateProfileTest = "DuplicateProfile.xml";
            private ProfileTestDataHelper _profileTestDataHelper;

            protected override void Arrange()
            {
                _profileTestDataHelper = new ProfileTestDataHelper(DuplicateProfileTest);
            }

            [Test]
            public void Should_Throw_Duplicate_Profile_Exception()
            {
                Assert.Throws<DuplicateProfileException>(
                    () => _profileTestDataHelper.Validator.ValidateMetadata());
            }
        }

        [LocalTestOnly]
        public class When_invalid_resource_found_in_profiles_xml : TestFixtureBase
        {
            private const string InvalidResourceTest = "InvalidResource.xml";
            private ProfileTestDataHelper _profileTestDataHelper;

            protected override void Arrange()
            {
                _profileTestDataHelper = new ProfileTestDataHelper(InvalidResourceTest);
            }

            [Test]
            public void Should_Throw_Invalid_Resource_Exception()
            {
                Assert.Throws<InvalidResourceException>(
                    () => _profileTestDataHelper.Validator.ValidateMetadata());
            }
        }

        [LocalTestOnly]
        public class When_missing_key_for_resource_found_in_profiles_xml : TestFixtureBase
        {
            private const string MissingForeignKey = "MissingForeignKey.xml";
            private ProfileTestDataHelper _profileTestDataHelper;

            protected override void Arrange()
            {
                _profileTestDataHelper = new ProfileTestDataHelper(MissingForeignKey);
            }

            [Test]
            public void Should_Throw_Missing_Foreign_Key_Exception()
            {
                Assert.Throws<MissingForeignKeyException>(
                    () => _profileTestDataHelper.Validator.ValidateMetadata());
            }
        }

        [LocalTestOnly]
        public class When_missing_incoming_reference_found_in_profiles_xml : TestFixtureBase
        {
            private const string IncomingReference = "IncomingReference.xml";
            private ProfileTestDataHelper _profileTestDataHelper;

            protected override void Arrange()
            {
                _profileTestDataHelper = new ProfileTestDataHelper(IncomingReference);
            }

            [Test]
            public void Should_Throw_Incoming_Reference_Exception()
            {
                Assert.Throws<IncomingReferenceException>(
                    () => _profileTestDataHelper.Validator.ValidateMetadata());
            }
        }

        [LocalTestOnly]
        public class When_invalid_property_name_found_in_profiles_xml : TestFixtureBase
        {
            private const string MissingProperty = "MissingProperty.xml";
            private ProfileTestDataHelper _profileTestDataHelper;

            protected override void Arrange()
            {
                _profileTestDataHelper = new ProfileTestDataHelper(MissingProperty);
            }

            [Test]
            public void Should_Throw_Missing_Property_Exception()
            {
                Assert.Throws<MissingPropertyException>(
                    () => _profileTestDataHelper.Validator.ValidateMetadata());
            }
        }

        [LocalTestOnly]
        public class When_invalid_property_reference_found_in_profiles_xml : TestFixtureBase
        {
            private const string InvalidReference = "InvalidReference.xml";
            private ProfileTestDataHelper _profileTestDataHelper;

            protected override void Arrange()
            {
                _profileTestDataHelper = new ProfileTestDataHelper(InvalidReference);
            }

            [Test]
            public void Should_Throw_Invalid_Property_Reference_Exception()
            {
                Assert.Throws<InvalidPropertyReferenceException>(
                    () => _profileTestDataHelper.Validator.ValidateMetadata());
            }
        }

        [LocalTestOnly]
        public class When_valid_profiles_xml_file_provided : TestFixtureBase
        {
            private const string ValidProfile = "Profiles.xml";
            private ProfileTestDataHelper _profileTestDataHelper;

            protected override void Arrange()
            {
                _profileTestDataHelper = new ProfileTestDataHelper(ValidProfile);
            }

            [Test]
            public void Should_Not_Throw_Exception()
            {
                Assert.DoesNotThrow(
                    () => _profileTestDataHelper.Validator.ValidateMetadata());
            }
        }
    }
}

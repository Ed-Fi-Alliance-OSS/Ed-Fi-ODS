// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers;
using EdFi.Ods.Common.Metadata.Profiles;
using FluentValidation.Results;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Profiles
{
    [TestFixture]
    public class ProfileMetadataValidatorTests
    {
        public class When_duplicate_profile_names_found_in_profiles_xml : TestFixtureBase
        {
            private const string TestDefinition = "DuplicateProfile.xml";

            private ValidationResult _actualValidationResult;

            protected override void Act()
            {
                var resourceModelProvider = this.GetResourceModelProvider("General");
                
                var xDoc = ProfileTestDataHelper.LoadProfileDocument(TestDefinition);

                var profilesMetadataValidator = new ProfileMetadataValidator(resourceModelProvider);
                _actualValidationResult = profilesMetadataValidator.Validate(xDoc);
            }

            [Test]
            public void Should_Throw_Duplicate_Profile_Exception()
            {
                _actualValidationResult.ShouldSatisfyAllConditions(
                    () => _actualValidationResult.IsValid.ShouldBeFalse(),
                    () => _actualValidationResult.Errors.First().ErrorMessage.ShouldContain("Duplicate profile name(s) encountered: 'The-Duplicated-Profile-Name'"));
            }
        }
        
        public class When_invalid_resource_found_in_profiles_xml : TestFixtureBase
        {
            private const string TestDefinition = "InvalidResource.xml";

            private ValidationResult _actualValidationResult;

            protected override void Act()
            {
                var resourceModelProvider = this.GetResourceModelProvider("General");

                var xDoc = ProfileTestDataHelper.LoadProfileDocument(TestDefinition);

                var profilesMetadataValidator = new ProfileMetadataValidator(resourceModelProvider);
                _actualValidationResult = profilesMetadataValidator.Validate(xDoc);
            }
        
            [Test]
            public void Should_Throw_Invalid_Resource_Exception()
            {
                _actualValidationResult.ShouldSatisfyAllConditions(
                    () => _actualValidationResult.IsValid.ShouldBeFalse(),
                    () => _actualValidationResult.Errors.First().ErrorMessage.ShouldContain("Resource 'edfi.InvalidResource' not found."));
            }
        }

        [TestFixture]
        public class When_including_or_excluding_singular_invalid_members_in_profiles_xml
        {
            [TestCase("InvalidProperty.xml", "NotAProperty")]
            [TestCase("InvalidEmbeddedObject.xml", "NotAnEmbeddedObject")]
            [TestCase("InvalidCollection.xml", "NotACollection")]
            public void Should_include_validation_failure_indicating_member_could_not_be_found(string modelName, string memberName)
            {
                var resourceModelProvider = this.GetResourceModelProvider("General");
                var xDoc = ProfileTestDataHelper.LoadProfileDocument(modelName);
                var profilesMetadataValidator = new ProfileMetadataValidator(resourceModelProvider);
                var result = profilesMetadataValidator.Validate(xDoc);

                string[] expectedMessages = 
                {
                    $"Profile 'Inclusion' definition for the read content type for resource 'edfi.TestResourceOne' attempted to include member '{memberName}' of 'edfi.TestResourceOne', but it doesn't exist. The following members are available: 'Name', 'SomethingId'.",
                    $"Profile 'Inclusion' definition for the write content type for resource 'edfi.TestResourceOne' attempted to include member '{memberName}' of 'edfi.TestResourceOne', but it doesn't exist. The following members are available: 'Name', 'SomethingId'.",
                    $"Profile 'Exclusion' definition for the read content type for resource 'edfi.TestResourceOne' attempted to exclude member '{memberName}' of 'edfi.TestResourceOne', but it doesn't exist. The following members are available: 'Name', 'SomethingId'.",
                    $"Profile 'Exclusion' definition for the write content type for resource 'edfi.TestResourceOne' attempted to exclude member '{memberName}' of 'edfi.TestResourceOne', but it doesn't exist. The following members are available: 'Name', 'SomethingId'.",
                };

                string[] actualMessages = result.Errors.Select(e => e.ErrorMessage).ToArray();

                Assert.That(actualMessages, Is.EquivalentTo(expectedMessages));
            }
        }

        [TestFixture]
        public class When_including_or_excluding_multiple_invalid_members_in_profiles_xml
        {
            [TestCase("InvalidProperties.xml", "NotAProperty")]
            [TestCase("InvalidEmbeddedObjects.xml", "NotAnEmbeddedObject")]
            [TestCase("InvalidCollections.xml", "NotACollection")]
            public void Should_include_validation_failure_indicating_multiple_members_could_not_be_found(string modelName, string memberBaseName)
            {
                var resourceModelProvider = this.GetResourceModelProvider("General");
                var xDoc = ProfileTestDataHelper.LoadProfileDocument(modelName);
                var profilesMetadataValidator = new ProfileMetadataValidator(resourceModelProvider);
                var result = profilesMetadataValidator.Validate(xDoc);

                string[] expectedMessages =
                {
                    $"Profile 'Inclusion' definition for the read content type for resource 'edfi.TestResourceOne' attempted to include members '{memberBaseName}1', '{memberBaseName}2' of 'edfi.TestResourceOne', but they don't exist. The following members are available: 'Name', 'SomethingId'.",
                    $"Profile 'Inclusion' definition for the write content type for resource 'edfi.TestResourceOne' attempted to include members '{memberBaseName}1', '{memberBaseName}2' of 'edfi.TestResourceOne', but they don't exist. The following members are available: 'Name', 'SomethingId'.",
                    $"Profile 'Exclusion' definition for the read content type for resource 'edfi.TestResourceOne' attempted to exclude members '{memberBaseName}1', '{memberBaseName}2' of 'edfi.TestResourceOne', but they don't exist. The following members are available: 'Name', 'SomethingId'.",
                    $"Profile 'Exclusion' definition for the write content type for resource 'edfi.TestResourceOne' attempted to exclude members '{memberBaseName}1', '{memberBaseName}2' of 'edfi.TestResourceOne', but they don't exist. The following members are available: 'Name', 'SomethingId'.",
                };
                
                string[] actualMessages = result.Errors.Select(e => e.ErrorMessage).ToArray();

                Assert.That(actualMessages, Is.EquivalentTo(expectedMessages));
            }
        }

        public class When_profiles_xml_fails_schema_validation : TestFixtureBase
        {
            private const string TestDefinition = "SchemaViolation.xml";

            private ValidationResult _actualValidationResult;

            protected override void Act()
            {
                var resourceModelProvider = this.GetResourceModelProvider("General");

                var xDoc = ProfileTestDataHelper.LoadProfileDocument(TestDefinition);

                var profilesMetadataValidator = new ProfileMetadataValidator(resourceModelProvider);
                _actualValidationResult = profilesMetadataValidator.Validate(xDoc);
            }
        
            [Test]
            public void Should_Throw_Invalid_Resource_Exception()
            {
                _actualValidationResult.ShouldSatisfyAllConditions(
                    () => _actualValidationResult.IsValid.ShouldBeFalse(),
                    () => _actualValidationResult.Errors.First().ErrorMessage.ShouldContain("The 'Profile' element is not declared."));
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;
using FakeItEasy;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using Assert = NUnit.Framework.Assert;

namespace EdFi.Ods.Features.UnitTests
{
    [TestFixture]
    public class OpenApiMetadataDefinitionsFactoryProfileNamingStrategyUnitTests
    {
        [Test]
        public void CallToGetResourceNameHandlesCamelCasingOfProfileSchemaNameEdFi_ResourceEducationOrganizationIdentificationCode()
        {
            string schema = "EdFi";
            string resourceName = "EducationOrganizationIdentificationCode";
            string contextualResourceName = "School";
            string operationNamingContext = "Readable";
            string expectedResult = "edFi_educationOrganizationIdentificationCode_readable";
            string expectedResultWithContextualResource = "edFi_educationOrganizationIdentificationCode_school_readable";

            AssertResults(schema, resourceName, contextualResourceName, operationNamingContext, expectedResult, expectedResultWithContextualResource);
        }

        [Test]
        public void CallToGetResourceNameHandlesCamelCasingOfProfileSchemaNameEdFi_ResourceSchool()
        {
            string schema = "EdFi"; // Expected casing outcome is edFi
            string resourceName = "School";
            string contextualResourceName = "School";
            string operationNamingContext = "Readable";
            string expectedResult = "edFi_school_readable";
            string expectedResultWithContextualResource = "edFi_school_school_readable";

            AssertResults(schema, resourceName, contextualResourceName, operationNamingContext, expectedResult, expectedResultWithContextualResource);
        }

        [Test]
        public void CallToGetResourceNameHandlesCamelCasingOfProfileSchemaNameTPDM_ResourceSchoolExtension()
        {
            string schema = "TPDM"; //Expected casing outcome is tpdm
            string resourceName = "SchoolExtension";
            string contextualResourceName = "SchoolExtension";
            string operationNamingContext = "Readable";
            string expectedResult = "tpdm_schoolExtension_readable";
            string expectedResultWithContextualResource = "tpdm_schoolExtension_schoolExtension_readable";

            AssertResults(schema, resourceName, contextualResourceName, operationNamingContext, expectedResult, expectedResultWithContextualResource);
        }

        [Test]
        public void CallToGetResourceNameHandlesCamelCasingOfProfileSchemaNameTX_ResourceExtendedSchoolYearServicesAttendance()
        {
            string schema = "TX"; // Expected casing outcome is tx
            string resourceName = "ExtendedSchoolYearServicesAttendance";
            string contextualResourceName = "ExtendedSchoolYearServicesAttendance";
            string operationNamingContext = "Readable";
            string expectedResult = "tx_extendedSchoolYearServicesAttendance_readable";
            string expectedResultWithContextualResource = "tx_extendedSchoolYearServicesAttendance_extendedSchoolYearServicesAttendance_readable";

            AssertResults(schema, resourceName, contextualResourceName, operationNamingContext, expectedResult, expectedResultWithContextualResource);
        }

        private void AssertResults(string schema, string resourceName, string contextualResourceName, string operationNamingContext, string expectedResult, string expectedResultWithContextualResource)
        {
            var actualResult = GetActualResult(schema, resourceName, operationNamingContext);
            Assert.AreEqual(expectedResult, actualResult);

            actualResult = GetActualResultWithContextualResource(schema, resourceName, contextualResourceName, operationNamingContext);
            Assert.AreEqual(expectedResultWithContextualResource, actualResult);
        }
        private string GetActualResult(string schema, string resourceName, string operationNamingContext)
        {
            var mockResource = A.Fake<Resource>(x => x.WithArgumentsForConstructor(() => new Resource(resourceName)));

            A.CallTo(mockResource).Where(a => a.Method.Name.Equals("get_SchemaProperCaseName"))
                .WithReturnType<string>()
                .Returns(schema);

            var mockOpenApiMetadataResourceContext = A.Fake<IOpenApiMetadataResourceContext>();

            A.CallTo(mockOpenApiMetadataResourceContext)
                .Where(a => a.Method.Name.Equals("get_ContextualResource"))
                .WithReturnType<Resource?>()
              .Returns(null);

            A.CallTo(mockOpenApiMetadataResourceContext).Where(a => a.Method.Name.Equals("get_OperationNamingContext"))
               .WithReturnType<string>()
               .Returns(operationNamingContext);

            var sut = new OpenApiMetadataDefinitionsFactoryProfileNamingStrategy();
            return sut.GetResourceName(mockResource, mockOpenApiMetadataResourceContext);
        }

        private string GetActualResultWithContextualResource(string schema, string resourceName, string contextualResourceName , string operationNamingContext)
        {
            var mockResource = A.Fake<Resource>(x => x.WithArgumentsForConstructor(() => new Resource(resourceName)));
            var mockContextualResource = A.Fake<Resource>(x => x.WithArgumentsForConstructor(() => new Resource(contextualResourceName)));

            A.CallTo(mockResource).Where(a => a.Method.Name.Equals("get_SchemaProperCaseName"))
                .WithReturnType<string>()
                .Returns(schema);

            var mockOpenApiMetadataResourceContext = A.Fake<IOpenApiMetadataResourceContext>();

            A.CallTo(mockOpenApiMetadataResourceContext).Where(a => a.Method.Name.Equals("get_ContextualResource"))
              .WithReturnType<Resource>()
              .Returns(mockContextualResource);


            A.CallTo(mockOpenApiMetadataResourceContext).Where(a => a.Method.Name.Equals("get_OperationNamingContext"))
               .WithReturnType<string>()
               .Returns(operationNamingContext);

            var sut = new OpenApiMetadataDefinitionsFactoryProfileNamingStrategy();
            return sut.GetResourceName(mockResource, mockOpenApiMetadataResourceContext);
        }
    }
}
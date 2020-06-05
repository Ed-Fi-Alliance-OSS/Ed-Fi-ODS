// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.RouteInformations;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.NetCore.Tests
{
    [TestFixture]
    public class OpenApiMetadataRouteInformationTests
    {
        public class When_Getting_the_route_information_for_all
        {
            [Test]
            public void Should_return_the_correct_route_for_sandbox()
            {
                // Arrange
                var apiSettings = new ApiSettings {Mode = ApiMode.Sandbox.Value};

                // Act
                var result = new AllOpenApiMetadataRouteInformation(apiSettings).GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.All);
                result.Template.ShouldBe("metadata/data/v3/swagger.json");
            }

            [Test]
            public void Should_return_the_correct_route_for_shared_instance()
            {
                // Arrange
                var apiSettings = new ApiSettings {Mode = ApiMode.SharedInstance.Value};

                // Act
                var result = new AllOpenApiMetadataRouteInformation(apiSettings).GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.All);
                result.Template.ShouldBe("metadata/data/v3/swagger.json");
            }

            [Test]
            public void Should_return_the_correct_route_for_year_specific()
            {
                // Arrange
                var apiSettings = new ApiSettings {Mode = ApiMode.YearSpecific.Value};

                // Act
                var result = new AllOpenApiMetadataRouteInformation(apiSettings).GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.All);
                result.Template.ShouldBe("metadata/data/v3/{schoolYearFromRoute:regex(^\\d{{4}}$)}/swagger.json");
            }
        }

        public class When_Getting_the_route_information_for_schema
        {
            [Test]
            public void Should_return_the_correct_route_for_sandbox()
            {
                // Arrange
                var apiSettings = new ApiSettings {Mode = ApiMode.Sandbox.Value};

                // Act
                var result = new SchemaOpenApiMetadataRouteInformation(apiSettings).GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.Schema);
                result.Template.ShouldBe("metadata/data/v3/{document}/swagger.json");
            }

            [Test]
            public void Should_return_the_correct_route_for_shared_instance()
            {
                // Arrange
                var apiSettings = new ApiSettings {Mode = ApiMode.SharedInstance.Value};

                // Act
                var result = new SchemaOpenApiMetadataRouteInformation(apiSettings).GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.Schema);
                result.Template.ShouldBe("metadata/data/v3/{document}/swagger.json");
            }

            [Test]
            public void Should_return_the_correct_route_for_year_specific()
            {
                // Arrange
                var apiSettings = new ApiSettings {Mode = ApiMode.YearSpecific.Value};

                // Act
                var result = new SchemaOpenApiMetadataRouteInformation(apiSettings).GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.Schema);
                result.Template.ShouldBe("metadata/data/v3/{schoolYearFromRoute:regex(^\\d{{4}}$)}/{document}/swagger.json");
            }
        }

        public class When_Getting_the_route_information_for_resource_type
        {
            [Test]
            public void Should_return_the_correct_route_for_sandbox()
            {
                // Arrange
                var apiSettings = new ApiSettings {Mode = ApiMode.Sandbox.Value};

                // Act
                var result = new ResourceTypeOpenMetadataRouteInformation(apiSettings).GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.ResourceTypes);
                result.Template.ShouldBe("metadata/data/v3/{document}/swagger.json");
            }

            [Test]
            public void Should_return_the_correct_route_for_shared_instance()
            {
                // Arrange
                var apiSettings = new ApiSettings {Mode = ApiMode.SharedInstance.Value};

                // Act
                var result = new ResourceTypeOpenMetadataRouteInformation(apiSettings).GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.ResourceTypes);
                result.Template.ShouldBe("metadata/data/v3/{document}/swagger.json");
            }

            [Test]
            public void Should_return_the_correct_route_for_year_specific()
            {
                // Arrange
                var apiSettings = new ApiSettings {Mode = ApiMode.YearSpecific.Value};

                // Act
                var result = new ResourceTypeOpenMetadataRouteInformation(apiSettings).GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.ResourceTypes);
                result.Template.ShouldBe("metadata/data/v3/{schoolYearFromRoute:regex(^\\d{{4}}$)}/{document}/swagger.json");
            }
        }
    }
}

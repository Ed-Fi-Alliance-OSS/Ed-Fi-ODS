// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Constants;
using EdFi.Ods.Features.RouteInformations;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.RouteInformations
{
    [TestFixture]
    public class OpenApiMetadataRouteInformationTests
    {
        public class When_Getting_the_route_information_for_all
        {
            [Test]
            public void Should_return_the_correct_route()
            {
                // Arrange

                // Act
                var result = new AllOpenApiMetadataRouteInformation().GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.All);
                result.Template.ShouldBe("metadata/data/v3/swagger.json");
            }
        }

        public class When_Getting_the_route_information_for_schema
        {
            [Test]
            public void Should_return_the_correct_route()
            {
                // Arrange

                // Act
                var result = new SchemaOpenApiMetadataRouteInformation().GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.Schema);
                result.Template.ShouldBe("metadata/data/v3/{document}/swagger.json");
            }
        }

        public class When_Getting_the_route_information_for_resource_type
        {
            [Test]
            public void Should_return_the_correct_route()
            {
                // Arrange

                // Act
                var result = new ResourceTypeOpenMetadataRouteInformation().GetRouteInformation();

                // Assert
                result.Name.ShouldBe(MetadataRouteConstants.ResourceTypes);
                result.Template.ShouldBe("metadata/data/v3/{document}/swagger.json");
            }
        }
    }
}

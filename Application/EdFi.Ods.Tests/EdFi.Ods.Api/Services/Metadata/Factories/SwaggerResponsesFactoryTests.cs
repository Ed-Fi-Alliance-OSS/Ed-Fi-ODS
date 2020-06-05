// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Factories
{
    [TestFixture]
    public class SwaggerResponsesFactoryTests
    {
        public class When_creating_responses_for_a_single_instance_or_year_specific_ods : TestFixtureBase
        {
            private IDictionary<string, Response> _swaggerResponses;

            protected override void Act()
            {
                _swaggerResponses = new SwaggerResponsesFactory().Create();
            }

            [Assert]
            public void Should_contain_201_Created()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("Created"));
            }

            [Assert]
            public void Should_contain_204_Updated()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("Updated"));
            }

            [Assert]
            public void Should_contain_204_Deleted()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("Deleted"));
            }

            [Assert]
            public void Should_contain_304_NotModified()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("NotModified"));
            }

            [Assert]
            public void Should_contain_400_BadRequest()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("BadRequest"));
            }

            [Assert]
            public void Should_contain_401_Unauthorized()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("Unauthorized"));
            }

            [Assert]
            public void Should_contain_403_Forbidden()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("Forbidden"));
            }

            [Assert]
            public void Should_contain_404_NotFound()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("NotFound"));
            }

            [Assert]
            public void Should_contain_409_Conflict()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("Conflict"));
            }

            [Assert]
            public void Should_contain_412_PreconditionFailed()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("PreconditionFailed"));
            }

            [Assert]
            public void Should_contain_500_Error()
            {
                Assert.That(_swaggerResponses.Keys, Has.Member("Error"));
            }
        }
    }
}

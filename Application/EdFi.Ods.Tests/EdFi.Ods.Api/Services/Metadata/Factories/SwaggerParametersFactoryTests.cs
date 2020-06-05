// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Factories
{
    [TestFixture]
    public class SwaggerParametersFactoryTests
    {
        public class When_creating_parameters_for_a_single_instance_or_year_specific_ods : TestFixtureBase
        {
            private IDictionary<string, Parameter> _swaggerParameters;

            protected override void Act()
            {
                _swaggerParameters =
                    new SwaggerParametersFactory().Create(false);
            }

            [Assert]
            public void Should_contain_offset() => _swaggerParameters.Keys.ShouldContain("offset");

            [Assert]
            public void Should_contain_limit() => _swaggerParameters.Keys.ShouldContain("limit");

            [Assert]
            public void Should_contain_MinChangeVersion() => _swaggerParameters.Keys.ShouldContain("MinChangeVersion");

            [Assert]
            public void Should_contain_MaxChangeVersion() => _swaggerParameters.Keys.ShouldContain("MaxChangeVersion");

            [Assert]
            public void Should_contain_if_none_match() => _swaggerParameters.Keys.ShouldContain("If-None-Match");

            [Assert]
            public void Should_contain_fields() => _swaggerParameters.Keys.ShouldContain("fields");

            [Assert]
            public void Should_contain_queryExpression() => _swaggerParameters.Keys.ShouldContain("queryExpression");
        }
    }
}

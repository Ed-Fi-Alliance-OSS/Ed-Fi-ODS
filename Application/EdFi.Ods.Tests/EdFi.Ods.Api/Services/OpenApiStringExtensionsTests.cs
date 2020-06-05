// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Features.OpenApiMetadata;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services
{
    public class OpenApiStringExtensionsTests
    {
        [TestFixture]
        public class When_enhancing_resource_description
        {
            [TestCase("Description", false, null, "Description", "Non-deprecated resource entity with a valid description")]
            [TestCase("", false, null, "", "Non-deprecated resource entity with an empty description")]
            [TestCase(null, false, null, "", "Non-deprecated resource entity with a null description")]
            [TestCase("Description", true, null, "Deprecated: Description", "Deprecated resource entity with a valid description and null deprecation reasons")]
            [TestCase("", true, null, "Deprecated", "Deprecated resource entity with an empty description and null deprecation reasons")]
            [TestCase(null, true, null, "Deprecated", "Deprecated resource entity with a null description and null deprecation reasons")]
            [TestCase("Description", true, new[] { "Deprecation Reason" }, "Deprecated: Deprecation Reason Description", "Deprecated resource entity with a valid description and one deprecation reason")]
            [TestCase("", true, new[] { "Deprecation Reason" }, "Deprecated: Deprecation Reason", "Deprecated resource entity with an empty description and one deprecation reason")]
            [TestCase(null, true, new[] { "Deprecation Reason" }, "Deprecated: Deprecation Reason", "Deprecated resource entity with a null description and one deprecation reason")]
            [TestCase("Description", true, new[] { "Deprecation Reason 1", "Deprecation Reason 2" }, "Deprecated: Deprecation Reason 1 Deprecation Reason 2 Description", "Deprecated resource entity with a valid description and multiple deprecation reasons")]
            [TestCase("", true, new[] { "Deprecation Reason 1", "Deprecation Reason 2" }, "Deprecated: Deprecation Reason 1 Deprecation Reason 2", "Deprecated resource entity with an empty description and multiple deprecation reasons")]
            [TestCase(null, true, new[] { "Deprecation Reason 1", "Deprecation Reason 2" }, "Deprecated: Deprecation Reason 1 Deprecation Reason 2", "Deprecated resource entity with a null description and multiple deprecation reasons")]
            public void Should_generate_valid_description(string description, bool isDeprecated, string[] deprecationReasons, string expectedOutputDescription, string scenarioSummary)
            {
                description.EnhanceResourceDescription(isDeprecated, deprecationReasons).ShouldBe(expectedOutputDescription, $"Scenario: {scenarioSummary} failed comparison.");
            }
        }

        [TestFixture]
        public class When_scrubbing_string_for_OpenApi_display
        {
            [Test]
            public void Should_not_change_valid_string()
            {
                string content = "StringContent<>!@#$%^&*()";
                content.ScrubForOpenApi().ShouldBe(content);
            }

            [Test]
            public void Should_scrub_invalid_characters_with_spaces()
            {
                string content = "String\nContent\rMore\tContent";
                content.ScrubForOpenApi().ShouldBe("String Content More Content");
            }

            [Test]
            public void Should_handle_null_string()
            {
                ((string) null).ScrubForOpenApi().ShouldBe(string.Empty);
            }

            [Test]
            public void Should_handle_empty_string()
            {
                string content = "";
                content.ScrubForOpenApi().ShouldBe(content);
            }
        }
    }
}

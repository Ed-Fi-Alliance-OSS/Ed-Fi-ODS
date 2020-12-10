// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.LoadTools.BulkLoadClient.Application;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class YearSpecificConfigurationTests
    {
        [Test]
        public void ShouldReplaceYearSuccessfully()
        {
            int year = DateTime.Now.Year;

            var args = new[]
            {
                "-m",
                "https://api-stage.ed-fi.org/YearSpecific_v5.2.0/api/metadata/1999",
                "-a",
                "https://api-stage.ed-fi.org/YearSpecific_v5.2.0/api/data/v3/1999",
                "-g",
                "https://api-stage.ed-fi.org/YearSpecific_v5.2.0/api/metadata/data/v3/1999/dependencies",
                "-o",
                "https://api-stage.ed-fi.org/YearSpecific_v5.2.0/api/oauth/token",
                "-y",
                year.ToString(),
            };

            var config = new ConfigurationBuilder()
                .AddCommandLine(
                    args, new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {"-a", "OdsApi:ApiUrl"},
                        {"-y", "OdsApi:SchoolYear"},
                        {"-m", "OdsApi:MetadataUrl"},
                        {"-o", "OdsApi:OAuthUrl"},
                        {"-g", "OdsApi:DependenciesUrl"}
                    }).
                Build();

            config["OdsApi:ApiMode"] = "Year Specific";

            var result = BulkLoadClientConfiguration.Create(config);

            result.ApiUrl.ShouldBe($"https://api-stage.ed-fi.org/YearSpecific_v5.2.0/api/data/v3/{year}");
            result.MetadataUrl.ShouldBe($"https://api-stage.ed-fi.org/YearSpecific_v5.2.0/api/metadata/{year}");
            result.DependenciesUrl.ShouldBe($"https://api-stage.ed-fi.org/YearSpecific_v5.2.0/api/metadata/data/v3/{year}/dependencies");
            result.OauthUrl.ShouldBe($"https://api-stage.ed-fi.org/YearSpecific_v5.2.0/api/oauth/token");
        }
    }
}

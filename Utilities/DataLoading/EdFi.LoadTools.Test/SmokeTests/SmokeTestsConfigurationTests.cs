// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.LoadTools.SmokeTest;
using EdFi.SmokeTest.Console.Application;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Assert = NUnit.Framework.Legacy.ClassicAssert;

namespace EdFi.LoadTools.Test.SmokeTests
{
    [TestFixture]
    public class SmokeTestsConfigurationTests
    {
        [Test]
        public void Create_should_default_default_numeric_fallback_max_to_999()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        ["TestSet"] = "DestructiveSdk"
                    })
                .Build();

            var smokeTestsConfiguration = SmokeTestsConfiguration.Create(configuration);

            Assert.AreEqual(999, smokeTestsConfiguration.DefaultNumericFallbackMax);
        }

        [Test]
        public void Create_should_read_default_numeric_fallback_max_from_ods_api_configuration()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        ["TestSet"] = "DestructiveSdk",
                        ["OdsApi:DefaultNumericFallbackMax"] = "42"
                    })
                .Build();

            var smokeTestsConfiguration = SmokeTestsConfiguration.Create(configuration);

            Assert.AreEqual(42, smokeTestsConfiguration.DefaultNumericFallbackMax);
        }

        [Test]
        public void Validator_should_reject_non_positive_default_numeric_fallback_max()
        {
            var configuration = new SmokeTestsConfiguration
            {
                ApiUrl = "http://localhost:54746/data/v3",
                OAuthUrl = "http://localhost:54746/oauth/token",
                MetadataUrl = "http://localhost:54746/metadata",
                XsdMetadataUrl = "http://localhost:54746/metadata/xsd",
                SdkLibraryPath = typeof(SmokeTestsConfigurationTests).Assembly.Location,
                NamespacePrefix = "uri://ed-fi.org",
                TestSet = TestSet.DestructiveSdk,
                EducationOrganizationIdOverrides = new Dictionary<string, int>
                {
                    ["LocalEducationAgencyId"] = 100000
                },
                UnifiedProperties = new[] { "FiscalYear" },
                DefaultNumericFallbackMax = 0
            };

            var validator = new SmokeTestConfigurationValidator(configuration);

            Assert.IsFalse(validator.IsValid());
            Assert.IsTrue(validator.ErrorText.Contains("OdsApi:DefaultNumericFallbackMax must be greater than zero."));
        }
    }
}

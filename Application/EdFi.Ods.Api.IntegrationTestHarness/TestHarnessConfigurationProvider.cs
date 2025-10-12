// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EdFi.Ods.Api.IntegrationTestHarness
{
    public class TestHarnessConfigurationProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TestHarnessConfigurationProvider));
        private readonly IConfiguration _configuration;
        private readonly Lazy<TestHarnessConfiguration> _testHarnessConfiguration;

        public TestHarnessConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            _testHarnessConfiguration = new Lazy<TestHarnessConfiguration>(BuildTestHarnessConfiguration);
        }

        public TestHarnessConfiguration GetTestHarnessConfiguration() => _testHarnessConfiguration.Value;

        private TestHarnessConfiguration BuildTestHarnessConfiguration()
        {
            var testHarnessConfiguration = new TestHarnessConfiguration();
            var configurationFilePath = _configuration.GetValue<string>("configurationFilePath");

            if (!string.IsNullOrEmpty(configurationFilePath))
            {
                _logger.Debug($"configurationPath = {configurationFilePath}");

                if (!File.Exists(configurationFilePath))
                {
                    throw new Exception($"Configuration file {configurationFilePath} does not exists.");
                }

                testHarnessConfiguration =
                    JsonConvert.DeserializeObject<TestHarnessConfiguration>(File.ReadAllText(configurationFilePath));
            }
            else
            {
                testHarnessConfiguration.Vendors = BuildDefaultVendor();
            }

            return testHarnessConfiguration;
        }

        private List<Vendor> BuildDefaultVendor()
        {
            var apiClient = new ApiClient
            {
                ApiClientName = "Api",
                LocalEducationOrganizations = new() { 255901 }
            };

            var application = new Application
            {
                ApplicationName = "Default Application",
                ClaimSetName = "Ed-Fi Sandbox",
                ApiClients = new List<ApiClient> { apiClient }
            };

            var vendor = new Vendor
            {
                Email = "test@ed-fi.org",
                VendorName = "Test Admin",
                Applications = new List<Application> { application },
                NamespacePrefixes = new List<string>
                {
                    "uri://ed-fi.org",
                    "uri://gbisd.edu",
                    "uri://tpdm.ed-fi.org"
                }
            };

            return new List<Vendor> { vendor };
        }
    }
}

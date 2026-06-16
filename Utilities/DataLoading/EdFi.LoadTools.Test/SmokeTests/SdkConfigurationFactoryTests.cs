// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.SmokeTest.Console.Application;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.LoadTools.Test.SmokeTests
{
    /// <summary>
    ///     Exercises the real legacy (old-generator) branch of <see cref="SdkConfigurationFactory" />:
    ///     when the SDK assembly exposes <c>Client.Configuration</c> but no <c>Client.HostConfiguration</c>,
    ///     the factory must construct the Configuration object directly (not a DI <see cref="IServiceProvider" />),
    ///     set its <c>AccessToken</c> from the token handler, and pass the configured data-management API URL
    ///     through as the base path unchanged. The stub assembly shape below stands in for an old-generator
    ///     SDK so the test is independent of any published SDK version.
    /// </summary>
    [TestFixture]
    public class SdkConfigurationFactoryTests
    {
        // Namespace prefix of the stub Client.Configuration below. The factory composes
        // "{prefix}.Client.HostConfiguration" and "{prefix}.Client.Configuration"; the former is absent
        // from this assembly (no HostConfiguration type), so the factory selects the legacy branch.
        private const string StubNamespacePrefix = "EdFi.LoadTools.Test.SmokeTests.LegacySdkStub";

        [Test]
        public void Legacy_mode_builds_a_configuration_object_with_token_and_data_management_base_path()
        {
            const string dataManagementApiUrl = "http://localhost:8765/data/v3";
            const string bearerToken = "LEGACY-BEARER-TOKEN";

            var apiConfiguration = A.Fake<IApiConfiguration>();
            A.CallTo(() => apiConfiguration.Url).Returns(dataManagementApiUrl);

            var sdkLibraryConfiguration = A.Fake<ISdkLibraryConfiguration>();
            A.CallTo(() => sdkLibraryConfiguration.Path)
                .Returns(typeof(LegacySdkStub.Client.Configuration).Assembly.Location);
            A.CallTo(() => sdkLibraryConfiguration.SdkNamespacePrefix).Returns(StubNamespacePrefix);

            var tokenHandler = A.Fake<IOAuthTokenHandler>();
            A.CallTo(() => tokenHandler.GetBearerToken()).Returns(bearerToken);

            // No throw even though Client.HostConfiguration is absent from the (stub) SDK assembly.
            var factory = Should.NotThrow(
                () => new SdkConfigurationFactory(apiConfiguration, sdkLibraryConfiguration, tokenHandler));

            var configuration = factory.SdkConfiguration;

            // Legacy mode returns the Configuration object itself, NOT the DI service provider.
            configuration.ShouldNotBeNull();
            configuration.ShouldBeOfType<LegacySdkStub.Client.Configuration>();
            configuration.ShouldNotBeAssignableTo<IServiceProvider>();

            var legacyConfiguration = (LegacySdkStub.Client.Configuration) configuration;

            // AccessToken is taken from IOAuthTokenHandler.GetBearerToken().
            legacyConfiguration.AccessToken.ShouldBe(bearerToken);
            A.CallTo(() => tokenHandler.GetBearerToken()).MustHaveHappened();

            // The base path passed into the Configuration ctor is the configured (data-management) URL,
            // unchanged - old-generator operation paths omit /data/v3, so the base path must already
            // include it.
            legacyConfiguration.BasePath.ShouldBe(dataManagementApiUrl);
        }
    }
}

namespace EdFi.LoadTools.Test.SmokeTests.LegacySdkStub.Client
{
    using System.Collections.Generic;

    // Stub of an old-generator SDK's Client.Configuration. Its full name ends in ".Client.Configuration"
    // (and there is deliberately no sibling ".Client.HostConfiguration" type) so SdkConfigurationFactory
    // probes past the new-generator host-configuration type and takes the legacy branch. The namespace has
    // no "Apis.All"/"Models.All" segment, so the SdkCategorizer assembly scan ignores it.
    public class Configuration
    {
        // Mirrors the real generated 4-arg ctor (defaultHeaders, apiKey, apiKeyPrefix, basePath) the
        // factory invokes via Activator.CreateInstance.
        public Configuration(
            IDictionary<string, string> defaultHeaders,
            IDictionary<string, string> apiKey,
            IDictionary<string, string> apiKeyPrefix,
            string basePath)
        {
            DefaultHeaders = defaultHeaders;
            ApiKey = apiKey;
            ApiKeyPrefix = apiKeyPrefix;
            BasePath = basePath;
        }

        public IDictionary<string, string> DefaultHeaders { get; }

        public IDictionary<string, string> ApiKey { get; }

        public IDictionary<string, string> ApiKeyPrefix { get; }

        public string BasePath { get; }

        public string AccessToken { get; set; }
    }
}

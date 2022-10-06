// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebApi.IntegrationTests.YearSpecific
{
    [SetUpFixture]
    public class YearSpecificHostGlobalFixture : OneTimeGlobalDatabaseSetupBase
    {
        public static YearSpecificHostGlobalFixture Instance { get; private set; }

        public YearSpecificHostGlobalFixture()
        {
            Instance = this;
        }

        public override string[] OdsTokens { get; set; } = { "2014", "2015" };

        public HttpClient HttpClient { get; private set; }

        protected override string DatabaseCopyPrefix
        {
            get => "EdFiOdsWebApiIntegrationTestsYearSpecific";
        }
        
        private IHost Host { get; set; }

        [OneTimeSetUp]
        public override async Task OneTimeSetUpAsync()
        {
            await base.OneTimeSetUpAsync();

            var executableAbsoluteDirectory = Path.GetDirectoryName(typeof(GlobalWebApiIntegrationTestFixture).Assembly.Location);

            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(configBuilder =>
                    {
                        configBuilder.SetBasePath(executableAbsoluteDirectory);
                        configBuilder.AddConfiguration(Configuration);
                        configBuilder.AddJsonFile(Path.Combine(executableAbsoluteDirectory, "appsettings.YearSpecific.json"));
                    })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(TestConstants.YearSpecificBaseUrl);
                    })
                .Build();

            HttpClient = new HttpClient {BaseAddress = new Uri(TestConstants.YearSpecificBaseUrl)};

            await Host.StartAsync(GlobalWebApiIntegrationTestFixture.Instance.CancellationToken);
        }

        [OneTimeTearDown]
        public override async Task OneTimeTearDownAsync()
        {
            await base.OneTimeTearDownAsync();

            HttpClient.Dispose();

            await Host?.StopAsync();
            Host?.Dispose();
        }
    }
}

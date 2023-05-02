// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    [SetUpFixture]
    public class HostGlobalFixture : OneTimeGlobalDatabaseSetupBase
    {
        public static HostGlobalFixture Instance { get; private set; }

        public HostGlobalFixture()
        {
            Instance = this;
        }

        public HttpClient HttpClient { get; private set; }

        protected override string DatabaseCopyPrefix
        {
            get => "EdFiOdsWebApiIntegrationTestsSandbox";
        }

        private IHost Host { get; set; }

        [OneTimeSetUp]
        public override async Task OneTimeSetUpAsync()
        {
            await base.OneTimeSetUpAsync();

            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                 .ConfigureAppConfiguration(configurationBuilder => {
                     configurationBuilder.SetBasePath(TestContext.CurrentContext.TestDirectory);
                     configurationBuilder.AddConfiguration(Configuration);
                 })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(TestConstants.BaseUrl);
                    })
                .Build();

            await Host.StartAsync(GlobalWebApiIntegrationTestFixture.Instance.CancellationToken);

            HttpClient = new HttpClient {BaseAddress = new Uri(TestConstants.BaseUrl)};
        }

        [OneTimeTearDown]
        public override async Task OneTimeTearDownAsync()
        {
            await base.OneTimeTearDownAsync();

            HttpClient?.Dispose();

            await Host?.StopAsync();
            Host?.Dispose();
        }
    }
}

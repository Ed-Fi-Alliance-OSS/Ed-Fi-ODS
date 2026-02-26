// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using EdFi.Ods.Common.Infrastructure.Compatibility;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Npgsql;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    [SetUpFixture]
    public class CompositesSpecFlowTestFixture : OneTimeGlobalDatabaseSetupBase
    {
        public static CompositesSpecFlowTestFixture Instance { get; private set; }

        public CompositesSpecFlowTestFixture()
        {
            Instance = this;
        }

        public IServiceProvider ServiceProvider { get; private set; }

        private IHost _host;

        [OneTimeSetUp]
        public override async Task OneTimeSetUpAsync()
        {
            // Configure Npgsql for .NET 10+ DateOnly/TimeOnly compatibility
            // Npgsql 10.0+ maps SQL DATE to DateOnly by default, but NHibernate expects DateTime
            // See: https://www.npgsql.org/doc/release-notes/10.0.html
            #pragma warning disable CS0618 // GlobalTypeMapper is obsolete but required for NHibernate compatibility
            #pragma warning disable NPG9001 // Type is for evaluation purposes only and is subject to change or removal in future updates
            NpgsqlConnection.GlobalTypeMapper.AddTypeInfoResolverFactory(new LegacyDateAndTimeResolverFactory());
            #pragma warning restore NPG9001
            #pragma warning restore CS0618

                 
            await base.OneTimeSetUpAsync();

            var executableAbsoluteDirectory = AppContext.BaseDirectory;
            ConfigureLogging(executableAbsoluteDirectory);

            // Create and start up the host
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(configurationBuilder =>
                {
                    configurationBuilder.AddConfiguration(Configuration);
                    configurationBuilder.SetBasePath(TestContext.CurrentContext.TestDirectory);
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(CompositesTestConstants.BaseUrl);
                    })
                .Build();

            ServiceProvider = _host.Services;

            await _host.StartAsync();
        }

        [OneTimeTearDown]
        public override async Task OneTimeTearDownAsync()
        {
            await base.OneTimeTearDownAsync();

            await _host?.StopAsync();
            _host?.Dispose();
        }

        private void ConfigureLogging(string executableAbsoluteDirectory)
        {
            var assembly = typeof(CompositesSpecFlowTestFixture).GetTypeInfo().Assembly;

            string configPath = Path.Combine(executableAbsoluteDirectory, "log4net.config");

            XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
        }

        protected override string DatabaseCopyPrefix
        {
            get => "EdFiOdsWebApiCompositeSpecFlowTests";
        }
    }
}

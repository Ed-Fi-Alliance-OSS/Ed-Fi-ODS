// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using NUnit.Framework;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    [SetUpFixture]
    public class GlobalWebApiIntegrationTestFixture
    {
        private readonly string _databasePrefix = "EdFi_IntegrationTests_";

        public static string DatabaseName { get; set; }

        public static CancellationToken CancellationToken { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            DatabaseName = _databasePrefix + Guid.NewGuid().ToString("N");

            CancellationToken = new CancellationToken();

            var executableAbsoluteDirectory = Path.GetDirectoryName(typeof(GlobalWebApiIntegrationTestFixture).Assembly.Location);
            ConfigureLogging(executableAbsoluteDirectory);

            static void ConfigureLogging(string executableAbsoluteDirectory)
            {
                var assembly = typeof(GlobalWebApiIntegrationTestFixture).GetTypeInfo().Assembly;

                string configPath = Path.Combine(executableAbsoluteDirectory, "log4net.config");

                XmlConfigurator.Configure(LogManager.GetRepository(assembly), new FileInfo(configPath));
            }
        }
    }
}

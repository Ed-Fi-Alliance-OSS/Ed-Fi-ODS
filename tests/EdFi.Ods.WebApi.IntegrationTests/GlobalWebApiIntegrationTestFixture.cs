// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Reflection;
using System.Threading;
using log4net;
using log4net.Config;
using NUnit.Framework;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    [SetUpFixture]
    public class GlobalWebApiIntegrationTestFixture
    {
        public static GlobalWebApiIntegrationTestFixture Instance { get; private set; }

        public GlobalWebApiIntegrationTestFixture()
        {
            Instance = this;
        }

        public CancellationToken CancellationToken { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
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

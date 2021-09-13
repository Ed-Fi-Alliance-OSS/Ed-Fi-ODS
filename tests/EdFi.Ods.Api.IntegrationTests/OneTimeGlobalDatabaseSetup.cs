// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Api.IntegrationTests
{
    [SetUpFixture]
    public class OneTimeGlobalDatabaseSetup
    {
        private const string DatabasePrefix = "EdFi_Integration_Test_";

        private IConfigurationRoot _configuration;

        public static string SqlServerConnectionString { get; private set; }

        public static string PostgreSqlConnectionString { get; private set; }

        public async Task EnsureDockerContainer()
        {
            var dockerUri = Environment.OSVersion.Platform == PlatformID.Win32NT
                ? "npipe://./pipe/docker_engine"
                : "unix:///var/run/docker.sock";

            var dockerClient = new DockerClientConfiguration(new Uri(dockerUri)).CreateClient();

            await dockerClient.Images.CreateImageAsync(
                new ImagesCreateParameters {FromImage = "postgres:11-alpine"}, null, new Progress<JSONMessage>());

            var volumes = await dockerClient.Volumes.ListAsync();
            var volumeCount = volumes.Volumes.Count(v => v.Name == $"{DatabasePrefix}Volume");

            if (volumeCount <= 0)
            {
                await dockerClient.Volumes.CreateAsync(new VolumesCreateParameters {Name = $"{DatabasePrefix}Volume"});
            }

            var containers = await dockerClient
                .Containers.ListContainersAsync(new ContainersListParameters {All = true});

            var testContainer = containers.FirstOrDefault(
                c => c.Names.Any(n => n.Contains($"{DatabasePrefix}Container")));

            if (testContainer != null)
            {
                return;
            }

            var postgresContainer = await dockerClient
                .Containers
                .CreateContainerAsync(
                    new CreateContainerParameters
                    {
                        Name = $"{DatabasePrefix}Container",
                        Image = "postgres:11-alpine",
                        Env = new List<string> {"POSTGRES_PASSWORD=docker"},
                        HostConfig = new HostConfig
                        {
                            PortBindings = new Dictionary<string, IList<PortBinding>>
                            {
                                {
                                    "5432/tcp",
                                    new PortBinding[]
                                    {
                                        new PortBinding
                                        {
                                            HostPort = "5432"
                                        }
                                    }
                                }
                            },
                        }
                    });

            await dockerClient
                .Containers
                .StartContainerAsync(postgresContainer.ID, new ContainerStartParameters());
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            await EnsureDockerContainer();

            var sqlServerConnectionString = _configuration.GetConnectionString("EdFi_Ods");

            if (string.IsNullOrWhiteSpace(sqlServerConnectionString))
            {
                throw new ApplicationException(
                    "Invalid configuration for integration tests.  Verify a valid sql server connection string for 'EdFi_Ods'");
            }

            var connectionStringBuilder = new DbConnectionStringBuilder {ConnectionString = sqlServerConnectionString};
            var sourceDatabaseName = connectionStringBuilder["Database"] as string;
            var testDatabaseName = $"{DatabasePrefix}{Guid.NewGuid():N}";

            var databaseHelper = new DatabaseHelper(_configuration);
            databaseHelper.CopyDatabase(sourceDatabaseName, testDatabaseName);

            connectionStringBuilder["Database"] = testDatabaseName;
            SqlServerConnectionString = connectionStringBuilder.ConnectionString;

            PostgreSqlConnectionString = _configuration.GetConnectionString("EdFi_Ods_Manual_PostgreSQL");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var databaseHelper = new DatabaseHelper(_configuration);
            databaseHelper.DropMatchingDatabases(DatabasePrefix + "%");
        }
    }
}

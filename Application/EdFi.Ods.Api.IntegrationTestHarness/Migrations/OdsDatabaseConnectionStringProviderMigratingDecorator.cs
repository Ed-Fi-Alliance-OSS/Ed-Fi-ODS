// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Data.Common;
using System.Reflection;
using EdFi.Common.Configuration;
using EdFi.Common.Database;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Database;
using log4net;

namespace EdFi.Ods.Api.IntegrationTestHarness.Migrations;

public class OdsDatabaseConnectionStringProviderMigratingDecorator : IOdsDatabaseConnectionStringProvider
{
    private readonly IDatabaseMigrationsApplicator _databaseMigrationsApplicator;

    private readonly ILog _logger = LogManager.GetLogger(typeof(OdsDatabaseConnectionStringProviderMigratingDecorator));
    private readonly ConcurrentDictionary<ulong, bool> _migratedConnections = new();
    private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;
    private readonly DbProviderFactory _dbProviderFactory;
    private readonly TestHarnessConfigurationProvider _testHarnessConfigurationProvider;

    public OdsDatabaseConnectionStringProviderMigratingDecorator(
        IDatabaseMigrationsApplicator databaseMigrationsApplicator,
        IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
        TestHarnessConfigurationProvider testHarnessConfigurationProvider,
        DbProviderFactory dbProviderFactory)
    {
        _databaseMigrationsApplicator = databaseMigrationsApplicator;
        _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
        _dbProviderFactory = dbProviderFactory;
        _testHarnessConfigurationProvider = testHarnessConfigurationProvider;
    }

    string IDatabaseConnectionStringProvider.GetConnectionString()
    {
        string connectionString = _odsDatabaseConnectionStringProvider.GetConnectionString();

        if (_migratedConnections.TryAdd(XxHash3Code.Combine(connectionString), true))
        {
            // Get the Standard version
            string standardVersionText;
            string standardVersion = null;

            // Introspect the standard version from the target ODS
            using (var conn = _dbProviderFactory.CreateConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select util.GetEdFiStandardVersion()";
                standardVersionText = cmd.ExecuteScalar()?.ToString();
            }

            if (!_testHarnessConfigurationProvider.GetTestHarnessConfiguration().ApplyOdsDatabaseMigrations)
            {
                return connectionString;
            }

            if (!string.IsNullOrWhiteSpace(standardVersionText))
            {
                string[] versionParts = standardVersionText.Split('.');
                string major = versionParts[0];
                string minor = versionParts[1];

                string revision = (versionParts.Length > 2)
                    ? versionParts[2]
                    : "0";

                standardVersion = $"{major}.{minor}.{revision}";
                _logger.Info($"Applying ODS migrations (Standard Version: {standardVersion})...");
            }
            else
            {
                _logger.Info("Applying ODS migrations (no Standard Version identified)...");
            }

            // Apply migrations
            _databaseMigrationsApplicator.ApplyMigrations(
                Assembly.GetExecutingAssembly(),
                connectionString,
                MigrationArtifactType.Structure,
                MigrationDatabaseType.Ods,
                standardVersion);
        }

        return connectionString;
    }

    public string GetReadReplicaConnectionString() => _odsDatabaseConnectionStringProvider.GetConnectionString();
}

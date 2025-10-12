// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using System.Threading.Tasks;
using EdFi.Ods.Api.Startup;

namespace EdFi.Ods.Api.IntegrationTestHarness.Migrations;

public class ApplySecurityDatabaseMigrationsStartupCommand : IStartupCommand
{
    private readonly IDatabaseMigrationsApplicator _databaseMigrationsApplicator;
    private readonly ISecurityDatabaseConnectionStringCatalog _securityConnectionStringCatalog;

    public ApplySecurityDatabaseMigrationsStartupCommand(
        IDatabaseMigrationsApplicator databaseMigrationsApplicator,
        ISecurityDatabaseConnectionStringCatalog securityConnectionStringCatalog)
    {
        _databaseMigrationsApplicator = databaseMigrationsApplicator;
        _securityConnectionStringCatalog = securityConnectionStringCatalog;
    }

    public Task ExecuteAsync()
    {
        foreach (var connectionString in _securityConnectionStringCatalog.GetConnectionStrings())
        {
            _databaseMigrationsApplicator.ApplyMigrations(
                Assembly.GetExecutingAssembly(),
                connectionString,
                MigrationArtifactType.Data,
                MigrationDatabaseType.Security);
        }

        return Task.CompletedTask;
    }
}

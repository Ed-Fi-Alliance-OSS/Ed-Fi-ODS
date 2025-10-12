// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Security.DataAccess.Providers;

namespace EdFi.Ods.Api.IntegrationTestHarness.Migrations;

public class SingleTenantSecurityDatabaseConnectionStringCatalog : ISecurityDatabaseConnectionStringCatalog
{
    private readonly ISecurityDatabaseConnectionStringProvider _securityConnectionStringProvider;

    public SingleTenantSecurityDatabaseConnectionStringCatalog(
        ISecurityDatabaseConnectionStringProvider securityConnectionStringProvider)
    {
        _securityConnectionStringProvider = securityConnectionStringProvider;
    }

    public string[] GetConnectionStrings() => [_securityConnectionStringProvider.GetConnectionString()];
}

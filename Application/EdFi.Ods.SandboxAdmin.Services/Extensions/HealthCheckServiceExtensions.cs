// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.Extensions.DependencyInjection;

namespace EdFi.Ods.Sandbox.Admin.Extensions
{
    public static class HealthCheckServiceExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, string connectionString, bool isSqlServer)
        {
            var hcBuilder = services.AddHealthChecks();
            if (isSqlServer)
            {
                hcBuilder.AddSqlServer(connectionString);
            }
            else
            {
                hcBuilder.AddNpgSql(connectionString);
            }

            return services;
        }
    }
}

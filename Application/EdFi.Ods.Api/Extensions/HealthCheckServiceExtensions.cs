// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdFi.Ods.Api.Extensions
{
    public static class HealthCheckServiceExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfigurationRoot configuration, ApiSettings apiSettings)
        {
            Dictionary<string, string> connectionStrings;

            if (apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.GetConfigKeyName()))
            {
                connectionStrings = configuration.Get<TenantsSection>().Tenants.ToDictionary(x => x.Key, x => x.Value.ConnectionStrings["EdFi_Admin"]);
            }
            else
            {
                connectionStrings = new() {
                    { "SingleTenant", configuration.GetConnectionString("EdFi_Admin") }
                };
            }

            var isSqlServer = "SQLServer".Equals(apiSettings.Engine, StringComparison.OrdinalIgnoreCase);
            var hcBuilder = services.AddHealthChecks();

            foreach (var connectionString in connectionStrings)
            {
                if (isSqlServer)
                {
                    hcBuilder.AddSqlServer(connectionString.Value, name: connectionString.Key);
                }
                else
                {
                    hcBuilder.AddNpgSql(connectionString.Value, name: connectionString.Key);
                }
            }

            return services;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Api.Extensions
{
    public static class HealthCheckServiceExtensions
    {
        public static IServiceCollection AddHealthCheck(
            this IServiceCollection services,
            IConfigurationRoot configuration,
            IFeatureManager featureManager,
            DatabaseEngine databaseEngine)
        {
            Dictionary<string, string> connectionStrings;

            if (featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
            {
                connectionStrings = configuration.Get<TenantsSection>()
                    .Tenants.ToDictionary(
                        x => x.Key, 
                        x => x.Value.ConnectionStrings["EdFi_Admin"]);
            }
            else
            {
                connectionStrings = new()
                {
                    { "SingleTenant", configuration.GetConnectionString("EdFi_Admin") }
                };
            }

            var hcBuilder = services.AddHealthChecks();

            foreach (var connectionString in connectionStrings)
            {
                if (databaseEngine == DatabaseEngine.SqlServer)
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

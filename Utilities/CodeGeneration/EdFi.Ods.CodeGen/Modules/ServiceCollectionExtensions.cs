// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdFi.Ods.CodeGen.Modules
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(
                    Directory.GetParent(AppContext.BaseDirectory)
                        .FullName)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return services.AddSingleton(configRoot.Build());
        }
    }
}

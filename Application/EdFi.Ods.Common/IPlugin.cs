// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EdFi.Ods.Common;

/// <summary>
/// Provides a custom assembly author a way of configuring the host before it is built, and then to configure
/// services direction with the <see cref="IServiceCollection" /> during ASP.NET configuration process.
/// </summary>
/// <seealso cref="IPluginModule"/>
public interface IPlugin
{
    /// <summary>
    /// Configures services during ASP.NET startup/configuration process.
    /// </summary>
    /// <param name="configuration">The configuration root of the ASP.NET application.</param>
    /// <param name="services">The service collection being configured.</param>
    /// <param name="apiSettings">The <see cref="ApiSettings" /> configuration object that has already been bound from the configuration.</param>
    void ConfigureServices(IConfigurationRoot configuration, IServiceCollection services, ApiSettings apiSettings);

    /// <summary>
    /// Configures the host prior to being finalized and built.
    /// </summary>
    /// <param name="hostBuilder">The <see cref="IHostBuilder" /> on which to perform configuration activities.</param>
    void ConfigureHost(IHostBuilder hostBuilder);
}

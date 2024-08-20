// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdFi.Ods.Common;

/// <summary>
/// Provides a custom assembly author a way to configure services registration with
/// the <see cref="IServiceCollection" /> during ASP.NET configuration process.
/// </summary>
/// <seealso cref="ICustomModule"/>
public interface IServicesConfigurationActivity
{
    /// <summary>
    /// Configures services during ASP.NET startup/configuration process.
    /// </summary>
    /// <param name="configuration">The configuration root of the ASP.NET application.</param>
    /// <param name="services">The service collection being configured.</param>
    /// <param name="apiSettings">The <see cref="ApiSettings" /> configuration object that has already been bound from the configuration.</param>
    void ConfigureServices(IConfigurationRoot configuration, IServiceCollection services, ApiSettings apiSettings);
}

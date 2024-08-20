// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.Extensions.Hosting;

namespace EdFi.Ods.Common;

/// <summary>
/// Provides a custom assembly author a way of configuring the host before it is built.
/// </summary>
public interface IHostConfigurationActivity
{
    /// <summary>
    /// Configures the host prior to being finalized and built.
    /// </summary>
    /// <param name="hostBuilder">The <see cref="IHostBuilder" /> on which to perform configuration activities.</param>
    void ConfigureHost(IHostBuilder hostBuilder);
}

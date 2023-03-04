// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.AspNetCore.Builder;

namespace EdFi.Ods.Api.Startup
{
    /// <summary>
    /// Defines a method for applying custom logic during the WebAPI configuration using the <see cref="IApplicationBuilder" />.
    /// </summary>
    public interface IApplicationConfigurationActivity
    {
        /// <summary>
        /// Applies additional configuration on the API during initialization.
        /// </summary>
        /// <param name="builder">The builder supplied by ASP.NET Core.</param>
        void Configure(IApplicationBuilder builder);
    }
}


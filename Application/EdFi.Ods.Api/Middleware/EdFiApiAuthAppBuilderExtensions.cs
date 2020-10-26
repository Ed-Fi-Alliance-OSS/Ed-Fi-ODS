// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;

namespace EdFi.Ods.Api.Middleware
{
    public static class EdFiApiAuthAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="EdFiApiAuthenticationMiddleware"/> to the specified <see cref="IApplicationBuilder"/>, which enables authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseEdFiApiAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            
            return app.UseMiddleware<EdFiApiAuthenticationMiddleware>();
        }
    }
}

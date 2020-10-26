// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Middleware;
using Microsoft.AspNetCore.Builder;

namespace EdFi.Ods.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseOpenApiMetadata(this IApplicationBuilder builder)
            => builder.UseMiddleware<OpenApiMetadataMiddleware>();

        /// <summary>
        /// Adds the <see cref="EdFiApiAuthenticationMiddleware"/> to the specified <see cref="IApplicationBuilder"/>, which enables authentication capabilities.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseEdFiApiAuthentication(this IApplicationBuilder builder)
            => builder.UseMiddleware<EdFiApiAuthenticationMiddleware>();
    }
}

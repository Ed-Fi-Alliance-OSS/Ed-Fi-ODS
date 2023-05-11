// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Builder;

namespace EdFi.Ods.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseOpenApiMetadata(this IApplicationBuilder builder)
            => builder.UseMiddleware<OpenApiMetadataMiddleware>();

        public static IApplicationBuilder UseOdsInstanceIdentification(this IApplicationBuilder builder)
            => builder.UseMiddleware<OdsInstanceIdentificationMiddleware>();

        public static IApplicationBuilder UseTenantIdentification(this IApplicationBuilder builder)
            => builder.UseMiddleware<TenantIdentificationMiddleware>();

        /// <summary>
        /// Adds the <see cref="EdFiApiAuthenticationMiddleware"/> to the specified <see cref="IApplicationBuilder"/>, which enables authentication capabilities.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseEdFiApiAuthentication(this IApplicationBuilder builder)
            => builder.UseMiddleware<EdFiApiAuthenticationMiddleware>();

        public static IApplicationBuilder UseXsdMetadata(this IApplicationBuilder builder)
            => builder.UseMiddleware<XsdMetadataFileMiddleware>();

        public static IApplicationBuilder UseRequestResponseDetailsLogger(this IApplicationBuilder builder)
            => builder.UseMiddleware<RequestResponseDetailsLoggerMiddleware>();
    }
}

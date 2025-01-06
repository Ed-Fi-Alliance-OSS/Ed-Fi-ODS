// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseOpenApiMetadata(this IApplicationBuilder builder)
            => builder.UseMiddlewareForFeature<OpenApiMetadataMiddleware>(ApiFeature.OpenApiMetadata.Value);

        public static IApplicationBuilder UseOdsInstanceIdentification(this IApplicationBuilder builder)
            => builder.UseMiddleware<OdsInstanceIdentificationMiddleware>();

        public static IApplicationBuilder UseTenantIdentification(this IApplicationBuilder builder)
            => builder.UseMiddlewareForFeature<TenantIdentificationMiddleware>(ApiFeature.MultiTenancy.Value);

        public static IApplicationBuilder UseRequestCorrelation(this IApplicationBuilder builder)
            => builder.UseMiddleware<RequestCorrelationMiddleware>();

        public static IApplicationBuilder UseProblemDetailsEnrichment(this IApplicationBuilder builder)
            => builder.UseMiddleware<ProblemDetailsErrorEnrichmentMiddleware>();

        /// <summary>
        /// Adds the <see cref="EdFiApiAuthenticationMiddleware"/> to the specified <see cref="IApplicationBuilder"/>, which enables authentication capabilities.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseEdFiApiAuthentication(this IApplicationBuilder builder)
            => builder.UseMiddleware<EdFiApiAuthenticationMiddleware>();
        
        public static IApplicationBuilder UseRequestResponseDetailsLogger(this IApplicationBuilder builder)
            => builder.UseMiddleware<RequestResponseDetailsLoggerMiddleware>();

        public static IApplicationBuilder UseOAuthContentTypeValidation(this IApplicationBuilder builder)
            => builder.UseMiddleware<OAuthContentTypeValidationMiddleware>();
    }
}

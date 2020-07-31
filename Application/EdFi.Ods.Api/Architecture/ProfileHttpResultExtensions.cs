// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web.Http;
using EdFi.Ods.Api.Services.CustomActionResults;

namespace EdFi.Ods.Api.Architecture
{
    public static class ProfileHttpResultExtensions
    {
        /// <summary>
        /// Replaces the content type header on the supplied <see cref="IHttpActionResult"/>
        /// with the supplied content type.
        /// </summary>
        public static IHttpActionResult WithContentType(
            this IHttpActionResult result,
            string contentType)
        {
            return result.With(
                x =>
                {
                    x.Content.Headers.Remove("Content-Type");
                    x.Content.Headers.Add("Content-Type", contentType);
                });
        }
    }
}

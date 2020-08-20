// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Net.Http;
using System.Web.Http;

namespace EdFi.Ods.Api.Services.CustomActionResults
{
    public static class HttpActionResultExtensions
    {
        public static IHttpActionResult With(this IHttpActionResult inner, Action<HttpResponseMessage> responseAction)
        {
            return new HttpActionResultWithAction(inner, responseAction);
        }

        public static IHttpActionResult WithError(this IHttpActionResult inner, string errorMessage)
        {
            return new HttpActionResultWithError(inner, errorMessage);
        }
    }
}

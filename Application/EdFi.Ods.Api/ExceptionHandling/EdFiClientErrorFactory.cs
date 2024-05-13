// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EdFi.Ods.Common.Exceptions
{
    public class EdFiClientErrorFactory : IClientErrorFactory
    {
        public IActionResult GetClientError(ActionContext actionContext, IClientErrorActionResult clientError)
        {
            // This prevents ASP.net from writing its Problem Details to the response stream and allows
            // our ProblemDetailsErrorEnrichmentMiddleware to answer with our custom Problem Details.
            return clientError;
        }
    }
}

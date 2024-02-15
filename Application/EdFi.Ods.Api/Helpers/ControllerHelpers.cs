// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net;
using EdFi.Ods.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Helpers
{
    public static class ControllerHelpers
    {
        /// <summary>
        /// Gets an IActionResult returning a 404 Not Found status with no response body.
        /// </summary>
        /// <returns></returns>
        public static IActionResult NotFound(string error)
        {
            var problemDetails = new NotFoundException(error);

            return new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status,
            };
        }
    }
}

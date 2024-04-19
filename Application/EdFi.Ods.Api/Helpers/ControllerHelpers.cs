// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Helpers
{
    public static class ControllerHelpers
    {
        /// <summary>
        /// Gets an IActionResult returning a 404 Not Found status with a default response body indicating the resource could not be found.
        /// </summary>
        /// <returns></returns>
        public static IActionResult NotFound(string correlationId = null)
        {
            var problemDetails = new NotFoundException("scenario60.")
            {
                CorrelationId = correlationId
            };

            return new ObjectResult(problemDetails.AsSerializableModel())
            {
                StatusCode = problemDetails.Status,
            };
        }

        public static IActionResult FeatureDisabled(string featureName, string correlationId = null)
        {
            return new ObjectResult(
                new FeatureDisabledException("scenario39.", StatusCodes.Status404NotFound)
                    {
                        CorrelationId = correlationId
                    }
                    .AsSerializableModel())
            {
                StatusCode = StatusCodes.Status404NotFound
            };
        }
    }
}

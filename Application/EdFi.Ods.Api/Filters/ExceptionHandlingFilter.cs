// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.ProblemDetails;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.Api.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        private readonly IEdFiProblemDetailsProvider _problemDetailsProvider;
        private readonly ILog _logger = LogManager.GetLogger(typeof(ExceptionHandlingFilter));

        public ExceptionHandlingFilter(IEdFiProblemDetailsProvider problemDetailsProvider)
        {
            _problemDetailsProvider = problemDetailsProvider;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.Error($"Unhandled exception caught by {nameof(ExceptionHandlingFilter)}: {context.Exception}");

            var problemDetails = _problemDetailsProvider.GetProblemDetails(context.Exception);

            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status,
            };
        }
    }
}

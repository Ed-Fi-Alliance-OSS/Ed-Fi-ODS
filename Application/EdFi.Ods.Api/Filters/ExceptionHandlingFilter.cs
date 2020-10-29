// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.ExceptionHandling;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.Api.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        private readonly IRESTErrorProvider _restErrorProvider;

        private readonly ILog _logger = LogManager.GetLogger(typeof(ExceptionHandlingFilter));
        
        public ExceptionHandlingFilter(IRESTErrorProvider restErrorProvider)
        {
            _restErrorProvider = restErrorProvider;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.Error($"Unhandled exception caught by {nameof(ExceptionHandlingFilter)}: {context.Exception}");

            var restError = _restErrorProvider.GetRestErrorFromException(context.Exception);

            context.Result = new ObjectResult(new { Message = restError.Message })
            {
                StatusCode = restError.Code,
            };
        }
    }
}

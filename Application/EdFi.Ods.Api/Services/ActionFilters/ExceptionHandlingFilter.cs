// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using log4net;

namespace EdFi.Ods.Api.Services.ActionFilters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ExceptionHandlingFilter));
        private readonly bool isCustomErrorEnabled;

        public ExceptionHandlingFilter(bool isCustomErrorEnabled)
        {
            this.isCustomErrorEnabled = isCustomErrorEnabled;
        }

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            //TODO: CLH - When using Owin you can configure response behavior by settting config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly which will do the same thing this is doing.  In which case this can just become an IExceptionLogger with one line to log the exception.
            if (!isCustomErrorEnabled) //Just log if custom error mode is not enabled meaning we want the thrown exception to display.
            {
                return Task.Run(() => _logger.Error(actionExecutedContext.Exception), cancellationToken);
            }

            //Otherwise display a generic error message with minimal information.
            return Task.Run(
                () =>
                {
                    _logger.Error(actionExecutedContext.Exception);

                    actionExecutedContext.Response =
                        actionExecutedContext.Request.CreateErrorResponse(
                            HttpStatusCode.InternalServerError,
                            new HttpError(actionExecutedContext.Exception, false));
                },
                cancellationToken);
        }

        public bool AllowMultiple
        {
            get { return true; }
        }
    }
}

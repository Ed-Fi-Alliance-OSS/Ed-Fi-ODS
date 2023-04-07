// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using log4net;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware
{
    public class RequestResponseDetailsLoggerMiddleware : IMiddleware
    {
        private readonly ReverseProxySettings _reverseProxySettings;
        private readonly IRESTErrorProvider _restErrorProvider;
        private ILog _requestResponseDetailsLogger;

        public RequestResponseDetailsLoggerMiddleware(ApiSettings apiSettings, IRESTErrorProvider restErrorProvider)
        {
            _reverseProxySettings = apiSettings.GetReverseProxySettings();
            _restErrorProvider = restErrorProvider;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

            switch (context.Response.StatusCode)
            {
                case StatusCodes.Status500InternalServerError:
                    if(context.Items["Exception"] is Exception exception) 
                        LogRequestResponseDetailsOnException(context, exception);
                    break;
                case StatusCodes.Status201Created:
                    LogRequestResponseDetailsInfo(context, (context.Items["createdResourceUri"] as string) ?? "Created resource URI missing");
                    break;
                default:
                    LogRequestResponseDetailsInfo(context);
                    break;
            }
        }

        private static string TryGetStatusCodeDescription(int statusCode)
        {
            var httpStatusCodeParsed = Enum.TryParse(statusCode.ToString(), out HttpStatusCode httpStatusCode);

            return httpStatusCodeParsed
                ? httpStatusCode.ToString()
                : "Unknown";
        }

        private void LogRequestResponseDetailsInfo(HttpContext context, string responseMessage = "Ok")
        {
            // Check the Appender exists to avoid duplicated log messages on both controller(root) and detailed loggers
            if (!RequestResponseDetailsFileAppenderExists())
                return;

            AddLoggerProperties(context.Request.Method, context.Response.StatusCode, context);

            RequestResponseDetailsLogger.Info(TryGetStatusCodeDescription(context.Response.StatusCode));
        }

        private void LogRequestResponseDetailsOnException(HttpContext context, Exception exception)
        {
            // Check the Appender exists to avoid duplicated log messages on both controller(root) and detailed loggers
            if (!RequestResponseDetailsFileAppenderExists())
                return;

            var restError = _restErrorProvider.GetRestErrorFromException(exception);

            AddLoggerProperties(context.Request.Method, restError.Code, context);

            RequestResponseDetailsLogger.Error(restError.Message);
        }

        protected ILog RequestResponseDetailsLogger
        {
            get => _requestResponseDetailsLogger ??= LogManager.GetLogger("RequestResponseDetailsLogger");
        }

        private void AddLoggerProperties(string requestMethod, int responseCode, HttpContext context)
        {
            LogicalThreadContext.Properties["RequestUrl"] = context.Request.ResourceUri(_reverseProxySettings);
            LogicalThreadContext.Properties["RequestMethod"] = requestMethod;
            LogicalThreadContext.Properties["ResponseCode"] = responseCode;
        }

        private bool RequestResponseDetailsFileAppenderExists() => 
            RequestResponseDetailsLogger.Logger.Repository.GetAppenders().Any(x => x.Name == "RequestResponseDetailsFileAppender");

    }
}

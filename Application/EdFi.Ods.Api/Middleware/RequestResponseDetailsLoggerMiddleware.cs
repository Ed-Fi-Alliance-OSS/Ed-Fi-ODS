// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.ProblemDetails;
using log4net;
using log4net.Appender;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware
{
    public class RequestResponseDetailsLoggerMiddleware : IMiddleware
    {
        private readonly ReverseProxySettings _reverseProxySettings;
        private readonly IEdFiProblemDetailsProvider _problemDetailsProvider;
        private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;
        private readonly DateTime _logRequestResponseContentUntil;
        private bool _logRequestResponseContent;
        private ILog _requestResponseDetailsLogger;
        private ILog _requestResponseContentLogger;

        public RequestResponseDetailsLoggerMiddleware(
            ReverseProxySettings reverseProxySettings,
            int logRequestResponseContentForMinutes,
            IEdFiProblemDetailsProvider problemDetailsProvider,
            IOdsDatabaseConnectionStringProvider connectionStringProvider)
        {
            _reverseProxySettings = reverseProxySettings;
            _problemDetailsProvider = problemDetailsProvider;
            _connectionStringProvider = connectionStringProvider;
            _logRequestResponseContent = logRequestResponseContentForMinutes > 0 && RequestResponseContentDatabaseAppenderConfigured();

            if (_logRequestResponseContent)
                _logRequestResponseContentUntil = DateTime.UtcNow.AddMinutes(logRequestResponseContentForMinutes);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (_logRequestResponseContent && DateTime.UtcNow > _logRequestResponseContentUntil)
            {
                _logRequestResponseContent = false;
            }

            if (_logRequestResponseContent)
            {
                SetDatabaseAppenderConnectionString();

                context.Request.EnableBuffering();
                string requestBodyContent = await GetRequestBodyContent();

                var originalResponseBodyStream = context.Response.Body;
                context.Response.Body = new MemoryStream();

                await next(context);

                string responseBodyContent = await GetResponseBodyContent(originalResponseBodyStream);

                AddLoggerDetailProperties(context.Request.Method, context.Response.StatusCode, context);
                AddLoggerContentProperties(requestBodyContent, responseBodyContent, context);

                switch (context.Response.StatusCode)
                {
                    case StatusCodes.Status500InternalServerError:
                        if (context.Items["Exception"] is Exception exception)
                            LogRequestResponseContentOnException(exception);
                        break;
                    case >= StatusCodes.Status400BadRequest:
                        LogRequestResponseContentInfo(context);
                        break;
                    default:
                        LogRequestResponseContentDebug(context);
                        break;
                }
            }
            else
            {
                await next(context);
                AddLoggerDetailProperties(context.Request.Method, context.Response.StatusCode, context);
            }

            switch (context.Response.StatusCode)
            {
                case StatusCodes.Status500InternalServerError:
                    if (context.Items["Exception"] is Exception exception)
                        LogRequestResponseDetailsOnException(exception);
                    break;
                case >= StatusCodes.Status400BadRequest:
                    LogRequestResponseDetailsInfo(context);
                    break;
                default:
                    LogRequestResponseDetailsDebug(context);
                    break;
            }

            void SetDatabaseAppenderConnectionString()
            {
                var requestResponseAppenders = ((log4net.Repository.Hierarchy.Logger)LogManager.GetAllRepositories().FirstOrDefault()?.GetLogger("RequestResponseContentLogger"))?.Appenders;

                if (requestResponseAppenders?.Count != 1 || requestResponseAppenders.OfType<AdoNetAppender>().Count() != 1)
                    return;

                var adoNetAppender = (AdoNetAppender)requestResponseAppenders[0];
                adoNetAppender.ConnectionString = _connectionStringProvider.GetConnectionString();
                adoNetAppender.ActivateOptions();
            }

            async Task<string> GetRequestBodyContent()
            {
                context.Request.Body.Position = 0;
                var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;

                return requestBody;
            }

            async Task<string> GetResponseBodyContent(Stream originalBodyStream)
            {
                context.Response.Body.Position = 0;
                var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Position = 0;

                await context.Response.Body.CopyToAsync(originalBodyStream);
                context.Response.Body = originalBodyStream;

                return responseBody;
            }
        }

        private static string TryGetStatusCodeDescription(int statusCode)
        {
            var httpStatusCodeParsed = Enum.TryParse(statusCode.ToString(), out HttpStatusCode httpStatusCode);

            return httpStatusCodeParsed
                ? httpStatusCode.ToString()
                : "Unknown";
        }

        private void LogRequestResponseContentInfo(HttpContext context)
        {
            if (!RequestResponseContentDatabaseAppenderConfigured())
                return;

            RequestResponseContentLogger.Info(TryGetStatusCodeDescription(context.Response.StatusCode));
        }

        private void LogRequestResponseContentDebug(HttpContext context)
        {
            if (!RequestResponseContentDatabaseAppenderConfigured() ||
                !RequestResponseContentLogger.IsDebugEnabled)
                return;

            RequestResponseContentLogger.Debug(TryGetStatusCodeDescription(context.Response.StatusCode));
        }

        private void LogRequestResponseContentOnException(Exception exception)
        {
            if (!RequestResponseContentDatabaseAppenderConfigured())
                return;

            var problemDetails = _problemDetailsProvider.GetProblemDetails(exception);

            RequestResponseContentLogger.Error(problemDetails, exception);
        }

        private void LogRequestResponseDetailsInfo(HttpContext context)
        {
            // Check the Appender exists to avoid duplicated log messages on both controller(root) and detailed loggers
            if (!RequestResponseDetailsFileAppenderExists())
                return;

            RequestResponseDetailsLogger.Info(TryGetStatusCodeDescription(context.Response.StatusCode));
        }

        private void LogRequestResponseDetailsDebug(HttpContext context)
        {
            // Check the Appender exists to avoid duplicated log messages on both controller(root) and detailed loggers
            if (!RequestResponseDetailsFileAppenderExists() ||
                !RequestResponseDetailsLogger.IsDebugEnabled)
                return;

            RequestResponseDetailsLogger.Debug(TryGetStatusCodeDescription(context.Response.StatusCode));
        }

        private void LogRequestResponseDetailsOnException(Exception exception)
        {
            // Check the Appender exists to avoid duplicated log messages on both controller(root) and detailed loggers
            if (!RequestResponseDetailsFileAppenderExists())
                return;

            var problemDetails = _problemDetailsProvider.GetProblemDetails(exception);
            string logMessage = string.Concat("Detail: ", problemDetails.Detail, ", Errors: ", string.Join(' ', problemDetails.Errors ?? Array.Empty<string>()));

            RequestResponseDetailsLogger.Error(logMessage, exception);
        }

        protected ILog RequestResponseDetailsLogger
        {
            get => _requestResponseDetailsLogger ??= LogManager.GetLogger("RequestResponseDetailsLogger");
        }

        protected ILog RequestResponseContentLogger
        {
            get => _requestResponseContentLogger ??= LogManager.GetLogger("RequestResponseContentLogger");
        }

        private void AddLoggerDetailProperties(string requestMethod, int responseCode, HttpContext context)
        {
            LogicalThreadContext.Properties["RequestUrl"] = context.Request.ResourceUri(_reverseProxySettings);
            LogicalThreadContext.Properties["RequestMethod"] = requestMethod;
            LogicalThreadContext.Properties["ResponseCode"] = responseCode;
        }

        private void AddLoggerContentProperties(string requestBodyContent, string responseBodyContent, HttpContext context)
        {
            LogicalThreadContext.Properties["RequestUrlWithQueryString"] = $"{context.Request.ResourceUri(_reverseProxySettings)}{context.Request.QueryString}";
            LogicalThreadContext.Properties["RequestBody"] = requestBodyContent;
            LogicalThreadContext.Properties["ResponseBody"] = responseBodyContent;
        }

        private static bool RequestResponseDetailsFileAppenderExists()
        {
            var appenders = ((log4net.Repository.Hierarchy.Logger)LogManager.GetAllRepositories().FirstOrDefault()?.GetLogger("RequestResponseDetailsLogger"))?.Appenders;

            return (appenders?.OfType<FileAppender>() ?? Array.Empty<FileAppender>()).Any();
        }

        private static bool RequestResponseContentDatabaseAppenderConfigured()
        {
            var appenders = ((log4net.Repository.Hierarchy.Logger)LogManager.GetAllRepositories().FirstOrDefault()?.GetLogger("RequestResponseContentLogger"))?.Appenders;

            return appenders?.Count == 1 && appenders.OfType<AdoNetAppender>().Count() == 1;
        }
    }
}

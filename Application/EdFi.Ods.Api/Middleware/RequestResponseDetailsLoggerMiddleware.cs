// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using log4net;
using log4net.Appender;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware
{
    public class RequestResponseDetailsLoggerMiddleware : IMiddleware
    {
        private readonly ReverseProxySettings _reverseProxySettings;
        private readonly IRESTErrorProvider _restErrorProvider;
        private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;
        private readonly DateTime _logRequestResponseContentUntil;
        private bool _logRequestResponseContent;
        private ILog _requestResponseDetailsLogger;
        private ILog _requestResponseContentLogger;

        public RequestResponseDetailsLoggerMiddleware(ReverseProxySettings reverseProxySettings, int logRequestResponseContentForSeconds,IRESTErrorProvider restErrorProvider, IOdsDatabaseConnectionStringProvider connectionStringProvider)
        {
            _reverseProxySettings = reverseProxySettings;
            _restErrorProvider = restErrorProvider;
            _connectionStringProvider = connectionStringProvider;
            _logRequestResponseContent = logRequestResponseContentForSeconds > 0 && RequestResponseContentDatabaseAppenderExists();

            if(_logRequestResponseContent)
                _logRequestResponseContentUntil = DateTime.UtcNow.AddSeconds(logRequestResponseContentForSeconds);
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
                    default:
                        LogRequestResponseContentInfo(context);
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
                    if(context.Items["Exception"] is Exception exception) 
                        LogRequestResponseDetailsOnException(exception);
                    break;
                default:
                    LogRequestResponseDetailsInfo(context);
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
            RequestResponseContentLogger.Info(TryGetStatusCodeDescription(context.Response.StatusCode));
        }

        private void LogRequestResponseContentOnException(Exception exception)
        {
            var restError = _restErrorProvider.GetRestErrorFromException(exception);

            RequestResponseContentLogger.Error(restError.Message, exception);
        }

        private void LogRequestResponseDetailsInfo(HttpContext context)
        {
            // Check the Appender exists to avoid duplicated log messages on both controller(root) and detailed loggers
            if (!RequestResponseDetailsFileAppenderExists())
                return;

            RequestResponseDetailsLogger.Info(TryGetStatusCodeDescription(context.Response.StatusCode));
        }

        private void LogRequestResponseDetailsOnException(Exception exception)
        {
            // Check the Appender exists to avoid duplicated log messages on both controller(root) and detailed loggers
            if (!RequestResponseDetailsFileAppenderExists())
                return;

            var restError = _restErrorProvider.GetRestErrorFromException(exception);

            RequestResponseDetailsLogger.Error(restError.Message, exception);
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

        private bool RequestResponseDetailsFileAppenderExists() => 
            RequestResponseDetailsLogger.Logger.Repository.GetAppenders().Any(x => x.Name == "RequestResponseDetailsFileAppender");

        private bool RequestResponseContentDatabaseAppenderExists() =>
            RequestResponseContentLogger.Logger.Repository.GetAppenders().Any(x => x.Name == "RequestResponseContentAppender");
    }
}

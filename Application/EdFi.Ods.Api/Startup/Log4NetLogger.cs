// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using log4net;
using Microsoft.Owin.Logging;

namespace EdFi.Ods.Api.Startup
{
    public class Log4NetLoggerFactory : ILoggerFactory
    {
        public ILogger Create(string name)
        {
            var log = LogManager.GetLogger(name);
            return new Log4NetLogger(log);
        }
    }

    internal class Log4NetLogger : ILogger
    {
        private readonly ILog _log;

        public Log4NetLogger(ILog log)
        {
            _log = log;
        }

        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            switch (eventType)
            {
                case TraceEventType.Critical:
                    _log.Fatal(state, exception);
                    break;
                case TraceEventType.Error:
                    _log.Error(state, exception);
                    break;
                case TraceEventType.Warning:
                    _log.Warn(state, exception);
                    break;
                case TraceEventType.Information:
                    _log.Info(state, exception);
                    break;
                default:
                    _log.Debug(state, exception);
                    break;
            }

            return true;
        }
    }
}

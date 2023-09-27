// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Net;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Logging;

namespace EdFi.Ods.Api.ExceptionHandling
{
    public interface IRESTErrorProvider
    {
        RESTError GetRestErrorFromException(Exception exception);
    }

    public class RESTErrorProvider : IRESTErrorProvider
    {
        private readonly ILogContextAccessor _logContextAccessor;
        private readonly IEnumerable<IExceptionTranslator> _translators;

        public RESTErrorProvider(IEnumerable<IExceptionTranslator> translators, ILogContextAccessor logContextAccessor)
        {
            _translators = translators;
            _logContextAccessor = logContextAccessor;
        }

        public RESTError GetRestErrorFromException(Exception exception)
        {
            // Try to translate the exception explicitly
            foreach (var translator in _translators)
            {
                RESTError error;

                if (translator.TryTranslateMessage(exception, out error))
                {
                    // Assign the correlation error (if it exists)
                    error.CorrelationId = (string)_logContextAccessor.GetValue("CorrelationId");

                    return error;
                }
            }

            // Default exception message is to just return all the messages in the exception stack as an Internal Server Error
            var response = new RESTError
            {
                // This class translates into a serialized output that matches inBloom's approach to error handling.
                Code = (int)HttpStatusCode.InternalServerError,
                Type = "Internal Server Error",
                Message = "An unexpected error occurred on the server.",
                CorrelationId = (string)_logContextAccessor.GetValue("CorrelationId")
            };

            return response;
        }
    }
}

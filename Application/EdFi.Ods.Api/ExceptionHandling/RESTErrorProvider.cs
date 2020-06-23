// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Net;

namespace EdFi.Ods.Api.ExceptionHandling
{
    // TODO: Modify code generation and remove all usages of this interface.
    // Replaced by IExceptionTranslationProvider. Interface can be removed once code generated artifacts no longer take a dependency.
    public interface IRESTErrorProvider
    {
        RESTError GetRestErrorFromException(Exception exception);
    }
    
    // Replaced by IExceptionTranslationProvider. Interface can be removed once code generated artifacts no longer take a dependency.
    public class RESTErrorProvider : IRESTErrorProvider
    {
        private readonly IEnumerable<IExceptionTranslator> _translators;

        public RESTErrorProvider(IEnumerable<IExceptionTranslator> translators)
        {
            _translators = translators;
        }

        public RESTError GetRestErrorFromException(Exception exception)
        {
            // Try to translate the exception explicitly
            foreach (var translator in _translators)
            {
                ExceptionTranslationResult error;

                if (translator.TryTranslateMessage(exception, out error))
                {
                    return error.Error;
                }
            }

            // Default exception message is to just return all the messages in the exception stack as an Internal Server Error
            var response = new RESTError
                           {
                               // This class translates into a serialized output that matches inBloom's approach to error handling.
                               Code = (int) HttpStatusCode.InternalServerError, Type = "Internal Server Error",
                               Message = "An unexpected error occurred on the server."
                           };

            return response;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;

namespace EdFi.Ods.Api.ExceptionHandling
{
    public class ExceptionTranslationProvider : IExceptionTranslationProvider
    {
        private readonly IExceptionTranslator[] _translators;

        public ExceptionTranslationProvider(IExceptionTranslator[] translators)
        {
            _translators = translators;
        }
        
        public ExceptionTranslationResult TranslateException(Exception exception)
        {
            // Try to translate the exception explicitly
            foreach (var translator in _translators)
            {
                if (translator.TryTranslateMessage(exception, out ExceptionTranslationResult result))
                {
                    return result;
                }
            }
            
            // Default exception message is to just return all the messages in the exception stack as an Internal Server Error
            var error = new RESTError
            {
                // This class translates into a serialized output that matches inBloom's approach to error handling.
                Code = (int) HttpStatusCode.InternalServerError, Type = "Internal Server Error",
                Message = "An unexpected error occurred on the server."
            };
            
            return new ExceptionTranslationResult(error, exception);
        }
    }
}

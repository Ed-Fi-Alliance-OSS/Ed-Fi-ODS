// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.ExceptionHandling
{
    /// <summary>
    /// Defines a method for translating internal Exceptions to public-facing error messages.
    /// </summary>
    public interface IExceptionTranslator
    {
        /// <summary>
        /// Attempts to translate the specified <see cref="Exception"/> to an error message that hides 
        /// internal details of the service implementation and is palatable for consumers of the API.
        /// </summary>
        /// <param name="ex">The <see cref="Exception"/> to be translated.</param>
        /// <param name="translationResult">The details of the translation, including the API's error response model.</param>
        /// <returns><b>true</b> if the exception was handled; otherwise <b>false</b>.</returns>
        bool TryTranslateMessage(Exception ex, out ExceptionTranslationResult translationResult);

        // TODO: Remove
        // bool TryTranslateMessage(Exception ex, out RESTError webServiceError);

    }
    
    public class ExceptionTranslationResult
    {
        public ExceptionTranslationResult(RESTError error, Exception originalException)
        {
            Error = error;
            OriginalException = originalException;
        }

        public RESTError Error { get; }

        public Exception OriginalException { get; }
    }
}

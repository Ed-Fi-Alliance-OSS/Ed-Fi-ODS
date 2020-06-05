// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Api.Common.ExceptionHandling.Translators
{
    public class ProfileContentTypeExceptionTranslator : IExceptionTranslator
    {
        /// <summary>
        /// Attempts to translate the specified <see cref="System.Exception"/> to an error message that hides 
        /// internal details of the service implementation and is palatable for consumers of the API.
        /// </summary>
        /// <param name="ex">The <see cref="System.Exception"/> to be translated.</param>
        /// <param name="webServiceError">The web service error response model.</param>
        /// <returns><b>true</b> if the exception was handled; otherwise <b>false</b>.</returns>
        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            webServiceError = null;

            if (ex is ProfileContentTypeException)
            {
                webServiceError = new RESTError
                                  {
                                      Code = (int) HttpStatusCode.MethodNotAllowed, Type = HttpStatusCode.MethodNotAllowed.ToString(),
                                      Message = ex.Message
                                  };

                return true;
            }

            return false;
        }
    }
}

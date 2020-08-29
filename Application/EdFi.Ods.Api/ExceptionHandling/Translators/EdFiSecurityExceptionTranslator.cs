// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class EdFiSecurityExceptionTranslator : IExceptionTranslator
    {
        public bool TryTranslateMessage(Exception ex, out ExceptionTranslationResult translationResult)
        {
            translationResult = null;

            if (ex is EdFiSecurityException)
            {
                var error = new RESTError
                {
                    Code = (int) HttpStatusCode.Forbidden,
                    Type = "Forbidden",
                    Message = ex.GetAllMessages()
                };

                translationResult = new ExceptionTranslationResult(error, ex);
                
                return true;
            }

            return false;
        }
    }
}

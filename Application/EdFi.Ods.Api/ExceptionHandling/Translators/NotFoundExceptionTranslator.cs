// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Api.Exceptions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class NotFoundExceptionTranslator : IExceptionTranslator
    {
        public bool TryTranslateMessage(Exception ex, out ExceptionTranslationResult translationResult)
        {
            translationResult = null;

            if (ex is NotFoundException)
            {
                var error = new RESTError
                {
                    Code = (int) HttpStatusCode.NotFound,
                    Type = "Not Found",
                    Message = ex.GetAllMessages() ?? "The specified resource could not be found."
                };

                translationResult = new ExceptionTranslationResult(error, ex);

                return true;
            }

            return false;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using EdFi.Ods.Api.Exceptions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class NotModifiedExceptionTranslator : IExceptionTranslator
    {
        public bool TryTranslateMessage(Exception ex, out ExceptionTranslationResult translationResult)
        {
            translationResult = null;

            if (ex is NotModifiedException)
            {
                var error = new RESTError
                {
                    Code = (int) HttpStatusCode.NotModified,
                    Type = "Not Modified"
                };

                translationResult = new ExceptionTranslationResult(error, ex);

                return true;
            }

            return false;
        }
    }
}

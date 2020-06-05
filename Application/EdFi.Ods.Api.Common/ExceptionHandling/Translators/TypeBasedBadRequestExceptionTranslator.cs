// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Api.Common.ExceptionHandling.Translators
{
    public class TypeBasedBadRequestExceptionTranslator : IExceptionTranslator
    {
        private readonly Type[] _badRequestExceptionTypes =
        {
            typeof(BadRequestException),
            typeof(ValidationException),
            typeof(FormatException)
        };

        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            webServiceError = null;

            if (!_badRequestExceptionTypes.Contains(ex.GetType()))
            {
                return false;
            }

            webServiceError = new RESTError
            {
                Code = (int) HttpStatusCode.BadRequest,
                Type = "Bad Request",
                Message = ex.GetAllMessages()
            };

            return true;
        }
    }
}

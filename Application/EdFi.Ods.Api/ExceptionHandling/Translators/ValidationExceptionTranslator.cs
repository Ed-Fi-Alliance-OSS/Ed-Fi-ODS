// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Common.Exceptions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class ValidationExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            if (ex is ValidationException validationException)
            {
                var validationResult = validationException.ValidationResult;

                problemDetails = new BadRequestDataException("Data validation failed.", new[] { validationResult.ErrorMessage });
                return true;
            }

            problemDetails = null;
            return false;
        }
    }
}

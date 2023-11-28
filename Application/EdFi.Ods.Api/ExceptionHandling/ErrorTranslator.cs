// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Models.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EdFi.Ods.Api.ExceptionHandling
{
    public class ErrorTranslator
    {
        private readonly ModelStateKeyConverter _modelStateKeyConverter;

        public ErrorTranslator(ModelStateKeyConverter modelStateKeyConverter)
        {
            _modelStateKeyConverter = modelStateKeyConverter;
        }

        // Attempts to translate the API error response to ASP.NET MVC error response format to maintain compatibility for the consumers. 
        public EdFiProblemDetails GetErrorMessage(Resource resource, ModelStateDictionary modelState, string correlationId)
        {
            if (modelState.Keys.All(string.IsNullOrEmpty) && modelState.Values.Any())
            {
                return new EdFiProblemDetails()
                {
                    Type = "urn:ed-fi:general:bad-request",
                    Title = "Bad Request",
                    Detail = "The request could not be processed. See 'errors' for details.",
                    Errors = modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToArray(),
                    Status = StatusCodes.Status400BadRequest,
                    Instance = $"urn:correlation:{correlationId}",
                    CorrelationId = correlationId
                };
            }

            var validationErrors = modelState
                .Where(e => e.Value.ValidationState == ModelValidationState.Invalid)
                .ToDictionary(
                    kvp => _modelStateKeyConverter.GetJsonPath(resource, kvp.Key),
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new EdFiProblemDetails()
            {
                Type = "urn:ed-fi:validation:validation-failed",
                Title = "Validation Failed",
                Detail = "The request failed some validation rules. See 'validationErrors' for details.",
                Status = StatusCodes.Status400BadRequest,
                ValidationErrors = validationErrors,
                Instance = $"urn:correlation:{correlationId}",
                CorrelationId = correlationId
            };
        }

        public static RESTError GetErrorMessage(string message, string correlationId)
        {
            return new RESTError()
            {
                Message = message,
                CorrelationId = correlationId
            };
        }

        public EdFiProblemDetails GetErrorMessage(Resource resource, IEnumerable<ValidationResult> validationResults, string correlationId)
        {
            ModelStateDictionary modelState = new();

            foreach (ValidationResult validationResult in validationResults)
            {
                modelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? string.Empty, validationResult.ErrorMessage);
            }

            var validationErrors = modelState
                .Where(e => e.Value.ValidationState == ModelValidationState.Invalid)
                .ToDictionary(
                    kvp => _modelStateKeyConverter.GetJsonPath(resource, kvp.Key),
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new EdFiProblemDetails()
            {
                Type = "urn:ed-fi:validation:validation-failed",
                Title = "Validation Failed",
                Detail = "The request failed some validation rules. See 'validationErrors' for details.",
                Status = StatusCodes.Status400BadRequest,
                ValidationErrors = validationErrors,
                Instance = $"urn:correlation:{correlationId}",
                CorrelationId = correlationId
            };
        }
    }
}

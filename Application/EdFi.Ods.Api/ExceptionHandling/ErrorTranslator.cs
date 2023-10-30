// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Models.Resource;
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
        public RESTError GetErrorMessage(Resource resource, ModelStateDictionary modelState, string correlationId)
        {
            if (modelState.Keys.All(string.IsNullOrEmpty) && modelState.Values.Any())
            {
                return new RESTError()
                {
                    Message = string.Join(",", modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))),
                    CorrelationId = correlationId
                };
            }

            var validationErrors = modelState
                .Where(e => e.Value.ValidationState == ModelValidationState.Invalid)
                .ToDictionary(
                    kvp => _modelStateKeyConverter.GetJsonPath(resource, kvp.Key),
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new RESTError()
            {
                Message = "The request is invalid.",
                ValidationErrors = validationErrors,
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
    }
}

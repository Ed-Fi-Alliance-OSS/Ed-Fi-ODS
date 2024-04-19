// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Resource;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EdFi.Ods.Api.ExceptionHandling
{
    public class ErrorTranslator
    {
        private readonly ModelStateKeyConverter _modelStateKeyConverter;

        private const string DetailForValidationErrors = "Data validation failed. See 'validationErrors' for details.";
        private const string DetailForErrors = "The request could not be processed. See 'errors' for details.";

        public ErrorTranslator(ModelStateKeyConverter modelStateKeyConverter)
        {
            _modelStateKeyConverter = modelStateKeyConverter;
        }

        // Attempts to translate the API error response to ASP.NET MVC error response format to maintain compatibility for the consumers. 
        public IEdFiProblemDetails GetProblemDetails(Resource resource, ModelStateDictionary modelState)
        {
            // Process model binding failures
            if (modelState.Keys.All(string.IsNullOrEmpty) && modelState.Values.Any())
            {
                string[] errors = modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToArray();

                return new BadRequestException("scenario10.", errors).AsSerializableModel();
            }

            // Process data validation errors
            var validationErrors = modelState
                .Where(e => e.Value.ValidationState == ModelValidationState.Invalid)
                .ToDictionary(
                    kvp => _modelStateKeyConverter.GetJsonPath(resource, kvp.Key),
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new BadRequestDataException("scenario2.", validationErrors).AsSerializableModel();
        }

        public IEdFiProblemDetails GetProblemDetails(Resource resource, IEnumerable<ValidationResult> validationResults)
        {
            ModelStateDictionary modelState = new();

            // Process validation results into a model state dictionary (replicating what ASP.NET would do during model binding if we hadn't taken over that process)
            foreach (ValidationResult validationResult in validationResults)
            {
                foreach (string memberName in validationResult.MemberNames)
                {
                    modelState.AddModelError(memberName, validationResult.ErrorMessage);
                }
            }

            // Prepare the model state with appropriate JSON Paths
            var validationErrors = modelState
                .Where(e => e.Value.ValidationState == ModelValidationState.Invalid)
                .ToDictionary(
                    kvp => _modelStateKeyConverter.GetJsonPath(resource, kvp.Key),
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new BadRequestDataException("scenario3.", validationErrors).AsSerializableModel();
        }
    }
}

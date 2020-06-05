// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Api.Common.Attributes
{
    public class ValidateObjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // If no object present, do not fail validation (Required attribute should be present if the reference is required)
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var compositeResults = new CompositeValidationResult($"Validation of '{validationContext.DisplayName}' failed.");

            var itemResults = new List<ValidationResult>();
            var context = new ValidationContext(value, null, null);

            Validator.TryValidateObject(value, context, itemResults, true);

            if (itemResults.Any())
            {
                foreach (var itemResult in itemResults)
                {
                    compositeResults.AddResult(
                        itemResult is CompositeValidationResult
                            ? itemResult
                            : new ValidationResult($"{context.DisplayName}: {itemResult}"));
                }
            }

            return compositeResults.Results.Any()
                ? compositeResults
                : ValidationResult.Success;
        }
    }
}

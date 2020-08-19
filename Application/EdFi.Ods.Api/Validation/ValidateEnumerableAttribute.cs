// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Api.Validation
{
    public class ValidateEnumerableAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var enumerable = value as IEnumerable;
            var compositeResults = new CompositeValidationResult(string.Format("Validation of '{0}' failed.", validationContext.DisplayName));

            if (enumerable == null)
            {
                return ValidationResult.Success;
            }

            var i = 0;

            foreach (var item in enumerable)
            {
                var itemResults = new List<ValidationResult>();
                var context = new ValidationContext(item, validationContext.ServiceContainer, null);

                Validator.TryValidateObject(item, context, itemResults, true);

                if (itemResults.Any())
                {
                    foreach (var itemResult in itemResults)
                    {
                        if (itemResult is CompositeValidationResult)
                        {
                            compositeResults.AddResult(itemResult);
                        }
                        else
                        {
                            compositeResults.AddResult(new ValidationResult(string.Format("{0}[{1}]: {2}", context.DisplayName, i, itemResult)));
                        }
                    }
                }

                i++;
            }

            if (compositeResults.Results.Any())
            {
                return compositeResults;
            }

            // If we're still here, validation was successful
            return ValidationResult.Success;
        }
    }
}

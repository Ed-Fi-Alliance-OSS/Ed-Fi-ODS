// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Api.Common.Attributes
{
    /// <summary>
    /// Validates an Ed-Fi entity Extensions dictionary.
    /// </summary>
    public class ValidateExtensionsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dictionary = value as IDictionary;

            if (dictionary == null)
            {
                return ValidationResult.Success;
            }

            var compositeResults = new CompositeValidationResult($"Validation of '{validationContext.DisplayName}' failed.");

            foreach (DictionaryEntry entry in dictionary)
            {
                var @object = (entry.Value as IList)?[0];

                if (@object == null)
                {
                    throw new Exception($"Unable to unwrap the extension object.");
                }

                var itemResults = new List<ValidationResult>();
                var context = new ValidationContext(@object, null);

                Validator.TryValidateObject(@object, context, itemResults, validateAllProperties: true);

                if (!itemResults.Any())
                {
                    continue;
                }

                foreach (var itemResult in itemResults)
                {
                    if (itemResult is CompositeValidationResult)
                    {
                        compositeResults.AddResult(itemResult);
                    }
                    else
                    {
                        var extensionBagNameParts = SystemConventions.GetExtensionBagNameParts((string) entry.Key);

                        compositeResults.AddResult(
                            new ValidationResult(
                                $"{context.DisplayName} ({extensionBagNameParts.SchemaProperCaseName}): {itemResult}"));
                    }
                }
            }

            return compositeResults.Results.Any()
                ? compositeResults
                : ValidationResult.Success;
        }
    }
}

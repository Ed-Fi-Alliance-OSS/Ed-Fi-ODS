// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Api.NetCore.Attributes
{
    /// <summary>
    /// Validates an Ed-Fi AggregateExtensions dictionary.
    /// </summary>
    public class ValidateAggregateExtensionsAttribute : ValidationAttribute
    {
        private readonly ValidateEnumerableAttribute _validateEnumerable = new ValidateEnumerableAttribute();

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
                var enumerable = entry.Value as IList;

                if (enumerable == null)
                {
                    throw new Exception($"Unable to unwrap the extension object.");
                }

                var context = new ValidationContext(enumerable, null)
                {
                    DisplayName = GetAggregateExtensionDisplayName((string) entry.Key)
                };

                var enumerableValidationResult = _validateEnumerable.GetValidationResult(enumerable, context);

                if (enumerableValidationResult == ValidationResult.Success)
                {
                    continue;
                }

                if (enumerableValidationResult is CompositeValidationResult)
                {
                    compositeResults.AddResult(enumerableValidationResult);
                }
                else
                {
                    compositeResults.AddResult(
                        new ValidationResult($"{context.DisplayName} ({entry.Key}): {enumerableValidationResult}"));
                }
            }

            if (compositeResults.Results.Any())
            {
                return compositeResults;
            }

            // If we're still here, validation was successful
            return ValidationResult.Success;
        }

        private static string GetAggregateExtensionDisplayName(string extensionBagName)
        {
            var bagNameParts = SystemConventions.GetExtensionBagNameParts(extensionBagName);

            return $"{bagNameParts.PluralName} ({bagNameParts.SchemaProperCaseName})";
        }
    }
}

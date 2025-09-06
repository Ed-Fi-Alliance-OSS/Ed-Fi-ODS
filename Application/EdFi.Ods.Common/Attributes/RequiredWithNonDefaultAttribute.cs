// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Attributes
{
    /// <summary>
    /// Ensures that the value assigned is not the Type's default value (e.g. "null" for reference types, 0's for numbers, etc.).
    /// </summary>
    public class RequiredWithNonDefaultAttribute : ValidationAttribute
    {
        public RequiredWithNonDefaultAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string s)
            {
                if (s.Equals(string.Empty) || (!GeneratedArtifactStaticDependencies.Behaviors.AllowWhitespaceOnlyValues && IsWhiteSpace(s)))
                {
                    return BuildValidationResult($"{validationContext.DisplayName} is required and should not be left empty.");
                }

                return ValidationResult.Success;
            }
            else if (value is bool)
            {
                // A default boolean value (false) is a reasonable value
                return ValidationResult.Success;
            }
            else if (value is decimal)
            {
                // In case of decimal types, accept default values
                return ValidationResult.Success;
            }
            else if (value is DateTime dt && dt == default)
            {
                // DateTime default value is very specific (1/1/0001 12:00:00 AM), so it can be confusing for users
                // if they didn't used that value; no need to inform more than "the field is required"
                return BuildValidationResult($"{validationContext.DisplayName} is required.");
            }
            else if (value != null)
            {
                if (value.Equals(value.GetType().GetDefaultValue()))
                {
                    return BuildValidationResult($"{validationContext.DisplayName} value must be different than {value.GetType().GetDefaultValue()}.");
                }

                return ValidationResult.Success;
            }

            return BuildValidationResult($"{validationContext.DisplayName} is required.");

            ValidationResult BuildValidationResult(string message)
            {
                return new ValidationResult(message,
                    new[] { validationContext.MemberNamePath() });
            }
        }

        private bool IsWhiteSpace(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i])) return false;
            }

            return true;
        }
    }
}

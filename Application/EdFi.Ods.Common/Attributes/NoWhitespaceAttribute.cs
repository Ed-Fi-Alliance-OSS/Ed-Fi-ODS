// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Common.Attributes
{
    public class NoWhitespaceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string stringValue = value as string;

            // Validate property value does not contain any leading or trailing whitespace
            if (stringValue == null
                || !((stringValue.Length > 0 && char.IsWhiteSpace(stringValue, 0))
                    || (stringValue.Length > 0 && char.IsWhiteSpace(stringValue, stringValue.Length - 1))))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                $"{validationContext.MemberName} cannot contain leading or trailing spaces.",
                new[] { validationContext.MemberNamePath() });
        }
    }
}

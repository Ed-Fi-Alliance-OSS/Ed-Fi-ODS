// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;

namespace EdFi.Ods.Api.Common.Attributes
{
    public class NoWhitespaceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string stringValue = value as string;

            // Validate property value does not contain any leading or trailing whitespace
            return stringValue == null || stringValue.Equals(stringValue.Trim())
                ? ValidationResult.Success
                : new ValidationResult(
                    $"{validationContext.DisplayName} property is part of the primary key and therefore its value cannot contain leading or trailing whitespace.");
        }
    }
}

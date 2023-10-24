// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;

namespace EdFi.Ods.Common.Attributes;

/// <summary>
/// Validates that a resource reference is fully formed.
/// </summary>
public class FullyDefinedReferenceAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Ensures the supplied reference is either null, or is fully formed.
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (value is IResourceReference reference)
        {
            if (!reference.IsReferenceFullyDefined())
            {
                return new ValidationResult($"{validationContext.MemberName} is missing the following properties: {string.Join(", ", reference.GetUndefinedProperties())}");
            }
        }

        return ValidationResult.Success;
    }
}
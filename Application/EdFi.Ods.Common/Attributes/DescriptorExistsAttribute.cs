// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Common.Dependencies;

namespace EdFi.Ods.Common.Attributes;

public sealed class DescriptorExistsAttribute : ValidationAttribute
{
    private readonly string _descriptorName;

    public DescriptorExistsAttribute(string descriptorName)
    {
        _descriptorName = descriptorName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        try
        {
            if (default == GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId(_descriptorName, value.ToString()))
            {
                return new ValidationResult(
                    $"{_descriptorName} value '{value}' does not exist.",
                    new[] { validationContext.MemberName });
            }
        }
        catch (ValidationException ex)
        {
            return new ValidationResult(ex.Message, new[] { validationContext.MemberName });
        }

        return ValidationResult.Success;
    }
}

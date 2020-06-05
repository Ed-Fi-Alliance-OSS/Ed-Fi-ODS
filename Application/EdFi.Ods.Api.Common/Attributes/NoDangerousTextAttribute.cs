// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Api.Common.Validation;

namespace EdFi.Ods.Api.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NoDangerousTextAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string s = value as string;

            if (string.IsNullOrEmpty(s))
            {
                return ValidationResult.Success;
            }

            return CrossSiteScriptingValidation.IsDangerousString(s, out int matchIndex)
                ? new ValidationResult($"{validationContext.DisplayName} contains a potentially dangerous value.")
                : ValidationResult.Success;
        }
    }
}

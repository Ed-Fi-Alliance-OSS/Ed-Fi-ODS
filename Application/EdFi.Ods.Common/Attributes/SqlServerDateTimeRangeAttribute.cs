// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace EdFi.Ods.Common.Attributes
{
    /// <summary>
    /// Ensures that the value assigned falls within SQL server's datetime range
    /// </summary>
    public class SqlServerDateTimeRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!(value is DateTime))
            {
                throw new ArgumentException("SqlServerDateTimeRangeAttribute can only be used with DateTime types");
            }

            var dt = (DateTime) value;

            if (dt >= SqlDateTime.MinValue.Value &&
                dt <= SqlDateTime.MaxValue.Value)
            {
                return ValidationResult.Success;
            }

            var contextualDisplayName = validationContext == null
                ? string.Empty
                : validationContext.DisplayName;

            return
                new ValidationResult(
                    $"{contextualDisplayName} : '{value}' must be within SQL datetime range ('{SqlDateTime.MinValue.Value}' to '{SqlDateTime.MaxValue.Value}')");
        }
    }
}

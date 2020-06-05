// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EdFi.Ods.Api.Common.Attributes
{
    public class RequiredCollectionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var enumerable = value as IEnumerable;

            if (enumerable == null || !enumerable.Cast<object>()
                                                 .Any())
            {
                return new ValidationResult(string.Format("{0} requires at least one object in the collection.", validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}

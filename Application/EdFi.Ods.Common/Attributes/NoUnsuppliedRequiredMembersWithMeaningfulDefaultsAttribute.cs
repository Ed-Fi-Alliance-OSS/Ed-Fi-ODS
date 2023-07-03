// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EdFi.Ods.Common.Attributes
{
    public class NoUnsuppliedRequiredMembersWithMeaningfulDefaultsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IHasRequiredMembersWithMeaningfulDefaultValues resource)
            {
                if(resource.GetUnassignedMemberNames().Any())
                {
                    return new ValidationResult("Required value not explicitly assigned.", resource.GetUnassignedMemberNames());
                }
            }

            return ValidationResult.Success;
        }
    }
}

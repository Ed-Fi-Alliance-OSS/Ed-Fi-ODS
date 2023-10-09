﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EdFi.Common.Inflection;

namespace EdFi.Ods.Common.Attributes;

public sealed class NoDuplicateMembersAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var enumerable = value as IEnumerable;

        if (enumerable == null)
        {
            return ValidationResult.Success;
        }

        var itemNumber = 1;
        var enumerableHashSet = new HashSet<object>();

        foreach (var item in enumerable)
        {
            if (item != null)
            {
                if (!enumerableHashSet.Add(item))
                {
                    return new ValidationResult(
                        $"The {Inflector.AddOrdinalSuffix(itemNumber.ToString())} item of the {validationContext.DisplayName} collection is a duplicate.");
                }
            }

            itemNumber++;
        }

        // If we're still here, validation was successful
        return ValidationResult.Success;
    }
}

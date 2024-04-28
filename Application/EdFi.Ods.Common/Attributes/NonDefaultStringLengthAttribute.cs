// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;

namespace EdFi.Ods.Common.Attributes;

public class NonDefaultStringLengthAttribute : StringLengthAttribute
{
    public NonDefaultStringLengthAttribute(int maximumLength)
        : base(maximumLength) { }
    
    public override bool IsValid(object value)
    {
        // Skip the validation if the string is either null or empty.
        if (string.IsNullOrEmpty((string) value))
        {
            return true;
        }

        return base.IsValid(value);
    }
}

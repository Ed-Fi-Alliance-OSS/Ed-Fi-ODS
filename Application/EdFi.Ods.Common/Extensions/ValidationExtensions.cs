// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Common.Extensions;

public static class ValidationExtensions
{
    public static string MemberNamePath(this ValidationContext validationContext)
    {
        var pathBuilder = ValidationHelpers.GetPathBuilder(validationContext);

        if (pathBuilder.Length == 0)
        {
            return validationContext.MemberName;
        }
        
        return $"{pathBuilder}.{validationContext.MemberName}";
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EdFi.Ods.Common.Validation
{
    public static class ValidationResultExtensions
    {
        public static bool IsValid(this ValidationResult validationResult)
        {
            return validationResult == ValidationResult.Success;
        }

        public static bool IsValid(this IEnumerable<ValidationResult> validationResults)
        {
            return validationResults == null || validationResults.All(r => r == ValidationResult.Success);
        }
    }
}

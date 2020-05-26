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
            return !validationResults.Any(r => r != ValidationResult.Success);
        }

        public static string GetAllMessages(this IEnumerable<ValidationResult> validationResults, int indentLevel = 0)
        {
            var sb = new StringBuilder();

            foreach (var validationResult in validationResults)
            {
                GetAllMessages(sb, validationResult, new string('\t', indentLevel));
            }

            return sb.ToString();
        }

        public static string GetAllMessages(this ValidationResult validationResult, int indentLevel = 0)
        {
            var sb = new StringBuilder();
            GetAllMessages(sb, validationResult, new string('\t', indentLevel));
            return sb.ToString();
        }

        private static void GetAllMessages(StringBuilder sb, ValidationResult validationResult, string indent)
        {
            sb.AppendFormat("{0}{1}\n", indent, validationResult.ErrorMessage);

            if (validationResult is CompositeValidationResult)
            {
                var compositeResult = validationResult as CompositeValidationResult;

                foreach (var result in compositeResult.Results)
                {
                    GetAllMessages(sb, result, indent + "\t");
                }
            }
        }
    }
}

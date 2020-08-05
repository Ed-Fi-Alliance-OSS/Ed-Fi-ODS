// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace EdFi.LoadTools.BulkLoadClient
{
    public class BulkLoadValidationResult
    {
        public BulkLoadValidationResult()
        {
            ValidationErrors = new HashSet<string>();
        }

        public BulkLoadValidationResult(string errorMessage)
        {
            ValidationErrors = new HashSet<string>
            {
                errorMessage
            };
        }

        public void Add(string errorMessage)
        {
            ValidationErrors.Add(errorMessage);
        }

        public HashSet<string> ValidationErrors { get; set; }
        public bool Valid => !ValidationErrors.Any();
    }
}

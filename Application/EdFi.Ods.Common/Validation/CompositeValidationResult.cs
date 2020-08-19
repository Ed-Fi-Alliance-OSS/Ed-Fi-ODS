// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EdFi.Ods.Common.Validation
{
    public class CompositeValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();

        public CompositeValidationResult(string errorMessage)
            : base(errorMessage) { }

        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames)
            : base(errorMessage, memberNames) { }

        protected CompositeValidationResult(ValidationResult validationResult)
            : base(validationResult) { }

        public IEnumerable<ValidationResult> Results
        {
            get { return _results; }
        }

        public void AddResult(ValidationResult validationResult)
        {
            _results.Add(validationResult);
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Common;
using Validator = EdFi.Ods.Common.Validation.Validator;

namespace EdFi.Ods.Api.Validation
{
    public class DataAnnotationsResourceValidator : ObjectValidatorBase, IResourceValidator
    {
        public ICollection<ValidationResult> ValidateObject(object entity)
        {
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, validateAllProperties: true, validateEverything: true))
            {
                SetInvalid();
            }
            else
            {
                SetValid();
            }

            return validationResults;
        }
    }
}

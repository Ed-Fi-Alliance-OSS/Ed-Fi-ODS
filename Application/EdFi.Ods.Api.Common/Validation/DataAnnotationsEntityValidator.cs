// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Validation
{
    public class DataAnnotationsEntityValidator : ObjectValidatorBase, IEntityValidator
    {
        public virtual ICollection<ValidationResult> ValidateObject(object entity)
        {
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(entity, new ValidationContext(entity, null, null), validationResults, true);

            if (validationResults.Any())
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

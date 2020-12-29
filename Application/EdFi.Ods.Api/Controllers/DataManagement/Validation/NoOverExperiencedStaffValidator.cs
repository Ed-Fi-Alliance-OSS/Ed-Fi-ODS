// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Validation
{
    public class NoOverExperiencedStaffValidator : IEntityRecordValidator
    {
        public FullName SupportedEntityName { get; } = new FullName("edfi", "Staff");

        public void Validate(Entity entity, IDictionary<string, object> proposedValues, IList<string> validationMessages)
        {
            var experience = (decimal?) proposedValues["YearsOfPriorProfessionalExperience"];

            if (experience > 50.0M)
            {
                validationMessages.Add(
                    $"Staff has too much experience. Experience value of {experience} must be less than or equal to 50.");
            }
        }
    }
}

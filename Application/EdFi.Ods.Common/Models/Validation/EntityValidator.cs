// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;
using FluentValidation;

namespace EdFi.Ods.Common.Models.Validation
{
    public class EntityValidator : AbstractValidator<Entity>
    {
        public EntityValidator(DomainModel domainModel)
        {
            FullName aggregateName = new FullName();

            // Ensure entity doesn't have a schema of auth.
            RuleFor(entity => entity.Schema)
               .Must(schema => !schema.IsAuthSchema())
               .WithMessage(entity => $"Entity '{entity.FullName}' uses the reserved schema '{SystemConventions.AuthSchema}'.");

            // Ensure entity is assigned to a valid aggregate
            RuleFor(entity => entity.FullName)
               .Must(entityName => domainModel.AggregateFullNameByEntityFullName.TryGetValue(entityName, out aggregateName))
               .WithMessage("Entity '{PropertyValue}' not assigned to any aggregate.");

            // Ensure that each Entity's FullName.Schema are located in the Schemas in the DomainModel
            RuleFor(entity => entity)
               .Must(entity => domainModel.Schemas.Any(sc => sc.PhysicalName.Equals(entity.FullName.Schema)))
               .WithMessage(entity => $"Entity '{entity.FullName}' uses an undefined schema.");

            // If entity is not assigned to an aggregate, return
            if (string.Equals(aggregateName.ToString(), "."))
                return;

            // Ensure aggregate returned above is a valid aggregate within the domain model
            RuleFor(a => aggregateName)
               .Must(entityName => domainModel.AggregateByName.ContainsKey(aggregateName))
               .WithMessage("Aggregate '{PropertyValue}' not found in domain model.");
        }
    }
}

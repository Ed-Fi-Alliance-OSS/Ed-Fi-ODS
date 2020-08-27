// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using FluentValidation;

namespace EdFi.Ods.Common.Models.Validation
{
    public class AssociationValidator : AbstractValidator<Association>
    {
        public AssociationValidator(DomainModel domainModel)
        {
            //Ensure primary entity exists as an entity within the domain model
            RuleFor(association => association.PrimaryEntityFullName)
               .Must(entityName => domainModel.EntityByFullName.ContainsKey(entityName))
               .WithMessage(association => $"The primary entity '{{PropertyValue}}' of the association '{association.FullName}' could not be found.");

            //Ensure secondary entity exists as an entity within the domain model
            RuleFor(association => association.SecondaryEntityFullName)
               .Must(entityName => domainModel.EntityByFullName.ContainsKey(entityName))
               .WithMessage(association => $"The secondary entity '{{PropertyValue}}' of the association '{association.FullName}' could not be found.");

            // Ensure that each associate's FullName.Schema are located in the Schemas in the Domain-Model
            RuleFor(association => association)
               .Must(association => domainModel.Schemas.Any(sc => sc.PhysicalName.Equals(association.FullName.Schema)))
               .WithMessage(association => $"Association '{association.FullName}' is not located in the Schema-Definitions of the Domain-Model.");

            // Ensure that all source properties of each association are identifying properties on the source entity.
            RuleFor(association => association)
               .Must(association => association.PrimaryEntityAssociationProperties.All(ap => ap.EntityProperty.IsIdentifying))
               .WithMessage(association => $"Association '{association.FullName}' uses non-identifying properties ({string.Join(", ", association.PrimaryEntityAssociationProperties.Where(ap => !ap.EntityProperty.IsIdentifying).Select(ap => ap.PropertyName))}) from the primary entity.");
        }
    }
}

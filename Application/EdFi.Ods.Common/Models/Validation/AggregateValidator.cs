// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using FluentValidation;

namespace EdFi.Ods.Common.Models.Validation
{
    public class AggregateValidator : AbstractValidator<Aggregate>
    {
        public AggregateValidator(DomainModel domainModel)
        {
            //Ensure aggregate has 1 or more members
            RuleFor(aggregate => aggregate)
               .NotEmpty()
               .WithMessage(aggregate => $"Aggregate '{aggregate.FullName}' has no members.");

            //Ensure each member exists as an entity within the domain model
            RuleForEach(aggregate => aggregate.MemberEntityNames)
               .Must(m => domainModel.EntityByFullName.ContainsKey(m))
               .WithMessage(aggregate => $"Entity {{PropertyValue}} of Aggregate '{aggregate.FullName}' could not be found in the model.");

            // Ensure that each Aggregate's FullName.Schema are located in the Schemas in the Domain-Model
            RuleFor(aggregate => aggregate)
               .Must(aggregate => domainModel.Schemas.Any(sc => sc.PhysicalName.Equals(aggregate.FullName.Schema)))
               .WithMessage(aggregate => $"Aggregate '{aggregate.FullName}' uses an undefined schema.");
        }
    }
}

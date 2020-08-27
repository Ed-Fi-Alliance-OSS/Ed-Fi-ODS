// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;
using FluentValidation;

namespace EdFi.Ods.Common.Models.Validation
{
    public class SchemaValidator : AbstractValidator<Schema>
    {
        public SchemaValidator(DomainModel domainModel)
        {
            RuleFor(schema => schema.PhysicalName)
               .Must(name => !SystemConventions.IsAuthSchema(name))
               .WithMessage($"Schema '{SystemConventions.AuthSchema}' is reserved for system use.");
        }
    }
}

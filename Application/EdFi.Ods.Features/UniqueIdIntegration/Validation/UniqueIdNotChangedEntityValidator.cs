// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Api.Common.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Features.UniqueIdIntegration.Validation
{
    public class UniqueIdNotChangedEntityValidator : ObjectValidatorBase, IEntityValidator
    {
        private readonly IPersonUniqueIdToIdCache _personIdentifiersCache;

        public UniqueIdNotChangedEntityValidator(IPersonUniqueIdToIdCache personIdentifiersCache)
        {
            _personIdentifiersCache = personIdentifiersCache;
        }

        public virtual ICollection<ValidationResult> ValidateObject(object @object)
        {
            var validationResults = new List<ValidationResult>();
            var objType = @object.GetType();

            if (PersonEntitySpecification.IsPersonEntity(objType))
            {
                var objectWithIdentifier = (IHasIdentifier) @object;

                var persistedUniqueId = _personIdentifiersCache.GetUniqueId(objType.Name, objectWithIdentifier.Id);

                var objectWithUniqueId = (IIdentifiablePerson) @object;
                string newUniqueId = objectWithUniqueId.UniqueId;

                if (persistedUniqueId != null && persistedUniqueId != newUniqueId)
                {
                    validationResults.Add(new ValidationResult("A person's UniqueId cannot be modified."));
                }
            }

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
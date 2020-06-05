// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Api.Common.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Features.UniqueIdIntegration.Validation
{
    /// <summary>
    /// Implements a validator that ensures that the UniqueId provided on a person entity can be resolved
    /// to a previously established GUID-based Id value.  It is intended for use in implementations where
    /// there is a UniqueId system in the environment, and the UniqueIds supplied to the API are expected
    /// to be present and available through the PersonIdentifiersCache.
    /// </summary>
    public class EnsureUniqueIdAlreadyExistsEntityValidator : ObjectValidatorBase, IEntityValidator
    {
        public ICollection<ValidationResult> ValidateObject(object @object)
        {
            var validationResults = new List<ValidationResult>();

            var objType = @object.GetType();

            if (!PersonEntitySpecification.IsPersonEntity(objType))
            {
                SetValid();
                return new List<ValidationResult>();
            }

            // All Person entities should have an Id property.
            var entityWithIdentifier = @object as IHasIdentifier;

            // This should never happen.
            if (entityWithIdentifier == null)
            {
                throw new NotImplementedException(
                    string.Format(
                        "Entity of type '{0}' representing a person did not implement the {1} interface to provide access to the GUID-based identifier.  This implies an error in the implementation of the Person-type entity.",
                        objType.FullName,
                        typeof(IHasIdentifier).Name));
            }

            // Used in conjunction with the PopulateIdFromUniqueIdOnPeople pipeline step, the Id
            // property should have already been populated if the UniqueId provided on the request
            // existed previously.
            //
            // For implementations with an integrated UniqueId system, it is an invalid request
            // if we are unable to resolve the UniqueId to a GUID-based Id by this point in the
            // processing of the request.
            if (entityWithIdentifier.Id == default(Guid))
            {
                var person = @object as IIdentifiablePerson;

                // This should never happen.
                if (person == null)
                {
                    throw new NotImplementedException(
                        string.Format(
                            "Entity of type '{0}' representing a person did not implement the {1} interface to provide access to the UniqueId value.  This implies an error in the implementation of the Person-type entity.",
                            objType.FullName,
                            typeof(IIdentifiablePerson).Name));
                }

                validationResults.Add(
                    new ValidationResult(
                        string.Format(
                            "The supplied UniqueId value '{0}' was not resolved.",
                            person.UniqueId)));
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
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Validation;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.Security.Authorization.EntityAuthorization;

public interface IEntityInstanceAuthorizationValidator
{
    void Validate(object entity, string actionUri, string validationRuleSetName);
}

public class EntityInstanceAuthorizationValidator : IEntityInstanceAuthorizationValidator
{
    private readonly IExplicitObjectValidator[] _explicitObjectValidators;

    private readonly Lazy<Dictionary<string, Actions>> _bitValuesByAction;

    [Flags]
    private enum Actions
    {
        Create = 0x1,
        Read = 0x2,
        Update = 0x4,
        Delete = 0x8,
    }

    public EntityInstanceAuthorizationValidator(
        IExplicitObjectValidator[] explicitObjectValidators, 
        ISecurityRepository securityRepository)
    {
        _explicitObjectValidators = explicitObjectValidators;
        
        // Lazy initialization
        _bitValuesByAction = new Lazy<Dictionary<string, Actions>>(
            () => new Dictionary<string, Actions>
            {
                { securityRepository.GetActionByName("Create").ActionUri, Actions.Create },
                { securityRepository.GetActionByName("Read").ActionUri, Actions.Read },
                { securityRepository.GetActionByName("Update").ActionUri, Actions.Update },
                { securityRepository.GetActionByName("Delete").ActionUri, Actions.Delete }
            });
    }

    public void Validate(object entity, string actionUri, string validationRuleSetName)
    {
        // If there are explicit object validators, and we're modifying data
        if (_explicitObjectValidators.Any() && IsCreateUpdateOrDelete(actionUri))
        {
            // Validate the object using explicit validation
            var validationResults = _explicitObjectValidators.ValidateObject(entity, validationRuleSetName);

            if (!validationResults.IsValid())
            {
                string validationResultsText = string.Join(".", validationResults.Select(vr => vr.ToString()));

                throw new ValidationException(
                    $"Validation of '{entity.GetType().Name}' failed. {validationResultsText}");
            }
        }

        bool IsCreateUpdateOrDelete(string requestAction)
        {
            return (_bitValuesByAction.Value[requestAction] 
                & (Actions.Create | Actions.Update | Actions.Delete)) != 0;
        }
    }
}

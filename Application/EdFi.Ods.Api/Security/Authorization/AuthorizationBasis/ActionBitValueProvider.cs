// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

public interface IActionBitValueProvider
{
    int GetBitValue(string action);
}

public class ActionBitValueProvider : IActionBitValueProvider
{
    private readonly Lazy<Dictionary<string, int>> _bitValuesByAction;

    public ActionBitValueProvider(ISecurityRepository securityRepository)
    {
        _bitValuesByAction = new Lazy<Dictionary<string, int>>(
            () => new Dictionary<string, int>
            {
                { securityRepository.GetActionByName("Create").ActionUri, 1 },
                { securityRepository.GetActionByName("Read").ActionUri, 2 },
                { securityRepository.GetActionByName("Update").ActionUri, 4 },
                { securityRepository.GetActionByName("Delete").ActionUri, 8 },
                { securityRepository.GetActionByName("ReadChanges").ActionUri, 16 }
            });
    }
    
    public int GetBitValue(string action)
    {
        if (_bitValuesByAction.Value.TryGetValue(action, out int result))
        {
            return result;
        }
    
        throw new NotSupportedException("The requested action is not supported for authorization.");
    }
}

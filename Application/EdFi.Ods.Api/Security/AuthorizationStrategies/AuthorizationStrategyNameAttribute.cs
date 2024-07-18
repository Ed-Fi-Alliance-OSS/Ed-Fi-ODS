// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies;

/// <summary>
/// Provides the authorization strategy name that is associated with an <see cref="IAuthorizationStrategy" /> implementation
/// (replacing the previously used class naming convention). 
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
sealed class AuthorizationStrategyNameAttribute : Attribute
{
    public AuthorizationStrategyNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}

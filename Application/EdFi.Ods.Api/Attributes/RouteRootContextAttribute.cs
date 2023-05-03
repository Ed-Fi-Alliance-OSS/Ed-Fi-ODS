// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Attributes;

/// <summary>
/// Defines the root context used as the basis for the base route manipulation needed for multi-tenant mode and the presence
/// of a custom configured route template capturing additional ODS context.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class RouteRootContextAttribute : Attribute
{
    public RouteRootContextAttribute(RouteContextType contextType)
    {
        ContextType = contextType;
    }

    public RouteContextType ContextType { get; }
}

public enum RouteContextType
{
    /// <summary>
    /// Indicates the controller's route should never be manipulated (default behavior when attribute is not present).
    /// </summary>
    None,
    /// <summary>
    /// Indicates the controller's route should be manipulated to include tenant context when applicable.
    /// </summary>
    Tenant,
    /// <summary>
    /// Indicates the controller's route should be manipulated to include tenant context and ODS-specific context when applicable.
    /// </summary>
    Ods
}

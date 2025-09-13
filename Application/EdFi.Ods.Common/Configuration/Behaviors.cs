// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Configuration;

/// <summary>
/// Provides configuration settings for overriding certain API behaviors via configuration.
/// </summary>
public class Behaviors
{
    /// <summary>
    /// Overrides the default behavior changed in v7.3 of not allowing whitespace-only values in (non-key) properties.
    /// </summary>
    public bool AllowWhitespaceOnlyValues { get; set; }
}

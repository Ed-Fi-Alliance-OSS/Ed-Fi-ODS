// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Configuration.Sections;

/// <summary>
/// Represents the "Tenants" section of the application configuration.
/// </summary>
public class TenantsSection
{
    public Dictionary<string, Tenant> Tenants { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public class Tenant
{
    public Dictionary<string, string> ConnectionStrings { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    public Dictionary<string, OdsInstance> OdsInstances { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public class OdsInstance
{
    public string ConnectionString { get; set; }

    public Dictionary<string, string> ConnectionStringByDerivativeType { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}
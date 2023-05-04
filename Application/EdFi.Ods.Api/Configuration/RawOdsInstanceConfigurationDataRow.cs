// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Represents a raw result row from the EdFi_Admin function that returns ODS instance configuration data.
/// </summary>
public class RawOdsInstanceConfigurationDataRow
{
    public int OdsInstanceId { get; set; }

    public string ConnectionString { get; set; }

    public string ContextKey { get; set; }

    public string ContextValue { get; set; }

    public string DerivativeType { get; set; }

    public string ConnectionStringByDerivativeType { get; set; }
}

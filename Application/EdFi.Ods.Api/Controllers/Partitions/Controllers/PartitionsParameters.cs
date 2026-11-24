// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

/// <summary>
/// Reads the optional query string parameters of the partitions endpoint.
/// </summary>
public static class PartitionsParameters
{
    public const string AllowSmallPartitions = "allowSmallPartitions";

    /// <summary>
    /// Reads the allowSmallPartitions parameter. The name is matched in any case, and an empty value is treated
    /// as not supplied (small partitions are not allowed).
    /// </summary>
    /// <returns><c>false</c> when the parameter has a value that is not a boolean; otherwise <c>true</c>.</returns>
    public static bool TryGetAllowSmallPartitions(IDictionary<string, string> parameters, out bool allowSmallPartitions)
    {
        allowSmallPartitions = false;

        string value = parameters?
            .FirstOrDefault(p => string.Equals(p.Key, AllowSmallPartitions, StringComparison.OrdinalIgnoreCase))
            .Value;

        if (string.IsNullOrWhiteSpace(value))
        {
            return true;
        }

        return bool.TryParse(value, out allowSmallPartitions);
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

/// <summary>
/// Reads the optional query string parameters of the partitions endpoint.
/// </summary>
public static class PartitionsParameters
{
    public const string AllowSmallPartitions = "allowSmallPartitions";

    /// <summary>
    /// Reads the allowSmallPartitions parameter.
    /// </summary>
    /// <returns><c>false</c> when the parameter is present but is not a boolean; otherwise <c>true</c>.</returns>
    public static bool TryGetAllowSmallPartitions(IDictionary<string, string> parameters, out bool allowSmallPartitions)
    {
        allowSmallPartitions = false;

        if (parameters == null || !parameters.TryGetValue(AllowSmallPartitions, out string value))
        {
            return true;
        }

        return bool.TryParse(value, out allowSmallPartitions);
    }
}

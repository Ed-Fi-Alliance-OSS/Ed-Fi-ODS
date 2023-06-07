// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;

namespace EdFi.Ods.Api.Configuration;

public static class OdsInstanceConfigurationExtensions
{
    /// <summary>
    /// Applies configuration-based connection string overrides defined in the supplied dictionary (keyed by ODS instance id)
    /// to the subject <see cref="OdsInstanceConfiguration" />. 
    /// </summary>
    /// <param name="baseOdsInstanceConfiguration">The ODS instance configuration to be updated.</param>
    /// <param name="odsInstances">The ODS instance map loaded from configuration that contains the connection string overrides.</param>
    public static void ApplyOdsConnectionStringOverrides(
        this OdsInstanceConfiguration baseOdsInstanceConfiguration,
        Dictionary<string, OdsInstance> odsInstances)
    {
        ArgumentNullException.ThrowIfNull(baseOdsInstanceConfiguration);
        ArgumentNullException.ThrowIfNull(odsInstances);

        if (odsInstances.TryGetValue(baseOdsInstanceConfiguration.OdsInstanceIdAsString, out var odsInstance))
        {
            if (!string.IsNullOrEmpty(odsInstance.ConnectionString))
            {
                baseOdsInstanceConfiguration.ConnectionString = odsInstance.ConnectionString;
            }

            foreach (var derivativeType in DerivativeType.GetAll())
            {
                string derivativeConnectionString =
                    odsInstance.ConnectionStringByDerivativeType.GetValueOrDefault(derivativeType.DisplayName);

                if (!string.IsNullOrEmpty(derivativeConnectionString))
                {
                    baseOdsInstanceConfiguration.ConnectionStringByDerivativeType[derivativeType] = derivativeConnectionString;
                }
            }
        }
    }
}
